using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PlatformaEducationala.Models.DataAccessLayer
{
    public class NotaDAL
    {
        public ObservableCollection<Nota> ObtineToateNotele()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineToateNotele", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                ObservableCollection<Nota> rezultat = new ObservableCollection<Nota>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Nota nota = new Nota
                    {
                        IdNota = (int)reader[0],
                        IdMaterie = (int)reader[1],
                        Valoare = (int)reader[2],
                        EsteTeza = Convert.ToBoolean(reader[3]),
                        Semestru = (int)reader[4],
                        MedieIncheiata = Convert.ToBoolean(reader[5]),
                        IdElev = (int)reader[6]
                    };
                    rezultat.Add(nota);
                }
                reader.Close();
                return rezultat;
            }
        }

        public ObservableCollection<Nota> ObtineToateNoteleDupaMaterie(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Nota> rezultat = new ObservableCollection<Nota>();
                SqlCommand cmd = new SqlCommand("ObtineToateNoteleDupaMaterie", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruMaterieId = new SqlParameter("@materie_id", materie.IdMaterie);
                cmd.Parameters.Add(parametruMaterieId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Nota()
                    {
                        IdNota = reader.GetInt32(0),
                        IdMaterie = reader.GetInt32(1),
                        Valoare = reader.GetInt32(2),
                        EsteTeza = reader.GetBoolean(3),
                        Semestru = reader.GetInt32(4),
                        MedieIncheiata = reader.GetBoolean(5),
                        IdElev = reader.GetInt32(6)
                    });
                }
                return rezultat;
            }
        }

        public void InserareNota(Nota nota)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareNota", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdMaterie = new SqlParameter("@id_materie", nota.IdMaterie);
                SqlParameter parametruValoare = new SqlParameter("@valoare", nota.Valoare);
                SqlParameter parametruEsteTeza = new SqlParameter("@este_teza", Convert.ToBoolean(nota.EsteTeza));
                SqlParameter parametruSemestru = new SqlParameter("@semestru", nota.Semestru);
                SqlParameter parametruMedieIncheiata = new SqlParameter("@medie_incheiata", Convert.ToBoolean(nota.MedieIncheiata));
                SqlParameter parametruIdElev = new SqlParameter("@id_elev", nota.IdElev);
                SqlParameter parametruNotaId = new SqlParameter("@nota_id", System.Data.SqlDbType.Int);
                parametruNotaId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruIdMaterie);
                cmd.Parameters.Add(parametruValoare);
                cmd.Parameters.Add(parametruEsteTeza);
                cmd.Parameters.Add(parametruSemestru);
                cmd.Parameters.Add(parametruMedieIncheiata);
                cmd.Parameters.Add(parametruIdElev);
                cmd.Parameters.Add(parametruNotaId);
                con.Open();
                cmd.ExecuteNonQuery();
                nota.IdNota = parametruNotaId.Value as int?;
            }
        }

        public void StergereNota(Nota nota)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereNota", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruNotaId = new SqlParameter("@nota_id", nota.IdNota);
                cmd.Parameters.Add(parametruNotaId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareNota(Nota nota)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareNota", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruNotaId = new SqlParameter("@nota_id", nota.IdNota);
                SqlParameter parametruIdMaterie = new SqlParameter("@id_materie", nota.IdMaterie);
                SqlParameter parametruValoare = new SqlParameter("@valoare", nota.Valoare);
                SqlParameter parametruEsteTeza = new SqlParameter("@este_teza", Convert.ToBoolean(nota.EsteTeza));
                SqlParameter parametruSemestru = new SqlParameter("@semestru", nota.Semestru);
                SqlParameter parametruMedieIncheiata = new SqlParameter("@medie_incheiata", Convert.ToBoolean(nota.MedieIncheiata));
                SqlParameter parametruIdElev = new SqlParameter("@id_elev", nota.IdElev);
                cmd.Parameters.Add(parametruNotaId);
                cmd.Parameters.Add(parametruIdMaterie);
                cmd.Parameters.Add(parametruValoare);
                cmd.Parameters.Add(parametruEsteTeza);
                cmd.Parameters.Add(parametruSemestru);
                cmd.Parameters.Add(parametruMedieIncheiata);
                cmd.Parameters.Add(parametruIdElev);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Nota> ObtineToateAbsenteleDupaMaterieDupaProfesor(int profesorId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Nota> rezultat = new ObservableCollection<Nota>();
                SqlCommand cmd = new SqlCommand("ObtineToateNoteleDupaMaterieDupaProfesor", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruProfesorId = new SqlParameter("@profesor_id", profesorId);
                cmd.Parameters.Add(parametruProfesorId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Nota()
                    {
                        IdNota = reader.GetInt32(0),
                        IdMaterie = reader.GetInt32(1),
                        Valoare = reader.GetInt32(2),
                        EsteTeza = reader.GetBoolean(3),
                        Semestru = reader.GetInt32(4),
                        MedieIncheiata = reader.GetBoolean(5),
                        IdElev = reader.GetInt32(6)
                    });
                }
                return rezultat;
            }
        }
    }
}
