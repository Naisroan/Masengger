using System;
using System.Security.Cryptography;
using System.Text;

namespace MasenggerModel
{
    /// <summary>
    /// Clase con metodos estaticos para encriptacion en base a una llave
    /// </summary>
    public static class Encriptado
    {
        private static readonly string Key = "**Msn";

        /// <summary>
        /// Metodo que encripta una cadena de caracteres
        /// </summary>
        /// <param name="toEncrypt">Cadena a encriptar</param>
        /// <param name="useHashing">Indica si utilizará hashing (mas seguro)</param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;

            // convertimos la cadena a un arreglo de bytes
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                // la key la convertimos también a un arreglo de bytes y le aplicamos
                // el hash
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(Key);

            // creamos un objeto y le asignamos la llave (con hash o no) para posteriormente encriptar
            // en base a dicha llave
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            // creamos el encriptador
            ICryptoTransform cTransform = tdes.CreateEncryptor();

            // creamos un arreglo con el resultado de la encriptacion
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);

            tdes.Clear();

            // creamos un string con el arreglo de bytes encriptado
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// Metodo que desencripta una cadena ya encriptada
        /// </summary>
        /// <param name="cipherString">Cadena a desencriptar</param>
        /// <param name="useHashing">Indica si el encriptado uso hasing</param>
        /// <returns></returns>
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;

            // como en el metodo de encriptacion al final convertimos a una cadena de caracteres
            // un arreglo de bytes lo reconvertimos
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                // la key la convertimos también a un arreglo de bytes y le aplicamos
                // el hash
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));

                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(Key);
            }

            // creamos un objeto y le asignamos la llave (con hash o no) para posteriormente desencriptar
            // en base a dicha llave
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            // creamos el desencriptador
            ICryptoTransform cTransform = tdes.CreateDecryptor();

            // obtenemos un arreglo con el resultado de la desencriptacion
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();

            // creamos un string con el arreglo de bytes desencriptado
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        private static string EcryptedKey(string key)
        {
            string encrypted = string.Empty;

            for (int i = 0; i < key.Length; i++)
            {
                char letter = key[i];
                letter = (char)(letter - 1);
                encrypted += letter;
            }

            return encrypted;
        }

        private static string DecryptedKey(string key)
        {
            string decrypted = string.Empty;

            for (int i = 0; i < key.Length; i++)
            {
                char letter = key[i];
                letter = (char)(letter + 1);
                decrypted += letter;
            }

            return decrypted;
        }
    }
}
