using MVC.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Validators
{
    public class UniqueNameAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectInstance as Course;
            var name = value as string;
            SchoolContext scontext = new SchoolContext();
            if(scontext.Courses.FirstOrDefault(m => m.Name == name && m.Id ==obj.Id) is not null)
            {
                return ValidationResult.Success;
            }
            else if (scontext.Courses.FirstOrDefault(m => m.Name == name && m.Id != obj.Id)is not null)
            {
                return new ValidationResult("Name exists");
            }
            else
            return ValidationResult.Success;
            //return base.IsValid(value, validationContext);
        }
    }
}
