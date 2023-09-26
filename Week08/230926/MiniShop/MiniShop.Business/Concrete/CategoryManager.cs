using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Business.Abstract;
using MiniShop.Data.Abstract;
using MiniShop.Shared.Dtos;

namespace MiniShop.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
            //Data karmanından ilgili metodu çağırarak categoryleri çekeceğiz
            //Bu category listesini categoryDto listesine döndüreceğiz
            //Bu listeyi geri döndüreceğiz
            var categories = _categoryRepository.GetAll();
            if (categories == null)
            {
                return new List<CategoryDto>();
            }
            return null;
        }

        public CategoryDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}