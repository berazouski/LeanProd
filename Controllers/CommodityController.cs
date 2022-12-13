using LeanProd.Data;
using LeanProd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_2.Controllers
{
    public class CommodityController : Controller
    {


        ApplicationDbContext _db;

        public CommodityController(ApplicationDbContext context)
        {
            _db = context;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Commodity commodity)
        {
            _db.Commodities.Add(commodity);
            _db.SaveChanges();
            return RedirectToAction("ListOfCommodity");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var commodity = _db.Commodities.Find(id);
            return View(commodity);
        }

        [HttpPost]
        public IActionResult Edit(Commodity commodity)
        {
            _db.Attach(commodity);
            _db.Entry(commodity).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("ListOfCommodity");
        }

        public IActionResult Details(Commodity commodity)
        {
            return View(commodity);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var actionName = ControllerContext.ActionDescriptor.ActionName;   

            var commodity = _db.Commodities.Find(id);
            return View(commodity);
        }

        [HttpPost]
        public IActionResult Delete(Commodity commodity)
        {
           /// var commodity = _db.Commodities.Find(commodity.id);
            _db.Commodities.Remove(commodity);
            _db.SaveChanges();
            return RedirectToAction("ListOfCommodity");
        }
        
        [HttpGet]
        public  IActionResult ListOfCommodity()
        {
            return View(_db.Commodities.ToList());
        }
    }

}
