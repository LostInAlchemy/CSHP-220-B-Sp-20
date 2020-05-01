using System.Text.RegularExpressions;

namespace Homework4
{
    public class ZipCodeValidation
    {
        public bool ZipCodeVal(string uxZipcode)
        {
            Constants constants = new Constants();

            bool zipMatch = false;

            foreach (string item in constants.ZipCodes)
            {
                Regex match = new Regex(@item);

                if (match.IsMatch(uxZipcode))
                {
                    zipMatch = true;
                }
            }

            return zipMatch;
        }
    }
}
