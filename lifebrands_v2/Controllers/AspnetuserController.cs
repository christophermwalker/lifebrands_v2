
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
    public class aspnetusersController : Controller
    {
        // GET: aspnetusers
        public ActionResult aspnetusers()
        {

            return View();
        }



        public JsonResult Getaspnetusers(string sidx, string sort, int page, int rows)
        {
            DatabaseContext db = new DatabaseContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var aspnetusersList = db.aspnetusers.Select(
                       t => new
                       {
                           t.Id,
                           t.Email,
                           t.PasswordHash,
                           t.SecurityStamp,
                           t.PhoneNumber,
                           t.UserName,
                       }
                       );

            int totalRecords = aspnetusersList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                aspnetusersList = aspnetusersList.OrderByDescending(t => t.Id);
                aspnetusersList = aspnetusersList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                aspnetusersList = aspnetusersList.OrderBy(t => t.Id);
                aspnetusersList = aspnetusersList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = aspnetusersList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create(aspnetusers Model)
        {
            DatabaseContext db = new DatabaseContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.Id = new Random().Next(1, 1000);
                    db.aspnetusers.Add(Model);
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
        public string Edit(aspnetusers Model)
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
            aspnetusers aspnetuser = db.aspnetusers.Find(int.Parse(Id));
            db.aspnetusers.Remove(Id);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}