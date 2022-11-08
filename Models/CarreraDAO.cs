using SERVIS_WEB_PROYECTO.Entity;
using SERVIS_WEB_PROYECTO.Service;
using SERVIS_WEB_PROYECTO.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SERVIS_WEB_PROYECTO.Models
{
    public class CarreraDAO : ICarrera<Carrera>
    {
        public void ActualizarCarrera(Carrera p)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_ActualizarCarrera", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", p.idCarrera);
            cmd.Parameters.AddWithValue("@nom", p.nomCarrera);

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

        public Carrera BuscarCarrera(int idCarrera)
        {
            Carrera car = null;
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_BuscarCarrera", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", idCarrera);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    car = new Carrera()
                    {
                        idCarrera = Convert.ToInt32(dr[0]),
                        nomCarrera = dr[1].ToString(),
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return car;
        }

        public List<Carrera> CarreraListar()
        {
            List<Carrera> lista = new List<Carrera>();
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_listarCarrera", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Carrera carre = new Carrera()
                    {
                        idCarrera = Convert.ToInt32(dr[0]),
                        nomCarrera = dr[1].ToString(),
                    };
                    lista.Add(carre);
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

        public void Eliminar(int id)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_EliminarCarrera", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", id);
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

        public void InsertarCarrera(Carrera p)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_InsertarCarrera", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nom", p.nomCarrera);

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
    }
}