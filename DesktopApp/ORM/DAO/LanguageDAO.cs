using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DesktopApp.ORM.DAO
{
    public class LanguageDAO : AbstractDAO<Language>
    {
        public LanguageDAO()
        {
            //5.3 - Seznam jazyků
            selectAllSql = "SELECT language_id, name FROM Language ORDER BY name";
            selectSql = "SELECT language_id, name FROM Language WHERE language_id = @1";
            //5.1 - Nový jazyk
            insertSql = "INSERT INTO Language (name) VALUES (@1)";
            //5.4 - Smazání jazyka
            deleteSql = "DELETE FROM Language WHERE language_id = @1";
            //5.2 Aktualizace jazyka
            updateSql = "UPDATE Language SET name = @1 WHERE language_id = @2";
            isIdentity = true;
        }

        protected override Language LoadObject(SqlDataReader reader)
        {
            Key key = new Key(reader.GetInt32(0)); //new Key() { Fields = new[] { reader.GetInt32(0) } };
            string name = reader.GetString(1);
            return new Language() { Key = key, Name = name };
        }

        protected override int FillInsert(Language obj, SqlParameterCollection parameters)
        {
            int i = 0;
            parameters.AddWithValue("@" + (++i), obj.Name);
            return i;
        }

    }
}
