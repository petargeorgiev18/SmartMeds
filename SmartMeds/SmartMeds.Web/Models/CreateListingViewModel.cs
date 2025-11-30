using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartMeds.Web.Models
{
    public class CreateListingViewModel
    {
        [Required]
        [Display(Name = "Medicine")]
        public long MedicineId { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive.")]
        public double Price { get; set; }
        public List<SelectListItem> MedicineOptions { get; set; } = new();
    }
}
