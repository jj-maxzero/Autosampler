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
            AllDisableButton.Click += AllDisableButton_Click;
        }

        // ✅ All Disable 버튼 눌렀을 때 실행되는 코드
        private void AllDisableButton_Click(object sender, RoutedEventArgs e)
        {
            // ✅ RackContentContol이 Rack15mlControl인지 확인 후 ToggleButton 해제
            if (RackContentContol.Content is Rack15mlControl rack15ml)
            {
                rack15ml.DisableAllButtons();   // ⬅ Rack15mlControl에 메서드 만들어서 호출
            }

           
        }

        private void AllAbleButton_Click(object sender, RoutedEventArgs e)
        {
            if (RackContentContol.Content is Rack15mlControl rack15ml)
            {
                rack15ml.EnableAllButtons();   // ✅ 15ml 전체 버튼 선택
            }

           
        }



        private void RackSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RackContentContol == null) return;

            ComboBox comboBox = sender as ComboBox;
            string selectedText = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedText == "15ml tube A, B")
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
