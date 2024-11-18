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
    
    public partial class Trainers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainers()
        {
            this.TrainerActivities = new HashSet<TrainerActivities>();
            this.Trainings = new HashSet<Trainings>();
        }
    
        public int trainer_id { get; set; }
        public int sports_complex_id { get; set; }
        public string trainer_full_name { get; set; }
        public Nullable<bool> trainer_gender { get; set; }
        public string trainer_phone_number { get; set; }
    
        public virtual SportComplexes SportComplexes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainerActivities> TrainerActivities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainings> Trainings { get; set; }
    }
}