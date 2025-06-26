using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cajero
    {
        public int IdCajero { get; set; }
        public ML.Tipo Tipo { get; set; }
        public int Cantidad { get; set; }
        public decimal Denominacion { get; set; }

        //Propiedad única para operación de retiro en C#
        [DisplayName("Ingrese la cantidad a retirar en multiplos de $0.50")]
        [Required(ErrorMessage = "Escriba la cantidad a retirar")]
        [RegularExpression(@"^\d+(\.([05]){1})?$", ErrorMessage = "Valor inválido, debe ser múltiplo de 0.50")]
        public decimal Retiro { get; set; }
        public List<object> Cajeros {  get; set; }
    }
}