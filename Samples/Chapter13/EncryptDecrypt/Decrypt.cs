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
			ReadKeyAndIV(des);

			ICryptoTransform decryptor = des.CreateDecryptor();

			FileStream inFile = new FileStream(@"BloopsEnc.txt", FileMode.Open);
			FileStream outFile = new FileStream(@"BloopsDec.txt", FileMode.Create);
			int inSize = decryptor.InputBlockSize;
			int outSize = decryptor.OutputBlockSize;
			byte [] inBytes = new byte[inSize];
			byte [] outBytes = new byte[outSize];
			int numBytesRead, numBytesOutput;
			do
			{
				numBytesRead = inFile.Read(inBytes, 0, inSize);
				if (numBytesRead == inSize)
				{
					numBytesOutput = decryptor.TransformBlock(inBytes, 0, numBytesRead, outBytes, 0);
					outFile.Write(outBytes, 0, numBytesOutput);
				}
				else
				{
					byte [] final = decryptor.TransformFinalBlock(inBytes, 0, numBytesRead);
					outFile.Write(final, 0, final.Length);
				}
			} while (numBytesRead > 0);
			inFile.Close();
			outFile.Close();
		}

		static void ReadKeyAndIV(DES des)
		{
			StreamReader inFile = new StreamReader(@"KeyIV.txt");
			int keySize;
			keySize = int.Parse(inFile.ReadLine());
			byte [] key = new byte[keySize/8];
			byte [] iv = new byte[keySize/8];
			for (int i=0 ; i< des.KeySize/8 ; i++)
				key[i] = byte.Parse(inFile.ReadLine());
			for (int i=0 ; i< des.KeySize/8 ; i++)
				iv[i] = byte.Parse(inFile.ReadLine());
			inFile.Close();
			des.KeySize = keySize;
			des.Key = key;
			des.IV = iv;
		}
	}
}
