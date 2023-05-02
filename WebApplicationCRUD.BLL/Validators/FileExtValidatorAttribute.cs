using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCRUD.BLL.Validators
{
    public class FileExtValidatorAttribute : ValidationAttribute
    {
        private readonly string[] _authorizedExt;

        public FileExtValidatorAttribute(params string[] authorizedExt)
        {
            _authorizedExt = authorizedExt;
            ErrorMessage = "This file is not valid";
        }

        public override bool IsValid(object? value)
        {
            if (value is null)
                return true;
            if (value is IFormFile file)
            {
                return _authorizedExt.Contains(file.ContentType);
            }
            return true;
        }
    }
}

