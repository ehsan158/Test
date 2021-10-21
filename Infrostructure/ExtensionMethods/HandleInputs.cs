using System;
using System.Text.RegularExpressions;

namespace Infrostructure.ExtensionMethods
{
   public static class HandleInputs
    {
        public static int HandleInput(this string input)
        {
            string pattern = @"\D+";
            var numbers = Regex.Split(input, pattern);
            input = null;
            foreach (var item in numbers)
            {
                input += item;
            }
            return ((input != null && input != "") ? Convert.ToInt32(input):0);
        }
    }
}
