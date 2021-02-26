using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClorMeasurement
{
    public class AirPolutionMeasurement : Measurement
    {
        public double PM2_5 { get; set; } = 0;
        public double PM10 { get; set; } = 0;
        public AirPolutionMeasurement(string name = "No name!") : base(name)
        {

        }
        public override void Print()
        {
            base.Print();
        }
    }
}
