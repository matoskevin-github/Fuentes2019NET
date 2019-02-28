using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WcfEscuelaCRUDADO.Net.DataSource;
using WcfEscuelaCRUDADO.Net.Model;

namespace WcfEscuelaCRUDADO.Net
{
    public class ServiceEscuela : IServiceEscuela
    {
        public bool RegistrarMaestro(EscuelaBE oescuelaBE)
        {
            bool bolRespuesta = false;
            try
            {
                using (SqlConnection connection = DBUtils.GetDBConnection())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "sp_Maestro_Add";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = connection;

                        command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = oescuelaBE.Nombre;
                        command.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 50).Value = oescuelaBE.ApellidoPaterno;
                        command.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 50).Value = oescuelaBE.ApellidoMaterno;
                        command.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = oescuelaBE.FechaNacimiento;
                        command.Parameters.Add("@FechaIngreso", SqlDbType.Date).Value = oescuelaBE.FechaIngreso;

                        connection.Open();

                        bolRespuesta = command.ExecuteNonQuery() > 0;

                        connection.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return bolRespuesta;
        }

        public bool ActualizarMaestro(EscuelaBE oescuelaBE)
        {
            bool bolRespuesta = false;
            try
            {
                using (SqlConnection connection = DBUtils.GetDBConnection())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "sp_Maestro_Update";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = connection;

                        command.Parameters.Add("@idMaestro", SqlDbType.Int).Value = oescuelaBE.idMaestro;
                        command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = oescuelaBE.Nombre;
                        command.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 50).Value = oescuelaBE.ApellidoPaterno;
                        command.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 50).Value = oescuelaBE.ApellidoMaterno;
                        command.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = oescuelaBE.FechaNacimiento;
                        command.Parameters.Add("@FechaIngreso", SqlDbType.Date).Value = oescuelaBE.FechaIngreso;

                        connection.Open();

                        bolRespuesta = command.ExecuteNonQuery() > 0;

                        connection.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return bolRespuesta;
        }

        public bool EliminarMaestro(EscuelaBE oescuelaBE)
        {
            bool bolRespuesta = false;
            try
            {
                using (SqlConnection connection = DBUtils.GetDBConnection())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "sp_Maestro_Delete";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = connection;

                        command.Parameters.Add("@idMaestro", SqlDbType.Int).Value = oescuelaBE.idMaestro;

                        connection.Open();

                        bolRespuesta = command.ExecuteNonQuery() > 0;

                        connection.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return bolRespuesta;
        }

        public List<EscuelaBE> ListarMaestros()
        {
            List<EscuelaBE> listEscuelaBE = new List<EscuelaBE>();
            try
            {
                using (SqlConnection connection = DBUtils.GetDBConnection())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "sp_Maestro_GetAll";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = connection;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EscuelaBE oEscuelaBE = new EscuelaBE();
                                oEscuelaBE.idMaestro = Convert.ToInt32(reader["idMaestro"]);
                                oEscuelaBE.Nombre = Convert.ToString(reader["Nombre"]);
                                oEscuelaBE.ApellidoPaterno = Convert.ToString(reader["ApellidoPaterno"]);
                                oEscuelaBE.ApellidoMaterno = Convert.ToString(reader["ApellidoMaterno"]);
                                oEscuelaBE.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                                oEscuelaBE.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]);
                                listEscuelaBE.Add(oEscuelaBE);
                            }
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listEscuelaBE;
        }

        public EscuelaBE ListarMaestroPorId(int idMaestro)
        {
            EscuelaBE oEscuelaBE = new EscuelaBE();
            try
            {
                using (SqlConnection connection = DBUtils.GetDBConnection())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "sp_Maestro_GetById";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = connection;

                        command.Parameters.Add("@idMaestro", SqlDbType.Int).Value = idMaestro;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {                               
                                oEscuelaBE.idMaestro = Convert.ToInt32(reader["idMaestro"]);
                                oEscuelaBE.Nombre = Convert.ToString(reader["Nombre"]);
                                oEscuelaBE.ApellidoPaterno = Convert.ToString(reader["ApellidoPaterno"]);
                                oEscuelaBE.ApellidoMaterno = Convert.ToString(reader["ApellidoMaterno"]);
                                oEscuelaBE.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                                oEscuelaBE.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]);
                                break;
                            }
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oEscuelaBE;
        }

        public List<EscuelaBE> ListarMaestroPorCriterio(string Criterio)
        {
            List<EscuelaBE> listEscuelaBE = new List<EscuelaBE>();
            try
            {
                using (SqlConnection connection = DBUtils.GetDBConnection())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "sp_Maestro_GetByCriterio";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = connection;

                        command.Parameters.Add("@Criterio", SqlDbType.VarChar, 50).Value = Criterio;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EscuelaBE oEscuelaBE = new EscuelaBE();
                                oEscuelaBE.idMaestro = Convert.ToInt32(reader["idMaestro"]);
                                oEscuelaBE.Nombre = Convert.ToString(reader["Nombre"]);
                                oEscuelaBE.ApellidoPaterno = Convert.ToString(reader["ApellidoPaterno"]);
                                oEscuelaBE.ApellidoMaterno = Convert.ToString(reader["ApellidoMaterno"]);
                                oEscuelaBE.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                                oEscuelaBE.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]);
                                listEscuelaBE.Add(oEscuelaBE);
                            }
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listEscuelaBE;
        }






    }
}
