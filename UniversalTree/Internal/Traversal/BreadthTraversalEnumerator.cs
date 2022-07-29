using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalTree.Interfaces;

namespace UniversalTree.Public
{
    public class BreadthTraversalEnumerator<OrderType> : ITreeEnumerator
    {
        public IEnumerator<ITree> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
