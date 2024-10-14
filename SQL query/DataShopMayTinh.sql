USE ShopMayTinh;
INSERT INTO TaiKhoan (tai_khoan, mat_khau, ma_nguoi_dung) 
VALUES ('quanlycuahang', 'key000', 'admin');

INSERT INTO ChuShop (ma_chu_shop, ten_chu_shop, email, dia_chi, so_dien_thoai) 
VALUES ('admin', N'HCMUTE', 'shophcmute@gmail.com', N'123 Đường Số 1, Quận 1, TP.HCM', '0123456789');

INSERT INTO TaiKhoan (tai_khoan, mat_khau, ma_nguoi_dung) 
VALUES 
('khach1', 'key001', 'kh0001'),
('khach2', 'key002', 'kh0002'),
('khach3', 'key003', 'kh0003'),
('khach4', 'key004', 'kh0004'),
('khach5', 'key005', 'kh0005'),
('khach6', 'key006', 'kh0006'),
('khach7', 'key007', 'kh0007'),
('khach8', 'key008', 'kh0008'),
('khach9', 'key009', 'kh0009'),
('khach10', 'key010', 'kh0010');

INSERT INTO KhachHang (ma_khach_hang, ten_khach_hang, email, dia_chi, so_dien_thoai) 
VALUES 
('kh0001', N'Nguyễn Văn Anh', 'vananh@gmail.com', N'456 Đường Số 2, Quận 2, TP.HCM', '0987654321'),
('kh0002', N'Trần Thị Bình ', 'tranbinh@gmail.com', N'789 Đường Số 3, Quận 3, TP.HCM', '0912345678'),
('kh0003', N'Lê Văn Cường', 'vancuong@gmail.com', N'321 Đường Số 4, Quận 4, TP.HCM', '0923456789'),
('kh0004', N'Phạm Thị Duyên', 'duyenpham@gmail.com', N'654 Đường Số 5, Quận 5, TP.HCM', '0934567890'),
('kh0005', N'Huỳnh Văn Thắng', 'vanthang@gmail.com', N'987 Đường Số 6, Quận 6, TP.HCM', '0945678901'),
('kh0006', N'Ngô Thị Ngọc', 'ngocngo@gmail.com', N'159 Đường Số 7, Quận 7, TP.HCM', '0956789012'),
('kh0007', N'Đặng Văn Giang', 'vangiang@gmail.com', N'753 Đường Số 8, Quận 8, TP.HCM', '0967890123'),
('kh0008', N'Bùi Thị Hương', 'huongbui@gmail.com', N'852 Đường Số 9, Quận 9, TP.HCM', '0978901234'),
('kh0009', N'Vũ Văn Tuấn', 'vantuan@gmail.com', N'369 Đường Số 10, Quận 10, TP.HCM', '0989012345'),
('kh0010', N'Nguyễn Thị Hồng', 'hongnguyen@gmail.com', N'258 Đường Số 11, Quận 11, TP.HCM', '0990123456');

INSERT INTO MayTinh (ma_may_tinh, ten_may_tinh, mo_ta, gia_tien, ton_kho, cpu, ram, o_cung, card_roi, man_hinh, trong_luong, nam_san_suat, bao_hanh)
VALUES 
('MT01', 'Dell XPS 13', N'Laptop siêu mỏng, hiệu năng cao, phù hợp cho văn phòng và du lịch.', 29000000, 10, 'Intel Core i7-1165G7', '16GB LPDDR4x', '512GB SSD', 'Intel Iris Xe', '13.4 inch FHD+', 1.2, 2023, N'12 tháng'),
('MT02', 'ASUS ROG Zephyrus G14', N'Laptop gaming mạnh mẽ với thiết kế nhỏ gọn, dành cho game thủ.', 35000000, 8, 'AMD Ryzen 9 5900HS', '32GB DDR4', '1TB SSD', 'NVIDIA GeForce RTX 3060', '14 inch QHD', 1.6, 2023, N'12 tháng'),
('MT03', 'HP Spectre x360', N'Laptop 2 trong 1 với thiết kế đẹp và tính năng cảm ứng.', 32000000, 5, 'Intel Core i7-1250U', '16GB LPDDR4x', '1TB SSD', 'Intel Iris Xe', '13.3 inch FHD', 1.3, 2023, N'12 tháng'),
('MT04', 'Lenovo ThinkPad X1 Carbon', N'Laptop doanh nhân bền bỉ, hiệu suất cao, bàn phím tuyệt vời.', 40000000, 6, 'Intel Core i7-1260P', '16GB LPDDR5', '512GB SSD', 'Intel Iris Xe', '14 inch FHD', 1.1, 2023, N'12 tháng'),
('MT05', 'Acer Aspire 5', N'Laptop văn phòng với hiệu năng ổn định và giá cả phải chăng.', 15000000, 15, 'Intel Core i5-1135G7', '8GB DDR4', '512GB SSD', 'Intel Iris Xe', '15.6 inch FHD', 1.8, 2022, N'12 tháng'),
('MT06', 'Microsoft Surface Laptop 4', N'Laptop mỏng nhẹ với màn hình cảm ứng và thời lượng pin lâu.', 29000000, 7, 'Intel Core i5-1135G7', '16GB LPDDR4x', '512GB SSD', 'Intel Iris Xe', '13.5 inch', 1.3, 2023, N'12 tháng'),
('MT07', 'Razer Blade 15', N'Laptop gaming với thiết kế đẹp và hiệu năng mạnh mẽ.', 45000000, 4, 'Intel Core i7-12800H', '16GB DDR5', '1TB SSD', 'NVIDIA GeForce RTX 3070', '15.6 inch FHD', 2.1, 2023, N'12 tháng'),
('MT08', 'Apple MacBook Air M1', N'Laptop nhẹ nhàng, hiệu năng cao với chip M1.', 29000000, 10, 'Apple M1', '8GB', '256GB SSD', 'Apple GPU', '13.3 inch Retina', 1.29, 2020, N'12 tháng'),
('MT09', 'Dell G5 15', N'Laptop gaming với cấu hình tốt và giá cả hợp lý.', 27000000, 9, 'Intel Core i5-10500H', '8GB DDR4', '512GB SSD', 'NVIDIA GeForce GTX 1650', '15.6 inch FHD', 2.5, 2021, N'12 tháng'),
('MT10', 'HP Envy x360', N'Laptop 2 trong 1 linh hoạt với màn hình cảm ứng.', 21000000, 8, 'AMD Ryzen 5 5500U', '16GB DDR4', '512GB SSD', 'AMD Radeon Graphics', '15.6 inch FHD', 1.6, 2022, N'12 tháng');

