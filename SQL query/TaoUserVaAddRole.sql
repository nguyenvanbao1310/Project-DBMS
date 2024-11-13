


-- Tạo login cho tài khoản quản lý cửa hàng
CREATE LOGIN quanlycuahang WITH PASSWORD = 'key000';
CREATE USER quanlycuahang FOR LOGIN quanlycuahang;

-- Tạo login và user cho các khách hàng
CREATE LOGIN khach1 WITH PASSWORD = 'key001';
CREATE USER khach1 FOR LOGIN khach1;

CREATE LOGIN khach2 WITH PASSWORD = 'key002';
CREATE USER khach2 FOR LOGIN khach2;

CREATE LOGIN khach3 WITH PASSWORD = 'key003';
CREATE USER khach3 FOR LOGIN khach3;

CREATE LOGIN khach4 WITH PASSWORD = 'key004';
CREATE USER khach4 FOR LOGIN khach4;

CREATE LOGIN khach5 WITH PASSWORD = 'key005';
CREATE USER khach5 FOR LOGIN khach5;

CREATE LOGIN khach6 WITH PASSWORD = 'key006';
CREATE USER khach6 FOR LOGIN khach6;

CREATE LOGIN khach7 WITH PASSWORD = 'key007';
CREATE USER khach7 FOR LOGIN khach7;

CREATE LOGIN khach8 WITH PASSWORD = 'key008';
CREATE USER khach8 FOR LOGIN khach8;

CREATE LOGIN khach9 WITH PASSWORD = 'key009';
CREATE USER khach9 FOR LOGIN khach9;

CREATE LOGIN khach10 WITH PASSWORD = 'key010';
CREATE USER khach10 FOR LOGIN khach10;



-- Thêm các tài khoản khách hàng vào role RKhachHang
ALTER ROLE RKhachHang ADD MEMBER khach1;
ALTER ROLE RKhachHang ADD MEMBER khach2;
ALTER ROLE RKhachHang ADD MEMBER khach3;
ALTER ROLE RKhachHang ADD MEMBER khach4;
ALTER ROLE RKhachHang ADD MEMBER khach5;
ALTER ROLE RKhachHang ADD MEMBER khach6;
ALTER ROLE RKhachHang ADD MEMBER khach7;
ALTER ROLE RKhachHang ADD MEMBER khach8;
ALTER ROLE RKhachHang ADD MEMBER khach9;
ALTER ROLE RKhachHang ADD MEMBER khach10;

-- Thêm các tài khoản chủ shop vào role RChuShop
ALTER ROLE RChuShop ADD MEMBER quanlycuahang;
