using lifebrands_v2.Entities;
using lifebrands_v2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lifebrands_v2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /*
       public ActionResult Products()
       {

           return View();
       }
      
       public JsonResult GetProducts(string sidx, string sort, int page, int rows)
       {
           DatabaseContext db = new DatabaseContext();
           sort = (sort == null) ? "" : sort;
           int pageIndex = Convert.ToInt32(page) - 1;
           int pageSize = rows;

           var ProductList = db.Products.Select(
                      t => new
                      {
                          t.idProduct,
                          t.name,
                          t.cost,
                          t.wholesale_cost,
                          t.retail_price,
                      }
                      );

           int totalRecords = ProductList.Count();
           var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
           if (sort.ToUpper() == "DESC")
           {
               ProductList = ProductList.OrderByDescending(t => t.name);
               ProductList = ProductList.Skip(pageIndex * pageSize).Take(pageSize);
           }
           else
           {
               ProductList = ProductList.OrderBy(t => t.name);
               ProductList = ProductList.Skip(pageIndex * pageSize).Take(pageSize);
           }
           var jsonData = new
           {
               total = totalPages,
               page,
               records = totalRecords,
               rows = ProductList
           };
           return Json(jsonData, JsonRequestBehavior.AllowGet);
       }
       [HttpPost]
       public string Create(products Model)
       {
           DatabaseContext db = new DatabaseContext();
           string msg;
           try
           {
               if (ModelState.IsValid)
               {
                   Model.idProduct = new Random().Next(1, 1000);
                   db.Products.Add(Model);
                   db.SaveChanges();
                   msg = "Saved Successfully";
               }
               else
               {
                   msg = "Validation data not successfully";
               }
           }
           catch (Exception ex)
           {
               msg = "Error occured:" + ex.Message;
           }
           return msg;
       }
       public string Edit(products Model)
       {
           DatabaseContext db = new DatabaseContext();
           string msg;
           try
           {
               if (ModelState.IsValid)
               {
                   db.Entry(Model).State = EntityState.Modified;
                   db.SaveChanges();
                   msg = "Saved Successfully";
               }
               else
               {
                   msg = "Validation data not successfully";
               }
           }
           catch (Exception ex)
           {
               msg = "Error occured:" + ex.Message;
           }
           return msg;
       }
       public string Delete(string Id)
       {
           DatabaseContext db = new DatabaseContext();
           products product = db.Products.Find(int.Parse(Id));
           db.Products.Remove(product);
           db.SaveChanges();
           return "Deleted successfully";
       }*/
    }
}