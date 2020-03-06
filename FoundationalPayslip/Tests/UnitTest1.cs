//using System;
using Xunit;
using FoundationalPayslip;

namespace FoundationalPayslip.Tests
{
    public class SomeBasicTests
    {
        private readonly OutputFormatter _simpleFunctions;

        public SomeBasicTests()
        {
            _simpleFunctions = new OutputFormatter();
        }

        [Fact]
        public void IsNetIncomeRounded()
        {
            System.Console.WriteLine("The test is running");
            //double result = _simpleFunctions.FormatNetIncome();

            //Assert.True(result % 2 == 0, "The number has been rounded!");
        }
    }
}