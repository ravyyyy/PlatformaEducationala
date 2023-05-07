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
        public void InserareAbsenta(Absenta absenta)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareAbsenta", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruIdMaterie = new SqlParameter("@id_materie", absenta.IdMaterie);
                SqlParameter parametruIdElev = new SqlParameter("@id_elev", absenta.IdElev);
                SqlParameter parametruDataAbsenta = new SqlParameter("@data_absenta", absenta.DataAbsenta);
                SqlParameter parametruEsteMotivata = new SqlParameter("@este_motivata", absenta.EsteMotivata);
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
                SqlParameter parametruDataAbsenta = new SqlParameter("@data_absenta", absenta.DataAbsenta);
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
    }
}
