using System.Collections.Generic;

namespace PoprawaKolokwium2.DTO
{
    public class SomeTeam
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public virtual Organization Organization { get; set; }
        public string OrganizationName { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual ICollection<Member>Members { get; set; }
    }
}