﻿using System.Runtime.Serialization;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());
            string text = string.Empty;
            Stack<string> states = new Stack<string>();
            for (int i = 0; i < operations; i++)
            {
                string[] inputCommands = Console.ReadLine().Split();
                if (inputCommands[0] == "1")
                {
                    states.Push(text);
                    text += inputCommands[1];
                }
                else if (inputCommands[0] == "2")
                {
                    states.Push(text);
                    int count = int.Parse(inputCommands[1]);
                    text = text.Substring(0, text.Length - count);
                }
                else if (inputCommands[0] == "3")
                {
                    int index = int.Parse(inputCommands[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (inputCommands[0] == "4")
                {
                    text = states.Pop();
                }
            }
        }
    }
}