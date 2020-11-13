using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeData.Models
{
    public class Steps
    {
        public int StepId { get; }
        public int RecipeId { get; }

        public int StepNumber { get; }
        
        public string StepDescription { get; }

        public Steps(int stepId, int recipeId, int stepNumber,  string stepDescription)
        {
            StepId = stepId;
            RecipeId = recipeId;
            StepNumber = stepNumber;
            StepDescription = stepDescription;
        }
    }
}
