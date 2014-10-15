using SmartFormat;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Decrypts (RSA) a string using the supplied key.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="key">Decryption key.</param>
        /// <returns>
        /// The decrypted string or null if decryption failed.
        /// </returns>
        /// <exception cref="ArgumentNullException">Occurs when value and/or key is null or empty.</exception>
        public static string Decrypt(this string value, string key)
        {
            Contract.Requires<ArgumentException>(!String.IsNullOrWhiteSpace(value));
            Contract.Requires<ArgumentException>(!String.IsNullOrWhiteSpace(key));

            string result = null;

            try
            {
                System.Security.Cryptography.CspParameters cspp = new System.Security.Cryptography.CspParameters();
                cspp.KeyContainerName = key;

                using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(cspp))
                {
                    rsa.PersistKeyInCsp = true;

                    string[] decryptArray = value.Split(new string[] { "-" }, StringSplitOptions.None);
                    byte[] decryptByteArray = Array.ConvertAll<string, byte>(decryptArray, (s => Convert.ToByte(byte.Parse(s, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture))));

                    byte[] bytes = rsa.Decrypt(decryptByteArray, true);

                    result = System.Text.UTF8Encoding.UTF8.GetString(bytes);
                }
            }
            finally
            {
                // no need for further processing
            }

            return result;
        }

        /// <summary>
        /// Encrypts (RSA) a string using the supplied key.
        /// </summary>
        /// <param name="value">String to encrypt.</param>
        /// <param name="key">Encryption key.</param>
        /// <returns>A string representing a byte array separated by a minus sign.</returns>
        /// <exception cref="ArgumentNullException">Occurs when value and/or key is null or empty.</exception>
        public static string Encrypt(this string value, string key)
        {
            Contract.Requires<ArgumentException>(!String.IsNullOrWhiteSpace(value));
            Contract.Requires<ArgumentException>(!String.IsNullOrWhiteSpace(key));

            System.Security.Cryptography.CspParameters cspp = new System.Security.Cryptography.CspParameters();
            cspp.KeyContainerName = key;

            using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(cspp))
            {
                rsa.PersistKeyInCsp = true;

                byte[] bytes = rsa.Encrypt(System.Text.UTF8Encoding.UTF8.GetBytes(value), true);

                return BitConverter.ToString(bytes);
            }
        }

        /// <summary>
        /// Returns the MD5 Hash for the given string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string MD5(this string value)
        {
            Contract.Requires<ArgumentNullException>(value != null, "value");

            byte[] bytes = Encoding.UTF8.GetBytes(value);
            StringBuilder builder = new StringBuilder();

            using (System.Security.Cryptography.MD5CryptoServiceProvider provider = new System.Security.Cryptography.MD5CryptoServiceProvider())
            {
                bytes = provider.ComputeHash(bytes);
            }

            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2").ToLower());
            }

            return builder.ToString();
        }
    }
}
