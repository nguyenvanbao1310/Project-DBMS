﻿use ShopMayTinh;
---Thêm tài khoản
IF OBJECT_ID('dbo.ThemTaiKhoan', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemTaiKhoan;
GO
CREATE PROCEDURE dbo.ThemTaiKhoan
    @ten_khach_hang NVARCHAR(100),
    @tai_khoan VARCHAR(50),
    @mat_khau VARCHAR(50),
    @email VARCHAR(100),
	@dia_chi nvarchar(255)
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
--- Lấy mã người dùng của khách hàng

IF OBJECT_ID('dbo.LayMaNguoiDung', 'P') IS NOT NULL
    DROP PROCEDURE dbo.LayMaNguoiDung;
GO

CREATE PROCEDURE dbo.LayMaNguoiDung
	@tai_khoan varchar(50),
	@mat_khau varchar(255)
AS
BEGIN
	SELECT ma_nguoi_dung 
    FROM TaiKhoan 
    WHERE tai_khoan = @tai_khoan AND mat_khau = @mat_khau
END
GO

---thêm máy tính
IF OBJECT_ID('dbo.ThemMayTinh', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemMayTinh;
GO

CREATE PROCEDURE dbo.ThemMayTinh
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
    @duong_dan NVARCHAR(255) = NULL
AS
BEGIN
    DECLARE @ma_may_tinh VARCHAR(50);
	DECLARE @hinh_anh VARBINARY(MAX);
    DECLARE @sql NVARCHAR(MAX);
    DECLARE @checkResult NVARCHAR(255);
	-- Gán hình ảnh mặc định nếu không có đường dẫn
    IF @duong_dan IS NULL OR @duong_dan = ''
    BEGIN
        SELECT @hinh_anh = BulkColumn
        FROM OPENROWSET(BULK 'D:\DBMS\MayTinhPic\default.png', SINGLE_BLOB) AS Image;
    END
    ELSE
    BEGIN
        -- Sử dụng câu lệnh động để gán hình ảnh từ đường dẫn
        SET @sql = 'SELECT @hinh_anh = BulkColumn FROM OPENROWSET(BULK ''' + @duong_dan + ''', SINGLE_BLOB) AS Image';
        EXEC sp_executesql @sql, N'@hinh_anh VARBINARY(MAX) OUTPUT', @hinh_anh OUTPUT;
    END
    -- Gọi hàm để kiểm tra tính hợp lệ của dữ liệu
    SET @checkResult = dbo.CheckSanPhamTruocKhiThem(
        @ten_may_tinh,
        @gia_tien,
        @ton_kho,
        @trong_luong,
        @nam_san_suat,
        @cpu,
        @ram,
        @o_cung,
        @man_hinh,
        @bao_hanh,
		@hinh_anh
    );

    -- Nếu dữ liệu không hợp lệ, phát sinh lỗi
    IF @checkResult <> 'Hợp lệ'
    BEGIN
        RAISERROR(@checkResult, 16, 1);
        RETURN; -- Kết thúc thủ tục nếu có lỗi
    END

    -- Gọi hàm để tạo mã máy tính mới
    SET @ma_may_tinh = dbo.TaoMaMayTinh();

    -- Thêm máy tính mới vào bảng
    INSERT INTO MayTinh (ma_may_tinh, ten_may_tinh, mo_ta, gia_tien, ton_kho, cpu, ram, o_cung, card_roi, man_hinh, trong_luong, nam_san_suat, bao_hanh, hinh_anh)
    VALUES (@ma_may_tinh, @ten_may_tinh, @mo_ta, @gia_tien, @ton_kho, @cpu, @ram, @o_cung, @card_roi, @man_hinh, @trong_luong, @nam_san_suat, @bao_hanh, @hinh_anh);
    PRINT(N'Thêm máy tính thành công');
	
END;
GO

---Xóa máy tính

IF OBJECT_ID('dbo.XoaMayTinh', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XoaMayTinh;
GO
CREATE PROCEDURE dbo.XoaMayTinh
    @ma_may_tinh VARCHAR(50)
AS
BEGIN
    BEGIN TRY
        -- Kiểm tra xem mã máy tính có tồn tại không
        IF EXISTS (SELECT 1 FROM MayTinh WHERE ma_may_tinh = @ma_may_tinh)
        BEGIN
            -- Xóa máy tính
            DELETE FROM MayTinh WHERE ma_may_tinh = @ma_may_tinh;
            -- Thông báo thành công
            PRINT N'Xóa máy tính thành công';
        END
        ELSE
        BEGIN
            PRINT N'Mã máy tính không tồn tại';
        END
    END TRY
    BEGIN CATCH
        -- Thông báo thất bại với thông tin lỗi
        PRINT ERROR_MESSAGE();
    END CATCH;
END;
GO
---Sửa máy tính
IF OBJECT_ID('dbo.SuaMayTinh', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SuaMayTinh;
GO
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
	 IF @ten_may_tinh IS NULL OR @ten_may_tinh = ''
    BEGIN
        RAISERROR('Tên máy tính không được để trống', 16, 1);
        RETURN;
    END

    IF @gia_tien IS NULL OR @gia_tien <= 0
    BEGIN
        RAISERROR('Giá tiền không hợp lệ', 16, 1);
        RETURN;
    END

    IF @ton_kho IS NULL OR @ton_kho < 0
    BEGIN
        RAISERROR('Số lượng tồn kho không hợp lệ', 16, 1);
        RETURN;
    END

    IF @cpu IS NULL OR @cpu = ''
    BEGIN
        RAISERROR('CPU không được để trống', 16, 1);
        RETURN;
    END

    IF @ram IS NULL OR @ram = ''
    BEGIN
        RAISERROR('RAM không được để trống', 16, 1);
        RETURN;
    END

    IF @o_cung IS NULL OR @o_cung = ''
    BEGIN
        RAISERROR('Ổ cứng không được để trống', 16, 1);
        RETURN;
    END

    IF @man_hinh IS NULL OR @man_hinh = ''
    BEGIN
        RAISERROR('Màn hình không được để trống', 16, 1);
        RETURN;
    END

    IF @trong_luong IS NULL OR @trong_luong <= 0
    BEGIN
        RAISERROR('Trọng lượng không hợp lệ', 16, 1);
        RETURN;
    END

    IF @nam_san_suat IS NULL OR @nam_san_suat <= 0
    BEGIN
        RAISERROR('Năm sản xuất không hợp lệ', 16, 1);
        RETURN;
    END

    IF @bao_hanh IS NULL OR @bao_hanh = ''
    BEGIN
        RAISERROR('Bảo hành không được để trống', 16, 1);
        RETURN;
    END
    BEGIN TRY
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

        -- Thông báo thành công
        PRINT N'Sửa máy tính thành công';
    END TRY
    BEGIN CATCH
        -- Thông báo thất bại với thông tin lỗi
        PRINT ERROR_MESSAGE();
    END CATCH;
END;
GO

--- load thông tin sản phẩm chi tiết 
IF OBJECT_ID('dbo.XemChiTietMayTinh', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XemChiTietMayTinh;
GO
CREATE PROCEDURE XemChiTietMayTinh
    @ma_may_tinh VARCHAR(50)
AS
BEGIN
    SELECT ma_may_tinh, ten_may_tinh, mo_ta, gia_tien, ton_kho, cpu, ram, o_cung, card_roi, man_hinh, trong_luong, nam_san_suat, bao_hanh, hinh_anh
    FROM MayTinh
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
    @ngay_ket_thuc DATE,
	@ma_may_tinh VARCHAR(50)
AS
BEGIN
    DECLARE @ma_khuyen_mai VARCHAR(50);
    DECLARE @checkResult NVARCHAR(255);

    -- Gọi hàm để kiểm tra tính hợp lệ của dữ liệu
    SET @checkResult = dbo.CheckKhuyenMaiTruocKhiThem(
        @ten_khuyen_mai,
        @phan_tram_giam,
        @so_tien_giam,
        @ngay_bat_dau,
        @ngay_ket_thuc
    );

    -- Nếu dữ liệu không hợp lệ, phát sinh lỗi
    IF @checkResult <> 'Hợp lệ'
    BEGIN
        RAISERROR(@checkResult, 16, 1);
        RETURN; -- Kết thúc thủ tục nếu có lỗi
    END

    -- Gọi hàm để tạo mã khuyến mãi mới
    SET @ma_khuyen_mai = dbo.TaoMaKhuyenMai();

    -- Thêm khuyến mãi mới vào bảng
    INSERT INTO KhuyenMai (ma_khuyen_mai, ten_khuyen_mai, mo_ta, phan_tram_giam, so_tien_giam, ngay_bat_dau, ngay_ket_thuc)
    VALUES (@ma_khuyen_mai, @ten_khuyen_mai, @mo_ta, @phan_tram_giam, @so_tien_giam, @ngay_bat_dau, @ngay_ket_thuc);
    
	INSERT INTO SanPham_KhuyenMai (ma_may_tinh, ma_khuyen_mai)
    VALUES (@ma_may_tinh, @ma_khuyen_mai);
    
	PRINT(N'Thêm thành công!');
END;
GO

---Xóa khuyến mãi
IF OBJECT_ID('dbo.XoaKhuyenMai', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XoaKhuyenMai;
GO
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

---Thêm khuyến mãi cho các sản phẩm
IF OBJECT_ID('dbo.ThemKhuyenMaiSanPham', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemKhuyenMaiSanPham;
GO

IF OBJECT_ID('dbo.ThemKhuyenMaiSanPham', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemKhuyenMaiSanPham;
GO
CREATE PROCEDURE dbo.ThemKhuyenMaiSanPham
(
    @ma_khuyen_mai VARCHAR(50),
    @ma_may_tinh VARCHAR(50)
)
AS
BEGIN
    -- Kiểm tra xem khuyến mãi có tồn tại không
    IF NOT EXISTS (SELECT 1 FROM KhuyenMai WHERE ma_khuyen_mai = @ma_khuyen_mai)
    BEGIN
        RAISERROR('Khuyến mãi không tồn tại.', 16, 1);
        RETURN;
    END

    -- Kiểm tra xem sản phẩm có tồn tại không
    IF NOT EXISTS (SELECT 1 FROM MayTinh WHERE ma_may_tinh = @ma_may_tinh)
    BEGIN
        RAISERROR('Sản phẩm không tồn tại.', 16, 1);
        RETURN;
    END

    -- Thêm khuyến mãi cho sản phẩm
    INSERT INTO SanPham_KhuyenMai (ma_may_tinh, ma_khuyen_mai)
    VALUES (@ma_may_tinh, @ma_khuyen_mai);
END;
GO

--- Xem các sản phẩm được áp dụng với mỗi khuyến mãi
IF OBJECT_ID('dbo.XemSanPhamApDungVoiMoiKhuyenMai', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XemSanPhamApDungVoiMoiKhuyenMai;
GO
CREATE PROCEDURE dbo.XemSanPhamApDungVoiMoiKhuyenMai
(
    @ma_khuyen_mai VARCHAR(50)
)
AS
BEGIN
	SELECT *
	FROM View_SanPhamKhuyenMai
	WHERE View_SanPhamKhuyenMai.ma_khuyen_mai = @ma_khuyen_mai
END;


--- Xóa SanPham_KhuyenMai

IF OBJECT_ID('dbo.XoaSanPham_KhuyenMai', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XoaSanPham_KhuyenMai;
GO
CREATE PROCEDURE dbo.XoaSanPham_KhuyenMai
(
    @ma_khuyen_mai VARCHAR(50),
	@ma_may_tinh varchar(50)
)
AS
BEGIN
	DELETE FROM SanPham_KhuyenMai
	WHERE SanPham_KhuyenMai.ma_khuyen_mai = @ma_khuyen_mai AND SanPham_KhuyenMai.ma_may_tinh = @ma_may_tinh
END


---Thêm đánh giá
IF OBJECT_ID('dbo.ThemDanhGia', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemDanhGia;
GO

IF OBJECT_ID('dbo.ThemDanhGia', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemDanhGia;
GO
CREATE PROCEDURE dbo.ThemDanhGia
    @ma_khach_hang VARCHAR(50),
    @ma_may_tinh VARCHAR(50),
    @so_sao_danh_gia INT,
    @noi_dung NVARCHAR(255)
AS
BEGIN
    DECLARE @ma_danh_gia VARCHAR(50);
    SET @ma_danh_gia = dbo.TaoMaDanhGia();  -- Giả sử bạn đã có hàm tạo mã đánh giá

    -- Kiểm tra xem khách hàng đã đặt hàng sản phẩm này và đơn hàng đã hoàn thành chưa
    IF EXISTS (
        SELECT 1
        FROM DonHang dh
        JOIN DonHangChiTiet dht ON dh.ma_don_hang = dht.ma_don_hang
        WHERE dh.ma_khach_hang = @ma_khach_hang 
          AND dht.ma_may_tinh = @ma_may_tinh 
          AND dh.trang_thai = 1  -- 1 có thể là trạng thái hoàn thành
    )
    BEGIN
        -- Thêm đánh giá vào bảng
        INSERT INTO DanhGia (ma_danh_gia, ma_khach_hang, ma_may_tinh, so_sao_danh_gia, ngay_danh_gia, noi_dung)
        VALUES (@ma_danh_gia, @ma_khach_hang, @ma_may_tinh, @so_sao_danh_gia, GETDATE(), @noi_dung);
    END
    ELSE
    BEGIN
        -- Nếu không thỏa mãn điều kiện, có thể thông báo hoặc xử lý khác
        PRINT 'Khách hàng chưa mua sản phẩm này hoặc đơn hàng chưa hoàn thành.';
    END
END;
GO

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
GO

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
GO

---Xem  danh sách đánh giá của 1 máy tính
IF OBJECT_ID('dbo.XemDanhGia1SanPham', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XemDanhGia1SanPham;
GO
CREATE PROCEDURE dbo.XemDanhGia1SanPham
    @ma_may_tinh VARCHAR(50)
AS
BEGIN
-- Xóa đánh giá
SELECT ma_danh_gia, ma_khach_hang, DanhGia.ma_may_tinh, so_sao_danh_gia, ngay_danh_gia, noi_dung, hinh_anh
	FROM DanhGia INNER JOIN MayTinh ON DanhGia.ma_may_tinh = MayTinh.ma_may_tinh
    WHERE DanhGia.ma_may_tinh = @ma_may_tinh;
END;
GO







--- Thêm đơn hàng
IF OBJECT_ID('dbo.ThemDonHang', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemDonHang;
GO

CREATE PROCEDURE dbo.ThemDonHang
    @ma_don_hang VARCHAR(50),
    @ma_khach_hang VARCHAR(50),
    @ngay_dat_hang DATE,
    @tong_tien INT,
    @trang_thai INT
AS
BEGIN
    -- Thêm đơn hàng mới vào bảng
    INSERT INTO DonHang (ma_don_hang, ma_khach_hang, ngay_dat_hang, tong_tien, trang_thai)
    VALUES (@ma_don_hang, @ma_khach_hang, @ngay_dat_hang, @tong_tien, @trang_thai);
END;
GO

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
GO

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
GO

--- Xem lịch sử đơn hàng
IF OBJECT_ID('dbo.XemLichSuDonHang', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XemLichSuDonHang;
GO

CREATE PROCEDURE dbo.XemLichSuDonHang
	@ma_nguoi_dung varchar(50)
AS
BEGIN
	SELECT ma_don_hang, ngay_dat_hang, trang_thai
    FROM DonHang 
    WHERE ma_khach_hang = @ma_nguoi_dung
END
GO

--- Xem chi tiết đơn hàng từ 1 đơn hàng.
IF OBJECT_ID('dbo.XemChiTietDonHang', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XemChiTietDonHang;
GO

CREATE PROCEDURE dbo.XemChiTietDonHang
	@ma_don_hang varchar(50)
AS
BEGIN
	SELECT DonHangChiTiet.ma_may_tinh, ten_may_tinh, gia_ban, so_luong 
    FROM DonHangChiTiet INNER JOIN MayTinh ON DonHangChiTiet.ma_may_tinh = MayTinh.ma_may_tinh
    WHERE ma_don_hang = @ma_don_hang
END
GO

--- Lấy các đơn hàng của 1 người dùng với trạng thái là hoàn thành
IF OBJECT_ID('dbo.LayDonHangHoanThanhCuaKhachHang', 'P') IS NOT NULL
    DROP PROCEDURE dbo.LayDonHangHoanThanhCuaKhachHang;
GO

CREATE PROCEDURE dbo.LayDonHangHoanThanhCuaKhachHang
	@ma_khach_hang varchar(50)
AS
BEGIN
	SELECT *
	FROM DonHang
    WHERE ma_khach_hang = @ma_khach_hang
	AND trang_thai = 1
END
GO
--- Xem danh sách sản phẩm từ giỏ hàng.
IF OBJECT_ID('dbo.XemGioHang', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XemGioHang;
GO
CREATE PROCEDURE dbo.XemGioHang 
	@ma_khach_hang varchar(50)
AS
BEGIN
	SELECT ma_khach_hang, GioHang.ma_may_tinh, ten_may_tinh, gia_tien, so_luong
	FROM GioHang INNER JOIN MayTinh ON GioHang.ma_may_tinh = MayTinh.ma_may_tinh
	WHERE GioHang.ma_khach_hang = @ma_khach_hang
END;
GO

--- Xem chi tiết máy tính
IF OBJECT_ID('dbo.XemChiTietMayTinh', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XemChiTietMayTinh;
GO

CREATE PROCEDURE dbo.XemChiTietMayTinh
    @ma_may_tinh varchar(50)
AS
BEGIN
    SELECT * 
    FROM View_MayTinh
    WHERE ma_may_tinh = @ma_may_tinh;
END;
GO

---Thêm vào giỏ hàng
IF OBJECT_ID('dbo.ThemVaoGioHang', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThemVaoGioHang;
GO

CREATE PROCEDURE dbo.ThemVaoGioHang
    @ma_khach_hang VARCHAR(50),
    @ma_may_tinh VARCHAR(50)
AS
BEGIN
    BEGIN TRY
        -- Kiểm tra xem khách hàng có tồn tại không
        IF NOT EXISTS (SELECT 1 FROM KhachHang WHERE ma_khach_hang = @ma_khach_hang)
        BEGIN
            RAISERROR('Khách hàng không tồn tại.', 16, 1);
            RETURN;
        END

        -- Kiểm tra số lượng tồn kho của sản phẩm
        DECLARE @trangThai INT;
        SET @trangThai = dbo.KiemTraTonKho(@ma_may_tinh);

        IF @trangThai = 0
        BEGIN
            RAISERROR(N'Sản phẩm không còn hàng trong kho.', 16, 1);
            RETURN;
        END
        ELSE IF @trangThai = -1
        BEGIN
            RAISERROR(N'Sản phẩm không tồn tại.', 16, 1);
            RETURN;
        END

        -- Kiểm tra xem sản phẩm đã có trong giỏ hàng của khách hàng chưa
        IF EXISTS (SELECT 1 FROM GioHang WHERE ma_khach_hang = @ma_khach_hang AND ma_may_tinh = @ma_may_tinh)
        BEGIN
            -- Cập nhật số lượng nếu sản phẩm đã có trong giỏ hàng
            UPDATE GioHang
            SET so_luong = so_luong + 1
            WHERE ma_khach_hang = @ma_khach_hang AND ma_may_tinh = @ma_may_tinh;

            PRINT N'Sản phẩm đã được cập nhật số lượng trong giỏ hàng.';
        END
        ELSE
        BEGIN
            -- Thêm sản phẩm mới vào giỏ hàng với số lượng là 1
            INSERT INTO GioHang (ma_khach_hang, ma_may_tinh, so_luong)
            VALUES (@ma_khach_hang, @ma_may_tinh, 1);

            PRINT N'Sản phẩm đã được thêm vào giỏ hàng.';
        END
    END TRY
    BEGIN CATCH
        -- Thông báo thất bại với thông tin lỗi
        PRINT ERROR_MESSAGE();
    END CATCH;
END;
GO

--- Xóa sản phẩm khỏi giỏ hàng
IF OBJECT_ID('dbo.XoaKhoiGioHang', 'P') IS NOT NULL
    DROP PROCEDURE dbo.XoaKhoiGioHang;
GO

CREATE PROCEDURE dbo.XoaKhoiGioHang
    @ma_khach_hang VARCHAR(50),
    @ma_may_tinh VARCHAR(50)
AS
BEGIN
    -- Kiểm tra xem sản phẩm có trong giỏ hàng của khách hàng không
    IF EXISTS (SELECT 1 FROM GioHang WHERE ma_khach_hang = @ma_khach_hang AND ma_may_tinh = @ma_may_tinh)
    BEGIN
        -- Xóa sản phẩm khỏi giỏ hàng
        DELETE FROM GioHang
        WHERE ma_khach_hang = @ma_khach_hang AND ma_may_tinh = @ma_may_tinh;
    END
    ELSE
    BEGIN
        PRINT N'Sản phẩm không có trong giỏ hàng.';
    END
END;
GO


--- Tìm kiếm sản phẩm
IF OBJECT_ID('dbo.TimKiemSanPham', 'P') IS NOT NULL
    DROP PROCEDURE dbo.TimKiemSanPham;
GO
CREATE PROCEDURE dbo.TimKiemSanPham
    @tu_khoa NVARCHAR(255)
AS
BEGIN
    SELECT *
    FROM View_MayTinh
    WHERE 
        ten_may_tinh LIKE '%' + @tu_khoa + '%' OR
        mo_ta LIKE '%' + @tu_khoa + '%' OR
        cpu LIKE '%' + @tu_khoa + '%' OR
        ram LIKE '%' + @tu_khoa + '%' OR
        o_cung LIKE '%' + @tu_khoa + '%' OR
        card_roi LIKE '%' + @tu_khoa + '%' OR
        man_hinh LIKE '%' + @tu_khoa + '%';
END;
GO
--- Lấy dữ liệu khuyến mãi (Khách hàng, mã và sản phẩm).
IF OBJECT_ID('dbo.LayThongTinKhuyenMai', 'P') IS NOT NULL
    DROP PROCEDURE dbo.LayThongTinKhuyenMai;
GO
CREATE PROCEDURE dbo.LayThongTinKhuyenMai
    @ma_nguoi_dung VARCHAR(50)
AS
BEGIN
    SELECT 
        KhuyenMai.ten_khuyen_mai,
		KhuyenMai.phan_tram_giam,
        MayTinh.ten_may_tinh,
		KhuyenMai.ngay_ket_thuc
    FROM 
        SanPham_KhuyenMai 
    INNER JOIN 
        KhuyenMai_KhachHang 
        ON SanPham_KhuyenMai.ma_khuyen_mai = KhuyenMai_KhachHang.ma_khuyen_mai
	INNER JOIN 
        KhuyenMai 
        ON KhuyenMai_KhachHang.ma_khuyen_mai = KhuyenMai.ma_khuyen_mai
    INNER JOIN 
        MayTinh 
        ON SanPham_KhuyenMai.ma_may_tinh = MayTinh.ma_may_tinh
    WHERE 
        KhuyenMai_KhachHang.ma_khach_hang = @ma_nguoi_dung 
    AND 
        KhuyenMai_KhachHang.trang_thai = 1;
END;
GO

--- Lấy dữ liệu của các voucher theo từng sản phẩm (Khách hàng, mã sản phẩm và các khuyến mãi được dùng cho sản phẩm đó).
IF OBJECT_ID('dbo.ApDungKhuyenMaiVaoSanPham', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ApDungKhuyenMaiVaoSanPham;
GO
CREATE PROCEDURE dbo.ApDungKhuyenMaiVaoSanPham
    @ma_nguoi_dung VARCHAR(50),
	@ma_may_tinh varchar (50)
AS
BEGIN
    SELECT 
        KhuyenMai.ten_khuyen_mai,
		KhuyenMai.phan_tram_giam,
        MayTinh.ten_may_tinh,
		KhuyenMai.ngay_ket_thuc
    FROM 
        SanPham_KhuyenMai 
    INNER JOIN 
        KhuyenMai_KhachHang 
        ON SanPham_KhuyenMai.ma_khuyen_mai = KhuyenMai_KhachHang.ma_khuyen_mai
	INNER JOIN 
        KhuyenMai 
        ON KhuyenMai_KhachHang.ma_khuyen_mai = KhuyenMai.ma_khuyen_mai
    INNER JOIN 
        MayTinh 
        ON SanPham_KhuyenMai.ma_may_tinh = MayTinh.ma_may_tinh
    WHERE 
        KhuyenMai_KhachHang.ma_khach_hang = @ma_nguoi_dung
    AND 
		SanPham_KhuyenMai.ma_may_tinh = @ma_may_tinh
	AND
        KhuyenMai_KhachHang.trang_thai = 1;
END;
GO

IF OBJECT_ID('dbo.GetMayTinhTheoSoSaoTrungBinh', 'P') IS NOT NULL
    DROP PROCEDURE dbo.GetMayTinhTheoSoSaoTrungBinh;
GO

CREATE PROCEDURE dbo.GetMayTinhTheoSoSaoTrungBinh
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        m.ma_may_tinh,
        m.ten_may_tinh,
        m.gia_tien,
        m.ton_kho,
        m.cpu,
        m.ram,
        m.o_cung,
        m.card_roi,
        m.man_hinh,
        m.trong_luong,
        m.nam_san_suat,
        m.bao_hanh,
        m.hinh_anh,
        COALESCE(dbo.TinhSoSaoTrungBinh(m.ma_may_tinh), 0) AS so_sao_trung_binh
    FROM 
        MayTinh m
    ORDER BY 
        so_sao_trung_binh DESC;  -- Sắp xếp theo số sao trung bình giảm dần
END;
GO

--- Đăng kí tài khoản
IF OBJECT_ID('dbo.DangKi', 'P') IS NOT NULL
    DROP PROCEDURE dbo.DangKi;
GO
CREATE PROCEDURE dbo.DangKi 
    @tai_khoan varchar (50),
    @mat_khau NVARCHAR(255),
	@email NVARCHAR(255),
    @ten_khach_hang NVARCHAR(255),
	@dia_chi NVARCHAR(255),
	@so_dien_thoai VARCHAR(20)
AS
BEGIN
	IF @tai_khoan IS NULL OR @tai_khoan = ''
    BEGIN
        RAISERROR (N'Tài khoản không được để trống.', 16, 1);
        RETURN;
    END;
    IF @mat_khau IS NULL OR @mat_khau = ''
    BEGIN
        RAISERROR (N'Mật khẩu không được để trống.', 16, 1);
        RETURN;
    END;
    IF @email IS NULL OR @email = ''
    BEGIN
        RAISERROR (N'Email không được để trống.', 16, 1);
        RETURN;
    END;
    IF @ten_khach_hang IS NULL OR @ten_khach_hang = ''
    BEGIN
        RAISERROR (N'Tên khách hàng không được để trống.', 16, 1);
        RETURN;
    END;
    IF @dia_chi IS NULL OR @dia_chi = ''
    BEGIN
        RAISERROR (N'Địa chỉ không được để trống.', 16, 1);
        RETURN;
    END;
    IF @so_dien_thoai IS NULL OR @so_dien_thoai = ''
    BEGIN
        RAISERROR (N'Số điện thoại không được để trống.', 16, 1);
        RETURN;
    END;

    -- Kiểm tra số điện thoại hợp lệ
    IF @so_dien_thoai NOT LIKE '[0-9]%' OR LEN(@so_dien_thoai) < 10 OR LEN(@so_dien_thoai) > 11
    BEGIN
        RAISERROR (N'Số điện thoại không hợp lệ. Vui lòng nhập số điện thoại gồm 10-11 chữ số.', 16, 1);
        RETURN;
    END;
    DECLARE @EmailExists BIT;
    SET @EmailExists = dbo.KiemTraEmail(@Email);

    IF @EmailExists = 1
    BEGIN
        -- Email đã tồn tại
        RAISERROR (N'Email này đã được đăng ký. Vui lòng sử dụng email khác.', 16, 1);
        RETURN;
    END
    ELSE
    BEGIN
		DECLARE @ma_khach_hang VARCHAR(50);
		-- Gọi hàm để tạo mã khách hàng mới
		SET @ma_khach_hang = dbo.TaoMaKhachHang();
		INSERT INTO TaiKhoan(tai_khoan, mat_khau, ma_nguoi_dung)
		VALUES(@tai_khoan, @mat_khau, @ma_khach_hang)
		
        INSERT INTO KhachHang (ma_khach_hang, ten_khach_hang, email, dia_chi, so_dien_thoai)
        VALUES (@ma_khach_hang, @ten_khach_hang, @email, @dia_chi, @so_dien_thoai);

        PRINT N'Đăng ký thành công.';
    END
END
GO

IF OBJECT_ID('dbo.ThongTinCaNhan', 'P') IS NOT NULL
    DROP PROCEDURE dbo.ThongTinCaNhan;
GO
CREATE PROCEDURE dbo.ThongTinCaNhan
	@ma_nguoi_dung varchar (50)
AS
BEGIN 
	SELECT * FROM View_KhachHang INNER JOIN TaiKhoan ON View_KhachHang.ma_khach_hang = TaiKhoan.ma_nguoi_dung
	WHERE ma_khach_hang = @ma_nguoi_dung
END
GO

EXECUTE dbo.ThongTinCaNhan 'kh0001'

