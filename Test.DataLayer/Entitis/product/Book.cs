using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataLayer.Entitis.Common;

namespace Test.DataLayer.Entitis.product
{
    public class Book:BaseEntity
    {
        [Display(Name ="عنوان")]
        [Required(ErrorMessage = "عنوان نمیتواند خالی باشد")]
        [MaxLength(50)]
        public string Title { get; set; }=string.Empty;
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "توضیحات نمیتواند خالی باشد")]
        [MaxLength(500)]
        public string Description { get; set; }= string.Empty;
        [Display(Name = "نویسنده")]
        public string Author { get; set; } = string.Empty;
        [Display(Name = "ناشر")]
        public string Translator { get; set; }= string.Empty ;
        [Display(Name = "قیمت")]
        public int Price {  get; set; }
        [Display(Name = "تعدادصفحات")]
        public int NumberOfPages { get; set; }
        [Display(Name = "جمع آوری")]
        public string Publisher { get; set; } =string.Empty;
        [Display(Name = "موضوع")]
        public string Subject {  get; set; }
        [Display(Name = "شابک")]
        public string Shabk { get; set; } = string.Empty ;
        [Display(Name = "جلد")]
        public string? CoverType { get; set; } = string.Empty;

    }
}
