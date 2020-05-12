using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaglavnieLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string stroka;
            stroka = Convert.ToString(Console.ReadLine());
            int n = stroka.Length, i;
            for (i = 0; i < n; i++)
                if (char.IsUpper(stroka[i]))
                    if (stroka[i] > 'A' && stroka[i] < 'Z') continue;
                    else Console.Write(stroka[i]);
            Console.ReadKey();
        }
    }
}