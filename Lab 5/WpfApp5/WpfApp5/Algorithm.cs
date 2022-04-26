using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp5
{
    public class Algorithm
    {
        public int Length { get; }

        public static List<string> Patterns_create(string Text)
        {
            List<string> Patterns = new List<string>();
            for (int i = 0; i < Text.Length - 4; i++)
            {
                if (Patterns.Contains(Text.Substring(i, 4)) == false)
                {
                    Patterns.Add(Text.Substring(i, 4));
                }
            }
            return Patterns;
        }


        public int PatternCount(string Text, string Pattern) // szukane wzorce mają mieć długość 4
        {
            int count = 0;
            for (int i = 0; i < Text.Length - 4; i++)
            {
                if (Text.Substring(i, 4) == Pattern)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
