using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQarrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Task [0] ******");

            int Min = 0;
            int Max = 99;
            int[] arrRand = new int[10];

            Random randNum = new Random();
            for (int i = 0; i < arrRand.Length; i++)
            {
                arrRand[i] = randNum.Next(Min, Max);
            }
            Console.WriteLine("Array 1d of random numbers:");

            for (int i = 0; i < arrRand.Length; i++)
            {
                Console.Write(arrRand[i] + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Number of element in arr 1d");
            int countAll = (from x in arrRand select x).Count();
            Console.WriteLine(countAll);
            Console.WriteLine("");

            Console.WriteLine("Number of even element in arr 1d");
            int countEven = (from x in arrRand where x % 2 == 0 select x).Count();
            Console.WriteLine(countEven);
            Console.WriteLine("");

            Console.WriteLine("Number of odd element in arr 1d");
            int countOdd = (from x in arrRand where x % 2 == 1 select x).Count();
            Console.WriteLine(countOdd);
            Console.WriteLine("");

            int rows = 10;
            int columns = 5;
            int[,] arrRand2d = new int[rows,columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    arrRand2d[i, j] = randNum.Next(Min, Max);
                }
            }
            Console.WriteLine("Array 2d of random numbers:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(arrRand2d[i, j] + "\t");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");

            Console.WriteLine("****** Task [1] ******");

            School mySchool = new School();

            var studentenVonWarschauUndSeattle = (from student in mySchool.students  where student.City == "Warsaw" || student.City == "Seattle" select student);

            Console.WriteLine("Studenten im Warschau und Seattle:");

            foreach (var student in studentenVonWarschauUndSeattle)
            {
                System.Console.WriteLine("{0} {1} {2} ", student.First, student.Last, student.City );
            }
            Console.WriteLine("");

            int wieVieleStudenten = (from student in studentenVonWarschauUndSeattle select student).Count();
            Console.WriteLine("Es gibt : " + wieVieleStudenten + " Studenten im Warschau und Seattle");
            Console.WriteLine("");

            Console.WriteLine("****** Task [2] ******");

            studentenVonWarschauUndSeattle = from student in mySchool.students where student.City == "Warsaw" || student.City == "Seattle" orderby student.Last ascending select student;
            Console.WriteLine("Studenten im Warschau und Seattle sortieret nach ihrem Nachnamen:");
            foreach (var student in studentenVonWarschauUndSeattle)
            {
                System.Console.WriteLine("{0} {1} {2} ", student.First, student.Last, student.City);
            }
            Console.WriteLine("");

            Console.WriteLine("****** Task [3] ******");

            var studentsAccoridngToTheirCities = from student in mySchool.students group student by student.City;
            foreach (var studentGroup in studentsAccoridngToTheirCities)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup) {
                    Console.WriteLine("{0} {1}", student.First, student.Last); }

                Console.WriteLine("");

            }
            Console.WriteLine("");

            Console.WriteLine("****** Task [4] ******");

            IEnumerable<string> query = (from student in mySchool.students where student.City == "Warsaw" select student.Last).Concat(from teacher in mySchool.teachers where teacher.City == "Warsaw" select teacher.Last);
            foreach (var member in query)
            {
                Console.WriteLine("{0} ", member);
            }
            Console.WriteLine("");

            Console.WriteLine("****** Task [5] ******");
            var query2 = (from student in mySchool.students where student.City == "Warsaw" select new { First = student.First, Last = student.Last }).Concat((from teacher in mySchool.teachers where teacher.City == "Warsaw" select new { First = teacher.First, Last = teacher.Last }));
            foreach (var member in query2)
            {
                Console.WriteLine("{0} ", member);
            }
            Console.WriteLine("");
            Console.WriteLine("****** Task [6] ******");


            Console.WriteLine("");

            Console.ReadKey();


        }
    }
}
