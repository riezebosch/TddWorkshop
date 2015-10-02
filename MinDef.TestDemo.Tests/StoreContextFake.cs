using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinDef.TestDemo.Tests
{
    class StoreContextFake : StoreContext
    {
          public bool IsSaveChangesCalled()
        {
            return _save;
        }

        public override int SaveChanges()
        {
            _save = true;
            return 1;
        }

        public bool _save { get; set; }
    }
}
