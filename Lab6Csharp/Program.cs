using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Spec[] array = new Spec[5];
            array[0] = new Spec("Тимити", 18, "Беларусь", (courseNum)1, "ИиТП", "английский, французский");
            array[1] = new Spec("Саша", 18, "Беларусь", (courseNum)1, "КИС", "математика, немецкий");
            array[2] = new Spec("Ваня", 18, "Беларусь", (courseNum)1, "ИиТП", "английский, физкультура");
            array[3] = new Spec("Алекс", 18, "Беларусь", (courseNum)3, "ВМСиС", "информатика, математика");
            array[4] = new Spec("Максим", 28, "Беларусь", (courseNum)1, "ИиТП", "математика, информатика");

            Array.Sort(array);

            for (int i = 0; i < array.Length(); i++)
            {
                array[i].getInfo();
            }
        }
    }
}
