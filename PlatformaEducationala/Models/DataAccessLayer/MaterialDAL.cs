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
    public class MaterialDAL
    {
        public ObservableCollection<Material> ObtineToateMaterialele()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineToateMaterialele", con);
                ObservableCollection<Material> rezultat = new ObservableCollection<Material>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Material material = new Material();
                    material.IdMaterial = reader.GetInt32(0);
                    material.IdMaterie = reader.GetInt32(1);
                    material.Fisier = (byte[])reader[2];
                    rezultat.Add(material);
                }
                reader.Close();
                return rezultat;
            }
        }

        public void InserareMaterial(Material material)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareMaterial", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruIdMaterie = new SqlParameter("@id_materie", material.IdMaterie);
                SqlParameter parametruFisier = new SqlParameter("@fisier", material.Fisier);
                SqlParameter parametruMaterialId = new SqlParameter("@material_id", System.Data.SqlDbType.Int);
                parametruMaterialId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruIdMaterie);
                cmd.Parameters.Add(parametruFisier);
                cmd.Parameters.Add(parametruMaterialId);
                con.Open();
                cmd.ExecuteNonQuery();
                material.IdMaterial = parametruMaterialId.Value as int?;
            }
        }

        public void StergereMaterial(Material material)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereMaterial", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruIdMaterial = new SqlParameter("@material_id", material.IdMaterial);
                cmd.Parameters.Add(parametruIdMaterial);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareMaterial(Material material)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareMaterial", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruMaterialId = new SqlParameter("@material_id", material.IdMaterial);
                SqlParameter parametruIdMaterie = new SqlParameter("@id_materie", material.IdMaterie);
                SqlParameter parametruFisier = new SqlParameter("@fisier", material.Fisier);
                cmd.Parameters.Add(parametruMaterialId);
                cmd.Parameters.Add(parametruIdMaterie);
                cmd.Parameters.Add(parametruFisier);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Material> ObtineToateMaterialeleDupaMaterie(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Material> rezultat = new ObservableCollection<Material>();
                SqlCommand cmd = new SqlCommand("ObtineToateMaterialeleDupaMaterie", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruMaterieId = new SqlParameter("@materie_id", materie.IdMaterie);
                cmd.Parameters.Add(parametruMaterieId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Material()
                    {
                        IdMaterial = reader.GetInt32(0),
                        IdMaterie = reader.GetInt32(1),
                        Fisier = (byte[])reader[2]
                    });
                }
                return rezultat;
            }
        }

        public ObservableCollection<Material> ObtineToateMaterialeleDupaMaterieDupaProfesor(int profesorId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Material> rezultat = new ObservableCollection<Material>();
                SqlCommand cmd = new SqlCommand("ObtineToateMaterialeleDupaMaterieDupaProfesor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parametruProfesorId = new SqlParameter("@profesor_id", profesorId);
                cmd.Parameters.Add(parametruProfesorId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Material()
                    {
                        IdMaterial = reader.GetInt32(0),
                        IdMaterie = reader.GetInt32(1),
                        Fisier = (byte[])reader[2]
                    });
                }
                return rezultat;
            }
        }
    }
}
