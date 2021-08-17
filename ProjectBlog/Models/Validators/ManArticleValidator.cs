using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YazilimBlog.Models.Validators
{
    public class ManArticleValidator:AbstractValidator<ManipulationArticle>
    {

        public ManArticleValidator()
        {
            RuleFor(x => x.Write).NotNull().WithMessage("On Yazı Bos Olamaz").NotEmpty();
            RuleFor(x => x.Write).MaximumLength(60).WithMessage("60  Karekterden fazla olamaz");
            RuleFor(x => x.Write).MinimumLength(10).WithMessage("10  Karekterden az olamaz");
            RuleFor(x => x.WriteLength).NotNull().WithMessage(" Yazı Bos Olamaz").NotEmpty();
            RuleFor(x => x.WriteTitle).NotNull().WithMessage(" Başlık Bos Olamaz").NotEmpty();
            RuleFor(x => x.WriteTitle).MaximumLength(70).WithMessage(" Maksimum 70 karekter olabilir ").NotEmpty();
       


    
    
            
        }
    }
}
