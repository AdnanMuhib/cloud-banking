//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CloudBanking.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BankTransaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BankTransaction()
        {
            this.Wallets = new HashSet<Wallet>();
        }
    
        public int TransactionID { get; set; }
        public int CustomerID { get; set; }
        public string TransactionType { get; set; }
        public int Amount { get; set; }
        public System.DateTime TransactionDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
