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
    /// Item creator project.
    /// </summary>
    class Project
    {
        /// <summary>
        /// Project types.
        /// </summary>
        public enum Types
        {
            AIS,
            Pro,
            Simple
        }

        /// <summary>
        /// Project name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of items included in project.
        /// </summary>
        public virtual Dictionary<string, IItem> ListOfItems { get; set; }

        /// <summary>
        /// Current project type.
        /// </summary>
        public Types @Type { get; set; }

        /// <summary>
        /// Item creator project.
        /// </summary>
        /// <param name="name"></param>
        public Project(string name)
        {
             string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Stv233\\ItemCreator\\";
            Name = name;

            try
            {
                Directory.Delete(appData + "\\Projects\\" + Name, true);
            }
            catch { }
            Directory.CreateDirectory(appData + "\\Projects\\" + Name);

            ListOfItems = new Dictionary<string, IItem>();
        }

        ~Project()
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Stv233\\ItemCreator\\";
            try
            {
                Directory.Delete(appData + "\\Projects\\" + Name, true);
            }
            catch { }
        }

        /// <summary>
        /// Save project to file.
        /// </summary>
        /// <param name="path">Path</param>
        public void Save(string path)
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Stv233\\ItemCreator\\";
            using (var fileStream = new FileStream(appData + "\\Projects\\" + Name +"\\ProjectData", FileMode.Create))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(Type.ToString());
                    foreach (string itemName in ListOfItems.Keys)
                    {
                        streamWriter.WriteLine(itemName);
                    }
                }
            }

            try
            {
                ZipFile.CreateFromDirectory(appData + "\\Projects\\" + Name, path);
            }
            catch
            {
                File.Delete(path);
                ZipFile.CreateFromDirectory(appData + "\\Projects\\" + Name, path);
            }
        }

        /// <summary>
        /// Opens a project from a file.
        /// </summary>
        /// <param name="path"></param>
        public void Open(string path)
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Stv233\\ItemCreator\\";

            Name = path.Substring(path.LastIndexOf("\\") + 1, path.LastIndexOf(".") - path.LastIndexOf("\\") - 1);
            try
            {
                Directory.Delete(appData + "\\Projects\\" + Name, true);
            }
            catch { }
            ZipFile.ExtractToDirectory(path, appData + "\\Projects\\" + Name);
            ListOfItems.Clear();

            string[] ProjectData = File.ReadAllLines(appData + "\\Projects\\" + Name + "\\ProjectData");

            if (ProjectData[0] == "AIS")
            {
                Type = Types.AIS;
            }
            else if (ProjectData[0] == "Pro")
            {
                Type = Types.Pro;
            }
            else if (ProjectData[0] == "Simple")
            {
                Type = Types.Simple;
            }
            else
            {
                throw new System.Exception("Unknown project type");
            }

            Array.Copy(ProjectData, 1, ProjectData, 0, ProjectData.Length - 1);
            Array.Resize<string>(ref ProjectData, ProjectData.Length - 1);

            foreach (string itemName in ProjectData)
            {
                if (Type == Types.AIS)
                {
                    AISItem item = new AISItem(itemName);
                    item.Import(appData + "\\Projects\\" + Name + "\\" + itemName);
                    ListOfItems.Add(itemName, item);
                }
                else if (Type == Types.Simple)
                {
                    SimpleItem item = new SimpleItem(itemName);
                    item.Import(appData + "\\Projects\\" + Name + "\\" + itemName);
                    ListOfItems.Add(itemName, item);
                }
            }
        }

        /// <summary>
        /// Exports all items included in the project.
        /// </summary>
        /// <param name="path"></param>
        public void ExportAllItems(string path)
        {
            foreach (IItem item in ListOfItems.Values)
            {
                item.Export(path);
            }
        }

        /// <summary>
        /// Adds an item to the project.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(IItem item)
        {
             string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Stv233\\ItemCreator\\";
            ListOfItems[item.Name] = item;
            item.Export(appData + "\\Projects\\" + Name);
        }
    }
}
