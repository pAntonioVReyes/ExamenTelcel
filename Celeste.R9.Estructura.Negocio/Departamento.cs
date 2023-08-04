using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.R9.Estructura.Negocio
{
    public class Departamento
    {
        public int DepartamentoID { get; set; }
        public string Descripcion { get; set; }
        public List<object> Departamentos { get; set; }

        public Departamento() { }

        public Departamento(int departamentoID, string descripcion) 
        {
            this.DepartamentoID = departamentoID;
            this.Descripcion = descripcion;
        }

        public static Result GetAll() 
        {
            Result result = new Result();

            try 
            {

                using (Telcel.R9.Estructura.AccesoDatos.JtorresContext context = new Telcel.R9.Estructura.AccesoDatos.JtorresContext()) 
                {
                    var query = context.Departamentos.FromSqlRaw($"DepartamentoGetAll").ToList();

                    if (query != null) 
                    {
                        result.Objects = new List<object>();

                        foreach (var departamentos in query) 
                        {
                            Departamento departamento = new Departamento(
                                departamentos.DepartamentoId, departamentos.Descripcion
                                );

                            result.Objects.Add(departamento);
                        }

                        if (result.Objects != null) result.Correct = true;
                    }
                }

            } catch (Exception ex) 
            {
                result.Correct = false;
                result.Ex = ex; 
                result.Mensaje = "Error al encontrar registros \n" + result.Ex;
            }
            return result;
        }
        public static Result GetById(int id) 
        {
            Result result = new Result();

            try 
            {
                using (Telcel.R9.Estructura.AccesoDatos.JtorresContext context = new Telcel.R9.Estructura.AccesoDatos.JtorresContext())
                {
                    var query = context.Departamentos.FromSqlRaw($"DepartamentoGetById {id}").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var departamentos in query)
                        {
                            Departamento departamento = new Departamento(
                                departamentos.DepartamentoId, departamentos.Descripcion
                                );

                            result.Objects.Add(departamento);
                        }

                        if (result.Objects != null) result.Correct = true;
                    }
                }
            } catch (Exception ex) 
            {
                result.Correct = false;
                result.Ex = ex;
                result.Mensaje = "Error \n" + result.Ex;
            }

            return result;
        }
    }
}
