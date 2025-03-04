using OldPhonePad.DefaultConstant;
using OldPhonePad.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePad
{
    class Program
    {
        public static void Main()
        {
            GenerateTextHelper.Initialize();
            Console.WriteLine("Input : 8 88777444666*664# =>" + GenerateTextHelper.Generate("8 88777444666*664#"));
            
            while (true)
            {
                Console.WriteLine(CommonConstant.INPUT_REQUEST_MESSAGE);
                string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput))
                {
                    string message = CommonConstant.OUTPUT_MESSAGE_FORMAT;
                    Console.WriteLine(string.Format(message, userInput, GenerateTextHelper.Generate(userInput)));
                }
            }
        }

    }
}