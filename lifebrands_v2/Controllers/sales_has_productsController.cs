
using lifebrands_v2.Entities;
using lifebrands_v2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lifebrands_v2.Controllers
{
    public class sales_has_sales_has_productsController : Controller
    {
        // GET: sales_has_products
        public ActionResult sales_has_products()
        {

            return View();
        }



        public JsonResult Getsales_has_products(string sidx, string sort, int page, int rows)
        {
            DatabaseContext db = new DatabaseContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var sales_has_productsList = db.sales_has_products.Select(
                       t => new
                       {
                           t.sales_idSale,
                           t.products_idProduct,                      
                       }
                       );

            int totalRecords = sales_has_productsList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                sales_has_productsList = sales_has_productsList.OrderByDescending(t => t.sales_idSale);
                sales_has_productsList = sales_has_productsList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                sales_has_productsList = sales_has_productsList.OrderBy(t => t.sales_idSale);
                sales_has_productsList = sales_has_productsList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = sales_has_productsList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create(sales_has_products Model)
        {
            DatabaseContext db = new DatabaseContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.sales_idSale = new Random().Next(1, 1000);
                    db.sales_has_products.Add(Model);
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
        public string Edit(sales_has_products Model)
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
            sales_has_products sales_has_product = db.sales_has_products.Find(int.Parse(Id));
            db.sales_has_products.Remove(sales_has_product);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}