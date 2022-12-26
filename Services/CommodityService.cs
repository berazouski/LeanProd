using LeanProd.Data;
using LeanProd.Interfaces;
using LeanProd.Models;

namespace LeanProd.Services
{
    public class CommodityService: ICommodityService
    {
        public List<Commodity> GetCommodities(ApplicationDbContext dbContext)
        {
            return dbContext.Commodities.ToList();
        }

    }
}
