using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOA
{
   public class DAL
    {
        public static AppSettingsReader aps = new AppSettingsReader();

        public static SqlConnection getconnection()
        {

            var sqlcon = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;//connection string from app.config

            SqlConnection scon = new SqlConnection(sqlcon);
            if (scon.State != ConnectionState.Open)
            {
                scon.Open();
                SqlCommand sqlcmd = new SqlCommand();

            }
            return scon;

        }
        public static int IDU(string sql, SqlParameter[] parm)
        {

            using (SqlConnection scon = getconnection())
            {
                SqlCommand scmd = new SqlCommand(sql, scon);
                scmd.CommandTimeout = 200;
                if (parm == null)
                {
                    scmd.Parameters.Add(new SqlParameter("@0", DBNull.Value));
                }
                else if (parm != null)
                {
                    scmd.Parameters.AddRange(parm);
                }
                try
                {

                    return scmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }
        public static int IUD_SP(string sql, CommandType cmdtype, SqlParameter[] param)
        {


            using (SqlConnection con = getconnection())
            {

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = cmdtype;
                cmd.CommandTimeout = 200;
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                try
                {

                    return cmd.ExecuteNonQuery();//insert delete update
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static DataTable getuser(string sql, SqlParameter[] parm)
        {

            using (SqlConnection scon = getconnection())
            {
                SqlCommand scmd = new SqlCommand(sql, scon);
                scmd.CommandTimeout = 200;
                if (parm != null)
                {
                    scmd.Parameters.AddRange(parm);
                }

                SqlDataAdapter sda = new SqlDataAdapter(scmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;


            }

        }
    }
}

