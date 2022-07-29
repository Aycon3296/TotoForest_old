using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalTree.Interfaces;
using UniversalTree.Public;

namespace UniversalTree.Core
{
    internal class TestFiniteTree : ITree
    {
        public TreeType TreeType { get; } = TreeType.Finite;

        public IEnumerable<ITree> Enumerate(ITreeEnumerator treeEnumerator)
        {
            throw new NotImplementedException();
        }

        public bool Equals(ITree? other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITree> GetNextChild()
        {
            throw new NotImplementedException();
        }

        public ITree GetParent()
        {
            throw new NotImplementedException();
        }

        public ITree GetRoot()
        {
            throw new NotImplementedException();
        }
    }
}
