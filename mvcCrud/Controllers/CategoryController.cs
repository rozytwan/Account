using BLLS;
using BLLS.Account;
using mvcCrud.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcCrud.Controllers
{
    public class CategoryController : Controller
    {
        bllcategory bllc = new bllcategory();
        DataContent db = new DataContent();
        // GET: Category
        public ActionResult Index(string sort, string q, int page = 1, int pageSize = 25)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sort) ? "category_name" : "";
            ViewBag.DateSortParm = sort == "Date" ? "date" : "Date";
            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 25;
            DataTable dt = bllc.GetCategory();
            List<Category> li = new List<Category>();
            li = (from DataRow dr in dt.Rows
                  select new Category()
                  {
                      category_id = Convert.ToInt32(dr["category_id"]),
                      category_name = dr["category_name"].ToString(),
                      category_type = (dr["category_type"].ToString()),
                      category_code = dr["category_code"].ToString()

                  }).ToList();
            return View(li.ToPagedList(page, pageSize));
        }
        public ActionResult Create()
        {
            return View();
        }
        string status;
        [HttpPost]
        public ActionResult Create(Category collection, string selectedname)
        {
            try
            {
                // TODO: Add insert logic here
                string category_name = ((collection.category_name));

                string category_type = selectedname;
                if (category_type == "Expenses")
                {
                    status = "Expenses";
                }
                else
                {
                    status = "Income";
                }
                string category_code = (collection.category_code);

                int insert = bllc.InsertCategory(category_name, category_type, category_code, status);

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
        public ActionResult Edit(int id)
        {
            DataTable dt = bllc.GetCategoryId(id);
            if (dt.Rows.Count > 0)
            {
                return View((from DataRow dr in dt.Rows
                             select new Category()
                             {
                                 category_id = Convert.ToInt32(dr["category_id"]),
                                 category_name = dr["category_name"].ToString(),
                                 category_type = (dr["category_type"].ToString()),
                                 category_code = dr["category_code"].ToString()

                             }).SingleOrDefault());
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, Category collection, string selectedname)
        {
            try
            {
                // TODO: Add update logic here
                string category_name = (collection.category_name);
                string category_type = selectedname;
                if (category_type == "Expenses")
                {
                    status = "Expenses";
                }
                else
                {
                    status = "Income";
                }
                string category_code = (collection.category_code);
                int update = bllc.UpdateCategoryId(id, category_name, category_type, category_code, status);
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
        public ActionResult DeleteModal()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            DataTable dt = bllc.GetCategoryId(id);
            if (dt.Rows.Count > 0)
            {
                return View((from DataRow dr in dt.Rows
                             select new Category()
                             {
                                 category_id = Convert.ToInt32(dr["category_id"]),
                                 category_name = dr["category_name"].ToString(),
                                 category_type = (dr["category_type"].ToString()),
                                 category_code = dr["category_code"].ToString()

                             }).SingleOrDefault());
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, Category collection)
        {
            try
            {
                // TODO: Add delete logic here
                int delete = bllc.DeleteCategory(id);
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
        [HttpPost]
        public ActionResult Search(string selectedname, string category_type)
        {
            List<Category> Li = new List<Category>();
            if (selectedname == "Category Type")
            {
                DataTable dt = bllc.SearchCategoryType(category_type);
                if (dt.Rows.Count > 0)
                {
                    Li = (from DataRow dr in dt.Rows
                          select new Category()
                          {
                              category_id = Convert.ToInt32(dr["category_id"]),
                              category_name = dr["category_name"].ToString(),
                              category_type = (dr["category_type"].ToString()),
                              category_code = dr["category_code"].ToString()
                          }).ToList();
                }
            }
            else if (selectedname == "Category Code")
            {
                DataTable dt = bllc.SearchCategoryCode((category_type));
                if (dt.Rows.Count > 0)
                {
                    Li = (from DataRow dr in dt.Rows
                          select new Category()
                          {
                              category_id = Convert.ToInt32(dr["category_id"]),
                              category_name = dr["category_name"].ToString(),
                              category_type = (dr["category_type"].ToString()),
                              category_code = dr["category_code"].ToString()
                          }).ToList();
                }

            }
            return View(Li);
        }

    }
}