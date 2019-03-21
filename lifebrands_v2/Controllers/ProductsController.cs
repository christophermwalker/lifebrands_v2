using IdentityMySQLDemo.Models;
using lifebrands_v2.Entities;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lifebrands_v2.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Products() => View();
      
        public JsonResult GetProducts(string sidx, string sort, int page, int rows)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var ProductList = db.products.Select(
                       t => new ProductsMaster
                       {
                           idProduct = t.ToString(),
                           name = t.ToString(),
                           cost = t.ToString(),
                           wholesale_cost = t.ToString(),
                           retail_price = t.ToString()
                       }
                       ); 

            int totalRecords = ProductList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                ProductList = ProductList.OrderByDescending(t => t.name);
                ProductList = ProductList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                ProductList = ProductList.OrderBy(t => t.name);
                ProductList = ProductList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = ProductList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}