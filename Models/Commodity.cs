using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeanProd.Models
{
    
    public class Commodity 
    {
        [NotMapped]
        public List<Commodity> Commodities { get; }
       
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(150, MinimumLength = 3)]
        public string Name { get; set; }
       
        [StringLength(500, MinimumLength = 0)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не указан товарный код")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Код должен содержать только цифры")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Длина кода должна составлять 13 символов")]
        public string EAN13 { get; set; }

        
       
    }


}
