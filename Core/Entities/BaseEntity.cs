using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            IsActive = true;
            CreatedOn = DateTime.Now;
        }

        public Guid Id { get; protected set; }
        public bool IsActive { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
    }
}
