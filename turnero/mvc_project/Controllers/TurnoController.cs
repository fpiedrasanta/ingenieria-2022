using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_project.Models;
using mvc_project.Models.Login;

namespace mvc_project.Controllers
{
    public class TurnoController : Controller
    {
        private readonly ILogger<TurnoController> _logger;

        public TurnoController(ILogger<TurnoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(
            int idProfesional,
            int numeroSemana)
        {
            TurnoViewModel turnoViewModel = new TurnoViewModel
            {
                Horarios = new List<FilaHorario>()
            };
            
            //Fila 1
            Horario lunes = new Horario
            {
                Hora = "10 am",
                Especialidad = "Cualquiera"
            };

            Horario miercoles = new Horario
            {
                Hora = "11 am",
                Especialidad = "Caries"
            };

            Horario viernes = new Horario
            {
                Hora = "10 am",
                Especialidad = "Tratamiento conducto"
            };
            
            FilaHorario filaHorario = new FilaHorario
            {
                HorarioLunes = lunes,
                HorarioMartes = null,
                HorarioMiercoles = miercoles,
                HorarioJueves = null,
                HorarioViernes = viernes,
                HorarioSabado = null,
                HorarioDomingo = null
            };

            if(numeroSemana == 0)
            {
                turnoViewModel.Horarios.Add(filaHorario);
            }

            //Fila 2
            lunes = new Horario
            {
                Hora = "10.30 am",
                Especialidad = "Cualquiera"
            };
            
            filaHorario = new FilaHorario
            {
                HorarioLunes = lunes,
                HorarioMartes = null,
                HorarioMiercoles = null,
                HorarioJueves = null,
                HorarioViernes = null,
                HorarioSabado = null,
                HorarioDomingo = null
            };

            if(numeroSemana == 1)
            {
                turnoViewModel.Horarios.Add(filaHorario);
            }
            
            DateTime hoy = DateTime.Now.AddDays(numeroSemana * 7);

            int diasHastaElDomingo = (int)DayOfWeek.Sunday - (int)hoy.DayOfWeek;
            int diasHastaElSabado = (int)DayOfWeek.Saturday - (int)hoy.DayOfWeek;

            turnoViewModel.FechaDesde = hoy.AddDays(diasHastaElDomingo).ToString("dd/MM/yyyy");
            turnoViewModel.FechaHasta = hoy.AddDays(diasHastaElSabado).ToString("dd/MM/yyyy");

            turnoViewModel.NumeroSemana = numeroSemana;

            return View(turnoViewModel);
        }
    }
}
