using System.ComponentModel.DataAnnotations;

namespace Chris.Framework.Web.Mvc.ModelValidation
{
    /// <inheritdoc />
    /// <summary>
    /// 身份证号校验
    /// </summary>
    public class IdCardValidationAttribute : RegularExpressionAttribute
    {
        private const string RegexPattern = @"(^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$)|(^[1-9]\d{5}\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{2}[0-9Xx]$)";
        public IdCardValidationAttribute() : base(RegexPattern)
        {
            ErrorMessage = "身份证格式不正确";
        }
    }
}
