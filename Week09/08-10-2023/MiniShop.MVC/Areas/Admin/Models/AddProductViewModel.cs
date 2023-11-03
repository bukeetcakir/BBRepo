using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MiniShop.MVC.Models;

namespace MiniShop.MVC.Areas.Admin.Models
{
    public class AddProductViewModel
    {
        [JsonPropertyName("name")]
        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "Boş bırakılmamalıdır.")]
        [MinLength(5, ErrorMessage = "En az 5 karakter olmalıdır.")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter olmalıdır.")]
        public string Name { get; set; }

        [JsonPropertyName("properties")]
        [DisplayName("Ürün Özellikleri")]
        [Required(ErrorMessage = "Boş bırakılmamalıdır.")]
        [MinLength(50, ErrorMessage = "En az 50 karakter olmalıdır.")]
        [MaxLength(500, ErrorMessage = "En fazla 500 karakter olmalıdır.")]
        public string Properties { get; set; }

        [JsonPropertyName("price")]
        [DisplayName("Ürün Fiyatı")]
        [Required(ErrorMessage = "Boş bırakılmamalıdır")]
        public int Price { get; set; } = 0;

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("note")]
        [DisplayName("Özel Notlar")]
        [MinLength(5, ErrorMessage = "En az 5 karakter olmalıdır.")]
        [MaxLength(500, ErrorMessage = "En fazla 500 karakter olmalıdır.")]
        public string Note { get; set; }

        [JsonPropertyName("categoryIds")]
        [Required(ErrorMessage = "En az bir kategori seçilmelidir.")]
        public List<int> CategoryIds { get; set; }

        public List<CategoryViewModel> Categories { get; set; }

        [JsonPropertyName("isActive")]
        [DisplayName("Aktif")]
        public bool IsActive { get; set; }
    }
}