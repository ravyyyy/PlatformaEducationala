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
    public class ElevDAL
    {
        public ObservableCollection<Elev> ObtineTotiElevii()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineTotiElevii", con);
                ObservableCollection<Elev> rezultat = new ObservableCollection<Elev>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Elev elev = new Elev();
                    elev.IdElev = (int)(reader[0]);
                    elev.Nume = reader[1].ToString();
                    elev.Prenume = reader[2].ToString();
                    elev.DataNastere = reader.GetDateTime(3);
                    elev.Adresa = reader[4].ToString();
                    elev.NumarTelefon = reader[5].ToString();
                    elev.Email = reader[6].ToString();
                    elev.IdClasa = (int)(reader[7]);
                    rezultat.Add(elev);
                }
                reader.Close();
                return rezultat;
            }
        }

        public ObservableCollection<Elev> ObtineTotiEleviiDupaMaterieDupaProfesor(int id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineTotiEleviiDupaMaterieDupaProfesor", con);
                ObservableCollection<Elev> rezultat = new ObservableCollection<Elev>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruProfesorId = new SqlParameter("@profesor_id", id);
                cmd.Parameters.Add(parametruProfesorId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Elev elev = new Elev();
                    elev.IdElev = (int)(reader[0]);
                    elev.Nume = reader[1].ToString();
                    elev.Prenume = reader[2].ToString();
                    elev.DataNastere = reader.GetDateTime(3);
                    elev.Adresa = reader[4].ToString();
                    elev.NumarTelefon = reader[5].ToString();
                    elev.Email = reader[6].ToString();
                    elev.IdClasa = (int)(reader[7]);
                    rezultat.Add(elev);
                }
                reader.Close();
                return rezultat;
            }
        }

        public Elev ObtineElevDupaId(int elevId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                Elev rezultat = new Elev();
                SqlCommand cmd = new SqlCommand("ObtineElevDupaId", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruElevId = new SqlParameter("@elev_id", elevId);
                cmd.Parameters.Add(parametruElevId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.IdElev = (int)reader[0];
                    rezultat.Nume = reader[1].ToString();
                    rezultat.Prenume = reader[2].ToString();    
                    rezultat.DataNastere = (DateTime)reader[3];
                    rezultat.Adresa = reader[4].ToString();
                    rezultat.NumarTelefon = reader[5].ToString();
                    rezultat.Email = reader[6].ToString();
                    rezultat.IdClasa = (int)reader[7];
                }
                return rezultat;
            }
        }

        public ObservableCollection<Elev> ObtineTotiEleviiDupaClasa(Clasa clasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Elev> rezultat = new ObservableCollection<Elev>();
                SqlCommand cmd = new SqlCommand("ObtineTotiEleviiDupaClasa", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruClasaId = new SqlParameter("@clasa_id", clasa.IdClasa);
                cmd.Parameters.Add(parametruClasaId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Elev()
                    {
                        IdElev = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        Prenume = reader.GetString(2),
                        DataNastere = reader.GetDateTime(3),
                        Adresa = reader.GetString(4),
                        NumarTelefon = reader.GetString(5),
                        Email = reader.GetString(6),
                        IdClasa = reader.GetInt32(7)
                    });
                }
                return rezultat;
            }
        }

        public void InserareElev(Elev elev)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareElev", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruNume = new SqlParameter("@nume", elev.Nume);
                SqlParameter parametruPrenume = new SqlParameter("@prenume", elev.Prenume);
                SqlParameter parametruDataNastere = new SqlParameter("@data_nastere", Convert.ToDateTime(elev.DataNastere));
                SqlParameter parametruAdresa = new SqlParameter("@adresa", elev.Adresa);
                SqlParameter parametruNumarTelefon = new SqlParameter("@numar_telefon", elev.NumarTelefon);
                SqlParameter parametruEmail = new SqlParameter("@email", elev.Email);
                SqlParameter parametruIdClasa = new SqlParameter("@id_clasa", elev.IdClasa);
                SqlParameter parametruElevId = new SqlParameter("@elev_id", System.Data.SqlDbType.Int);
                parametruElevId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruNume);
                cmd.Parameters.Add(parametruPrenume);
                cmd.Parameters.Add(parametruDataNastere);
                cmd.Parameters.Add(parametruAdresa);
                cmd.Parameters.Add(parametruNumarTelefon);
                cmd.Parameters.Add(parametruEmail);
                cmd.Parameters.Add(parametruIdClasa);
                cmd.Parameters.Add(parametruElevId);
                con.Open();
                cmd.ExecuteNonQuery();
                elev.IdElev = parametruElevId.Value as int?;
            }
        }

        public void StergereElev(Elev elev)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereElev", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruElevId = new SqlParameter("@elev_id", elev.IdElev);
                cmd.Parameters.Add(parametruElevId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareElev(Elev elev)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareElev", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruElevId = new SqlParameter("@elev_id", elev.IdElev);
                SqlParameter parametruNume = new SqlParameter("@nume", elev.Nume);
                SqlParameter parametruPrenume = new SqlParameter("@prenume", elev.Prenume);
                SqlParameter parametruDataNastere = new SqlParameter("@data_nastere", Convert.ToDateTime(elev.DataNastere));
                SqlParameter parametruAdresa = new SqlParameter("@adresa", elev.Adresa);
                SqlParameter parametruNumarTelefon = new SqlParameter("@numar_telefon", elev.NumarTelefon);
                SqlParameter parametruEmail = new SqlParameter("@email", elev.Email);
                SqlParameter parametruIdClasa = new SqlParameter("@id_clasa", elev.IdClasa);
                cmd.Parameters.Add(parametruElevId);
                cmd.Parameters.Add(parametruNume);
                cmd.Parameters.Add(parametruPrenume);
                cmd.Parameters.Add(parametruDataNastere);
                cmd.Parameters.Add(parametruAdresa);
                cmd.Parameters.Add(parametruNumarTelefon);
                cmd.Parameters.Add(parametruEmail);
                cmd.Parameters.Add(parametruIdClasa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
