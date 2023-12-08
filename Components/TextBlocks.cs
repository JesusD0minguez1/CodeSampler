using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.Interfaces;

namespace FactoryPattern.Components
{
    internal class TextBlocks : ITags
    {
        string width;
        string height;
        string top;
        string left;

        public TextBlocks(string width, string height, string top, string left)
        {
            this.width = width;
            this.height = height;
            this.top = top;
            this.left = left;
        }

        public string CreateTag()
        {
            return ($" \t <TextBlock Height=\"{this.height}\" Width=\"{this.width}\" Margin=\"{this.left},{this.top},0,0\" /> \n");

        }

    }
}
