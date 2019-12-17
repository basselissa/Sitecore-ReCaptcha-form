using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Globalization;

namespace Sitecore.SharedSource.Forms.Fields.ReCaptcha.Services
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ReCaptchaValidationAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly IReCaptchaService reCaptchaService = ServiceLocator.ServiceProvider.GetService<IReCaptchaService>();
        
        public override bool IsValid(object value)
        {
            try
            {
                
                var isValid = reCaptchaService.VerifySync((string)value);
                RecaptchaContext.RecaptchaValidated = isValid;
                return isValid;
            }
            catch(Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Recaptcha Module:: " + ex.Message + value.GetType(), this);
                return false;
            }
            
        }

        public override string FormatErrorMessage(string name)
        {
            return Translate.Text(this.ErrorMessageString);
        }

        IEnumerable<ModelClientValidationRule> IClientValidatable.GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "required"
            };
            yield return rule;
        }
        
    }
    
}