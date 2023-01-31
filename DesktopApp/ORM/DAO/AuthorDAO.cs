using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace DesktopApp.ORM.DAO
{
    public class AuthorDAO : AbstractDAO<Author>
    {
        string selectByNameSql;

        public AuthorDAO()
        {
            //6.1 - Nový autor
            insertSql = "INSERT INTO Author (first_name, last_name, birth_date, biography) VALUES (@1, @2, @3, @4)";

            //6.2 - Aktualizace autora
            updateSql = "UPDATE Author SET first_name = @1, last_name = @2, birth_date = @3, biography = @4 WHERE author_id = @5";

            //6.3 - Seznam autorů
            selectAllSql = "SELECT author_id, first_name, last_name, birth_date, biography FROM Author";
            selectSql = "SELECT author_id, first_name, last_name, birth_date, biography FROM Author WHERE author_id = @1";

            //6.3 - Seznam autorů - vyhledávání podle jména a příjmení
            selectByNameSql = "SELECT author_id, first_name, last_name" +
                               " FROM Author" +
                               " WHERE @1 IS NULL OR" +
                               " CHARINDEX(LOWER(@2), LOWER(first_name + ' ' + last_name)) != 0 OR" +
                               " CHARINDEX(LOWER(@3), LOWER(last_name + ' ' + first_name)) != 0" +
                               " ORDER BY first_name, last_name";
            isIdentity = true;
        }

        protected override int FillInsert(Author obj, SqlParameterCollection parameters)
        {
            int i = 0;
            parameters.AddWithValue("@" + (++i), obj.FirstName);
            parameters.AddWithValue("@" + (++i), obj.LastName);
            parameters.AddWithValue("@" + (++i), ObjOrDbNull(obj.BirthDate));
            parameters.AddWithValue("@" + (++i), ObjOrDbNull(obj.Biography));
            return i;
        }

        protected override Author LoadObject(SqlDataReader reader)
        {
            int i = -1; //nebo od 0 a pouzit i++
            Author author = new Author
            {
                Key = new Key(reader.GetInt32(++i)),
                FirstName = reader.GetString(++i),
                LastName = reader.GetString(++i)
            };
            if (!reader.IsDBNull(++i))
            {
                author.BirthDate = reader.GetDateTime(i);
            }
            if (!reader.IsDBNull(++i))
            {
                author.Biography = reader.GetString(i);
            }
            return author;
        }

        private Author LoadForSelectByName(SqlDataReader reader)
        {
            int i = -1;
            Author author = new Author
            {
                Key = new Key(reader.GetInt32(++i)),
                FirstName = reader.GetString(++i),
                LastName = reader.GetString(++i)
            };
            return author;
        }


        //6.3 - Seznam autorů - vyhledávání podle jména a příjmení
        public Collection<Author> SelectByName(string name)
        {
            object[] objects = { name, name, name };
            return CustomSelect(selectByNameSql, objects, LoadForSelectByName);
        }
    }
}
