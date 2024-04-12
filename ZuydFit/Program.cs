// See https://aka.ms/new-console-template for more information
using System.Xml;
using System.Xml.Linq;
using ZuydFit;

public class Program
{
    public void Main(string[] args)
    {
        Console.WriteLine("wat is de titel van je advies");
        string Title = Console.ReadLine();

        Console.WriteLine("Wat is het advies dat je wilt geven?");
        string Description = Console.ReadLine();

        Advice advice = new Advice(Title, Description);
        advice.AddAdvice(advice);

        Console.WriteLine("Welk advies wil je verwijderen voer de titel in");

        
    }
}
