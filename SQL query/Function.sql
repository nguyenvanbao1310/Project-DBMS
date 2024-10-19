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