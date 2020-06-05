using System;
namespace Lab5
{
    class Spec : Student
    {
        public struct specialty {
           public string specName;
           public string mainSub;

        }

        public specialty specStruct;

        public Spec() : this("Неизвестно",0, "Неизвестно", 0, "Неизвестно", "Неизвестно")
        {
            ID = 0;
        }
        public Spec(string nameValue, int ageValue, string countryValue, courseNum courseValue, string specValue, string subjectValue)
        {
            name = nameValue;
            age = ageValue;
            country = countryValue;
            ID = generateID();
            course = (int)courseValue;
            specStruct.specName = specValue;
            specStruct.mainSub = subjectValue;
        }

        public override void getInfo()
        {
            base.getInfo();
            Console.WriteLine($"Специальность: {specStruct.specName}");
            Console.WriteLine($"Профильный предмет: {specStruct.mainSub}");
        }
    }
}
