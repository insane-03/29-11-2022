using Flopkart_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flopkart_Service.Interface
{
    public interface ICartService
    {
        public ProductModel SelectProduct(ProductModel product);
    }
}
