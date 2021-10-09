create database QLKHACHSAN
go
use QLKHACHSAN
go
create table dichvu
(
	maDichVu int IDENTITY(1,1) NOT NULL,
	tenDichVu nvarchar(50) NULL,
	donGia float NULL,
	primary key(maDichVu)
)
/*bảng dịch vụ*/
INSERT dichvu  VALUES (N'giặt', 50000)
INSERT dichvu  VALUES (N'Thuê xe', 100000)

select * from dichvu
go
create table khachhang
(
	maKhachHang int IDENTITY(1,1) NOT NULL,
	tenKhachHang nvarchar(50) NULL,
	ngaySinh date NULL,
	gioiTinh bit NULL,
	chungMinhNhanDan nvarchar(13) NULL,
	diaChi nvarchar(50) NULL,
	soDienThoai nvarchar(10) NULL,
	quocTich nvarchar(50) NULL,
	primary key(maKhachHang)
)
/*bảng khách hàng*/
go
INSERT khachhang VALUES ( N'Nguyễn Đăng Khoa', CAST(N'1993-06-02' AS Date), 1, N'352514521', N'Mỹ Long, Long Xuyên', N'0979123123', N'Việt Nam')
INSERT khachhang VALUES ( N'Lê Công Hậu', CAST(N'1999-09-15' AS Date), 1, N'123099554', N'Thoại Sơn', N'9953254646', N'Việt Nam')
INSERT khachhang VALUES ( N'Trần Bảo Nguyên', CAST(N'1996-12-20' AS Date), 1, N'748991546', N'Hà Nội', N'0296546511', N'Nhật')
INSERT khachhang VALUES ( N'Trần Quốc Bảo', CAST(N'2000-11-24' AS Date), 1, N'149749494', N'Châu Đốc', N'0395453646', N'Việt Nam')
INSERT khachhang VALUES ( N'Trương Quốc Duy', CAST(N'2000-10-08' AS Date), 1, N'492374000', N'Cái Răng, Cần Thơ', N'0794928406', N'Việt Nam')
INSERT khachhang VALUES ( N'Lê Thị Ngọc Anh', CAST(N'1999-06-25' AS Date), 0, N'151053454', N'Bình Đức, Long Xuyên', N'0246221239', N'Việt Nam')
INSERT khachhang VALUES ( N'Nguyễn Gia Huy', CAST(N'1999-09-29' AS Date), 1, N'098321122', N'Mỹ Hiệp, Chợ Mới', N'0112222239', N'Việt Nam')
INSERT khachhang VALUES ( N'Trần Minh Đức', CAST(N'2000-06-21' AS Date), 1, N'192421241', N'Phú Tân, An Giang', N'0974286406', N'Việt Nam')
INSERT khachhang VALUES ( N'Thái Nhật Anh', CAST(N'2002-01-15' AS Date), 0, N'449911092', N'Châu Thành, An Giang', N'0792712213', N'Việt Nam')
INSERT khachhang VALUES ( N'Lê Anh Thư', CAST(N'1997-07-25' AS Date), 0, N'986421221', N'Kiến An, Chợ Mới', N'0395453646', N'Việt Nam')

select * from khachhang
go
create table nhanvien
(
	maNhanVien int IDENTITY(1,1) NOT NULL,
	hoTen nvarchar(50) NULL,
	gioiTinh bit NULL,
	ngaySinh date NULL,
	soChungMinh nvarchar(13) NULL,
	diaChi nvarchar(50) NULL,
	soDienThoai nvarchar(10) NULL,
	ngayVaoLam date NULL,
	primary key(maNhanVien)
)
/*bảng nhân viên */
go

