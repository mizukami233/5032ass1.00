namespace _5032ass1._00.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookingSet")]
    public partial class BookingSet
    {
        public int Id { get; set; }

        [Required]
        public string Booking_Name { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}",ApplyFormatInEditMode = true)]
        public DateTime Booking_Date { get; set; }

        [Required]
        [EmailAddress]
        public string Booking_Email { get; set; }

        [Required]
        public string User_Id { get; set; }
  
        public string Booking_Rate { get; set; }

        public int Class_Id { get; set; }

        public virtual ClassSet ClassSet { get; set; }
    }
}
