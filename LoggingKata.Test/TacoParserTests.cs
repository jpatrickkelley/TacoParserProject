using System;
using Xunit;
using System.Collections.Generic;


namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
            //Arrange

            var Tester = new TacoParser();

            var input = "31.570771,-84.10353,Taco Bell Albany...";

            //Act 

            var Actual = Tester.Parse(input);


            //Assert

            Assert.NotNull(Actual);

        }

        [Theory]
        [InlineData("31.570771,-84.10353,Taco Bell Albany...", "Taco Bell Albany..." )]
        public void ShouldParse(string str, string expected)
        {
            //TacoParserTests parserTest = new TacoParserTests();

         //Creating an object of TacoPaser class so we can access Shouls Parse method.
         
            TacoParser parserInstance = new TacoParser();

            // Creating an object of Tacoparser class so we can access TacoParser method.

            //TacoBell newBell = new TacoBell();

            //ACT
            var actual = parserInstance.Parse(str);


            // This is the answer to the test.
            //Assert
            Assert.Equal(expected, actual.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
            //Arrange
            var fail = new TacoParser();

            //Act
            var actual = fail.Parse(str);

            //Assert

            Assert.Null(actual);



        }
    }
}
