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

        public void Create(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public void Delete(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDto> GetAll()
        {
            List<Category> categories = _categoryRepository.GetAll();
            if (categories.Count == 0)
            {
                return new List<CategoryDto>{
                    new CategoryDto{ErrorMessage="Hiç kategori bulunamadı!"}
                };
            }
            List<CategoryDto> categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            return categoryDtos;
        }

        public CategoryDto GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return new CategoryDto { ErrorMessage = "Aradığınız kategori bulunamadı!" };
            }
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public void Update(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}