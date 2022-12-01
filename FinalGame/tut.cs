using System;

public class tut
{
    public void intro(){
        string Pname;
        System.Console.WriteLine("Please enter your name:");
        Pname = Console.ReadLine();
        System.Console.WriteLine($"Hello {Pname}, You will now be guided through a short tutorial of the game!");
        System.Console.WriteLine("you will start by going down into your mine, press enter to continue");
        Console.ReadLine();
    }
}
