using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalTree.Interfaces;
using UniversalTree.Public;

namespace UniversalTree.Internal
{
    internal class EmptyTraversalEnumerator : ITreeEnumerator
    {
        public ITree Current => TreeBase.Empty;

        object IEnumerator.Current => TreeBase.Empty;

        public void Dispose() { }

        public bool MoveNext()
        {
            return false;
        }

        public void Reset() { }
    }
}
