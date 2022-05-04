namespace MyClassLibrary
{
    public class DancerPoints
    {
        public string Name { get; set; }

        public int Points { get; set; }

        public DancerPoints(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public static DancerPoints operator +(DancerPoints a, DancerPoints b)
            => new DancerPoints($"{a.Name} & {b.Name} ", a.Points + b.Points);
    }
}
