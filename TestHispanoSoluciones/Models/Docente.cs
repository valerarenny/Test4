namespace TestHispanoSoluciones.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Docente")]
    public partial class Docente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Docente()
        {
            Laboratorio = new HashSet<Laboratorio>();
        }

        [Key]
        public int Id_Docente { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellido { get; set; }

        [StringLength(12)]
        public string DNI { get; set; }

        public int? Id_Status { get; set; }

        public int? Id_Rol { get; set; }

        public int? Id_Turno { get; set; }

        public int? Id_Asignacion { get; set; }

        public virtual Asignacion Asignacion { get; set; }

        public virtual Rol Rol { get; set; }

        public virtual Status Status { get; set; }

        public virtual Turno Turno { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Laboratorio> Laboratorio { get; set; }
    }
}
