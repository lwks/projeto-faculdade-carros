using System;
using System.Text;

namespace Carros.Utils
{
    static class CriptografiaMd5
    {
        public static String CriptografaMd5(String senha)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(senha));

            String SenhaCriptografada = BitConverter.ToString(s).ToLower();

            return SenhaCriptografada;
        }
    }
}