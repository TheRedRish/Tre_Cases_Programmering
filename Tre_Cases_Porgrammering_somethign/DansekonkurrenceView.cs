using MyClassLibrary;

namespace Tre_Cases_Porgrammering
{
    internal class DansekonkurrenceView
    {
        DancerPoints _dancerPoints = new DancerPoints();
        public DansekonkurrenceView()
        {
            string nameInput;
            int pointsInput;
            bool succesInput = false, succes = false;

            List<int> points = new List<int>();
            List<string> names = new List<string>();

            //Spørger om navn og points og lægger dem ind i deres henholdsvise liste. Kommer ud af loop når der tastes Y
            do
            {
                //Bliver holdt inde i loopet hvis der ikke bliver tastet et heltal i Succesinput.
                do
                {
                    Console.Clear();
                    Console.Write("Indtast navn:   ");

                    nameInput = Console.ReadLine();

                    Console.Write("Indtast points: ");
                    succesInput = int.TryParse(Console.ReadLine(), out pointsInput);

                    //Hvis der ikke indtastes et heltal bliver denne besked sendt.
                    if (!succesInput)
                    {
                        Console.WriteLine("Du har ikke indtastet et heltal, prøv igen.");
                        Console.ReadKey();
                    }

                } while (!succesInput);

                 //tilføjer indput til listerne
                points.Add(pointsInput);
                names.Add(nameInput);

                //Kommer ud af loopet hvis der tastes Y.
                Console.Write("Er du færdig med indtastning af navne? y/n: ");
                string doneCheck = Console.ReadLine();
                if (doneCheck.ToUpper() == "Y") succes = true;
                
            } while (!succes);

            //Sender points og navn til NamesAndPointsTotal. Får en string tilbage med navne og total points
            var result = _dancerPoints.NamesAndPointsTotal(points, names);

            Console.Write(result);
            Console.ReadKey();

        }
    }
}
