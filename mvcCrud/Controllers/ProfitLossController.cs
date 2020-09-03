using BLLS.Account;
using mvcCrud.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcCrud.Controllers
{
    public class ProfitLossController : Controller
    {
        blltransaction bllt = new blltransaction();
        // GET: ProfitLoss
        public ActionResult Index()
        {
            DataTable dt = bllt.GetTransactionSumByMonth();
            
            List<ProfitLoss> li = new List<ProfitLoss>();
            List<ProfitLoss> list = new List<ProfitLoss>();
            li = (from DataRow dr in dt.Rows
                  select new ProfitLoss()
                  {
                      // category_id = Convert.ToInt32(dr["category_id"]),
                      category_name = (dr["category_name"].ToString()),
                      status = dr["status"].ToString(),
                      description = (dr["description"].ToString()),
                      amount = Convert.ToDecimal(dr["amount"].ToString()),
                      date = Convert.ToDateTime(dr["date"].ToString()),
                      month = (dr["month"].ToString()),
                  }).ToList();
     return View(li);
           
        }
        [HttpPost]
        public ActionResult SearchProfitLoss(string from,string to)
        {
            DataTable dt = bllt.SearchPLByDate(Convert.ToDateTime(from), Convert.ToDateTime(to));
            List<ProfitLoss> li = new List<ProfitLoss>();
            List<ProfitLoss> list = new List<ProfitLoss>();
            li = (from DataRow dr in dt.Rows
                  select new ProfitLoss()
                  {
                      // category_id = Convert.ToInt32(dr["category_id"]),
                      category_name = (dr["category_name"].ToString()),
                      status = dr["status"].ToString(),
                      description = (dr["description"].ToString()),
                      amount = Convert.ToDecimal(dr["amount"].ToString()),
                      date = Convert.ToDateTime(dr["date"].ToString()),
                      month = (dr["month"].ToString()),
                  }).ToList();

            return View(li);


        }
        decimal sum;
        decimal expenses;
        decimal income;
        public ActionResult IncomeStatement()
        {
            DataTable dt = bllt.sum_grand_total();
            DataTable dt1 = bllt.GetTransactionSumByStatus();
            DataTable dt2 = bllt.GetTransactionSumByIncomeStatus();
            if (dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sum += Convert.ToDecimal(dt.Rows[i]["grand_total"].ToString());
                }
              // decimal sales = Convert.ToDecimal(dt.Rows[0]["grand_total"].ToString());
                ViewBag.MyString = sum;
            }
            if (dt1.Rows.Count>0)
            {
                if (dt1.Rows[0]["amount"].ToString() == "")
                {
                    expenses = 0;
                }
                else
                {
                    expenses = Convert.ToDecimal(dt1.Rows[0]["amount"].ToString());
                }
                ViewBag.Myexpenses = expenses;
            }
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0]["amount"].ToString() == "")
                {
                    income = 0;
                }
                else
                {
                     income = Convert.ToDecimal(dt2.Rows[0]["amount"].ToString());
                }
                ViewBag.Myincome = income;
            }
            return View();
        }
        public ActionResult IncomeStatementByDate(DateTime from,DateTime to)
        {
            DataTable dt = bllt.sum_grand_total_date(from,to);
            DataTable dt1 = bllt.GetTransactionSumByStatusDate(from,to);
            DataTable dt2 = bllt.GetTransactionSumByIncomeStatusDate(from, to);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sum += Convert.ToDecimal(dt.Rows[i]["grand_total"].ToString());
                }
                // decimal sales = Convert.ToDecimal(dt.Rows[0]["grand_total"].ToString());
                ViewBag.MyString = sum;
            }
            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["amount"].ToString() == "")
                {
                    expenses = 0;
                }
                else
                {
                    expenses = Convert.ToDecimal(dt1.Rows[0]["amount"].ToString());
                }
                ViewBag.Myexpenses = expenses;
            }
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0]["amount"].ToString() == "")
                {
                    income = 0;
                }
                else
                {
                    income = Convert.ToDecimal(dt2.Rows[0]["amount"].ToString());
                }
                ViewBag.Myincome = income;
            }
            return View();
        }
    }
}
