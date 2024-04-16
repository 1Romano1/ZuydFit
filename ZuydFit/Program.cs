// See https://aka.ms/new-console-template for more information
using System.Xml;
using System.Xml.Linq;
using ZuydFit;

public class Program
{
    static void Main(string[] args)
    {
        /*
        Console.WriteLine("wat is de titel van je advies");
        string title = Console.ReadLine();

        Console.WriteLine("Wat is het advies dat je wilt geven?");
        string description = Console.ReadLine();

        Advice advice2 = new Advice(title, description);
        advice2.AddAdvice();
        
        Advice advice1 = new Advice();
        List<Advice> advices = advice1.ReadAdvice();
        foreach (var adv in advices)
        {
            Console.WriteLine(adv.Title);
        }

        Console.WriteLine("Welk advies wil je verwijderen voer de Id in");
        string Title = Console.ReadLine();

        Advice advice = new Advice();
        advice.GetAdviceByTitle(title);
        advice.DeleteAdvice();

        
        Advice advice3 = new Advice();
        List<Advice> Advices = advice3.ReadAdvice();
        foreach (var ad in Advices)
        {
            Console.WriteLine(ad.Title);
        }
        Console.WriteLine("Welk advies wilt u aanpassen? Type de titel");
        string title1 = Console.ReadLine();

        Console.WriteLine(title1);
        advice3.GetAdviceByTitle(title1);

        Console.WriteLine("wat is de titel van je advies");
        advice3.Title = Console.ReadLine();

        Console.WriteLine("Wat is het advies dat je wilt geven?");
        advice3.Description = Console.ReadLine();

        advice3.UpdateAdvice();
        
        Console.WriteLine("Schrijf de titel van je Goal");
        string name = Console.ReadLine();

        Console.WriteLine("Geef een beschrijving van je Goal");
        string description1 = Console.ReadLine();

        Console.WriteLine("Hoeveel progressie heb je gemaakt aan deze goal?");
        string progression = Console.ReadLine();

        Goal goal1 = new Goal(name, description1, progression);
        goal1.AddGoal();*/

        Goal goal1 = new Goal();
        List<Goal> goals = goal1.GetGoals();
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.Name);
            Console.WriteLine(goal.Description);
        }
    }
}
