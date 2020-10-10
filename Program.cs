using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new Contexto();
            ctx.AgregarUsuario("David","micontra");
            ctx.AgregarUsuario("Juan","micontra");
            ctx.AgregarUsuario("Pepe","micontra");
            ctx.AgregarRecurso("Recurso?");
            ctx.AgregarTarea("Entregar items al jefe de la aldea",new DateTime(2020,09,01),10,false);
            ctx.AgregarDetalle(new DateTime(2020, 08, 01), 1000);
            ctx.ConsultarUsuarios();
            ctx.ConsultarRecursos();
            ctx.ConsultarTareas();
            ctx.ConsultarDetalles();
            ctx.BorrarUsuario(2);
            ctx.ConsultarUsuarios();
            Console.WriteLine("fin");
        }
    }
}
