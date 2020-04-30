using System.Text.RegularExpressions;
using System.Windows;

namespace Homework4
{
    public class ZipCodeValidation
    {
        public void ZipCodeVal(string uxZipcode)
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

            message(zipMatch, uxZipcode);
        }

        private void message (bool match, string uxZipcode)
        {
            if (match)
            {
                MessageBox.Show(uxZipcode + Constants.message1, Constants.titleMsg1, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(uxZipcode + Constants.message2, Constants.titleMsg2, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
