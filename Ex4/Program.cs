using System;

public class Program
{
    static void Main(string[] args)
    {
        string username = "tudy";
        string password = "pass123";
        int tries = 3;

        while (tries > 0)
        {
            Console.WriteLine("Username:");
            string tryUser = Console.ReadLine();
            Console.WriteLine("Password:");
            string tryPass = Console.ReadLine();

            if (tryUser == username && tryPass == password)
            {
                Console.WriteLine("Te-ai logat cu succes");
                break;
            }
            else if (tryUser != username || tryPass != password)
            {
                Console.WriteLine("Ai gresit username sau parola");
                tries--;
            }
        }
        if (tries == 0)
        {
            Console.WriteLine("Nu mai ai incercari");
        }
    }
}