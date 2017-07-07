using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GloriousGarden.Models
{
    public class location
    {
        public location()
        {

        }
        [Key]
        public int LocationId { get; set; }
        [Required MaxLength(50, ErrorMessage = "Location name be more than 50 characters")]
        [Display(Name ="Location")]
        public string LocationName { get; set; }

    }
}