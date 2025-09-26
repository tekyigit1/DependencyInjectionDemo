using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DependencyInjectionDemo.Interfaces;
using DependencyInjectionDemo.Models;
using DependencyInjectionDemo.Services;

namespace DependencyInjectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Generic Host ile DI container oluştur
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    // Interface -> Concrete mapping
                    services.AddTransient<IOgretmen, Teacher>();

                    // ClassRoom bağımlılıklarıyla birlikte çözülebilsin
                    services.AddTransient<ClassRoom>();

                    // Örnek: Teacher kurulumunu parametreli vermek istersen:
                    // services.AddTransient<IOgretmen>(sp => new Teacher("Ahmet", "Yılmaz"));
                })
                .Build();

            // DI container'dan ClassRoom al
            var classRoom = host.Services.GetRequiredService<ClassRoom>();

            // Uygulama mantığı
            classRoom.SetTeacherName("Ahmet", "Yılmaz"); // İstersen kaldırıp üstte factory kullan
            Console.WriteLine(classRoom.GetTeacherInfo());
        }
    }
}
