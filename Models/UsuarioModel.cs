using System.ComponentModel.DataAnnotations;

namespace ExamenFinalIncomel.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        public string nombre { get; set; }

        public string email { get; set; }

        public string fechaNacimiento { get; set; }

        public string contrasenia { get; set; }


    }
}
