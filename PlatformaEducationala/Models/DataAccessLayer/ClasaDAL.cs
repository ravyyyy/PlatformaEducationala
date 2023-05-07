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
    public class ClasaDAL
    {
        public ObservableCollection<Clasa> ObtineToateClasele()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("ObtineToateClasele", con);
                ObservableCollection<Clasa> rezultat = new ObservableCollection<Clasa>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Clasa clasa = new Clasa();
                    clasa.IdClasa = (int)reader[0];
                    clasa.IdSpecializare = (int)reader[1];
                    clasa.IdDiriginte = (int)reader[2];
                    clasa.AnStudiu = (int)reader[3];
                    clasa.Grupa = reader[4].ToString();
                    rezultat.Add(clasa);
                }
                reader.Close();
                return rezultat;
            }
            finally
            { 
                con.Close(); 
            }
        }

        public void InserareClasa(Clasa clasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareClasa", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruIdSpecializare = new SqlParameter("@id_specializare", clasa.IdSpecializare);
                SqlParameter parametruIdDiriginte = new SqlParameter("@id_diriginte", clasa.IdDiriginte);
                SqlParameter parametruAnStudiu = new SqlParameter("@an_studiu", clasa.AnStudiu);
                SqlParameter parametruGrupa = new SqlParameter("@grupa", clasa.Grupa);
                SqlParameter parametruClasaId = new SqlParameter("@clasa_id", System.Data.SqlDbType.Int);
                cmd.Parameters.Add(parametruIdSpecializare);
                cmd.Parameters.Add(parametruIdDiriginte);
                cmd.Parameters.Add(parametruAnStudiu);
                cmd.Parameters.Add(parametruGrupa);
                cmd.Parameters.Add(parametruClasaId);
                con.Open();
                cmd.ExecuteNonQuery();
                clasa.IdClasa = parametruClasaId.Value as int?;
            }
        }

        public void StergereClasa(Clasa clasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereClasa", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruClasaId = new SqlParameter("@clasa_id", clasa.IdClasa);
                cmd.Parameters.Add(parametruClasaId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareClasa(Clasa clasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareClasa", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruClasaId = new SqlParameter("@clasa_id", clasa.IdClasa);
                SqlParameter parametruIdSpecializare = new SqlParameter("@id_specializare", clasa.IdSpecializare);
                SqlParameter parametruIdDiriginte = new SqlParameter("@id_diriginte", clasa.IdDiriginte);
                SqlParameter parametruAnStudiu = new SqlParameter("@an_studiu", clasa.AnStudiu);
                SqlParameter parametruGrupa = new SqlParameter("@grupa", clasa.Grupa);
                cmd.Parameters.Add(parametruClasaId);
                cmd.Parameters.Add(parametruIdSpecializare);
                cmd.Parameters.Add(parametruIdDiriginte);
                cmd.Parameters.Add(parametruAnStudiu);
                cmd.Parameters.Add(parametruGrupa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Clasa> ObtineToateClaseleDupaSpecializare(Specializare specializare)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Clasa> rezultat = new ObservableCollection<Clasa>();
                SqlCommand cmd = new SqlCommand("ObtineToateClaseleDupaSpecializare", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruIdSpecializare = new SqlParameter("@specializare_id", specializare.IdSpecializare);
                cmd.Parameters.Add(parametruIdSpecializare);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Clasa()
                    {
                        IdClasa = reader.GetInt32(0),
                        IdSpecializare = reader.GetInt32(1),
                        IdDiriginte = reader.GetInt32(2),
                        AnStudiu = reader.GetInt32(3),
                        Grupa = reader[4].ToString()
                    });
                }
                return rezultat;
            }
        }
    }
}
