﻿use ShopMayTinh;
---Thêm tài khoản
IF OBJECT_ID('dbo.ThemTaiKhoan', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemTaiKhoan;
GO
CREATE PROCEDURE dbo.ThemTaiKhoan
    @ten_khach_hang NVARCHAR(100),
    @tai_khoan VARCHAR(50),
    @mat_khau VARCHAR(50),
    @email VARCHAR(100)
AS
BEGIN
    DECLARE @ma_khach_hang VARCHAR(50);
	-- Gọi hàm để tạo mã khách hàng mới
    SET @ma_khach_hang = dbo.TaoMaKhachHang();

	-- Thêm tài khoản mới vào bảng TaiKhoan
    INSERT INTO TaiKhoan (tai_khoan, mat_khau, ma_nguoi_dung)
    VALUES (@tai_khoan, @mat_khau, @ma_khach_hang);

    -- Thêm thông tin khách hàng vào bảng KhachHang
    INSERT INTO KhachHang (ma_khach_hang ,ten_khach_hang, email)
    VALUES (@ma_khach_hang, @ten_khach_hang, @email);
END;
GO

---thêm máy tính
IF OBJECT_ID('dbo.ThemMayTinh', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemMayTinh;
GO
CREATE PROCEDURE ThemMayTinh
    @ten_may_tinh NVARCHAR(255),
    @mo_ta NVARCHAR(255) = NULL,
    @gia_tien INT,
    @ton_kho INT,
    @cpu NVARCHAR(255),
    @ram NVARCHAR(255),
    @o_cung NVARCHAR(255),
    @card_roi NVARCHAR(255) = NULL,
    @man_hinh NVARCHAR(255),
    @trong_luong FLOAT,
    @nam_san_suat INT,
    @bao_hanh NVARCHAR(255),
    @hinh_anh VARBINARY(MAX) = NULL
AS
BEGIN
    DECLARE @ma_may_tinh VARCHAR(50);

    -- Gọi hàm để tạo mã máy tính mới
    SET @ma_may_tinh = dbo.TaoMaMayTinh();

    -- Thêm máy tính mới vào bảng
    INSERT INTO MayTinh (ma_may_tinh, ten_may_tinh, mo_ta, gia_tien, ton_kho, cpu, ram, o_cung, card_roi, man_hinh, trong_luong, nam_san_suat, bao_hanh, hinh_anh)
    VALUES (@ma_may_tinh, @ten_may_tinh, @mo_ta, @gia_tien, @ton_kho, @cpu, @ram, @o_cung, @card_roi, @man_hinh, @trong_luong, @nam_san_suat, @bao_hanh, @hinh_anh);
END;

---Xóa máy tính
IF OBJECT_ID('dbo.XoaMayTinh', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XoaMayTinh;
GO
CREATE PROCEDURE dbo.XoaMayTinh
    @ma_may_tinh VARCHAR(50)
AS
BEGIN
    -- Kiểm tra xem mã máy tính có tồn tại không
    IF EXISTS (SELECT 1 FROM MayTinh WHERE ma_may_tinh = @ma_may_tinh)
    BEGIN
        -- Xóa máy tính
        DELETE FROM MayTinh WHERE ma_may_tinh = @ma_may_tinh;
    END
END;

---Sửa máy tính
IF OBJECT_ID('dbo.SuaMayTinh', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SuaMayTinh;
GO
CREATE PROCEDURE dbo.SuaMayTinh
    @ma_may_tinh VARCHAR(50),
    @ten_may_tinh NVARCHAR(255) = NULL,
    @mo_ta NVARCHAR(255) = NULL,
    @gia_tien INT = NULL,
    @ton_kho INT = NULL,
    @cpu NVARCHAR(255) = NULL,
    @ram NVARCHAR(255) = NULL,
    @o_cung NVARCHAR(255) = NULL,
    @card_roi NVARCHAR(255) = NULL,
    @man_hinh NVARCHAR(255) = NULL,
    @trong_luong FLOAT = NULL,
    @nam_san_suat INT = NULL,
    @bao_hanh NVARCHAR(255) = NULL,
    @hinh_anh VARBINARY(MAX) = NULL
AS
BEGIN
    -- Cập nhật thông tin máy tính
    UPDATE MayTinh
    SET 
        ten_may_tinh = COALESCE(@ten_may_tinh, ten_may_tinh),
        mo_ta = COALESCE(@mo_ta, mo_ta),
        gia_tien = COALESCE(@gia_tien, gia_tien),
        ton_kho = COALESCE(@ton_kho, ton_kho),
        cpu = COALESCE(@cpu, cpu),
        ram = COALESCE(@ram, ram),
        o_cung = COALESCE(@o_cung, o_cung),
        card_roi = COALESCE(@card_roi, card_roi),
        man_hinh = COALESCE(@man_hinh, man_hinh),
        trong_luong = COALESCE(@trong_luong, trong_luong),
        nam_san_suat = COALESCE(@nam_san_suat, nam_san_suat),
        bao_hanh = COALESCE(@bao_hanh, bao_hanh),
        hinh_anh = COALESCE(@hinh_anh, hinh_anh)
    WHERE ma_may_tinh = @ma_may_tinh;
END;

---Thêm khuyến mãi
IF OBJECT_ID('dbo.ThemKhuyenMai', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemKhuyenMai;
GO
CREATE PROCEDURE dbo.ThemKhuyenMai
    @ten_khuyen_mai NVARCHAR(255),
    @mo_ta NVARCHAR(255) = NULL,
    @phan_tram_giam FLOAT,
    @so_tien_giam INT = NULL,
    @ngay_bat_dau DATE,
    @ngay_ket_thuc DATE
AS
BEGIN
    DECLARE @ma_khuyen_mai VARCHAR(50);

    -- Gọi hàm để tạo mã khuyến mãi mới
    SET @ma_khuyen_mai = dbo.TaoMaKhuyenMai();

    -- Thêm khuyến mãi mới vào bảng
    INSERT INTO KhuyenMai (ma_khuyen_mai, ten_khuyen_mai, mo_ta, phan_tram_giam, so_tien_giam, ngay_bat_dau, ngay_ket_thuc)
    VALUES (@ma_khuyen_mai, @ten_khuyen_mai, @mo_ta, @phan_tram_giam, @so_tien_giam, @ngay_bat_dau, @ngay_ket_thuc);
END;

---Xóa khuyến mãi
IF OBJECT_ID('dbo.XoaKhuyenMai', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XoaKhuyenMai;
GO
CREATE PROCEDURE dbo.XoaKhuyenMai
    @ma_khuyen_mai VARCHAR(50)
AS
BEGIN
    -- Xóa khuyến mãi
    DELETE FROM KhuyenMai WHERE ma_khuyen_mai = @ma_khuyen_mai;
END;

---Sửa khuyến mãi
IF OBJECT_ID('dbo.SuaKhuyenMai', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SuaKhuyenMai;
GO
CREATE PROCEDURE dbo.SuaKhuyenMai
    @ma_khuyen_mai VARCHAR(50),
    @ten_khuyen_mai NVARCHAR(255) = NULL,
    @mo_ta NVARCHAR(255) = NULL,
    @phan_tram_giam FLOAT = NULL,
    @so_tien_giam INT = NULL,
    @ngay_bat_dau DATE = NULL,
    @ngay_ket_thuc DATE = NULL
AS
BEGIN
    -- Cập nhật thông tin khuyến mãi
    UPDATE KhuyenMai
    SET 
        ten_khuyen_mai = COALESCE(@ten_khuyen_mai, ten_khuyen_mai),
        mo_ta = COALESCE(@mo_ta, mo_ta),
        phan_tram_giam = COALESCE(@phan_tram_giam, phan_tram_giam),
        so_tien_giam = COALESCE(@so_tien_giam, so_tien_giam),
        ngay_bat_dau = COALESCE(@ngay_bat_dau, ngay_bat_dau),
        ngay_ket_thuc = COALESCE(@ngay_ket_thuc, ngay_ket_thuc)
    WHERE ma_khuyen_mai = @ma_khuyen_mai;
END;

---Thêm đơn hàng
CREATE PROCEDURE dbo.ThemDonHang
    @ma_khach_hang VARCHAR(50),
    @ngay_dat_hang DATE,
    @tong_tien INT,
    @trang_thai INT,
    @chi_tiet NVARCHAR(MAX)  -- Tham số chứa chuỗi JSON
AS
BEGIN
    DECLARE @ma_don_hang VARCHAR(50);

    -- Gọi hàm để tạo mã đơn hàng mới
    SET @ma_don_hang = dbo.TaoMaDonHang();

    -- Thêm đơn hàng mới vào bảng DonHang
    INSERT INTO DonHang (ma_don_hang, ma_khach_hang, ngay_dat_hang, tong_tien, trang_thai)
    VALUES (@ma_don_hang, @ma_khach_hang, @ngay_dat_hang, @tong_tien, @trang_thai);

    -- Thêm chi tiết đơn hàng vào bảng DonHangChiTiet từ chuỗi JSON
    INSERT INTO DonHangChiTiet (ma_don_hang, ma_may_tinh, gia_ban, so_luong)
    SELECT 
        @ma_don_hang, 
        JSON_VALUE(value, '$.ma_may_tinh'), 
        JSON_VALUE(value, '$.gia_ban'), 
        JSON_VALUE(value, '$.so_luong')
    FROM OPENJSON(@chi_tiet) AS value;
END;

---Cập nhật trạng thái của đơn hàng 1: hoàn thành, 2: chưa hoàn thành, 3: hủy
IF OBJECT_ID('dbo.CapNhatTrangThaiDonHang', 'P') IS NOT NULL
    DROP PROCEDURE dbo.CapNhatTrangThaiDonHang;
GO
CREATE PROCEDURE dbo.CapNhatTrangThaiDonHang
    @ma_don_hang VARCHAR(50),
    @trang_thai INT  -- Tham số cho trạng thái mới
AS
BEGIN
    -- Cập nhật trạng thái đơn hàng
    UPDATE DonHang
    SET trang_thai = @trang_thai
    WHERE ma_don_hang = @ma_don_hang;
END;