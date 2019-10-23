using System;
using System.IO;
using Cooperchip.IdeiasApp.DomainCore.Base;

namespace Cooperchip.IdeiasApp.Domain.Models
{
    public class Anexo : EntityBase
    {
        public string Nome { get; set; }
        public Guid IdeiaId { get; set; }
        public Ideia Ideia { get; set; }

        public Guid EventoId { get; set; }
        public Evento Evento { get; set; }

        public Guid ArquivoId { get; set; }
        public Arquivo Arquivo { get; set; }
    }
}