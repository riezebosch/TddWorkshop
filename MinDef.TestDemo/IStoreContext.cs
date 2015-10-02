using MinDef.TestDemo.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinDef.TestDemo
{
    public interface IStoreContext
    {
        IList<Tank> Tanks { get; set; }
        int SaveChanges();
    }
}
