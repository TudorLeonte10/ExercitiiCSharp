using Ex19.Services;
using System;
using Ex19.Interfaces;
using Ex19.Models;

public class Program
{
    public static void Main(string[] args)
    {
        IUserInterface ui = new ConsoleUserInterface();
        IBookService bookingService = new BookService();
        var manager = new LibraryManager(bookingService, ui);

        manager.Run();
    }
}