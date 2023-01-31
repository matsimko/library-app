using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace DesktopApp.ORM.DAO
{
    class BookDAO : AbstractDAO<Book>
    {
        public BookDAO()
        {
            //1.3 - Seznam knih
            selectAllSql = "SELECT Book.book_id, Book.title, Book.release_year, Book.author_id," +
                           " Author.first_name, Author.last_name" +
                           " FROM Book" +
                           " JOIN Author ON Book.author_id = Author.author_id";
            //1.5 - Detail knihy (kopie se aktualne ziskavaji v samostatnem dotazu)
            selectSql = "SELECT Book.book_id, Book.title, Book.release_year, Book.description, Book.author_id," +
                        " Author.first_name, Author.last_name, Book.language_id, Language.name" +
                        " FROM Book" +
                        " JOIN Author ON Book.author_id = Author.author_id" +
                        " JOIN Language ON Book.language_id = Language.language_id" +
                        " WHERE Book.book_id = @1";
            //1.1 - Nová kniha
            insertSql = "INSERT INTO Book (title, title_lower, release_year, description, author_id, language_id) VALUES (@1, @2, @3, @4, @5, @6)";
            //1.2 - Aktualizace knihy
            updateSql = "UPDATE Book" +
                        " SET title = @1, title_lower = @2, release_year = @3, description = @4, author_id = @5, language_id = @6" +
                        " WHERE book_id = @7";

            isIdentity = true;
        }


        public override Book Select(Key key)
        {
            return Select(key, LoadForSelectDetail);
        }


        protected override Book LoadObject(SqlDataReader reader)
        {
            int i = -1;
            Book book = new Book
            {
                Key = new Key(reader.GetInt32(++i)),
                Title = reader.GetString(++i)
            };
            
            if (!reader.IsDBNull(++i))
            {
                book.ReleaseYear = reader.GetInt32(i);
            }
            /*if (!reader.IsDBNull(++i))
            {
                book.Description = reader.GetString(i);
            }*/
            book.Author = new Author
            {
                Key = new Key(reader.GetInt32(++i)),
                FirstName = reader.GetString(++i),
                LastName = reader.GetString(++i)
            };
            /*book.Language = new Language
            {
                Key = new Key(reader.GetInt32(++i))
            };*/

            return book;
        }

        private Book LoadForSelectDetail(SqlDataReader reader)
        {
            Book book = new Book();
            int i = -1;
            book.Key = new Key(reader.GetInt32(++i));
            book.Title = reader.GetString(++i);
            if(!reader.IsDBNull(++i))
            {
                book.ReleaseYear = reader.GetInt32(i);
            }
            if (!reader.IsDBNull(++i))
            {
                book.Description = reader.GetString(i);
            }
            book.Author = new Author
            {
                Key = new Key(reader.GetInt32(++i)),
                FirstName = reader.GetString(++i),
                LastName = reader.GetString(++i)
            };
            book.Language = new Language
            {
                Key = new Key(reader.GetInt32(++i)),
                Name = reader.GetString(++i)
            };

            //aktuálně se využívá další dotaz
            book.BookCopies = new BookCopyDAO().SelectForBook(book.Key.Id);
            book.Genres = new BookGenreDAO().SelectForBook(book.Key.Id);

            return book;
        }



        protected override int FillInsert(Book obj, SqlParameterCollection parameters)
        {
            int i = 0;
            parameters.AddWithValue("@" + (++i), obj.Title);
            parameters.AddWithValue("@" + (++i), obj.Title.ToLower());
            parameters.AddWithValue("@" + (++i), ObjOrDbNull(obj.ReleaseYear));
            parameters.AddWithValue("@" + (++i), ObjOrDbNull(obj.Description));
            parameters.AddWithValue("@" + (++i), (object) obj.Author.Key.Id);
            parameters.AddWithValue("@" + (++i), (object) obj.Language.Key.Id);
            return i;
        }

        //1.4 - Hledání knih
        public Collection<Book> Search(string title = null, int? authorId = null,
            int? languageId = null, Collection<int> genreIds = null,
            int? releaseYearFrom = null, int? releaseYearTo = null)
        {
            string genreIdList = null;
            if(genreIds != null)
            {
                genreIdList = String.Join(",", genreIds);
            }
            string[] paramNames = { "title", "author_id", "language_id", "genre_id_list", "release_year_from", "release_year_to" };
            object[] paramValues = { title, authorId, languageId, genreIdList, releaseYearFrom, releaseYearTo };
            return ExecuteStoredProcedure_Reader("searchBooks", paramNames, paramValues);
        }


    }
}
