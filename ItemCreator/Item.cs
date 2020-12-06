using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ItemCreator
{
    class Item
    {
        public string Name { get;  private set; }

        public virtual void CreateINI(string path)
        {
            using (FileStream fileStream = new FileStream(path + "ini.dat", FileMode.Create))
            {}
        }
    }
}
