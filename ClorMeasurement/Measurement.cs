using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClorMeasurement
{
    public class Measurement
    {
        private string stationName;
        private DateTime date;
        private double[] conditions = new double[3];
        private string[] strCondtions = { "Temperature", "Pressure", "Humidity" };
        public enum MeasurementConditions { Temperature = 0, Pressure = 1, Humidity = 2 };
        public static int NoOfMeasurements = 0;

        public Measurement(string name = "No name!")
        {
            stationName = name;
            date = DateTime.Now;
            for (int i = 0; i < 3; i++)
            {
                conditions[i] = 0;
            }
            Interlocked.Increment(ref NoOfMeasurements);
        }

        public double this[int index]
        {
            get
            {
                return conditions[index];
            }

            set
            { 
                conditions[index] = value;
            }
        }

    public virtual void Print()
        {
            Console.WriteLine("Station name: {0}", stationName);
            Console.WriteLine("Date of Measurement: {0}", date);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0} : {1}", strCondtions[i], conditions[i]);
            }
        }
        ~Measurement()
        {
            Interlocked.Decrement(ref NoOfMeasurements);
        }

    }
}
