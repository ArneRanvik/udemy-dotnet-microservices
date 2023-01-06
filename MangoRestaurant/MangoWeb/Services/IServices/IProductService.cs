﻿using MangoWeb.Models;

namespace MangoWeb.Services.IServices
{
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProuctByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDTO product);
        Task<T> UpdateProductAsync<T>(ProductDTO product);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
