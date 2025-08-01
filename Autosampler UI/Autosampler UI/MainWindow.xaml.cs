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
using System.Windows.Threading;

namespace Autosampler_UI
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;  // ✅ 타이머 변수 선언
        public MainWindow()
        {
            InitializeComponent();
            StartClock();
            //Vessel1 기본 선택 상태로 설정
            Vessel1Image.Source = new BitmapImage(new Uri("pack://application:,,,/Images/vessel_btn_all,1~6_normal.png"));

            //Main 버튼 눌림 상태로 처리
            MainButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#17447C"));
            MainButton.Foreground = Brushes.White;

            //두 조건이 만족되므로 MainControl 로드
            if(IsVessel1Selected() && IsMainButtonActive())
            {
                MainControl mainControl = new MainControl();
                DynamicContent.Content = mainControl;
            }
        }

        private void StartClock()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);   // ✅ 1초마다 실행
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTimeTextBlock.Text = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
        }

        private bool IsVessel1Selected()
        {
            return Vessel1Image.Source.ToString().Contains("normal");
        }

        private bool IsMainButtonActive()
        {
            // MainButton의 Background를 SolidColorBrush로 변환
            if (MainButton.Background is SolidColorBrush brush)
            {
                // Brush의 Color 값을 #17447C와 비교
                return brush.Color == (Color)ColorConverter.ConvertFromString("#17447C");
            }
            return false;
        }

        private void ShowMain(object sender, RoutedEventArgs e)
        {
            ResetNavButtonColors();   // 🔹 먼저 전체 버튼 색을 초기화
            MainButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#17447C"));
            //MainControl 인스턴스 생성
            MainControl mainControl = new MainControl();

            //ContentControl에 삽입
            DynamicContent.Content = mainControl;
        }

        private void ShowCalibration(object sender, RoutedEventArgs e)
        {
            ResetNavButtonColors();   // 🔹 먼저 전체 버튼 색을 초기화
            CalButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#17447C"));
            CalirationControl calibrationControl = new CalirationControl();
            DynamicContent.Content = calibrationControl;

        }



        private void ResetNavButtonColors()
        {
            // ✅ 모든 버튼을 기본 색으로 초기화
            MainButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1E71B8"));
            CalButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1E71B8"));
            R1_Data1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1E71B8"));
            R2_Data1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1E71B8"));
        }


    }
}
