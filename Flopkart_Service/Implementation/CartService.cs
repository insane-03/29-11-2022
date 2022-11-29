using AutoMapper;
using Flopkart_Model;
using Flopkart_Repository.Implementation;
using Flopkart_Repository.Interface;
using Flopkart_Repository.MongoEntity;
using Flopkart_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flopkart_Service.Implementation
{
    public class CartService :ICartService
    {
        private readonly ICartRepository _cartRepository;

        private readonly IMapper _mapper;
        public CartService(ICartRepository cartRepository, IMapper mapper) 
        {
            _cartRepository= cartRepository;
            _mapper= mapper;
        }


        public ProductModel SelectProduct(ProductModel product)
        {
            _cartRepository.BuyItems(_mapper.Map<MongoProducts>(product));
            return product;
        }
    }
}
