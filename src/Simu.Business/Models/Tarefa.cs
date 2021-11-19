using System;
using System.Collections.Generic;

namespace Simu.Business.Models
{
    public class Tarefa : Entity
    {
        public string TarefaId { get; set; }

        public string UsuarioId { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }
        public string Prova { get; set; }

        public string Imagem { get; set; }

        public string UploadImagem { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}
