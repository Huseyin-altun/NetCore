using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YazilimBlog.Models.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {

        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotNull().WithMessage("Kategori Bos Olamaz").NotEmpty();         
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("3  Karekterden az olamaz");
     
       


    
    
            
        }
    }
}
