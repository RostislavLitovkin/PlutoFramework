using System.Text.RegularExpressions;

namespace PlutoFramework.Model
{
    public class FormModel
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            var regex = new Regex(emailRegex, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }
    }
}
