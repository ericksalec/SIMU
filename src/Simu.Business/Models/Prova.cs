using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simu.Business.Models
{
    public class Prova : Entity
    {
        public Questao Questao { get; set; }
        public DateTime Data { get; set; }

    }
}
