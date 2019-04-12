
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
    public class vendor_has_eventController : Controller
    {
        // GET: vendor_has_event
        public ActionResult vendor_has_event()
        {

            return View();
        }



        public JsonResult Getvendor_has_event(string sidx, string sort, int page, int rows)
        {
            DatabaseContext db = new DatabaseContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var vendor_has_eventList = db.vendor_has_event.Select(
                       t => new
                       {
                           t.vendor_idVendor,
                           t.event_idEvent,                  
                       }
                       );

            int totalRecords = vendor_has_eventList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                vendor_has_eventList = vendor_has_eventList.OrderByDescending(t => t.vendor_idVendor);
                vendor_has_eventList = vendor_has_eventList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                vendor_has_eventList = vendor_has_eventList.OrderBy(t => t.vendor_idVendor);
                vendor_has_eventList = vendor_has_eventList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = vendor_has_eventList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create(vendor_has_event Model)
        {
            DatabaseContext db = new DatabaseContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.vendor_idVendor = new Random().Next(1, 1000);
                    db.vendor_has_event.Add(Model);
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
        public string Edit(vendor_has_event Model)
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
            vendor_has_event vendor_has_events = db.vendor_has_event.Find(int.Parse(Id));
            db.vendor_has_event.Remove(vendor_has_events);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}