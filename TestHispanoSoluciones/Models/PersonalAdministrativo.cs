namespace TestHispanoSoluciones.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonalAdministrativo")]
    public partial class PersonalAdministrativo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonalAdministrativo()
        {
            Laboratorio = new HashSet<Laboratorio>();
        }

        [Key]
        public int Id_PersonalAdm { get; set; }

        [StringLength(50)]
        public string Nombres { get; set; }

        [StringLength(50)]
        public string Apellidos { get; set; }

        [StringLength(50)]
        public string DNI { get; set; }

        public int? Id_Rol { get; set; }

        public int? Id_Status { get; set; }

        public int? Id_Turno { get; set; }

        public int? Id_Departamento { get; set; }

        public virtual Departamento Departamento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Laboratorio> Laboratorio { get; set; }

        public virtual Rol Rol { get; set; }

        public virtual Status Status { get; set; }

        public virtual Turno Turno { get; set; }
    }
}
