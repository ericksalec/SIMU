using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simu.App.ViewModels
{
    public class QuestaoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [HiddenInput]
        public Guid TarefaId { get; set; }


        [DisplayName("Prova")]
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(5000, ErrorMessage ="O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 1)]
        public string Prova { get; set; }

        [DisplayName("Enunciado")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(5000, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 1)]
        public string Enunciado { get; set; }

        [DisplayName("TipoAssunto")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 1)]
        public string TipoAssunto { get; set; }

        [DisplayName("Resposta")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(5000, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 1)]
        public string Resposta { get; set; }

        [DisplayName("AnoProva")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 1)]
        public int AnoProva { get; set; }

        [DisplayName("Numero")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 1)]
        public int Numero { get; set; }

        [DisplayName("Alternativa A")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(2000, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 1)]
        public string A { get; set; }

        [DisplayName("Alternativa B")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(2000, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 1)]
        public string B { get; set; }

        [DisplayName("Alternativa C")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(2000, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 1)]
        public string C { get; set; }

        [DisplayName("Alternativa D")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(2000, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 1)]
        public string D { get; set; }

        [DisplayName("Alternativa E")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(2000, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 1)]
        public string E { get; set; }

    }
}
