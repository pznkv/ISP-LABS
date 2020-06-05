using System;
namespace Lab5
{
    class Human
    {
        protected string name;
        protected int age;
        protected string country;
        public static int ID;

        public Human() : this("Неизвестно")
        {
        }
        public Human(string nameValue) : this(nameValue, 0, "Неизвестно")
        {
        }
        public Human(string nameValue, string countryValue) : this(nameValue, 0, countryValue)
        {
        }
        public Human(string nameValue, int ageValue) : this(nameValue, ageValue, "Неизвестно")
        {
        }
        public Human(int ageValue, string countryValue) : this("Неизвестно", ageValue, countryValue)
        {
        }
        public Human(string nameValue, int ageValue, string countryValue)
        {
            name = nameValue;
            age = ageValue;
            country = countryValue;
        }


        public void setValue(string nameValue, string countryValue)
        {
            name = nameValue;
            country = countryValue;
        }
        public string getName()
        {
            return name;
        }
        public string getCountry()
        {
            return country;
        }

        public void setValue(int ageValue)
        {
            age = ageValue;
        }
        public int getAge()
        {
            return age;
        }

        public virtual void getInfo()
        {
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Страна: {country}");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine("");
        }


        public int generateID()
        {
            Random rnd = new Random();
            return ID = rnd.Next(100000, 999999);
        }

    }
}
