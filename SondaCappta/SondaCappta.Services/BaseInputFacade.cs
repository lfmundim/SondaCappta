using SondaCappta.Models;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SondaCappta.Services
{
    public class BaseInputFacade
    {
        private static readonly Regex DimensionInput = new Regex(@"^(\d \d)\s*$");
        private static readonly Regex CommandsInput = new Regex(@"^([LRM]+)\s*$");
        private static readonly Regex PositionInput = new Regex(@"^(\d \d [NEWS])\s*$");

        private readonly Field _field;

        public BaseInputFacade(Field field)
        {
            _field = field;
        }

        /// <summary>
        /// Builds a field using direct user input
        /// </summary>
        protected void BuildField()
        {
            Console.Write("> Field Dimensions: ");
            var dimensionsString = Console.ReadLine();
            BuildFieldFromString(dimensionsString);
        }

        /// <summary>
        /// Builds a field using a <paramref name="file"/> input
        /// </summary>
        /// <param name="file"></param>
        protected void BuildField(StreamReader file)
        {
            var dimensionsString = file.ReadLine();
            BuildFieldFromString(dimensionsString);
        }

        /// <summary>
        /// Adds a probe to a field using direct user input
        /// </summary>
        /// <returns></returns>
        protected Probe AddProbe()
        {
            Console.Write("> Starting position and direction: ");
            var positionString = Console.ReadLine();
            return AddProbeFromString(positionString);
        }

        /// <summary>
        /// Adds a probe to a field using a <paramref name="file"/> input
        /// </summary>
        /// <returns></returns>
        protected Probe AddProbe(StreamReader file)
        {
            var positionString = file.ReadLine();
            return AddProbeFromString(positionString);
        }

        /// <summary>
        /// Executes commands for a <paramref name="probe"/> using direct user input
        /// </summary>
        /// <param name="probe"></param>
        protected void ExecuteCommands(Probe probe)
        {
            Console.Write("> Commands: ");
            var commands = Console.ReadLine();
            ExecuteCommandsFromString(commands, probe);
        }

        /// <summary>
        /// Executes commands for a <paramref name="probe"/> using a <paramref name="file"/> input
        /// </summary>
        /// <param name="probe"></param>
        protected void ExecuteCommands(Probe probe, StreamReader file)
        {
            var commands = file.ReadLine();
            ExecuteCommandsFromString(commands, probe);
        }

        private void ExecuteCommandsFromString(string input, Probe probe)
        {
            if (!CommandsInput.IsMatch(input))
            {
                throw new ArgumentException();
            }

            foreach (var command in input)
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

        private Probe AddProbeFromString(string input)
        {
            if (!PositionInput.IsMatch(input))
            {
                throw new ArgumentException();
            }
            var position = input.Split(' ');

            var probe = new Probe(position[0], position[1], position[2]);
            _field.Probes.Add(probe);

            return probe;
        }

        private void BuildFieldFromString(string input)
        {
            if (!DimensionInput.IsMatch(input))
            {
                throw new ArgumentException();
            }
            var dimensions = input.Split(' ');
            _field.XDimension = Convert.ToInt32(dimensions[0]);
            _field.YDimension = Convert.ToInt32(dimensions[1]);
        }
    }
}
