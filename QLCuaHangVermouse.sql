CREATE DATABASE QLCuaHangVermouse
GO

USE QLCuaHangVermouse
GO

--Tạo bảng Loại tài khoản
CREATE TABLE LoaiTK (
	MaLoaiTK INT IDENTITY(1,1) PRIMARY KEY,
	TenLoaiTK NVARCHAR(20)
)
GO

--Tạo bảng Tài Khoản
CREATE TABLE TaiKhoan (
	TenTK NVARCHAR(50) PRIMARY KEY,
	MatKhau NVARCHAR(50) NOT NULL,
	Email NVARCHAR(100),
	MaLoaiTK INT,
	HoTen NVARCHAR(50),
	DiaChi NVARCHAR(100),
	SDT VARCHAR(10),
	Avatar NVARCHAR(500),
	Token NVARCHAR(500),
	FOREIGN KEY (MaLoaiTK) REFERENCES dbo.LoaiTK(MaLoaiTK) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

-- Tạo bảng Loại hàng
CREATE TABLE TheLoai (
    MaLoai  INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(50) NOT NULL
)
GO

-- Tạo bảng Sản phẩm 
CREATE TABLE SanPham (
    MaSP  INT IDENTITY(1,1) PRIMARY KEY,
    TenSP NVARCHAR(50) NOT NULL,
	Size CHAR(5) NOT NULL,
	GiaBan FLOAT NOT NULL,
	GiaGiam FLOAT,
    MaLoai  INT,
    SoLuongTon INT DEFAULT 0,
	SoLuongBan INT DEFAULT 0,
	ImageURL NVARCHAR(500),
	Mota NVARCHAR(500),
	TrangThai NVARCHAR(50),
    FOREIGN KEY (MaLoai) REFERENCES dbo.TheLoai(MaLoai) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

-- Tạo bảng Nhà cung cấp 
CREATE TABLE NhaCungCap (
    MaNCC  INT IDENTITY(1,1) PRIMARY KEY,
    TenNCC NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(100),
    SoDienThoai VARCHAR(10),
	Email NVARCHAR(100)
)
GO

---Tạo bảng Khách hàng
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
	TenKH NVARCHAR(50) NOT NULL,
	GioiTinh NVARCHAR(5),
	NgaySinh DATE,
	Diachi NVARCHAR(50),
	Email NVARCHAR(100), 
	SDT VARCHAR(10)
)
GO

-- Tạo bảng Hóa đơn nhập
CREATE TABLE HoaDonNhap (
    MaHDN INT IDENTITY(1,1) PRIMARY KEY,
    NgayNhap DATE NOT NULL,
    MaNCC INT,
	TenTK NVARCHAR(50), 
	GhiChu NVARCHAR(50),
    FOREIGN KEY (MaNCC) REFERENCES dbo.NhaCungCap(MaNCC) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (TenTK) REFERENCES dbo.TaiKhoan(TenTK) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

-- Tạo bảng Chi tiết hóa đơn nhập 
CREATE TABLE ChiTietHoaDonNhap(
    MaChiTietHDN INT IDENTITY(1,1) PRIMARY KEY,
    MaHDN INT,
    MaSP INT,
    SoLuong INT,
    GiaNhap FLOAT,
	TongTien FLOAT,
    FOREIGN KEY (MaHDN) REFERENCES dbo.HoaDonNhap(MaHDN) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES dbo.SanPham(MaSP) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

-- Tạo bảng Hóa đơn bán
CREATE TABLE HoaDonBan (
    MaHDB INT IDENTITY(1,1) PRIMARY KEY,
    TrangThai BIT,
    NgayTao DATE,
    NgayDuyet DATE,   
    TenKH NVARCHAR(50),    
    Diachi NVARCHAR(250),
    Email VARCHAR(50),
    SDT NCHAR(10),
    DiaChiGiaoHang NVARCHAR(350),
    ThoiGianGiaoHang DATETIME
)
GO

-- Tạo bảng Chi tiết hóa đơn bán  
CREATE TABLE ChiTietHoaDonBan (
    MaChiTietHDB INT IDENTITY(1,1) PRIMARY KEY,
    MaHDB  INT,
    MaSP INT,
    SoLuong INT,
    GiaBan FLOAT,
	TongTien FLOAT,
    FOREIGN KEY (MaHDB) REFERENCES dbo.HoaDonBan(MaHDB) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES dbo.SanPham(MaSP) ON DELETE CASCADE ON UPDATE CASCADE
)
GO


---------------CHÈN DỮ LIỆU-------------------
--Chèn dữ liệu vào bảng loại tài khoản
INSERT INTO LoaiTK(TenLoaiTK)
VALUES
(N'Khách Hàng'),   
(N'Admin')
GO

--Chèn dữ liệu vào bảng tài khoản
INSERT INTO TaiKhoan (TenTK, MatKhau, Email, MaLoaiTK, HoTen, DiaChi, SDT, Avatar, Token)
VALUES
('quangne2003', 'quang203', 'quang2003@gmail.com', '1', N'Lê Văn Quảng', N'Hưng Yên', '0987654321', null, null),
('admin', 'admin', 'admin01@gmail.com', '2', N'Admin Quảng', N'Hưng Yên', '0123456789', null, null)

-- Chèn dữ liệu vào bảng LoaiHang
INSERT INTO TheLoai (TenLoai)
VALUES
(N'Áo dài tay'),
(N'Đầm'),
(N'Quần dài'),
(N'Set Combo'),
(N'Váy'),
(N'Áo sơ mi'),
(N'Áo cộc tay'),
(N'Quần short'),
(N'Áo đá bóng'),
(N'Áo bảo hộ')

-- Chèn dữ liệu vào bảng SanPham
INSERT INTO dbo.SanPham(TenSP, Size, GiaBan, GiaGiam, MaLoai, SoLuongTon, SoLuongBan, ImageURL, Mota, TrangThai)
VALUES
(N'SAND - BAD UNIFORM TEE','M', 300000, 100000, '1',20, 10, null, null, 'còn hàng'),
(N'GREY - BAD UNIFORM TEE', 'L', 500000, 100000, '2',20, 10, null, null, 'còn hàng'),
(N'ACID KAKI PANTS', 'XL', 700000, 100000, '3',20, 10, null, null, 'hết hàng'),
(N'FALLEN ANGEL TEE', 'M', 750000, 100000, '4',20, 10, null, null, 'hết hàng'),
(N'MOUNTAIN SHORT OLIVE', 'L', 600000, 100000, '5',20, 10, null, null, 'còn hàng'),
(N'GREY DESTROYED SWEAT SHORT', 'M', 500000, 100000, '6',20, 10, null, null, 'còn hàng'),
(N'BASIC TEE - WHITE', 'M', 400000, 100000, '7',20, 10, null, null, 'hết hàng'),
(N'BAD LOVER TEE', 'L', 300000, 100000, '8',20, 10, null, null, 'còn hàng'),
(N'BASIC TEE - MOCA', 'XL', 450000, 100000, '9',20, 10, null, null, 'hết hàng'),
(N'KING CARD SHIRT', 'XL', 650000, 100000, '10',20, 10, null, null, 'còn hàng')

-- Chèn dữ liệu vào bảng NhaCungCap
INSERT INTO NhaCungCap (TenNCC, DiaChi, SoDienThoai, Email)
VALUES
(N'Huy Dior', N'Hà Nội', '0123456789', 'huy01@gmail.com'),
(N'Hưng Gucci', N'Hồ Chí Minh', '0123456789', 'hung02@gmail.com'),
(N'Hoàng Chanel', N'Đà Nẵng', '0123456789', 'hoang03@gmail.com'),
(N'Quảng YSL', N'Nha Trang', '0123456789', 'quang04@gmail.com'),
(N'Tùng Versace', N'Huế', '0123456789', 'tung05@gmail.com'),
(N'Minh Tom Ford', N'Đồng Nai', '0123456789', 'minh06@gmail.com'),
(N'Kiên Paco Rabanne', N'Hải Phòng', '0123456789', 'kien07@gmail.com'),
(N'Thắng Givenchy', N'Bình Dương', '0123456789', 'thang08@gmail.com'),
(N'Quốc Bvlgari', N'Cần Thơ', '0123456789', 'quoc09@gmail.com'),
(N'Quyến Hermes', N'Vũng Tàu', '0123456789', 'quyen10@gmail.com')

-- Chèn dữ liệu vào bảng KhachHang
INSERT INTO KhachHang (TenKH, GioiTinh, NgaySinh, Diachi, Email, SDT)
VALUES
(N'Nguyễn Thi Xuân Mai', N'Nữ', '2004-12-24', N'Hưng Yên', N'nguyenthixuanmai@gmail.com', N'0123456789'),
(N'Trần Kim Long', N'Nam', '2003-09-05', N'Hưng Yên', N'trankimlong@gmail.com', N'0123456788'),
(N'Dương Kim Linh', N'Nữ', '1999-12-12', N'Hà Nội', N'duongkimlinh@gmail.com', N'0123456778'),
(N'Đặng Thanh Sơn', N'Nam', '2003-05-13', N'Hải Dương', N'dangthanhson@gmail.com', N'0123456678'),
(N'Đỗ Tuấn Dương', N'Nam', '1999-02-16', N'Hà Nam', N'dotuanduong@gmail.com', N'0123455678'),
(N'Lê Đức Mạnh', N'Nam', '2003-06-22', N'Hưng Yên', N'leducmanh@gmail.com', N'0123445678'),
(N'Lê Thị Thanh Thảo', N'Nữ', '2003-04-25', N'Hà Nội', N'lethithanhthao@gmail.com', N'0123345678'),
(N'Đỗ Thị Tuyết', N'Nữ', '2001-08-12', N'Hà Nội', N'dothituyet@gmail.com', N'0122345678'),
(N'Võ Thanh Mai', N'Nữ', '2001-06-29', N'Hà Nam', N'vothanhmai@gmail.com', N'0112345678'),
(N'Nguyễn Bình Minh', N'Nam', '2000-08-09', N'Hải Dương', N'nguyenbinhminh@gmail.com', N'0123456798')

-- Chèn dữ liệu vào bảng HoaDonNhap
INSERT INTO HoaDonNhap (NgayNhap, MaNCC, TenTK, GhiChu)
VALUES
('2023-01-05', '2', 'quangne2003', null),
('2023-02-10', '3', 'quangne2003', null),
('2023-03-15', '5', 'quangne2003', null),
('2023-04-20', '4', 'quangne2003', null),
('2023-05-25', '7', 'quangne2003', null),
('2023-06-30', '6', 'quangne2003', null),
('2023-07-05', '8', 'admin', null),
('2023-08-10', '6', 'admin', null),
('2023-09-15', '4', 'admin', null),
('2023-10-20', '3', 'admin', null),
('2023-10-20', '2', 'admin', null)

-- Chèn dữ liệu vào bảng ChiTietHoaDonNhap
INSERT INTO ChiTietHoaDonNhap (MaHDN, MaSP, SoLuong, GiaNhap, TongTien)
VALUES
('1', '8', 2, 2400000, 800000),
('2', '9', 3, 2500000, 800000),
('3', '6', 4, 3000000, 800000),
('4', '7', 5, 3500000, 800000),
('5', '5', 6, 4000000, 800000),
('6', '4', 7, 4500000, 800000),
('7', '5', 8, 5000000, 800000),
('8', '6', 9, 5500000, 800000),
('9', '3', 5, 6000000, 800000)

-- Chèn dữ liệu vào bảng HoaDonBan
INSERT INTO HoaDonBan (TrangThai, NgayTao, NgayDuyet, TenKH, DiaChi, Email, SDT, DiaChiGiaoHang, ThoiGianGiaoHang)
VALUES
(1, '2023-03-01', '2023-03-02', N'Nguyễn Thi Xuân Mai', N'Hưng Yên', N'nguyenthixuanmai@gmail.com', N'123456789', N'Địa chỉ giao hàng 1', '2023-03-03'),
(0, '2023-03-01', '2023-03-02', N'Trần Kim Long', N'Hưng Yên', N'trankimlong@gmail.com', N'123456789', N'Địa chỉ giao hàng 2', '2023-03-03')

-- Chèn dữ liệu vào bảng ChiTietHoaDonBan
INSERT INTO ChiTietHoaDonBan (MaHDB, MaSP, SoLuong, GiaBan)
VALUES
('1', '3', 2, 2400000),
('2', '3', 3, 2500000),
('1', '5', 4, 2500000),
('1', '4', 5, 3500000),
('2', '5', 6, 4000000),
('1', '7', 7, 4500000),
('1', '8', 8, 5000000),
('2', '6', 9, 6000000)

SELECT * FROM dbo.LoaiTK
SELECT * FROM dbo.TaiKhoan
SELECT * FROM dbo.KhachHang
SELECT * FROM dbo.TheLoai
SELECT * FROM dbo.NhaCungCap
SELECT * FROM dbo.SanPham
SELECT * FROM dbo.HoaDonNhap
SELECT * FROM dbo.ChiTietHoaDonNhap
SELECT * FROM dbo.HoaDonBan
SELECT * FROM dbo.ChiTietHoaDonBan



------------------KHÁCH HÀNG----------------------
--Thêm Khách hàng
CREATE PROC [dbo].[sp_khachhang_create]
(	
	@MaKH INT,
	@TenKH NVARCHAR(50),
	@GioiTinh NVARCHAR(5),
	@NgaySinh DATE,
	@Diachi VARCHAR(50),
	@Email VARCHAR(100), 
	@SDT VARCHAR(10)
)
AS 
BEGIN
INSERT INTO KhachHang(MaKH,TenKH,GioiTinh,NgaySinh,DiaChi,Email,SDT) VALUES (@MaKH,@TenKH,@GioiTinh,@NgaySinh,@DiaChi,@Email,@SDT)
END

-----Tìm kiếm khách hàng theo mã
CREATE PROCEDURE [dbo].[sp_searchKH_by_MaNV]
	@MaKH INT
AS
BEGIN
	SELECT * FROM KhachHang AS KH WHERE KH.MaKH=@MaKH
END

--Cập nhật thông tin khach hang
CREATE PROC [dbo].[sp_khachhang_update]
	@MaKH INT,
	@TenKH NVARCHAR(50),
	@GioiTinh NVARCHAR(5),
	@NgaySinh DATE,
	@Diachi VARCHAR(50),
	@Email VARCHAR(100), 
	@SDT VARCHAR(10)
AS
BEGIN
	UPDATE KhachHang SET TenKH=@TenKH, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh, Diachi=@Diachi, Email=@Email, SDT=@SDT WHERE MaKH=@MaKH
END

--Xóa khách hàng theo mã
CREATE PROC [dbo].[sp_DeleteKH]	
	@MaKH INT
AS
BEGIN 
	DELETE KhachHang WHERE @MaKH=MaKH
END


 -------------------NHÀ CUNG CẤP---------------------
 ---Thủ tục thêm nhà cung cấp
CREATE PROC sp_nhacungcap_create 
 @MaNCC INT,
 @TenNCC NVARCHAR(50),
 @DiaChi NVARCHAR(100),
 @SoDienthoai VARCHAR(10),
 @Email NVARCHAR(100)
AS
BEGIN
	INSERT INTO NhaCungCap(MaNCC, TenNCC, DiaChi, SoDienThoai, Email) VALUES (@MaNCC,@TenNCC,@DiaChi,@SoDienthoai,@Email)
END

 -----Tìm kiếm nhà cung cấp theo Mã NCC
CREATE PROC sp_searchNCC_by_MaNCC
 @MaNCC INT
AS
BEGIN 
 SELECT * FROM NhaCungCap AS ncc WHERE ncc.MaNCC=@MaNCC
END

 ----Cập nhật thông tin Nhà cung cấp
CREATE PROC sp_nhacungcap_update
 @MaNCC INT,
 @TenNCC NVARCHAR(50),
 @DiaChi NVARCHAR(100),
 @SoDienthoai VARCHAR(10),
 @Email NVARCHAR(100)
AS
BEGIN
	UPDATE NhaCungCap SET TenNCC=@TenNCC,DiaChi=@DiaChi,SoDienThoai=@SoDienthoai,Email=@Email WHERE MaNCC=@MaNCC
END
 
 ----Xóa Nhà cung cấp theo mã 
CREATE PROC sp_DeleteNCC
 @MaNCC INT
AS
BEGIN 
 DELETE NhaCungCap WHERE @MaNCC=MaNCC
END

 -----------------------THỂ LOẠI---------------------
 ---Thủ tục thêm thể loại
CREATE PROC sp_ThemTL 
 @MaLoai INT,
 @TenLoai NVARCHAR(50)
AS
BEGIN
	INSERT INTO TheLoai(MaLoai, TenLoai) VALUES (@MaLoai,@TenLoai)
END

 -----Tìm kiếm thể loại theo Mã Loại
CREATE PROC sp_TimKiemTL
 @MaLoai INT
AS
BEGIN 
 SELECT * FROM TheLoai AS tl WHERE tl.MaLoai=@MaLoai
END

 ----Cập nhật thông tin Thể loại
CREATE PROC sp_SuaTL
 @MaLoai INT,
 @TenLoai NVARCHAR(50)
AS
BEGIN
	UPDATE TheLoai SET TenLoai=@TenLoai WHERE MaLoai= @MaLoai
END
 
 ----Xóa Thể loại theo mã 
CREATE PROC sp_XoaTL
 @MaLoai INT
AS
BEGIN 
 DELETE TheLoai WHERE @MaLoai= MaLoai
END

---------------------------SẢN PHẨM---------------------------
--Thêm Sản phẩm
CREATE PROCEDURE sp_ThemSanPham
	@MaSP NCHAR(10),
    @TenSP NVARCHAR(50),
	@Size CHAR(5),
	@GiaBan FLOAT,
	@GiaGiam FLOAT,
    @MaLoai NCHAR(10),
    @SoLuongTon INT,
	@SoLuongBan INT,
    @ImageURL NVARCHAR(250),
    @MoTa NVARCHAR(250),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    INSERT INTO SanPham (MaSP, TenSP, Size, GiaBan, GiaGiam, MaLoai, SoLuongTon, SoLuongBan, ImageURL, Mota, TrangThai)
    VALUES (@MaSP, @TenSP, @Size, @GiaBan, @GiaGiam, @MaLoai, @SoLuongTon, @SoLuongBan, @ImageURL, @Mota, @TrangThai);
END;

--Sửa Thông tin Sản phẩm (không sửa số lượng bán)
CREATE PROCEDURE sp_SuaThongTinSanPham
    @MaSP NCHAR(10),
    @TenSP NVARCHAR(50),
	@Size CHAR(5),
	@GiaBan FLOAT,
	@GiaGiam FLOAT,
    @MaLoai NCHAR(10),
    @SoLuongTon INT,
    @ImageURL NVARCHAR(250),
    @MoTa NVARCHAR(250),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    UPDATE SanPham
    SET TenSP=@TenSP, Size=@Size, GiaBan=@GiaBan, GiaGiam=@GiaGiam, MaLoai=@MaLoai, SoLuongTon=@SoLuongTon, ImageURL=@ImageURL, Mota=@MoTa, TrangThai=@TrangThai
    WHERE MaSP = @MaSP;
END;

--Sửa thông tin số lượng bán bảng sản phẩm
CREATE PROCEDURE sp_SuaSLBanSanPham
    @MaSP NCHAR(10),
    @SoLuongBan INT
AS
BEGIN
    UPDATE SanPham
    SET SoLuongBan = @SoLuongBan
    WHERE MaSP = @MaSP;
END;

--Xóa sản phẩm
CREATE PROCEDURE sp_XoaSanPham
    @MaSP INT
AS
BEGIN
    DELETE FROM SanPham
    WHERE MaSP = @MaSP;
END;

--Tìm kiếm sản phẩm theo tên
CREATE PROCEDURE sp_TimKiemSanPhamTheoTen
    @TenSP NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM SanPham
    WHERE TenSP LIKE '%' + @TenSP + '%';
END;

--Tìm kiếm sản phảm theo mã
CREATE PROCEDURE sp_TimKiemSanPhamTheoMa
    @MaSP NCHAR(10)
AS
BEGIN
    SELECT *
    FROM SanPham AS sp
    WHERE sp.MaSP = @MaSP;
END;

--------------------------LOẠI TÀI KHOẢN----------------------
-- Thêm loại tài khoản
CREATE PROCEDURE sp_ThemLoaiTaiKhoan
	@MaLoaiTK NCHAR(10),
    @TenLoaiTK NVARCHAR(50)
AS
BEGIN
    INSERT INTO LoaiTK(MaLoaiTK ,TenLoaiTK)
    VALUES (@MaLoaiTK, @TenLoaiTK);
END;

-- Sửa loại tài khoản
CREATE PROCEDURE sp_SuaLoaiTaiKhoan
    @MaLoaiTK NCHAR(10),
    @TenLoaiTK NVARCHAR(50)
AS
BEGIN
    UPDATE LoaiTK
    SET TenLoaiTK = @TenLoaiTK
    WHERE MaLoaiTK = @MaLoaiTK;
END;

-- Xóa loại tài khoản
CREATE PROCEDURE sp_XoaLoaiTaiKhoan
    @MaLoaiTK NCHAR(10)
AS
BEGIN
    DELETE FROM LoaiTK
    WHERE MaLoaiTK = @MaLoaiTK;
END;

-- Tìm kiếm loại tài khoản theo tên
CREATE PROCEDURE sp_TimKiemLoaiTaiKhoan
    @TenLoaiTK NVARCHAR(50)
AS
BEGIN
    SELECT * FROM LoaiTK
    WHERE TenLoaiTK LIKE N'%' + @TenLoaiTK + '%';
END;

-- Tìm kiếm loại tài khoản theo mã
CREATE PROCEDURE sp_TimKiemLoaiTaiKhoantheoma
    @MaLoaiTK NCHAR(10)
AS
BEGIN
    SELECT * FROM LoaiTK AS ltk
    WHERE ltk.MaLoaiTK = @MaLoaiTK;
END;

--------------------------TÀI KHOẢN--------------------------
-- Thêm tài khoản
CREATE PROCEDURE sp_ThemTaiKhoan
    @TenTK NVARCHAR(50),
    @MatKhau NVARCHAR(50),
	@MaLoaiTK NCHAR(10)
AS
BEGIN
    INSERT INTO TaiKhoan (TenTK, MatKhau, MaLoaiTK)
    VALUES (@TenTK, @MatKhau, @MaLoaiTK);
END;

-- Xóa tài khoản
CREATE PROCEDURE sp_XoaTaiKhoan
    @TenTK NVARCHAR(50)
AS
BEGIN
    DELETE FROM TaiKhoan
    WHERE TenTK = @TenTK;
END;

-- Đổi mật khẩu
CREATE PROCEDURE sp_DoiMatKhau
    @TenTK NVARCHAR(50),
    @MatKhauMoi NVARCHAR(50)
AS
BEGIN
    UPDATE TaiKhoan
    SET MatKhau = @MatKhauMoi
    WHERE TenTK = @TenTK;
END;

-- Cập nhật tài khoản
CREATE PROCEDURE sp_CapNhatTaiKhoan
    @TenTK NVARCHAR(50),
    @Email NVARCHAR(50),
    @HoTen NVARCHAR(50),
    @DiaChi NVARCHAR(250),
    @SDT VARCHAR(10),
    @Avatar NVARCHAR(500),
    @Token NVARCHAR(500)
AS
BEGIN
    UPDATE TaiKhoan
    SET Email = @Email, HoTen = @HoTen, DiaChi = @DiaChi, SDT = @SDT, Avatar = @Avatar, Token = @Token
    WHERE TenTK = @TenTK;
END;

-- Đăng nhập
CREATE PROCEDURE sp_DangNhap
    @TenTK NVARCHAR(50),
    @MatKhau NVARCHAR(50)
AS
BEGIN
    SELECT * FROM TaiKhoan
    WHERE TenTK = @TenTK AND MatKhau = @MatKhau;
END;

--InfoUser
CREATE PROC sp_InfoUser
	@TenTK NVARCHAR(50)
AS 
BEGIN
	SELECT tk.HoTen, tk.DiaChi, tk.SDT, tk.Email From TaiKhoan as tk where tk.TenTK=@TenTK
END
