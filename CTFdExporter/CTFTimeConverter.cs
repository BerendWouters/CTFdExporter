using System.Linq;
using Newtonsoft.Json;

namespace CTFdExporter
{
    public static class CTFTimeConverter
    {
        public static string Convert(string input)
        {
            var scoreboard = JsonConvert.DeserializeObject<Scoreboard>(input);
            var ctfTimeScoreboard = Convert(scoreboard);
            return JsonConvert.SerializeObject(ctfTimeScoreboard);
        }
        public static CTFTimeScoreboard Convert(Scoreboard scoreboard)
        {
            var ctftimeScoreboard = new CTFTimeScoreboard()
            {
                standings = scoreboard.data.Select(d => new CTFTimeScoreboard.Standing()
                {
                    pos = d.pos,
                    score = d.score,
                    team = d.name
                }).ToArray()
            };
            return ctftimeScoreboard;
        }

    }

    public class CTFTimeScoreboard
    {
        public Standing[] standings { get; set; }
        public class Standing
        {
            public int pos { get; set; }
            public string team { get; set; }
            public int score { get; set; }
        }
    }
    public class Scoreboard
    {
        public bool success { get; set; }
        public Team[] data { get; set; }

        public class Team
        {
            public int pos { get; set; }
            public int account_id { get; set; }
            public string account_url { get; set; }
            public string account_type { get; set; }
            public object oauth_id { get; set; }
            public string name { get; set; }
            public int score { get; set; }
            public Member[] members { get; set; }
        }

        public class Member
        {
            public int id { get; set; }
            public object oauth_id { get; set; }
            public string name { get; set; }
            public int score { get; set; }
        }

    }
}