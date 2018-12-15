using System;
using GameHelper.Models;

namespace GameHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start...");
            Console.ReadLine(); 
            PlayerModel player = new PlayerModel();
            player.HireEmployee("Kitchen Trainee");
            player.HireEmployee("Marketing Trainee");
            player.HireEmployee("Management Trainee");

            Console.ReadLine();
            player.PaySalaries();

            Console.ReadLine();
        }
    }
}
