using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoFrameworkCore.Xcavate
{
    public enum VerificationEnum
    {
        // Has to be here due to binding
        None,

        Loading,
        Pending,
        Verified,
        Rejected,
    }
}
