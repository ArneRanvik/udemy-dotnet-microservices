using ProductAPI.Models.DTOs;

namespace ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<ResponseDTO<List<ProductDTO>>> GetProducts();
        Task<ResponseDTO<ProductDTO>> GetProductById(int id);
        Task<ResponseDTO<ProductDTO>> CreateUpdateProduct(ProductDTO productDTO);
        Task<ResponseDTO<bool>> DeleteProduct(int id);
    }
}
