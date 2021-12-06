﻿using PlayerBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    public class Serialization
    {
        public static readonly string defaultFilePath = Environment.CurrentDirectory + "\\PlayerData.dat";

        /// <summary>
        /// Generates a list of dummy player objects
        /// </summary>
        /// <returns>list of player objects</returns>
        public static List<Player> GenerateTestPlayers()
        {
            List<Player> players = new();
            Player player1 = new("testPlayer", "testClass");
            player1.AddScore(1337);
            players.Add(player1);
            Player player2 = new("testPlayer2", "testClass2");
            player2.AddScore(137);
            players.Add(player2);
            return players;
        }

        public static bool SerializePlayerObjects(string path, List<Player> list)
        {
            try
            {
                using FileStream fs = new(path, FileMode.Create);
                BinaryFormatter formatter = new();
                formatter.Serialize(fs, list);
                fs.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private static void Main()
        {
            //Program 1
            {
                List<Player> playerList = new();
                Console.Write("\nPlease insert player count : ");
                int playerCount = 0;
                try
                {
                    //Initialization
                    playerCount = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < playerCount; i++)
                    {
                        var temp = new Player();
                        Console.Write("Please insert the name for player - " + (i + 1) + "\t: ");
                        temp.Name = Console.ReadLine();
                        Console.Write("Please insert the class for player-" + (i + 1) + "\t: ");
                        temp.SwitchClass(Console.ReadLine());
                        temp.SetScore(new Random().Next(0, 100));
                        Console.WriteLine(temp.Name + " played a non-existent game and gained " + temp.Score + " points!");
                        playerList.Add(temp);
                        Console.WriteLine();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //Serialization
                SerializePlayerObjects(defaultFilePath, playerList);
                Console.WriteLine("Player list has been serialized");
            }
        }
    }
}