using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore
{
    public class Recurso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Recurso(int id, string nombre, int usuarioId, Usuario usuario)
        {
            Id = id;
            Nombre = nombre;
            UsuarioId = usuarioId;
            Usuario = usuario;
        }

        public Recurso()
        {
        }
    }
}
