using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SERVIS_WEB_PROYECTO.Entity;
using SERVIS_WEB_PROYECTO.Service;
using SERVIS_WEB_PROYECTO.DataBase;

namespace SERVIS_WEB_PROYECTO.Models
{
    public class ProfesorDAO : IProfesor<Profesor>
    {
        public void ActualizarProfesor(Profesor p)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("actualizaProfe", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cod", p.codProf);
            cmd.Parameters.AddWithValue("@nombre", p.nombre);
            cmd.Parameters.AddWithValue("@apellido", p.apellido);
            cmd.Parameters.AddWithValue("@dni", p.dni);
            cmd.Parameters.AddWithValue("@correo", p.correo);
            cmd.Parameters.AddWithValue("@celular", p.celular);

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

        public Profesor BuscarProfesor(int idProf)
        {
            Profesor pro = null;
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("buscaProfe", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", idProf);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    pro = new Profesor()
                    {
                        codProf = Convert.ToInt32(dr[0]),
                        nombre = dr[1].ToString(),
                        apellido = dr[2].ToString(),
                        dni = dr[3].ToString(),
                        correo = dr[4].ToString(),
                        celular = dr[5].ToString()
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return pro;
        }

        public void Eliminar(int cod)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("eliminaProfe", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", cod);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public void InsertaProfesor(Profesor p)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("insertaProfe", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", p.nombre);
            cmd.Parameters.AddWithValue("@apellido", p.apellido);
            cmd.Parameters.AddWithValue("@dni", p.dni);
            cmd.Parameters.AddWithValue("@correo", p.correo);
            cmd.Parameters.AddWithValue("@celular", p.celular);

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

        public List<Profesor> ProfesorListar()
        {
            List<Profesor> lista = new List<Profesor>();
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("listaProfe", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Profesor pro = new Profesor()
                    {
                        codProf = Convert.ToInt32(dr[0]),
                        nombre = dr[1].ToString(),
                        apellido = dr[2].ToString(),
                        dni = dr[3].ToString(),
                        correo = dr[4].ToString(),
                        celular = dr[5].ToString()
                    };
                    lista.Add(pro);
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
    }
}