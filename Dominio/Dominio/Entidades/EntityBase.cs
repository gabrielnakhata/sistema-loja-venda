using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class EntityBase
    {
        [Key]
        public int? Codigo { get; set; } 
    }
}
