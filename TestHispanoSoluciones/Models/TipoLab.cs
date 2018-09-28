namespace TestHispanoSoluciones.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoLab")]
    public partial class TipoLab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoLab()
        {
            Laboratorio = new HashSet<Laboratorio>();
        }

        [Key]
        public int Id_TipoLab { get; set; }

        [StringLength(50)]
        public string Tipo_Lab { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Laboratorio> Laboratorio { get; set; }
    }
}
