using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simu.Business.Models
{
    public class Dado : Entity
    {
        public int UserId { get; set; }
        public int Respondidas { get; set; }
        public int Acertos { get; set; }
        public int Erros { get; set; }

    }
}
