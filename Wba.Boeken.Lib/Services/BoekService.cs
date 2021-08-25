using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wba.Boeken.Lib.Entities;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Dapper;

namespace Wba.Boeken.Lib.Services
{
    public class BoekService
    {
        public static List<Boek> GetBoeken(Auteur auteur = null, Uitgever uitgever = null)
        {
            List<Boek> boeken = new List<Boek>();
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                connection.Open();
                if (auteur == null && uitgever == null)
                    boeken = connection.Query<Boek>("Select * from boeken order by titel").ToList();
                else if (auteur != null && uitgever == null)
                    boeken = connection.Query<Boek>("Select * from boeken where AuteurId = @auteurId order by titel", new { auteurId = auteur.Id }).ToList();
                else if (auteur == null && uitgever != null)
                    boeken = connection.Query<Boek>("Select * from boeken where UitgeverId = @uitgeverId  order by titel", new { uitgeverId = uitgever.Id }).ToList();
                else
                    boeken = connection.Query<Boek>("Select * from boeken where AuteurId = @auteurId and UitgeverId = @uitgeverId  order by titel", new { auteurId = auteur.Id, uitgeverId = uitgever.Id }).ToList();
                connection.Close();
            }
            return boeken;
        }


        public static Boek FindBoek(string id)
        {
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();
                    Boek boek = connection.Get<Boek>(id);
                    connection.Close();
                    return boek;
                }
                catch (Exception error)
                {
                    return null;
                }
            }
        }
        public static bool Add(Boek boek)
        {
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();
                    connection.Insert(boek);
                    connection.Close();
                    return true;
                }
                catch(Exception error)
                {
                    return false;
                }
            }
        }
        public static bool Update(Boek boek)
        {
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();
                    connection.Update(boek);
                    connection.Close();
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                }
            }
        }
        public static bool Delete(Boek boek)
        {
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                try
                {
                    connection.Open();
                    connection.Delete(boek);
                    connection.Close();
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                }
            }
        }
        public static bool IsAuteurInGebruik(string auteurId)
        {
            string sql = $"select count(*) from boeken where auteurid = @id";
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                connection.Open();
                int count = connection.ExecuteScalar<int>(sql, new { id = auteurId });
                connection.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }
        }
        public static bool IsUitgeverInGebruik(string uitgeverId)
        {
            string sql = $"select count(*) from boeken where uitgeverid = @id";
            using (SqlConnection connection = new SqlConnection(DBService.GetCS()))
            {
                connection.Open();
                int count = connection.ExecuteScalar<int>(sql,new { id = uitgeverId });
                connection.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }

        }

    }
}
