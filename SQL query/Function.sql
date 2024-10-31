use ShopMayTinh;
---tạo mã tài khoản KH khi đăng kí
IF OBJECT_ID('dbo.TaoMaKhachHang', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TaoMaKhachHang;
GO
CREATE FUNCTION dbo.TaoMaKhachHang()
RETURNS VARCHAR(50)
AS
BEGIN
    DECLARE @ma_khach_hang VARCHAR(50);
    DECLARE @new_id INT; 

    -- Lấy giá trị cao nhất hiện có của mã khách hàng
    SELECT @new_id = COALESCE(MAX(
                                    CASE 
                                        WHEN ma_khach_hang LIKE 'kh%' AND LEN(ma_khach_hang) > 2 
                                        THEN TRY_CAST(RIGHT(ma_khach_hang, LEN(ma_khach_hang) - 2) AS INT)
                                        ELSE NULL 
                                    END), 0) + 1
    FROM KhachHang;

    -- Tạo mã khách hàng mới
    SET @ma_khach_hang = 'kh' + RIGHT('0000' + CAST(@new_id AS VARCHAR), 4);

    RETURN @ma_khach_hang;
END;
GO


---tạo mã máy tính khi thêm mới
IF OBJECT_ID('dbo.TaoMaMayTinh', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TaoMaMayTinh;
GO

CREATE FUNCTION dbo.TaoMaMayTinh()
RETURNS VARCHAR(50)
AS
BEGIN
    DECLARE @ma_may_tinh VARCHAR(50);
    DECLARE @new_id INT;

    -- Lấy giá trị cao nhất hiện có của mã máy tính
    SELECT @new_id = COALESCE(MAX(
                                    CASE 
                                        WHEN ma_may_tinh LIKE 'mt%' AND LEN(ma_may_tinh) > 2 
                                        THEN TRY_CAST(RIGHT(ma_may_tinh, LEN(ma_may_tinh) - 2) AS INT)
                                        ELSE NULL 
                                    END), 0) + 1
    FROM MayTinh;

    -- Tạo mã máy tính mới
    SET @ma_may_tinh = 'mt' + RIGHT('00' + CAST(@new_id AS VARCHAR), 2);

    RETURN @ma_may_tinh;
END;
GO


---tạo mã khuyến mãi
IF OBJECT_ID('dbo.TaoMaKhuyenMai', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TaoMaKhuyenMai;
GO
CREATE FUNCTION dbo.TaoMaKhuyenMai()
RETURNS VARCHAR(50)
AS
BEGIN
    DECLARE @ma_khuyen_mai VARCHAR(50);
    DECLARE @new_id INT;

    -- Lấy giá trị cao nhất hiện có của mã khuyến mãi
    SELECT @new_id = COALESCE(MAX(
                                    CASE 
                                        WHEN ma_khuyen_mai LIKE 'km%' AND LEN(ma_khuyen_mai) > 2 
                                        THEN TRY_CAST(RIGHT(ma_khuyen_mai, LEN(ma_khuyen_mai) - 2) AS INT)
                                        ELSE NULL 
                                    END), 0) + 1
    FROM KhuyenMai;

    -- Tạo mã khuyến mãi mới
    SET @ma_khuyen_mai = 'km' + RIGHT('0' + CAST(@new_id AS VARCHAR), 2); -- Chỉ cần 2 chữ số sau KM

    RETURN @ma_khuyen_mai;
END;
GO


---tạo mã đơn hàng
IF OBJECT_ID('dbo.TaoMaDonHang', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TaoMaDonHang;
GO
CREATE FUNCTION dbo.TaoMaDonHang()
RETURNS VARCHAR(50)
AS
BEGIN
    DECLARE @ma_don_hang VARCHAR(50);
    DECLARE @new_id INT;

    -- Lấy giá trị cao nhất hiện có của mã đơn hàng
    SELECT @new_id = COALESCE(MAX(
                                    CASE 
                                        WHEN ma_don_hang LIKE 'dh%' AND LEN(ma_don_hang) > 2 
                                        THEN TRY_CAST(RIGHT(ma_don_hang, LEN(ma_don_hang) - 2) AS INT)
                                        ELSE NULL 
                                    END), 0) + 1
    FROM DonHang;

    -- Tạo mã đơn hàng mới với định dạng dh0001, dh0002,...
    SET @ma_don_hang = 'dh' + RIGHT('0000' + CAST(@new_id AS VARCHAR), 4); -- Định dạng dh0001, dh0002,...

    RETURN @ma_don_hang;
END;
GO

---Tạo mã đánh giá
IF OBJECT_ID('dbo.TaoMaDanhGia', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TaoMaDanhGia;
GO
CREATE FUNCTION dbo.TaoMaDanhGia()
RETURNS VARCHAR(50)
AS
BEGIN
    DECLARE @ma_danh_gia VARCHAR(50);
    DECLARE @new_id INT;

    -- Lấy giá trị cao nhất hiện có của mã đánh giá
    SELECT @new_id = COALESCE(MAX(
                                    CASE 
                                        WHEN ma_danh_gia LIKE 'dg%' AND LEN(ma_danh_gia) > 2 
                                        THEN TRY_CAST(RIGHT(ma_danh_gia, LEN(ma_danh_gia) - 2) AS INT)
                                        ELSE NULL 
                                    END), 0) + 1
    FROM DanhGia;

    -- Tạo mã đánh giá mới với định dạng dg0001, dg0002,...
    SET @ma_danh_gia = 'dg' + RIGHT('0000' + CAST(@new_id AS VARCHAR), 4); -- Định dạng dg0001, dg0002,...

    RETURN @ma_danh_gia;
END;
GO

---Tìm kiếm sản phẩm bằng từ khóa
IF OBJECT_ID('dbo.TimKiemSanPham', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TimKiemSanPham;
GO
CREATE FUNCTION dbo.TimKiemSanPham (
    @tu_khoa NVARCHAR(255)
)
RETURNS TABLE
AS
RETURN
(
    SELECT ma_may_tinh, ten_may_tinh, mo_ta, gia_tien, ton_kho, cpu, ram, o_cung, card_roi, man_hinh, bao_hanh
    FROM MayTinh
    WHERE 
        ten_may_tinh LIKE '%' + @tu_khoa + '%' OR
        mo_ta LIKE '%' + @tu_khoa + '%' OR
        cpu LIKE '%' + @tu_khoa + '%' OR
        ram LIKE '%' + @tu_khoa + '%' OR
        o_cung LIKE '%' + @tu_khoa + '%' OR
        card_roi LIKE '%' + @tu_khoa + '%' OR
        man_hinh LIKE '%' + @tu_khoa + '%'
);
GO

---Tìm sản phẩm theo giá
IF OBJECT_ID('dbo.TimKiemSanPhamTheoGia', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TimKiemSanPhamTheoGia;
GO
CREATE FUNCTION dbo.TimKiemSanPhamTheoGia (
    @GiaMin INT,
    @GiaMax INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM MayTinh
    WHERE gia_tien BETWEEN @GiaMin AND @GiaMax
);
GO

--- Lấy ra các khuyến mãi của sản phẩm đang chọn mà khách hàng đang có
IF OBJECT_ID('dbo.LayKhuyenMaiCuaKhachHangVaSanPham', 'FN') IS NOT NULL
    DROP FUNCTION dbo.LayKhuyenMaiCuaKhachHangVaSanPham;
GO
CREATE FUNCTION dbo.LayKhuyenMaiCuaKhachHangVaSanPham
(
    @ma_khach_hang VARCHAR(50),
    @ma_may_tinh VARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        km.ma_khuyen_mai,
        km.ten_khuyen_mai,
        km.mo_ta,
        km.phan_tram_giam,
        km.so_tien_giam,
        km.ngay_bat_dau,
        km.ngay_ket_thuc,
        kmkh.trang_thai
    FROM 
        KhuyenMai km
    JOIN 
        SanPham_KhuyenMai spkm ON km.ma_khuyen_mai = spkm.ma_khuyen_mai
    JOIN 
        KhuyenMai_KhachHang kmkh ON km.ma_khuyen_mai = kmkh.ma_khuyen_mai
    WHERE 
        kmkh.ma_khach_hang = @ma_khach_hang
        AND spkm.ma_may_tinh = @ma_may_tinh
        AND kmkh.trang_thai = 1 -- Chỉ lấy khuyến mãi chưa được sử dụng
);
GO

---Hàm áp dụng khuyến mãi
IF OBJECT_ID('dbo.ApDungKhuyenMai', 'FN') IS NOT NULL
    DROP FUNCTION dbo.ApDungKhuyenMai;
GO

CREATE FUNCTION dbo.ApDungKhuyenMai
(
    @ma_may_tinh VARCHAR(50),
    @ma_khuyen_mai VARCHAR(50)
)
RETURNS INT
AS
BEGIN
    DECLARE @gia_tien INT;
    DECLARE @so_tien_giam INT;
    DECLARE @phan_tram_giam FLOAT;
    DECLARE @tong_tien INT;

    -- Lấy giá tiền của sản phẩm
    SELECT @gia_tien = gia_tien
    FROM MayTinh
    WHERE ma_may_tinh = @ma_may_tinh;

    -- Lấy thông tin khuyến mãi
    SELECT @so_tien_giam = so_tien_giam, @phan_tram_giam = phan_tram_giam
    FROM KhuyenMai
    WHERE ma_khuyen_mai = @ma_khuyen_mai;

    -- Tính toán số tiền sau khi áp dụng khuyến mãi
    SET @tong_tien = @gia_tien;

    -- Áp dụng khuyến mãi theo phần trăm
    IF @phan_tram_giam IS NOT NULL
    BEGIN
        SET @tong_tien = @tong_tien - (@tong_tien * @phan_tram_giam / 100);
    END

    -- Áp dụng khuyến mãi theo số tiền
    IF @so_tien_giam IS NOT NULL
    BEGIN
        SET @tong_tien = @tong_tien - @so_tien_giam;
    END

    -- Đảm bảo số tiền không âm
    IF @tong_tien < 0
    BEGIN
        SET @tong_tien = 0;
    END

    RETURN @tong_tien;
END;
GO

---Kiem tra du lieu khi them san pham
IF OBJECT_ID('dbo.CheckSanPhamTruocKhiThem', 'FN') IS NOT NULL
    DROP FUNCTION dbo.CheckSanPhamTruocKhiThem;
GO
CREATE FUNCTION CheckSanPhamTruocKhiThem (
    @ten_may_tinh NVARCHAR(255),
    @gia_tien INT,
    @ton_kho INT,
    @trong_luong FLOAT,
    @nam_san_suat INT,
    @cpu NVARCHAR(255),
    @ram NVARCHAR(255),
    @o_cung NVARCHAR(255),
    @man_hinh NVARCHAR(255),
    @bao_hanh NVARCHAR(255),
	@hinh_anh VARBINARY(MAX)
)
RETURNS NVARCHAR(255) -- Trả về thông báo lỗi
AS
BEGIN
    DECLARE @errorMessage NVARCHAR(255) = 'Hợp lệ';
    
    -- Kiểm tra các trường không được phép null
    IF @ten_may_tinh IS NULL OR @cpu IS NULL OR 
       @ram IS NULL OR @o_cung IS NULL OR @man_hinh IS NULL OR @bao_hanh IS NULL OR @hinh_anh IS NULL
    BEGIN
        SET @errorMessage = 'Các trường không được phép để trống.';
        RETURN @errorMessage;
    END

    -- Kiểm tra giá tiền
    IF @gia_tien <= 0
    BEGIN
        SET @errorMessage = 'Giá tiền phải lớn hơn 0.';
        RETURN @errorMessage;
    END

    -- Kiểm tra tồn kho
    IF @ton_kho < 0
    BEGIN
        SET @errorMessage = 'Tồn kho không thể nhỏ hơn 0.';
        RETURN @errorMessage;
    END

    -- Kiểm tra trọng lượng
    IF @trong_luong <= 0
    BEGIN
        SET @errorMessage = 'Trọng lượng phải lớn hơn 0.';
        RETURN @errorMessage;
    END

    -- Kiểm tra năm sản xuất
    IF @nam_san_suat < 1900 OR @nam_san_suat > YEAR(GETDATE())
    BEGIN
        SET @errorMessage = 'Năm sản xuất không hợp lệ.';
        RETURN @errorMessage;
    END

    RETURN @errorMessage; -- Trả về thông báo hợp lệ
END;
GO

--- Kiểm tra khuyến mãi trước khi thêm
IF OBJECT_ID('dbo.CheckKhuyenMaiTruocKhiThem', 'FN') IS NOT NULL
    DROP FUNCTION dbo.CheckKhuyenMaiTruocKhiThem;
GO
CREATE FUNCTION CheckKhuyenMaiTruocKhiThem (
    @ten_khuyen_mai NVARCHAR(255),
    @phan_tram_giam FLOAT,
    @so_tien_giam INT,
    @ngay_bat_dau DATE,
    @ngay_ket_thuc DATE
)
RETURNS NVARCHAR(255) -- Trả về thông báo lỗi
AS
BEGIN
    DECLARE @errorMessage NVARCHAR(255) = 'Hợp lệ';

    -- Kiểm tra tên khuyến mãi
    IF @ten_khuyen_mai IS NULL OR @ten_khuyen_mai = ''
    BEGIN
        SET @errorMessage = 'Tên khuyến mãi không được để trống.';
        RETURN @errorMessage;
    END

    -- Kiểm tra phần trăm giảm giá và số tiền giảm
    IF @phan_tram_giam < 0 OR (@so_tien_giam IS NOT NULL AND @so_tien_giam < 0)
    BEGIN
        SET @errorMessage = 'Phần trăm giảm và số tiền giảm không được âm.';
        RETURN @errorMessage;
    END

    -- Kiểm tra ngày bắt đầu và ngày kết thúc
    IF @ngay_bat_dau IS NULL OR @ngay_ket_thuc IS NULL
    BEGIN
        SET @errorMessage = 'Ngày bắt đầu và ngày kết thúc không được để trống.';
        RETURN @errorMessage;
    END

    IF @ngay_bat_dau >= @ngay_ket_thuc
    BEGIN
        SET @errorMessage = 'Ngày bắt đầu phải trước ngày kết thúc.';
        RETURN @errorMessage;
    END

    RETURN @errorMessage; -- Trả về thông báo hợp lệ
END;
GO