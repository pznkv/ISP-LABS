using System;

namespace Random_string
{
    class Program
    {
        private static Random random;
        static void Main(string[] args)
        {
            random = new Random((int)DateTime.Now.Ticks);
            string english = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrst" +
                             "uvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcd" +
                             "efghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuv";
            for (int i = 0; i < 30; i++ ){
                int rad = random.Next(0,english.Length);
                Console.Write(english[rad]);
                Console.WriteLine(" Стоит на позиции {0} ", rad);
            }   
            Console.ReadKey();
        }
    }
}