INSERT nhanvien VALUES ( N'Hồ Thanh Thảo', 0, CAST(N'1997-02-01' AS Date), N'123456789', N'Thái Bình', N'0156546464', CAST(N'2020-06-04' AS Date))
INSERT nhanvien VALUES ( N'Hồ Chí Công', 1, CAST(N'1999-11-01' AS Date), N'178978212', N'Thới Bình, Cà Mau', N'0169266212', CAST(N'2020-09-01' AS Date))
INSERT nhanvien VALUES ( N'Trần Thị Ngọc Thơm', 0, CAST(N'1997-02-01' AS Date), N'167897882', N'Bình Phước Xuân, Chợ Mới', N'0156637832', CAST(N'2021-09-04' AS Date))
INSERT nhanvien VALUES ( N'Trần Quốc Đạt', 1, CAST(N'2000-07-16' AS Date), N'356211298', N'Mỹ Hiệp, Chợ Mới', N'0393592400', CAST(N'2020-02-09' AS Date))
go

select * from nhanvien
create table loaiphong
(
	loaiPhong nvarchar(20) NOT NULL,
	donGia float NULL,
	primary key(loaiPhong)
)
/*bảng loại phòng*/
go
INSERT loaiphong  VALUES (N'Phòng Thường', 300000)
INSERT loaiphong  VALUES (N'Phòng Trung', 350000)
INSERT loaiphong VALUES (N'Phòng Vip', 400000)

select * from loaiphong
go
create table phong
(
	maPhong int NOT NULL,
	tinhTrang bit NULL,
	loaiPhong nvarchar(20) NULL,
	primary key(maPhong)
)
/*bảng phòng*/
go
INSERT phong  VALUES (101, 0, N'Phòng Thường')
INSERT phong  VALUES (102, 1, N'Phòng Thường')
INSERT phong  VALUES (103, 0, N'Phòng Thường')
INSERT phong  VALUES (104, 1, N'Phòng Thường')
INSERT phong  VALUES (105, 0, N'Phòng Thường')
INSERT phong  VALUES (106, 1, N'Phòng Thường')
INSERT phong  VALUES (107, 0, N'Phòng Thường')
INSERT phong  VALUES (108, 1, N'Phòng Thường')
INSERT phong  VALUES (109, 0, N'Phòng Thường')
INSERT phong  VALUES (110, 0, N'Phòng Thường')

INSERT phong VALUES (201, 1, N'Phòng Trung')
INSERT phong VALUES (202, 0, N'Phòng Trung')
INSERT phong VALUES (203, 1, N'Phòng Trung')
INSERT phong VALUES (204, 0, N'Phòng Trung')
INSERT phong VALUES (205, 1, N'Phòng Trung')
INSERT phong VALUES (206, 0, N'Phòng Trung')
INSERT phong VALUES (207, 0, N'Phòng Trung')
INSERT phong VALUES (208, 0, N'Phòng Trung')
INSERT phong VALUES (209, 0, N'Phòng Trung')
INSERT phong VALUES (210, 0, N'Phòng Trung')


INSERT phong VALUES (301, 1, N'Phòng Vip')
INSERT phong VALUES (302, 1, N'Phòng Vip')
INSERT phong VALUES (303, 1, N'Phòng Vip')
INSERT phong VALUES (304, 0, N'Phòng Vip')
INSERT phong VALUES (305, 0, N'Phòng Vip')
INSERT phong VALUES (306, 0, N'Phòng Vip')
INSERT phong VALUES (307, 0, N'Phòng Vip')
INSERT phong VALUES (308, 0, N'Phòng Vip')
INSERT phong VALUES (309, 0, N'Phòng Vip')
INSERT phong VALUES (310, 0, N'Phòng Vip')

