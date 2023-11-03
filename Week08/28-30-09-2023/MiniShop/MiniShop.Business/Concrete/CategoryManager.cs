using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MiniShop.Business.Abstract;
using MiniShop.Data.Abstract;
using MiniShop.Entity.Concrete;
using MiniShop.Shared.Dtos;

namespace MiniShop.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public ResponseDto<CategoryDto> Create(AddCategoryDto addCategoryDto)
        {
            var addedCategory = _mapper.Map<Category>(addCategoryDto);
            addedCategory.CreatedDate = DateTime.Now;
            addedCategory.ModifiedDate = DateTime.Now;
            addedCategory.IsDeleted = false;
            var resultCategory = _categoryRepository.Create(addedCategory);
            return new ResponseDto<CategoryDto>
            {
                Data = _mapper.Map<CategoryDto>(resultCategory),
                Error = null
            };
        }

        public void Delete(int id)
        {
            var deletedCategory = _categoryRepository.GetById(id);
            _categoryRepository.Delete(deletedCategory);
        }

        public ResponseDto<List<CategoryDto>> GetAll()
        {
            var response = new ResponseDto<List<CategoryDto>>();
            List<Category> categories = _categoryRepository.GetAll().Where(c => !c.IsDeleted).ToList();
            if (categories.Count == 0)
            {
                response.Data = null;
                response.Error = "Hiç kategori bulunamadı.";
            }
            else
            {
                List<CategoryDto> categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
                response.Data = categoryDtos;
                response.Error = null;
            }
            return response;
        }

        public ResponseDto<CategoryDto> GetById(int id)
        {
            var response = new ResponseDto<CategoryDto>();
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                response.Data = null;
                response.Error = "Aradığınız kategori bulunamadı.";
            }
            else
            {
                var categoryDto = _mapper.Map<CategoryDto>(category);
                response.Data = categoryDto;
                response.Error = null;
            }
            return response;
        }

        public ResponseDto<CategoryDto> SoftDelete(int id)
        {
            var deletedCategory = _categoryRepository.GetById(id);
            var result = _categoryRepository.SoftDelete(deletedCategory);
            return new ResponseDto<CategoryDto>
            {
                Data = _mapper.Map<CategoryDto>(result),
                Error = null
            };
        }

        public void Update(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}