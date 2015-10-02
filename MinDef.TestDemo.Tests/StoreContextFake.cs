using MinDef.TestDemo.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinDef.TestDemo.Tests
{
    class StoreContextFake : IStoreContext
    {
        public StoreContextFake()
        {
            Tanks = new List<Tank>();
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

        public IList<Tank> Tanks { get; set; }
    }
}
