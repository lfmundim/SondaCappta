﻿using System;

using Microsoft.Extensions.DependencyInjection;

using SondaCappta.Models;
using SondaCappta.Services;

namespace SondaCappta
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection();
            var field = new Field();
            var inlineInputFacade = new InlineInputFacade(field);
            var fileInputFacade = new FileInputFacade(field);

            serviceProvider.AddSingleton(field);

            Console.WriteLine("> File or inline input?\n 1- File \n 2- Inline");
            var readType = Console.ReadLine();
            if (readType.Equals("1"))
            {
                fileInputFacade.ReadInput();
            }
            else if (readType.Equals("2"))
            {
                inlineInputFacade.ReadInput();
            }
        }
    }
}
