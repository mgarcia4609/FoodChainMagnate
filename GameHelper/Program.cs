﻿using System;
using GameHelper.Models;
using GameHelper.GameLogic;

namespace GameHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerModel player = new PlayerModel();
            Globals globals = new Globals();

            player.HireEmployee("Kitchen Trainee");
            player.HireEmployee("Marketing Trainee");
            player.HireEmployee("Management Trainee");
            player.HireEmployee("Kitchen Trainee");
            player.HireEmployee("Marketing Trainee");
            player.HireEmployee("Management Trainee");

            player.FireEmployees(player.GetNumberToFire());

            Console.ReadLine();
        }
    }
}
