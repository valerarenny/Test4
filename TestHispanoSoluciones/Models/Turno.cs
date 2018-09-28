namespace TestHispanoSoluciones.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Turno")]
    public partial class Turno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Turno()
        {
            Docente = new HashSet<Docente>();
            PersonalAdministrativo = new HashSet<PersonalAdministrativo>();
        }

        [Key]
        public int Id_Turno { get; set; }

        public TimeSpan? Hora_Ini { get; set; }

        public TimeSpan? Hora_Fin { get; set; }

        public int? Dia_Desde { get; set; }

        public int? Dia_Hasta { get; set; }

        public virtual Dias Dias { get; set; }

        public virtual Dias Dias1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Docente> Docente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalAdministrativo> PersonalAdministrativo { get; set; }
    }
}
