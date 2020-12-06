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
    /// AIS inventory item.
    /// </summary>
    class AISItem : Item
    {
        /// <summary>
        /// Item type.
        /// </summary>
        public UInt16 @Type { get; set; }

        /// <summary>
        /// Item effect.
        /// </summary>
        public string Effect { get; set; }

        /// <summary>
        /// Effect count.
        /// </summary>
        public int EffectCount { get; set; }

        /// <summary>
        /// Item image.
        /// </summary>
        public System.Drawing.Image Icon { get; set; }

        /// <summary>
        /// Can delete item.
        /// </summary>
        public bool CanDeleted { get; set; }

        /// <summary>
        /// Item Description.
        /// </summary>
        public string Description { get; set; } 

        /// <summary>
        /// AIS inventory item.
        /// </summary>
        /// <param name="name">Item name.</param>
        public AISItem(string name) : base(name) { }

        /// <summary>
        /// AIS inventory item.
        /// </summary>
        /// <param name="name">Item name</param>
        /// <param name="type">Item type</param>
        /// <param name="effect">Item effect</param>
        /// <param name="effectCount">Effect count</param>
        /// <param name="icon">Item image</param>
        /// <param name="canDeleted">Can delete item</param>
        /// <param name="description">Item Description</param>
        public AISItem(string name, UInt16 @type, string effect, int effectCount, System.Drawing.Image icon, bool canDeleted, string description) : base(name)
        {
            @Type = type;
            Effect = effect;
            EffectCount = effectCount;
            Icon = icon;
            CanDeleted = canDeleted;
            Description = description;
        }

        /// <summary>
        /// Exports an item.
        /// </summary>
        /// <param name="path">Path</param>
        public override void Export(string path)
        {
            Directory.Delete(path + "\\" + Name,true);
            Directory.CreateDirectory(path + "\\" + Name);

            using (var fileStream = new FileStream(path + "\\" + Name + "\\ini.dat", System.IO.FileMode.Create))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine("ItemType=" + @Type.ToString());
                    streamWriter.WriteLine("ItemEffect=" + Effect.ToString());
                    streamWriter.WriteLine("EffectCount=" + EffectCount.ToString());
                    streamWriter.WriteLine("Icon=img.png");
                    streamWriter.WriteLine("CanDeleted=" + Convert.ToInt32(CanDeleted).ToString());
                    streamWriter.WriteLine("Description=des.txt");
                }
            }

            using (var fileStream = new FileStream(path + "\\" + Name + "\\img.png", System.IO.FileMode.Create))
            {
                Icon.Save(fileStream, System.Drawing.Imaging.ImageFormat.Png);
            }

            using (var fileStream = new FileStream(path + "\\" + Name + "\\des.txt", System.IO.FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(Description);
                }
            }

        }

        /// <summary>
        /// Import item.
        /// </summary>
        /// <param name="path">Path</param>
        public override void Import(string path)
        {
            Name = path.Substring(path.LastIndexOf('\\') + 1);
            string[] fileString = File.ReadAllLines(path + "\\ini.dat");
            foreach (string line in fileString)
            {
                if (line.Contains("ItemType"))
                {
                    @Type = Convert.ToUInt16(line.Substring(line.IndexOf('=') + 1));
                }
                else if (line.Contains("ItemEffect"))
                {
                    Effect = line.Substring(line.IndexOf('=') + 1);
                }
                else if (line.Contains("EffectCount"))
                {
                    EffectCount = Convert.ToInt32(line.Substring(line.IndexOf('=') + 1));
                }
                else if (line.Contains("Icon"))
                {
                    using (var fileStream = new FileStream(path + "\\" + line.Substring(line.IndexOf('=') + 1),FileMode.Open))
                    {
                        Icon = System.Drawing.Image.FromStream(fileStream);
                    }
                }
                else if (line.Contains("CanDeleted"))
                {
                    CanDeleted = !(line.Substring(line.IndexOf('=') + 1) == "0");
                }
                else if (line.Contains("Description"))
                {
                    Description = File.ReadAllText(path + "\\" + line.Substring(line.IndexOf('=') + 1));
                }
            }

        }

        /// <summary>
        /// Save item to file.
        /// </summary>
        /// <param name="path">Path</param>
        public override void Save(string path)
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);

            Export(appData + "Temp\\");

            ZipFile.CreateFromDirectory(appData + "Temp\\" + Name, path + Name + ".asii");
        }

        /// <summary>
        /// Load item from file
        /// </summary>
        /// <param name="path">Path</param>
        public override void Open(string path)
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);

            System.IO.Directory.Delete(appData + path.Substring(0, path.LastIndexOf('.')), true);
            ZipFile.ExtractToDirectory(path, appData + path.Substring(0, path.LastIndexOf('.')));
            Import(appData + path.Substring(0, path.LastIndexOf('.')));
            System.IO.Directory.Delete(appData + path.Substring(0, path.LastIndexOf('.')), true);
        }
    }
}
