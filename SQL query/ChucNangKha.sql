---Tính tổng doanh thu
IF OBJECT_ID('dbo.DoanhThuTheoNgay', 'FN') IS NOT NULL
    DROP FUNCTION dbo.DoanhThuTheoNgay;
GO
CREATE FUNCTION dbo.DoanhThuTheoNgay(@ngay DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT
        M.ten_may_tinh,
        SUM(DCT.so_luong) AS so_luong,
        DCT.gia_ban,
        SUM(DCT.so_luong * DCT.gia_ban) AS tong_tien
    FROM
        DonHang DH
    JOIN
        DonHangChiTiet DCT ON DH.ma_don_hang = DCT.ma_don_hang
    JOIN
        MayTinh M ON DCT.ma_may_tinh = M.ma_may_tinh
    WHERE
        DH.ngay_dat_hang = @ngay
    GROUP BY
        M.ten_may_tinh, DCT.gia_ban
);
GO

---Tính tổng doanh thu theo ngày
IF OBJECT_ID('dbo.TinhTongGiaBanTheoNgay', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TinhTongGiaBanTheoNgay;
GO
CREATE FUNCTION dbo.TinhTongGiaBanTheoNgay(@ngay DATE)
RETURNS INT
AS
BEGIN
    DECLARE @tong_gia_ban INT;

    SELECT @tong_gia_ban = SUM(DCT.gia_ban * DCT.so_luong)
    FROM DonHang DH
    JOIN DonHangChiTiet DCT ON DH.ma_don_hang = DCT.ma_don_hang
    WHERE DH.ngay_dat_hang = @ngay;

    RETURN @tong_gia_ban;
END;
GO

---Lấy ra doanh thu theo tháng
IF OBJECT_ID('dbo.DoanhThuTheoThang', 'FN') IS NOT NULL
    DROP FUNCTION dbo.DoanhThuTheoThang;
GO
CREATE FUNCTION dbo.DoanhThuTheoThang(@thang INT, @nam INT)
RETURNS TABLE
AS
RETURN
(
    SELECT
        M.ten_may_tinh,
        SUM(DCT.so_luong) AS so_luong,
        DCT.gia_ban,
        SUM(DCT.so_luong * DCT.gia_ban) AS tong_tien
    FROM
        DonHang DH
    JOIN
        DonHangChiTiet DCT ON DH.ma_don_hang = DCT.ma_don_hang
    JOIN
        MayTinh M ON DCT.ma_may_tinh = M.ma_may_tinh
    WHERE
        MONTH(DH.ngay_dat_hang) = @thang AND YEAR(DH.ngay_dat_hang) = @nam
    GROUP BY
        M.ten_may_tinh, DCT.gia_ban
);
GO 

--Tính tổng giá bán theo tháng
IF OBJECT_ID('dbo.TinhTongGiaBanTheoThang', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TinhTongGiaBanTheoThang;
GO
CREATE FUNCTION dbo.TinhTongGiaBanTheoThang(@thang INT, @nam INT)
RETURNS INT
AS
BEGIN
    DECLARE @tong_gia_ban INT;

    SELECT @tong_gia_ban = SUM(DCT.gia_ban * DCT.so_luong)
    FROM DonHang DH
    JOIN DonHangChiTiet DCT ON DH.ma_don_hang = DCT.ma_don_hang
    WHERE MONTH(DH.ngay_dat_hang) = @thang AND YEAR(DH.ngay_dat_hang) = @nam;

    RETURN @tong_gia_ban;
END;
GO

--Lấy ra doanh thu theo năm
IF OBJECT_ID('dbo.DoanhThuTheoNam', 'FN') IS NOT NULL
    DROP FUNCTION dbo.DoanhThuTheoNam;
GO
CREATE FUNCTION dbo.DoanhThuTheoNam(@nam INT)
RETURNS TABLE
AS
RETURN
(
    SELECT
        M.ten_may_tinh,
        SUM(DCT.so_luong) AS so_luong,
        DCT.gia_ban,
        SUM(DCT.so_luong * DCT.gia_ban) AS tong_tien
    FROM
        DonHang DH
    JOIN
        DonHangChiTiet DCT ON DH.ma_don_hang = DCT.ma_don_hang
    JOIN
        MayTinh M ON DCT.ma_may_tinh = M.ma_may_tinh
    WHERE
        YEAR(DH.ngay_dat_hang) = @nam
    GROUP BY
        M.ten_may_tinh, DCT.gia_ban
);
GO

--Tính tổng giá bán theo năm
IF OBJECT_ID('dbo.TinhTongGiaBanTheoNam', 'FN') IS NOT NULL
	DROP FUNCTION dbo.TinhTongGiaBanTheoNam;
GO
CREATE FUNCTION dbo.TinhTongGiaBanTheoNam(@nam INT)
RETURNS INT
AS
BEGIN
    DECLARE @tong_gia_ban INT;

    SELECT @tong_gia_ban = SUM(DCT.gia_ban * DCT.so_luong)
    FROM DonHang DH
    JOIN DonHangChiTiet DCT ON DH.ma_don_hang = DCT.ma_don_hang
    WHERE YEAR(DH.ngay_dat_hang) = @nam;

    RETURN @tong_gia_ban;
END;