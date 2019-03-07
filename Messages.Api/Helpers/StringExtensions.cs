using System;
using System.Globalization;
using System.Text;

namespace Messages.Api.Helpers
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            // Filter the message to include only letters and numbers
            var stringBuilder = new StringBuilder();
            foreach (var letter in message)
            {
                if (char.IsLetterOrDigit(letter))
                {
                    stringBuilder.Append(letter);
                }
            }

            var filtered = stringBuilder.ToString();
            if (string.IsNullOrWhiteSpace(filtered))
            {
                return false;
            }

            for (var i = 0; i < filtered.Length / 2; i++)
            {
                var leftLetter = filtered[i].ToString();
                var rightLetter = filtered[filtered.Length - i - 1].ToString();

                // Ignore case and accented letters: https://stackoverflow.com/a/7720903
                var areEqual = string.Compare(leftLetter, rightLetter, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0;
                if (!areEqual)
                {
                    return false;
                }
            }

            return true;
        }
    }
}