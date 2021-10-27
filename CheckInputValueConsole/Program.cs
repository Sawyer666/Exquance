using System;
using GameApi.Exceptions;
using GameApi.ValueInputService;

namespace CheckInputValueConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var valueInputService = new ValueInputService();
            
            while (true)
            {
                Console.WriteLine("Press 'Exit' to close application...");
                Console.WriteLine("Start typing values...");

                var input = Console.ReadLine();

                try
                {
                    Console.WriteLine(valueInputService.Validate(Convert.ToInt32(input)));
                }
                catch (IncorrectValueException e)
                {
                    Console.WriteLine(e);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                }

                if (input == "Exit")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}