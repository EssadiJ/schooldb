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
    
    public partial class Table_Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_Teacher()
        {
            this.Table_class = new HashSet<Table_class>();
        }
    
        public int id { get; set; }
        public string full_name { get; set; }
        public string cin { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_class> Table_class { get; set; }
    }
}
