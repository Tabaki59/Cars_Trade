//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cars_Trade.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ID_статуса_сделки
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ID_статуса_сделки()
        {
            this.Trades = new HashSet<Trades>();
        }
    
        public byte ID_статуса_сделки1 { get; set; }
        public string Статус_сделки { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trades> Trades { get; set; }
    }
}
