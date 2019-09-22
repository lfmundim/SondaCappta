using SondaCappta.Models;
using SondaCappta.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SondaCappta.Services
{
    public class FileInputFacade : BaseInputFacade, IInputFacade
    {
        public FileInputFacade(Field field) : base(field)
        {
        }

        public void ReadInput()
        {
            Console.WriteLine("Initializing file input.");
            Console.Write("> Full file path: ");
            var filePath = Console.ReadLine();
            StreamReader file;
            try
            {
                file = new StreamReader(filePath);
                BuildField(file);

                while (true)
                {
                    var probe = AddProbe(file);
                    ExecuteCommands(probe, file);

                    Console.WriteLine($"Final position: {probe.GetPosition()}");
                }
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("Program finished due to end of file input");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Program finished due to invalid input");
            }
            catch (FileNotFoundException fex)
            {
                Console.WriteLine($"Could not find file: {fex.Message}");
            }
        }
    }
}
