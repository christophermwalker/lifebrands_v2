
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
    public class aspnetuserclaimsController : Controller
    {
        // GET: aspnetuserclaims
        public ActionResult aspnetuserclaims()
        {

            return View();
        }



        public JsonResult Getaspnetuserclaims(string sidx, string sort, int page, int rows)
        {
            DatabaseContext db = new DatabaseContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var aspnetuserclaimsList = db.aspnetuserclaims.Select(
                       t => new
                       {
                           t.Id,
                           t.UserID,
                           t.ClaimType,
                           t.ClaimValue,
                       }
                       );

            int totalRecords = aspnetuserclaimsList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                aspnetuserclaimsList = aspnetuserclaimsList.OrderByDescending(t => t.Id);
                aspnetuserclaimsList = aspnetuserclaimsList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                aspnetuserclaimsList = aspnetuserclaimsList.OrderBy(t => t.Id);
                aspnetuserclaimsList = aspnetuserclaimsList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = aspnetuserclaimsList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create(aspnetuserclaims Model)
        {
            DatabaseContext db = new DatabaseContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.Id = new Random().Next(1, 1000);
                    db.aspnetuserclaims.Add(Model);
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
        public string Edit(aspnetuserclaims Model)
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
            aspnetuserclaims aspuserclaim = db.aspnetuserclaims.Find(int.Parse(Id));
            db.aspnetuserclaims.Remove(Id);
            db.SaveChanges();
            return "Deleted successfully";
        }
    }

}