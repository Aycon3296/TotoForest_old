using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalTree.Public;

namespace UniversalTree.Interfaces
{
    public interface ITree : IEquatable<ITree>
    {
        TreeType TreeType { get; }

        ITree GetRoot();

        IEnumerator<ITree> GetNextChild();

        ITree GetParent();

        IEnumerable<ITree> Enumerate(ITreeEnumerator treeEnumerator);
    }
}
