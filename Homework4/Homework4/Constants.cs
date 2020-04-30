using System.Collections.Generic;

namespace Homework4
{
    public class Constants
    {
        public const string message1 = " is a valid Zipcode";
        public const string message2 = " is not a valid Zipcode";
        public const string titleMsg1 = "Valid Zipcode";
        public const string titleMsg2 = "InValid Zipcode";

        public List<string> ZipCodes = new List<string>();

        const string fullUSVaildZipcode = "^[0-9]{5}-[0-9]{4}$";
        const string uSVaildZipcode = "^[0-9]{5}$";
        const string canadaVaildZipcode = "^[A-Z]{1}[0-9]{1}[A-Z]{1}[0-9]{1}[A-Z]{1}[0-9]{1}$";

        public Constants()
        {
            ZipCodes.Add(fullUSVaildZipcode);
            ZipCodes.Add(uSVaildZipcode);
            ZipCodes.Add(canadaVaildZipcode);
        }
    }
}
