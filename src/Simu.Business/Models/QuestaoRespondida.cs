using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simu.Business.Models
{
    public class QuestaoRespondida : Entity
    {
        public Guid TarefaId { get; set; }
        public Guid UserId { get; set; }
        public string Prova { get; set; }
        public string Enunciado { get; set; }
        public string TipoAssunto { get; set; }
        public string Resposta { get; set; }
        public string RespostaMarcada { get; set; }
        public bool Acerto { get; set; }
        public int AnoProva { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }

    }
}
