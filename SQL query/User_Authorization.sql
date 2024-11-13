USE ShopMayTinh;
GO

-- Tạo các role cho hệ thống
CREATE ROLE RChuShop;  -- Role cho chủ shop
CREATE ROLE RKhachHang; -- Role cho khách hàng
GO

--- CHỦ SHOP
-- Phân quyền cho role chủ shop
GRANT SELECT, INSERT, UPDATE, DELETE ON MayTinh TO RChuShop; 
GRANT SELECT ON DonHang TO RChuShop; 
GRANT SELECT ON DonHangChiTiet TO RChuShop;
GRANT SELECT, INSERT, UPDATE, DELETE ON KhuyenMai TO RChuShop;
GRANT SELECT, INSERT, UPDATE, DELETE ON SanPham_KhuyenMai TO RChuShop;
GRANT SELECT, INSERT ON KhuyenMai_KhachHang TO RChuShop;
GRANT SELECT ON DanhGia TO RChuShop; 



-- Phân quyền thực thi cho các stored procedures
GRANT EXECUTE ON dbo.LayMaNguoiDung TO RChuShop;
GRANT EXECUTE ON dbo.ThemMayTinh TO RChuShop;
GRANT EXECUTE ON dbo.XoaMayTinh TO RChuShop;
GRANT EXECUTE ON dbo.SuaMayTinh TO RChuShop;
GRANT EXECUTE ON dbo.ThemKhuyenMai TO RChuShop;
GRANT EXECUTE ON dbo.XoaKhuyenMai TO RChuShop;
GRANT EXECUTE ON dbo.SuaKhuyenMai TO RChuShop;
GRANT EXECUTE ON dbo.ThemKhuyenMaiSanPham TO RChuShop;
GRANT EXECUTE ON dbo.XemSanPhamApDungVoiMoiKhuyenMai TO RChuShop;
GRANT EXECUTE ON dbo.XoaSanPham_KhuyenMai TO RChuShop;
GRANT SELECT ON dbo.TimKiemSanPham TO RChuShop;
GRANT SELECT ON dbo.TimKiemSanPhamChoChu TO RChuShop;
GRANT EXECUTE ON dbo.CheckSanPhamTruocKhiThem TO RChuShop;
GRANT EXECUTE ON dbo.CheckKhuyenMaiTruocKhiThem TO RChuShop;
GRANT EXECUTE ON dbo.XemChiTietMayTinh TO RChuShop;

GO


-- Phân quyền thực thi cho các View
GRANT SELECT ON dbo.View_SanPhamKhuyenMai TO RChuShop;
GRANT SELECT ON dbo.View_DanhSachKhuyenMai TO RChuShop;
GRANT SELECT ON dbo.View_DanhSachDonHang TO RChuShop;
GRANT SELECT ON dbo.View_ThongTinKhachHang TO RChuShop;
GRANT SELECT ON dbo.View_KhachHang TO RChuShop;
GRANT SELECT ON dbo.View_MayTinh TO RChuShop;


-- Phân quyền thực thi cho các function
GRANT EXECUTE ON dbo.TaoMaMayTinh TO RChuShop;
GRANT EXECUTE ON dbo.TaoMaKhuyenMai TO RChuShop;
GRANT EXECUTE ON dbo.TaoMaDonHang TO RChuShop;
GRANT EXECUTE ON dbo.TaoMaDanhGia TO RChuShop;
GRANT SELECT ON dbo.LayChiTietDonHang TO RChuShop;
GRANT SELECT ON dbo.TimKhuyenMai TO RChuShop;
GRANT SELECT ON dbo.TimDonHangChoChu TO RChuShop;
GRANT SELECT ON dbo.TimTaiKhoanKhachHang TO RChuShop;
GRANT SELECT ON dbo.TimKiemSanPhamChoChu TO RChuShop;
GRANT EXECUTE ON dbo.CheckSanPhamTruocKhiThem TO RChuShop;
GRANT EXECUTE ON dbo.CheckKhuyenMaiTruocKhiThem TO RChuShop;
GRANT SELECT ON dbo.DoanhThuTheoNgay TO RChuShop;
GRANT EXECUTE ON dbo.TinhTongGiaBanTheoNgay TO RChuShop;
GRANT SELECT ON dbo.DoanhThuTheoThang TO RChuShop;
GRANT EXECUTE ON dbo.TinhTongGiaBanTheoThang TO RChuShop;
GRANT SELECT ON dbo.DoanhThuTheoNam TO RChuShop;
GRANT EXECUTE ON dbo.TinhTongGiaBanTheoNam TO RChuShop;








--- KHÁCH HÀNG

-- Phân quyền cho role khách hàng
GRANT SELECT ON MayTinh TO RKhachHang; 
GRANT SELECT, DELETE ON KhuyenMai_KhachHang TO RKhachHang; 
GRANT SELECT, INSERT, UPDATE ON GioHang TO RKhachHang;
GRANT SELECT, INSERT, UPDATE ON DonHang TO RKhachHang;
GRANT SELECT, INSERT ON DonHangChiTiet TO RKhachHang;
GRANT SELECT, INSERT ON DanhGia TO RKhachHang;


