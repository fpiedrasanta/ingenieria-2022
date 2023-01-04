using System;
using System.Collections.Generic;

namespace mvc_project.Models
{
    public class TurnoViewModel
    {
        public List<FilaHorario> Horarios { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public int NumeroSemana { get; set; }
    }

    public class FilaHorario
    {
        public Horario HorarioLunes { get; set; }
        public Horario HorarioMartes { get; set; }
        public Horario HorarioMiercoles { get; set; }
        public Horario HorarioJueves { get; set; }
        public Horario HorarioViernes { get; set; }
        public Horario HorarioSabado { get; set; }
        public Horario HorarioDomingo { get; set; }
    }

    public class Horario
    {
        public string Hora { get; set; }
        public string Especialidad { get; set; }
    }
}