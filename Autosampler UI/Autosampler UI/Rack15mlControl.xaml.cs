using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Rack15mlControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Rack15mlControl : UserControl
    {
        public Rack15mlControl()
        {
            InitializeComponent();
            CreateRackButtons();
        }


        private void MarkAsCompleted(ToggleButton btn)
        {
            btn.Tag = "Completed";      // ✅ Style Trigger가 초록색으로 변경
            btn.IsChecked = false;      // 선택 해제 (파란색 → 초록색으로 바뀜)
        }

        private void CreateRackButtons()
        {
            int number = 1;

            for (int row = 0; row < 7; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    ToggleButton btn = CreateSampleButton(number);  // ✅ ToggleButton 사용
                    Grid.SetRow(btn, row);
                    Grid.SetColumn(btn, col);
                    RackGrid.Children.Add(btn);
                    number++;
                }
            }
        }

        private ToggleButton CreateSampleButton(int number)
        {
            return new ToggleButton
            {
                Content = number.ToString(),
                Width = 95,
                Height = 55,
                Background = Brushes.White,
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(5),
                FontWeight = FontWeights.Bold,
                FontSize = 18,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Style = (Style)FindResource("SampleToggleButtonStyle") // ✅ Style 적용
            };
        }

        private Button CreateRoundButton(int number)
        {
            return new Button
            {
                Content = number.ToString(),
                Width = 70,  // 셀보다 조금 작게 (예시값, 필요하면 조정)
                Height = 33, // 셀보다 조금 작게 (예시값, 필요하면 조정)
                Background = Brushes.White,
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(1),
                Margin = new Thickness(5), // 버튼 사이 여백
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Template = CreateRoundedRectButtonTemplate()
            };
        }


        private ControlTemplate CreateRoundedRectButtonTemplate()
        {
            var template = new ControlTemplate(typeof(Button));

            //  버튼 외곽 (CornerRadius로 살짝 둥글게)
            FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Border.CornerRadiusProperty, new CornerRadius(50)); // 살짝 둥근 사각형
            border.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(Button.BackgroundProperty));
            border.SetValue(Border.BorderBrushProperty, new TemplateBindingExtension(Button.BorderBrushProperty));
            border.SetValue(Border.BorderThicknessProperty, new TemplateBindingExtension(Button.BorderThicknessProperty));

            //  버튼 안의 Content(Text)
            FrameworkElementFactory content = new FrameworkElementFactory(typeof(ContentPresenter));
            content.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            content.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            border.AppendChild(content);

            template.VisualTree = border;
            return template;
        }

        public void DisableAllButtons()
        {
            foreach (var child in RackGrid.Children)
            {
                if (child is ToggleButton btn)
                {
                    btn.IsChecked = false;   // ✅ 버튼 해제
                    btn.Tag = null;          // ✅ 상태 초기화 (Completed 같은 태그도 리셋)
                    btn.Background = Brushes.White;  // ✅ 배경색도 초기화 (필요하면)
                }
            }
        }


        public void EnableAllButtons()
        {
            foreach (var child in RackGrid.Children)
            {
                if (child is ToggleButton btn)
                {
                    btn.IsChecked = true;            // ✅ 토글 ON
                    btn.Tag = null;                  // 상태 초기화 (필요하면 유지)
                    btn.Background = Brushes.LightBlue; // ✅ 선택된 색상 (SampleToggleButtonStyle에서 색상 지정됨)
                }
            }
        }


        private ControlTemplate CreateRoundButtonTemplate()
        {
            var template = new ControlTemplate(typeof(Button));
            FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Border.CornerRadiusProperty, new CornerRadius(20)); // 원형 버튼
            border.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(Button.BackgroundProperty));
            border.SetValue(Border.BorderBrushProperty, new TemplateBindingExtension(Button.BorderBrushProperty));
            border.SetValue(Border.BorderThicknessProperty, new TemplateBindingExtension(Button.BorderThicknessProperty));

            FrameworkElementFactory content = new FrameworkElementFactory(typeof(ContentPresenter));
            content.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            content.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            border.AppendChild(content);

            template.VisualTree = border;
            return template;
        }
    }
}
