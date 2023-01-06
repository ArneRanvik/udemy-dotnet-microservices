using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductAPI.DbContexts;
using ProductAPI.Models;
using ProductAPI.Models.DTOs;

namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<ProductDTO>> CreateUpdateProduct(ProductDTO productDTO)
        {
            var response = new ResponseDTO<ProductDTO>();

            try
            {
                Product product = _mapper.Map<ProductDTO, Product>(productDTO);
                if (product.ProductId > 0)
                {
                    _context.Products.Update(product);
                    response.Message = "Product was updated.";
                }
                else
                {
                    _context.Products.Add(product);
                    response.Message = "Product was added.";
                }
                await _context.SaveChangesAsync();

                response.Result = _mapper.Map<Product, ProductDTO>(product);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Failed to create or update product.";
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return response;
        }

        public async Task<ResponseDTO<bool>> DeleteProduct(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product == null) 
                {
                    response.Message = "Product does not exist, unable to delete.";
                    response.Result = false;
                    return response;
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                response.Message = $"Product with id: {id} was deleted.";
                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Failed to delete product.";
                response.ErrorMessages = new List<string>() { ex.ToString() };
                response.Result = false;
            }

            return response;
        }

        public async Task<ResponseDTO<ProductDTO>> GetProductById(int id)
        {
            var response = new ResponseDTO<ProductDTO>();

            try
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product == null)
                {
                    response.Success = false;
                    response.Message = "Product does not exist.";
                    return response;
                }
                response.Message = "Product found.";
                response.Result = _mapper.Map<ProductDTO>(product);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Failed to retrieve the product.";
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return response;
        }

        public async Task<ResponseDTO<List<ProductDTO>>> GetProducts()
        {
            var response = new ResponseDTO<List<ProductDTO>>();

            try
            {
                List<Product> productList = await _context.Products.ToListAsync();
                response.Message = "List of all products fetched successfully.";
                response.Result = _mapper.Map<List<ProductDTO>>(productList);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Failed to retrieve the products.";
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return response;
            
        }
    }
}
