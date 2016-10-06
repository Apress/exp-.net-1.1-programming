using System;
using System.Security.Cryptography;
using System.IO;

namespace EncryptDecrypt
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			des.GenerateKey();
			des.GenerateIV();
			WriteKeyAndIV(des);
			ICryptoTransform encryptor = des.CreateEncryptor();

			FileStream inFile = new FileStream(@"Bloops.txt", FileMode.Open);
			FileStream outFile = new FileStream(@"BloopsEnc.txt", FileMode.Create);
			int inSize = encryptor.InputBlockSize;
			int outSize = encryptor.OutputBlockSize;
			byte [] inBytes = new byte[inSize];
			byte [] outBytes = new byte[outSize];
			int numBytesRead, numBytesOutput;
			do
			{
				numBytesRead = inFile.Read(inBytes, 0, inSize);
				if (numBytesRead == inSize)
				{
					numBytesOutput = encryptor.TransformBlock(inBytes, 0, numBytesRead, outBytes, 0);
					outFile.Write(outBytes, 0, numBytesOutput);
				}
				else if (numBytesRead > 0)
				{
					byte [] final = encryptor.TransformFinalBlock(inBytes, 0, numBytesRead);
					outFile.Write(final, 0, final.Length);
				}
			} while (numBytesRead > 0);
			inFile.Close();
			outFile.Close();
		}

		static void WriteKeyAndIV(DES des)
		{
			StreamWriter outFile = new StreamWriter(@"KeyIV.txt", false);
			outFile.WriteLine(des.KeySize);
			for (int i=0 ; i< des.KeySize/8 ; i++)
				outFile.WriteLine(des.Key[i]);
			for (int i=0 ; i< des.KeySize/8 ; i++)
				outFile.WriteLine(des.IV[i]);
			outFile.Close();
		}
	}
}
