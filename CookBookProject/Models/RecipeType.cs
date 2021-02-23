using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CookBookProject.Models
{
    public class RecipeType
    {
        public int RecipeTypeId { get; set; }
        [Display(Name = "Type")]
        [Required]
        public string Name { get; set; }
    }
}