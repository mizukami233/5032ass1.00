namespace _5032ass1._00.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClassSet")]
    public partial class ClassSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClassSet()
        {
            BookingSets = new HashSet<BookingSet>();
        }

        public int Id { get; set; }

        [Required]
        public string Class_Name { get; set; }

        [Required]
        public string Class_Des { get; set; }

        [Required]
        public string Class_Rate { get; set; }

        [Required]
        public string Class_Lng { get; set; }

        [Required]
        public string Class_Lat { get; set; }

        [Column(TypeName = "date")]
        public DateTime Class_Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingSet> BookingSets { get; set; }
    }
}
