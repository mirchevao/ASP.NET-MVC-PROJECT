using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CookBookProject.Models;

namespace CookBookProject.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            Recipes = new List<Recipe>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
     
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}