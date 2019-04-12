
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
    public class NotificationsController : Controller
    {
        // GET: Notifications
        public ActionResult Notifications()
        {

            return View();
        }



        public JsonResult GetNotifications(string sidx, string sort, int page, int rows)
        {
            DatabaseContext db = new DatabaseContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var NotificationsList = db.Notifications.Select(
                       t => new
                       {
                           t.idNotifications,
                           t.subject,
                           t.comments,
       
                       }
                       );

            int totalRecords = NotificationsList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                NotificationsList = NotificationsList.OrderByDescending(t => t.idNotifications);
                NotificationsList = NotificationsList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                NotificationsList = NotificationsList.OrderBy(t => t.idNotifications);
                NotificationsList = NotificationsList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = NotificationsList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create(Notifications Model)
        {
            DatabaseContext db = new DatabaseContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.idNotifications = new Random().Next(1, 1000);
                    db.Notifications.Add(Model);
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
        public string Edit(Notifications Model)
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
            Notifications idNotification = db.Notifications.Find(int.Parse(Id));
            db.Notifications.Remove(idNotification);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}