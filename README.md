DependencyInjectionDemo

Bu proje, Dependency Injection (DI) kavramını Constructor Injection yöntemiyle basit bir şekilde göstermektedir.

📌 İçerik

IOgretmen → Öğretmenler için temel arayüz.

Teacher → IOgretmen arayüzünü implemente eden öğretmen sınıfı.

ClassRoom → İçinde öğretmen bulunduran sınıf. Öğretmen bağımlılığı constructor injection ile dışarıdan verilir.

Program.cs → Uygulamanın başlangıç noktası. DI Container (Microsoft.Extensions.Hosting) ile sınıflar enjekte edilir.

🚀 Kullanılan Teknolojiler

.NET 8.0

C#

Microsoft.Extensions.Hosting (Dependency Injection için)

🛠️ Kurulum ve Çalıştırma
1. Projeyi oluştur
dotnet new console -n DependencyInjectionDemo
cd DependencyInjectionDemo

2. NuGet paketini ekle
dotnet add package Microsoft.Extensions.Hosting
dotnet restore

3. Projeyi çalıştır
dotnet run

📂 Proje Yapısı
DependencyInjectionDemo/
├─ Program.cs
├─ Interfaces/
│  └─ IOgretmen.cs
├─ Models/
│  └─ Teacher.cs
└─ Services/
   └─ ClassRoom.cs

📖 Kod Açıklaması
IOgretmen.cs
public interface IOgretmen
{
    string FirstName { get; set; }
    string LastName  { get; set; }
    string GetInfo();
}

Teacher.cs
public class Teacher : IOgretmen
{
    public string FirstName { get; set; }
    public string LastName  { get; set; }

    public Teacher() { }

    public Teacher(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName  = lastName;
    }

    public string GetInfo() => $"Öğretmen: {FirstName} {LastName}";
}

ClassRoom.cs
public class ClassRoom
{
    private readonly IOgretmen _teacher;

    public ClassRoom(IOgretmen teacher)
    {
        _teacher = teacher;
    }

    public void SetTeacherName(string firstName, string lastName)
    {
        _teacher.FirstName = firstName;
        _teacher.LastName  = lastName;
    }

    public string GetTeacherInfo() => _teacher.GetInfo();
}

Program.cs
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using DependencyInjectionDemo.Interfaces;
using DependencyInjectionDemo.Models;
using DependencyInjectionDemo.Services;

using var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddTransient<IOgretmen, Teacher>();
        services.AddTransient<ClassRoom>();
    })
    .Build();

var classRoom = host.Services.GetRequiredService<ClassRoom>();
classRoom.SetTeacherName("Ahmet", "Yılmaz");

Console.WriteLine(classRoom.GetTeacherInfo());

🎯 Çalıştırınca Çıktı
Öğretmen: Ahmet Yılmaz
