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
    
    public partial class Consultation
    {
        public int Id { get; set; }
        public string Classroom { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Flow Flow { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
