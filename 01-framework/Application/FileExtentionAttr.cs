using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace _01_framework.Application
{
    public class FileExtentionAttr : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] _extentions;

        public FileExtentionAttr(string[] extentions)
        {
            _extentions = extentions;
        }

        public override bool IsValid(object? value)
        {
            var file=value as IFormFile;
            if (file == null) return true;
            var fileExtention = Path.GetExtension(file.FileName);
            return _extentions.Contains(fileExtention);
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            string myStringOutput = String.Join("/", _extentions.Select(p => p.ToString()).ToArray());
            context.Attributes.Add("data-val-FileExtentionAttr", ErrorMessage);
            context.Attributes.Add("data-val-FileFormat", myStringOutput);

        }
    }
}
