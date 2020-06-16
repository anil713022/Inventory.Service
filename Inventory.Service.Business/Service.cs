using Inventory.Service.Repositories;
using System;
using System.Net.Http.Headers;

namespace Inventory.Service.Business
{

    public class Services: IService
    {
        private readonly IRepositorie _iRepositorie;
        public Services (IRepositorie iRepositorie)
        {
            _iRepositorie = iRepositorie;
        }
       public  string GetName()
        {
            return "Anil";
        }
    }
}
