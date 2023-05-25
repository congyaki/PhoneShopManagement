using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhoneShop.AdminApp.ViewModel
{
    public class ProductViewModel
    {
        [DisplayName("Product ID")]
        public int PId { get; set; }

        [DisplayName("Tên")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm.")]
        public string PName { get; set; }

        [DisplayName("Nhà Sản Xuất")]
        [Required(ErrorMessage = "Vui lòng chọn nhà sản xuất.")]
        public int MId { get; set; }

        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả sản phẩm.")]
        public string PDescription { get; set; }

        [DisplayName("Màu")]
        [Required(ErrorMessage = "Vui lòng nhập màu.")]
        public string PColor { get; set; }

        [DisplayName("Bộ lưu trữ")]
        [Required(ErrorMessage = "Vui lòng nhập bộ lưu trữ.")]
        public string PStorage { get; set; }

        [DisplayName("Ram")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin Ram.")]
        public string PRam { get; set; }

        [DisplayName("Kích thước màn hình")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin kích thước màn hình.")]
        public string PScreenSize { get; set; }

        [DisplayName("Độ phân giải")]
        [Required(ErrorMessage = "Vui lòng nhập độ phân giải.")]
        public string PResolution { get; set; }

        [DisplayName("Hệ điều hành")]
        [Required(ErrorMessage = "Vui lòng nhập hệ điều hành.")]
        public string POperatingSystem { get; set; }

        [DisplayName("Camera")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin camera.")]
        public string PCamera { get; set; }

        [DisplayName("Dung lượng Pin")]
        [Required(ErrorMessage = "Vui lòng nhập dung lượng pin.")]
        public string PBatteryCapacity { get; set; }

        [DisplayName("khả năng kết nối")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin kết nối.")]
        public string PConnectivity { get; set; }

        [DisplayName("trọng lượng")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin trọng lượng.")]
        public string PWeight { get; set; }

        [DisplayName("kích thước")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin kích thước.")]
        public string PDimension { get; set; }

        [DisplayName("Giá bán")]
        [Required(ErrorMessage = "Vui lòng nhập giá bán.")]
        [Range(0, double.MaxValue, ErrorMessage = "Vui lòng nhập giá bán không âm.")]
        public decimal PPrice { get; set; }

        [DisplayName("Giá gốc")]
        [Required(ErrorMessage = "Vui lòng nhập giá gốc.")]
        [Range(0, double.MaxValue, ErrorMessage = "Vui lòng nhập giá gốc không âm.")]
        public decimal POriginalPrice { get; set; }

        [DisplayName("Số lượng tồn kho")]
        [Required(ErrorMessage = "Vui lòng nhập số lượng tồn kho.")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập số lượng tồn kho không âm.")]
        public int PStock { get; set; }

        [DisplayName("Ảnh sản phẩm")]
        public List<IFormFile> ImageFiles { get; set; }
    

    }
}
