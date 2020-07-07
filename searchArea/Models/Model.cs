using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace searchArea.Models
{
    public class Model
    {
        private SqlConnection myConnection = null;
        public Model(SqlConnection myConnection) //建構子
        {
            this.myConnection = myConnection;
        }

        public int Area_Amount(string area)
        {
            int result = 0;
            try
            {
                if (this.myConnection.State == System.Data.ConnectionState.Closed)
                {
                    this.myConnection.Open();
                }
                using (SqlCommand sqlCmd = new SqlCommand("GET_RegionCount", this.myConnection))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@City", area);
                    SqlParameter param = sqlCmd.Parameters.Add("@Amount", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;//設定為輸出參數
                    sqlCmd.ExecuteNonQuery();  
                    if(param.Value.ToString() != "") //查詢不到結果，會是回傳空字串
                    {
                        result = int.Parse(param.Value.ToString());
                    }                
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            finally
            {
                if (this.myConnection.State == System.Data.ConnectionState.Open)
                {
                    this.myConnection.Close();
                }
            }
            return result;
        }
    }
}