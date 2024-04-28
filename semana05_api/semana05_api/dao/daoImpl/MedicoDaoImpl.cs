using semana05_api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace semana05_api.dao.daoImpl
{
    public class MedicoDaoImpl : MedicoDao
    {
        string cadena_conexion = "Data Source=.; uid=sa; pwd=sistemas; Initial Catalog= DSW_Semana_05;";
        public List<Medico> lista(string indicador, int codigo)
        {
            List<Medico> lista = new List<Medico>();
            SqlConnection con = new SqlConnection(cadena_conexion);
            SqlCommand cmd;
            SqlDataReader reader;
            try
            {
                con.Open();
                cmd = new SqlCommand("usp_medico_crud", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@indicador", indicador);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@nombre", "");
                cmd.Parameters.AddWithValue("@apellido", "");
                cmd.Parameters.AddWithValue("@especialidad", "");
                cmd.Parameters.AddWithValue("@documento", "");

                reader = cmd.ExecuteReader();
                Medico objMedico;

                while (reader.Read())
                {
                    objMedico = new Medico();
                    objMedico.codigo = reader.GetInt32(0);
                    objMedico.nombre = reader.GetString(1);
                    objMedico.apellido = reader.GetString(2);
                    objMedico.especialidad = reader.GetString(3);
                    objMedico.documento = reader.GetString(4);
                    lista.Add(objMedico);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public int operacion(string indicador, Medico medico)
        {
            int resultado = -1;
            SqlConnection con = new SqlConnection(cadena_conexion);
            SqlCommand cmd;
            try
            {
                con.Open();
                cmd = new SqlCommand("usp_medico_crud", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@indicador", indicador);
                cmd.Parameters.AddWithValue("@codigo", medico.codigo);
                cmd.Parameters.AddWithValue("@nombre", medico.nombre);
                cmd.Parameters.AddWithValue("@apellido", medico.apellido);
                cmd.Parameters.AddWithValue("@especialidad", medico.especialidad);
                cmd.Parameters.AddWithValue("@documento", medico.documento);
                resultado =  Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return resultado;

        }
    }
}