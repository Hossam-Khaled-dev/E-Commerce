
using Api.DTOs;
using Api.Helpers;
using AutoMapper;
using Core.Entites;
using Core.interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        // private readonly IProducrtRepo _producrtRepo;

        private readonly IGenericRepo<ProductBrand> _brandRepo;
        private readonly IGenericRepo<Product> _ProductRepo;
        private readonly IGenericRepo<ProductType> _TypeRepo;
        private readonly IMapper _Mapper;

        public ProductController(IGenericRepo<ProductBrand> brandRepo, IGenericRepo<Product> productRepo, IGenericRepo<ProductType> typeRepo, IMapper mapper) 
        {
            _Mapper = mapper;
            _brandRepo = brandRepo;
            _ProductRepo = productRepo;
            _TypeRepo = typeRepo;
        }

        [HttpGet]

        public async Task<ActionResult<Pagination<ProductDTO>>> GetProuduct([FromQuery]ProductSpecParam productSpecParam)
        {

            var specific = new ProductSpecification(productSpecParam);
            var countspec = new ProductWithFiltersForCountSepecification(productSpecParam);
            var totlaitem = await _ProductRepo.CountAsync(countspec);

            var prouducts = await _ProductRepo.ListAsync(specific);
            var data = _Mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(prouducts);

            return Ok(new Pagination<ProductDTO>(productSpecParam.PageIndex, productSpecParam.PageSize, totlaitem, data));
            


        }

        [HttpGet("{id}")]


        public async Task<ActionResult<ProductDTO>> GetByID(int id)
        {


            var specific = new ProductSpecification(id);
            if (id <= 0 && id !=null)
            {
                return BadRequest("Invalid product ID. The ID must be greater than zero.");
            }

            var product = await _ProductRepo.GetEntityWithSpec(specific);

            if (product == null)
            {
                return NotFound();

            }


            //return Ok(new ProductDTO()
            //{
            //    Id=product.Id,
            //    Description=product.Description,
            //    Name=product.Name,
            //    PictureUrl=product.PictureUrl,
            //   Price=product.Price,
            //   ProductBrand = product.ProductBrand.Name,
            //   ProductType = product.ProductType.Name

            //});

            return _Mapper.Map<Product, ProductDTO>(product);
        }

        [HttpGet("Types")]

        public async Task<IActionResult> GetByProductTypes()
        {
            return Ok(await _TypeRepo.ListAllAsync());
        }
        [HttpGet("Brands")]

        public async Task<IActionResult> GetByProductBrands()
        {
            return Ok(await _brandRepo.ListAllAsync());
        }



    }
}
