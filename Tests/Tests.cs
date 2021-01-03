using System.IO;
using CTFdExporter;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConvertCTFdScoreboardToCTFTimeScoreboardString()
        {
            var input = File.ReadAllText(Path.Combine("TestData", "testdata.json"));
            var response = CTFTimeConverter.Convert(input);
            Assert.That(response != null);

            var scoreboard = JsonConvert.DeserializeObject<Scoreboard>(input);
            var ctfTimeScoreboard = JsonConvert.DeserializeObject<CTFTimeScoreboard>(response);

            Assert.AreEqual(scoreboard.data.Length, ctfTimeScoreboard.standings.Length);
            
        }
    }
}