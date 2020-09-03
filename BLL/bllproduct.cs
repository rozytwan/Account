using DOA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class bllproduct
    {
        public DataTable GetData()
        {
            return DAL.getuser("select * from Products ", null);
        }
        public int InsertProduct(string productname,int serialnumber)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
               new SqlParameter("@productname",productname),
                new SqlParameter("@serialnumber",serialnumber)
            };
            return DAL.IDU("insert into Products(productname,serialnumber) values (@productname,@serialnumber)", parm);
        }
        public int UpdateProduct(int id,string productname, int serialnumber)
        {
            SqlParameter[] parm = new SqlParameter[]
            { new SqlParameter("@id",id),
               new SqlParameter("@productname",productname),
                new SqlParameter("@serialnumber",serialnumber)
            };
            return DAL.IDU("Update Products set productname=@productname,serialnumber=@serialnumber where id=@id", parm);
        }
        public DataTable GetProductById(int id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
          new SqlParameter("@id",id)
            };
            return DAL.getuser("select * from Products where id=@id", parm);
        }
        public int DeleteProduct(int id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
          new SqlParameter("@id",id)
            };
            return DAL.IDU("delete from Products where id=@id", parm);
        }
        public DataTable SearchProduct(string productname)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
          new SqlParameter("@productname",productname)
            };
            return DAL.getuser("select * from Products where productname like @productname +'%'", parm);
        }
        public DataTable UserSelection(string productname,int serialnumber)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
          new SqlParameter("@username",productname),
            new SqlParameter("@password",serialnumber),
            };
            return DAL.getuser("select * from Products where productname=@username and serialnumber=@password", parm);
        }
    }
}
