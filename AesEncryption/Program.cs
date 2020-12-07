using System;
using System.Runtime.InteropServices;

namespace AesEncryption
{
	class Program
	{
		static void Main(string[] args)
		{
			EncryptFile("ThePasswordToDecryptAndEncryptTheFile", @"test.png");
			//DecryptFile("ThePasswordToDecryptAndEncryptTheFile", @"test.png.aes");
		}

		private static void EncryptFile(string password, string filePath)
		{
			// For additional security Pin the password of your files
			GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

			// Encrypt the file
			FileEncryption.FileEncrypt(filePath, password);

			// To increase the security of the encryption, delete the given password from the memory !
			FileEncryption.ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
			gch.Free();

			// You can verify it by displaying its value later on the console (the password won't appear)
			Console.WriteLine("The given password is surely nothing: " + password);
		}

		private static void DecryptFile(string password, string filePath)
		{
			// For additional security Pin the password of your files
			GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

			// Decrypt the file
			FileEncryption.FileDecrypt(filePath, @"test_decrypted.png", password);

			// To increase the security of the decryption, delete the used password from the memory !
			FileEncryption.ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
			gch.Free();

			// You can verify it by displaying its value later on the console (the password won't appear)
			Console.WriteLine("The given password is surely nothing: " + password);
		}
	}
}
