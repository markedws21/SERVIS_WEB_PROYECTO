using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SERVIS_WEB_PROYECTO.Entity;
using SERVIS_WEB_PROYECTO.Service;
using System.Data;
using System.Data.SqlClient;
using SERVIS_WEB_PROYECTO.DataBase;

namespace SERVIS_WEB_PROYECTO.Models
{
    public class MatriculaDAO : IMatricula<Matricula>
    {
        public List<Matricula> ListarMatricula()
        {
            List<Matricula> lista = new List<Matricula>();
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_listarMatricula", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Matricula matri = new Matricula()
                    {
                        codMatricula = Convert.ToInt32(dr[0]),
                        codAlumno = Convert.ToInt32(dr[1]),
                        idCarrera = Convert.ToInt32(dr[2]),
                        ciclo = dr[3].ToString(),
                        idSede = Convert.ToInt32(dr[4])
                    };
                    lista.Add(matri);
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

        public void InsertarMatricula(Matricula p)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_InsertarMatricula", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codAlu", p.codAlumno);
            cmd.Parameters.AddWithValue("@idCarr", p.idCarrera);
            cmd.Parameters.AddWithValue("@ciclo", p.ciclo);
            cmd.Parameters.AddWithValue("@idSede", p.idSede);

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
        public void ActualizarMatricula(Matricula p)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_ActualizarMatricula", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codMat", p.codMatricula);
            cmd.Parameters.AddWithValue("@codAlu", p.codAlumno);
            cmd.Parameters.AddWithValue("@idCarr", p.idCarrera);
            cmd.Parameters.AddWithValue("@ciclo", p.ciclo);
            cmd.Parameters.AddWithValue("@idSede", p.idSede);

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
        public Matricula BuscarMatricula(int idMatricula)
        {
            Matricula matri = null;
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_BuscarMatricula", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idMat", idMatricula);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    matri = new Matricula()
                    {
                        codMatricula = Convert.ToInt32(dr[0]),
                        codAlumno = Convert.ToInt32(dr[1]),
                        idCarrera = Convert.ToInt32(dr[2]),
                        ciclo = dr[3].ToString(),
                        idSede = Convert.ToInt32(dr[4])
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return matri;
        }

    }
}