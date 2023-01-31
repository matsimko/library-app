using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DesktopApp.ORM.DAO
{
    public class GenreDAO : AbstractDAO<Genre>
    {
        public GenreDAO()
        {
            //3.3 - Seznam žánrů
            selectAllSql = "SELECT genre_id, name FROM Genre ORDER BY name";
            selectSql = "SELECT genre_id, name FROM Genre WHERE genre_id = @1";
            //3.1 Nový žánr
            insertSql = "INSERT INTO Genre (name) VALUES (@1)";
            //3.4 - Smazání žánru
            deleteSql = "DELETE FROM Genre WHERE genre_id = @1";
            //3.2 - Aktualizace žánru
            updateSql = "UPDATE Genre SET name = @1 WHERE genre_id = @2";
            isIdentity = true;
        }

        protected override Genre LoadObject(SqlDataReader reader)
        {
            Key key = new Key(reader.GetInt32(0)); //new Key() { Fields = new[] { reader.GetInt32(0) } };
            string name = reader.GetString(1);
            return new Genre() { Key = key, Name = name };
        }

        protected override int FillInsert(Genre obj, SqlParameterCollection parameters)
        {
            int i = 0;
            parameters.AddWithValue("@" + (++i), obj.Name);
            return i;
        }

    }   
}
