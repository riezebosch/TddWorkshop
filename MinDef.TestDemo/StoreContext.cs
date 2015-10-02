using MinDef.TestDemo.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MinDef.TestDemo
{
    public class StoreContext : DbContext, IStoreContext
    {
        public IDbSet<Tank> Tanks { get; set; }


    }
}
