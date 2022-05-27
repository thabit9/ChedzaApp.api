using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop
{
    public class Categories : EntityBase
    {
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Category Name")]
        public string CategoryName { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Description")]
        public string CategoryDesc { get; set; } = null!;
        public bool IsParent { get; set; }
        public int ParentId { get; set; }

        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(ParentId))]
        public Categories CategoryNavigation { get; set; } = null!;
        #endregion
        #region Navigation Properties(Retrieves Many Record)
        [InverseProperty(nameof(Product.CategoryNavigation))]
        public IEnumerable<Product>? Products { get; set; } = null!;
        #endregion

    }
}