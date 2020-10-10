using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Vencimiento { get; set; }
        public int Estimacion { get; set; }
        public int ResponsableId { get; set; }
        public Recurso Responsable { get; set; }
        public bool Estado { get; set; }

        public Tarea(int id, string titulo, DateTime vencimiento, int estimacion, int responsableId, Recurso responsable, bool estado)
        {
            Id = id;
            Titulo = titulo;
            Vencimiento = vencimiento;
            Estimacion = estimacion;
            ResponsableId = responsableId;
            Responsable = responsable;
            Estado = estado;
        }

        public Tarea()
        {
        }
    }
}
