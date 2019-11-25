using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClorMeasurement
{
    public class GammaRadiationMeasurement : Measurement
    {
        public double radiationLevel { get; set; } = 0;
        public GammaRadiationMeasurement(string name = "No name!") : base(name)
        {

        }
        public override void Print()
        {
            base.Print();
        }
    }
}
