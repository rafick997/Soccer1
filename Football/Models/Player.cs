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
    
    public partial class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int TeamID { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Photo { get; set; }
        public string Position { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<int> Weight { get; set; }
        public string Country { get; set; }
    
        public virtual Team1 Team1 { get; set; }
    }
}
