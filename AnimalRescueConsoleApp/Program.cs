using AnimalRescueApp;
using AnimalRescueApp.Models;
using System;


namespace AnimalRescueConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalRescueRepo rep = new AnimalRescueRepo();
            var users = rep.GetAllUsers();
            foreach(var item in users)
            {
                Console.WriteLine(item.DisplayName);
            }
            Console.WriteLine(rep.ValidateUser("shikhaberamolla", "abc@123"));

            //rep.ValidateUser()
            //UserDetails user = new UserDetails();
            //user.UserName = "varunkverma";
            //user.DisplayName = "Varun Verma";
            //user.Contact = 7685749786;
            //user.Address = "23 Main, Mysroe";
            //user.Password = "asd#87";

            //int res = rep.RegisterUser(user);
            //Console.WriteLine(res);
        }
    }
}
