using System;
using System.Collections.Generic;

class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_state}\n{_country}";
    }
}

class Event
{
    protected string _title;
    protected string _description;
    protected string _date;
    protected string _time;
    protected Address _address;

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Event Type: {this.GetType().Name}\nTitle: {_title}\nDate: {_date}";
    }
}

class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nEvent Type: Lecture\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }
}

class Reception : Event
{
    private string _rsvp;

    public Reception(string title, string description, string date, string time, Address address, string rsvp)
        : base(title, description, date, time, address)
    {
        _rsvp = rsvp;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nEvent Type: Reception\nRSVP: {_rsvp}";
    }
}

class OutdoorGathering : Event
{
    private string _weatherForecast;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        _weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nEvent Type: Outdoor Gathering\nWeather Forecast: {_weatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "NY", "USA");
        Lecture lecture = new Lecture("C# Programming", "Learn advanced C# programming", "2024-07-25", "10:00 AM", address1, "John Doe", 100);

        Address address2 = new Address("456 Elm St", "Othertown", "ON", "Canada");
        Reception reception = new Reception("Networking Event", "Meet industry professionals", "2024-07-26", "6:00 PM", address2, "rsvp@example.com");

        Address address3 = new Address("789 Pine St", "Elsewhere", "CA", "USA");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Community Picnic", "Enjoy food and games", "2024-07-27", "12:00 PM", address3, "Sunny and warm");

        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

        foreach (var eventItem in events)
        {
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(eventItem.GetShortDescription());
            Console.WriteLine("\n----------------------\n");
        }
    }
}