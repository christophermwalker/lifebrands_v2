
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
    public class aspnetuserrolesController : Controller
    {
        // GET: aspnetuserroles
        public ActionResult aspnetuserroles()
        {

            return View();
        }



        public JsonResult Getaspnetuserroles(string sidx, string sort, int page, int rows)
        {
            DatabaseContext db = new DatabaseContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var aspnetuserrolesList = db.aspnetuserroles.Select(
                       t => new
                       {
                           t.UserId,
                           t.RoleId,
                       }
                       );

            int totalRecords = aspnetuserrolesList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                aspnetuserrolesList = aspnetuserrolesList.OrderByDescending(t => t.UserId);
                aspnetuserrolesList = aspnetuserrolesList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                aspnetuserrolesList = aspnetuserrolesList.OrderBy(t => t.UserId);
                aspnetuserrolesList = aspnetuserrolesList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = aspnetuserrolesList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create(aspnetuserroles Model)
        {
            DatabaseContext db = new DatabaseContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.UserId = new Random().Next(1, 1000);
                    db.aspnetuserroles.Add(Model);
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
        public string Edit(aspnetuserroles Model)
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
            aspnetuserroles aspnetuserrole = db.aspnetuserroles.Find(int.Parse(Id));
            db.aspnetuserroles.Remove(aspnetuserrole);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}