using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Elm St", "Shelbyville", "IL", "USA");
        Address address3 = new Address("789 Oak St", "Capital City", "IL", "USA");

        Lecture lecture = new Lecture("Advanced C#", "Deep dive into C#", "01/08/2024", "10:00 AM", address1, "John Doe", 100);
        Reception reception = new Reception("Networking Event", "Meet and greet", "02/08/2024", "6:00 PM", address2, "rsvp@event.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Community Picnic", "Outdoor fun for all", "03/08/2024", "12:00 PM", address3, "Sunny");

        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

        foreach (var ev in events)
        {
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
        }
    }
}
