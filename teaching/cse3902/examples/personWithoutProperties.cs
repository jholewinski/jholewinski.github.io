// person.cs
using System;
class Person
{
    public string myName ="N/A";
    public int myAge = 0;

    public override string ToString()
    {
        return "Name = " + myName + ", Age = " + myAge;
    }

    public static void Main()
    {
        Console.WriteLine("Simple Fields");

        // Create a new Person object:
        Person person = new Person();

        // Print out the name and the age associated with the person:
        Console.WriteLine("Person details" + person.myName + " " + person.myAge);

        // Set some values on the person object:
        person.myName = "Joe";
        person.myAge = 99;
        Console.WriteLine("Person details" + person.ToString());

        // Increment the Age property:
        person.myAge += 1;
        Console.WriteLine("Person details" + person.ToString());
    }
}
