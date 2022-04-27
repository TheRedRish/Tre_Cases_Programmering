namespace MyClassLibrary
{
    public class Fodbold
    {
        public string HowMuchDoWeCheer(int passes, string goal)
        {

            //Logik kode, her bliver der returneret en af de fire muligheder an efter input

            if (goal.ToUpper() == "MÅL") return "Olé Olé Olé";

            else if (passes >= 10) return "High Five - Jubel!!!";

            else if (passes < 1) return "Shh";

            else
            {
                string result = "";

                for (int i = 0; i < passes; i++)
                {
                    result += "Huh! ";
                }

                return result;
            }
        }
    }
}