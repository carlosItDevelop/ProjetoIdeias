using System;
using Cooperchip.IdeiasApp.Domain.Enums;
using Cooperchip.IdeiasApp.DomainCore.Base;

namespace Cooperchip.IdeiasApp.Domain.Models
{
    public class Ideia : EntityBase
    {
        // Todo: Id e DataInclusao herdamos de EntityBase, no Projeto DomainCore.
        // Todo: Vamos implementar no Contexto da Aplicação a Inclusão da Data e a NÃO alteração da mesma;

        public StatusIdeia StatusIdeia { get; set; }
        public bool ExisteConcorrente { get; set; }
        public string DetalhesConcorrente { get; set; }

        // Todo: Implemetar UsuarioID, mas preciso mapear este atributo com o IdentityUser

        public string Argumento { get; set; }
        public DateTime DataSubAnalise { get; set; }

        public StatusAnalise StatusAnalise { get; set; }

    }
}