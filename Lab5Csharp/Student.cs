using System;
namespace Lab5
{
    enum courseNum
    {
        First = 1,
        Second,
        Third,
        Fourth
    }

    class Student : Human
    {
        public int course;

        public Student() : this("Неизвестно", 0, "Неизвестно", 0)
        {          
        }
        public Student(string nameValue, int ageValue, string countryValue, courseNum courseValue)
        {
            name = nameValue;
            age = ageValue;
            country = countryValue;
            ID = generateID();
            course = (int)courseValue;
        }

        public override void getInfo()
        {
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Страна: {country}");
            Console.WriteLine($"Курс: {course}");
            Console.WriteLine($"ID: {ID}");
        }


    }
}
