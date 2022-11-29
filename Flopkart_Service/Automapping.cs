using AutoMapper;
using Flopkart_Repository.MongoEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flopkart_Model;

namespace Flopkart_Service
{
    public class Automapping :Profile
    {
        public Automapping()
        {
            CreateMap<MongoProducts, ProductModel>().ReverseMap();
        }
    }
}
