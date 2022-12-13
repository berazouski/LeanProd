using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeanProd.Models
{
    
    public class Commodity 
    {
        [NotMapped]
        public List<Commodity> Commodities { get; }
       
        public int Id { get; set; }
       
        [Required]
        public string Name { get; set; }
       
        public string Description { get; set; }


        public string EAN13 { get; set; }

        
       
    }


}
