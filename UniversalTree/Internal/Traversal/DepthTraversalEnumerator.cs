using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalTree.Interfaces;
using UniversalTree.Internal;
using UniversalTree.Public;

namespace UniversalTree.Internal.Traversal
{
    internal sealed class DepthTraversalEnumerator : ITreeEnumerator
    {
        private readonly ITree _tree;
        private Stack<IEnumerator<ITree>> _stack = new();

        public ITree Current { get; private set; } = TreeBase.Empty;

        object IEnumerator.Current => Current;

        private DepthTraversalEnumerator(ITree tree)
        {
            _tree = tree ?? throw new ArgumentNullException(nameof(tree), "Tree cannot be null");
        }

        public static bool TryCreateEnumerator(ref ITreeEnumerator enumerator, ITree tree)
        {
            if (tree is null)
            {
                throw new ArgumentNullException(nameof(tree), "Tree cannot be null");
            }

            enumerator = TreeEnumerator.Empty;

            if (tree.TreeType != TreeType.Finite)
            {
                return false;
            }
            else
            {
                enumerator = new DepthTraversalEnumerator(tree);
                return true;
            }
        }

        public bool MoveNext()
        {
            if (_tree == TreeBase.Empty)
            {
                return false;
            }

            if (Current == TreeBase.Empty)
            {
                if (_tree == Current)
                {
                    return false;
                }
                else
                {

                    _stack = new Stack<IEnumerator<ITree>>();
                    _stack.Push(_tree.GetNextChild());

                    Current = _tree;
                    return true;
                }
            }
            else
            {
                while (_stack.Count > 0) //TODO: Move UP
                {
                    IEnumerator<ITree> treeEnumerator = _stack.Pop();

                    if (treeEnumerator.MoveNext())
                    {
                        Current = treeEnumerator.Current;
                        _stack.Push(treeEnumerator);
                        _stack.Push(Current.GetNextChild());
                        return true;
                    }
                }

                return false;
            }
        }

        public void Reset()
        {
            _stack.Clear();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
