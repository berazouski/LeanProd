using LeanProd.Data;
using LeanProd.Models;

namespace LeanProd.Interfaces
{
    public interface ICommodityService
    {
        public List<Commodity> GetCommodities(ApplicationDbContext dbContext) {
        
            return new List<Commodity>();
        }
        
    }
}
