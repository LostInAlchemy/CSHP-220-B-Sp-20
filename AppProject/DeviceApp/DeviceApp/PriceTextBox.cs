using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace DeviceApp
{
    public class PriceTextBox : TextBox
    {

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
            base.OnPreviewTextInput(e);
        }

        private bool AreAllValidNumericChars(string str)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");

            if (!regex.IsMatch(str))
            {
                return false;
            }

            //foreach (char c in str)
            //{
            //    if (!(c.Equals('.') || (char.IsNumber(c))))
            //    {
            //        if ((c == '.') && (str.IndexOf('.') > -1))
            //        {
            //            return false;
            //        }

            //        return false;
            //    }
            //}

            return true;
        }
    }
}
