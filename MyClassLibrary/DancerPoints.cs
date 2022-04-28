namespace MyClassLibrary
{
    public class DancerPoints
    {
        public string NamesAndPointsTotal(List<int> points, List<string> names)
        {
            string result = "";

            //gennemgår listen en for en og laver én lang string med hvert navn og et " & " imellem hvert navn.
            for (int i = 0; i < names.Count; i++)
            {
                result += ($"{names[i]}");
                if (names.Count > 1 && i + 1 != names.Count) result += (" & ");
            }

            //tilføjer summen af listen points til stringen resultat
            result += ($" {points.Sum()}");

            //sender resultatet tilbage
            return result;
        }
    }
}
