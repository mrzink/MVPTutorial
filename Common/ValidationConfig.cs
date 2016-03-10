using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace Common
{
    #region get attribute and context
    /// <summary>
    /// get attribute and context
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Attribute<T>
    {
        public static ValidationAttribute[] GetAttribute(string propertyName)
        {
            var attributes = typeof(T)
                   .GetProperty(propertyName)
                   .GetCustomAttributes(false)
                   .OfType<ValidationAttribute>()
                   .ToArray();
            return attributes;
        }

        public static ValidationContext GetContext(object contextName, string memberName)
        {
            var context = new ValidationContext(contextName, null, null) { MemberName = memberName };
            return context;
        }
    }

    public class IntegerValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                int.Parse(value.ToString());
                return ValidationResult.Success;
            }
            catch (Exception)
            {
                return new ValidationResult(ErrorMessage, new string[] { validationContext.MemberName });
            }
        }
    }
    #endregion
}

