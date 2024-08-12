Tôi sử dụng Visual Studio để phát triển website với framework ASP.NET MVC và ngôn ngữ lập trình là C#
- Đây là Website bán thiết bị điện tử có 3 role chính là: Khách hàng vãng lai, thành viên và admin
  + Role khách hàng vãng lai: Đăng nhập, Đăng ký, Xem chi tiết sản phẩm, Xem đánh giá sản phẩm, Bộ lọc tìm kiếm, Liên hệ với admin, Đặt hàng, Thanh toán
  + Role thành viên: Xem chi tiết sản phẩm, Xem đánh giá sản phẩm, Đánh giá sản phẩm, Bộ lọc tìm kiếm, Liên hệ với admin, Nhận tích điểm dựa trên đơn hàng đã hoàn thành, Sử dụng tích điểm đổi Voucher, Xem Voucher đã đổi, Áp dụng Voucher vào đơn đặt hàng, Đặt hàng, Thanh toán
  + Role admin: CRUD sản phẩm, CRUD loại sản phẩm, CRUD Voucher, CRUD người dùng, Xem và cập nhật trạng thái đơn hàng của thành viên và khách hàng vãng lai, Xem và cập nhật trạng thái liên hệ của thành viên và khách hàng vãng lai, Báo cáo doanh thu của thành viên và khách hàng vãng lai
    
- Cài đặt:
  B1: Create Database trong SQL Server bằng file DBQuanLyBanDoCongNghe.sql
  B2: Vào demo, trong Web.config đổi tên Data Source thành Server Name của SQL Server của mình
  B3: Chạy demo
  
- Trang admin: http://letuananh4282-001-site1.ctempurl.com/Admin/Home
  + Tài khoản: letuananh
  + Mật khẩu: 123456
