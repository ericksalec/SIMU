using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simu.Business.Models
{
    public class Questao : Entity
    {
        public Guid TarefaId { get; set; }
        public string Descricao { get; set; }
        public string Prova { get; set; }


        // EF Relation
        //public Assunto Assunto { get; set; }
        //public Prova Prova { get; set; }

    }
}
