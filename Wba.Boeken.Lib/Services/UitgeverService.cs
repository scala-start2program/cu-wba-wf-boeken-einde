using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wba.Boeken.Lib.Entities;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Wba.Boeken.Lib.Services
{
    public class UitgeverService
    {
        public static List<Uitgever> GetUitgevers()
        {
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();
                    List<Uitgever> uitgevers = connection.GetAll<Uitgever>().ToList();
                    uitgevers = uitgevers.OrderBy(p => p.Naam).ToList();
                    return uitgevers;
                }
                catch (Exception fout)
                {
                    return null;
                }
            }
        }
        public static Uitgever FindUitgever(string id)
        {
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();
                    Uitgever uitgever = connection.Get<Uitgever>(id);
                    connection.Close();
                    return uitgever;
                }
                catch
                {
                    return null;
                }
            }
        }
        public static bool Add(Uitgever uitgever)
        {
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();
                    connection.Insert(uitgever);
                    connection.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool Update(Uitgever uitgever)
        {
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();
                    connection.Update(uitgever);
                    connection.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool Delete(Uitgever uitgever)
        {
            if (BoekService.IsUitgeverInGebruik(uitgever.Id))
            {
                return false;
            }
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();
                    connection.Delete(uitgever);
                    connection.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
