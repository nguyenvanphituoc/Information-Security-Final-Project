using System;
using System.Reflection;

namespace FPBMTTC_FinalC_M_vs2017_ServiceAPI.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}