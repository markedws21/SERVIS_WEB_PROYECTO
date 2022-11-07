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
    public class SedeDAO : ISede<Sede>
    {
        public void ActualizarSede(Sede p)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_ActualizarSede", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idSede", p.idSede);
            cmd.Parameters.AddWithValue("@nomSede", p.nomSede);
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

        public List<Sede> SedeListar()
        {
            List<Sede> lista = new List<Sede>();
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_listarSede", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Sede sed = new Sede()
                    {
                        idSede = Convert.ToInt32(dr[0]),
                        nomSede = dr[1].ToString(),
                    };
                    lista.Add(sed);
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

        public Sede BuscarSede(int idSede)
        {
            Sede fab = null;
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_BuscarSede", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idSede", idSede);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    fab = new Sede()
                    {
                        idSede = Convert.ToInt32(dr[0]),
                        nomSede = dr[1].ToString(),

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

        public void InsertarSede(Sede p)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_InsertarSede", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nomSede", p.nomSede);
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
            SqlCommand cmd = new SqlCommand("usp_EliminarSede", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idSede", id);
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