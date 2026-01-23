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
            string password = "3283esvakturpremiumüyeliksatınaldım.AliSelim Çok İyi Babaaaaaa. Orgeneral 12312371246123952639567239526452645924892342346812346128461";
            DatabaseAccess.Database database = new Database();
            string haslanmis = database.CreatePWHash(password);

            using (StreamWriter writer = new StreamWriter(@"C:\Users\misaki\Documents\ornekhash.txt"))
            {
                writer.WriteLine(haslanmis);
            }

        }
    }
}
