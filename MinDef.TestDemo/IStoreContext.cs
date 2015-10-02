using MinDef.TestDemo.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MinDef.TestDemo
{
    public interface IStoreContext
    {
        IDbSet<Tank> Tanks { get; set; }
        int SaveChanges();
    }
}
