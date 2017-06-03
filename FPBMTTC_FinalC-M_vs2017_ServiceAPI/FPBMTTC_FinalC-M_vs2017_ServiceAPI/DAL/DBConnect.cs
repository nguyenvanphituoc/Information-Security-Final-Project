using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public partial class DBConnect
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter adp;
       // public static string strConnect { get; set; }

        public DBConnect(string strConnect)
        {
            cnn = new SqlConnection(strConnect);
            cmd = cnn.CreateCommand();
        }  
        // Select query
        public DataSet ExecuteQueryDataSet(
            string strSQL, CommandType ct,
            params SqlParameter[] param)
        {
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            if (param != null)
                foreach (SqlParameter p in param)
                    cmd.Parameters.Add(p);
            adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }
        public DataTable Execute_fnTable(string strSQL,
        ref string error,
       params SqlParameter[] param)
        {

            cnn.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataReader dtread;
            if (param != null)
                foreach (SqlParameter p in param)
                    cmd.Parameters.Add(p);
            SqlParameter returnParam = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.NVarChar);
            returnParam.Direction = System.Data.ParameterDirection.ReturnValue;

            try
            {
               dtread = cmd.ExecuteReader();
               dt.Load(dtread);
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            return dt;
        }
        public object Execute_fnScalar(string strSQL,
         ref string error,
        params SqlParameter[] param)
        {

            cnn.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.StoredProcedure;

            if (param != null)
                foreach (SqlParameter p in param)
                    cmd.Parameters.Add(p);
            SqlParameter returnParam = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.NVarChar);
            returnParam.Direction = System.Data.ParameterDirection.ReturnValue;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                cnn.Close();
            }

            return returnParam.Value;
        }
        public string ExecuteQueryXML(string strSQL, CommandType ct, params SqlParameter[] p)
        {
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.GetXml();
        }
        // action query
        public bool MyExecuteNonQuery(string strSQL,
            CommandType ct, ref string error,
            params SqlParameter[] param)
        {
            bool f = false;
            cnn.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            if (param != null)
                foreach (SqlParameter p in param)
                    cmd.Parameters.Add(p);
            try
            {
                cmd.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                cnn.Close();
            }
            return f;
        }
        //aggregate
        public string MyExecuteScalar(string strSQL,
           CommandType ct, ref string error,
           params SqlParameter[] param)
        {
            string f = "";
            cnn.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            if (param != null)
                foreach (SqlParameter p in param)
                    cmd.Parameters.Add(p);
            try
            {
                f = cmd.ExecuteScalar().ToString();

            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                cnn.Close();
            }
            return f;
        }    
        public void closeConnection()
        {
            if (cnn.State == ConnectionState.Open) cnn.Close();
        }
    }
}

