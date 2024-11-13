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
                                        WHEN ma_may_tinh LIKE 'MT%' AND LEN(ma_may_tinh) > 2 
                                        THEN TRY_CAST(RIGHT(ma_may_tinh, LEN(ma_may_tinh) - 2) AS INT)
                                        ELSE NULL 
                                    END), 0) + 1
    FROM MayTinh;

    -- Tạo mã máy tính mới
    SET @ma_may_tinh = 'MT' + RIGHT('00' + CAST(@new_id AS VARCHAR), 2);

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
                                        WHEN ma_khuyen_mai LIKE 'KM%' AND LEN(ma_khuyen_mai) > 2 
                                        THEN TRY_CAST(RIGHT(ma_khuyen_mai, LEN(ma_khuyen_mai) - 2) AS INT)
                                        ELSE NULL 
                                    END), 0) + 1
    FROM KhuyenMai;

    -- Tạo mã khuyến mãi mới
    SET @ma_khuyen_mai = 'KM' + RIGHT('0' + CAST(@new_id AS VARCHAR), 2); -- Chỉ cần 2 chữ số sau KM

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


--- Kiểm tra email tồn tại chưa khi đăng kí.
IF OBJECT_ID('dbo.KiemTraEmail', 'FN') IS NOT NULL
    DROP FUNCTION dbo.KiemTraEmail;
GO
CREATE FUNCTION dbo.KiemTraEmail (@Email NVARCHAR(255))
RETURNS BIT
AS
BEGIN
    DECLARE @Exists BIT;

    IF EXISTS (SELECT 1 FROM KhachHang WHERE Email = @Email)
        SET @Exists = 1; -- Email đã tồn tại
    ELSE
        SET @Exists = 0; -- Email chưa tồn tại

    RETURN @Exists;
END
GO



--- Kiểm tra tồn kho của sản phẩm
IF OBJECT_ID('dbo.KiemTraTonKho', 'FN') IS NOT NULL
    DROP FUNCTION dbo.KiemTraTonKho;
GO
CREATE FUNCTION dbo.KiemTraTonKho (@ma_may_tinh varchar(50))
RETURNS INT
AS
BEGIN
    DECLARE @ton_kho INT;
	DECLARE @trang_thai INT;

    -- Lấy số lượng tồn kho của sản phẩm
    SELECT @ton_kho = ton_kho FROM MayTinh WHERE ma_may_tinh = @ma_may_tinh;

    -- Kiểm tra nếu số lượng tồn kho ít hơn số lượng yêu cầu
	IF @ton_kho > 0
    BEGIN
       SET @trang_thai = 1;
    END
    ELSE
    BEGIN
        SET @trang_thai = 0;
    END
	RETURN @trang_thai;
END


