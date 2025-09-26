namespace DependencyInjectionDemo.Interfaces
{
    // Base interface
    public interface IOgretmen
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string GetInfo();
    }
}
