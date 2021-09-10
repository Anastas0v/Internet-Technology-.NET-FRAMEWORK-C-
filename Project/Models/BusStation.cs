using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class BusStation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name ="Starting City")]
        public string SCity { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Starting Country")]
        public string SCountry { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Ending City")]
        public string ECity { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Ending Country")]
        public string ECountry { get; set; }
        [Required]
        [RegularExpression(@"Bus")]
        public string Type { get; set; }
        [Required]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$", ErrorMessage = "Invalid Date Format. DD/MM/YYYY")]
        public string Date { get; set; }
        [Required]
        [RegularExpression(@"^(2[0-3]|[01]?[0-9]):([0-5]?[0-9])$", ErrorMessage = "Invalid Time Format. HH:MM IN 24Format")]
        public string Departure { get; set; }
        [Required]
        [RegularExpression(@"^(2[0-3]|[01]?[0-9]):([0-5]?[0-9])$", ErrorMessage = "Invalid Time Format. HH:MM IN 24Format")]
        public string Arrival { get; set; }
        [Required]
        [Range(1, 45, ErrorMessage = "Seats Are From 1 - 45")]
        public int Seat { get; set; }
        [Required]
        [Range(typeof(double), "1.50", "500.00", ErrorMessage = "Prices Are From 1.5 - 500.00")]
        public double Price { get; set; }
    }
}