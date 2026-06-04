using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace QuanLyCaPheApp.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Chuyển chuỗi về chữ thường và xóa khoảng trắng 2 đầu
            string status = value?.ToString()?.ToLower().Trim() ?? "";

            return status switch
            {
                "trống" or "trong" => new SolidColorBrush(Color.FromRgb(76, 175, 80)),
                "đang dùng" or "dang dung"=> new SolidColorBrush(Color.FromRgb(244, 67, 54)),
                "đã đặt" or "đặt trước" => new SolidColorBrush(Color.FromRgb(255, 193, 7)),
                "bảo trì" or "bao tri" => new SolidColorBrush(Color.FromRgb(158, 158, 158)),
                "dathanhtoan" => new SolidColorBrush(Color.FromRgb(76, 175, 80)),
                "danggoi" => new SolidColorBrush(Color.FromRgb(33, 150, 243)),
                "huybo" => new SolidColorBrush(Color.FromRgb(244, 67, 54)),
                "daxong" => new SolidColorBrush(Color.FromRgb(76, 175, 80)),
                "dangpha" => new SolidColorBrush(Color.FromRgb(255, 152, 0)),
                "chopha" => new SolidColorBrush(Color.FromRgb(158, 158, 158)),
                _ => new SolidColorBrush(Colors.Gray)
            };
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
