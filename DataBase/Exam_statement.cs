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
    
    public partial class Exam_statement
    {
        public int Id { get; set; }
        public Nullable<byte> Mark { get; set; }
        public Nullable<short> Points { get; set; }
        public string Enrolle_last_name { get; set; }
        public int Exam_sheet_number { get; set; }
    
        public virtual Exam_schedule Exam_schedule { get; set; }
    }
}
