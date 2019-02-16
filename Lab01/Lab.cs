using System.Linq;

namespace Lab01
{
    public class Lab
    {
        public string Joey(string input)
        {
            var listOfString = input.Select((c, i) => (new string(c, 1)).ToUpper() + new string(c, i));

            return string.Join('-', listOfString);
        }
    }
}