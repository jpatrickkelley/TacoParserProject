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
            var Tester = new TacoParser();
            var input = "31.570771,-84.10353,Taco Bell Albany..."; 
            var Actual = Tester.Parse(input);
            Assert.NotNull(Actual);
        }

        [Theory]
        [InlineData("31.570771,-84.10353,Taco Bell Albany...", "Taco Bell Albany..." )]
        public void ShouldParse(string str, string expected)
        {
         
            TacoParser parserInstance = new TacoParser();
            var actual = parserInstance.Parse(str);
            Assert.Equal(expected, actual.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            var fail = new TacoParser();
            var actual = fail.Parse(str);
            Assert.Null(actual);

        }
    }
}
