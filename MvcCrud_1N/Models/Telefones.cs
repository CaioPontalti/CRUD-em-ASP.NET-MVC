using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcCrud_1N.Models
{
    public class Telefones
    {
        public int Id { get; set; }

        public int DDD { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public TipoTelefone Tipo { get; set; }
    }
}