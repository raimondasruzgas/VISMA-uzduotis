﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISMAtas
{
    public static class UI_Helper
    {

        public static int AskForSelection(string[] variants, string question)
        {
            Console.Clear();
            bool exit = false;
            int selection = 0;
            while (!exit)
            {
                Console.WriteLine(question);
                for (int i = 0; i < variants.Length; i++)
                {
                    Console.WriteLine("{0} - {1}", i, variants[i]);
                }
                if (!int.TryParse(Console.ReadLine(), out selection) || selection > variants.Length-1 || selection < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Netinkamai ivestas pasirininkimas");
                    continue;
                }
                exit = true; 
            }
            return selection;
        }

        public static string AskForString(string question)
        {
            Console.Clear();
            string rez = " ";
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine(question);
                var input = Console.ReadLine();
                if (input == null)
                {
                    Console.Clear();
                    Console.WriteLine("Netinkamai ivestas pasirininkimas");
                    continue;
                }
                exit = true;
                rez = input;
            }
            
            
            return rez;
        }

        public static int AskForUserId(string queastion)
        {
            Console.Clear();
            var users = DB.Users.Select(x => x.Name).ToArray();
            var selection  = AskForSelection(users, queastion);
            var selecetedUserName = users[selection];
            var userId = DB.Users.Where(x => x.Name == selecetedUserName).Select(x => x.Id).FirstOrDefault();
            return userId;
        }

        public static DateTime AskForDate(string question)
        {
            Console.Clear();
            DateTime rez = DateTime.Now;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine(question);
                var input = Console.ReadLine();
                if (!DateTime.TryParse(input, out rez))
                {
                    Console.Clear();
                    Console.WriteLine("Netinkamai ivesta reiksme");
                    continue;
                }
                exit = true;
                
            }
            return rez;

        }

        


        /*
        public static void UniversalSelectPromp(string[] variants, Action[] actions )
        {
            bool exit = false;
            int selection = 0;

            while (!exit)
            {
                Console.WriteLine("Pasirinkimai :");
                for (int i = 0; i < variants.Length; i++)
                {
                    Console.WriteLine("{0} - {1}", i, variants[i]);
                }
                if (!int.TryParse(Console.ReadLine(), out selection) || selection > variants.Length || selection < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Netinkamai ivestas pasirinkimas.");
                    continue;
                }

                exit = true;
                actions[selection]();
            }
            
        }
        */
    }
}
