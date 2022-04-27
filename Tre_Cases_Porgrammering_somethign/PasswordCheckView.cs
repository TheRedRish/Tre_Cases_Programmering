using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary;

namespace Tre_Cases_Porgrammering
{
    internal class PasswordCheckView
    {
        PasswordCheck _passwordCheck = new PasswordCheck();

        public PasswordCheckView()
        {
            string choiceStart;

            // Spørger om der skal oprettes eller logges ind. Kører loop til der er skrevet en af delene
            do
            {
                Console.Clear();
                Console.Write("Skriv \"Login\" for at logge ind eller \"Opret\" for at oprette eller ændre password for en bruger: ");
                choiceStart = Console.ReadLine();

                // Kører loginscreen eller createaccountscreen an efter input, fortæller hvis der er tastet noget forkert.
                if (choiceStart.ToUpper() == "LOGIN")
                {
                    LoginScreen();
                }
                else if (choiceStart.ToUpper() == "OPRET")
                {
                    CreateAccountScreen();
                }
                else
                {
                    Console.WriteLine("Du har indtastet noget forkert, prøv igen.");
                    Console.ReadKey();
                }

            } while (choiceStart.ToUpper() != "LOGIN" && choiceStart.ToUpper() != "OPRET");
        }

        internal void LoginScreen()
        {
            string username, password;

            //Kører indtil rigtigt input er givet.
            do
            {
                // Visuelt sætter skærmen op og beder om brugernavn og password
                Console.Clear();

                Console.SetCursorPosition(55, 13);
                Console.Write("Login");

                Console.SetCursorPosition(50, 15);
                Console.Write("Brugernavn: ");
                username = Console.ReadLine();

                Console.SetCursorPosition(50, 16);
                Console.Write("Password:   ");
                password = Console.ReadLine();

                //Hvis metoden IsPasswordCorrect giver false holdes man i loopet
                if (!_passwordCheck.IsPasswordCorrect(username, password))
                {
                    ;
                    Console.SetCursorPosition(50, 19);
                    Console.WriteLine("Brugernavn eller password er forkert angivet");
                    Console.ReadKey();
                }

            } while (!_passwordCheck.IsPasswordCorrect(username, password));
            
            //hvis man er ude af loopet betyder det man har tastet rigtigt og kan komme ind.
            Console.SetCursorPosition(50, 19);
            Console.WriteLine("Tillykke Du er logget ind!");
            Console.ReadKey();
        }

        internal void CreateAccountScreen()
        {
            string username, password;

            //Kører indtil der er tastet noget rigtigt.
            do
            {
                // Visuelt sætter tingene op og beder om brugernavn og password. Her kan man enten oprette en bruger eller ændre password.
                Console.Clear();

                Console.SetCursorPosition(55, 13);
                Console.Write("Opret bruger eller ændre password");

                Console.SetCursorPosition(50, 15);
                Console.Write("Brugernavn: ");
                username = Console.ReadLine();

                Console.SetCursorPosition(50, 16);
                Console.Write("Password:   ");
                password = Console.ReadLine();

                // Hvis password kriterier ikke er overholdt bliver password og brugernavn ikke godtaget.
                if (!_passwordCheck.DoesPasswordOverholdEveryCondition(username, password))
                {
                    Console.SetCursorPosition(50, 19);
                    Console.WriteLine("IKKE GODKENDT password");
                    Console.ReadKey();
                }

            } while (!_passwordCheck.DoesPasswordOverholdEveryCondition(username, password));

            //Tilføjer brugernavn og password til filen med Username. Hvis filen ikke eksistere opretter den en nu fil med dette navn.
            //Derved ka der være flere brugere med deres passwords gemt hver for sig. Bliver gemt
            //Tre_Cases_Programmering\Tre_Cases_Porgrammering_somethign\bin\Debug\net6.0\Passwords
            using (StreamWriter sw = File.AppendText($"Passwords\\{username}Passwords.txt"))
            {
                sw.WriteLine(password);
            }

            Console.SetCursorPosition(50, 21);
            Console.Write("Din bruger er blevet oprettet!");
            Console.ReadKey();
        }
    }
}
