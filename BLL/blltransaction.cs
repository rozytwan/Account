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
    public class blltransaction
    {
        public DataTable GetTransaction()
        {
            return DAL.getuser("select distinct(t.category_name),sum(amount) as amount,t.category_id,fiscal_year,c.status from acc_transactions t inner join account_category c on t.category_id=c.category_id group by t.category_name,t.category_id,fiscal_year,c.status", null);
        }
        public DataTable GetTransactionSumByMonth()
        {
            return DAL.getuser("select t.category_name,status,date,FORMAT(date, 'MMMM')as month,amount,description from acc_transactions t join account_category c on t.category_id=c.category_id order by status desc", null);
        }
        public DataTable GetTransactionSumByStatus()
        {
            return DAL.getuser("select  sum(amount) as amount from acc_transactions t join account_category c on t.category_id=c.category_id where status='expenses'", null);
        }
        public DataTable GetTransactionSumByIncomeStatus()
        {
            return DAL.getuser("select  sum(amount) as amount from acc_transactions t join account_category c on t.category_id=c.category_id where status='Income' and paymentmode!='Credit'", null);
        }
        public DataTable GetTransactionSumByStatusDate(DateTime from,DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
      {
          new SqlParameter("@from",from),
           new SqlParameter("@to",to)
      };
            return DAL.getuser("select  sum(amount) as amount from acc_transactions t join account_category c on t.category_id=c.category_id where status='Expenses' and cast(date as date) between @from and @to", parm);
        }
        public DataTable GetTransactionSumByIncomeStatusDate(DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
      {
          new SqlParameter("@from",from),
           new SqlParameter("@to",to)
      };
            return DAL.getuser("select  sum(amount) as amount from acc_transactions t join account_category c on t.category_id=c.category_id where status='Income' and cast(date as date) between @from and @to", parm);
        }
        public int InsertTransaction(int category_id, string category_name, DateTime date, string description, decimal amount, string fiscal_year, string paymentmode)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_id",category_id),
               new SqlParameter("@category_name",category_name),
                new SqlParameter("@date",date),
                new SqlParameter("@description",description),
                  new SqlParameter("@amount",amount),
                new SqlParameter("@fiscal_year",fiscal_year),
                 new SqlParameter("@paymentmode",paymentmode),

            };
            return DAL.IDU("insert into acc_transactions(category_id,category_name,date,description,amount,fiscal_year,paymentmode) values (@category_id,@category_name,@date,@description,@amount,@fiscal_year,@paymentmode)", parm);
        }
        public DataTable GetTransactionId(int trans_id)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@trans_id",trans_id)
           };
            return DAL.getuser("select * from acc_transactions where trans_id=@trans_id", parm);
        }
        public DataTable GetCategoryId(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@category_id",category_id)
           };
            return DAL.getuser("select * from acc_transactions where category_id=@category_id", parm);
        }
        public DataTable GetCategoryIdByDate(int category_id,DateTime from,DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@category_id",category_id),
                new SqlParameter("@from",from),
                 new SqlParameter("@to",to),
           };
            return DAL.getuser("select * from acc_transactions where date between @from and @to and category_id=@category_id", parm);
        }
        public int DeleteTransaction(int trans_id)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@trans_id",trans_id)
           };
            return DAL.IDU("Delete from acc_transactions where trans_id=@trans_id", parm);
        }
        public DataTable SearchTransactionByname(string category_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
          new SqlParameter("@category_name",category_name)
            };
            return DAL.getuser("select * from acc_transactions where category_name like @category_name +'%'", parm);
        }
        public DataTable SearchTransactionDate(DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
          new SqlParameter("@date",date)
            };
            return DAL.getuser("select * from acc_transactions where cast(date as date)=@date", parm);
        }
        public DataTable SearchPLByDate(DateTime datefrom,DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
          new SqlParameter("@datefrom",datefrom),
           new SqlParameter("@dateto",dateto)
            };
            return DAL.getuser("select t.category_name,status,date,FORMAT(date, 'MMMM')as month,amount,description from acc_transactions t join account_category c on t.category_id=c.category_id where date between @datefrom and @dateto order by status desc", parm);
        }
        public int UpdateTransaction(int trans_id, int category_id, string category_name, DateTime date, string description, decimal amount, string fiscal_year, string paymentmode)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@trans_id",trans_id),
                   new SqlParameter("@category_id",category_id),
               new SqlParameter("@category_name",category_name),
                new SqlParameter("@date",date),
                new SqlParameter("@description",description),
                  new SqlParameter("@amount",amount),
                new SqlParameter("@fiscal_year",fiscal_year),
                new SqlParameter("@paymentmode",paymentmode),
   };
            return DAL.IDU("Update acc_transactions set category_id=@category_id,category_name=@category_name,date=@date,description=@description,amount=@amount,fiscal_year=@fiscal_year,paymentmode=@paymentmode where trans_id=@trans_id", parm);
        }
        public DataTable Getfiscalyear()
        {
            return DAL.getuser("select * from tbl_fiscal_year where is_active='True'", null);
        }
        public DataTable sum_grand_total()
        {
            return DAL.getuser("select DISTINCT bill_no,grand_total,sub_total,discount,tax_amount,service_charge from tbl_sales_record where bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void)", null);
        }
        public DataTable sum_grand_total_date(DateTime from,DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
          new SqlParameter("@from",from),
           new SqlParameter("@to",to)
          };
            return DAL.getuser("select DISTINCT bill_no,grand_total,sub_total,discount,tax_amount,service_charge from tbl_sales_record where cast(date_of_sale as date) between @from and @to and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void)", parm);
        }
    }
}
