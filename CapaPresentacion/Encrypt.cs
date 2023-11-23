using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion
{
    internal class Encrypt
    {
        Usuario U = new Usuario();
        String clavedes;
        public String md5(String source)
        {

            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, source);

                Console.WriteLine("la contra decifrada es " + source + " y la cifrada es: " + hash + ".");
                clavedes = source;


                return hash;
            }



        }
        public string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public bool VerifyPassword(string userInputPassword, string storedHashedPassword)
        {

            {
                string userInputHash = md5(userInputPassword); // Generar el hash de la contraseña ingresada por el usuario

                // Comparar el hash generado con el hash almacenado en la base de datos
                bool passwordsMatch = userInputHash.Equals(storedHashedPassword);

                return passwordsMatch;
            }
        }

        public string Desifrado()
        {
            return clavedes;
        }


    }
}
