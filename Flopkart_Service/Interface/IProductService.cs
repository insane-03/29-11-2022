using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flopkart_Model;

namespace Flopkart_Service.Interface
{
    public interface IProductService
    {

        public List<ProductModel> GetAllProducts();

        public ProductModel AddProduct(ProductModel product);

        public ProductModel DeleteItem(int ProductId);


        public ProductModel GetItem(int ProductId);

        public ProductModel ChangeProduct(ProductModel product, int ProductId);
    }
}