select * from phong
go
create table thuephong
(
	maThuePhong int IDENTITY(1,1) NOT NULL,
	maKhachHang int NULL,
	ngayDen date NULL,
	ngayDi date NULL,
	maDichVu int NULL,
	maPhong int NULL,
	thanhTien float NULL,
	primary key(maThuePhong)
)
/*bảng thuê phòng*/
go
INSERT thuephong VALUES ( 1, CAST(N'2020-12-25' AS Date), NULL, NULL, 102, NULL)
INSERT thuephong VALUES ( 3, CAST(N'2020-12-26' AS Date), NULL, NULL, 104, NULL)
INSERT thuephong VALUES ( 5, CAST(N'2020-12-27' AS Date), NULL, NULL, 106, NULL)
INSERT thuephong VALUES ( 9, CAST(N'2020-12-29' AS Date), NULL, NULL, 108, NULL)
INSERT thuephong VALUES ( 8, CAST(N'2020-12-22' AS Date), NULL, NULL, 201, NULL)
INSERT thuephong VALUES ( 7, CAST(N'2020-12-20' AS Date), NULL, NULL, 203, NULL)
INSERT thuephong VALUES ( 10, CAST(N'2020-12-21' AS Date), NULL, NULL, 301, NULL)
INSERT thuephong VALUES ( 6, CAST(N'2020-12-29' AS Date), NULL, NULL, 205, NULL)
INSERT thuephong VALUES ( 4, CAST(N'2020-12-11' AS Date), NULL, NULL, 303, NULL)
INSERT thuephong VALUES ( 2, CAST(N'2020-11-26' AS Date), NULL, NULL, 302, NULL)

select * from thuephong
go
create table nguoidung
(
	taiKhoan nvarchar(30) NOT NULL,
	matKhau nvarchar(30) NULL,
	phanQuyen nvarchar(20) NULL,
	maNhanVien int,
	primary key(taiKhoan)
)
/*bảng người dùng*/
go
INSERT nguoidung VALUES (N'trandat', N'12345', N'admin',4)
INSERT nguoidung VALUES (N'ngocthom', N'54321', N'user',3)
INSERT nguoidung VALUES (N'thaoga', N'113', N'user',1)
INSERT nguoidung VALUES (N'chicong', N'111', N'user',2)
select * from nguoidung

/*bảng hóa đơn*/
create table hoadon
(
	maHoaDon int identity(1,1),
	maKhachHang int,
	maNhanVien int,
	ngayLap date default(getdate()) not null,
	tongTien int null,
	primary key (maHoaDon)

)

select * from hoadon

/*Liên kết bảng */
go
ALTER TABLE phong  WITH CHECK ADD  CONSTRAINT FK_phong_loaiphong FOREIGN KEY(loaiPhong) REFERENCES loaiphong (loaiPhong)

ALTER TABLE thuephong  WITH CHECK ADD  CONSTRAINT FK_thuephong_dichvu FOREIGN KEY(maDichVu) REFERENCES dichvu (maDichVu)

ALTER TABLE thuephong  WITH CHECK ADD  CONSTRAINT FK_thuephong_khachhang FOREIGN KEY(maKhachHang) REFERENCES khachhang (maKhachHang)

ALTER TABLE thuephong  WITH CHECK ADD  CONSTRAINT FK_thuephong_phong FOREIGN KEY(maPhong) REFERENCES phong (maPhong)

ALTER TABLE hoadon  WITH CHECK ADD  CONSTRAINT FK_hoadon_khachhang FOREIGN KEY(maKhachHang) REFERENCES khachhang (maKhachHang)

ALTER TABLE hoadon  WITH CHECK ADD  CONSTRAINT FK_hoadon_nhanvien FOREIGN KEY(maNhanVien) REFERENCES nhanvien (maNhanVien)

