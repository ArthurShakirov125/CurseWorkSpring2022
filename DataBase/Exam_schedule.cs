//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdmissionsCommittee.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exam_schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exam_schedule()
        {
            this.Exam_statement = new HashSet<Exam_statement>();
        }
    
        public int Id { get; set; }
        public string Classroom { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Flow Flow { get; set; }
        public virtual Subject Subject { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam_statement> Exam_statement { get; set; }
    }
}
