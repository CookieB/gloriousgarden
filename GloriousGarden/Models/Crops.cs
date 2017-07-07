using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloriousGarden.Models
{
    public enum rating
    {
        hopeless=1,
        poor=2,
        fair=3,
        good=4,
        fantastic=5
    }
    public class Crops
    {
        public int Id { get; set; }    
        [Required]
        [MaxLength(50, ErrorMessage = "Crop name can't be more than 50 characters")]
        [Display(Name = "Crop")]
        public string CropName { get; set; }
        [MaxLength(255, ErrorMessage = "Variety can't be more than 50 characters")]
        [Display(Name = "Variety")]
        public string Variety { get; set; }
        [Display(Name = "Date Sown")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime SownDate { get; set; }
        [Display(Name = "Date Planted")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? PlantedDate { get; set; }
        [Display(Name = "Date Germinated")]

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? GerminationDate {get; set;}

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        [Display(Name = "Date Harvested")]
        public DateTime? HarvestDate { get; set; }
        [ForeignKey("Location")]
        [Display(Name = "Location")]
        public int LocationIdRef { get; set; }
        [Display(Name = "Yield")]
        public rating yield { get; set; }
        [Display(Name = "Rating")]
        public rating satisfaction { get; set; }
        [MaxLength(255, ErrorMessage = "Notes can't be more than 255 characters")]
        public string notes { get; set; }
        public location Location { get; set; }
    }
}