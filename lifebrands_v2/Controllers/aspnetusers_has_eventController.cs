
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
    public class aspnetusers_has_eventController : Controller
    {
        // GET: aspnetusers_has_event
        public ActionResult aspnetusers_has_event()
        {

            return View();
        }



        public JsonResult Getaspnetusers_has_event(string sidx, string sort, int page, int rows)
        {
            DatabaseContext db = new DatabaseContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var aspnetusers_has_eventList = db.aspnetusers_has_event.Select(
                       t => new
                       {
                           t.aspnetusers_Id,
                           t.event_idEvent,

                       }
                       );

            int totalRecords = aspnetusers_has_eventList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                aspnetusers_has_eventList = aspnetusers_has_eventList.OrderByDescending(t => t.aspnetusers_Id);
                aspnetusers_has_eventList = aspnetusers_has_eventList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                aspnetusers_has_eventList = aspnetusers_has_eventList.OrderBy(t => t.aspnetusers_Id);
                aspnetusers_has_eventList = aspnetusers_has_eventList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = aspnetusers_has_eventList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create(aspnetusers_has_event Model)
        {
            DatabaseContext db = new DatabaseContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.aspnetusers_Id = new Random().Next(1, 1000);
                    db.aspnetusers_has_event.Add(Model);
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
        public string Edit(aspnetusers_has_event Model)
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
            aspnetusers_has_event aspnetuser_event = db.aspnetusers_has_event.Find(int.Parse(Id));
            db.aspnetusers_has_event.Remove(aspnetuser_event);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}