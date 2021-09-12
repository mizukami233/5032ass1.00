using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace _5032ass1._00.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BookingSet> BookingSets { get; set; }
        public virtual DbSet<ClassSet> ClassSets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassSet>()
                .HasMany(e => e.BookingSets)
                .WithRequired(e => e.ClassSet)
                .HasForeignKey(e => e.Class_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
