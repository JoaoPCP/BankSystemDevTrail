using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDevTrail.Domain.Commons
{
    public abstract class BaseEntity
    {
        public Guid Id { get; }

        protected BaseEntity() { }

        protected BaseEntity(Guid id)
        {
            Id = id;
        }
    }
}
