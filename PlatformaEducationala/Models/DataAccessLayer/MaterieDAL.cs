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
    public class MaterieDAL
    {
        public ObservableCollection<Materie> ObtineToateMateriile()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineToateMateriile", con);
                ObservableCollection<Materie> rezultat = new ObservableCollection<Materie>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie materie = new Materie();
                    materie.IdMaterie = (int)(reader[0]);
                    materie.Nume = reader[1].ToString();
                    materie.IdProfesor = (int)(reader[2]);
                    materie.AreTeza = Convert.ToBoolean(reader[3]);
                    materie.AnStudiu = (int)(reader[4]);
                    rezultat.Add(materie);
                }
                reader.Close();
                return rezultat;
            }
        }

        public void InserareMaterie(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareMaterie", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
                SqlCommand cmd = new SqlCommand("StergereMaterie", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
                SqlCommand cmd = new SqlCommand("ActualizareMaterie", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
