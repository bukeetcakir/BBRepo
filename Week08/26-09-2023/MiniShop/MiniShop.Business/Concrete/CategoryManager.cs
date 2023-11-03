using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Business.Abstract;
using MiniShop.Data.Abstract;
using MiniShop.Entity.Concrete;
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
            //Data katmanından ilgili metodu çağırarak categoryleri çekeceğiz.
            //Bu category listesini categoryDto listesine dönüştüreceğiz.
            //Bu listeyi geri döndüreceğiz.
            List<Category> categories = _categoryRepository.GetAll();
            if (categories==null)
            {
                return new List<CategoryDto>();
            }

            throw new NotImplementedException();
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