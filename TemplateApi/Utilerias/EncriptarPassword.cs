using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateApi.Utilerias
{
    public  class EncriptarPassword
    {
        public string Encriptador(string password)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(password);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public string DesEncriptador(string password)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(password);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }


}
