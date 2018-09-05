using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCrud_1N.Models
{
    public class Clientes
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Nome Cliente")]
        public string Nome { get; set; }

        public string Email { get; set; }

        [Required]
        [ForeignKey("Consultores")]
        [Display(Name ="Consultor")]
        public int IdConsultor  { get; set; }

        public virtual Consultores Consultores { get; set; }

        public virtual List<Telefones> Telefones { get; set; }
    }
}