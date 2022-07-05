/* Любовь Соколова*/ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReflesDataTime
{
    class Program
    {
        /// <summary>
        /// 1. С помощью рефлексии выведите все свойства структуры DateTime.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var date = new DateTime();
            Type type = date.GetType();
            Console.WriteLine("Свойство структуры DataTime:");
            foreach (var t in type.GetProperties())
                Console.WriteLine(t.Name);
            Console.ReadKey();
        }
    }
}
