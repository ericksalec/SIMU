using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simu.App.ViewModels
{
    public class DadoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [HiddenInput]
        public Guid UserId { get; set; }

        [DisplayName("Questões Respondidas")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Respondidas { get; set; }

        [DisplayName("Questões acertadas")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Acertos { get; set; }

        [DisplayName("Questões errdas")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Erros { get; set; }
    }
}