ALTER TABLE nguoidung  WITH CHECK ADD  CONSTRAINT FK_nguoidung_nhanvien FOREIGN KEY(maNhanVien) REFERENCES nhanvien (maNhanVien)
go
/*StoredProcedure đăng nhập*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dangnhap 
	@acc nvarchar(30),
	@pass nvarchar(30)
AS
BEGIN
	SELECT count(*) 
	FROM [quanlykhachsan].[dbo].[nguoidung]
	 where taiKhoan=@acc and matKhau=@pass
END

GO
/******   StoredProcedure hiển thị thuê phòng ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[hienthi_thuetheophong]
AS
BEGIN
	
	select maThuePhong, a.maKhachHang, a.maPhong,tenKhachHang,ngaySinh,chungMinhNhanDan,diaChi,soDienThoai,ngayDen,donGia
from thuephong a,khachhang b,phong c,loaiphong d
where a.maKhachHang=b.maKhachHang and a.maPhong=c.maPhong and c.loaiPhong=d.loaiPhong and thanhTien is NULL
END


GO
/******   StoredProcedure hiển thị khách hàng  ******/
use QLKHACHSAN
select * from khachhang
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE hienthikhachhang

AS
BEGIN
	
	SELECT maKhachHang,tenKhachHang,ngaySinh,gioiTinh= 
	case when gioiTinh = 'True' then N'Nam' else N'Nữ' end,chungMinhNhanDan,diaChi,soDienThoai,quocTich
	FROM khachhang
