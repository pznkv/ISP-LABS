using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static Random random;

        public static int take_cart()
        {
            int temp, check;
            temp = random.Next(2, 12);
            switch (temp)
            {
                case 2:
                    if ((check = random.Next(0, 2)) == 0) Console.WriteLine("Jack");
                    else Console.WriteLine(temp);
                    break;
                case 3:
                    if ((check = random.Next(0, 2)) == 0) Console.WriteLine("Queen");
                    else Console.WriteLine(temp);
                    break;
                case 4:
                    if ((check = random.Next(0, 2)) == 0) Console.WriteLine("King");
                    else Console.WriteLine(temp);
                    break;
                case 11:
                    Console.WriteLine("ACE");
                    break;
                default:
                    Console.WriteLine(temp);
                    break;
            }
            return temp;
        }


        public static int game_players(int num_pl)
        {
            int sum = 0, choice;
            Console.WriteLine("{0} PLAYER", num_pl);
            Console.Write("Your first cart is ");
            sum += take_cart();
            Console.Write("Your second cart is ");
            sum += take_cart();

            if (sum == 22)
            {
                Console.WriteLine("GOLDEN 21");
                Console.ReadKey(true);
                return 21;
            }
            Console.WriteLine("Your sum is " + sum);
            Console.Write("Do you want to take more carts? 1+ - yes/0 - no \nYou: ");
            choice = Convert.ToInt32(Console.ReadLine());
            while (choice != 0)
            {
                Console.Write("You took ");
                sum += take_cart();
                Console.WriteLine("Your sum is " + sum);
                if (sum > 21)
                {
                    Console.WriteLine("OOOPS. You are loser :(");
                    Console.ReadKey(true);
                    break;
                }
                Console.WriteLine("Do you want to take more carts? 1 - yes/0 - no \nYou: ");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            Console.Clear();
            return sum;
        }


        public static int game_bots()
        {
            int sum = 0, temp;
            bool a = false;
            do
            {
                temp = random.Next(2, 12);
                sum += temp;
                if (sum > 15) a = true;
                else if (sum == 16)
                {
                    int check = random.Next(0, 2);
                    if (check == 0) a = true;
                }
            } while (a != true);
            return sum;
        }


        public static void winners(int[] score, int num_pl, int num_b)
        {
            int flag = 0;
            int num_max = 0;
            int max = score[0];
            for (int i = 0; i < num_pl + num_b; i++)
            {
                if (score[i] == 21)
                {
                    if (i < num_pl) Console.WriteLine("{0} player", i + 1);
                    else Console.WriteLine("{0} bot", i - num_pl + 1);
                    flag++;
                }
                if ((score[i] > max && score[i] < 21) || (max > 21 && score[i] < max))
                {
                    max = score[i];
                    num_max = i;
                }
            }

            if (flag == 0)
            {
                for (int i = 0; i < num_pl + num_b; i++)
                {
                    if (score[i] == max)
                    {
                        if (i < num_pl) Console.WriteLine("{0} player", i + 1);
                        else Console.WriteLine("{0} bot", i - num_pl + 1);
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            random = new Random((int)DateTime.Now.Ticks);

            int num_bots, num_players;
            Console.WriteLine("21");

            Console.Write("NUMBER OF PLAYERS: ");
            num_players = Convert.ToInt32(Console.ReadLine());

            Console.Write("NUMBER OF BOTS: ");
            num_bots = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            int[] score = new int[num_players + num_bots];
            for (int i = 0; i < num_players; i++)
            {
                score[i] = game_players(i + 1);
            }
            for (int i = num_players; i < num_bots + num_players; i++)
            {
                score[i] = game_bots();
            }

            Console.WriteLine("RESULTS");
            for (int i = 0; i < num_players; i++)
            {
                Console.WriteLine("{0} player: {1}", i + 1, score[i]);
            }
            for (int i = num_players; i < num_bots + num_players; i++)
            {
                Console.WriteLine("{0} bot: {1}", i - num_players + 1, score[i]);
            }

            Console.WriteLine("WINNERS");
            winners(score, num_players, num_bots);
            Console.ReadKey(true);
        }

    }

}

