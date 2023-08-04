using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.R9.Estructura.Negocio
{
    public class Puesto
    {
        public int PuestoID { get; set; }
        public string Descripcion { get; set; }
        public List<object> Puestos { get; set; }
        public Puesto() { }

        public Puesto(int puestoid ,string descripcion) 
        {
           this.PuestoID = puestoid;
           this.Descripcion = descripcion;
        }

        public static Result GetAll()
        {
            Result result = new Result();

            try
            {

                using (Telcel.R9.Estructura.AccesoDatos.JtorresContext context = new Telcel.R9.Estructura.AccesoDatos.JtorresContext())
                {
                    var query = context.Puestos.FromSqlRaw($"PuestoGetAll").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var puestos in query)
                        {
                            Puesto puesto = new Puesto(
                                puestos.PuestoId, puestos.Descripcion
                                );

                            result.Objects.Add(puesto);
                        }

                        if (result.Objects != null) result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Mensaje = "Error al encontrar registros \n" + result.Ex;
            }
            return result;
        }

        public static Result GetByIdUser(int id)
        {
            Result result = new Result();

            try
            {

                using (Telcel.R9.Estructura.AccesoDatos.JtorresContext context = new Telcel.R9.Estructura.AccesoDatos.JtorresContext())
                {
                    var query = context.Puestos.FromSqlRaw($"PuestoGetById {id}").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var puestos in query)
                        {
                            Puesto puesto = new Puesto(
                                puestos.PuestoId, puestos.Descripcion
                                );

                            result.Objects.Add(puesto);
                        }

                        if (result.Objects != null) result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Mensaje = "Error al encontrar registros \n" + result.Ex;
            }
            return result;
        }
    }
}
