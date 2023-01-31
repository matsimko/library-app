using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DesktopApp.ORM.DAO
{
    public class BookCopyDAO : AbstractDAO<BookCopy>
    {
        private string selectForBookSql;
        
        public BookCopyDAO()
        {
            //2.1 - Nová kopie knihy
            insertSql = "INSERT INTO Book_copy (release_year, book_id, creation_date, translator_id, language_id) VALUES (@1, @2, @3, @4, @5)";
            //2.2 - Aktualizace kopie knihy
            updateSql = "UPDATE Book_copy SET release_year = @1, book_id = @2, creation_date = @3, translator_id = @4, language_id = @5" +
                        " WHERE book_copy_id = @6";
            //2.3 - Seznam kopií knih
            selectAllSql = "SELECT book_copy_id, release_year, book_id, creation_date, translator_id, language_id FROM Book_copy";
            selectSql = "SELECT book_copy_id, release_year, book_id, creation_date, translator_id, language_id FROM Book_copy WHERE book_copy_id = @1";
            //2.4 - Seznam kopií dané knihy
            selectForBookSql = "SELECT Book_copy.book_copy_id, Book_copy.release_year, Book_copy.book_id, Book_copy.creation_date," +
                                    " Translator.translator_id, Translator.first_name, Translator.last_name," +
                                    " Language.language_id, Language.name," +
                                    " COUNT(CASE WHEN Reservation_queue.queue_position != 0 OR Reservation_queue.end_date IS NOT NULL THEN 1 END) as peopleInQueueCount," +
                                    " COUNT(CASE WHEN Reservation_queue.queue_position = 0 AND Reservation_queue.end_date IS NULL THEN 1 END) as isBorrowed" +
                                " FROM Book_copy " +
                                " LEFT JOIN Translator ON Translator.translator_id = Book_copy.translator_id" +
                                " JOIN Language ON Language.language_id = Book_copy.language_id" +
                                " LEFT JOIN Reservation_queue ON Reservation_queue.book_copy_id = Book_copy.book_copy_id" +
                                " WHERE book_id = @1" + 
                                " GROUP BY Book_copy.book_copy_id, Book_copy.release_year, Book_copy.book_id, Book_copy.creation_date," +
                                    " Translator.translator_id, Translator.first_name, Translator.last_name," +
                                    " Language.language_id, Language.name ";

            isIdentity = true;
        }

        protected override int FillInsert(BookCopy obj, SqlParameterCollection parameters)
        {
            obj.CreationDate = DateTime.Now;

            int i = 0;
            parameters.AddWithValue("@" + (++i), ObjOrDbNull(obj.ReleaseYear));
            parameters.AddWithValue("@" + (++i), (object) obj.BookId);
            parameters.AddWithValue("@" + (++i), obj.CreationDate);
            parameters.AddWithValue("@" + (++i), IdOrDbNull(obj.Translator));
            parameters.AddWithValue("@" + (++i), IdOrDbNull(obj.Language));
            return i;
        }

        protected override BookCopy LoadObject(SqlDataReader reader)
        {
            int i = -1;
            BookCopy bookCopy = new BookCopy
            {
                Key = new Key(reader.GetInt32(++i)),
            };
            if (!reader.IsDBNull(++i))
            {
                bookCopy.ReleaseYear = reader.GetInt32(i);
            }
            bookCopy.BookId = reader.GetInt32(++i);
            bookCopy.CreationDate = reader.GetDateTime(++i);
            bookCopy.Translator = new Translator();
            if (!reader.IsDBNull(++i))
            {
                bookCopy.Translator.Key = new Key(reader.GetInt32(i));
            }
            bookCopy.Language = new Language
            {
                Key = new Key(reader.GetInt32(++i)),
            };

            return bookCopy;
        }

        private BookCopy LoadForSelectForBook(SqlDataReader reader)
        {
            int i = -1;
            BookCopy bookCopy = new BookCopy
            {
                Key = new Key(reader.GetInt32(++i)),
            };
            if (!reader.IsDBNull(++i))
            {
                bookCopy.ReleaseYear = reader.GetInt32(i);
            }
            bookCopy.BookId = reader.GetInt32(++i);
            bookCopy.CreationDate = reader.GetDateTime(++i);
            bookCopy.Translator = new Translator();
            if (!reader.IsDBNull(++i))
            {
                bookCopy.Translator.Key = new Key(reader.GetInt32(i));
            }
            if (!reader.IsDBNull(++i))
            {
                bookCopy.Translator.FirstName = reader.GetString(i);
            }
            if (!reader.IsDBNull(++i))
            {
                bookCopy.Translator.LastName = reader.GetString(i);
            }          
            bookCopy.Language = new Language
            {
                Key = new Key(reader.GetInt32(++i)),
                Name = reader.GetString(++i)
            };
            bookCopy.PeopleInQueueCount = reader.GetInt32(++i);
            bookCopy.IsBorrowed = Convert.ToBoolean(reader.GetInt32(++i));

            return bookCopy;

        }

        //2.4 - Seznam kopií dané knihy
        public Collection<BookCopy> SelectForBook(int bookId)
        {
            object[] fields = { bookId };
            return CustomSelect(selectForBookSql, fields, LoadForSelectForBook );
        }

        //2.5 - Informace o kopii 
        public string BookCopyInfo(int bookCopyId)
        {
            string[] paramNames = { "book_copy_id" };
            object[] paramValues = { bookCopyId };
            return (string) ExecuteFunction("bookCopyInfo", paramNames, paramValues, SqlDbType.VarChar);
        }
    }
}
