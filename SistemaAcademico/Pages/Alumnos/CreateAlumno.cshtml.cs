using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages.Alumnos
{
    public class CreateAlumnoModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public Alumno Alumnos { get; set; }
        //OnPost() este m�todo se ejecuta cuando se realiza una solicitud HTTP POST  
        public IActionResult OnPost()
        {
            if (DatosCompartidos.ListaAlumnos.Any(alumno => alumno.Email == Alumnos.Email))
            {
                ModelState.AddModelError("Alumnos.Email", "El correo electr�nico ya est� registrado.");
            }

            if (DatosCompartidos.ListaAlumnos.Any(alumno => alumno.Dni == Alumnos.Dni))
            {
                ModelState.AddModelError("Alumnos.Dni", "El DNI ya est� registrado.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Alumnos.Id = DatosCompartidos.ObtenerNuevoAlumnoId();
            DatosCompartidos.ListaAlumnos.Add(Alumnos);
            return RedirectToPage("/Alumnos/Alumno");
        }
    }
}