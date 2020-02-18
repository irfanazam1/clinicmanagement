using System;

using System.Collections.Generic;



namespace ClinicManagement.Persistence
{
    public class NpgsqlDatabaseImpl : IDatabase
    {
        private static IDatabase _instance = null;
        private static object _lock = new object();

        private NpgsqlDatabaseImpl() { }

        public static IDatabase GetInstance()
        {
            lock (_lock)
            { 
                if (_instance == null)
                {
                    _instance = new NpgsqlDatabaseImpl();
                }
           }
            return _instance;
        }

        public bool AddObject(IDBObject dbObject)
        {
            Npgsql.NpgsqlConnection conn = null;
            Npgsql.NpgsqlConnection readerConn = null;
            Npgsql.NpgsqlTransaction trans = null;
            try
            {
                if (dbObject != null)
                {
                    bool result = this.UpdateObject(dbObject);
                    if (!result)
                    {
                        //Add Object
                        conn = (Npgsql.NpgsqlConnection)NpgsqlConnectionImpl.GetInstance().GetNewConnection();
                        readerConn = (Npgsql.NpgsqlConnection)NpgsqlConnectionImpl.GetInstance().GetNewConnection();
                        string strSql = dbObject.GetAddStatement();
                        Npgsql.NpgsqlCommand insertCommand = new Npgsql.NpgsqlCommand(strSql);
                        trans = conn.BeginTransaction();
                        insertCommand.Connection = conn;
                        insertCommand.ExecuteNonQuery();
                        trans.Commit();                      
                        object savedObject = this.GetDataReader(dbObject.GetUniqueObjectQuery(), readerConn);
                        if (savedObject != null)
                        {
                            Npgsql.NpgsqlDataReader reader = (Npgsql.NpgsqlDataReader)savedObject;
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    dbObject.SetId(reader.GetInt32(reader.GetOrdinal("id")));
                                }
                               
                                return true;
                            }
                        }
                        return false;
                    }
                    return result;
                }
            }
            catch(Exception ex)
            {
                if(trans != null)
                {
                    trans.Rollback();
                }
                throw ex;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
                if(readerConn != null)
                {
                    readerConn.Close();
                }
            }
            return false;
        }

        public bool DeleteObject(IDBObject dbObject)
        {
            Npgsql.NpgsqlTransaction trans = null;
            Npgsql.NpgsqlConnection conn = null;
            try
            {
                if (dbObject != null)
                {
                    conn = (Npgsql.NpgsqlConnection)NpgsqlConnectionImpl.GetInstance().GetNewConnection();
                    Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(dbObject.GetDeleteStatement());
                    command.Connection = conn;
                    trans = conn.BeginTransaction();
                    int count = command.ExecuteNonQuery();
                    trans.Commit();
                    if(count > 0) {
                        return true;
                    }
                    
                    

                }
            }
            catch(Exception ex)
            {
                if(trans != null)
                {
                    trans.Rollback();
                }
                throw ex;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
                
            }
            return false;
            
        }

        public bool UpdateObject(IDBObject dbObject)
        {
            Npgsql.NpgsqlConnection conn = null;
            Npgsql.NpgsqlTransaction trans = null;
            Npgsql.NpgsqlConnection readerConn = null;
            try
            {
                if (dbObject != null)
                {
                    conn = (Npgsql.NpgsqlConnection)NpgsqlConnectionImpl.GetInstance().GetNewConnection();
                    readerConn = (Npgsql.NpgsqlConnection)NpgsqlConnectionImpl.GetInstance().GetNewConnection();
                    object result = this.GetDataReader(dbObject.GetObjectByIdQuery(), readerConn);
                    if (result != null)
                    {
                        string strSql = dbObject.GetUpdateStatement();
                        Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(strSql);
                        command.Connection = conn;
                        trans = conn.BeginTransaction();
                        command.ExecuteNonQuery();
                        trans.Commit();
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                if(trans != null)
                {
                    trans.Rollback();
                }
                throw ex;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
                if(readerConn != null)
                {
                    readerConn.Close();
                }
            }
            return false;
        }

        public object GetDataReader(String query, System.Data.IDbConnection conn)
        {
            try
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query);

                command.Connection = (Npgsql.NpgsqlConnection)conn;
                Npgsql.NpgsqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    return reader;
                }
            }
            finally{}
            return null;
        }

        public DbRecord GetData(string query)
        {
            Npgsql.NpgsqlConnection conn = null;
            try
            {
                conn = (Npgsql.NpgsqlConnection)NpgsqlConnectionImpl.GetInstance().GetNewConnection();
                object reader = this.GetDataReader(query, conn);
                DbRecord record = new DbRecord();
                if (reader != null)
                {
                    Npgsql.NpgsqlDataReader npgsqlReader = (Npgsql.NpgsqlDataReader)reader;
                    record.FieldCount = npgsqlReader.FieldCount;
                    for (int i = 0; i < npgsqlReader.FieldCount; i++)
                    {
                        record.Columns.Add(npgsqlReader.GetName(i));
                    }
                    while (npgsqlReader.Read())
                    {
                        List<object> records = new List<object>();
                        for (int i = 0; i < npgsqlReader.FieldCount; i++)
                        {
                            records.Add(npgsqlReader.GetValue(i));

                        }
                        record.RowCount++;
                        record.Records.Add(records);

                    }
                    npgsqlReader.Close();
                }
                return record;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

    }
}
  