using Funding.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Funding.Data.Model
{
    public class PostWithLikes
    {
        public IEnumerable<Funding.Data.Model.Post> Posts {get; set;}
        public Like Like {get;set;}
    }
}
