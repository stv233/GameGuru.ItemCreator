﻿using System;
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
    class AISItem : IItem
    {
        /// <summary>
        /// Item name.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Item type.
        /// </summary>
        public UInt16 @Type { get; set; }

        /// <summary>
        /// Item effect.
        /// </summary>
        public object Effect { get; set; }

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
        public AISItem(string name)
        {
            if (name.Length >= 1)
            {
                Name = name;
            }
            else
            {
                throw new System.Exception("The name cannot be empty.");
            }
        }

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
        public AISItem(string name, UInt16 @type, string effect, int effectCount, System.Drawing.Image icon, bool canDeleted, string description)
        {
            if (name.Length > 1)
            {
                Name = name;
            }
            else
            {
                throw new System.Exception("The name cannot be empty.");
            }

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
        public void Export(string path)
        {
            try
            {
                try
                {
                    Directory.Delete(path + "\\" + Name, true);
                }
                catch { }
                Directory.CreateDirectory(path + "\\" + Name);

                using (var fileStream = new FileStream(path + "\\" + Name + "\\init.dat", System.IO.FileMode.Create))
                {
                    using (var streamWriter = new StreamWriter(fileStream))
                    {
                        foreach (string addon in Addons.AddonsList)
                        {
                            streamWriter.WriteLine("ADDON:" + addon);
                        }
                        streamWriter.WriteLine("ItemType=" + @Type.ToString());
                        if ((Addons.Enabled("MusicDiscs")) && (@Type == 4))
                        {
                            File.WriteAllBytes(path + "\\" + Name + "\\music.wav", (byte[])Effect);
                            streamWriter.WriteLine("ItemEffect=music.wav");
                        }
                        else
                        {
                            streamWriter.WriteLine("ItemEffect=" + Effect.ToString());
                        }
                        streamWriter.WriteLine("EffectCount=" + EffectCount.ToString());
                        streamWriter.WriteLine("Icon=img.png");
                        streamWriter.WriteLine("CanDeleted=" + Convert.ToInt32(CanDeleted).ToString());
                        streamWriter.WriteLine("Description=des.txt");
                    }
                }

                using (var fileStream = new FileStream(path + "\\" + Name + "\\img.png", System.IO.FileMode.Create))
                {
                    if (Icon != null)
                    {
                        var bitmap = new System.Drawing.Bitmap(Icon);
                        bitmap.Save(fileStream, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else
                    {
                        Icon = new System.Drawing.Bitmap(1, 1);
                        Icon.Save(fileStream, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }

                using (var fileStream = new FileStream(path + "\\" + Name + "\\des.txt", System.IO.FileMode.Create))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.Write(Description);
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred while exporting the item.\n" +
                    e.Message + "\nTry exporting the item again.", "Export error",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Import item.
        /// </summary>
        /// <param name="path">Path</param>
        public void Import(string path)
        {
            try
            {
                Name = path.Substring(path.LastIndexOf('\\') + 1);
                string[] fileString = File.ReadAllLines(path + "\\init.dat");
                foreach (string line in fileString)
                {
                    if (line.Contains("ADDON:"))
                    {
                        string[] addon = line.Split(':');

                        if (!Addons.Enabled(addon[1]))
                        {
                            if (System.Windows.Forms.MessageBox.Show("The item was created or modified using an unplugged \"" + addon[1] +"\" addon. Errors may occur while importing continues. Do you want to continue?",
                                "Unplugged addon",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                            {
                                return;
                            }
                        }
                    }

                    if (line.Contains("ItemType"))
                    {
                        @Type = Convert.ToUInt16(line.Substring(line.IndexOf('=') + 1));
                    }
                    else if (line.Contains("ItemEffect"))
                    {
                        if ((Addons.Enabled("MusicDiscs")) && (@Type == 4))
                        {
                            Effect = File.ReadAllBytes(path + "\\" + line.Substring(line.IndexOf('=') + 1));
                        }
                        else
                        {
                            Effect = line.Substring(line.IndexOf('=') + 1);
                        }
                    }
                    else if (line.Contains("EffectCount"))
                    {
                        EffectCount = Convert.ToInt32(line.Substring(line.IndexOf('=') + 1));
                    }
                    else if (line.Contains("Icon"))
                    {
                        using (var fileStream = new FileStream(path + "\\" + line.Substring(line.IndexOf('=') + 1), FileMode.Open))
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
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred while importing an item.\n" +
                    e.Message + "\nCheck the format you are importing to see if you are using the wrong type of project.", "Export error",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save item to file.
        /// </summary>
        /// <param name="path">Path</param>
        public void Save(string path)
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);

            Export(appData + "Temp\\");

            ZipFile.CreateFromDirectory(appData + "Temp\\" + Name, path + Name + ".asii");
        }

        /// <summary>
        /// Load item from file
        /// </summary>
        /// <param name="path">Path</param>
        public void Open(string path)
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);

            System.IO.Directory.Delete(appData + path.Substring(0, path.LastIndexOf('.')), true);
            ZipFile.ExtractToDirectory(path, appData + path.Substring(0, path.LastIndexOf('.')));
            Import(appData + path.Substring(0, path.LastIndexOf('.')));
            System.IO.Directory.Delete(appData + path.Substring(0, path.LastIndexOf('.')), true);
        }
    }
}
