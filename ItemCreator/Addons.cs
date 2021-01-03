using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemCreator
{
    static class Addons
    {
        /// <summary>
        /// Returns a list of the names of all included addons.
        /// </summary>
        static public List<string> AddonsList
        {
            get
            {
                var result = new List<string>();

                if (new Properties.Addons().MusicDiscs)
                {
                    result.Add("MusicDiscs");
                }

                return result;
            }
        }

        /// <summary>
        /// Checks if addon is enabled
        /// </summary>
        /// <param name="addon">Addon</param>
        /// <returns></returns>
        static public bool Enabled(string addon)
        {
            return AddonsList.Contains(addon);
        }
    }
}
