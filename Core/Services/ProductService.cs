using Application.Interface;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProductService
    {
        Task<bool> CreateProduct(Product productDetails);

        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProductById(int productId);

        Task<bool> UpdateProduct(Product productDetails);

        Task<bool> DeleteProduct(int productId);
    }
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;


        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateProduct(Product productDetails)
        {
            if (productDetails != null)
            {
                await _unitOfWork.Products.Add(productDetails);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
        [HttpDelete("{productId}")]
        public async Task<bool> DeleteProduct(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.Products.GetById(productId);
                if (productDetails != null)
                {
                    _unitOfWork.Products.Delete(productDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _unitOfWork.Products.GetAll();
        }

        public async  Task<Product> GetProductById(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.Products.GetById(productId);
                if (productDetails != null)
                {
                    return productDetails;
                }
            }
            return null;
        }
        [HttpPut]
        public async Task<bool> UpdateProduct(Product productDetails)
        {
            if (productDetails != null)
            {
                var product = await _unitOfWork.Products.GetById(productDetails.Id);
                if (product != null)
                {
                    product.ProductName = productDetails.ProductName;
                    product.ProductDescription = productDetails.ProductDescription;
                    product.ProductPrice = productDetails.ProductPrice;

                    _unitOfWork.Products.Update(product);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }


    }
}
