using LogiсOfEuclideanAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCalculator = new NodCalculator();


            Show(testCalculator.GetNODbyEuclideanAlgorithm(15, -5));
            Show(testCalculator.GetNODbyEuclideanAlgorithm(60, 15, 45, 63));
            Show(testCalculator.GetNODbyEuclideanAlgorithm(39, 52, 65, 130, 52));
            Show(testCalculator.GetNODbyEuclideanAlgorithm(60, 15, 45, 63));

            
        }

        static void Show (TimeAndResult timeAndResult)
        {
            Console.WriteLine("NOD is {0}; time of execute is {1}", timeAndResult.Result, timeAndResult.ExecutionTimeTicks);
        }
    }
}
