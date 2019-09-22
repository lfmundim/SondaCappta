using SondaCappta.Models;
using SondaCappta.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SondaCappta.Services
{
    public class InlineInputFacade : BaseInputFacade, IInputFacade
    {
        public InlineInputFacade(Field field) : base(field)
        {
        }

        /// <summary>
        /// Executes the logic reading from inline data
        /// </summary>
        public void ReadInput()
        {
            try
            {
                Console.WriteLine("Initializing inline input. To stop type any unexpected input");
                BuildField();

                while (true)
                {
                    var probe = AddProbe();
                    ExecuteCommands(probe);

                    Console.WriteLine($"Final position: {probe.GetPosition()}");
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Program finished due to invalid input");
                return;
            }
        }

    }
}
