using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SocialMedia : Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UrlAddress { get; set; }
        public virtual User User { get; set; }

        public SocialMedia()
        {
        }

        public SocialMedia(int id, string name, string urlAddress, int userId):this()
        {
            Id = id;
            Name = name;
            UrlAddress = urlAddress;
            UserId = userId;
        }
    }
}
