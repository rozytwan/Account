using BLL;
using mvcCrud.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace mvcCrud.Controllers
{
    public class ProductController : Controller
    {
        DataContext db = new DataContext();
        // GET: Product
        bllproduct bllp = new bllproduct();
        public ActionResult Index()
        {
            DataTable dt = bllp.GetData();
            List<Product> li = new List<Product>();
            li = (from DataRow dr in dt.Rows
                  select new Product()
                  {
                      id = Convert.ToInt32(dr["id"]),
                      productname = dr["productname"].ToString(),
                      serialnumber = Convert.ToInt32(dr["serialnumber"].ToString()),
                  }).ToList();

            return View(li);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            DataTable dt = bllp.GetProductById(id);
            if (id == null || id == 0)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return View(response);
            }
            else
            {
                return View((from DataRow dr in dt.Rows
                             select new Product()
                             {
                                 id = Convert.ToInt32(dr["id"]),
                                 productname = dr["productname"].ToString(),
                                 serialnumber = Convert.ToInt32(dr["serialnumber"].ToString()),

                             }).SingleOrDefault());

            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            DataTable ds = bllp.GetData();
            List<SelectListItem> li = new List<SelectListItem>();
            for (int rows = 0; rows <= ds.Rows.Count - 1; rows++)
            {
                li.Add(new SelectListItem { Text = ds.Rows[rows]["productname"].ToString() });
            }
            ViewData["FeedBack"] = li;
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product collection)
        {
            try
            {
                // TODO: Add insert logic here
                string productname = ((collection.productname));
                int serialnumber = ((collection.serialnumber));
                int insert = bllp.InsertProduct(productname, serialnumber);

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
        
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            DataTable dt = bllp.GetProductById(id);
            if (id == null || id==0)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return View(response);
            }
            else
            {
                return View((from DataRow dr in dt.Rows
                             select new Product()
                             {
                                 id = Convert.ToInt32(dr["id"]),
                                 productname = dr["productname"].ToString(),
                                 serialnumber = Convert.ToInt32(dr["serialnumber"].ToString()),

                             }).SingleOrDefault());
              
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product collection)
        {
            try
            {
                // TODO: Add update logic here
              
                string productname=(collection.productname);
              int serialnumber=(collection.serialnumber);

                int update = bllp.UpdateProduct(id, productname, serialnumber);
                if (update>0)
                {
                    ViewBag.ItemMsg="Updated Successfully";
                   
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
  
        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            DataTable dt = bllp.GetProductById(id);
            if (id == null || id == 0)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return View(response);
            }
            else
            {
                return View((from DataRow dr in dt.Rows
                             select new Product()
                             {
                                 id = Convert.ToInt32(dr["id"]),
                                 productname = dr["productname"].ToString(),
                                 serialnumber = Convert.ToInt32(dr["serialnumber"].ToString()),

                             }).SingleOrDefault());
             
            }

        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                // TODO: Add delete logic here
                int delete =bllp.DeleteProduct(id);
                if (delete>0)
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

    
        public ActionResult Search(string productname)
        {
            DataTable dt = bllp.SearchProduct(productname);
            List<Product> Li = new List<Product>();
          
                if (dt.Rows.Count > 0)
                {
                    Li = (from DataRow dr in dt.Rows
                          select new Product()
                          {
                              id = Convert.ToInt32(dr["id"]),
                              productname = dr["productname"].ToString(),
                              serialnumber = Convert.ToInt32(dr["serialnumber"].ToString()),
                          }).ToList();
                }
            

            return View(Li);
        }
    }
}
