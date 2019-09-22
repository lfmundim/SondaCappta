using SondaCappta.Models;
using SondaCappta.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SondaCappta.Services
{
    public class InlineInputFacade : IInlineInputFacade
    {
        private readonly Field _field;
        private static readonly Regex _dimensionInput = new Regex(@"^(\d \d)\s*$");
        private static readonly Regex _commandsInput = new Regex(@"^([LRM]+)\s*$");
        private static readonly Regex _positionInput = new Regex(@"^(\d \d [NEWS])\s*$");

        public InlineInputFacade(Field field)
        {
            _field = field;
        }

        public void ReadInlineInput()
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

        private void BuildField()
        {
            Console.Write("> Field Dimensions: ");
            var dimensionsString = Console.ReadLine();
            if (!_dimensionInput.IsMatch(dimensionsString))
            {
                throw new ArgumentException();
            }
            var dimensions = dimensionsString.Split(' ');
            _field.XDimension = Convert.ToInt32(dimensions[0]);
            _field.YDimension = Convert.ToInt32(dimensions[1]);
        }

        private Probe AddProbe()
        {
            Console.Write("> Starting position and direction: ");
            var positionString = Console.ReadLine();
            if (!_positionInput.IsMatch(positionString))
            {
                throw new ArgumentException();
            }
            var position = positionString.Split(' ');

            var probe = new Probe(position[0], position[1], position[2]);
            _field.Probes.Add(probe);

            return probe;
        }

        private void ExecuteCommands(Probe probe)
        {
            Console.Write("> Commands: ");
            var commands = Console.ReadLine();
            if (!_commandsInput.IsMatch(commands))
            {
                throw new ArgumentException();
            }

            foreach (var command in commands)
            {
                if (Enum.TryParse<TurnDirection>(command.ToString(), out var turnDirection))
                {
                    probe.Turn(turnDirection);
                }
                else
                {
                    _field.TryMoveForward(probe);
                }
            }
        }
    }
}
