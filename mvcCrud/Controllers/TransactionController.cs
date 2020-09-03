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
    public class TransactionController : Controller
    {
        Datatrans db = new Datatrans();
        DataContent dbc = new DataContent();
        blltransaction bllt = new blltransaction();
        bllcategory bllc = new bllcategory();
        // GET: Transaction
        public ActionResult Index()
        {
            DataTable dt = bllt.GetTransaction();
            List<Transaction> li = new List<Transaction>();
            li = (from DataRow dr in dt.Rows
                  select new Transaction()
                  {
                     // trans_id = Convert.ToInt32(dr["trans_id"].ToString()),
                      category_id = Convert.ToInt32(dr["category_id"]),
                      category_name = (dr["category_name"].ToString()),
                     
                      amount = Convert.ToDecimal(dr["amount"].ToString()),
                      fiscal_year = (dr["fiscal_year"].ToString()),
                      status = (dr["status"].ToString()),
                    
                  }).ToList();

            return View(li);
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int id)
        {
            DataTable dt = bllt.GetCategoryId(id);
            if (dt.Rows.Count > 0)
            {
                return View((from DataRow dr in dt.Rows
                             select new Transaction()
                             {
                                 trans_id = Convert.ToInt32(dr["trans_id"].ToString()),
                                 category_id = Convert.ToInt32(dr["category_id"]),
                                 category_name = (dr["category_name"].ToString()),
                                 description = dr["description"].ToString(),
                                 paymentmode = dr["paymentmode"].ToString(),
                                 amount = Convert.ToDecimal(dr["amount"].ToString()),
                                 fiscal_year = (dr["fiscal_year"].ToString()),
                                 date = Convert.ToDateTime(dr["date"].ToString())

                             }).ToList());
            }
            return View();
        }
        public ActionResult SearchById(int id,DateTime from,DateTime to)
        {
            DataTable dt = bllt.GetCategoryIdByDate(id,from,to);
            if (dt.Rows.Count > 0)
            {
                return View((from DataRow dr in dt.Rows
                             select new Transaction()
                             {
                                 trans_id = Convert.ToInt32(dr["trans_id"].ToString()),
                                 category_id = Convert.ToInt32(dr["category_id"]),
                                 category_name = (dr["category_name"].ToString()),
                                 description = dr["description"].ToString(),
                                 paymentmode = dr["paymentmode"].ToString(),
                                 amount = Convert.ToDecimal(dr["amount"].ToString()),
                                 fiscal_year = (dr["fiscal_year"].ToString()),
                                 date = Convert.ToDateTime(dr["date"].ToString())

                             }).ToList());
            }
            return View();
        }
        // GET: Transaction/Create
        public ActionResult Create()
        {
            DataTable ds = bllc.GetCategory();
            List<SelectListItem> li = new List<SelectListItem>();
            for (int rows = 0; rows <= ds.Rows.Count - 1; rows++)
            {
                li.Add(new SelectListItem { Text = ds.Rows[rows]["category_name"].ToString() });

            }
            ViewData["FeedBack"] = li;

            return View();


        }
        string fiscal_year;
        int category_id;
        decimal amount;
        string status;
        // POST: Transaction/Create
        [HttpPost]

        public ActionResult Create(Transaction collection, string name)
        {
            try
            {
                // TODO: Add insert logic here
                string category_name = ((collection.category_name));
                string description = ((collection.description));
                string paymentmode = collection.paymentmode;
                DataTable dtc = bllc.GetCategoryName(category_name);
                if (dtc.Rows.Count > 0)
                {
                    category_id = Convert.ToInt32(dtc.Rows[0]["category_id"].ToString());
                    status= dtc.Rows[0]["status"].ToString();
                    if (status=="Income")
                    {
                        amount = (collection.amount);
                    }
                    else
                    {
                        amount = -(collection.amount);
                    }
                }
                DataTable dt = bllt.Getfiscalyear();
                if (dt.Rows.Count > 0)
                {
                    fiscal_year = dt.Rows[0]["fiscal_year"].ToString();
                }
                DateTime date = ((collection.date));
                int insert = bllt.InsertTransaction(category_id, category_name, date, description, amount, fiscal_year, paymentmode);
                if (insert > 0)
                {
                    ViewBag.msg = "Successfully Inserted";

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            DataTable dt = bllt.GetTransactionId(id);
            if (dt.Rows.Count > 0)
            {
                return View((from DataRow dr in dt.Rows
                             select new Transaction()
                             {
                                 trans_id = Convert.ToInt32(dr["trans_id"].ToString()),
                                 category_id = Convert.ToInt32(dr["category_id"]),
                                 category_name = (dr["category_name"].ToString()),
                                 description = dr["description"].ToString(),
                                 paymentmode = dr["paymentmode"].ToString(),
                                 amount = Convert.ToDecimal(dr["amount"].ToString()),
                                 fiscal_year = (dr["fiscal_year"].ToString()),
                                 date = Convert.ToDateTime(dr["date"].ToString())

                             }).SingleOrDefault());
            }
            else
            {
                return View();
            }
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Transaction collection)
        {
            try
            {
                // TODO: Add update logic here

                string category_name = ((collection.category_name));
                string description = ((collection.description));
                string paymentmode = ((collection.paymentmode));
                 int category_id = ((collection.category_id));
                string fiscal_year = ((collection.fiscal_year));
                DateTime date = ((collection.date));
                DataTable dtc = bllc.GetCategoryName(category_name);
                if (dtc.Rows.Count > 0)
                {
                    category_id = Convert.ToInt32(dtc.Rows[0]["category_id"].ToString());
                    status = dtc.Rows[0]["status"].ToString();
                    if (status == "income")
                    {
                        amount = (collection.amount);
                    }
                    else
                    {
                        amount = -(collection.amount);
                    }
                }
                int update = bllt.UpdateTransaction(id, category_id, category_name, date, description, amount, fiscal_year, paymentmode);
                if (update > 0)
                {
                    ViewBag.ItemMsg = "Updated Successfully";

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
     
        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
        {
            DataTable dt = bllt.GetTransactionId(id);
            if (dt.Rows.Count > 0)
            {
                return View((from DataRow dr in dt.Rows
                             select new Transaction()
                             {
                                 trans_id = Convert.ToInt32(dr["trans_id"].ToString()),
                                 category_id = Convert.ToInt32(dr["category_id"]),
                                 category_name = (dr["category_name"].ToString()),
                                 paymentmode = dr["paymentmode"].ToString(),
                                 description = dr["description"].ToString(),
                                 amount = Convert.ToDecimal(dr["amount"].ToString()),
                                 fiscal_year = (dr["fiscal_year"].ToString()),
                                 date = Convert.ToDateTime(dr["date"].ToString())

                             }).SingleOrDefault());
            }
            else
            {
                return View();
            }
        }

        // POST: Transaction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Transaction collection)
        {
            try
            {
                // TODO: Add delete logic here
                int delete = bllt.DeleteTransaction(id);
                if (delete > 0)
                {
                    ViewBag.msg = "Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        string seletedname;
        public ActionResult Search(string selectedname, string category_type)
        {
            List<Transaction> Li = new List<Transaction>();
            if (selectedname == "Category Name")
            {
                DataTable dt = bllt.SearchTransactionByname(category_type);
                if (dt.Rows.Count > 0)
                {
                    Li = (from DataRow dr in dt.Rows
                          select new Transaction()
                          {
                              trans_id = Convert.ToInt32(dr["trans_id"].ToString()),
                              category_id = Convert.ToInt32(dr["category_id"]),
                              category_name = (dr["category_name"].ToString()),
                              paymentmode = dr["paymentmode"].ToString(),
                              description = dr["description"].ToString(),
                              amount = Convert.ToDecimal(dr["amount"].ToString()),
                              fiscal_year = (dr["fiscal_year"].ToString()),
                              date = Convert.ToDateTime(dr["date"].ToString()),
                          }).ToList();
                }
            }
            else if (selectedname == "date")
            {
                DataTable dt = bllt.SearchTransactionDate(Convert.ToDateTime(category_type));
                if (dt.Rows.Count > 0)
                {
                    Li = (from DataRow dr in dt.Rows
                          select new Transaction()
                          {
                              trans_id = Convert.ToInt32(dr["trans_id"].ToString()),
                              category_id = Convert.ToInt32(dr["category_id"]),
                              category_name = (dr["category_name"].ToString()),
                              description = dr["description"].ToString(),
                              paymentmode = dr["paymentmode"].ToString(),
                              amount = Convert.ToDecimal(dr["amount"].ToString()),
                              fiscal_year = (dr["fiscal_year"].ToString()),
                              date = Convert.ToDateTime(dr["date"].ToString()),
                          }).ToList();
                }

            }
            return View(Li);
        }
    }
}
