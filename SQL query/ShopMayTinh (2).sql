CREATE DATABASE ShopMayTinh;
GO;

USE ShopMayTinh;

CREATE TABLE MayTinh (
    ma_may_tinh VARCHAR(50) PRIMARY KEY,
    ten_may_tinh NVARCHAR(255) NOT NULL,
    mo_ta NVARCHAR(255),
    gia_tien INT NOT NULL,
    ton_kho INT NOT NULL,
    cpu NVARCHAR(255) NOT NULL,
    ram NVARCHAR(255) NOT NULL,
    o_cung NVARCHAR(255) NOT NULL,
    card_roi NVARCHAR(255) NOT NULL,
    man_hinh NVARCHAR(255) NOT NULL,
	trong_luong FLOAT,
	nam_san_suat INT,
    bao_hanh NVARCHAR(255) NOT NULL,
    hinh_anh VARBINARY(MAX)
);

CREATE TABLE TaiKhoan (
    tai_khoan VARCHAR(50) PRIMARY KEY,
    mat_khau VARCHAR(255) NOT NULL,
    ma_nguoi_dung VARCHAR(50) UNIQUE,
);

CREATE TABLE ChuShop (
    ma_chu_shop VARCHAR(50) PRIMARY KEY,
    ten_chu_shop NVARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    dia_chi NVARCHAR(255),
    so_dien_thoai VARCHAR(20) UNIQUE,
	FOREIGN KEY (ma_chu_shop) REFERENCES TaiKhoan(ma_nguoi_dung)
);
CREATE TABLE KhachHang (
    ma_khach_hang VARCHAR(50) PRIMARY KEY,
    ten_khach_hang NVARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    dia_chi NVARCHAR(255),
    so_dien_thoai VARCHAR(20) UNIQUE,
	FOREIGN KEY (ma_khach_hang) REFERENCES TaiKhoan(ma_nguoi_dung)
);


CREATE TABLE KhuyenMai (
    ma_khuyen_mai VARCHAR(50) PRIMARY KEY,
    ten_khuyen_mai NVARCHAR(255) NOT NULL,
    mo_ta NVARCHAR(255),
    phan_tram_giam FLOAT,
    so_tien_giam INT,
    ngay_bat_dau DATE,
    ngay_ket_thuc DATE,
);

CREATE TABLE DonHang (
    ma_don_hang VARCHAR(50) PRIMARY KEY,
    ma_khach_hang VARCHAR(50),
    ngay_dat_hang DATE,
    tong_tien INT,
	trang_thai INT,
    FOREIGN KEY (ma_khach_hang) REFERENCES KhachHang(ma_khach_hang)
);

CREATE TABLE DanhGia (
    ma_danh_gia VARCHAR(50) PRIMARY KEY,
    ma_khach_hang VARCHAR(50),
    ma_don_hang VARCHAR(50),
    so_sao_danh_gia INT CHECK (so_sao_danh_gia BETWEEN 1 AND 5),
    ngay_danh_gia DATE,
    noi_dung TEXT,
    FOREIGN KEY (ma_khach_hang) REFERENCES KhachHang(ma_khach_hang),
    FOREIGN KEY (ma_don_hang) REFERENCES DonHang(ma_don_hang)
);

CREATE TABLE DonHangChiTiet (
    ma_don_hang VARCHAR(50),
    ma_may_tinh VARCHAR(50),
    gia_ban INT,
    so_luong INT,
    PRIMARY KEY (ma_don_hang, ma_may_tinh),
    FOREIGN KEY (ma_don_hang) REFERENCES DonHang(ma_don_hang),
    FOREIGN KEY (ma_may_tinh) REFERENCES MayTinh(ma_may_tinh)
);

CREATE TABLE SanPham_KhuyenMai (
    ma_may_tinh VARCHAR(50),
    ma_khuyen_mai VARCHAR(50),
    PRIMARY KEY (ma_may_tinh, ma_khuyen_mai),
    FOREIGN KEY (ma_may_tinh) REFERENCES MayTinh(ma_may_tinh),
    FOREIGN KEY (ma_khuyen_mai) REFERENCES KhuyenMai(ma_khuyen_mai)
);

CREATE TABLE GioHang (
    ma_khach_hang VARCHAR(50),
    ma_may_tinh VARCHAR(50),
    so_luong INT NOT NULL,
	PRIMARY KEY (ma_khach_hang, ma_may_tinh),
    FOREIGN KEY (ma_khach_hang) REFERENCES KhachHang(ma_khach_hang) ON DELETE CASCADE
);

CREATE TABLE KhuyenMai_KhachHang (
    ma_khach_hang VARCHAR(50),
    ma_khuyen_mai VARCHAR(50),
    trang_thai INT NOT NULL,
    PRIMARY KEY (ma_khach_hang, ma_khuyen_mai),
    FOREIGN KEY (ma_khach_hang) REFERENCES KhachHang(ma_khach_hang) ON DELETE CASCADE,
    FOREIGN KEY (ma_khuyen_mai) REFERENCES KhuyenMai(ma_khuyen_mai) ON DELETE CASCADE
);

ALTER TABLE ChuShop
ADD CONSTRAINT FK_ChuShop_TaiKhoan
FOREIGN KEY (ma_chu_shop) REFERENCES TaiKhoan(ma_nguoi_dung) ON DELETE CASCADE;

ALTER TABLE KhachHang
ADD CONSTRAINT FK_KhachHang_TaiKhoan
FOREIGN KEY (ma_khach_hang) REFERENCES TaiKhoan(ma_nguoi_dung) ON DELETE CASCADE;

ALTER TABLE DonHang
ADD CONSTRAINT FK_DonHang_KhachHang
FOREIGN KEY (ma_khach_hang) REFERENCES KhachHang(ma_khach_hang) ON DELETE CASCADE;

ALTER TABLE DanhGia
ADD CONSTRAINT FK_DanhGia_KhachHang
FOREIGN KEY (ma_khach_hang) REFERENCES KhachHang(ma_khach_hang);

ALTER TABLE DanhGia
ADD CONSTRAINT FK_DanhGia_DonHang
FOREIGN KEY (ma_don_hang) REFERENCES DonHang(ma_don_hang) ON DELETE CASCADE;

ALTER TABLE DonHangChiTiet
ADD CONSTRAINT FK_DonHangChiTiet_DonHang
FOREIGN KEY (ma_don_hang) REFERENCES DonHang(ma_don_hang) ON DELETE CASCADE;

ALTER TABLE DonHangChiTiet
ADD CONSTRAINT FK_DonHangChiTiet_MayTinh
FOREIGN KEY (ma_may_tinh) REFERENCES MayTinh(ma_may_tinh) ON DELETE CASCADE;

ALTER TABLE SanPham_KhuyenMai
ADD CONSTRAINT FK_SanPhamKhuyenMai_MayTinh
FOREIGN KEY (ma_may_tinh) REFERENCES MayTinh(ma_may_tinh) ON DELETE CASCADE;

ALTER TABLE SanPham_KhuyenMai
ADD CONSTRAINT FK_SanPhamKhuyenMai_KhuyenMai
FOREIGN KEY (ma_khuyen_mai) REFERENCES KhuyenMai(ma_khuyen_mai) ON DELETE CASCADE;

