using System;

namespace Simu.App.Models
{
    public class ErrorViewModel
    {
        public string Mensagem { get; set; }

        public string Titulo { get; set; }

        public int ErroCode { get; set; }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
