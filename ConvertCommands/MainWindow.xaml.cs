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

namespace ConvertCommands
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddFrontAndBack(object sender, RoutedEventArgs e)
        {
            var strMain = txtMain.Text;
            var strFront = txtFront.Text;
            var strBack = txtBack.Text;

            string[] strReturn = { "\r\n" };

            string[] arrMain = strMain.Split(strReturn, StringSplitOptions.None);
            var strBuilder = new StringBuilder();

            foreach (var strPart in arrMain)
            {
                strBuilder.AppendLine($"{strFront} {strPart} {strBack}");
            }

            txtConvert.Text = strBuilder.ToString();
        }

        public void RemoveFrontAndBack(object sender, RoutedEventArgs e)
        {

            var strConvert = txtConvert.Text;
            var strFront = txtFront.Text;
            var strBack = txtBack.Text;

            string[] strReturn = { "\r\n" };


            string[] arrConvert = strConvert.Split(strReturn, StringSplitOptions.None);
            var strBuilder = new StringBuilder();

            foreach (var strPart in arrConvert)
            {
                string outputString = strPart;

                if (strPart == "")
                {
                    continue;
                }

                if (strFront != "" && strPart.Contains(strPart))
                {
                    outputString = outputString.Replace(strFront, "");
                }

                if (strBack != "" && strPart.Contains(strBack))
                {
                    outputString = outputString.Replace(strBack, "");
                }

                strBuilder.AppendLine($"{outputString}");
            }

            txtMain.Text = strBuilder.ToString();
        }

        public void Clear(object sender, RoutedEventArgs e)
        {
            txtMain.Clear();
            txtFront.Clear();
            txtBack.Clear();
            txtConvert.Clear();
        }
    }
}
