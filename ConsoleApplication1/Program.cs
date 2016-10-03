﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.TestEvents;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //cmd ln 
            // can set in iDE. Prj.Properties.CmdLnParams
            Console.WriteLine("{0} {1}", args[0], args[1]);
            Utils.WriteDetailLine(args.Length.ToString());

            new Delegates();

            Collections.Dict.Test();

            Linq.Test();

            IO.Test();

            new Dir();

            new MyEnum();

            new String();

            Loop.Test();

            //            DB.Test();

            Conditional.Test();

            Method.Test();

            Interface.Test();

            ExtensionMenthods.Test();

            DependencyInjection.Test();

            Collections.HashSetTst.Test();

            Collections.List.Test();

            Array.Test();

            Struct.Test();

            Event.Test();

            DateTimeTimeSpan.Test();

            Generics.Test();

            lang.Test();

            StringBuilderTst.Test();

            Numbers.Test();

            TupleTst.Test();

            Operators.Test();

            TimerTst.Test();

            GCTst.Test();

            TraceDebug.Test();

            Console.ReadKey();
        }
    }
}
