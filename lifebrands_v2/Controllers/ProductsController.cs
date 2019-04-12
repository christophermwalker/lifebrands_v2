
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
    public class ProductsController : Controller
    {

        // GET: Products
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

            var ProductList = db.products.Select(
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
                    Model.idProduct = Guid.NewGuid().ToString();
                    db.products.Add(Model);
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
            products product = db.products.Find(Id);
            db.products.Remove(product);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}