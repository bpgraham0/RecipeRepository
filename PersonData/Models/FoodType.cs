using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeData.Models
{
    public class FoodType
    {
        public int FoodTypeId { get; }
        public string Name { get; }

        public FoodType(int foodTypeId, string name)
        {
            FoodTypeId = foodTypeId;
            Name = name;
        }
    }
}
