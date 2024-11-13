--- Function so sánh CPU
IF OBJECT_ID('dbo.SoSanhCPU', 'FN') IS NOT NULL
    DROP FUNCTION dbo.SoSanhCPU;
GO
CREATE FUNCTION dbo.SoSanhCPU (@cpu1 NVARCHAR(255), @cpu2 NVARCHAR(255))
RETURNS NVARCHAR(255)
AS
BEGIN
    DECLARE @result NVARCHAR(255); 

    IF @cpu1 = @cpu2
        SET @result = N'='
    ELSE IF @cpu1 > @cpu2
        SET @result = N'↑'
    ELSE
        SET @result = N'↓'

    RETURN @result;
END;
GO


--- Function so sánh Ổ cứng
IF OBJECT_ID('dbo.SoSanhO_cung', 'FN') IS NOT NULL
    DROP FUNCTION dbo.SoSanhO_cung;
GO
CREATE FUNCTION dbo.SoSanhO_cung (@o_cung1 NVARCHAR(255), @o_cung2 NVARCHAR(255))
RETURNS NVARCHAR(255)
AS
BEGIN
    DECLARE @result NVARCHAR(255);
    DECLARE @o_cung11 FLOAT, @o_cung22 FLOAT;
    
    -- Lấy số lượng GB từ chuỗi
    SET @o_cung11 = CASE 
                        WHEN @o_cung1 LIKE '%GB%' THEN CAST(SUBSTRING(@o_cung1, 1, PATINDEX('%[A-Za-z]%', @o_cung1) - 1) AS FLOAT)
                        WHEN @o_cung1 LIKE '%TB%' THEN CAST(SUBSTRING(@o_cung1, 1, PATINDEX('%[A-Za-z]%', @o_cung1) - 1) AS FLOAT) * 1024
                        ELSE 0
                    END;
    
    SET @o_cung22 = CASE 
                        WHEN @o_cung2 LIKE '%GB%' THEN CAST(SUBSTRING(@o_cung2, 1, PATINDEX('%[A-Za-z]%', @o_cung2) - 1) AS FLOAT)
                        WHEN @o_cung2 LIKE '%TB%' THEN CAST(SUBSTRING(@o_cung2, 1, PATINDEX('%[A-Za-z]%', @o_cung2) - 1) AS FLOAT) * 1024
                        ELSE 0
                    END;

    -- So sánh sau khi chuyển đổi thành GB
    IF @o_cung11 > @o_cung22
        SET @result = N'↑'
    ELSE IF @o_cung11 < @o_cung22
        SET @result = N'↓'
    ELSE
        SET @result = N'='

    RETURN @result;
END;
GO

--- Function so sánh ram
IF OBJECT_ID('dbo.SoSanhRam', 'FN') IS NOT NULL
    DROP FUNCTION dbo.SoSanhRam;
GO
CREATE FUNCTION dbo.SoSanhRam (@ram1 NVARCHAR(50), @ram2 NVARCHAR(50))
RETURNS NVARCHAR(255)
AS
BEGIN
    DECLARE @result NVARCHAR(255);
    DECLARE @ram11 INT = CAST(SUBSTRING(@ram1, 1, PATINDEX('%[^0-9]%', @ram1)-1) AS INT);
    DECLARE @ram22 INT = CAST(SUBSTRING(@ram2, 1, PATINDEX('%[^0-9]%', @ram2)-1) AS INT);
    
    IF @ram11 > @ram22
        SET @result = N'↑'
    ELSE IF @ram11 < @ram22
        SET @result = N'↓'
    ELSE
        SET @result = N'='

    RETURN @result;
END;
GO


--- Function so sánh card
IF OBJECT_ID('dbo.SoSanhCard', 'FN') IS NOT NULL
    DROP FUNCTION dbo.SoSanhCard;
GO
CREATE FUNCTION dbo.SoSanhCard (@gpu1 NVARCHAR(255), @gpu2 NVARCHAR(255))
RETURNS NVARCHAR(255)
AS
BEGIN
    DECLARE @result NVARCHAR(255);
    
    IF @gpu1 = @gpu2
        SET @result = N'='
    ELSE IF @gpu1 > @gpu2
        SET @result = N'↑'
    ELSE
        SET @result = N'↓'

    RETURN @result;
END;
GO


