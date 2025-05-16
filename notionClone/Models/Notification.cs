using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notionClone
{
    public class Notification
    {
        public DateTime DateTime { get; set; } 
        public string Message { get; set; } = string.Empty;
        public bool IsNotified { get; set; } = false; 
    }


}
