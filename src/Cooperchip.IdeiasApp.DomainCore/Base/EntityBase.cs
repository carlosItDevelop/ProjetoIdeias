using System;

namespace Cooperchip.IdeiasApp.DomainCore.Base
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}