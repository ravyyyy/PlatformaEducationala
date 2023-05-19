using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PlatformaEducationala.Models.DataAccessLayer
{
    public class MaterieDAL
    {
        public ObservableCollection<Materie> ObtineToateMateriile()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineToateMateriile", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                ObservableCollection<Materie> rezultat = new ObservableCollection<Materie>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie materie = new Materie
                    {
                        IdMaterie = (int)(reader[0]),
                        Nume = reader[1].ToString(),
                        IdProfesor = (int)(reader[2]),
                        AreTeza = Convert.ToBoolean(reader[3]),
                        AnStudiu = (int)(reader[4])
                    };
                    rezultat.Add(materie);
                }
                reader.Close();
                return rezultat;
            }
        }

        public ObservableCollection<Materie> ObtineToateMateriileDupaProfesor(Profesor profesor)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Materie> rezultat = new ObservableCollection<Materie>();
                SqlCommand cmd = new SqlCommand("ObtineToateMateriileDupaProfesor", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruProfesorId = new SqlParameter("@profesor_id", profesor.IdProfesor);
                cmd.Parameters.Add(parametruProfesorId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    rezultat.Add(new Materie()
                    {
                        IdMaterie = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        IdProfesor = reader.GetInt32(2),
                        AreTeza = reader.GetBoolean(3),
                        AnStudiu = reader.GetInt32(4)
                    });
                }
                return rezultat;
            }
        }

        public void InserareMaterie(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareMaterie", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruNume = new SqlParameter("@nume", materie.Nume);
                SqlParameter parametruIdProfesor = new SqlParameter("@id_profesor", materie.IdProfesor);
                SqlParameter parametruAreTeza = new SqlParameter("@are_teza", Convert.ToBoolean(materie.AreTeza));
                SqlParameter parametruAnStudiu = new SqlParameter("@an_studiu", materie.AnStudiu);
                SqlParameter parametruMaterieId = new SqlParameter("@materie_id", System.Data.SqlDbType.Int);
                parametruMaterieId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruNume);
                cmd.Parameters.Add(parametruIdProfesor);
                cmd.Parameters.Add(parametruAreTeza);
                cmd.Parameters.Add(parametruAnStudiu);
                cmd.Parameters.Add(parametruMaterieId);
                con.Open();
                cmd.ExecuteNonQuery();
                materie.IdMaterie = parametruMaterieId.Value as int?;
            }
        }

        public void StergereMaterie(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereMaterie", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruMaterieId = new SqlParameter("@materie_id", materie.IdMaterie);
                cmd.Parameters.Add(parametruMaterieId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareMaterie(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareMaterie", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruMaterieId = new SqlParameter("@materie_id", materie.IdMaterie);
                SqlParameter parametruNume = new SqlParameter("@nume", materie.Nume);
                SqlParameter parametruIdProfesor = new SqlParameter("@id_profesor", materie.IdProfesor);
                SqlParameter parametruAnStudiu = new SqlParameter("@an_studiu", materie.AnStudiu);
                SqlParameter parametruAreTeza = new SqlParameter("@are_teza", materie.AreTeza);
                cmd.Parameters.Add(parametruMaterieId);
                cmd.Parameters.Add(parametruNume);
                cmd.Parameters.Add(parametruIdProfesor);
                cmd.Parameters.Add(parametruAnStudiu);
                cmd.Parameters.Add(parametruAreTeza);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
