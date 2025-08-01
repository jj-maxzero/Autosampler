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
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Vessel1 기본 선택 상태로 설정
            Vessel1Image.Source = new BitmapImage(new Uri("pack://application:,,,/Images/vessel_btn_all,1~6_normal.png"));  

            //Main 버튼 눌림 상태로 처리
            MainButton.Background = Brushes.DarkBlue;
            MainButton.Foreground = Brushes.White;

            //두 조건이 만족되므로 MainControl 로드
            if(IsVessel1Selected() && IsMainButtonActive())
            {
                MainControl mainControl = new MainControl();
                DynamicContent.Content = mainControl;
            }
        }

        private bool IsVessel1Selected()
        {
            return Vessel1Image.Source.ToString().Contains("normal");
        }

        private bool IsMainButtonActive()
        {
            //mainbutton이 눌린 상태인지 여부(색상 또는 토글 여부 기반)
            return MainButton.Background == Brushes.DarkBlue;
        }

        private void ShowMain(object sender, RoutedEventArgs e)
        {
            //MainControl 인스턴스 생성
            MainControl mainControl = new MainControl();

            //ContentControl에 삽입
            DynamicContent.Content = mainControl;
        }

    }
}
