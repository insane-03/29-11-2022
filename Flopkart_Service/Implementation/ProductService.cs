using Flopkart_Repository.Interface;
using Flopkart_Repository.MongoEntity;
using Flopkart_Service.Interface;
using Flopkart_Model;
using AutoMapper;

namespace Flopkart_Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public List<ProductModel> GetAllProducts()
        {
            List<MongoProducts> products = _productRepository.GetAllItems();
            var productsList = _mapper.Map<List<ProductModel>>(products);
            return productsList;


        }

        public ProductModel GetItem(int ProductId)
        {
            MongoProducts mongoProducts = _productRepository.GetoneProduct(ProductId);
            ProductModel product = _mapper.Map<ProductModel>(mongoProducts);
            return product;
        }

        public ProductModel AddProduct(ProductModel product)
        {
            _productRepository.InsertProduct(_mapper.Map<MongoProducts>(product));

            return product;
        }


        public ProductModel ChangeProduct(ProductModel product, int ProductId)
        {
            _productRepository.UpdateProduct(_mapper.Map<MongoProducts>(product),ProductId);
            return product;
        }

        public ProductModel DeleteItem(int ProductId)
        {
            MongoProducts mongoproduct = _productRepository.RemoveProduct(ProductId);
            ProductModel product = _mapper.Map<ProductModel>(mongoproduct);
            return product;
        }
        
    }
}