--- Function so sánh Trọng lượng
IF OBJECT_ID('dbo.SoSanhTrongLuong', 'FN') IS NOT NULL
    DROP FUNCTION dbo.SoSanhTrongLuong;
GO
CREATE FUNCTION dbo.SoSanhTrongLuong (@trong_luong1 FLOAT, @trong_luong2 FLOAT)
RETURNS NVARCHAR(255)
AS
BEGIN
    DECLARE @result NVARCHAR(255);

    IF @trong_luong1 < @trong_luong2
        SET @result = N'↓'
    ELSE IF @trong_luong1 > @trong_luong2
        SET @result = N'↑'
    ELSE
        SET @result = N'='

    RETURN @result;
END;
GO


--- Function so sánh giá tiền
IF OBJECT_ID('dbo.SoSanhGiaTien', 'FN') IS NOT NULL
    DROP FUNCTION dbo.SoSanhGiaTien;
GO
CREATE FUNCTION dbo.SoSanhGiaTien (@gia1 INT, @gia2 INT)
RETURNS NVARCHAR(255)
AS
BEGIN
    DECLARE @result NVARCHAR(255);

    IF @gia1 < @gia2
        SET @result = N'↓'
    ELSE IF @gia1 > @gia2
        SET @result = N'↑'
    ELSE
        SET @result = N'='

    RETURN @result;
END;
GO

--- Function so sánh màn hình
IF OBJECT_ID('dbo.SoSanhManHinh', 'FN') IS NOT NULL
    DROP FUNCTION dbo.SoSanhManHinh;
GO
CREATE FUNCTION dbo.SoSanhManHinh (@manHinh1 NVARCHAR(255), @manHinh2 NVARCHAR(255))
RETURNS NVARCHAR(255)
AS
BEGIN
    DECLARE @kichThuoc1 FLOAT, @kichThuoc2 FLOAT;
    DECLARE @doPhanGiai1 NVARCHAR(50), @doPhanGiai2 NVARCHAR(50);
    DECLARE @result NVARCHAR(255);

    SET @kichThuoc1 = CAST(SUBSTRING(@manHinh1, 1, CHARINDEX(' ', @manHinh1)-1) AS FLOAT);
    SET @kichThuoc2 = CAST(SUBSTRING(@manHinh2, 1, CHARINDEX(' ', @manHinh2)-1) AS FLOAT);


    SET @doPhanGiai1 = LTRIM(RTRIM(SUBSTRING(@manHinh1, CHARINDEX(' ', @manHinh1)+1, LEN(@manHinh1))));
    SET @doPhanGiai2 = LTRIM(RTRIM(SUBSTRING(@manHinh2, CHARINDEX(' ', @manHinh2)+1, LEN(@manHinh2))));

    IF @kichThuoc1 > @kichThuoc2
        SET @result = N'↑';
    ELSE IF @kichThuoc1 < @kichThuoc2
        SET @result = N'↓';
    ELSE
    BEGIN

        IF @doPhanGiai1 = @doPhanGiai2
            SET @result = N'=';
        ELSE IF @doPhanGiai1 = 'FHD+' AND @doPhanGiai2 = 'FHD'
            SET @result = N'↑';
        ELSE IF @doPhanGiai1 = 'FHD' AND @doPhanGiai2 = 'FHD+'
            SET @result = N'↓';
        ELSE IF @doPhanGiai1 = 'QHD' AND @doPhanGiai2 = 'FHD'
            SET @result = N'↑';
        ELSE IF @doPhanGiai1 = 'FHD' AND @doPhanGiai2 = 'QHD'
            SET @result = N'↓';
        ELSE IF @doPhanGiai1 = 'Retina' AND @doPhanGiai2 = 'FHD'
            SET @result = N'↑';
        ELSE IF @doPhanGiai1 = 'FHD' AND @doPhanGiai2 = 'Retina'
            SET @result = N'↓';
        ELSE
            SET @result = N'='; 
    END

    RETURN @result;
END;
GO





IF OBJECT_ID('dbo.SoSanh2LapTop', 'FN') IS NOT NULL
    DROP FUNCTION dbo.SoSanh2LapTop;
GO
CREATE PROCEDURE dbo.SoSanh2LapTop 
    @ma1 VARCHAR(50),
    @ma2 VARCHAR(50)

