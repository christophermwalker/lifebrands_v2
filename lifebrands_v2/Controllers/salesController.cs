
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
    public class salesController : Controller
    {
        // GET: sales
        public ActionResult sales()
        {

            return View();
        }



        public JsonResult Getsales(string sidx, string sort, int page, int rows)
        {
            DatabaseContext db = new DatabaseContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var salesList = db.sales.Select(
                       t => new
                       {
                           t.idSale,
                       }
                       );

            int totalRecords = salesList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                salesList = salesList.OrderByDescending(t => t.idSale);
                salesList = salesList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                salesList = salesList.OrderBy(t => t.idSale);
                salesList = salesList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = salesList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create(sales Model)
        {
            DatabaseContext db = new DatabaseContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.idSale = new Random().Next(1, 1000);
                    db.sales.Add(Model);
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
        public string Edit(sales Model)
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
            products sale = db.sales.Find(int.Parse(Id));
            db.sales.Remove(sale);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}