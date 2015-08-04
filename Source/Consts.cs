using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMsgPack
{
    public enum MsgPackType
    {
        Unknown = 0,
        Null,
        Map,
        Array,
        String,
        Integer,
        UInt64,
        Boolean,
        Single,
        Double,
        DateTime,
        Binary,
    }
}
