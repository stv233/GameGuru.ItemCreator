using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        

    }
}
