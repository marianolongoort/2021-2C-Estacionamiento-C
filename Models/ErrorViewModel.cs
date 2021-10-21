using System;

namespace EstacionamientoMVC.Models
{
    public class ErrorViewModel
    {

        private readonly TimeSpan duracion = new TimeSpan(2,0,0);

        public TimeSpan Duracion { get { return duracion; } }


        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
