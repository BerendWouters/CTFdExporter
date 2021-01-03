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
            Assert.That(ctfTimeScoreboard.standings.Length == 2);
            Assert.That(ctfTimeScoreboard.standings[0].pos == 1);
            Assert.That(ctfTimeScoreboard.standings[0].score == 655);
            Assert.That(ctfTimeScoreboard.standings[0].team == "Team 1");
            Assert.That(ctfTimeScoreboard.standings[1].pos == 2);
            Assert.That(ctfTimeScoreboard.standings[1].score == 655);
            Assert.That(ctfTimeScoreboard.standings[1].team == "Team 2");
        }
    }
}