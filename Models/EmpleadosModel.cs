using System.ComponentModel.DataAnnotations;

namespace ExamenFinalIncomel.Models
{
    public class EmpleadosModel
    {
        [Key]
        public int id { get; set; }

        public string registered_by { get; set; }

        public string created_By { get; set; }

        public int DPI { get; set; }

        public string nombre { get; set; }

        public int cantidad_hijos { get; set; }

        public decimal salario_base { get; set; }

        public int bono_decreto { get; set; }

        public decimal igss { get; set; }

        public decimal irtra { get; set; }

        public decimal bono_paternidad { get; set; }

        public decimal salario_total { get; set; }

        public decimal salario_liquido { get; set; }
          }
}
