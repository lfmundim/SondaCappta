using Shouldly;
using SondaCappta.Models;
using SondaCappta.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace SondaCappta.UnitTests.Facades
{
    public class FileInputFacade_UnitTests
    {
        private readonly Field _field;

        public FileInputFacade_UnitTests()
        {
            _field = new Field();
        }

        [Theory]
        [InlineData("../../../../input.txt", "1 3 N", "5 1 E")]
        public void ReadFileInput_UnitTest(string filePath, string expectedProbeAOutcome, string expectedProbeBOutcome)
        {
            var stringReader = new StringReader(filePath+ '\n');
            Console.SetIn(stringReader);

            var facade = new FileInputFacade(_field);
            facade.ReadInput();

            _field.Probes.Count.ShouldBe(2);
            _field.Probes[0].GetPosition().ShouldBe(expectedProbeAOutcome);
            _field.Probes[1].GetPosition().ShouldBe(expectedProbeBOutcome);
        }
    }
}
