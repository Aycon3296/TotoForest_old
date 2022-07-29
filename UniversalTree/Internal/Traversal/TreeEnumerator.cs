using UniversalTree.Interfaces;

namespace UniversalTree.Internal.Traversal
{
    internal static class TreeEnumerator
    {
        public static readonly ITreeEnumerator Empty = new EmptyTraversalEnumerator();
    }
}
