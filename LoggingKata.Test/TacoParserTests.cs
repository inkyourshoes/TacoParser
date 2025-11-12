using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests7
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            var tacoParser = new TacoParser();
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.087508,-84.575512,Taco Bell Acworth...\n", -84.575512)]
        [InlineData("34.376395,-84.913185,Taco Bell Adairsvill...", -84.913185)]
        [InlineData("31.570771,-84.10353,Taco Bell Albany...\n", -84.10353)]
        [InlineData("34.280205,-86.217115,Taco Bell Albertvill...\n", -86.217115)]
        [InlineData("30.731386,-86.566652,Taco Bell Crestvie...\n", -86.566652)]
        
        
        public void ShouldParseLongitude(string line, double expected)
        { 
            var tacoParserInstance = new TacoParser();
            var actual = tacoParserInstance.Parse(line);
            Assert.Equal(expected, actual.Location.Longitude);
        }
        
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", 34.113051)]
        [InlineData("33.926654,-87.757477,Taco Bell Winfiel...\n", 33.926654)]
        [InlineData("32.524115,-86.20775,Taco Bell Wetumpk...", 32.524115)]
        [InlineData("33.810924,-86.820487,Taco Bell Warrio...", 33.810924)]
        [InlineData("33.724109,-84.937891,Taco Bell Villa Ric...)", 33.724109)]
        
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParserInstance = new TacoParser();
            var actual = tacoParserInstance.Parse(line);

            Assert.Equal(expected, actual.Location.Latitude);
        }

     
    }
}
