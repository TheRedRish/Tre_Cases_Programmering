using MyClassLibrary;

namespace Tre_Cases_Porgrammering
{
    internal class FodboldView
    {
        // Nyt objekt fra Fodbold Klassen, behøver ikke blive defineret det er fra MyClassLibrary da der er skrevet "Using"
        Fodbold _fodbold = new Fodbold();

        public void FodboldStartup()
        {
            string goal;
            bool succes;
            int passes;

            //Henter input fra brugeren og tjekker at der bliver skrevet et heltal ved afleveringer
            do
            {
                Console.Clear();

                Console.Write("Er der blevet scoret et mål? Så skrive \"Mål\": ");
                goal = Console.ReadLine();

                Console.Write("Hvor mange afleveringer har der været: ");
                succes = int.TryParse(Console.ReadLine(), out passes);
            } while (!succes);

            //Sender passes og goal til HowMuchDoWeCheer og sender return værdien ind i result som bliver skrevet ud.
            var result = _fodbold.HowMuchDoWeCheer(passes, goal);
            Console.WriteLine(result);

            Console.ReadKey();
        }

    }
}
