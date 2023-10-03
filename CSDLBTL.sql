CREATE DATABASE CSDLBTL
GO

USE CSDLBTL
GO

--Tạo bảng Loại tài khoản
CREATE TABLE LoaiTK (
	MaLoaiTK NCHAR(10) PRIMARY KEY,
	TenLoaiTK NVARCHAR(20)
)
GO

--Tạo bảng Tài Khoản
CREATE TABLE TaiKhoan (
	TenTK NVARCHAR(50) PRIMARY KEY,
	MatKhau NVARCHAR(50) NOT NULL,
	Email NVARCHAR(100),
	MaLoaiTK NCHAR(10),
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
    MaLoai  NCHAR(10) PRIMARY KEY,
    TenLoai NVARCHAR(50) NOT NULL
)
GO

-- Tạo bảng Sản phẩm 
CREATE TABLE SanPham (
    MaSP  NCHAR(10) PRIMARY KEY,
    TenSP NVARCHAR(50) NOT NULL,
	Size CHAR(5) NOT NULL,
	GiaBan FLOAT NOT NULL,
	GiaGiam FLOAT,
    MaLoai  NCHAR(10),
    SoLuongTon INT DEFAULT 0,
	SoLuongBan INT DEFAULT 0,
	ImageURL NVARCHAR(250),
	Mota NVARCHAR(250),
	TrangThai NVARCHAR(50),
    FOREIGN KEY (MaLoai) REFERENCES dbo.TheLoai(MaLoai) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

-- Tạo bảng Nhà cung cấp 
CREATE TABLE NhaCungCap (
    MaNCC  NCHAR(10) PRIMARY KEY,
    TenNCC NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(100),
    SoDienThoai VARCHAR(10),
	Email VARCHAR(100)
)
GO

---Tạo bảng Khách hàng
CREATE TABLE KhachHang (
    MaKH NCHAR(10) PRIMARY KEY,
	TenKH NVARCHAR(30) NOT NULL,
	GioiTinh NVARCHAR(5),
	NgaySinh DATE,
	Diachi NVARCHAR(50),
	Email NVARCHAR(100), 
	SDT VARCHAR(10)
)
GO

-- Tạo bảng Hóa đơn nhập
CREATE TABLE HoaDonNhap (
    MaHDN NCHAR(10) PRIMARY KEY ,
    NgayNhap DATE NOT NULL,
    MaNCC NCHAR(10),
	TenTK NVARCHAR(50), 
	GhiChu NVARCHAR(50)
    FOREIGN KEY (MaNCC) REFERENCES dbo.NhaCungCap(MaNCC) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (TenTK) REFERENCES dbo.TaiKhoan(TenTK) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

-- Tạo bảng Chi tiết hóa đơn nhập 
CREATE TABLE ChiTietHoaDonNhap(
    MaChiTietHDN NCHAR(10) PRIMARY KEY,
    MaHDN NCHAR(10),
    MaSP NCHAR(10),
    SoLuong INT,
    GiaNhap FLOAT,
	TongTien FLOAT
    FOREIGN KEY (MaHDN) REFERENCES dbo.HoaDonNhap(MaHDN) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES dbo.SanPham(MaSP) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

-- Tạo bảng Hóa đơn bán
CREATE TABLE HoaDonBan (
    MaHDB NCHAR(10) PRIMARY KEY,
    TrangThai BIT,
    NgayTao DATETIME,
    NgayDuyet DATETIME,   
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
    MaChiTietHDB NCHAR(10) PRIMARY KEY,
    MaHDB  NCHAR(10),
    MaSP NCHAR(10),
    SoLuong INT,
    GiaBan FLOAT,
	TongTien FLOAT,
    FOREIGN KEY (MaHDB) REFERENCES dbo.HoaDonBan(MaHDB) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES dbo.SanPham(MaSP) ON DELETE CASCADE ON UPDATE CASCADE
)
GO


---------------CHÈN DỮ LIỆU-------------------
--Chèn dữ liệu vào bảng loại tài khoản
INSERT INTO LoaiTK(MaLoaiTK, TenLoaiTK)
VALUES
('MLTK01', N'Khách Hàng'),   
('MLTK02',N'Admin')
GO

--Chèn dữ liệu vào bảng tài khoản
INSERT INTO TaiKhoan (TenTK, MatKhau, Email, MaLoaiTK, HoTen, DiaChi, SDT, Avatar, Token)
VALUES
('quangne2003', 'quang203', 'quang2003@gmail.com', 'MLTK01', N'Lê Văn Quảng', N'Hưng Yên', '0987654321', null, null),
('admin', 'admin', 'admin01@gmail.com', 'MLTK02', N'Admin Quảng', N'Hưng Yên', '0123456789', null, null)

-- Chèn dữ liệu vào bảng LoaiHang
INSERT INTO TheLoai (MaLoai, TenLoai)
VALUES
('ML01', N'Áo dài tay'),
('ML02', N'Đầm'),
('ML03', N'Quần dài'),
('ML04', N'Set Combo'),
('ML05', N'Váy'),
('ML06', N'Áo sơ mi'),
('ML07', N'Áo cộc tay'),
('ML08', N'Quần short'),
('ML09', N'Áo đá bóng'),
('ML10', N'Áo bảo hộ')

-- Chèn dữ liệu vào bảng SanPham
INSERT INTO dbo.SanPham(MaSP, TenSP, Size, GiaBan, GiaGiam, MaLoai, SoLuongTon, SoLuongBan, ImageURL, Mota, TrangThai)
VALUES
('SP01', N'SAND - BAD UNIFORM TEE','M', 300000, 100000, 'ML01',20, 10, null, null, 'còn hàng'),
('SP02', N'GREY - BAD UNIFORM TEE', 'L', 500000, 100000, 'ML02',20, 10, null, null, 'còn hàng'),
('SP03', N'ACID KAKI PANTS', 'XL', 700000, 100000, 'ML03',20, 10, null, null, 'hết hàng'),
('SP04', N'FALLEN ANGEL TEE', 'M', 750000, 100000, 'ML04',20, 10, null, null, 'hết hàng'),
('SP05', N'MOUNTAIN SHORT OLIVE', 'L', 600000, 100000, 'ML05',20, 10, null, null, 'còn hàng'),
('SP06', N'GREY DESTROYED SWEAT SHORT', 'M', 500000, 100000, 'ML06',20, 10, null, null, 'còn hàng'),
('SP07', N'BASIC TEE - WHITE', 'M', 400000, 100000, 'ML07',20, 10, null, null, 'hết hàng'),
('SP08', N'BAD LOVER TEE', 'L', 300000, 100000, 'ML08',20, 10, null, null, 'còn hàng'),
('SP09', N'BASIC TEE - MOCA', 'XL', 450000, 100000, 'ML09',20, 10, null, null, 'hết hàng'),
('SP10', N'KING CARD SHIRT', 'XL', 650000, 100000, 'ML10',20, 10, null, null, 'còn hàng')

-- Chèn dữ liệu vào bảng NhaCungCap
INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SoDienThoai, Email)
VALUES
('NCC01', N'Huy Dior', N'Hà Nội', '0123456789', 'huy01@gmail.com'),
('NCC02', N'Hưng Gucci', N'Hồ Chí Minh', '0123456789', 'hung02@gmail.com'),
('NCC03', N'Hoàng Chanel', N'Đà Nẵng', '0123456789', 'hoang03@gmail.com'),
('NCC04', N'Quảng YSL', N'Nha Trang', '0123456789', 'quang04@gmail.com'),
('NCC05', N'Tùng Versace', N'Huế', '0123456789', 'tung05@gmail.com'),
('NCC06', N'Minh Tom Ford', N'Đồng Nai', '0123456789', 'minh06@gmail.com'),
('NCC07', N'Kiên Paco Rabanne', N'Hải Phòng', '0123456789', 'kien07@gmail.com'),
('NCC08', N'Thắng Givenchy', N'Bình Dương', '0123456789', 'thang08@gmail.com'),
('NCC09', N'Quốc Bvlgari', N'Cần Thơ', '0123456789', 'quoc09@gmail.com'),
('NCC10', N'Quyến Hermes', N'Vũng Tàu', '0123456789', 'quyen10@gmail.com')

-- Chèn dữ liệu vào bảng KhachHang
INSERT INTO KhachHang (MaKH, TenKH, GioiTinh, NgaySinh, Diachi, Email, SDT)
VALUES
(N'KH001', N'Nguyễn Thi Xuân Mai', N'Nữ', '2004-12-24', N'Hưng Yên', N'nguyenthixuanmai@gmail.com', N'0123456789'),
(N'KH002', N'Trần Kim Long', N'Nam', '2003-09-05', N'Hưng Yên', N'trankimlong@gmail.com', N'0123456788'),
(N'KH003', N'Dương Kim Linh', N'Nữ', '1999-12-12', N'Hà Nội', N'duongkimlinh@gmail.com', N'0123456778'),
(N'KH004', N'Đặng Thanh Sơn', N'Nam', '2003-05-13', N'Hải Dương', N'dangthanhson@gmail.com', N'0123456678'),
(N'KH005', N'Đỗ Tuấn Dương', N'Nam', '1999-02-16', N'Hà Nam', N'dotuanduong@gmail.com', N'0123455678'),
(N'KH006', N'Lê Đức Mạnh', N'Nam', '2003-06-22', N'Hưng Yên', N'leducmanh@gmail.com', N'0123445678'),
(N'KH007', N'Lê Thị Thanh Thảo', N'Nữ', '2003-04-25', N'Hà Nội', N'lethithanhthao@gmail.com', N'0123345678'),
(N'KH008', N'Đỗ Thị Tuyết', N'Nữ', '2001-08-12', N'Hà Nội', N'dothituyet@gmail.com', N'0122345678'),
(N'KH009', N'Võ Thanh Mai', N'Nữ', '2001-06-29', N'Hà Nam', N'vothanhmai@gmail.com', N'0112345678'),
(N'KH010', N'Nguyễn Bình Minh', N'Nam', '2000-08-09', N'Hải Dương', N'nguyenbinhminh@gmail.com', N'0123456798')

-- Chèn dữ liệu vào bảng HoaDonNhap
INSERT INTO HoaDonNhap (MaHDN, NgayNhap, MaNCC, TenTK, GhiChu)
VALUES
('HDN01', '2023-01-05', 'NCC01', 'quangne2003', null),
('HDN02', '2023-02-10', 'NCC02', 'quangne2003', null),
('HDN03', '2023-03-15', 'NCC03', 'quangne2003', null),
('HDN04', '2023-04-20', 'NCC04', 'quangne2003', null),
('HDN05', '2023-05-25', 'NCC05', 'quangne2003', null),
('HDN06', '2023-06-30', 'NCC06', 'quangne2003', null),
('HDN07', '2023-07-05', 'NCC07', 'admin', null),
('HDN08', '2023-08-10', 'NCC08', 'admin', null),
('HDN09', '2023-09-15', 'NCC09', 'admin', null),
('HDN10', '2023-10-20', 'NCC10', 'admin', null),
('HDN12', '2023-10-20', 'NCC03', 'admin', null)

-- Chèn dữ liệu vào bảng ChiTietHoaDonNhap
INSERT INTO ChiTietHoaDonNhap (MaChiTietHDN, MaHDN, MaSP, SoLuong, GiaNhap, TongTien)
VALUES
('CTHDN01', 'HDN01', 'SP01', 2, 2400000, 800000),
('CTHDN02', 'HDN02', 'SP02', 3, 2500000, 800000),
('CTHDN03', 'HDN03', 'SP03', 4, 3000000, 800000),
('CTHDN04', 'HDN04', 'SP04', 5, 3500000, 800000),
('CTHDN05', 'HDN05', 'SP05', 6, 4000000, 800000),
('CTHDN06', 'HDN06', 'SP06', 7, 4500000, 800000),
('CTHDN07', 'HDN07', 'SP07', 8, 5000000, 800000),
('CTHDN08', 'HDN08', 'SP08', 9, 5500000, 800000),
('CTHDN09', 'HDN09', 'SP09', 10, 6000000, 800000),
('CTHDN10', 'HDN10', 'SP10', 11, 6500000, 800000),
('CTHDN12', 'HDN12', 'SP04', 11, 6500000, 800000)

-- Chèn dữ liệu vào bảng HoaDonBan
INSERT INTO HoaDonBan (MaHDB, TrangThai, NgayTao, NgayDuyet, TenKH, DiaChi, Email, SDT, DiaChiGiaoHang, ThoiGianGiaoHang)
VALUES
('HDB01', 1, '2023-03-01', '2023-03-02', N'Nguyễn Thi Xuân Mai', N'Hưng Yên', N'nguyenthixuanmai@gmail.com', N'123456789', N'Địa chỉ giao hàng 1', '2023-03-03'),
('HDB02', 1, '2023-03-01', '2023-03-02', N'Trần Kim Long', N'Hưng Yên', N'trankimlong@gmail.com', N'123456789', N'Địa chỉ giao hàng 2', '2023-03-03')

-- Chèn dữ liệu vào bảng ChiTietHoaDonBan
INSERT INTO ChiTietHoaDonBan (MaChiTietHDB, MaHDB, MaSP, SoLuong, GiaBan)
VALUES
('CTHDB01', 'HDB01', 'SP01', 2, 2400000),
('CTHDB02', 'HDB02', 'SP02', 3, 2500000),
('CTHDB03', 'HDB01', 'SP03', 4, 2500000),
('CTHDB04', 'HDB02', 'SP04', 5, 3500000),
('CTHDB05', 'HDB01', 'SP05', 6, 4000000),
('CTHDB06', 'HDB02', 'SP06', 7, 4500000),
('CTHDB07', 'HDB01', 'SP07', 8, 5000000),
('CTHDB08', 'HDB02', 'SP08', 9, 6000000),
('CTHDB09', 'HDB01', 'SP09', 10, 6500000),
('CTHDB10', 'HDB02', 'SP10', 11, 7000000)

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
CREATE PROCEDURE [dbo].[sp_khachhang_create]
(	
	@MaKH VARCHAR(10),
	@TenKH NVARCHAR(30),
	@GioiTinh NVARCHAR(5),
	@NgaySinh date,
	@Diachi VARCHAR(30),
	@Email VARCHAR(50), 
	@SDT char(10)
)
AS 
BEGIN
INSERT INTO KhachHang(MaKH,TenKH,GioiTinh,NgaySinh,DiaChi,Email,SDT) VALUES (@MaKH,@TenKH,@GioiTinh,@NgaySinh,@DiaChi,@Email,@SDT)
END

-----Tìm kiếm khách hàng theo mã
CREATE PROCEDURE [dbo].[sp_searchKH_by_MaNV]
	@MaKH VARCHAR(10)
AS
BEGIN
	SELECT * FROM KhachHang AS KH WHERE KH.MaKH=@MaKH
END

--Cập nhật thông tin khach hang
CREATE PROC [dbo].[sp_khachhang_update]
	@MaKH VARCHAR(10),
	@TenKH NVARCHAR(30),
	@GioiTinh NVARCHAR(5),
	@NgaySinh date,
	@Diachi VARCHAR(30),
	@Email VARCHAR(50), 
	@SDT char(10)
AS
BEGIN
	UPDATE KhachHang SET MaKH=@MaKH, TenKH=@TenKH, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh, Diachi=@Diachi, Email=@Email, SDT=@SDT WHERE MaKH=@MaKH
END

--Xóa khách hàng theo mã
CREATE PROC [dbo].[sp_DeleteKH]	
	@MaKH VARCHAR(10)
AS
BEGIN 
	DELETE KhachHang WHERE @MaKH=MaKH
END


 -------------------NHÀ CUNG CẤP---------------------
 ---Thủ tục thêm nhà cung cấp
CREATE PROC sp_nhacungcap_create 
 @MaNCC NCHAR(10),
 @TenNCC NVARCHAR(50),
 @DiaChi NVARCHAR(100),
 @SoDienthoai NVARCHAR(15),
 @Email VARCHAR(100)
AS
BEGIN
	INSERT INTO NhaCungCap(MaNCC, TenNCC, DiaChi, SoDienThoai, Email) VALUES (@MaNCC,@TenNCC,@DiaChi,@SoDienthoai,@Email)
END

 -----Tìm kiếm nhà cung cấp theo Mã NCC
CREATE PROC sp_searchNCC_by_MaNCC
 @MaNCC NCHAR(10)
AS
BEGIN 
 SELECT * FROM NhaCungCap AS ncc WHERE ncc.MaNCC=@MaNCC
END

 ----Cập nhật thông tin Nhà cung cấp
CREATE PROC sp_nhacungcap_update
 @MaNCC NCHAR(10),
 @TenNCC NVARCHAR(50),
 @DiaChi NVARCHAR(100),
 @SoDienthoai NVARCHAR(15),
 @Email NCHAR(100)
AS
BEGIN
	UPDATE NhaCungCap SET TenNCC=@TenNCC,DiaChi=@DiaChi,SoDienThoai=@SoDienthoai,Email=@Email WHERE MaNCC=@MaNCC
END
 
 ----Xóa Nhà cung cấp theo mã 
CREATE PROC sp_DeleteNCC
 @MaNCC NCHAR(10)
AS
BEGIN 
 DELETE NhaCungCap WHERE @MaNCC=MaNCC
END

 -----------------------THỂ LOẠI---------------------
 ---Thủ tục thêm thể loại
CREATE PROC sp_ThemTL 
 @MaLoai NCHAR(10),
 @TenLoai NVARCHAR(50)
AS
BEGIN
	INSERT INTO TheLoai(MaLoai, TenLoai) VALUES (@MaLoai,@TenLoai)
END

 -----Tìm kiếm thể loại theo Mã Loại
CREATE PROC sp_TimKiemTL
 @MaLoai NCHAR(10)
AS
BEGIN 
 SELECT * FROM TheLoai AS tl WHERE tl.MaLoai=@MaLoai
END

 ----Cập nhật thông tin Thể loại
CREATE PROC sp_SuaTL
 @MaLoai NCHAR(10),
 @TenLoai NVARCHAR(50)
AS
BEGIN
	UPDATE TheLoai SET TenLoai=@TenLoai WHERE MaLoai= @MaLoai
END
 
 ----Xóa Thể loại theo mã 
CREATE PROC sp_XoaTL
 @MaLoai NCHAR(10)
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
	@MaLoaiTK NCHAR(10),
    @HoTen NVARCHAR(50),
    @DiaChi NVARCHAR(250),
    @SDT VARCHAR(10),
    @Avatar NVARCHAR(500),
    @Token NVARCHAR(500)
AS
BEGIN
    UPDATE TaiKhoan
    SET Email = @Email, MaLoaiTK = @MaLoaiTK, HoTen = @HoTen, DiaChi = @DiaChi, SDT = @SDT, Avatar = @Avatar, Token = @Token
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
