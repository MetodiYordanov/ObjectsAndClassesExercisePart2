namespace TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int teamsToCreate = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamsToCreate; i++)
            {
                string[] teamData = Console.ReadLine().Split('-');

                Team currentTeam = new Team
                {
                    Creator = teamData[0],
                    Name = teamData[1],
                    Members = new List<User>(),
                };

                if (teams.Any(t => t.Name == currentTeam.Name))
                {
                    Console.WriteLine($"Team {currentTeam.Name} was already created!");
                }
                else if (teams.Any(t => t.Creator == currentTeam.Creator))
                {
                    Console.WriteLine($"{currentTeam.Creator} cannot create another team!");
                }
                else
                {
                    teams.Add(currentTeam);
                    Console.WriteLine($"Team {currentTeam.Name} has been created by {currentTeam.Creator}!");
                }
            }

            string command = Console.ReadLine();

            while (command != "end of assignment")
            {
                string[] commandData = command.Split("->");
                string userName = commandData[0];
                string userTeam = commandData[1];

                User currentUser = new User
                {
                    Name = userName,
                };

                if (!teams.Any(t => t.Name == userTeam))
                {
                    Console.WriteLine($"Team {userTeam} does not exist!");
                }
                else if (teams.Any(t => t.Members.Contains(currentUser)) ||
                    teams.Any(t => t.Creator == currentUser.Name))
                {
                    Console.WriteLine($"Member {currentUser.Name} cannot join team {userTeam}!");
                }
                else
                {
                    teams.First(t => t.Name == userTeam).Members.Add(currentUser);
                }

                command = Console.ReadLine();
            }

            teams = teams.OrderByDescending(t => t.Members.Count)
                         .ThenBy(t => t.Name)
                         .ToList();

            foreach (var team in teams.Where(t => t.Members.Count > 0))
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(m => m.Name))
                {
                    Console.WriteLine($"-- {member.Name}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var team in teams.Where(t => t.Members.Count == 0))
            {
                Console.WriteLine($"{team.Name}");
            }
        }
    }
}