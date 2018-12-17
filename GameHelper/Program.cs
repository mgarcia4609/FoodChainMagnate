using System;
using GameHelper.Models;

namespace GameHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerModel player = new PlayerModel();

            player.HireEmployee("Kitchen Trainee");
            player.HireEmployee("Marketing Trainee");
            player.HireEmployee("Management Trainee");

            player.PaySalaries();

            Console.ReadLine();
        }
    }
}
