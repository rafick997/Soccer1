//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Football.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Team1
    {
        public Team1()
        {
            this.Players = new HashSet<Player>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }
        public string Photo { get; set; }
    
        public virtual ICollection<Player> Players { get; set; }
    }
}
