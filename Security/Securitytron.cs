using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.Security
{
    public static class Securitytron
    {
        public static string MadeHashCode(string value)
        {
            byte[] src = Encoding.ASCII.GetBytes(value);

            var Hash = new MD5CryptoServiceProvider().ComputeHash(src); 

            return ByteArrayToString(Hash);
        }

        static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
