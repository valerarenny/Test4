namespace TestHispanoSoluciones.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Laboratorio")]
    public partial class Laboratorio
    {
        [Key]
        public int Id_Lab { get; set; }

        public int? Id_Asignado { get; set; }

        public int? Id_Status { get; set; }

        public int? Id_Encargado { get; set; }

        public int? CapMax { get; set; }

        public int? NroEquipos { get; set; }

        public int? Id_TipoLab { get; set; }

        public virtual Docente Docente { get; set; }

        public virtual PersonalAdministrativo PersonalAdministrativo { get; set; }

        public virtual Status Status { get; set; }

        public virtual TipoLab TipoLab { get; set; }
    }
}
