﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    /*
        Arrays are fixed size, which means you can't add more elements than the 
        number allocated at creation time, if you need a auto sizing collection you 
        could use List<T> or an ArrayList

        int[] n   can assign another int[] to, regardless of size

        it is ref type (so can modify orig in a called method)
    */
    static class Array
    {
        static int[] ary = { 1, 2, 3, 4, 5 };

        public static void Test()
        {
            Console.WriteLine("Array ****");
            Contains();
            ModifyInMethod();
        }

        private static void ModifyInMethod()
        {
            Console.WriteLine("Modify in Method **");
            int[] n = { 7, 8, 9 };
            method1(n);
            Console.WriteLine(string.Join(" ", n));

            int[] m = { 1, 2, 3, 4, 5, 6, 7 };
            method1(m);
        }

        static void method1(int[] m)
        {
            m[0] = 2;
            // m[99] = 4; IndexOutOfRangeException
        }

        private static void Contains()
        {
            Console.WriteLine("Contains **");
            bool b = ary.Contains(3);
            Console.WriteLine(b);


            b = ary.Contains(99);
            Console.WriteLine(b);
        }
    }
}
