using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinDef.TestDemo
{
    internal class ObjectStorer
    {
        IDictionary<string, object> _items
            = new Dictionary<string, object>();
        private StoreContext context;

        internal ObjectStorer(StoreContext context)
        {
            this.context = context;
        }

        public ObjectStorer() 
            : this(new StoreContext())
        {
        }

        public bool Store(object o)
        {
            IVoertuig v = o as IVoertuig;
            if (v != null)
            {
                Store(v);
                return true;
           }

            return false;
        }

        private void Store(IVoertuig v)
        {
            context.SaveChanges();
            if (_items.ContainsKey(v.Kenteken))
            {
                throw new DuplicateKentekenException();
            }

            _items.Add(v.Kenteken, v);
        }

    }
}
