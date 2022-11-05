using SERVIS_WEB_PROYECTO.Entity;
using SERVIS_WEB_PROYECTO.Service;
using SERVIS_WEB_PROYECTO.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SERVIS_WEB_PROYECTO.Models
{
    public class AlumnoDAO : IAlumno<Alumno>
    {
        public void ActualizarAlumno(Alumno p)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_ActualizarAlumno", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", p.codAlumno);
            cmd.Parameters.AddWithValue("@nom", p.nomAlumno);
            cmd.Parameters.AddWithValue("@ape", p.apeAlumno);
            cmd.Parameters.AddWithValue("@dire", p.direAlumno);
            cmd.Parameters.AddWithValue("@dni", p.dniAlumno);
            cmd.Parameters.AddWithValue("@corre", p.correoAlumno);
            cmd.Parameters.AddWithValue("@fono", p.celuAlumno);
            cmd.Parameters.AddWithValue("@esta", p.estado);

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

        public List<Alumno> AlumnoListar()
        {
            List<Alumno> lista = new List<Alumno>();
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_listarAlumno", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Alumno alu = new Alumno()
                    {
                        codAlumno = Convert.ToInt32(dr[0]),
                        nomAlumno = dr[1].ToString(),
                        apeAlumno = dr[2].ToString(),
                        direAlumno = dr[3].ToString(),
                        dniAlumno = dr[4].ToString(),
                        correoAlumno = dr[5].ToString(),
                        celuAlumno = Convert.ToInt32(dr[6]),
                        estado = dr[7].ToString()
                    };
                    lista.Add(alu);
                }
                dr.Close();
                cn.Close();
            }catch(SqlException ex)
            {
                throw ex;
            }
            return lista;
        }

        public Alumno BuscarAlumno(int idAlumno)
        {
            Alumno al = null;
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_BuscarAlumno", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", idAlumno);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    al = new Alumno()
                    {
                        codAlumno = Convert.ToInt32(dr[0]),
                        nomAlumno = dr[1].ToString(),
                        apeAlumno = dr[2].ToString(),
                        direAlumno = dr[3].ToString(),
                        dniAlumno = dr[4].ToString(),
                        correoAlumno = dr[5].ToString(),
                        celuAlumno = Convert.ToInt32(dr[6]),
                        estado = dr[7].ToString()
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return al;
        }

        public void InsertarAlumno(Alumno p)
        {
            SqlConnection cn = dbAcceso.ConectaBD();
            SqlCommand cmd = new SqlCommand("usp_InsertarAlumno", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nom", p.nomAlumno);
            cmd.Parameters.AddWithValue("@ape", p.apeAlumno);
            cmd.Parameters.AddWithValue("@dire", p.direAlumno);
            cmd.Parameters.AddWithValue("@dni", p.dniAlumno);
            cmd.Parameters.AddWithValue("@corre", p.correoAlumno);
            cmd.Parameters.AddWithValue("@fono", p.celuAlumno);
            cmd.Parameters.AddWithValue("@esta", p.estado);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
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