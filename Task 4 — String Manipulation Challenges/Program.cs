// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string For Reverse :");
            string input = Console.ReadLine();
            Console.WriteLine("Enter A line To Count vowels :");
            string vowels = Console.ReadLine();
            Console.WriteLine("Enter two string to check they are Anagram or Not ");
            Console.WriteLine("Enter First string : ");
            string s1 = Console.ReadLine();
            Console.WriteLine("Enter Second string : ");
            string s2 = Console.ReadLine();
            Console.WriteLine("Enter a string to count word frequency : ");
            string vl=Console.ReadLine();

            Reversestring(input);
            Countvowels(vowels);
            isangram(s1, s2);
            Wordfreq(vl);


        }

        public static void Reversestring(string str)
            
        {
            Console.WriteLine("\nYour Original String is : " + str);
            char[] Array= str.ToCharArray();
            int right = Array.Length-1;
            int left= 0;
            while (left < right) {
                char t = Array[left];
                Array[left] = Array[right];
                Array[right] = t;

                left++;
                right--;

            }
            Console.WriteLine("Reverse String is : " + new string(Array));

        }
        static void Countvowels(string s)
        {
            Console.WriteLine("\nYour original String is :" + s);
            int Count = 0;
            string Vowels = "aeiouAEIOU";
            foreach (char c in s)
            {
                if (Vowels.Contains(c))
                {
                    Count++;
                }
                
            }
            Console.WriteLine("In you string No of Vowels is : "+Count);
        }
        static void isangram(string s1,string s2)
        {
            Console.WriteLine("\nYour first value is : "+s1+" , Your second value is : "+s2);
            string c1 = s1.Replace(" ", "").ToLower();
            string c2 = s2.Replace(" ", "").ToLower();

            if (c1.Length == c2.Length)
            {
                Console.WriteLine("Both Values are Anagram ");
            }
            else
            {
                Console.WriteLine("Both Values are not Anagram");
            }
        }
        public static void Wordfreq(string s)
        {
            Console.WriteLine("\nYour String is : " + s);
            Dictionary<string, int> word = new Dictionary<string, int>();
            foreach (string w in s.Split(' '))
            {
                if (word.ContainsKey(w))
                {
                    word[w] ++;
                }
                else
                {
                    word.Add(w, 1);
                }
            }

            Console.WriteLine("Word Frequency:");

            foreach (var item in word)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
    }
}