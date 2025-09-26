using DependencyInjectionDemo.Interfaces;

namespace DependencyInjectionDemo.Services
{
    // Classroom, IOgretmen'e bağımlı. Bağımlılık dışarıdan veriliyor (Constructor Injection).
    public class ClassRoom
    {
        private readonly IOgretmen _teacher;

        // Constructor Injection
        public ClassRoom(IOgretmen teacher)
        {
            _teacher = teacher;
        }

        // Örneği çalışma zamanında doldurmak için yardımcı metod
        public void SetTeacherName(string firstName, string lastName)
        {
            _teacher.FirstName = firstName;
            _teacher.LastName = lastName;
        }

        // Teacher içindeki GetInfo'yu çağırır
        public string GetTeacherInfo() => _teacher.GetInfo();
    }
}
