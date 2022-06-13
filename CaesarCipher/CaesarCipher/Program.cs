using System;
using System.Text;

namespace CaesarCipher
{
	public class CaesarCipher
	{

		private static char Caesar(char ch, int key) 
		{
			if (!char.IsLetter(ch))
				return ch; // Checking if the character is a letter 

			char offset = char.IsUpper(ch) ? 'A' : 'a';  

			return (char)((((ch + key) - offset) % 26) + offset);
		}

 
		public static string Encryption(string input, int key)
		{
			string output = string.Empty;

			foreach (char ch in input)   // Using the Caesar method for each letter 
				output += Caesar(ch, key);

			return output;
		}


		// Decryption
		public static string Decryption(string input, int key)
		{
			// Decryption is done with the opposite key , on the encrypted text

			return Encryption(input, 26 - key); 
		}

		public static void Main(String[] args)
		{
			Console.WriteLine("Enter text you wish to encrypt: ");
			string text = Console.ReadLine();

			if (string.IsNullOrEmpty(text)) // Making sure the user enters a text
			{
				while (string.IsNullOrEmpty(text))
				{
					Console.WriteLine("Reintroduceti fraza: ");
					text = Console.ReadLine();
				}
			}

			Console.WriteLine("Insert encryption key : ");
			int key = Convert.ToInt32(Console.ReadLine());

			// For the key we used the number of letters in the English vocabulary ( 26 )

			if (key > 26) // If the key is bigger than 26 we set it to 26
			{
				key = 26;
			}

			Console.WriteLine("-------------------------");
			Console.WriteLine($"Text : {text}");
			Console.WriteLine($"Key : {key}");

			Console.WriteLine("-------------------------");
			Console.WriteLine($"Encrypted Text:  {Encryption(text,key)} ");
			Console.WriteLine($"Decrypted Text: {Decryption(Encryption(text, key), key)}");
		}
	}
}