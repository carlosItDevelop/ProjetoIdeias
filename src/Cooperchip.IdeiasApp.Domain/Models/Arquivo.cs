using System;
using Cooperchip.IdeiasApp.DomainCore.Base;

namespace Cooperchip.IdeiasApp.Domain.Models
{
    public class Arquivo : EntityBase
    {
        public string Nome { get; set; }
        public byte[] ArquivoConteudo { get; set; }
    }
}