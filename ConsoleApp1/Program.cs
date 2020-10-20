using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.ServiceReference1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceImgClient clien = new ServiceImgClient();
          string line =  clien.TakeLink("сено",1);
            
            Console.ReadLine();
            

        }
    }
}
