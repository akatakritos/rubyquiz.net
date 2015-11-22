﻿using System;
using System.Collections.Generic;
using System.Linq;

using CommandLine;

using RubyQuiz.Core.Lcd;

namespace RubyQuiz.Runner
{
    public static class Program
    {
        static void Main(string[] args)
        {

            var options = new Options();
            if (!Parser.Default.ParseArguments(args, options, (verb, suboption) =>
            {
                if (options.LcdVerb != null)
                    PerformLcd(options.LcdVerb);
            }))
            {

                Environment.Exit(Parser.DefaultExitCodeFail);
            }

        }

        static void PerformLcd(LcdSubOptions options)
        {
            var writer = new DigitWriter(Console.Out, options.Size);
            writer.Write(options.Message);
        }

    }

}