-- Thêm hình ảnh vào các máy tính
DECLARE @ImageData VARBINARY(MAX);

-- Cập nhật hình ảnh cho từng máy tính
-- Dell XPS 13
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'D:\DBMS\MayTinhPic\MT01.jpg', SINGLE_BLOB) AS Image;
UPDATE MayTinh SET hinh_anh = @ImageData WHERE ma_may_tinh = N'MT01';

-- ASUS ROG Zephyrus G14
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'D:\DBMS\MayTinhPic\MT02.jpg', SINGLE_BLOB) AS Image;
UPDATE MayTinh SET hinh_anh = @ImageData WHERE ma_may_tinh = N'MT02';

-- HP Spectre x360
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'D:\DBMS\MayTinhPic\MT03.jpg', SINGLE_BLOB) AS Image;
UPDATE MayTinh SET hinh_anh = @ImageData WHERE ma_may_tinh = N'MT03';

-- Lenovo ThinkPad X1 Carbon
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'D:\DBMS\MayTinhPic\MT04.jpg', SINGLE_BLOB) AS Image;
UPDATE MayTinh SET hinh_anh = @ImageData WHERE ma_may_tinh = N'MT04';

-- Acer Aspire 5
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'D:\DBMS\MayTinhPic\MT05.jpg', SINGLE_BLOB) AS Image;
UPDATE MayTinh SET hinh_anh = @ImageData WHERE ma_may_tinh = N'MT05';

-- Microsoft Surface Laptop 4
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'D:\DBMS\MayTinhPic\MT06.jpg', SINGLE_BLOB) AS Image;
UPDATE MayTinh SET hinh_anh = @ImageData WHERE ma_may_tinh = N'MT06';

-- Razer Blade 15
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'D:\DBMS\MayTinhPic\MT07.jpg', SINGLE_BLOB) AS Image;
UPDATE MayTinh SET hinh_anh = @ImageData WHERE ma_may_tinh = N'MT07';

-- Apple MacBook Air M1
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'D:\DBMS\MayTinhPic\MT08.jpg', SINGLE_BLOB) AS Image;
UPDATE MayTinh SET hinh_anh = @ImageData WHERE ma_may_tinh = N'MT08';

-- Dell G5 15
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'D:\DBMS\MayTinhPic\MT09.jpg', SINGLE_BLOB) AS Image;
UPDATE MayTinh SET hinh_anh = @ImageData WHERE ma_may_tinh = N'MT09';

-- HP Envy x360
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'D:\DBMS\MayTinhPic\MT10.jpg', SINGLE_BLOB) AS Image;
UPDATE MayTinh SET hinh_anh = @ImageData WHERE ma_may_tinh = N'MT10';

-- Thêm dữ liệu khuyến mãi
INSERT INTO KhuyenMai (ma_khuyen_mai, ten_khuyen_mai, mo_ta, phan_tram_giam, so_tien_giam, ngay_bat_dau, ngay_ket_thuc)
VALUES 
('KM01', N'Giảm giá cuối năm', N'Giảm 15% trong tháng 12.', 15, NULL, '2024-12-01', '2024-12-31'),
('KM02', N'Giảm giá học sinh, sinh viên', N'Giảm 10% cho học sinh, sinh viên khi mua máy tính.', 10, NULL, '2024-09-01', '2024-12-31'),
('KM03', N'Giảm giá mùa hè', N'Giảm 20% cho mùa hè.', 20, NULL, '2024-06-01', '2024-08-31');
INSERT INTO SanPham_KhuyenMai (ma_may_tinh, ma_khuyen_mai)
VALUES 
('MT01', 'KM01'),
('MT02', 'KM01'),
('MT03', 'KM02'),
('MT04', 'KM03'),
('MT05', 'KM01'),
('MT06', 'KM03'),
('MT07', 'KM02');