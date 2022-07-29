using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalTree.Interfaces;

namespace UniversalTree.Internal
{
    internal static class RelationsRepository
    {
        private static int _headCounter = 0;
        public static SortedDictionary<int, int> ParentRelations { get; set; } = new SortedDictionary<int, int>();
        public static Dictionary<int, int> ChildRelations { get; set; } = new Dictionary<int, int>();
        public static List<int> Roots { get; set; } = new List<int>();
        internal static int GetNextNode()
        {
            return _headCounter++;
        }
    }
}