---Tính sao sao trung bình 
IF OBJECT_ID('dbo.TinhSoSaoTrungBinh', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TinhSoSaoTrungBinh;

GO
CREATE FUNCTION dbo.TinhSoSaoTrungBinh (@ma_may_tinh VARCHAR(50))
RETURNS FLOAT
AS
BEGIN
    DECLARE @so_sao_trung_binh FLOAT;

    -- Tính số sao trung bình
    SELECT @so_sao_trung_binh = COALESCE(AVG(so_sao_danh_gia), 0)
    FROM DanhGia
    WHERE ma_may_tinh = @ma_may_tinh;
    RETURN @so_sao_trung_binh;
END;
GO

--- Tìm kiếm khuyến mãi

IF OBJECT_ID('dbo.TimKhuyenMai', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TimKhuyenMai;
GO
CREATE FUNCTION dbo.TimKhuyenMai (
    @tu_khoa NVARCHAR(255) = NULL -- Từ khóa có thể NULL
)
RETURNS @result TABLE (
    ma_khuyen_mai VARCHAR(50),
    ten_khuyen_mai NVARCHAR(255),
    mo_ta NVARCHAR(255),
    phan_tram_giam INT,
    so_tien_giam INT,
    ngay_bat_dau DATE,
    ngay_ket_thuc DATE
)
AS
BEGIN
    -- Tìm kiếm khuyến mãi theo từ khóa
    INSERT INTO @result
    SELECT ma_khuyen_mai, ten_khuyen_mai, mo_ta, phan_tram_giam, so_tien_giam, ngay_bat_dau, ngay_ket_thuc
    FROM View_DanhSachKhuyenMai
    WHERE 
        (@tu_khoa IS NULL OR 
        ma_khuyen_mai LIKE '%' + @tu_khoa + '%' OR
        ten_khuyen_mai LIKE '%' + @tu_khoa + '%' OR
        mo_ta LIKE '%' + @tu_khoa + '%' OR
        CONVERT(VARCHAR, phan_tram_giam) LIKE '%' + @tu_khoa + '%' OR
        CONVERT(VARCHAR, so_tien_giam) LIKE '%' + @tu_khoa + '%' OR
        CONVERT(VARCHAR, ngay_bat_dau, 105) LIKE '%' + @tu_khoa + '%' OR
        CONVERT(VARCHAR, ngay_ket_thuc, 105) LIKE '%' + @tu_khoa + '%');

    RETURN;
END;
GO

IF OBJECT_ID('dbo.TimDonHangChoChu', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TimDonHangChoChu;
GO
CREATE FUNCTION dbo.TimDonHangChoChu(
    @tu_khoa NVARCHAR(255) = NULL
)
RETURNS @result TABLE (
    ma_don_hang VARCHAR(50),
    ma_khach_hang VARCHAR(50),
    ten_khach_hang NVARCHAR(255),
    ngay_dat_hang DATE,
    tong_tien INT,
    trang_thai INT
)
AS
BEGIN
    -- Tìm kiếm đơn hàng qua VIEW
    INSERT INTO @result
    SELECT 
        ma_don_hang,
        ma_khach_hang,
        ten_khach_hang,
        ngay_dat_hang,
        tong_tien,
        trang_thai
    FROM 
        View_DanhSachDonHang
    WHERE 
        -- Điều kiện tìm kiếm thông thường với các trường khác
        (@tu_khoa IS NULL OR 
        ma_don_hang LIKE '%' + @tu_khoa + '%' OR 
        ma_khach_hang LIKE '%' + @tu_khoa + '%' OR 
        ten_khach_hang LIKE '%' + @tu_khoa + '%' OR 
        CAST(ngay_dat_hang AS NVARCHAR) LIKE '%' + @tu_khoa + '%' OR 
        CAST(tong_tien AS NVARCHAR) LIKE '%' + @tu_khoa + '%' OR 
        CAST(trang_thai AS NVARCHAR) LIKE '%' + @tu_khoa + '%')
        
        -- Điều kiện kiểm tra trạng thái dựa trên từ khóa
        OR (@tu_khoa = N'Đã hoàn thành' AND trang_thai = 1)
        OR (@tu_khoa = N'Chưa hoàn thành' AND trang_thai = 2)
        OR (@tu_khoa = N'Đã hủy' AND trang_thai = 3)
    RETURN;
END;
GO


--TÌM TÀI KHOẢN KHÁCH HÀNG(CHO CHỦ TÌM)
IF OBJECT_ID('dbo.TimTaiKhoanKhachHang', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TimTaiKhoanKhachHang;
GO
CREATE FUNCTION dbo.TimTaiKhoanKhachHang (@tu_khoa NVARCHAR(255))
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM View_ThongTinKhachHang
    WHERE 
        tai_khoan LIKE '%' + @tu_khoa + '%' OR
        mat_khau LIKE '%' + @tu_khoa + '%' OR
        ma_khach_hang LIKE '%' + @tu_khoa + '%' OR
        ten_khach_hang LIKE '%' + @tu_khoa + '%' OR
        email LIKE '%' + @tu_khoa + '%' OR
        dia_chi LIKE '%' + @tu_khoa + '%' OR
        so_dien_thoai LIKE '%' + @tu_khoa + '%'
);
GO

--TÌM SẢN PHẨM(CHO CHỦ TÌM)
IF OBJECT_ID('dbo.TimKiemSanPhamChoChu', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TimKiemSanPhamChoChu;
GO
CREATE FUNCTION dbo.TimKiemSanPhamChoChu(
    @tu_khoa NVARCHAR(255) = NULL -- Từ khóa có thể NULL
)
RETURNS @result TABLE (
    ma_may_tinh VARCHAR(50),
    ten_may_tinh NVARCHAR(255),
    mo_ta NVARCHAR(255),
    gia_tien INT,
    ton_kho INT,
    cpu NVARCHAR(255),
    ram NVARCHAR(255),
    o_cung NVARCHAR(255),
    card_roi NVARCHAR(255),
    man_hinh NVARCHAR(255),
    trong_luong FLOAT,
    nam_san_suat INT,
    bao_hanh NVARCHAR(255),
	hinh_anh VARBINARY(MAX)
)
AS
BEGIN
    -- Tìm kiếm sản phẩm theo từ khóa
    INSERT INTO @result
    SELECT 
        ma_may_tinh, 
        ten_may_tinh, 
        mo_ta, 
        gia_tien, 
        ton_kho, 
        cpu, 
        ram, 
        o_cung, 
        card_roi, 
        man_hinh, 
        trong_luong, 
        nam_san_suat, 
        bao_hanh,
		hinh_anh
    FROM View_MayTinh
    WHERE 
        -- So sánh từ khóa với tất cả các cột (dùng CAST cho các cột số)
        (@tu_khoa IS NULL OR 
        ma_may_tinh LIKE '%' + @tu_khoa + '%' OR
        ten_may_tinh LIKE '%' + @tu_khoa + '%' OR
        mo_ta LIKE '%' + @tu_khoa + '%' OR
        cpu LIKE '%' + @tu_khoa + '%' OR
        ram LIKE '%' + @tu_khoa + '%' OR
        o_cung LIKE '%' + @tu_khoa + '%' OR
        card_roi LIKE '%' + @tu_khoa + '%' OR
        man_hinh LIKE '%' + @tu_khoa + '%' OR
        CAST(gia_tien AS NVARCHAR) LIKE '%' + @tu_khoa + '%' OR
        CAST(ton_kho AS NVARCHAR) LIKE '%' + @tu_khoa + '%' OR
        CAST(trong_luong AS NVARCHAR) LIKE '%' + @tu_khoa + '%' OR
        CAST(nam_san_suat AS NVARCHAR) LIKE '%' + @tu_khoa + '%' OR
        bao_hanh LIKE '%' + @tu_khoa + '%')
    RETURN;
END;
GO


--12. HÀM LẤY CHI TIẾT ĐƠN HÀNG
IF OBJECT_ID('dbo.LayChiTietDonHang', 'FN') IS NOT NULL
    DROP FUNCTION dbo.LayChiTietDonHang;
GO
CREATE FUNCTION dbo.LayChiTietDonHang(
    @ma_don_hang VARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        dht.ma_may_tinh, 
        mt.ten_may_tinh, 
        dht.gia_ban, 
        dht.so_luong 
    FROM DonHangChiTiet dht
    INNER JOIN MayTinh mt ON dht.ma_may_tinh = mt.ma_may_tinh
    WHERE dht.ma_don_hang = @ma_don_hang
);
GO


--TÌM ĐƠN HÀNG THEO MÃ ĐƠN HÀNG (cho khách hàng TÌM)
IF OBJECT_ID('dbo.TimDonHang', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TimDonHang;
GO
CREATE FUNCTION dbo.TimDonHang 
    (@ma_don_hang VARCHAR(50), @ma_khach_hang VARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT ma_don_hang, ngay_dat_hang, trang_thai
    FROM DonHang 
    WHERE ma_khach_hang = @ma_khach_hang 
      AND ma_don_hang LIKE '%' + @ma_don_hang + '%'
);
GO


--TÌM SẢN PHẨM TRONG GIỎ HÀNG
IF OBJECT_ID('dbo.TimSanPhamTrongGioHang', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TimSanPhamTrongGioHang;
GO
CREATE FUNCTION dbo.TimSanPhamTrongGioHang 
    (@tu_khoa NVARCHAR(255),
     @ma_khach_hang VARCHAR(50)
    )
RETURNS TABLE
AS
RETURN
(
    SELECT 
        @ma_khach_hang AS ma_khach_hang,
        GioHang.ma_may_tinh, 
        MayTinh.ten_may_tinh, 
        MayTinh.gia_tien, 
        GioHang.so_luong
    FROM 
        GioHang 
    INNER JOIN 
        MayTinh ON GioHang.ma_may_tinh = MayTinh.ma_may_tinh
    WHERE 
        GioHang.ma_khach_hang = @ma_khach_hang
        AND (
            MayTinh.ten_may_tinh LIKE '%' + @tu_khoa + '%' OR
            MayTinh.gia_tien LIKE '%' + @tu_khoa + '%' OR
            GioHang.so_luong LIKE '%' + @tu_khoa + '%' OR
            GioHang.ma_may_tinh LIKE '%' + @tu_khoa + '%' 
        )
);
GO

--9. HÀM LẤY THÔNG TIN CHI TIẾT SẢN PHẨM
IF OBJECT_ID('dbo.LayThongTinChiTietSanPham', 'FN') IS NOT NULL
    DROP FUNCTION dbo.LayThongTinChiTietSanPham;
GO
CREATE FUNCTION dbo.LayThongTinChiTietSanPham(@ma_may_tinh VARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM View_MayTinh 
    WHERE ma_may_tinh = @ma_may_tinh
);
GO


--TÌM SẢN PHẨM(CHO KHÁCH TÌM KẾT HỢP GIÁ TIỀN)
IF OBJECT_ID('dbo.TimKiemSanPham', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TimKiemSanPham;
GO
CREATE FUNCTION dbo.TimKiemSanPham(
    @tu_khoa NVARCHAR(255) = NULL, -- Từ khóa có thể NULL
    @gia_min INT = NULL,           -- Giá tối thiểu có thể NULL
    @gia_max INT = NULL            -- Giá tối đa có thể NULL
)
RETURNS @result TABLE (
    ma_may_tinh VARCHAR(50),
    ten_may_tinh NVARCHAR(255),
    mo_ta NVARCHAR(255),
    gia_tien INT,
    ton_kho INT,
    cpu NVARCHAR(255),
    ram NVARCHAR(255),
    o_cung NVARCHAR(255),
    card_roi NVARCHAR(255),
    man_hinh NVARCHAR(255),
    trong_luong FLOAT,
    nam_san_suat INT,
    bao_hanh NVARCHAR(255),
    hinh_anh VARBINARY(MAX)
)
AS
BEGIN
    -- Tìm kiếm sản phẩm theo từ khóa và giá
    INSERT INTO @result
    SELECT ma_may_tinh, ten_may_tinh, mo_ta, gia_tien, ton_kho, cpu, ram, o_cung, card_roi, man_hinh, trong_luong, nam_san_suat, bao_hanh, hinh_anh
    FROM View_MayTinh
    WHERE 
        -- Tìm kiếm theo từ khóa nếu không NULL
        (@tu_khoa IS NULL OR 
        ten_may_tinh LIKE '%' + @tu_khoa + '%' OR
        mo_ta LIKE '%' + @tu_khoa + '%' OR
        cpu LIKE '%' + @tu_khoa + '%' OR
        ram LIKE '%' + @tu_khoa + '%' OR
        o_cung LIKE '%' + @tu_khoa + '%' OR
        card_roi LIKE '%' + @tu_khoa + '%' OR
        man_hinh LIKE '%' + @tu_khoa + '%' OR
        CAST(gia_tien AS NVARCHAR) LIKE '%' + @tu_khoa + '%' OR
        CAST(ton_kho AS NVARCHAR) LIKE '%' + @tu_khoa + '%' OR
        CAST(trong_luong AS NVARCHAR) LIKE '%' + @tu_khoa + '%' OR
        CAST(nam_san_suat AS NVARCHAR) LIKE '%' + @tu_khoa + '%' OR
        bao_hanh LIKE '%' + @tu_khoa + '%')
        AND 
        -- Tìm kiếm theo giá nếu có giá min/max
        (@gia_min IS NULL OR gia_tien >= @gia_min)
        AND
        (@gia_max IS NULL OR gia_tien <= @gia_max);

    RETURN;
END;
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
		spkm.ma_may_tinh,
        km.phan_tram_giam,
        km.ngay_ket_thuc
    FROM 
        KhuyenMai km
    JOIN 
        SanPham_KhuyenMai spkm ON km.ma_khuyen_mai = spkm.ma_khuyen_mai
    JOIN 
        KhuyenMai_KhachHang kmkh ON km.ma_khuyen_mai = kmkh.ma_khuyen_mai
    WHERE 
        kmkh.ma_khach_hang = @ma_khach_hang
        AND spkm.ma_may_tinh = @ma_may_tinh
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
    
    -- Kiểm tra các trường không được phép null hoặc rỗng
    IF @ten_may_tinh IS NULL OR LEN(@ten_may_tinh) = 0 OR 
       @cpu IS NULL OR LEN(@cpu) = 0 OR 
       @ram IS NULL OR LEN(@ram) = 0 OR 
       @o_cung IS NULL OR LEN(@o_cung) = 0 OR 
       @man_hinh IS NULL OR LEN(@man_hinh) = 0 OR 
       @bao_hanh IS NULL OR LEN(@bao_hanh) = 0 OR 
       @hinh_anh IS NULL
    BEGIN
        SET @errorMessage = N'Các trường không được phép để trống.';
        RETURN @errorMessage;
    END

    -- Kiểm tra giá tiền
    IF @gia_tien <= 0
    BEGIN
        SET @errorMessage = N'Giá tiền phải lớn hơn 0.';
        RETURN @errorMessage;
    END

    -- Kiểm tra tồn kho
    IF @ton_kho <= 0
    BEGIN
        SET @errorMessage = N'Tồn kho không thể nhỏ hơn hay bằng 0.';
        RETURN @errorMessage;
    END

    -- Kiểm tra trọng lượng
    IF @trong_luong <= 0
    BEGIN
        SET @errorMessage = N'Trọng lượng phải lớn hơn 0.';
        RETURN @errorMessage;
    END

    -- Kiểm tra năm sản xuất
    IF @nam_san_suat < 1900 OR @nam_san_suat > YEAR(GETDATE())
    BEGIN
        SET @errorMessage = N'Năm sản xuất không hợp lệ.';
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
        SET @errorMessage = N'Tên khuyến mãi không được để trống.';
        RETURN @errorMessage;
    END

    -- Kiểm tra phần trăm giảm giá và số tiền giảm
    IF @phan_tram_giam < 0 OR (@so_tien_giam IS NOT NULL AND @so_tien_giam < 0)
    BEGIN
        SET @errorMessage = N'Phần trăm giảm và số tiền giảm không được âm.';
        RETURN @errorMessage;
    END

    -- Kiểm tra ngày bắt đầu và ngày kết thúc
    IF @ngay_bat_dau IS NULL OR @ngay_ket_thuc IS NULL
    BEGIN
        SET @errorMessage = N'Ngày bắt đầu và ngày kết thúc không được để trống.';
        RETURN @errorMessage;
    END

    IF @ngay_bat_dau >= @ngay_ket_thuc
    BEGIN
        SET @errorMessage = N'Ngày bắt đầu phải trước ngày kết thúc.';
        RETURN @errorMessage;
    END

    RETURN @errorMessage; -- Trả về thông báo hợp lệ
END;
GO

