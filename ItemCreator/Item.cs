using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace ItemCreator
{
    /// <summary>
    /// Inventory item.
    /// </summary>
    class Item
    {
        public string Name { get;  private set; }

        /// <summary>
        /// Inventory item.
        /// </summary>
        /// <param name="name">Item name</param>
        public Item(string name)
        {
            if (name.Length > 1)
            {
                Name = name;
            }
            else
            {
                throw new System.Exception("Item name cannot be empty");
            }
        }

        /// <summary>
        /// Exports an item.
        /// </summary>
        /// <param name="path">Path</param>
        public virtual void Export(string path)
        {
            using (FileStream fileStream = new FileStream(path + "\\" + Name + "\\ini.dat", FileMode.Create))
            {}
        }

        /// <summary>
        /// Save item to file.
        /// </summary>
        /// <param name="path"></param>
        public virtual void Save(string path)
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);

            Export(appData + "Temp\\");

            ZipFile.CreateFromDirectory(appData + "Temp\\" + Name, path + Name + ".asii");
        }
    }
}
