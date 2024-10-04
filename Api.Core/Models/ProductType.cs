using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Models
{
    public class ProductType : BaseModel
    {
        public string Name { get; set; }


    }
}
