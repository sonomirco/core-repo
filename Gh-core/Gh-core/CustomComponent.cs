using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper.Kernel;

namespace Gh_core
{
    public abstract class CustomComponent : GH_Component
    {
        protected CustomComponent(string name, string description, string subCategory)
            : base(name, name, description, "SubModule", subCategory)
        {
        }

        public override void CreateAttributes() => m_attributes = new ComponentAttribute(this);

        public override GH_Exposure Exposure => GH_Exposure.primary;

        public bool HasPhantomGroup { get; internal set; }
    }
}
