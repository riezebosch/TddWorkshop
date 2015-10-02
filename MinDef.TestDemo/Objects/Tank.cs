using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MinDef.TestDemo.Objects
{
    public class Tank : IVoertuig
    {
        [Key]
        public string Kenteken { get; set; }
    }
}
