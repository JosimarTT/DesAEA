using Lab12_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Lab12_WebAPIService.Repository;

namespace Lab12_WebAPIService.Controllers
{
    public class ShowroomController : ApiController
    {
        // GET : Showroom
        [HttpGet]
        public JsonResult<List<Models.Product>> GetAllProducts()
        {
            EntityMapper<Lab12_DataAccessLayer.Product, Models.Product> mapObj = new EntityMapper<Lab12_DataAccessLayer.Product, Models.Product>();
            List<Lab12_DataAccessLayer.Product> prodList = DAL.GetAllProducts();
            List<Models.Product> products = new List<Models.Product>();
            foreach (var item in prodList)
            {
                products.Add(mapObj.Translate(item));
            }
            return Json<List<Models.Product>>(products);
        }

        [HttpGet]
        public JsonResult<Models.Product> GetProduct(int id)
        {
            EntityMapper<Lab12_DataAccessLayer.Product, Models.Product> mapObj = new EntityMapper<Lab12_DataAccessLayer.Product, Models.Product>();
            Lab12_DataAccessLayer.Product dalProduct = DAL.GetProduct(id);
            Models.Product products = new Models.Product();
            products = mapObj.Translate(dalProduct);
            return Json<Models.Product>(products);
        }

        [HttpPost]
        public bool InsertProduct(Models.Product product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<Models.Product, Lab12_DataAccessLayer.Product> mapObj = new EntityMapper<Models.Product, Lab12_DataAccessLayer.Product>();
                Lab12_DataAccessLayer.Product productObj = new Lab12_DataAccessLayer.Product();
                productObj = mapObj.Translate(product);
                status = DAL.InsertProduct(productObj);
            }
            return status;
        }

        [HttpPut]
        public bool UpdateProduct(Models.Product product)
        {
            EntityMapper<Models.Product, Lab12_DataAccessLayer.Product> mapObj = new EntityMapper<Models.Product, Lab12_DataAccessLayer.Product>();
            Lab12_DataAccessLayer.Product productObj = new Lab12_DataAccessLayer.Product();
            productObj = mapObj.Translate(product);
            var status = DAL.UpdateProduct(productObj);
            return status;
        }

        [HttpDelete]
        public bool DeleteProduct(int id)
        {
            var status = DAL.DeleteProduct(id);
            return status;
        }
    }
}
