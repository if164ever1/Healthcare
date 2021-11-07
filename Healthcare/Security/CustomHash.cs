using EasyEncryption;

namespace Healthcare.Security
{
    public static class CustomHash
    {
		internal static string HashPassword(string input)
		{ 
			return SHA.ComputeSHA256Hash(input);
		}

		internal static bool PasswordCheck(string userInput, string savedInDbPassword)
		{ 
			string hashedInput = HashPassword(userInput);
			bool doPasswordsMatch = string.Equals(hashedInput, savedInDbPassword);
			return doPasswordsMatch;
		}
	}
}
