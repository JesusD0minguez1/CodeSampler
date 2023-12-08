using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.Interfaces;
using FactoryPattern.Components;


namespace FactoryPattern.Factories
{
    internal class XAMLFactory : IFactory
    {
        StringBuilder XAML = new StringBuilder();
        List<string> XAMLList = new List<string>();
        public void AppendToStringBuilder(string component)
        {
            XAML.Append(component);
            XAMLList.Add(component);
        }

        public void CreateComponet(string component, string width, string height, string top, string left)
        {
            string tag;
            switch (component.ToLower())
            {
                case "label":
                    Labels label = new Labels(width, height, top, left);
                    tag = label.CreateTag();
                    AppendToStringBuilder(tag);

                    break;
                case "button":
                    Buttons button = new Buttons(width, height, top, left);
                    tag = button.CreateTag();
                    AppendToStringBuilder(tag);

                    break;
                case "textinput":
                    TextInputs txtInput = new TextInputs(width, height, top, left);
                    tag = txtInput.CreateTag();
                    AppendToStringBuilder(tag);

                    break;
                case "textblock":
                    TextBlocks txtBlock = new TextBlocks(width, height, top, left);
                    tag = txtBlock.CreateTag();
                    AppendToStringBuilder(tag);

                    break;
                default:
                    break;


            }

        }

        public StringBuilder getOutput()
        {    
            return XAML;
        }

        public List<string> getTags()
        {
            return XAMLList;
        }

        public void resetTags(StringBuilder tags)
        {
            XAML.Clear();
            XAML = tags;
        }
    }
}
