using Microsoft.Extensions.DependencyInjection;
using SondaCappta.Models;
using SondaCappta.Services;
using System;
using System.Text.RegularExpressions;

namespace SondaCappta
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection();
            var field = new Field();
            var inlineInputFacade = new InlineInputFacade(field);

            serviceProvider.AddSingleton(field);
            serviceProvider.AddSingleton(inlineInputFacade);

            Console.WriteLine("> File or inline input?\n 1- File \n 2- Inline");
            var readType = Console.ReadLine();
            if (readType.Equals("1"))
            {

            }
            else if (readType.Equals("2"))
            {
                inlineInputFacade.ReadInput();
            }
        }
    }
}
