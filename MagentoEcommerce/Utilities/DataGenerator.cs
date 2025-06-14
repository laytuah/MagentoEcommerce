using System.Text;

namespace MagentoEcommerce.Utilities
{
    class DataGenerator
    {
        static char[] uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        static char[] lowercase = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        static char[] digits = "0123456789".ToCharArray();
        static char[] specialCharacters = "!@#$%^&*".ToCharArray();
        static char[] letters = uppercase.Concat(lowercase).ToArray();
        static char[] alphanumerics = letters.Concat(digits).ToArray();
        static Random random = new Random();

        public static string GenerateRandomString(int length = 10) => BuildString(length, letters);
        public static string GenerateRandomIntegerString(int length = 6) => BuildString(length, digits);
        public static string GenerateRandomAlphanumerics(int length = 12) => BuildString(length, alphanumerics);

        public static string GenerateValidPassword(int length = 12)
        {
            if (length < 4)
                throw new ArgumentException("Password length must be at least 4 to meet complexity rules.");

            var passwordChars = new List<char>
                {
                    uppercase[random.Next(uppercase.Length)],
                    lowercase[random.Next(lowercase.Length)],
                    digits[random.Next(digits.Length)],
                    specialCharacters[random.Next(specialCharacters.Length)]
                };
            var allChars = uppercase.Concat(lowercase).Concat(digits).Concat(specialCharacters).ToArray();
            while (passwordChars.Count < length)
            {
                passwordChars.Add(allChars[random.Next(allChars.Length)]);
            }
            return new string(passwordChars.OrderBy(_ => random.Next()).ToArray());
        }

        public static string GenerateRandomDate(int desiredMinAge = -18, int desiredMaxAge = -100)
        {
            DateTime today = DateTime.Today;
            DateTime minAge = today.AddDays(desiredMinAge);
            int range = (desiredMaxAge - desiredMinAge);
            DateTime randomDate = minAge.AddDays(random.Next(range + 1));
            return randomDate.ToString("yyyy-MM-dd");
        }

        public static string BuildString(int length, char[] dataType)
        {
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(dataType[random.Next(dataType.Length)]);
            }
            return result.ToString();
        }
    }
}
