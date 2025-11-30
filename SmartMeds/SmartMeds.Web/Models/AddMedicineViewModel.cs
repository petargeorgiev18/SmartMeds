using System;
using System.ComponentModel.DataAnnotations;

namespace SmartMeds.Web.Models
{
    public class AddMedicineViewModel
    {
        [Required]
        [Display(Name = "External Medicine ID")]
        public string ExternalMedicineId { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}