-- Phân quyền thực thi cho các stored procedures
GRANT EXECUTE ON dbo.ThongTinCaNhan TO RKhachHang;
GRANT EXECUTE ON dbo.TaoMaKhachHang TO RKhachHang;
GRANT EXECUTE ON dbo.ApDungKhuyenMai TO RKhachHang;
GRANT EXECUTE ON dbo.DangKi TO RKhachHang;
GRANT SELECT ON View_MayTinh TO RKhachHang;--(2)
GRANT EXECUTE ON dbo.ThemVaoGioHang TO RKhachHang;
GRANT EXECUTE ON dbo.XemGioHang TO RKhachHang;
GRANT EXECUTE ON dbo.ThemDonHang TO RKhachHang;
GRANT EXECUTE ON dbo.ThemDonHangChiTiet TO RKhachHang;
GRANT EXECUTE ON dbo.XemLichSuDonHang TO RKhachHang;
GRANT EXECUTE ON dbo.CapNhatTrangThaiDonHang TO RKhachHang;
GRANT EXECUTE ON dbo.XemDanhGia1SanPham TO RKhachHang;
GRANT EXECUTE ON dbo.ThemDanhGia TO RKhachHang;
GRANT EXECUTE ON dbo.XemChiTietMayTinh TO RKhachHang;
GRANT EXECUTE ON dbo.XemChiTietDonHang TO RKhachHang;
GRANT EXECUTE ON dbo.LayDonHangHoanThanhCuaKhachHang TO RKhachHang;
GRANT EXECUTE ON dbo.LayThongTinKhuyenMai TO RKhachHang;
GRANT EXECUTE ON dbo.ApDungKhuyenMaiVaoSanPham TO RKhachHang;
GRANT EXECUTE ON dbo.GetMayTinhTheoSoSaoTrungBinh TO RKhachHang;
GRANT EXECUTE ON dbo.SoSanh2LapTop TO RKhachHang;
GRANT EXECUTE ON dbo.layCacSanPhamBanChayTrongThang TO RKhachHang;

-- Phân quyền thực thi cho các function
GRANT EXECUTE ON dbo.KiemTraEmail TO RKhachHang; 
GRANT SELECT ON dbo.TimKiemSanPham TO RKhachHang; 
GRANT SELECT ON dbo.LayThongTinChiTietSanPham TO RKhachHang; 
GRANT EXECUTE ON dbo.KiemTraTonKho TO RKhachHang; --(1)
GRANT SELECT ON dbo.TimSanPhamTrongGioHang TO RKhachHang; 
GRANT EXECUTE ON dbo.TaoMaDonHang TO RKhachHang; 
GRANT SELECT ON dbo.TimDonHang TO RKhachHang; 
GRANT SELECT ON dbo.LayChiTietDonHang TO RKhachHang; 
GRANT EXECUTE ON dbo.TaoMaDanhGia TO RKhachHang; 
GRANT SELECT ON dbo.LayKhuyenMaiCuaKhachHangVaSanPham TO RKhachHang;
GRANT EXECUTE ON dbo.ApDungKhuyenMai TO RKhachHang;
GRANT EXECUTE ON dbo.SoSanhCPU TO RKhachHang;
GRANT EXECUTE ON dbo.SoSanhO_Cung TO RKhachHang;
GRANT EXECUTE ON dbo.SoSanhRam TO RKhachHang;
GRANT EXECUTE ON dbo.SoSanhCard TO RKhachHang;
GRANT EXECUTE ON dbo.SoSanhTrongLuong TO RKhachHang;
GRANT EXECUTE ON dbo.SoSanhGiaTien TO RKhachHang;
GRANT EXECUTE ON dbo.SoSanhManHinh TO RKhachHang;
GRANT SELECT ON dbo.TimKiemTenMayTinh TO RKhachHang;
GRANT SELECT ON dbo.TimKiemSanPhamChoChu TO RKhachHang;
GRANT EXECUTE ON dbo.TinhSoSaoTrungBinh TO RKhachHang;













GO


CREATE TRIGGER trg_ThemTaiKhoan ON TaiKhoan
AFTER INSERT
AS
BEGIN
    DECLARE @tenTaiKhoan VARCHAR(50), @matKhau VARCHAR(255), @maQuyenHan VARCHAR(50)
    
    SELECT @tenTaiKhoan = tai_khoan, @matKhau = mat_khau, @maQuyenHan = ma_nguoi_dung
    FROM inserted;

    DECLARE @sqlString NVARCHAR(2000);

    -- Tạo login cho tài khoản
    SET @sqlString = 'CREATE LOGIN [' + @tenTaiKhoan + '] WITH PASSWORD=''' + @matKhau + ''', DEFAULT_DATABASE=[ShopMayTinh], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF';
    EXEC (@sqlString);

    -- Tạo user cho login
    SET @sqlString = 'CREATE USER ' + @tenTaiKhoan + ' FOR LOGIN ' + @tenTaiKhoan;
    EXEC (@sqlString);

    -- Phân quyền dựa trên maQuyenHan
	IF (@maQuyenHan = 'admin')  -- Mã quyền hạn cho chủ shop
	BEGIN
	SET @sqlString = 'ALTER ROLE RChuShop ADD MEMBER ' + @tenTaiKhoan;
	EXEC (@sqlString);
	END
	ELSE IF (@maQuyenHan LIKE 'kh%')  -- Mã quyền hạn cho khách hàng (bắt đầu bằng 'kh')
	BEGIN
	SET @sqlString = 'ALTER ROLE RKhachHang ADD MEMBER ' + @tenTaiKhoan;
	EXEC (@sqlString);
	END
END;
