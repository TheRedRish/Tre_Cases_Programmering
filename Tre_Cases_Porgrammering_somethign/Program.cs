using MyClassLibrary;

namespace Tre_Cases_Porgrammering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Starter ved passwordcheck           
            new PasswordCheckView().PasswordStartup();

            //Her kan der vælges mellem Dansekonkurrence eller Fodbold
            bool done = false;

            while (!done)
            {
                Console.Clear();

                Console.WriteLine("Skriv \"Danse\" for danseprogram, skriv \"Fodbold\" for fodbold program, skriv Done for at logge ud.");
                string choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "DANSE":
                        new DansekonkurrenceView().DansekonkurrenceStartup();
                        break;
                    case "FODBOLD":
                        new FodboldView().FodboldStartup();
                        break;
                    case "DONE":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Du har indtastet noget forkert, prøv igen.");
                        break;
                }
            }
        }
    }
}