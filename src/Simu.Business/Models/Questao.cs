using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simu.Business.Models
{
    public class Questao : Entity
    {
        public Guid TarefaId { get; set; }
        public string Prova { get; set; }
        public string Enunciado { get; set; }
        public string TipoAssunto { get; set; }
        public string Resposta { get; set; }
        public int AnoProva { get; set; }
        public int Numero { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }


        // EF Relation
        //public Assunto Assunto { get; set; }
        //public Prova Prova { get; set; }

    }
}