AS
BEGIN

	IF NOT EXISTS (SELECT 1 FROM View_MayTinh WHERE ma_may_tinh = @ma1)
    BEGIN
        RAISERROR('Mã máy tính %s không tồn tại.', 16, 1, @ma1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM View_MayTinh WHERE ma_may_tinh = @ma2)
    BEGIN
        RAISERROR('Mã máy tính %s không tồn tại.', 16, 1, @ma2);
        RETURN;
    END


    DECLARE @SoSanhGia NVARCHAR(255);
    DECLARE @SoSanhRam NVARCHAR(255);
    DECLARE @SoSanhGpu NVARCHAR(255);
    DECLARE @SoSanhTrongLuong NVARCHAR(255);
    DECLARE @SoSanhCpu NVARCHAR(255);
    DECLARE @SoSanhOCung NVARCHAR(255);
    DECLARE @SoSanhManHinh NVARCHAR(255);


    DECLARE @gia1 INT, @gia2 INT;
    DECLARE @ram1 NVARCHAR(255), @ram2 NVARCHAR(255);
    DECLARE @gpu1 NVARCHAR(255), @gpu2 NVARCHAR(255);
    DECLARE @trong_luong1 FLOAT, @trong_luong2 FLOAT;
    DECLARE @cpu1 NVARCHAR(255), @cpu2 NVARCHAR(255);
    DECLARE @o_cung1 NVARCHAR(255), @o_cung2 NVARCHAR(255);
    DECLARE @man_hinh1 NVARCHAR(255), @man_hinh2 NVARCHAR(255);

    BEGIN TRANSACTION;
    BEGIN TRY

        SELECT @gia1 = gia_tien, @ram1 = ram, @gpu1 = card_roi, @trong_luong1 = trong_luong, 
               @cpu1 = cpu, @o_cung1 = o_cung, @man_hinh1 = man_hinh 
        FROM View_MayTinh WHERE ma_may_tinh = @ma1;

        SELECT @gia2 = gia_tien, @ram2 = ram, @gpu2 = card_roi, @trong_luong2 = trong_luong, 
               @cpu2 = cpu, @o_cung2 = o_cung, @man_hinh2 = man_hinh 
        FROM View_MayTinh WHERE ma_may_tinh = @ma2;


        SET @SoSanhGia = dbo.SoSanhGiaTien(@gia1, @gia2);
        SET @SoSanhRam = dbo.SoSanhRam(@ram1, @ram2);
        SET @SoSanhGpu = dbo.SoSanhCard(@gpu1, @gpu2);
        SET @SoSanhTrongLuong = dbo.SoSanhTrongLuong(@trong_luong1, @trong_luong2);
        SET @SoSanhCpu = dbo.SoSanhCPU(@cpu1, @cpu2);
        SET @SoSanhOCung = dbo.SoSanhO_cung(@o_cung1, @o_cung2);
        SET @SoSanhManHinh = dbo.SoSanhManHinh(@man_hinh1, @man_hinh2);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;

    SELECT 
        (SELECT ten_may_tinh FROM View_MayTinh WHERE ma_may_tinh = @ma1) AS Laptop1,
        (SELECT ten_may_tinh FROM View_MayTinh WHERE ma_may_tinh = @ma2) AS Laptop2,
        @SoSanhGia AS SoSanhGia,
        @SoSanhRam AS SoSanhRam,
        @SoSanhGpu AS SoSanhGpu,
        @SoSanhTrongLuong AS SoSanhTrongLuong,
        @SoSanhCpu AS SoSanhCPU,
        @SoSanhOCung AS SoSanhOCung,
        @SoSanhManHinh AS SoSanhManHinh;
END;
GO





IF OBJECT_ID('dbo.TimKiemTenMayTinh', 'FN') IS NOT NULL
    DROP FUNCTION dbo.TimKiemTenMayTinh;
GO
CREATE FUNCTION dbo.TimKiemTenMayTinh(
    @tu_khoa NVARCHAR(255) = NULL -- Từ khóa có thể NULL
)
RETURNS @result TABLE (
    ten_may_tinh NVARCHAR(255)
)
AS
BEGIN
	
    INSERT INTO @result
    SELECT 
        ten_may_tinh
    FROM View_MayTinh
    WHERE 
        (@tu_khoa IS NULL OR 
        ten_may_tinh LIKE '%' + @tu_khoa + '%')
    RETURN;
END;
GO




