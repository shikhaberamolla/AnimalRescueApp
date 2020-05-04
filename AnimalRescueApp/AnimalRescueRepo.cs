using System;
using System.Collections.Generic;
using System.Linq;
using AnimalRescueApp.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescueApp
{
    public class AnimalRescueRepo
    {
        AnimalRescueDBContext context;

        public AnimalRescueRepo()
        {
            context = new AnimalRescueDBContext();
        }

        public List<UserDetails> GetAllUsers()
        {
            List<UserDetails> users = new List<UserDetails>();
            try
            {
                users = context.UserDetails.ToList();
                return users;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public int RegisterUser(UserDetails user)
        {
            var userName = new SqlParameter( "@UserName",user.UserName);
            var displayName = new SqlParameter("@DisplayName", user.DisplayName);
            var contact = new SqlParameter("@Contact", user.Contact);
            var address = new SqlParameter("@Address", user.Address);
            var password = new SqlParameter("@Password", user.Password);
            try
            {
                int res = context.Database.ExecuteSqlCommand("Exec usp_RegisterUser @UserName, @DisplayName, @Contact, @Address, @Password", userName, displayName, contact, address, password);
                return res;
            }
            catch (Exception)
            {
                return -99;
            }
            
        }

        public string ValidateUser(string username, string password)
        {
            try
            {
                var res = from usr in context.UserDetails
                          where usr.UserName == username && usr.Password == password
                          select usr;
                if (res == null)
                {
                    return "Invalid Credentials";
                }
                return res.FirstOrDefault<UserDetails>().DisplayName;
            }
            catch (Exception)
            {
                return "Invalid Credentials";
            }
           
        }

        public List<Report> GetAllReports()
        {
            List<Report> reports = new List<Report>();
            try
            {
                reports = context.Report.ToList();
                return reports;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public bool AddReport(Report report)
        {
            try
            {
                context.Add<Report>(report);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ForAdoption> GetAllForAdoption()
        {
            List<ForAdoption> forAdoption = new List<ForAdoption>();
            try
            {
                forAdoption = context.ForAdoptions.ToList();
                return forAdoption;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
