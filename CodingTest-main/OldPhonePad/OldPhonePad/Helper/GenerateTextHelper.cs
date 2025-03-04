using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePad.Helper
{
    public class GenerateTextHelper
    {
        private static Dictionary<char, string> KeyMap { get; set; }

        public static void Initialize()
        {
            KeyMap = InitializeKeyMap();
        }
        public static string Generate(string text)
        {
            return OldPhonePad(text);
        }


        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input) || input[^1] != '#')
                return "";

            input = input.TrimEnd('#');

            StringBuilder output = new StringBuilder();
            StringBuilder currentSequence = new StringBuilder();
            char lastKey = '\0';

            foreach (char c in input)
            {
                if (c == '*' && currentSequence.Length > 0)
                {
                    currentSequence.Length--;
                    continue;
                }

                if (c == ' ')
                {
                    if (currentSequence.Length > 0)
                    {
                        output.Append(ProcessKeySequence(currentSequence.ToString(), KeyMap));
                        currentSequence.Clear();
                    }
                    continue;
                }

                if (char.IsDigit(c))
                {
                    if (c != lastKey && currentSequence.Length > 0)
                    {
                        output.Append(ProcessKeySequence(currentSequence.ToString(), KeyMap));
                        currentSequence.Clear();
                    }

                    currentSequence.Append(c);
                    lastKey = c;
                }
            }

            if (currentSequence.Length > 0)
            {
                output.Append(ProcessKeySequence(currentSequence.ToString(), KeyMap));
            }

            return output.ToString();
        }

        private static char ProcessKeySequence(string sequence, Dictionary<char, string> keyMap)
        {
            char key = sequence[0];
            if (!keyMap.ContainsKey(key) || keyMap[key] == "")
                return '?';

            int index = (sequence.Length - 1) % keyMap[key].Length;
            return keyMap[key][index];
        }


        private static Dictionary<char, string> InitializeKeyMap()
        {
            return new Dictionary<char, string>
        {
            { '0', " " },
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" }
        };
        }
    }
}
