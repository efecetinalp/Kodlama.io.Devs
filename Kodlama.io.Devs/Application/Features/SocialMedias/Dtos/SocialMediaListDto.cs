using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Dtos
{
    public class SocialMediaListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlAddress { get; set; }
        public string UserName { get; set; }
    }
}
