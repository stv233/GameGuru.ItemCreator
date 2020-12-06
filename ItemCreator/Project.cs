using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace ItemCreator
{
    class Project
    {
        /// <summary>
        /// Project name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of items included in project.
        /// </summary>
        public virtual Dictionary<string, IItem> ListOfItems { get; set; }

        /// <summary>
        /// Item creator project.
        /// </summary>
        /// <param name="name"></param>
        public Project(string name)
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            Name = name;

            Directory.Delete(appData + "\\Projects\\" + Name, true);
            Directory.CreateDirectory(appData + "\\Projects\\" + Name);

            ListOfItems = new Dictionary<string, IItem>();
        }

        ~Project()
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            Directory.Delete(appData + "\\Projects\\" + Name, true);
        }

        /// <summary>
        /// Save project to file.
        /// </summary>
        /// <param name="path">Path</param>
        public void Save(string path)
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            using (var fileStream = new FileStream(appData + "\\Projects\\" + Name +"\\ProjectIni", FileMode.Create))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    foreach (string itemName in ListOfItems.Keys)
                    {
                        streamWriter.WriteLine(itemName);
                    }
                }
            }

            ZipFile.CreateFromDirectory(appData + "\\Projects\\" + Name + ".iip", path);
        }

        /// <summary>
        /// Opens a project from a file.
        /// </summary>
        /// <param name="path"></param>
        public void Open(string path)
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            Directory.Delete(appData + "\\Projects\\" + Name, true);

            Name = path.Substring(path.LastIndexOf("\\") + 1, path.LastIndexOf(".") - path.LastIndexOf("\\") - 1);
            ZipFile.ExtractToDirectory(path, appData + "\\Projects\\" + Name);
            ListOfItems.Clear();

            string[] ProjectIni = File.ReadAllLines(appData + "\\Projects\\" + Name + "\\ProjectIni");

            foreach (string itemName in ProjectIni)
            {
                IItem item = new object() as IItem;
                item.Import(appData + "\\Projects\\" + Name + "\\" + itemName);
                ListOfItems.Add(itemName, item);
            }
        }

        /// <summary>
        /// Exports all items included in the project.
        /// </summary>
        /// <param name="path"></param>
        public void ExportAllItems(string path)
        {
            foreach (Item item in ListOfItems.Values)
            {
                item.Export(path);
            }
        }
    }
}
