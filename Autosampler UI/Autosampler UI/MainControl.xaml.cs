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

namespace Autosampler_UI
{
    /// <summary>
    /// MainControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainControl : UserControl
    {
        public MainControl()
        {
            InitializeComponent();
            RackSelectionChanged(RackSelectionComboBox, null);
        }

        private void RackSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RackContentContol == null) return;

            ComboBox comboBox = sender as ComboBox;
            string selectedText = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedText == "15ml tube")
            {
                RackContentContol.Content = new Rack15mlControl(); //15ml 전용 컨트롤 로드
            }

            else if (selectedText == "50ml tube")
            {
                RackContentContol.Content = new Rack50mlControl();
            }

        }


    }

}
