namespace TestHispanoSoluciones.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Departamento")]
    public partial class Departamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Departamento()
        {
            PersonalAdministrativo = new HashSet<PersonalAdministrativo>();
        }

        [Key]
        public int Id_Departamento { get; set; }

        [Column("Departamento")]
        [StringLength(10)]
        public string Departamento1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalAdministrativo> PersonalAdministrativo { get; set; }
    }
}
