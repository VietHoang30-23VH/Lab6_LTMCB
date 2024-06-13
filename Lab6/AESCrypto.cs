using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class AESCrypto
{
    private static readonly byte[] key = GenerateAESKey("1234");
    public static byte[] GenerateAESKey(string keyString)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(keyString);
            return sha256.ComputeHash(keyBytes);
        }
    }
    public static string Encrypt(string text)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = aes.Key.Take(16).ToArray();
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(text);
                    }
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }
    public static string Decrypt(string cipherText)
    {
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = aes.Key.Take(16).ToArray();
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}
