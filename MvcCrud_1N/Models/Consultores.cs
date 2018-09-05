using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCrud_1N.Models
{
    public class Consultores
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Nome Consultor")]
        public string Nome { get; set; }

    }
}