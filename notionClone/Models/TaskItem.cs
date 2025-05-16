using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notionClone.Models
{
    public class askItem
    {
        public string Description { get; set; } = "";
        public bool IsDone { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
    }


}
