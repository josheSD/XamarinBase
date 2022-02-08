using System;
using System.Collections.Generic;
using System.Text;

namespace AppHuac.Models
{
    public class Menu
    {
        public Menu()
        {
            TargetType = typeof(Menu);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
