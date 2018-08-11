using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.ReadSide.WCF
{
    public class ArticlesService : IArticlesService
    {
        public string Get()
        {
            return "hello";
        }
    }
}
