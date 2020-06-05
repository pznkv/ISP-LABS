using System;
namespace Lab5
{
    class Spec : Student
    {
        public struct Specialty {
           public string specName;
           public string mainSub;

        }

        public Specialty SpecStruct;

        public Spec() : this("Неизвестно",0, "Неизвестно", 0, "Неизвестно", "Неизвестно")
        {
            ID = 0;
        }
        public Spec(string nameValue, int ageValue, string countryValue, CourseNum courseValue, string specValue, string subjectValue)
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
            Console.WriteLine($"Специальность: {SpecStruct.specName}");
            Console.WriteLine($"Профильный предмет: {SpecStruct.mainSub}");
        }
    }
}
