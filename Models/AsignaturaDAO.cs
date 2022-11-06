using SERVIS_WEB_PROYECTO.DataBase;
using SERVIS_WEB_PROYECTO.Entity;
using SERVIS_WEB_PROYECTO.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SERVIS_WEB_PROYECTO.Models
{
    public class AsignaturaDAO : IAsignatura<Asignatura>
    {

        public void ActualizarAsignatura(Asignatura p)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_ActualizarAsignatura", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idAsignatura", p.idAsignatura);
            cmd.Parameters.AddWithValue("@nomAsignatura", p.nomAsignatura);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }

        public List<Asignatura> AsignaturaListar()
        {
            List<Asignatura> lista = new List<Asignatura>();
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_listarAsignatura", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Asignatura asi = new Asignatura()
                    {
                        idAsignatura = Convert.ToInt32(dr[0]),
                        nomAsignatura = dr[1].ToString(),
                    };
                    lista.Add(asi);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lista;
        }

        public Asignatura BuscarAsignatura(int idAsignatura)
        {
            Asignatura fab = null;
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_BuscarAsignatura", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idAsignatura", idAsignatura);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    fab = new Asignatura()
                    {
                        idAsignatura = Convert.ToInt32(dr[0]),
                        nomAsignatura = dr[1].ToString(),

                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return fab;
        }

        public void InsertarAsignatura(Asignatura p)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_InsertarAsignatura", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nomAsignatura", p.nomAsignatura);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
        public void Eliminar(int id)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_EliminarAsignatura", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idAsignatura", id);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}