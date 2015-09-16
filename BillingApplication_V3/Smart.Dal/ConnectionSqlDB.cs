using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Smart.Dal
{
    public class ConnectionSqlDB
    {
        private string connectionString;
        public SqlConnection sqlCon;


        public ConnectionSqlDB()
        {
               connectionString = Smart.Dal.Properties.Settings.Default.SQLConnectionString;
        }

        private Boolean Connect()
        {
            sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = connectionString;
                sqlCon.Open();

                return true;
                // You can get the server version 
                // MySqlConnect.ServerVersion
            }
            catch (Exception Ex)
            {
                // Try to close the connection
                if (sqlCon != null)
                    sqlCon.Dispose();

                throw new Exception(Ex.Message + "; connectionstring: " + connectionString);
            }

        }

        private Boolean Disconnect()
        {
            if (sqlCon.State.ToString() == "Open")
            {
                try
                {
                    sqlCon.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return true;
            }
        }


        //-------------check existance of data
        public int CheckExistence(string TableName, string KeyField, string ConditionString)
        {
            SqlCommand cmdSql = new SqlCommand();


            int functionReturnValue = 0;
            string sqlString = null;



            sqlString = "select count(" + KeyField + ") as cnt from " + TableName;
            if (!string.IsNullOrEmpty(ConditionString))
            {
                sqlString = sqlString + " " + ConditionString;
            }

            try
            {
                Connect();
                cmdSql.Connection = sqlCon;
                cmdSql.CommandText = sqlString;
                functionReturnValue = int.Parse(cmdSql.ExecuteScalar().ToString());


                return functionReturnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                Disconnect();


                cmdSql.Dispose();

            }

        }

        public int CheckExistence(string TableName, string KeyField, string ConditionString, Hashtable lstData)
        {
            SqlCommand cmdSql = new SqlCommand();


            int functionReturnValue = 0;
            string sqlString = null;



            sqlString = "select count(" + KeyField + ") as cnt from " + TableName;
            if (!string.IsNullOrEmpty(ConditionString))
            {
                sqlString = sqlString + " " + ConditionString;
            }

            try
            {
                Connect();
                cmdSql.Connection = sqlCon;
                cmdSql.CommandText = sqlString;


                foreach (DictionaryEntry dict in lstData)
                {
                    Type type = dict.Value.GetType();

                    cmdSql.Parameters.AddWithValue(dict.Key.ToString(), dict.Value.ToString());
                }

                functionReturnValue = int.Parse(cmdSql.ExecuteScalar().ToString());


                return functionReturnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                Disconnect();


                cmdSql.Dispose();

            }

        }

        //--------------get maximum id 
        public int GetMaximumID(string TableName, string FieldName, int DefaultID, string ConditionString)
        {
            int functionReturnValue = 0;
            string sqlString = null;

            SqlCommand cmdSql = new SqlCommand();


            sqlString = "select max(" + FieldName + ") as cnt from " + TableName;
            if (!string.IsNullOrEmpty(ConditionString))
            {
                sqlString = sqlString + " " + ConditionString;
            }
            try
            {
                Connect();
                cmdSql.Connection = sqlCon;
                cmdSql.CommandText = sqlString;
                functionReturnValue = int.Parse(cmdSql.ExecuteScalar().ToString());


                return functionReturnValue;
            }
            catch (FormatException ex)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {


                Disconnect();

                cmdSql.Dispose();

            }

        }

        //---------------det datatable
        public DataTable GetDataTable(string TableName, string Fields, string ConditionString)
        {

            string sqlString = null;
            SqlDataAdapter sqlAdapter = new SqlDataAdapter();

            sqlString = "select " + Fields + " from " + TableName;

            if (!string.IsNullOrEmpty(ConditionString))
            {
                sqlString = sqlString + " " + ConditionString;
            }

            DataTable dt = new DataTable();

            try
            {
                Connect();
              
                sqlAdapter = new SqlDataAdapter(sqlString, sqlCon);
                sqlAdapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Disconnect();

                sqlAdapter.Dispose();
            }
        }

        public DataTable GetDataTable(string TableName, string Fields, string ConditionString, Hashtable lstData)
        {

            string sqlString = null;

            SqlCommand cmdSql = new SqlCommand();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter();

            sqlString = "select " + Fields + " from " + TableName;

            if (!string.IsNullOrEmpty(ConditionString))
                sqlString = sqlString + " " + ConditionString;
            
            DataTable dt = new DataTable();

            try
            {
                Connect();
                cmdSql.Connection = sqlCon;
                cmdSql.CommandText = sqlString;

                if (lstData != null)
                {
                    foreach (DictionaryEntry dict in lstData)
                    {
                        Type type = dict.Value.GetType();

                        cmdSql.Parameters.AddWithValue(dict.Key.ToString(), dict.Value.ToString());
                    }
                }

                sqlAdapter = new SqlDataAdapter(sqlString, sqlCon);
                sqlAdapter.SelectCommand = cmdSql;
                sqlAdapter.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                Disconnect();

                cmdSql.Dispose();


                sqlAdapter.Dispose();

            }
        }

        public DataTable GetDataTableFromSP(string SPName, Hashtable lstData)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlAdapter=new SqlDataAdapter();
            try
            {
                Connect();

                sqlAdapter = new SqlDataAdapter(SPName, sqlCon);
                sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sprmparam = new SqlParameter();
                foreach (DictionaryEntry dict in lstData)
                {
                    Type type = dict.Value.GetType();
                    sprmparam = new SqlParameter(dict.Key.ToString(), dict.Value.ToString());

                    sqlAdapter.SelectCommand.Parameters.Add(sprmparam);
                }

                sqlAdapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Disconnect();

                sqlAdapter.Dispose();
            }
        }

        public string ExecuteScaler(string TableName, string FieldName, string ConditionString, Hashtable lstData)
        {
            string functionReturnValue = "";
            string sqlString = null;

            SqlCommand cmdSql = new SqlCommand();


            sqlString = "select " + FieldName + " as val from " + TableName;
            if (!string.IsNullOrEmpty(ConditionString))
            {
                sqlString = sqlString + " " + ConditionString;
            }
            try
            {
                Connect();
                cmdSql.Connection = sqlCon;
                cmdSql.CommandText = sqlString;

                foreach (DictionaryEntry dict in lstData)
                {
                    Type type = dict.Value.GetType();

                    cmdSql.Parameters.AddWithValue(dict.Key.ToString(), dict.Value.ToString());
                }

                if (cmdSql.ExecuteScalar() != null)
                    functionReturnValue = cmdSql.ExecuteScalar().ToString();
                else
                    functionReturnValue = "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                Disconnect();

                cmdSql.Dispose();

            }

            if (functionReturnValue == null)
                functionReturnValue = "";


            return functionReturnValue;
        }

        //get dataset
        public DataSet GetDataSet(string TableName, string Fields, string ConditionString)
        {

            string sqlString = null;

            SqlCommand cmdSql = new SqlCommand();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter();

            sqlString = "select " + Fields + " from " + TableName;

            if (!string.IsNullOrEmpty(ConditionString))
            {

                sqlString = sqlString + " " + ConditionString;

            }

            DataSet ds = new DataSet();

            try
            {
                Connect();
                cmdSql.Connection = sqlCon;
                cmdSql.CommandText = sqlString;
                sqlAdapter = new SqlDataAdapter(sqlString, sqlCon);
                sqlAdapter.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Disconnect();

                cmdSql.Dispose();

                sqlAdapter.Dispose();
            }
        }

        //--------------execute scaler query
        public string ExecuteScaler(string TableName, string FieldName, string ConditionString)
        {
            string functionReturnValue = "";
            string sqlString = null;

            SqlCommand cmdSql = new SqlCommand();



            sqlString = "select " + FieldName + " as val from " + TableName;
            if (!string.IsNullOrEmpty(ConditionString))
            {
                sqlString = sqlString + " " + ConditionString;
            }
            try
            {
                Connect();
                cmdSql.Connection = sqlCon;
                cmdSql.CommandText = sqlString;

                if (cmdSql.ExecuteScalar() != null)
                    functionReturnValue = cmdSql.ExecuteScalar().ToString();
                else
                    functionReturnValue = "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                Disconnect();

                cmdSql.Dispose();

            }

            if (functionReturnValue == null)
                functionReturnValue = "";


            return functionReturnValue;
        }

        //-------------execute not query
        public int ExecuteNonQuery(string QueryString)
        {
            int functionReturnValue = 0;

            SqlCommand cmdSql = new SqlCommand();


            try
            {
                Connect();
                cmdSql.Connection = sqlCon;
                cmdSql.CommandText = QueryString;

                functionReturnValue = cmdSql.ExecuteNonQuery();

                return functionReturnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Disconnect();

                cmdSql.Dispose();
            }


        }

        //-------------execute not query with one parameter
        public int ExecuteNonQueryWithImageParameter(string QueryString, Byte[] imagedata)
        {
            int functionReturnValue = 0;

            SqlCommand cmdSql = new SqlCommand();

            try
            {
                Connect();
                cmdSql.Connection = sqlCon;
                cmdSql.CommandText = QueryString;


                //SqlCommand oc = new SqlCommand("insert into ImageList_T values(5,@Image,'2.jpg')", con);

                cmdSql.Parameters.AddWithValue("@Image", imagedata);


                //var param = cmdSql.Parameters.AddWithValue("nvarcharParam", bytes);
                //param.DbType = type;

                functionReturnValue = cmdSql.ExecuteNonQuery();

                return functionReturnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Disconnect();

                cmdSql.Dispose();
            }


        }

        public int ExecuteNonQueryWithFileParameter(string QueryString, Byte[] filedata)
        {
            int functionReturnValue = 0;

            SqlCommand cmdSql = new SqlCommand();

            try
            {
                Connect();
                cmdSql.Connection = sqlCon;
                cmdSql.CommandText = QueryString;

                cmdSql.Parameters.AddWithValue("@File", filedata);

                functionReturnValue = cmdSql.ExecuteNonQuery();

                return functionReturnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Disconnect();

                cmdSql.Dispose();
            }
        }

        public int ExecuteNonQuery(string QueryString, Hashtable lstData)
        {
            int functionReturnValue = 0;

            SqlCommand cmdSql = new SqlCommand();

            try
            {
                Connect();
                cmdSql.Connection = sqlCon;
                cmdSql.CommandText = QueryString;

                foreach (DictionaryEntry dict in lstData)
                {
                    Type type = dict.Value.GetType();

                    if (type.Name == "Byte[]")
                        cmdSql.Parameters.AddWithValue(dict.Key.ToString(), dict.Value);
                    else
                        cmdSql.Parameters.AddWithValue(dict.Key.ToString(), dict.Value.ToString());
                }

                functionReturnValue = cmdSql.ExecuteNonQuery();

                return functionReturnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Disconnect();

                cmdSql.Dispose();
            }
        }
        //-------------execute select query with one parameter
        public DataTable ExecuteSelectQuery(string sqlString, string paramName, string value, DbType type)
        {
            SqlCommand cmdSql = new SqlCommand();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                Connect();
                cmdSql.Connection = sqlCon;
                cmdSql.CommandText = sqlString;

                var param = cmdSql.Parameters.AddWithValue(paramName, value);
                param.DbType = type;

                sqlAdapter = new SqlDataAdapter(sqlString, sqlCon);
                sqlAdapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Disconnect();
                cmdSql.Dispose();
                sqlAdapter.Dispose();
            }


        }
    }
}
