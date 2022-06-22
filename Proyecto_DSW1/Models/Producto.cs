//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_DSW1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.PedidoDetalle = new HashSet<PedidoDetalle>();
        }
    
        public int idProducto { get; set; }
        public Nullable<int> idCategoria { get; set; }
        [Required(ErrorMessage = "Ingrese nombre producto")]
        public string nom_prod { get; set; }

        [Required(ErrorMessage = "Ingrese precio")]
        public double pre_prod { get; set; }
        [Required(ErrorMessage = "Ingrese stock")]
        public int sto_prod { get; set; }
        [Required(ErrorMessage = "Ingrese Imagen")]
        public string img_prod { get; set; }
        [Required(ErrorMessage = "Ingrese descripcion de producto")]
        public string des_prod { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; }
    }
}
