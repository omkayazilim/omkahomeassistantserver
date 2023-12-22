using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class ReleChannelListItemDto : ReleChannelModelBase
    {
        public EspPortDefListItemDto? PortDef { get; set; }
    }
}
