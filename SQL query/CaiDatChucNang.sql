CREATE PROCEDURE CheckTaiKhoan
	@taikhoan varchar(50),
	@matkhau varchar(255)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM TaiKhoan WHERE tai_khoan = @taikhoan AND mat_khau = @matkhau)
    BEGIN
        SELECT 1 AS trangThaiTaiKhoan;
    END
    ELSE
    BEGIN
        SELECT 0 AS trangThaiTaiKhoan;
    END
END;




CREATE VIEW View_MayTinh AS 
SELECT ma_may_tinh, ten_may_tinh, mo_ta, gia_tien, ton_kho, cpu, ram, o_cung, card_roi, man_hinh, trong_luong, nam_san_suat, bao_hanh, hinh_anh
FROM MayTinh;

CREATE VIEW View_KhachHang AS 
SELECT ma_khach_hang, ten_khach_hang, email, dia_chi, so_dien_thoai 
FROM KhachHang;

CREATE VIEW View_ThongTinKhachHang AS 
SELECT ma_khach_hang, tai_khoan, mat_khau, ten_khach_hang, email, dia_chi, so_dien_thoai 
FROM KhachHang INNER JOIN TaiKhoan ON KhachHang.ma_khach_hang = TaiKhoan.ma_nguoi_dung;

CREATE VIEW View_DanhSachDonHang AS
SELECT ma_don_hang, DonHang.ma_khach_hang, ten_khach_hang, ngay_dat_hang, tong_tien, trang_thai
FROM DonHang INNER JOIN KhachHang ON DonHang.ma_khach_hang = KhachHang.ma_khach_hang

CREATE VIEW View_DanhSachKhuyenMai AS
SELECT ma_khuyen_mai, ten_khuyen_mai, mo_ta, phan_tram_giam, so_tien_giam, ngay_bat_dau, ngay_ket_thuc
FROM KhuyenMai

--- Xem danh sách sản phẩm khuyến mãi
CREATE VIEW View_SanPhamKhuyenMai AS
SELECT *
FROM SanPham_KhuyenMai


EXECUTE XemChiTietMayTinh 'MT09'


SELECT *FROM View_MayTinh
SELECT *FROM View_ThongTinKhachHang
SELECT *FROM View_DanhSachDonHang
SELECT *FROM View_DanhSachKhuyenMai
SELECT *FROM TaiKhoan