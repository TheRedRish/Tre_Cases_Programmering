using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class Danser
    {
        private string name;
        private int points;

        public string Name 
        {
            get {return name; }
            set { name = value; }
        }

        public int Points
        {
            get {return points; }
            set { points = value; }
        }

        public Danser()
        {

        }

        public Danser(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public static Danser operator +(Danser a, Danser b)
            => new Danser($"{a.Name} & {b.Name}", a.points + b.points);


        public void Samling()
        {
            Danser danser_1 = new Danser("Rune", 999999);
            Danser danser_2 = new Danser("Henrik", 69);

            var results = danser_1 + danser_2;
            
            Console.WriteLine(results.name + results.points.ToString());
        }
    }
}
