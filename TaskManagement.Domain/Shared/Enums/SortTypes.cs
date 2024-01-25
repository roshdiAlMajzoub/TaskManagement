using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Shared.Enums
{
    [Flags]
    public enum SortTypes
    {
        /// <summary>
        /// Ascending
        /// </summary>
        [EnumMember(Value = "Ascending")]
        None,

        /// <summary>
        /// Ascending
        /// </summary>
        [EnumMember(Value = "Ascending")]
        Ascending,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "Descending")]
        Descending
    }
}
