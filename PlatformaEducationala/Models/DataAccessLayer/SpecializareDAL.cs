using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PlatformaEducationala.Models.DataAccessLayer
{
    public class SpecializareDAL
    {
        public ObservableCollection<Specializare> ObtineToateSpecializarile()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineToateSpecializarile", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                ObservableCollection<Specializare> rezultat = new ObservableCollection<Specializare>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Specializare specializare = new Specializare();
                    specializare.IdSpecializare = (int)(reader[0]);
                    specializare.Denumire = reader.GetString(1);
                    rezultat.Add(specializare);
                }
                reader.Close();
                return rezultat;
            }
        }

        public void InserareSpecializare(Specializare specializare)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareSpecializare", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruDenumire = new SqlParameter("@denumire", specializare.Denumire);
                SqlParameter parametruIdSpecializare = new SqlParameter("@specializare_id", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(parametruDenumire);
                cmd.Parameters.Add(parametruIdSpecializare);
                con.Open();
                cmd.ExecuteNonQuery();
                specializare.IdSpecializare = parametruIdSpecializare.Value as int?;
            }
        }

        public void StergereSpecializare(Specializare specializare)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereSpecializare", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdSpecializare = new SqlParameter("@specializare_id", specializare.IdSpecializare);
                cmd.Parameters.Add(parametruIdSpecializare);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareSpecializare(Specializare specializare)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareSpecializare", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdSpecializare = new SqlParameter("@specializare_id", specializare.IdSpecializare);
                SqlParameter parametruDenumire = new SqlParameter("@denumire", specializare.Denumire);
                cmd.Parameters.Add(parametruIdSpecializare);
                cmd.Parameters.Add(parametruDenumire);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
