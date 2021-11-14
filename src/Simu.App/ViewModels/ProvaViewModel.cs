using Simu.App.ViewModels;
using Simu.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simu.App.ViewModels
{
    public class ProvaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Questão")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10000, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 1)]
        public Questao Questao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Data { get; set; }
    }
}
