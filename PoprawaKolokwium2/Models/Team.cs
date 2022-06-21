using System.Collections.Generic;

namespace PoprawaKolokwium2
{
    public class Team
    {
       
            public int TeamID { get; set; }
            public int OrganizationID { get; set; }
            public virtual  Organization Organization{ get; set; }
            public string TeamName { get; set; }
            
            public string TeamDescription { get; set; }
            public virtual ICollection<File> Files {get; set;}
            public virtual ICollection<Membership> Memberships { get; set; }
        
 
    }
}