using QuanLyCaPheApp.Models;
using QuanLyCaPheApp.ViewModels;
using System.Windows.Controls;

namespace QuanLyCaPheApp.Views
{
    public partial class TrangChuView : Page
    {
        private TrangChuViewModel _vm;

        public TrangChuView()
        {
            InitializeComponent();
            _vm = new TrangChuViewModel();
            DataContext = _vm;
            _vm.BanDuocChon = OnBanChon;
            // WPF Page dùng Loaded event thay vì OnNavigatedTo
            this.Loaded += (s, e) => _vm.Load();
        }

        private void OnBanChon(Ban ban)
        {
            // Đưa trạng thái về chữ thường để so sánh
            string status = ban.TrangThai?.ToLower().Trim() ?? "";

            switch (status)
            {
                case "trống":
                    NavigationService?.Navigate(new DatBanView());
                    break;
                case "đang dùng":
                    var goi = new GoiMonView();
                    goi.SetBan(ban);
                    NavigationService?.Navigate(goi);
                    break;
                case "đã đặt":
                case "đặt trước": // Bổ sung thêm case này để phòng hờ database lưu chữ "đặt trước"
                    NavigationService?.Navigate(new DatBanView());
                    break;
            }
        }
    }
}
