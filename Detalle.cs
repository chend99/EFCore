using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore
{
    public class Detalle
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Tiempo { get; set; }
        public int RecursoId { get; set; }
        public Recurso Recurso { get; set; }
        public int TareaId { get; set; }
        public Tarea Tarea { get; set; }

        public Detalle(int id, DateTime fecha, int tiempo, int recursoId, Recurso recurso, int tareaId, Tarea tarea)
        {
            Id = id;
            Fecha = fecha;
            Tiempo = tiempo;
            RecursoId = recursoId;
            Recurso = recurso;
            TareaId = tareaId;
            Tarea = tarea;
        }

        public Detalle()
        {
        }
    }
}
