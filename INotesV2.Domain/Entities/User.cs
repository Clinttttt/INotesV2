using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? user_name { get; set; }
        public string? refresh_token { get; set; }
        public DateTime refresh_token_expiry { get; set; }
        public string? email { get; set; }
        public string? provider { get; set; }
        public string? provider_id { get; set; }
        public DateTime created_at { get; set; }
        public string? profile_photo_url { get; set; }
        public byte[]? profile_photo_bytes { get; set; }


    }
}
