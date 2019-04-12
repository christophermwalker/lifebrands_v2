
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
    public class event_has_promoController : Controller
    {
        // GET: event_has_promo
        public ActionResult event_has_promo()
        {

            return View();
        }



        public JsonResult Getevent_has_promo(string sidx, string sort, int page, int rows)
        {
            DatabaseContext db = new DatabaseContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var Event_idEventList = db.event_has_promo.Select(
                       t => new
                       {
                           t.Event_idEvent,
                           t.Promo_idPromo,

                       }
                       );

            int totalRecords = Event_idEventList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                Event_idEventList = Event_idEventList.OrderByDescending(t => t.Event_idEvent);
                Event_idEventList = Event_idEventList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Event_idEventList = Event_idEventList.OrderBy(t => t.Event_idEvent);
                Event_idEventList = Event_idEventList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Event_idEventList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create(event_has_promo Model)
        {
            DatabaseContext db = new DatabaseContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.Event_idEvent = new Random().Next(1, 1000);
                    db.event_has_promo.Add(Model);
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
        public string Edit(event_has_promo Model)
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
            event_has_promo event_promo = db.event_has_promo.Find(int.Parse(Id));
            db.event_has_promo.Remove(event_promo);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}