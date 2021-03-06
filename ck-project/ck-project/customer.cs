//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ck_project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            this.leads = new HashSet<lead>();
        }
    
        public int customer_number { get; set; }
        [Required(ErrorMessage = "The first name is required")]
        [MinLength(2, ErrorMessage = "The first name is too short")]
        [MaxLength(19, ErrorMessage = "The first name must be less than 20 characters")]
        public string customer_firstname { get; set; }

        [MaxLength(19, ErrorMessage = "The middle name must be less than 20 characters")]
        public string customer_middlename { get; set; }
        [Required(ErrorMessage = "The last name is required")]
        [MinLength(2, ErrorMessage = "The last name is too short")]
        [MaxLength(19, ErrorMessage = "The last name must be less than 20 characters")]
        public string customer_lastname { get; set; }
        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string phone_number { get; set; }
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string second_phone_number { get; set; }
        public string email { get; set; }
        public Nullable<int> address_number { get; set; }
        public bool deleted { get; set; }
    
        public virtual address address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lead> leads { get; set; }
    }
}
