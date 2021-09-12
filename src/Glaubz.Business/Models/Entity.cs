using System;
using System.Collections.Generic;
using System.Text;

namespace Glaubz.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
