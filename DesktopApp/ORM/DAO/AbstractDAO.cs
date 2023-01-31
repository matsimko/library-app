using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DesktopApp.ORM.DAO
{
    /// <summary>
    /// Tato třída se postará o CRUD operace pro každý doménový objekt.
    /// Potomkům stačí nadefinovat dané CRUD stringy a stringy netriválních dotazů (s využitím CustomSelect),
    /// implementovat LoadObject pro načtení objektu ze SELECTu a fillInsert pro vyplnění parametrů INSERTu a UPDATu
    /// a určit, zda insert využívá IDENTITY sloupec.
    /// Operace, které nemají být podporované, se nechají na null a db.CreateCommand vyhodí NotSupportedException.
    /// Dále je umožněno volat procedury a funkce.
    /// </summary>
    public abstract class AbstractDAO<T> where T : DomainObject
    {  
        protected string selectSql;
        protected string selectAllSql;
        protected string deleteSql;
        protected string insertSql;
        protected string updateSql;
        protected bool isIdentity = false;


        protected abstract T LoadObject(SqlDataReader reader);

        /// <returns>number of parameteres filled</returns>
        protected abstract int FillInsert(T obj, SqlParameterCollection parameters);



        private void FillKey(Key key, SqlParameterCollection parameters, int startIdx = 1)
        {
            if(key == null)
            {
                return;
            }
            string param;
            for(int i = 0; i < key.Fields.Length; i++)
            {
                param = "@" + (i + startIdx);
                parameters.AddWithValue(param, key.Fields[i]);
            }
        }

        private void FillCustomSelect(object[] objects, SqlParameterCollection parameters)
        {
            string param;
            for (int i = 0; i < objects.Length; i++)
            {
                param = "@" + (i + 1);
                parameters.AddWithValue(param, ObjOrDbNull(objects[i]));
            }
        }

        public virtual Collection<T> SelectAll()
        {
            return SelectAll(LoadObject);
        }

        /// <summary>
        /// The customLoad enables the SELECT to return data different than data returned from other SELECTs
        /// because each can be loaded differently
        /// </summary>
        /// <param name="customLoad"></param>
        protected Collection<T> SelectAll(Func<SqlDataReader, T> customLoad)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(selectAllSql);
            SqlDataReader reader = db.Select(command);

            Collection<T> objects = new Collection<T>();
            T obj;
            while (reader.Read())
            {
                obj = customLoad(reader);
                objects.Add(obj);
            }

            reader.Close();
            db.Close();

            return objects;
        }

        public virtual T Select(Key key)
        {
            return Select(key, LoadObject);
        }

        protected T Select(Key key, Func<SqlDataReader, T> customLoad)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(selectSql);
            FillKey(key, command.Parameters);
            SqlDataReader reader = db.Select(command);

            T obj = default;
            if (reader.Read())
            {
                obj = customLoad(reader);
            }

            reader.Close();
            db.Close();

            return obj;
        }

        protected virtual Collection<T> CustomSelect(string sql, object[] fields)
        {
            return CustomSelect(sql, fields, LoadObject);
        }

        protected Collection<T> CustomSelect(string sql, object[] fields, Func<SqlDataReader, T> customLoad)
        {
            return CustomSelect<T>(sql, fields, customLoad);
        }

        protected Collection<CustomType> CustomSelect<CustomType>(string sql, object[] fields, Func<SqlDataReader, CustomType> customLoad)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(sql);
            FillCustomSelect(fields, command.Parameters);
            SqlDataReader reader = db.Select(command);

            Collection<CustomType> objects = new Collection<CustomType>();
            CustomType obj = default;
            while (reader.Read())
            {
                obj = customLoad(reader);
                objects.Add(obj);
            }

            reader.Close();
            db.Close();

            return objects;
        }

        public int Insert(T obj)
        {
            Database db = new Database();
            db.Connect();

            string sql = isIdentity ? insertSql + "; SELECT SCOPE_IDENTITY()" : insertSql;
            SqlCommand command = db.CreateCommand(sql);
            FillInsert(obj, command.Parameters);

            int ret;
            if (isIdentity)
            {
                ret = db.ExecuteScalar(command);
                obj.Key = new Key(ret);
            }
            else
            {
                ret = db.ExecuteNonQuery(command);
            }

            db.Close();

            return ret;
        }

        public int Update(T obj)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(updateSql);
            int startIdx = FillInsert(obj, command.Parameters) + 1;
            FillKey(obj.Key, command.Parameters, startIdx);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }

        public int Delete(T obj)
        {
            return Delete(obj.Key);
        }

        public int Delete(Key key)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(deleteSql);
            FillKey(key, command.Parameters);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }

        protected object ObjOrDbNull(object obj)
        {
            return obj ?? DBNull.Value; //(obj != null) ? obj : DBNull.Value;
        }

        protected object IdOrDbNull(DomainObject obj)
        {
            if(obj != null && obj.Key != null)
            {
                return obj.Key.Id;
            }
            else
            {
                return DBNull.Value;
            }
        }


        //param variables are all INPUT in these versions

        protected int ExecuteStoredProcedure(string name, string[] paramNames, object[] paramValues, bool scalar = false)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(name);
            FillProcedureParams(paramNames, paramValues, command.Parameters);
            int ret;
            if(!scalar)
            {
                ret = db.ExecuteStoredProcedure(command);
            }
            else
            {
                ret = db.ExecuteStoredProcedure_Scalar(command);
            }

            db.Close();

            return ret;
        }

        public virtual Collection<T> ExecuteStoredProcedure_Reader(string name, string[] paramNames, object[] paramValues)
        {
            return ExecuteStoredProcedure_Reader(name, paramNames, paramValues, LoadObject);
        }

        protected Collection<T> ExecuteStoredProcedure_Reader(string name, string[] paramNames, object[] paramValues,
            Func<SqlDataReader, T> customLoad)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(name);
            FillProcedureParams(paramNames, paramValues, command.Parameters);
            SqlDataReader reader = db.ExecuteStoredProcedure_Reader(command);


            Collection<T> objects = new Collection<T>();
            T obj;
            while (reader.Read())
            {
                obj = customLoad(reader);
                objects.Add(obj);
            }

            reader.Close();
            db.Close();

            return objects;
        }


        protected void FillProcedureParams(string[] paramNames, object[] paramValues, SqlParameterCollection parameters)
        {
            if (paramNames.Length != paramValues.Length)
            {
                throw new ArgumentException("paramNames.Length != paramValues.Length");
            }
            for(int i = 0; i < paramNames.Length; i++)
            {
                parameters.AddWithValue("@" + paramNames[i], ObjOrDbNull(paramValues[i]));
            }
        }

        protected object ExecuteFunction(string name, string[] paramNames, object[] paramValues, SqlDbType returnType)
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(name);
            FillProcedureParams(paramNames, paramValues, command.Parameters);
            SqlParameter returnValue = command.Parameters.Add("@RETURN_VALUE", returnType);
            returnValue.Direction = ParameterDirection.ReturnValue;
            db.ExecuteStoredProcedure(command);

            db.Close();

            return returnValue.Value;
        }

    }
}
