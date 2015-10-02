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

        public bool Store(object o)
        {
           if (o is IVoertuig)
           {
               if (_items.ContainsKey(((IVoertuig)o).Kenteken))
               {
                   throw new DuplicateKentekenException();
               }

               _items.Add(((IVoertuig)o).Kenteken, o);
           }

            return true;
        }

    }
}
