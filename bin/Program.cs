using System;
using System.Linq;
using System.Collections.Generic;

namespace MyAppCshrp
{
    class MainClass
    {
        private static void print(IEnumerable<int> result, String query)
        {
            Console.WriteLine("[QUERY] {0}", query);
            foreach (int i in result)
                Console.WriteLine("[OUTPUT] {0}", i);
        }
        private static void greaterThan(List<int> list)
        {
            var result = (from x in list where x > 1 select x);
            print(result, "SELECT * FROM list WHERE x > 1;");
        }
        private static void lessThan(List<int> list)
        {
            var result = (from x in list where x < 2 select x);
            print(result, "SELECT * FROM list WHERE x < 2;");
        }
        private static void equals(List<int> list)
        {
            var result = (from x in list where x == 1 select x);
            print(result, "SELECT * FROM list WHERE x = 1;");
        }
        public static void Main(string[] args)
        {
            List<int> list = new List<int>() { 0, 1, 2 };
            Console.WriteLine("[INPUT] {0}", String.Join(", ", list.ToArray()));
            greaterThan(list);
            lessThan(list);
            equals(list);
        }
    }
}
