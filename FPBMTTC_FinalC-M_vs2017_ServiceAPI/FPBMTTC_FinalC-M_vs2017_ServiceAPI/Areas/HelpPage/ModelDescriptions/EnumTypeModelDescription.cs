using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FPBMTTC_FinalC_M_vs2017_ServiceAPI.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}