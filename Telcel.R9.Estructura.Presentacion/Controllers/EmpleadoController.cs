using Celeste.R9.Estructura.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace Telcel.R9.Estructura.Presentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            string nombre = "";

            Celeste.R9.Estructura.Negocio.Result result = Celeste.R9.Estructura.Negocio.Empleado.GetAll(nombre);

            if (result.Correct)
            {
                Celeste.R9.Estructura.Negocio.Empleado empleado = new Celeste.R9.Estructura.Negocio.Empleado();
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else 
            {
                ViewBag.Mensaje = result.Mensaje;
                return View("Modal");
            }
            
        }
        [HttpPost]
        public IActionResult GetAll(string nombre) 
        {
            Celeste.R9.Estructura.Negocio.Result result = Celeste.R9.Estructura.Negocio.Empleado.GetAll(nombre);

            if (result.Correct)
            {
                Celeste.R9.Estructura.Negocio.Empleado empleado = new Celeste.R9.Estructura.Negocio.Empleado();
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                ViewBag.Mensaje = result.Mensaje;
                return View("Modal");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Form() 
        {
            Celeste.R9.Estructura.Negocio.Result result = new Celeste.R9.Estructura.Negocio.Result();
            Celeste.R9.Estructura.Negocio.Result resultD = Celeste.R9.Estructura.Negocio.Departamento.GetAll();
            Celeste.R9.Estructura.Negocio.Result resultP = Celeste.R9.Estructura.Negocio.Puesto.GetAll();

            if (resultD != null && resultP != null) 
            {
                Celeste.R9.Estructura.Negocio.Empleado dropdownlist = new Celeste.R9.Estructura.Negocio.Empleado();
                dropdownlist.Departamento = new Celeste.R9.Estructura.Negocio.Departamento();
                dropdownlist.Puesto = new Celeste.R9.Estructura.Negocio.Puesto();
                dropdownlist.Departamento.Departamentos = resultD.Objects;
                dropdownlist.Puesto.Puestos = resultP.Objects;

            }
            ViewBag.Titulo = "Agregar";
            return View();
        }

        [HttpPost]
        public IActionResult Form(Celeste.R9.Estructura.Negocio.Empleado empleado)
        {
            Celeste.R9.Estructura.Negocio.Result result = Celeste.R9.Estructura.Negocio.Empleado.Add(empleado);

            if (result.Correct)
            {
                ViewBag.Mensaje = result.Mensaje;
                return View("Modal");
            }
            else 
            {
                ViewBag.Mensaje = result.Mensaje;
                return View("Modal");
            }
        }

        [HttpPost]
        public IActionResult Delete(int idEmpleado) 
        {
            Celeste.R9.Estructura.Negocio.Result result = Celeste.R9.Estructura.Negocio.Empleado.Delete(idEmpleado);

            if (result.Correct) 
            {
                ViewBag.Mensaje = result.Mensaje;
                return View("Modal");
            }
            else 
            {
                ViewBag.Mensaje = result.Mensaje;
                return View("Modal");
            }
        }
        
    }
}
