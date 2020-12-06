using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemCreator
{
    interface IItem
    {
        /// <summary>
        /// Item name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Exports an item.
        /// </summary>
        /// <param name="path">Path</param>
        void Export(string path);

        /// <summary>
        /// Import item.
        /// </summary>
        /// <param name="path">Path</param>
        void Import(string path);

        /// <summary>
        /// Save item to file.
        /// </summary>
        /// <param name="path">Path</param>
        void Save(string path);

        /// <summary>
        /// Load item from file
        /// </summary>
        /// <param name="path">Path</param>
        void Open(string path);

    }
}
