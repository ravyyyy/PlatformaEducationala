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
    public class AbsentaDAL
    {
        public ObservableCollection<Absenta> ObtineToateAbsentele()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineToateAbsentele", con);
                ObservableCollection<Absenta> rezultat = new ObservableCollection<Absenta>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Absenta absenta = new Absenta();
                    absenta.IdAbsenta = reader.GetInt32(0);
                    absenta.IdMaterie = reader.GetInt32(1);
                    absenta.IdElev = reader.GetInt32(2);
                    absenta.DataAbsenta = reader.GetDateTime(3);
                    absenta.EsteMotivata = reader.GetBoolean(4);
                    rezultat.Add(absenta);
                }
                reader.Close();
                return rezultat;
            }
        }

        public void InserareAbsenta(Absenta absenta)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareAbsenta", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruIdMaterie = new SqlParameter("@id_materie", absenta.IdMaterie);
                SqlParameter parametruIdElev = new SqlParameter("@id_elev", absenta.IdElev);
                SqlParameter parametruDataAbsenta = new SqlParameter("@data_absenta", absenta.DataAbsenta);
                SqlParameter parametruEsteMotivata = new SqlParameter("@este_motiva", absenta.EsteMotivata);
                SqlParameter parametruAbsentaId = new SqlParameter("@absenta_id", System.Data.SqlDbType.Int);
                parametruAbsentaId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruIdMaterie);
                cmd.Parameters.Add(parametruIdElev);
                cmd.Parameters.Add(parametruDataAbsenta);
                cmd.Parameters.Add(parametruEsteMotivata);
                cmd.Parameters.Add(parametruAbsentaId);
                con.Open();
                cmd.ExecuteNonQuery();
                absenta.IdAbsenta = parametruAbsentaId.Value as int?;
            }
        }

        public void ActualizareAbsenta(Absenta absenta)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareAbsenta", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruAbsentaId = new SqlParameter("@absenta_id", absenta.IdAbsenta);
                SqlParameter parametruIdMaterie = new SqlParameter("@id_materie", absenta.IdMaterie);
                SqlParameter parametruIdElev = new SqlParameter("@id_elev", absenta.IdElev);
                SqlParameter parametruDataAbsenta = new SqlParameter("@data_absenta", Convert.ToDateTime(absenta.DataAbsenta));
                SqlParameter parametruEsteMotivata = new SqlParameter("@este_motivata", absenta.EsteMotivata);
                cmd.Parameters.Add(parametruAbsentaId);
                cmd.Parameters.Add(parametruIdMaterie);
                cmd.Parameters.Add(parametruIdElev);
                cmd.Parameters.Add(parametruDataAbsenta);
                cmd.Parameters.Add(parametruEsteMotivata);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void StergereAbsenta(Absenta absenta)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereAbsenta", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruAbsentaId = new SqlParameter("@absenta_id", absenta.IdAbsenta);
                cmd.Parameters.Add(parametruAbsentaId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Absenta> ObtineToateAbsenteleDupaElev(Elev elev)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Absenta> rezultat = new ObservableCollection<Absenta>();
                SqlCommand cmd = new SqlCommand("ObtineToateAbsenteleDupaElev", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruElevId = new SqlParameter("@elev_id", elev.IdElev);
                cmd.Parameters.Add(parametruElevId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Absenta()
                    {
                        IdAbsenta = reader.GetInt32(0),
                        IdMaterie = reader.GetInt32(1),
                        IdElev = reader.GetInt32(2),
                        DataAbsenta = reader.GetDateTime(3),
                        EsteMotivata = reader.GetBoolean(4)
                    });
                }
                return rezultat;
            }
        }

        public ObservableCollection<Absenta> ObtineToateAbsenteleDupaMaterie(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Absenta> rezultat = new ObservableCollection<Absenta>();
                SqlCommand cmd = new SqlCommand("ObtineToateAbsenteleDupaMaterie", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruMaterieId = new SqlParameter("@materie_id", materie.IdMaterie);
                cmd.Parameters.Add(parametruMaterieId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Absenta()
                    {
                        IdAbsenta = reader.GetInt32(0),
                        IdMaterie = reader.GetInt32(1),
                        IdElev = reader.GetInt32(2),
                        DataAbsenta = reader.GetDateTime(3),
                        EsteMotivata = reader.GetBoolean(4)
                    });
                }
                return rezultat;
            }
        }
    }
}
