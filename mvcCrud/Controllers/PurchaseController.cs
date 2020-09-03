using BLL;
using mvcCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcCrud.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        bllproduct bllp = new bllproduct();
        public ActionResult Index()
        {
            //DataTable dt=bll.GetPurchase
            //List<Purchase> li =new List<Purchase>();
            return View();
        }
    }
}