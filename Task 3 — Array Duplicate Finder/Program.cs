// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

namespace Duplicate
{
    class program
    {
        public static void Main(string[] args)
        {
            int[] num = { 4, 2, 7, 2, 9, 4, 4, 1, 7 };
            Console.WriteLine("Original array: " + string.Join(", ", num));

            Console.WriteLine("\n----Manual Method Output-----\n");
            manualoutput(num);

            Console.WriteLine();

            Console.WriteLine("\n----Linq Method Output-----\n");
            linqoutput(num);
        }
        public static void manualoutput(int[] n)
        {
            int[] temp = new int[n.Length];
            for(int i = 0; i < n.Length; i++)
            {
                int count = 0;
                for(int j = 0; j < n.Length; j++)
                {
                    if(n[i] == n[j])
                    {
                        count++;
                    }
                }
                if(count > 1 && !temp.Contains(n[i]) || count==1)
                {
                    temp[i] = n[i];
                    Console.WriteLine(n[i]);
                }
            }


        }
        public static void linqoutput(int[] n)
        {
            var uniqueValues = n.Distinct();
            Console.WriteLine("Unique (Distinct): " + string.Join(", ", uniqueValues));
            var duplicates = n.GroupBy(x => x)
                              .Where(g => g.Count() > 1 )
                              .Select(g=>$"\n {g.Key} -> appears {g.Count()} times ");
            Console.WriteLine("\nDuplicate counts: " + string.Join(" ", duplicates));

        }
    }
}