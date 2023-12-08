using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Interfaces
{
    internal interface IFactory
    {
        void CreateComponet(string component, string width, string height, string top, string left);

        void AppendToStringBuilder(string tag);

        StringBuilder getOutput();

        List<string> getTags();

        void resetTags(StringBuilder tags);

    }
}
