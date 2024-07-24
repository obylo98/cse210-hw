using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Event lecture = new Lecture("Tech Talk", "A talk on the latest in tech.", DateTime.Now.AddDays(1), DateTime.Now.AddHours(2), address1, "John Doe", 100);

        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Event reception = new Reception("Networking Event", "An opportunity to meet professionals.", DateTime.Now.AddDays(2), DateTime.Now.AddHours(3), address2, "rsvp@example.com");

        Address address3 = new Address("789 Oak St", "San Francisco", "CA", "USA");
        Event outdoorGathering = new OutdoorGathering("Picnic", "A fun outdoor gathering.", DateTime.Now.AddDays(3), DateTime.Now.AddHours(4), address3, "Sunny");

        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

        foreach (var eventItem in events)
        {
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine(eventItem.GetShortDescription());
            Console.WriteLine();
        }
    }
}
