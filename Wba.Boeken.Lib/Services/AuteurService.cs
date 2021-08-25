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
    public class AuteurService
    {
        public static List<Auteur> GetAuteurs()
        {
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();
                    List<Auteur> auteurs = connection.GetAll<Auteur>().ToList();
                    auteurs = auteurs.OrderBy(p => p.Naam).ToList();
                    return auteurs;
                }
                catch (Exception fout)
                {
                    return null;
                }
            }
        }
        public static Auteur FindAuteur(string id)
        {
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();
                    Auteur auteur = connection.Get<Auteur>(id);
                    connection.Close();
                    return auteur;
                }
                catch
                {
                    return null;
                }
            }
        }
        public static bool Add(Auteur auteur)
        {
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();
                    connection.Insert(auteur);
                    connection.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool Update(Auteur auteur)
        {
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();
                    connection.Update(auteur);
                    connection.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool Delete(Auteur auteur)
        {
            if(BoekService.IsAuteurInGebruik(auteur.Id))
            {
                return false;
            }
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();


                    connection.Delete(auteur);
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
