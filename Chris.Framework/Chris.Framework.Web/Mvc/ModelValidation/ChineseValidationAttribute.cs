using System.ComponentModel.DataAnnotations;

namespace Chris.Framework.Web.Mvc.ModelValidation
{
    /// <inheritdoc />
    /// <summary>
    /// 中文字符校验
    /// <remarks>（当字段为null或Enpty时，可以通过验证，可与[Required]配合使用。）</remarks>
    /// </summary>
    public class ChineseValidationAttribute : RegularExpressionAttribute
    {
        private const string RegixPattern = @"^[\u4e00-\u9fa5]*$";
        public ChineseValidationAttribute() : base(RegixPattern)
        {
            ErrorMessage = "请输入中文字符";
        }
    }
}
