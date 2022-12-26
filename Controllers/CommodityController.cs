using LeanProd.Data;
using LeanProd.Interfaces;
using LeanProd.Models;
using LeanProd.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_2.Controllers
{
    public class CommodityController : Controller
    {

        private readonly ICommodityService _сommodityService;


        ApplicationDbContext _db;

        //public CommodityController(ApplicationDbContext context)
        //{
        //    _db = context;
        //}

        public CommodityController(ICommodityService commodityService, ApplicationDbContext context)
        {
            _сommodityService = commodityService;
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
           var list =  _сommodityService.GetCommodities(_db);
            return View(list);
        }
    }

}
