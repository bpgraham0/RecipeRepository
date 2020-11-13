using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeData.Models
{
    public class CourseType
    {
        public int CourseTypeId { get; }
        public string Name { get; }

        public CourseType(int courseTypeId, string name)
        {
            CourseTypeId = courseTypeId;
            Name = name;
        }
    }
}
