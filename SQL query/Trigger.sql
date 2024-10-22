use ShopMayTinh

---Thêm khuyến mãi cho tất cả khách hàng khi thêm khuyến mãi cho sản phẩm
IF OBJECT_ID('dbo.Trig_AfterInsert_KhuyenMai', 'TR') IS NOT NULL
    DROP TRIGGER dbo.Trig_AfterInsert_KhuyenMai;
GO
CREATE TRIGGER dbo.Trig_AfterInsert_KhuyenMai
ON KhuyenMai
AFTER INSERT
AS
BEGIN
    INSERT INTO KhuyenMai_KhachHang (ma_khach_hang, ma_khuyen_mai, trang_thai)
	SELECT kh.ma_khach_hang, i.ma_khuyen_mai, 1
	FROM KhachHang kh
	JOIN inserted i ON 1 = 1;
END;
