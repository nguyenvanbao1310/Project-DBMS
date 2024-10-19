use ShopMayTinh;
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
IF OBJECT_ID('dbo.ThemDonHang', 'P') IS NOT NULL
	DROP PROCEDURE dbo.ThemDonHang;
GO
CREATE PROCEDURE dbo.ThemDonHang
	@ma_khach_hang VARCHAR(50),
	@ngay_dat_hang DATE,
	@tong_tien INT,
	@trang_thai INT
	AS
	BEGIN
	DECLARE @ma_don_hang VARCHAR(50);

	-- Gọi hàm để tạo mã đơn hàng mới
	SET @ma_don_hang = dbo.TaoMaDonHang();

	-- Thêm đơn hàng mới vào bảng
	INSERT INTO DonHang (ma_don_hang, ma_khach_hang, ngay_dat_hang, tong_tien, trang_thai)
	VALUES (@ma_don_hang, @ma_khach_hang, @ngay_dat_hang, @tong_tien, @trang_thai);
END;

---thêm đơn hàng chi tiết
IF OBJECT_ID('dbo.ThemDonHangChiTiet', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemDonHangChiTiet;
GO
CREATE PROCEDURE dbo.ThemDonHangChiTiet
    @ma_don_hang VARCHAR(50),
    @ma_may_tinh VARCHAR(50),
    @gia_ban INT,
    @so_luong INT
AS
BEGIN
    -- Kiểm tra xem đơn hàng đã tồn tại chưa
    IF NOT EXISTS (SELECT 1 FROM DonHang WHERE ma_don_hang = @ma_don_hang)
    BEGIN
        RAISERROR('Đơn hàng không tồn tại.', 16, 1);
        RETURN;
    END

    -- Kiểm tra xem máy tính đã tồn tại chưa
    IF NOT EXISTS (SELECT 1 FROM MayTinh WHERE ma_may_tinh = @ma_may_tinh)
    BEGIN
        RAISERROR('Máy tính không tồn tại.', 16, 1);
        RETURN;
    END

    -- Thêm chi tiết đơn hàng vào bảng DonHangChiTiet
    INSERT INTO DonHangChiTiet (ma_don_hang, ma_may_tinh, gia_ban, so_luong)
    VALUES (@ma_don_hang, @ma_may_tinh, @gia_ban, @so_luong);
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

---Thêm đánh giá
IF OBJECT_ID('dbo.ThemDanhGia', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemDanhGia;
GO
CREATE PROCEDURE dbo.ThemDanhGia
    @ma_khach_hang VARCHAR(50),
    @ma_don_hang VARCHAR(50),
    @so_sao_danh_gia INT,
    @ngay_danh_gia DATE,
    @noi_dung NVARCHAR(255)
AS
BEGIN
    DECLARE @ma_danh_gia VARCHAR(50);
    DECLARE @trang_thai INT;

    -- Kiểm tra xem khách hàng có đơn hàng hoàn thành không
    SELECT @trang_thai = trang_thai
    FROM DonHang
    WHERE ma_don_hang = @ma_don_hang AND ma_khach_hang = @ma_khach_hang;

    IF @trang_thai IS NULL
    BEGIN
        RAISERROR('Bạn không có lịch sử mua sản phẩm này!.', 16, 1);
        RETURN;
    END

    IF @trang_thai <> 1 -- Trạng thái 1 là "hoàn thành"
    BEGIN
        RAISERROR('Đơn hàng chưa hoàn thành hoặc đã bị hủy, không thể đánh giá.', 16, 1);
        RETURN;
    END

    -- Tạo mã đánh giá mới
    SET @ma_danh_gia = dbo.TaoMaDanhGia();

    -- Thêm đánh giá vào bảng
    INSERT INTO DanhGia (ma_danh_gia, ma_khach_hang, ma_don_hang, so_sao_danh_gia, ngay_danh_gia, noi_dung)
    VALUES (@ma_danh_gia, @ma_khach_hang, @ma_don_hang, @so_sao_danh_gia, @ngay_danh_gia, @noi_dung);
END;

---Sửa đánh giá
IF OBJECT_ID('dbo.SuaDanhGia', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SuaDanhGia;
GO
CREATE PROCEDURE dbo.SuaDanhGia
    @ma_danh_gia VARCHAR(50),
    @so_sao_danh_gia INT,
    @ngay_danh_gia DATE,
    @noi_dung NVARCHAR(255)
AS
BEGIN
    -- Cập nhật đánh giá
    UPDATE DanhGia
    SET 
        so_sao_danh_gia = @so_sao_danh_gia,
        ngay_danh_gia = @ngay_danh_gia,
        noi_dung = @noi_dung
    WHERE ma_danh_gia = @ma_danh_gia;
END;

---xóa đánh giá
IF OBJECT_ID('dbo.XoaDanhGia', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XoaDanhGia;
GO
CREATE PROCEDURE dbo.XoaDanhGia
    @ma_danh_gia VARCHAR(50)
AS
BEGIN
-- Xóa đánh giá
DELETE FROM DanhGia
    WHERE ma_danh_gia = @ma_danh_gia;
END;

---Thêm vào giỏ hàng
IF OBJECT_ID('dbo.ThemVaoGioHang', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemVaoGioHang;
GO
CREATE PROCEDURE dbo.ThemVaoGioHang
    @ma_khach_hang VARCHAR(50),
    @ma_may_tinh VARCHAR(50)
AS
BEGIN
    -- Kiểm tra xem sản phẩm đã có trong giỏ hàng của khách hàng chưa
    IF EXISTS (SELECT 1 FROM GioHang WHERE ma_khach_hang = @ma_khach_hang AND ma_may_tinh = @ma_may_tinh)
    BEGIN
        -- Cập nhật số lượng nếu sản phẩm đã có trong giỏ hàng
        UPDATE GioHang
        SET so_luong = so_luong + 1
        WHERE ma_khach_hang = @ma_khach_hang AND ma_may_tinh = @ma_may_tinh;
    END
    ELSE
    BEGIN
        -- Thêm sản phẩm mới vào giỏ hàng với số lượng là 1
        INSERT INTO GioHang (ma_khach_hang, ma_may_tinh, so_luong)
        VALUES (@ma_khach_hang, @ma_may_tinh, 1);
    END
END;