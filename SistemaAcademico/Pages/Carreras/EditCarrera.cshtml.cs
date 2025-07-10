using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaAcademico.Data;
using SistemaAcademico.Helpers;
using SistemaAcademico.Models;

namespace SistemaAcademico.Pages.Carreras
{
    public class EditCarreraModel : PageModel
    {
        public List<string> Modalidades = new List<string>();
        [BindProperty]
        public Carrera CarrerasP { get; set; }
        public IActionResult OnGet(int id)
        {
            Modalidades = OpcionesModalidad.lista;

            // ?? Coloca el breakpoint aquí
            CarrerasP = DatosCompartidos.ListCarreras.FirstOrDefault(c => c.Id == id);

            if (CarrerasP == null)
            {
                throw new Exception($"Carrera con id {id} no encontrada");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Modalidades = OpcionesModalidad.lista;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (var carrera in DatosCompartidos.ListCarreras)
            {
                if (carrera.Id == CarrerasP.Id)
                {
                    carrera.Nombre = CarrerasP.Nombre;
                    carrera.Modalidad = CarrerasP.Modalidad;
                    carrera.DuracionAnios = CarrerasP.DuracionAnios;
                    carrera.TituloOtorgado = CarrerasP.TituloOtorgado;
                    break;
                }
            }
            return RedirectToPage("/Carreras/TablaCarreras");
        }

    }
}