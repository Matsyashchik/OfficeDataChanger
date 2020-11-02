using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDataChangerLibrary
{
    public sealed class FileData
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Opened { get; set; }
        public string Creator { get; set; }
        public string LastModifiedBy { get; set; }
        public ushort TotalEditingTime { get; set; }
        public ushort Revision { get; set; }
    }
}
