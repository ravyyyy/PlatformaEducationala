using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformaEducationala.Models.DataAccessLayer
{
    public class MedieDAL
    {
        public ObservableCollection<Medie> ObtineToateMediile()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineToateMediile", con);
                ObservableCollection<Medie> rezultat = new ObservableCollection<Medie>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Medie medie = new Medie();
                    medie.IdMedie = reader.GetInt32(0);
                    medie.IdElev = reader.GetInt32(1);
                    medie.IdMaterie = reader.GetInt32(2);
                    medie.Nota = reader.GetDecimal(3);
                    rezultat.Add(medie);
                }
                reader.Close();
                return rezultat;
            }
        }

        public void InserareMedie(Medie medie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareMedie", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruIdElev = new SqlParameter("@id_elev", medie.IdElev);
                SqlParameter parametruIdMaterie = new SqlParameter("@id_materie", medie.IdMaterie);
                SqlParameter parametruNota = new SqlParameter("@nota", medie.Nota);
                SqlParameter parametruMedieId = new SqlParameter("@medie_id", System.Data.SqlDbType.Int);
                parametruMedieId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruIdElev);
                cmd.Parameters.Add(parametruIdMaterie);
                cmd.Parameters.Add(parametruNota);
                cmd.Parameters.Add(parametruMedieId);
                con.Open();
                cmd.ExecuteNonQuery();
                medie.IdMedie = parametruMedieId.Value as int?;
            }
        }

        public void StergereMedie(Medie medie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereMedie", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruIdMedie = new SqlParameter("@medie_id", medie.IdMedie);
                cmd.Parameters.Add(parametruIdMedie);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareMedie(Medie medie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareMedie", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruMedieId = new SqlParameter("@medie_id", medie.IdMedie);
                SqlParameter parametruIdElev = new SqlParameter("@id_elev", medie.IdElev);
                SqlParameter parametruIdMaterie = new SqlParameter("@id_materie", medie.IdMaterie);
                SqlParameter parametruNota = new SqlParameter("@nota", medie.Nota);
                cmd.Parameters.Add(parametruMedieId);
                cmd.Parameters.Add(parametruIdElev);
                cmd.Parameters.Add(parametruIdMaterie);
                cmd.Parameters.Add(parametruNota);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Medie> ObtineToateMediileDupaElev(Elev elev)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Medie> rezultat = new ObservableCollection<Medie>();
                SqlCommand cmd = new SqlCommand("ObtineToateMediileDupaElev", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruMaterieId = new SqlParameter("@elev_id", elev.IdElev);
                cmd.Parameters.Add(parametruMaterieId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Medie()
                    {
                        IdMedie = reader.GetInt32(0),
                        IdElev = reader.GetInt32(1),
                        IdMaterie = reader.GetInt32(2),
                        Nota = reader.GetDecimal(3)
                    });
                }
                return rezultat;
            }    
        }

        public ObservableCollection<Medie> ObtineToateMediileDupaMaterie(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Medie> rezultat = new ObservableCollection<Medie>();
                SqlCommand cmd = new SqlCommand("ObtineToateMediileDupaMaterie", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruMaterieId = new SqlParameter("@materie_id", materie.IdMaterie);
                cmd.Parameters.Add(parametruMaterieId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Medie()
                    {
                        IdMedie = reader.GetInt32(0),
                        IdElev = reader.GetInt32(1),
                        IdMaterie = reader.GetInt32(2),
                        Nota = reader.GetDecimal(3)
                    });
                }
                return rezultat;
            }
        }
    }
}
