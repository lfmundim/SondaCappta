using Microsoft.Extensions.DependencyInjection;
using SondaCappta.Models;
using System;

namespace SondaCappta
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection();
            Console.WriteLine("> File or inline input?\n 1- File \n 2- Inline");
            var readType = Console.ReadLine();
            if (readType.Equals("2"))
            {
                Console.Write("> Field Dimensions: ");
                var dimensionsString = Console.ReadLine();
                var dimensions = dimensionsString.Split(' ');
                var field = new Field(Convert.ToInt32(dimensions[0]), Convert.ToInt32(dimensions[1]));
                serviceProvider.AddSingleton(field);

                while (true)
                {

                    Console.Write("> Starting position and direction: ");
                    var positionString = Console.ReadLine();
                    var position = positionString.Split(' ');

                    var probe = new Probe
                    {
                        Coords = new Coords
                        {
                            XCoord = Convert.ToInt32(position[0]),
                            YCoord = Convert.ToInt32(position[1])
                        },
                        Direction = Enum.Parse<Direction>(position[2]),
                    };
                    field.Probes.Add(probe);
                    Console.Write("> Commands: ");
                    var commands = Console.ReadLine();
                    foreach (var command in commands)
                    {
                        if (Enum.TryParse<TurnDirection>(command.ToString(), out var direction))
                        {
                            probe.Turn(direction);
                        }
                        else
                        {
                            field.TryMoveForward(probe);
                        }
                    }
                    Console.WriteLine($"Final position: {probe.GetPosition()}");
                }
            }
        }
    }
}
