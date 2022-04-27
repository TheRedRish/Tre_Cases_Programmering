using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyClassLibrary
{
    public class PasswordCheck
    {
        //Tjekker om alle password kriterierne er opfyldt
        public bool DoesPasswordOverholdEveryCondition(string username, string password)
        {
            if (DoesMinimumPassword(password) && DoesSizeLettersPassword(password) && DoesContainSpecialCharsPasswordAndNumbers(password)
                && DoesNumberPositionPassword(password) && DoesContainSpacesPassword(password)
                && NotEqualToUsernamePassword(username, password) && NotUsedBefore(username, password))
            {
                return true;
            }
            else return false;
        }
        
        //Tjekker om password er det rigtige, altså det sidste loggede password i textfilen.
        public bool IsPasswordCorrect(string username, string password)
        {
            string lastPassword="";

            if (!DoesFileExist(username))
                return false;

            using (StreamReader sr = new StreamReader($"Passwords\\{username}Passwords.txt"))
            {
                while (!sr.EndOfStream)
                {
                    lastPassword = sr.ReadLine();
                }
            }

            if (lastPassword == password) return true;

            Console.WriteLine("8");
            return false;
        }

        //Tjekker om password har minimum 12 karaktere
        public bool DoesMinimumPassword(string password)
        {
            if (password.Length < 12) { Console.WriteLine("1"); return false; }

            return true;
        }

        //Tjekker om password har store og små bogstaver ved at tjekke dem imod en database med alle danske store og små bogstaver
        public bool DoesSizeLettersPassword(string password)
        {
            Regex rgxUpper = new Regex("[^A-Å]");
            Regex rgxLower = new Regex("[^a-å]");

            if (!rgxUpper.IsMatch(password) && !rgxLower.IsMatch(password)) { Console.WriteLine("2"); return false; }

            return true;
        }

        //Tjekker om password indeholder specialkaraktere ved at tjekke at de indeholder tegn som ikke er en del af de normale.
        public bool DoesContainSpecialCharsPasswordAndNumbers(string password)
        {
            Regex rgx = new Regex("[^A-Åa-å0-9]");

            if (!rgx.IsMatch(password)) { Console.WriteLine("3"); return false; }

            return true;
        }

        //Tjekker om password har et tal i starten eller slutningen
        public bool DoesNumberPositionPassword(string password)
        {
            if (Char.IsDigit(password[0]) || Char.IsDigit(password[password.Length - 1])) { Console.WriteLine("4"); return false; }

            return true;
        }

        //Tjekker om password indeholder mellemrum
        public bool DoesContainSpacesPassword(string password)
        {
            if (password.Contains(" ")) { Console.WriteLine("5"); return false; }

            return true;
        }

        //Tjekker om password er det samme som brugernavn
        public bool NotEqualToUsernamePassword(string username, string password)
        {
            if (username.ToLower() == password.ToLower()) { Console.WriteLine("6"); return false; }

            return true;
        }

        //Tjekker om password er blevet brug før ved at sammenligne med en liste over alle tidligere brugte password, hentet fra filen.
        public bool NotUsedBefore(string username, string password)
        {
            List<string> passwords = new List<string>();

            if (!DoesFileExist(username))
                return true;

            using (StreamReader sr = new StreamReader($"Passwords\\{username}Passwords.txt"))
            {
                while (!sr.EndOfStream)
                {
                    passwords.Add(sr.ReadLine());
                }
            }
            if (passwords.Contains(password)) { Console.WriteLine("7"); return false; }

            return true;
        }

        //Tjekker om filen med findes. Bruges så der ikke opstår fejl ved at prøve og læse en fil der ikke findes.
        public bool DoesFileExist(string fileName)
        {
            if (File.Exists($"Passwords\\{fileName}Passwords.txt")) return true;

            return false;
        }
    }
}