END
GO
/****** StoredProcedure hiển thị phòng ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[hienthiphong] 
AS
BEGIN
select maPhong,a.loaiPhong,tinhTrang= case when tinhTrang='True' then N'Có Khách' else N'Trống' end,donGia
from phong a,loaiphong b
where a.loaiPhong=b.loaiPhong
END
GO
/******  StoredProcedure hiển thị nhân viên   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE hienthitatcanhanvien
AS
BEGIN

	SELECT maNhanVien,hoTen,gioiTinh= case when gioiTinh = 'true'  then N'Nam' else N'Nữ' end ,ngaySinh,soChungMinh,diaChi,soDienThoai,ngayVaoLam
	from [dbo].[nhanvien]
END

GO
/******  StoredProcedure Sửa khách hàng ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sua_khachhang
(
	@makhachhang int,
	@tenKhachHang nvarchar(50),
	@ngaySinh date,
	@gioiTinh bit,
	@chungMinhNhanDan nvarchar(13),
	@diaChi nvarchar(50),
	@soDienThoai nvarchar(10),
	@quocTich nvarchar(50)
	)
AS
BEGIN
update khachhang
set 
tenKhachHang=@tenKhachHang,
gioiTinh=@gioiTinh,
ngaySinh=@ngaySinh,
chungMinhNhanDan=@chungMinhNhanDan,
diaChi=@diaChi,
soDienThoai=@soDienThoai,
quocTich=@quocTich
where maKhachHang=@makhachhang
END


GO
/******   StoredProcedure Sửa nhân viên ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sua_nhanvien
	(
	@maNhanVien int,
	@hoTen nvarchar(50),
	@gioiTinh bit,
	@ngaySinh date,
	@soChungMinh nvarchar(13),
	@diaChi nvarchar(50),
	@soDienThoai nvarchar(10),
	@ngayVaoLam date
	)
AS
BEGIN
update [dbo].[nhanvien]
set 
hoTen=@hoTen,
gioiTinh=@gioiTinh,
ngaySinh=@ngaySinh,
soChungMinh=@soChungMinh,
diaChi=@diaChi,
soDienThoai=@soDienThoai,
ngayVaoLam=@ngayVaoLam
where maNhanVien=@maNhanVien
END


GO
/******   StoredProcedure Tìm kiếm thuê phòng******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE timkiem_thuephong
@maPhong int
AS
BEGIN
	
	select tenKhachHang,ngaySinh,chungMinhNhanDan,diaChi,soDienThoai,ngayDen
from thuephong a,khachhang b
where a.maKhachHang=b.maKhachHang and maPhong =@maPhong
END

GO
/******   StoredProcedure Tính tiền ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE tinhtien
(
@ngayDi date,
@thanhTien float,
@maThuePhong int,
@maPhong int
)
AS
BEGIN
BEGIN
	update thuephong
set ngayDi=@ngayDi,
thanhTien=@thanhTien
where maThuePhong=@maThuePhong
END
BEGIN
	update phong
set tinhTrang = 'False'
where maPhong=@maPhong
END
END
GO
/******   StoredProcedure Thêm khách hàng ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE them_khachhang
	(
	@tenKhachHang nvarchar(50),
	@ngaySinh date,
	@gioiTinh bit,
	@chungMinhNhanDan nvarchar(13),
	@diaChi nvarchar(50),
	@soDienThoai nvarchar(10),
	@quocTich nvarchar(50)
	)
AS
BEGIN
	
	insert into khachhang(tenKhachHang,ngaySinh,gioiTinh,chungMinhNhanDan,diaChi,soDienThoai,quocTich) 
	values (@tenKhachHang,@ngaySinh,@gioiTinh,@chungMinhNhanDan,@diaChi,@soDienThoai,@quocTich)
	return
END
GO
/******   StoredProcedure Thêm nhân viên ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE them_nhanvien
	(
	@hoTen nvarchar(50),
	@gioiTinh bit,
	@ngaySinh date,
	@soChungMinh nvarchar(13),
	@diaChi nvarchar(50),
	@soDienThoai nvarchar(10),
	@ngayVaoLam date
	)
AS
BEGIN
	
	insert into nhanvien(hoTen,gioiTinh,ngaySinh,soChungMinh,diaChi,soDienThoai,ngayVaoLam) 
	values (@hoTen,@gioiTinh,@ngaySinh,@soChungMinh,@diaChi,@soDienThoai,@ngayVaoLam)
	return
END

GO
/******   StoredProcedure Thêm thuê phòng ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE them_thuephong
(
	@maKhachHang int,
	@ngayDen date,
	@maPhong int
)
AS
BEGIN
	BEGIN
	insert into thuephong(maKhachHang,ngayDen,maPhong)
	values(@maKhachHang,@ngayDen,@maPhong)
	END
	BEGIN
	update phong
	set tinhTrang='True'
	where maPhong =@maPhong
	END
END

GO
/******   StoredProcedure Xóa khách hàng******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE xoa_khachhang
@maKhachHang int
AS
BEGIN
	DELETE 
	FROM khachhang
	 WHERE maKhachHang= @maKhachHang
END

GO
/******   StoredProcedure Xóa nhân viên******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE xoa_nhanvien
@maNhanVien int
AS
BEGIN
	DELETE FROM nhanvien WHERE maNhanVien=@maNhanVien
END

/******   StoredProcedure Thêm người dùng ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE them_nguoidung
	(
	@taiKhoan nvarchar(30),
	@matKhau nvarchar(30),
	@phanQuyen nvarchar(20),
	@maNhanVien int
	)
AS
BEGIN
	
	insert into nguoidung(taiKhoan,matKhau,phanQuyen,maNhanVien) 
	values (@taiKhoan,@matKhau,@phanQuyen,@maNhanVien)
	return
END

GO



/******   StoredProcedure Xóa người dùng******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE xoa_nguoidung
@taiKhoan nvarchar(30)
AS
BEGIN
	DELETE FROM nguoidung WHERE taiKhoan=@taiKhoan
END


select  hd.maHoaDon, tp.maPhong, kh.maKhachHang, kh.tenKhachHang, kh.chungMinhNhanDan, kh.soDienThoai, kh.quocTich, tp.ngayDen, tp.ngayDi, nv.maNhanVien
from dbo.hoadon as hd 
inner join dbo.khachhang as kh on kh.maKhachHang = hd.maKhachHang
inner join dbo.NhanVien as nv on nv.maNhanVien = hd.maNhanVien
inner join dbo.thuephong as tp on tp.maKhachHang = kh.maKhachHang

select * from dbo.nhanvien nv where nv.maNhanVien = 4

/*** Tổng số lượt khách hàng thuê trong tháng ***/
select * from dbo.thuePhong tp where MONTH(tp.ngayDi) = 5 AND YEAR(tp.ngayDi) = 2021