// See https://aka.ms/new-console-template for more information
using System.Xml;
using System.Xml.Linq;
using ZuydFit;

public class Program
{
    static void Main(string[] args)
    {
        /*Console.WriteLine("wat is de titel van je advies");
        string title = Console.ReadLine();

        Console.WriteLine("Wat is het advies dat je wilt geven?");
        string description = Console.ReadLine();

        Advice advice2 = new Advice(Title, Description);
        advice2.AddAdvice(advice);*/

        Advice advice1 = new Advice();
        List<Advice> advices = advice1.ReadAdvice();
        foreach (var adv in advices)
        {
            Console.WriteLine(adv.Title);
        }

        Console.WriteLine("Welk advies wil je verwijderen voer de Id in");
        string title = Console.ReadLine();

        Advice advice = new Advice();
        advice.GetAdviceByTitle(title);
        advice.DeleteAdvice();




    }
}
