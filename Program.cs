using System;
using System.Collections.Generic;
using System.IO;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new List<string>();
            ////test 2
            //a.Add("1");
            //a.Add("abbcaccbb");

            //test3
            a.Add("20");
            a.Add("aaabbbccbaaaacbbabbb");
            a.Add("caaabaaaaaabbbbaaaaa");
            a.Add("aaaaaabbbaacabaaaaab");
            a.Add("caaaabaaaabbaabbaaab");
            a.Add("ababbaaaaaabbbababba");
            a.Add("aaaacbbabacbcaaaacac");
            a.Add("abacbcbcabbbacaaabaa");
            a.Add("bbbcabbbbacacabbbaba");
            a.Add("babbabbaababcacccbbb");
            a.Add("abbbaabcbbabbaabaaaa");
            a.Add("babaacbbaabaabababab");
            a.Add("aaabbaabaacbbbbababb");
            a.Add("caabacabcbbcabacbaac");
            a.Add("bbcbcaabbcbaabbababb");
            a.Add("baabacaabbbaabbaabaa");
            a.Add("cabbbaabbabaabaaaacb");
            a.Add("aabbbcbabbbaaaaabbab");
            a.Add("bbaaabacbbbabbabacac");
            a.Add("baaacbaacbabcbbbabab");
            a.Add("acabbbcabcbcabaacabc");

            Console.WriteLine(strokesRequired(a));
            Console.ReadKey();
        }


        public static int strokesRequired(List<string> picture)
        {
            var chars = new char[picture.Count - 1][]; //creating an array of char[][] to keep chars

            var index = 0;
            for (int i = 1; i < picture.Count; i++)
            {
                chars[index++] = picture[i].ToCharArray(); //every item in the list goes to a row in array
            }

            int count = 0; //keeps record of unique visited cells

            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < chars[i].Length; j++)
                {
                    if (chars[i][j] != '-')
                    {
                        Add(chars, chars[i][j], i, j);
                        count++;
                    }
                }
            }

            return count;
        }

        public static void Add(char[][] chars, char c, int i, int j)
        {
            if (chars[i][j] != c)
                return;

            chars[i][j] = '-';// we mark this cell as visited
            if (i - 1 >= 0)
            {
                Add(chars, c, i - 1, j); //to check same cell at prevous row
            }

            if (j - 1 >= 0)
            {
                Add(chars, c, i, j - 1); //to check previous cell at same row
            }

            if (i + 1 < chars.Length)
            {
                Add(chars, c, i + 1, j); //to chek same cell in next row
            }

            if (j + 1 < chars[i].Length)
            {
                Add(chars, c, i, j + 1); //to check next cell at same row
            }
        }

    }

}
