using DependencyInjectionDemo.Interfaces;

namespace DependencyInjectionDemo.Models
{
    // Concrete implementation
    public class Teacher : IOgretmen
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Parametresiz ctor: DI ile oluştur, sonra değer ata
        public Teacher() { }

        // İstersen hızlı kurulum için parametreli ctor da var
        public Teacher(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string GetInfo()
        {
            return $"Öğretmen: {FirstName} {LastName}";
        }
    }
}
