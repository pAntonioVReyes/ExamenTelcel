using Microsoft.EntityFrameworkCore;

namespace Celeste.R9.Estructura.Negocio
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public List<object> Empleados { get; set; }
        public Celeste.R9.Estructura.Negocio.Departamento Departamento { get; set; }
        public Celeste.R9.Estructura.Negocio.Puesto Puesto { get; set; }

        public Empleado() { }
        public Empleado(string nombre, int puestoId, int departamentoId) 
        {
            this.Nombre = nombre;
            Departamento = new Departamento();
            this.Departamento.DepartamentoID = puestoId;
            Puesto = new Puesto();
            this.Puesto.PuestoID = departamentoId;
        }

        public static Result GetAll(string nombre) 
        {
            Result result = new Result();

            try 
            {
                using (Telcel.R9.Estructura.AccesoDatos.JtorresContext context = new Telcel.R9.Estructura.AccesoDatos.JtorresContext()) 
                {
                    var query = context.Empleados.FromSqlRaw($"EmpleadoGetAll {nombre}").ToList();

                    if (query != null) 
                    {
                        result.Objects = new List<object>();

                        foreach (var empleados in query) 
                        {
                            Empleado empleado = new Empleado();

                            empleado.Puesto = new Puesto();
                            empleado.Departamento = new Departamento();

                            empleado.EmpleadoID = empleados.PuestoId.Value;
                            empleado.Nombre = empleados.Nombre;
                            
                            empleado.Puesto.PuestoID = empleados.DepartamentoId.Value;
                            empleado.Puesto.Descripcion = empleados.PuestoNombre;

                            empleado.Departamento.DepartamentoID = empleados.DepartamentoId.Value;
                            empleado.Departamento.Descripcion = empleados.DepartamentoNombre;

                            result.Objects.Add(empleado);
                        }
                        
                        if(result.Objects!= null) 
                        {
                            result.Mensaje = "Registros encontrados";
                            result.Correct = true;
                        }     
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

        public static Result Add(Celeste.R9.Estructura.Negocio.Empleado empleado)
        {
            Result result = new Result();

            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.JtorresContext context = new Telcel.R9.Estructura.AccesoDatos.JtorresContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoADD '{empleado.Nombre}', {empleado.Puesto.PuestoID} ,{empleado.Departamento.DepartamentoID}").;

                    if (query > 0)
                    {
                        result.Mensaje = "Registros agregado";
                        result.Correct = true;
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

        public static Result Delete(int id)
        {
            Result result = new Result();

            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.JtorresContext context = new Telcel.R9.Estructura.AccesoDatos.JtorresContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoDelete {id}");

                    if (query > 0)
                    {
                        result.Mensaje = "Registro eliminado";
                        result.Correct = true;
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