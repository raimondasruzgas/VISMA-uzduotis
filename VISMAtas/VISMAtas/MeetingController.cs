using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISMAtas
{
    public static class MeetingController
    {
        public static void Login()
        {
            Console.Clear();
            bool exit = false;
            while (!exit)
            {
                string username = UI_Helper.AskForString("Prasome ivesti vartotojo varda : ");
                string password = UI_Helper.AskForString("Prasome ivesti slaptazodi : ");



                var user = DB.Users.Where(x => x.Name == username).FirstOrDefault();



                if (user == null)
                {
                    Console.Clear();
                    Console.WriteLine("Tokio vartotojo nera.");
                    continue;
                }



                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    Console.Clear();
                    DB.CurrentUser = user;
                    exit = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Neteisingas slaptazodis.");
                    continue;
                }
            }
        }



        public static void Register()
        {

            Console.Clear();

            bool exit = false;
            while (!exit)
            {
                string username = UI_Helper.AskForString("Prasome ivesti vartotojo varda : ");
                string password = UI_Helper.AskForString("Prasome ivesti slaptazodi : ");



                var user = DB.Users.Where(x => x.Name == username).FirstOrDefault();



                if (user != null)
                {
                    Console.Clear();
                    Console.WriteLine("Tokio vartotojas jau registruotas.");
                    continue;
                }



                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);



                var newUser = new User() { Name = username, Password = hashedPassword };



                DB.Users.Add(newUser);
                DB.SaveUsers();
                DB.CurrentUser = newUser;
                Console.Clear();
                exit = true;
            }
        }
    }
}
