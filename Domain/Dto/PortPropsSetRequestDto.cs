using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class PortPropsSetRequestDto
    {
        public long Id { get; set; }
        public long EspPortDefId { get; set; }
        public  string? Title { get; set; }

    }
}
