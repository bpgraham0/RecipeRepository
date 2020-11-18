using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeData.Models
{
    public class Recipe
    {
        public int RecipeId { get; }
        public int FoodTypeId { get; }
        public int CourseTypeId { get; }
        public string Name { get; }
        public string Description { get; }
        public double ServingSize { get; }
        public int PrepTime { get; }
        public int CookTime { get; }
        public DateTime CreatedOn { get; }
        public DateTime UpdatedOn { get; }

        public Recipe(int recipeId, int foodTypeId, int courseTypeId, string name, 
            string description, double servingSize, int prepTime, int cookTime, DateTime createdOn, DateTime updatedOn)
        {
            RecipeId = recipeId;
            FoodTypeId = foodTypeId;
            CourseTypeId = courseTypeId;
            Name = name;
            Description = description;
            ServingSize = servingSize;
            PrepTime = prepTime;
            CookTime = cookTime;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
        }
    }
}
