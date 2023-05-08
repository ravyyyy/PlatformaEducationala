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
    public class ProfesorDAL
    {
        public ObservableCollection<Profesor> ObtineTotiProfesorii()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineTotiProfesorii", con);
                ObservableCollection<Profesor> rezultat = new ObservableCollection<Profesor>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Profesor profesor = new Profesor();
                    profesor.IdProfesor = (int)(reader[0]);
                    profesor.Nume = reader[1].ToString();
                    profesor.Prenume = reader[2].ToString();
                    profesor.DataNastere = reader.GetDateTime(3);
                    profesor.Adresa = reader[4].ToString();
                    profesor.NumarTelefon = reader[5].ToString();
                    profesor.Email = reader[6].ToString();
                    profesor.EsteDiriginte = Convert.ToBoolean(reader[7].ToString());
                    rezultat.Add(profesor);
                }
                reader.Close();
                return rezultat;
            }
        }

        public Profesor ObtineProfesorDupaId(int idProfesor)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                Profesor profesor = new Profesor();
                SqlCommand cmd = new SqlCommand("ObtineProfesorDupaId", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruProfesorId = new SqlParameter("@profesor_id", idProfesor);
                cmd.Parameters.Add(parametruProfesorId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    profesor.IdProfesor = (int)(reader[0]);
                    profesor.Nume = reader[1].ToString();
                    profesor.Prenume = reader[2].ToString();
                    profesor.DataNastere = reader.GetDateTime(3);
                    profesor.Adresa = reader[4].ToString();
                    profesor.NumarTelefon = reader[5].ToString();
                    profesor.Email = reader[6].ToString();
                    profesor.EsteDiriginte = Convert.ToBoolean(reader[7].ToString());
                }
                return profesor;
            }
        }

        public void InserareProfesor(Profesor profesor)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareProfesor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruNume = new SqlParameter("@nume", profesor.Nume);
                SqlParameter parametruPrenume = new SqlParameter("@prenume", profesor.Prenume);
                SqlParameter parametruDataNastere = new SqlParameter("@data_nastere", Convert.ToDateTime(profesor.DataNastere));
                SqlParameter parametruAdresa = new SqlParameter("@adresa", profesor.Adresa);
                SqlParameter parametruNumarTelefon = new SqlParameter("@numar_telefon", profesor.NumarTelefon);
                SqlParameter parametruEmail = new SqlParameter("@email", profesor.Email);
                SqlParameter parametruEsteDiriginte = new SqlParameter("@este_diriginte", Convert.ToBoolean(profesor.EsteDiriginte));
                SqlParameter parametruProfesorId = new SqlParameter("@profesor_id", System.Data.SqlDbType.Int);
                parametruProfesorId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruNume);
                cmd.Parameters.Add(parametruPrenume);
                cmd.Parameters.Add(parametruDataNastere);
                cmd.Parameters.Add(parametruAdresa);
                cmd.Parameters.Add(parametruNumarTelefon);
                cmd.Parameters.Add(parametruEmail);
                cmd.Parameters.Add(parametruEsteDiriginte);
                cmd.Parameters.Add(parametruProfesorId);
                con.Open();
                cmd.ExecuteNonQuery();
                profesor.IdProfesor = parametruProfesorId.Value as int?;
            }
        }

        public void StergereProfesor(Profesor profesor)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereProfesor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruProfesorId = new SqlParameter("@profesor_id", profesor.IdProfesor);
                cmd.Parameters.Add(parametruProfesorId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        public void ActualizareProfesor(Profesor profesor)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareProfesor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruProfesorId = new SqlParameter("@profesor_id", profesor.IdProfesor);
                SqlParameter parametruNume = new SqlParameter("@nume", profesor.Nume);
                SqlParameter parametruPrenume = new SqlParameter("@prenume", profesor.Prenume);
                SqlParameter parametruDataNastere = new SqlParameter("@data_nastere", profesor.DataNastere);
                SqlParameter parametruAdresa = new SqlParameter("@adresa", profesor.Adresa);
                SqlParameter parametruNumarTelefon = new SqlParameter("@numar_telefon", profesor.NumarTelefon);
                SqlParameter parametruEmail = new SqlParameter("@email", profesor.Email);
                SqlParameter parametruEsteDiriginte = new SqlParameter("@este_diriginte", profesor.EsteDiriginte);
                cmd.Parameters.Add(parametruNume);
                cmd.Parameters.Add(parametruPrenume);
                cmd.Parameters.Add(parametruDataNastere);
                cmd.Parameters.Add(parametruAdresa);
                cmd.Parameters.Add(parametruNumarTelefon);
                cmd.Parameters.Add(parametruEmail);
                cmd.Parameters.Add(parametruEsteDiriginte);
                cmd.Parameters.Add(parametruProfesorId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
