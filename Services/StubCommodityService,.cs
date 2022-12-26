using LeanProd.Data;
using LeanProd.Interfaces;
using LeanProd.Models;

namespace LeanProd.Services
{
    public class StubCommodityService:  ICommodityService
    {
        
        public List<Commodity> GetCommodities(ApplicationDbContext dbContext)
        {
            return new List<Commodity>();
        }
    }
}
