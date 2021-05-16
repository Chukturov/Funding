using Funding.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Funding.Data.Model
{
    public class CampaignImgs : Image
    {
        public Campaign campaign {get;set;}
    }
}
