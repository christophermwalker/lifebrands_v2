
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
    public class aspnetuserlogins : Controller
    {
        // GET: aspnetuserlogins
        public ActionResult aspnetuserlogins()
        {

            return View();
        }



        public JsonResult Getaspnetuserlogins(string sidx, string sort, int page, int rows)
        {
            DatabaseContext db = new DatabaseContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var aspnetuserloginsList = db.aspnetuserlogins.Select(
                       t => new
                       {
                           t.LoginProvider,
                           t.ProviderKey,
                           t.UserId,
                       }
                       );

            int totalRecords = aspnetuserloginsList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                aspnetuserloginsList = aspnetuserloginsList.OrderByDescending(t => t.LoginProvider);
                aspnetuserloginsList = aspnetuserloginsList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                aspnetuserloginsList = aspnetuserloginsList.OrderBy(t => t.LoginProvider);
                aspnetuserloginsList = aspnetuserloginsList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = aspnetuserloginsList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create(aspnetuserlogins Model)
        {
            DatabaseContext db = new DatabaseContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.LoginProvider = new Random().Next(1, 1000);
                    db.aspnetuserlogins.Add(Model);
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
        public string Edit(aspnetuserlogins Model)
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
            aspnetuserlogins LoginProvider = db.aspnetuserlogins.Find(int.Parse(Id));
            db.aspnetuserlogins.Remove(LoginProvider);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}