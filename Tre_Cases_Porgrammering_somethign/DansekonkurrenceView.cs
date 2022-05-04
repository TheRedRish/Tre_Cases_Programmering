using MyClassLibrary;

namespace Tre_Cases_Porgrammering
{
    internal class DansekonkurrenceView
    {
        public void DansekonkurrenceStartup()
        {
            string[] nameInput = new string[2];
            int[] pointsInput = new int[2];
            bool succesInput = false;

            do {
                for (int i = 0; i < 2; i++)
                {
                    Console.Write("Indtast navn:   ");

                    nameInput[i] = Console.ReadLine();

                    Console.Write("Indtast points: ");
                    succesInput = int.TryParse(Console.ReadLine(), out pointsInput[i]);

                    if (!succesInput)
                    {
                        Console.WriteLine("Du har ikke indtastet et heltal, prøv igen.");
                        Console.ReadKey();
                    }
                }
            } while (!succesInput);

            DancerPoints danser_1 = new DancerPoints(nameInput[0], pointsInput[0]);
            DancerPoints danser_2 = new DancerPoints(nameInput[1], pointsInput[1]);

            var results = danser_1 + danser_2;

            Console.WriteLine(results.Name + results.Points.ToString());
            Console.ReadKey();
        }
    }
}
