using Dropbox.Api;
using Funding.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funding.Data.Repository
{
    public class DropboxRepository : IDropbox
    {
        private static string token = "QAY0acSlThsAAAAAAAAAAT5434MivLSp9jW9JZcy6Q6E5apgXHpirN0MiLmqDoE_";
        public async Task<string> getImgByUrl(string Path)
        {
            using (var dbx = new DropboxClient(token))
            {
                var TemporaryLink = await dbx.Files.GetTemporaryLinkAsync(Path);
                return TemporaryLink.Link;
            }
        }
    }
}
