using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CookBookProject.Models
{
    public class LowCarbMeals
    {
        [Key]
        public int id { get; set; }
        public int recipeTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Rating { get; set; }

        [Display(Name = "Image")]
        public string ImgURL { get; set; }

        public RecipeType recipeType { get; set; }
    }
}