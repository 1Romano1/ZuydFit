using System.Security.Cryptography.X509Certificates;

namespace ZuydFit
{
    public class Program
    {
        static void Main(string[] args)
        {
            LocationMenu();

            static void AskForNewLocation()
            {
                Console.WriteLine("In Welk lokaal heb je de training?");
                string classroom = Console.ReadLine();

                Console.WriteLine("wat is het adres van de locatie?");
                string address = Console.ReadLine();

                Console.WriteLine("wat is de postcode van de locatie?");
                string zipcode = Console.ReadLine();

                Console.WriteLine("in welke stad is de locatie?");
                string city = Console.ReadLine();


                Location location = new Location(classroom, address, zipcode, city);
                location.Add();
            }

            static void AskForListLocation()
            {
                Console.WriteLine("Locaties");
                Location location = new Location();
                List<Location> locations = location.Read();
                foreach (Location loc in locations)
                {
                    Console.WriteLine($"Classroom: {loc.Classroom} \tAddress: {loc.Address} \tZipcode: {loc.Zipcode} \tCity: {loc.City}");
                }
            }

            static void AskForDeleteLocation()
            {
                Console.WriteLine("Voer het ID in van de locatie die u wilt verwijderen?");
                int id;
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    return;
                }
                Location location = new Location();
                location.Delete();
            }

            static void AskForUpdateLocation()
            {
                Console.WriteLine("Voer het Id in die u wilt bijwerken:");
                int id;
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    return;
                }

                Console.WriteLine("Voer het nieuwe klaslokaal in:");
                string classroom = Console.ReadLine();

                Console.WriteLine("Voer het nieuwe adres in:");
                string address = Console.ReadLine();

                Console.WriteLine("Voer de nieuwe postcode in:");
                string zipcode = Console.ReadLine();

                Console.WriteLine("Voer de nieuwe stad in:");
                string city = Console.ReadLine();

                Location location = new Location()
                {
                    Id = id,
                    Classroom = classroom,
                    Address = address,
                    Zipcode = zipcode,
                    City = city
                };
                location.Update();
                Console.WriteLine("De Locatie met id '" + id + "' is succesvol bijgewerkt.");
            }

            static void LocationMenu()
            {
                bool exit = false;
                string userInput;

                while (!exit)
                {
                    Console.WriteLine("Wat wil je gaan doen?");
                    Console.WriteLine("1. Een Locatie toevoegen");
                    Console.WriteLine("2. Locaties bekijken");
                    Console.WriteLine("3. Een Locatie bijwerken");
                    Console.WriteLine("4. Een Locatie verwijderen");
                    Console.WriteLine("5. Terug naar hoofdmenu");

                    userInput = Console.ReadLine();

                    if (userInput == "1")
                        AskForNewLocation();
                    else if (userInput == "2")
                        AskForListLocation();
                    else if (userInput == "3")
                        AskForUpdateLocation();
                    else if (userInput == "4")
                        AskForDeleteLocation();
                    else if (userInput == "5")
                        exit = true;
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                        continue;
                    }

                    // Extra regel om de interface duidelijk te houden na het uitvoeren van een actie
                    Console.WriteLine("Druk op Enter om door te gaan...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}