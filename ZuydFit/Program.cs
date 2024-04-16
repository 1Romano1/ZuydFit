using System;
using System.Linq;
using ZuydFit;
using ZuydFit.ZuydFit;

class Program
{
    static void Main(string[] args)
    {
        
        Planning planning = new Planning(DateTime.Now, "Joggen");

        // Voorbeeld van het aanroepen van een methode
        planning.AddPlanning();
        planning.ReadPlanning();
        planning.UpdatePlanning();
        planning.DeletePlanning();


    }
}

