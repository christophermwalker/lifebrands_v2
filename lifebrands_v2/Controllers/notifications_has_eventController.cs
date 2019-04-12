
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
    public class notifications_has_event : Controller
    {
        // GET: notifications_has_event
        public ActionResult notifications_has_events()
        {

            return View();
        }



        public JsonResult Getnotifications_has_event(string sidx, string sort, int page, int rows)
        {
            DatabaseContext db = new DatabaseContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var notifications_has_eventList = db.notifications_has_event.Select(
                       t => new
                       {
                           t.notifications_idNotifications,
                           t.event_idEvent,
                  
                       }
                       );

            int totalRecords = notifications_has_eventList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                notifications_has_eventList = notifications_has_eventList.OrderByDescending(t => t.notifications_idNotifications);
                notifications_has_eventList = notifications_has_eventList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                notifications_has_eventList = notifications_has_eventList.OrderBy(t => t.notifications_idNotifications);
                notifications_has_eventList = notifications_has_eventList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = notifications_has_eventList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create(notifications_has_event Model)
        {
            DatabaseContext db = new DatabaseContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.notifications_idNotifications = new Random().Next(1, 1000);
                    db.notifications_has_event.Add(Model);
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
        public string Edit(notifications_has_event Model)
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
            notifications_has_event notifications_has_events = db.notifications_has_event.Find(int.Parse(Id));
            db.notifications_has_event.Remove(notifications_has_events);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}