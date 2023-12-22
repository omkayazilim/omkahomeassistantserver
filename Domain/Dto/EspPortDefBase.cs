using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class EspPortDefBase
    {
        public long Id { get; set; }
        public int PortNumber { get; set; }
        public string? PortKey { get; set; }
        public string? PortDesc { get; set; }
        public bool IsActive { get; set; }  
    }
}
