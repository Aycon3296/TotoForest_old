using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalTree.Interfaces;
using UniversalTree.Internal;
using System.Linq;

namespace UniversalTree.Public
{
    public abstract class TreeBase : ITree
    {
        protected readonly int _root;
        
        public static readonly TreeBase Empty = new EmptyTree();

        public TreeBase()
        {
            _root = RelationsRepository.GetNextNode();
        }

        protected TreeBase(int root)
        {
            _root = root;
        }

        protected abstract ITree GetTree(int root);

        public abstract TreeType TreeType { get; }

        public IEnumerable<ITree> Enumerate(ITreeEnumerator treeEnumerator)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITree> GetNextChild()
        {
            foreach (var node in RelationsRepository.ChildRelations.Where(node => node.Key == _root))
            {
                yield return GetTree(node.Value);
            }
        }

        public ITree GetParent()
        {
            return GetTree(RelationsRepository.ParentRelations.First(relation => relation.Key == _root).Value) ?? Empty;
        }

        public override bool Equals(object? other)
        {
            if (other is null || other is not ITree)
            {
                return false;
            }
            else
            {
                return Equals((TreeBase)other);
            }
        }

        public override int GetHashCode()
        {
            return _root;
        }

        public override string ToString()
        {
            return $"Tree{{{_root}}}";
        }

        public bool Equals(ITree? other)
        {
            //Check for null and compare run-time types.
            if ((other == null) || this is EmptyTree)
            {
                return false;
            }
            else
            {
                if (other is TreeBase otherTreeBase)
                {
                    return otherTreeBase._root == _root;
                }
                else
                {
                    return false;
                }
            }
        }

        public ITree GetRoot()
        {
            int parent = _root;
            int buffer;
            do
            {
                buffer = parent;
                parent = RelationsRepository.ParentRelations.FirstOrDefault(ralation => ralation.Key == parent).Value;
            }
            while (parent != default);

            return GetTree(parent);
        }
    }
}
