//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace schoolDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table_students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_students()
        {
            this.Table_Attendnce = new HashSet<Table_Attendnce>();
            this.Table_class = new HashSet<Table_class>();
        }
    
        public int id { get; set; }
        public string full_name { get; set; }
        public Nullable<System.DateTime> age { get; set; }
        public string gender { get; set; }
        public Nullable<System.DateTime> date_in { get; set; }
        public Nullable<System.DateTime> date_out { get; set; }
        public Nullable<int> id_parent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_Attendnce> Table_Attendnce { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_class> Table_class { get; set; }
        public virtual Table_parents Table_parents { get; set; }
    }
}