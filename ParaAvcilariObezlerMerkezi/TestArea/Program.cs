using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess;
using System.IO;

namespace TestArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "1234";
            DatabaseAccess.Database database = new Database();
            string haslanmis = database.CreatePWHash(password);

            using (StreamWriter writer = new StreamWriter(@"C:\Users\Misaki\Documents\ornekhash.txt"))
            {
                writer.WriteLine(haslanmis);
            }

        }
    }
}
