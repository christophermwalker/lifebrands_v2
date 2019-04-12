
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
    public class vendorController : Controller
    {
        // GET: vendor
        public ActionResult vendor()
        {

            return View();
        }



        public JsonResult Getvendor(string sidx, string sort, int page, int rows)
        {
            DatabaseContext db = new DatabaseContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var vendorList = db.vendor.Select(
                       t => new
                       {
                           t.idVendor,
                           t.name,
                           t.address,
                           t.city,
                           t.state,
                           t.zip,
                       }
                       );

            int totalRecords = vendorList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                vendorList = vendorList.OrderByDescending(t => t.idVendor);
                vendorList = vendorList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                vendorList = vendorList.OrderBy(t => t.idVendor);
                vendorList = vendorList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = vendorList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create(vendor Model)
        {
            DatabaseContext db = new DatabaseContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.idVendor = new Random().Next(1, 1000);
                    db.vendor.Add(Model);
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
        public string Edit(vendor Model)
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
            vendor vendors = db.vendor.Find(int.Parse(Id));
            db.vendor.Remove(vendors);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}