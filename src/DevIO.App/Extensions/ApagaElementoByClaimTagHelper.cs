using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;

namespace DevIO.App.Extensions
{
    [HtmlTargetElement("*", Attributes = "supress-by-claim-type")]
    [HtmlTargetElement("*", Attributes = "supress-by-claim-name")]
    public class ApagaElementoByClaimTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ApagaElementoByClaimTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HtmlAttributeName("supress-by-claim-type")]
        public string IdentityClaimType { get; set; }

        [HtmlAttributeName("supress-by-claim-name")]
        public string IdentityClaimName { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context is null) throw new ArgumentException(nameof(context));

            if (output is null) throw new ArgumentException(nameof(output));

            var temAcesso = CustomAuthorizarion.ValidarClaimsUsuario(_contextAccessor.HttpContext, IdentityClaimType, IdentityClaimName);

            if (temAcesso) return;

            output.SuppressOutput();
        }

    }


    [HtmlTargetElement("*", Attributes = "disable-by-claim-type")]
    [HtmlTargetElement("*", Attributes = "disable-by-claim-name")]
    public class DesabilitaElementoByClaimTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public DesabilitaElementoByClaimTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HtmlAttributeName("disable-by-claim-type")]
        public string IdentityClaimType { get; set; }

        [HtmlAttributeName("disable-by-claim-name")]
        public string IdentityClaimName { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context is null) throw new ArgumentException(nameof(context));

            if (output is null) throw new ArgumentException(nameof(output));

            var temAcesso = CustomAuthorizarion.ValidarClaimsUsuario(_contextAccessor.HttpContext, IdentityClaimType, IdentityClaimName);

            if (temAcesso) return;

            output.Attributes.RemoveAll("href");
            output.Attributes.Add(new TagHelperAttribute("style", "cursor:not-allowed"));
            output.Attributes.Add(new TagHelperAttribute("title", "Você não tem Permissão"));
        }

    }

    [HtmlTargetElement("*", Attributes = "supress-by-action")]
    public class ApagaElementoByActionTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ApagaElementoByActionTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HtmlAttributeName("supress-by-action")]
        public string ActonName { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context is null) throw new ArgumentException(nameof(context));

            if (output is null) throw new ArgumentException(nameof(output));

            var action = _contextAccessor.HttpContext.GetRouteData().Values["action"].ToString();

            if (ActonName.Contains(action)) return;

            output.SuppressOutput();
        }

    }
}
