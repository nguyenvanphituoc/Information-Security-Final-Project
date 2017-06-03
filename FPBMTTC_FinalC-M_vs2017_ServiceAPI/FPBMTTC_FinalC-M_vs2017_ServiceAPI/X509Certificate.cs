//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FPBMTTC_FinalC_M_vs2017_ServiceAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class X509Certificate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public X509Certificate()
        {
            this.PersonalDatas = new HashSet<PersonalData>();
        }
    
        public int id { get; set; }
        public double version { get; set; }
        public string serial_number { get; set; }
        public string signature_algorithm { get; set; }
        public string issuer_name { get; set; }
        public string validity_period { get; set; }
        public string subject_name { get; set; }
        public string public_key { get; set; }
        public string extensions { get; set; }
        public string signature { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalData> PersonalDatas { get; set; }
    }
}