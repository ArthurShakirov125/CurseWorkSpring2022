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
    
    public partial class Enrollee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Passport { get; set; }
        public string Education { get; set; }
        public System.DateTime Graduation { get; set; }
        public bool Golden_medal { get; set; }
        public bool Silver_medal { get; set; }
    
        public virtual Exam_sheet Exam_sheet { get; set; }
    }
}
