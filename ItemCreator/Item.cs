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
        public string Name { get;  protected set; }

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
            System.IO.Directory.Delete(path + "\\" + Name, true);
            System.IO.Directory.CreateDirectory(path + "\\" + Name);

            using (FileStream fileStream = new FileStream(path + "\\" + Name + "\\ini.dat", FileMode.Create))
            {}

            System.IO.Directory.Delete(path + "\\" + Name, true);
        }

        /// <summary>
        /// Import item.
        /// </summary>
        /// <param name="path">Path</param>
        public virtual void Import(string path)
        {
            Name = path.Substring(0, path.LastIndexOf('\\'));
            using (FileStream fileStream = new FileStream(path + "\\ini.dat", FileMode.Open))
            { }
        }

        /// <summary>
        /// Save item to file.
        /// </summary>
        /// <param name="path">Path</param>
        public virtual void Save(string path)
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);

            Export(appData + "Temp\\");

            ZipFile.CreateFromDirectory(appData + "Temp\\" + Name, path + Name + ".ii");
        }

        /// <summary>
        /// Load item from file
        /// </summary>
        /// <param name="path">Path</param>
        public virtual void Load(string path)
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);

            System.IO.Directory.Delete(appData + path.Substring(0,path.LastIndexOf('.')), true);
            ZipFile.ExtractToDirectory(path, appData + path.Substring(0, path.LastIndexOf('.')));
            Import(appData + path.Substring(0, path.LastIndexOf('.')));
            System.IO.Directory.Delete(appData + path.Substring(0, path.LastIndexOf('.')), true);
        }
    }
}
