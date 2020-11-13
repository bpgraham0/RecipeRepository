using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeData.Models
{
    public class Measurement
    {
        public int MeasurementId { get; }
        public string Name { get; }

        public Measurement(int measurementId, string name)
        {
            MeasurementId = measurementId;
            Name = name;
        }
    }
}
