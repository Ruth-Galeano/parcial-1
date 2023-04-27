using System.ComponentModel.DataAnnotations;

namespace Parcial1.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; } 
        public DateTime? FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public int  IdCiudad { get; set; }
        public string? Ciudad { get; set; }
    }
}
