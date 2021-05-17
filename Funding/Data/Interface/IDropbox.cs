using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funding.Data.Interface
{
    public interface IDropbox
    {
        Task<string> getImgByUrl(string Path);
    }
}
