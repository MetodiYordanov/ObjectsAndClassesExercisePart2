namespace Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            Article originalArticle = new Article
            {
                Title = input[0],
                Content = input[1],
                Author = input[2],
            };

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(": ");

                if (command[0] == "Edit")
                {
                    originalArticle.Edit(command[1]);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    originalArticle.ChangeAuthor(command[1]);
                }
                else if (command[0] == "Rename")
                {
                    originalArticle.Rename(command[1]);
                }
            }

            Console.WriteLine(originalArticle.ToString());
        }
    }
}