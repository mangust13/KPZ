//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab_03.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrainerActivities
    {
        public int trainer_activity_id { get; set; }
        public int trainer_id { get; set; }
        public int activity_type_id { get; set; }
    
        public virtual ActivityTypes ActivityTypes { get; set; }
        public virtual Trainers Trainers { get; set; }
    }
}
