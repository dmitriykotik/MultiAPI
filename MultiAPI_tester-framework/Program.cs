using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiAPI;

namespace MultiAPI_Tester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($@"getCurrentFolder: {Basic.getCurrentFolder()}
getPathAppData: {Basic.getPathAppData()}");
            
            Console.ReadLine();
        }
    }
}
