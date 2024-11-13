--Tạo login cho chủ shop
CREATE LOGIN UChuShop WITH PASSWORD = 'chushop';
GO

---Tạo login cho khách hàng
CREATE LOGIN UKhachHang WITH PASSWORD = 'khachhang';
GO

USE ShopMayTinh;
GO

---Tạo user cho login
CREATE USER UChuShop FOR LOGIN UChuShop;
CREATE USER UKhachHang FOR LOGIN UKhachHang;
GO

---Phân quyền cho chủ shop
GRANT SELECT, INSERT, UPDATE, DELETE ON MayTinh TO UChuShop;
GRANT SELECT ON DonHang TO UChuShop;
GRANT SELECT ON DonHangChiTiet TO UChuShop;
GRANT SELECT, INSERT, UPDATE, DELETE ON KhuyenMai TO UChuShop;
GRANT SELECT, INSERT, UPDATE, DELETE ON SanPham_KhuyenMai TO UChuShop;
GRANT SELECT, INSERT ON KhuyenMai_KhachHang TO UChuShop;
GRANT SELECT ON DanhGia TO UChuShop;

GRANT EXECUTE ON dbo.TaoMaMayTinh TO UChuShop;
GRANT EXECUTE ON dbo.TaoMaKhuyenMai TO UChuShop;
GRANT EXECUTE ON dbo.TaoMaDonHang TO UChuShop;
GRANT EXECUTE ON dbo.TaoMaDanhGia TO UChuShop;
GRANT EXECUTE ON dbo.CheckSanPhamTruocKhiThem TO UChuShop;
GRANT EXECUTE ON dbo.CheckKhuyenMaiTruocKhiThem TO UChuShop;
GO

---Phân quyền cho khách hàng
GRANT SELECT ON MayTinh TO UKhachHang;
GRANT SELECT, DELETE ON KhuyenMai_KhachHang TO UKhachHang;
GRANT SELECT, INSERT, UPDATE ON GioHang TO UKhachHang;
GRANT SELECT, INSERT, UPDATE ON DonHang TO UKhachHang;
GRANT SELECT, INSERT ON DonHangChiTiet TO UKhachHang;
GRANT SELECT, INSERT ON DanhGia TO UKhachHang;

GRANT EXECUTE ON dbo.TaoMaKhachHang TO UKhachHang;
GRANT EXECUTE ON dbo.ApDungKhuyenMai TO UKhachHang;
GO
