using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRepublic
{
    public interface IConsoleWrapper
    {
        void WriteLine(string value);
        void WriteLine();
        void Write(string value);
    }

    /// <summary>
    /// This class in used only to be able to write unit tests around areas where we want to use the Console object to 
    /// write to the screen.
    /// </summary>
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
