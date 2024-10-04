using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Core.Models
{
    public class Product : BaseModel
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }


        public ProductType Type { get; set; }

        public Brand Brand { get; set; }

    }
}
