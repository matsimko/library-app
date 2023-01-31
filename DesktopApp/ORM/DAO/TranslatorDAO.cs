using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace DesktopApp.ORM.DAO
{
    public class TranslatorDAO : AbstractDAO<Translator>
    {
        //string selectByNameSql;

        public TranslatorDAO()
        {
            //7.1 - Nový překladatel
            insertSql = "INSERT INTO Translator (first_name, last_name, birth_date, biography) VALUES (@1, @2, @3, @4)";

            //7.2 - Aktualizace překladatele
            updateSql = "UPDATE Translator SET first_name = @1, last_name = @2, birth_date = @3, biography = @4 WHERE translator_id = @5";

            //7.3 - Seznam překladatelů
            selectAllSql = "SELECT translator_id, first_name, last_name, birth_date, biography FROM Translator";
            selectSql = "SELECT translator_id, first_name, last_name, birth_date, biography FROM Translator WHERE translator_id = @1";

            /* selectByNameSql = "SELECT translator_id, first_name, last_name" +
                                " FROM Translator" +
                                " WHERE @1 IS NULL OR" +
                                " CHARINDEX(LOWER(@2), LOWER(first_name + ’ ’ + last_name)) != 0 OR" +
                                " CHARINDEX(LOWER(@3), LOWER(last_name + ’ ’ + first_name)) != 0";*/
            isIdentity = true;
        }

        protected override int FillInsert(Translator obj, SqlParameterCollection parameters)
        {
            int i = 0;
            parameters.AddWithValue("@" + (++i), obj.FirstName);
            parameters.AddWithValue("@" + (++i), obj.LastName);
            parameters.AddWithValue("@" + (++i), ObjOrDbNull(obj.BirthDate));
            parameters.AddWithValue("@" + (++i), ObjOrDbNull(obj.Biography));
            return i;
        }

        protected override Translator LoadObject(SqlDataReader reader)
        {
            Translator translator = new Translator();
            int i = -1;
            translator.Key = new Key(reader.GetInt32(++i));
            translator.FirstName = reader.GetString(++i);
            translator.LastName = reader.GetString(++i);
            if (!reader.IsDBNull(++i))
            {
                translator.BirthDate = reader.GetDateTime(i);
            }
            if (!reader.IsDBNull(++i))
            {
                translator.Biography = reader.GetString(i);
            }
            return translator;
        }

       /* private Translator LoadForSelectByName(SqlDataReader reader)
        {
            Translator translator = new Translator();
            int i = 0;
            translator.Key = new Key(reader.GetInt32(++i));
            translator.FirstName = reader.GetString(++i);
            translator.LastName = reader.GetString(++i);
            return translator;
        }


        public Collection<Translator> SelectByName(string name)
        {
            object[] objects = { name, name, name };
            return CustomSelect(objects, LoadForSelectByName);
        }*/
    }
}
