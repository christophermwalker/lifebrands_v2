
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
    public class promo_has_eventController : Controller
    {
        // GET: promo_has_event
        public ActionResult promo_has_event()
        {

            return View();
        }



        public JsonResult Getpromo_has_event(string sidx, string sort, int page, int rows)
        {
            DatabaseContext db = new DatabaseContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var promo_has_eventList = db.promo_has_event.Select(
                       t => new
                       {
                           t.promo_idPromo,
                           t.event_idEvent,
                     
                       }
                       );

            int totalRecords = promo_has_eventList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                promo_has_eventList = promo_has_eventList.OrderByDescending(t => t.promo_idPromo);
                promo_has_eventList = promo_has_eventList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                promo_has_eventList = promo_has_eventList.OrderBy(t => t.promo_idPromo);
                promo_has_eventList = promo_has_eventList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = promo_has_eventList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create(promo_has_event Model)
        {
            DatabaseContext db = new DatabaseContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.promo_idPromo = new Random().Next(1, 1000);
                    db.promo_has_event.Add(Model);
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
        public string Edit(promo_has_event Model)
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
            promo_has_event promo_has_events = db.promo_has_event.Find(int.Parse(Id));
            db.promo_has_event.Remove(promo_has_events);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}