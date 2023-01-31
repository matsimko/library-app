using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DesktopApp.ORM.DAO
{
    class BookGenreDAO : AbstractDAO<BookGenre>
    {

        private string selectForBookSql;

        public BookGenreDAO()
        {
            //4.1 - Nový žánr u knihy
            insertSql = "INSERT INTO Book_genre (book_id, genre_id) VALUES (@1, @2)";

            //4.2 - Seznam žánrů u knihy
            selectForBookSql = "SELECT Genre.genre_id, Genre.name" +
                                " FROM Book_genre JOIN Genre ON Genre.genre_id = Book_genre.genre_id" +
                                " WHERE Book_genre.book_id = @1";

            //4.3 - Smazání žánru u knihy
            deleteSql = "DELETE FROM Book_genre WHERE book_id = @1 AND genre_id = @2";
        }

        protected override int FillInsert(BookGenre obj, SqlParameterCollection parameters)
        {
            int i = 0;
            parameters.AddWithValue("@" + (++i), (object)obj.Key.Fields[0]);
            parameters.AddWithValue("@" + (++i), (object)obj.Key.Fields[1]);
            return i;
        }

        //aktuálně není potřeba
        protected override BookGenre LoadObject(SqlDataReader reader)
        {
            int i = -1;
            int bookId = reader.GetInt32(++i);
            int genreId = reader.GetInt32(++i);
            BookGenre bookGenre = new BookGenre
            {
                Key = new Key(new[] { bookId, genreId })
            };

            return bookGenre;
        }

        //2. moznost je dat GenreDAO().LoadObject public, a pouzit to
        private Genre LoadGenre(SqlDataReader reader)
        {
            int i = -1;
            Genre genre = new Genre
            {
                Key = new Key(reader.GetInt32(++i)),
                Name = reader.GetString(++i)
            };


            return genre;
        }

        //4.2 - Seznam žánrů u knihy
        public Collection<Genre> SelectForBook(int bookId)
        {
            object[] fields = { bookId };
            Collection<Genre> genres =  CustomSelect<Genre>(selectForBookSql, fields, LoadGenre);
            return genres;
        }
    }
}
