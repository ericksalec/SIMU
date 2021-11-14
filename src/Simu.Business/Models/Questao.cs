using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simu.Business.Models
{
    public class Questao : Entity
    {
        public Guid ProvaId { get; set; }
        public Guid AssuntoId { get; set; }
        public string Conteudo { get; set; }

        // EF Relation
        //public Assunto Assunto { get; set; }
        //public Prova Prova { get; set; }

    }
}
