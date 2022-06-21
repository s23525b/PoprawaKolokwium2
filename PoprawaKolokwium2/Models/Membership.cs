using System;
using System.Collections.Generic;

namespace PoprawaKolokwium2
{
    public class Membership
    {
      
            public virtual Member Member { get; set; }
            public int MemberID { get; set; }
            public int TeamID { get; set; }
            public virtual Team Team { get; set; }
            public DateTime MembershipDate { get; set; }
            
            
        
     
    }
}