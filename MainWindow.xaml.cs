using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using FactoryPattern.Factories;
using System.IO;

namespace FactoryPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Tag = "";
        string CodeBase = "";
        HTMLFactory HTMLFactory = new HTMLFactory();
        XAMLFactory XAMLFactory = new XAMLFactory();
        StringBuilder xaml = new StringBuilder();
        StringBuilder html = new StringBuilder();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void codeFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CodeBase = ((ComboBoxItem)((ComboBox)sender).SelectedItem).Content.ToString();
        }

        private void cmbComponents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tag = ((ComboBoxItem)((ComboBox)sender).SelectedItem).Content.ToString();

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string height = txtHeight.Text;
            string width = txtWidth.Text;
            string top = txtTop.Text;
            string left = txtleft.Text;

            if (isValidEntry())
            {
                if (CodeBase == "HTML")
                {
                    txtOutput.Text = "";
                    HTMLFactory.CreateComponet(Tag, width, height, top, left);
                    appendToHMTL(txtOutput, html, HTMLFactory.getOutput().ToString());

                }
                else {
                    txtOutput.Text = "";
                    XAMLFactory.CreateComponet(Tag, width, height, top, left);
                    appendToXAML(txtOutput, xaml, XAMLFactory.getOutput().ToString());

                }
            
            }


        }

        private static void appendToHMTL( TextBlock output,StringBuilder html,string components)
        {
            html.Clear();
            html.AppendLine("<!DOCTYPE html \n <html> \n <body> \n");
            html.AppendLine(components);
            html.AppendLine("\n</body> \n</html>");
            output.Text = html.ToString();
        }

        private static void appendToXAML(TextBlock output, StringBuilder xaml, string components)
        {
            xaml.Clear();
            xaml.AppendLine("<Window x:Class=\"FactoryPattern.MainWindow\" \n");
            xaml.AppendLine("\t xmlns = \"http:\\/\\/schemas.microsoft.com\\/winfx\\/2006\\/xaml\\/presentation \" \n");
            xaml.AppendLine("\t xmlns: x = \" http:\\/\\/schemas.microsoft.com\\/winfx/\\2006\\/xaml \"  \n");
            xaml.AppendLine("\t xmlns: d = \" http:\\/\\/schemas.microsoft.com\\/expression\\/blend\\/2008 \" \n");
            xaml.AppendLine("\t xmlns: d = \" http:\\/\\/schemas.microsoft.com\\/expression\\/blend\\/2008 \"   \n");
            xaml.AppendLine("\t xmlns: mc = \" http:\\/\\/schemas.openxmlformats.org\\/markup-compatibility\\/2006 \"  \n");
            xaml.AppendLine("\t  xmlns: mc = \" http:\\/\\/schemas.openxmlformats.org\\/markup-compatibility\\/2006 \" \n");
            xaml.AppendLine("\t" + components + "\n");
            xaml.AppendLine("<\\Window>");
            
            output.Text = xaml.ToString();

        }


        private bool isValidEntry() {
            string height = txtHeight.Text;
            string width = txtWidth.Text;
            string top = txtTop.Text;
            string left = txtleft.Text;



            Regex digits = new Regex("\\d");

            if (digits.IsMatch(height))
            {
                if (digits.IsMatch(width))
                {
                    if (digits.IsMatch(top))
                    {
                        if (digits.IsMatch(left))
                        {
                            return true;
                        }
                    }

                }
            }
            else {
                MessageBox.Show("Please enter an Digit or valid entry");
            }
            return false;
        }

       

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var x = XAMLFactory.getOutput();
            var h = HTMLFactory.getOutput();
            string height = txtHeight.Text;
            string width = txtWidth.Text;
            string top = txtTop.Text;
            string left = txtleft.Text;

            if (CodeBase == "HTML")
            {
                resetHTML(html, HTMLFactory);
                txtOutput.Text = "";
                HTMLFactory.CreateComponet(Tag, width, height, top, left);
                appendToHMTL(txtOutput, html, h.ToString());

            }
            else {

                resetXAML(xaml, XAMLFactory );
                txtOutput.Text = "";
                XAMLFactory.CreateComponet(Tag, width, height, top, left);
                appendToXAML(txtOutput, xaml, x.ToString());

            }
        }


        private static void resetXAML(StringBuilder xaml, XAMLFactory XAMLFactory)
        {
            xaml.Clear();
            XAMLFactory.getTags().RemoveAt(XAMLFactory.getTags().Count() - 1);

            foreach (string i in XAMLFactory.getTags())
            {
                xaml.Append(i);
            }

            XAMLFactory.resetTags(xaml);

        }

        private static void resetHTML(StringBuilder html, HTMLFactory HTMLFactory)
        {
            html.Clear();
            HTMLFactory.getTags().RemoveAt(HTMLFactory.getTags().Count() - 1);

            foreach (string i in HTMLFactory.getTags())
            {
                html.Append(i);
            }

            HTMLFactory.resetTags(html);

        }


    }
}
