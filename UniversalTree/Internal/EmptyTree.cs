using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalTree.Interfaces;
using UniversalTree.Public;

namespace UniversalTree.Internal
{
    internal sealed class EmptyTree : TreeBase
    {
        public override TreeType TreeType => TreeType.Finite;

        protected override ITree GetTree(int root)
        {
            return this;
        }
    }
}
