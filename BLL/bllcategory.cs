using DOA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS.Account
{
    public class bllcategory
    {
        public DataTable GetCategory()
        {
            return DAL.getuser("select * from account_category", null);
        }
        public int InsertCategory(string category_name, string category_type, string category_code, string status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
               new SqlParameter("@category_name",category_name),
                new SqlParameter("@category_type",category_type),
                new SqlParameter("@category_code",category_code),
                new SqlParameter("@status",status),
            };
            return DAL.IDU("insert into account_category(category_name,category_type,category_code,status) values (@category_name,@category_type,@category_code,@status)", parm);
        }
        public DataTable GetCategoryId(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@category_id",category_id)
           };
            return DAL.getuser("select * from account_category where category_id=@category_id", parm);
        }
        public DataTable GetCategoryName(string category_name)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@category_name",category_name)
           };
            return DAL.getuser("select * from account_category where category_name=@category_name", parm);
        }
        public DataTable SearchCategoryType(string category_type)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
          new SqlParameter("@category_type",category_type)
            };
            return DAL.getuser("select * from account_category where category_type like @category_type +'%'", parm);
        }
        public DataTable SearchCategoryCode(string category_code)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
          new SqlParameter("@category_code",category_code)
            };
            return DAL.getuser("select * from account_category where category_code like @category_code +'%'", parm);
        }
        public int DeleteCategory(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@category_id",category_id)
           };
            return DAL.IDU("Delete from account_category where category_id=@category_id", parm);
        }
        public int UpdateCategoryId(int category_id, string category_name, string category_type, string category_code, string status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
               new SqlParameter("@category_id",category_id),
                new SqlParameter("@category_name",category_name),
                new SqlParameter("@category_type",category_type),
                new SqlParameter("@category_code",category_code),
                  new SqlParameter("@status",status)
   };
            return DAL.IDU("Update account_category set category_name=@category_name,category_type=@category_type,category_code=@category_code,status=@status where category_id=@category_id", parm);
        }
    }
}
