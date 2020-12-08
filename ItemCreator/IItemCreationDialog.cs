using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemCreator
{
    interface IItemCreationDialog<out T> where T : IItem
    {
        T Item { get; }
        bool CanChangeName { get; set; }
        System.Windows.Forms.DialogResult ShowDialog();
    }
}
