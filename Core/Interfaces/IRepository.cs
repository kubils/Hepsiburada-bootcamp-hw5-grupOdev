using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository<Tentity> where Tentity : class
    {
        void Create(Tentity entity);
        void Remove(Tentity entity);
        void Update(Tentity entity);
        List<Tentity> GetAll();
    }
}
