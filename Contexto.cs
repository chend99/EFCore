using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EFCore
{
    public class Contexto : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=efc.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(eu=> {
                eu.ToTable("Usuario");
                eu.Property(p => p.Nombre).IsRequired();
                eu.Property(p => p.Clave).IsRequired();
            });
                
            modelBuilder.Entity<Recurso>(er => {
                er.ToTable("Recurso");
                er.Property(p => p.Nombre).IsRequired();
            });

            modelBuilder.Entity<Tarea>(et => {
                et.ToTable("Tarea");
                et.Property(p => p.Titulo).HasMaxLength(100).IsRequired();
                et.Property(p => p.Vencimiento).IsRequired();
                et.Property(p => p.Estimacion).IsRequired();
                et.Property(p => p.Estado).IsRequired();
            });

            modelBuilder.Entity<Detalle>(ed => {
                ed.ToTable("Detalle");
                ed.Property(p => p.Fecha).IsRequired();
                ed.Property(p => p.Tiempo).IsRequired();
            });

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Detalle> Detalles { get; set; }

        //AGREGAR
        public void AgregarUsuario(string nombre,string clave)
        {
            Usuarios.Add(new Usuario {Nombre = nombre, Clave = clave});
            SaveChanges();
            Console.WriteLine("Usuario Agregado.");
        }
        public void AgregarRecurso(string nombre)
        {
            Recursos.Add(new Recurso { Nombre = nombre, UsuarioId = Usuarios.Where(i => i.Id > 0).First().Id }); // Aún no sé cómo funcionan las FKs con EFC.
            SaveChanges();
            Console.WriteLine("Recurso Agregado.");
        }
        
        public void AgregarTarea(string titulo, DateTime vencimiento, int estimacion, bool estado)
        {
            Tareas.Add(new Tarea { Titulo = titulo, Vencimiento = vencimiento, Estimacion = estimacion,ResponsableId = Recursos.Where(i => i.Id > 0).First().Id, Estado = estado }); // Aún no sé cómo funcionan las FKs con EFC.
            SaveChanges();
            Console.WriteLine("Tarea Agregado.");
        }
        public void AgregarDetalle(DateTime fecha, int tiempo)
        {
            Detalles.Add(new Detalle { Fecha = fecha, Tiempo = tiempo, RecursoId = Recursos.Where(i => i.Id > 0).Single().Id, TareaId= Tareas.Where(i => i.Id > 0).First().Id }); // Aún no sé cómo funcionan las FKs con EFC.
            SaveChanges();
            Console.WriteLine("Detalle Agregado.");
        }
        //BORRAR
        public void BorrarUsuario(int id)
        {
            Usuarios.Remove(Usuarios.Where(i => i.Id == id).Single());
            SaveChanges();
            Console.WriteLine("Usuario Borrado.");
        }
        public void BorrarRecurso(int id)
        {
            Recursos.Remove(Recursos.Where(i => i.Id == id).Single());
            SaveChanges();
            Console.WriteLine("Recurso Borrado.");
        }
        public void BorrarTarea(int id)
        {
            Tareas.Remove(Tareas.Where(i => i.Id == id).Single());
            SaveChanges();
            Console.WriteLine("Tarea Borrado.");
        }
        public void BorrarDetalle(int id)
        {
            Detalles.Remove(Detalles.Where(i => i.Id == id).Single());
            SaveChanges(); 
            Console.WriteLine("Detalle Borrado.");
        }
        //MODIFICAR
        public void ModificarUsuario(int id, string nombre, string clave)
        {
            var usuarioModificar = Usuarios.Where(i => i.Id == id).Single();
            usuarioModificar.Nombre = nombre;
            usuarioModificar.Clave = clave;
            SaveChanges();
            Console.WriteLine("Usuario Modificado.");
        }
        public void ModificarRecurso(int id, string nombre)
        {
            var recursoModificar = Recursos.Where(i => i.Id == id).Single();
            recursoModificar.Nombre = nombre;
            SaveChanges();
            Console.WriteLine("Recurso Modificado.");
        }
        public void ModificarTarea(int id, string titulo, DateTime vencimiento, int estimacion, bool estado)
        {
            var tareaModificar = Tareas.Where(i => i.Id == id).Single();
            tareaModificar.Titulo = titulo;
            tareaModificar.Vencimiento = vencimiento;
            tareaModificar.Estimacion = estimacion;
            tareaModificar.Estado = estado;
            SaveChanges();
            Console.WriteLine("Tarea Modificado.");
        }
        public void ModificarrDetalle(int id, DateTime fecha, int tiempo)
        {
            var detalleModificar = Detalles.Where(i => i.Id == id).Single();
            detalleModificar.Fecha = fecha;
            detalleModificar.Tiempo = tiempo;
            SaveChanges();
            Console.WriteLine("Detalle Modificado.");
        }
        //CONSULTAR
        public void ConsultarUsuarios()
        {
            foreach (var usuario in Usuarios.ToList())
            {
                Console.WriteLine($"Id: {usuario.Id} Nombre: {usuario.Nombre} Contraseña: {usuario.Clave}");
            }
        }
        public void ConsultarRecursos()
        {
            foreach (var recurso in Recursos.ToList())
            {
                Console.WriteLine($"Id: {recurso.Id} Nombre: {recurso.Nombre}");
            }
        }
        public void ConsultarTareas()
        {
            foreach (var tarea in Tareas.ToList())
            {
                Console.WriteLine($"Id: {tarea.Id} Titulo: {tarea.Titulo} Vencimiento: {tarea.Vencimiento} Estimacion: {tarea.Estimacion} Estado: {tarea.Estado}");
            }
        }
        public void ConsultarDetalles()
        {
            foreach (var detalle in Detalles.ToList())
            {
                Console.WriteLine($"Id: {detalle.Id} Fecha: {detalle.Fecha} Tiempo: {detalle.Tiempo}");
            }
        }
    }

}
