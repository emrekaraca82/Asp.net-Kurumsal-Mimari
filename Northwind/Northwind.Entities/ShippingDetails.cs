using System.ComponentModel.DataAnnotations;

namespace Northwind.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage ="İsim Zorunlu")]
        public string Name { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Adress1 { get; set; }
        [MaxLength(50)]
        public string Adress2 { get; set; }
        [MaxLength(50)]
        public string Adress3 { get; set; }
        [Required]
        public string Ctiy { get; set; }
        public string Country { get; set; }
        public bool IsGift { get; set; }
    }
}