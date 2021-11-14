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
        public Guid ProvaId { get; set; }
        [HiddenInput]
        public Guid AssuntoId { get; set; }

        [DisplayName("Conteúdo")]
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(10000, ErrorMessage ="O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 1)]
        public string Conteudo { get; set; }

    }
}
