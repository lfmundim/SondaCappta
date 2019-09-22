using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using SondaCappta.Models;
using System.IO;
using SondaCappta.Services;

namespace SondaCappta.UnitTests.Facades
{
    public class InlineInputFacade_UnitTests
    {
        private readonly Field _field;

        public InlineInputFacade_UnitTests()
        {
            _field = new Field();
        }

        [Theory]
        [InlineData("5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM", "1 3 N", "5 1 E")]
        public void ReadInlineInput_UnitTest(string dimensionsString, string probeA, string probeACommands, string probeB, string probeBCommands, string expectedProbeAOutcome, string expectedProbeBOutcome)
        {
            var dimensions = dimensionsString.Split(' ');
            _field.XDimension = Convert.ToInt32(dimensions[0]);
            _field.YDimension = Convert.ToInt32(dimensions[1]);

            var stringReader = new StringReader(dimensionsString + '\n' + probeA + '\n' + probeACommands + '\n' + probeB + '\n' + probeBCommands + "\nend");
            Console.SetIn(stringReader);

            var facade = new InlineInputFacade(_field);
            facade.ReadInlineInput();

            _field.Probes.Count.ShouldBe(2);
            _field.Probes[0].GetPosition().ShouldBe(expectedProbeAOutcome);
            _field.Probes[1].GetPosition().ShouldBe(expectedProbeBOutcome);
        }
    }
}
