using MinDef.TestDemo.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MinDef.TestDemo.Tests
{
    class StoreContextFake : IStoreContext
    {
        public StoreContextFake()
        {
            Tanks = new FakeDbSet.InMemoryDbSet<Tank>();
        }

          public bool IsSaveChangesCalled()
        {
            return _save;
        }

        public int SaveChanges()
        {
            _save = true;
            return 1;
        }

        public bool _save { get; set; }

        public IDbSet<Tank> Tanks { get; set; }
    }
}
