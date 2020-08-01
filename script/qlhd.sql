USE [master]
GO
/****** Object:  Database [qlhd]    Script Date: 7/27/2020 3:41:29 PM ******/
CREATE DATABASE [qlhd]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'qlhd', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\qlhd.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'qlhd_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\qlhd_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [qlhd] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [qlhd].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [qlhd] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [qlhd] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [qlhd] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [qlhd] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [qlhd] SET ARITHABORT OFF 
GO
ALTER DATABASE [qlhd] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [qlhd] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [qlhd] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [qlhd] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [qlhd] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [qlhd] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [qlhd] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [qlhd] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [qlhd] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [qlhd] SET  ENABLE_BROKER 
GO
ALTER DATABASE [qlhd] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [qlhd] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [qlhd] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [qlhd] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [qlhd] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [qlhd] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [qlhd] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [qlhd] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [qlhd] SET  MULTI_USER 
GO
ALTER DATABASE [qlhd] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [qlhd] SET DB_CHAINING OFF 
GO
ALTER DATABASE [qlhd] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [qlhd] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [qlhd] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [qlhd] SET QUERY_STORE = OFF
GO
USE [qlhd]
GO
/****** Object:  UserDefinedTableType [dbo].[GheLocation]    Script Date: 7/27/2020 3:41:29 PM ******/
CREATE TYPE [dbo].[GheLocation] AS TABLE(
	[id] [varchar](10) NULL,
	[LX] [int] NULL,
	[LY] [int] NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[DangNhap]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[DangNhap]
(
   @username varchar(50),
   @password varchar(50)
)
returns int
as
begin
  declare @check int
  select @check=count(*) from UserQl where username=@username and passw=@password
  if(@check>0)
     return 1
  return 0
end
GO
/****** Object:  UserDefinedFunction [dbo].[fcgetIdGhe]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[fcgetIdGhe]()
		returns varchar(10)
		
		
		As
		Begin
			Declare @IdBan varchar(10)
			Declare @MaxIdBan varchar(10)
			Declare @Max float
			
			
			Select @MaxIdBan=Max(CONVERT(float, SUBSTRING(id,4,3))) from Ghe
			if exists (select id from Ghe)
						set @Max = @MaxIdBan + 1
						
			else
						set @Max=1	
			if (@Max < 10)
						set @IdBan ='Ghe' + '00' + Convert(varchar(1),@Max)
			if (@Max < 100)
						set @IdBan='Ghe' + '0' + Convert(varchar(2),@Max)
			else 
			            set @IdBan='Ghe' + Convert(varchar(3),@Max)

			Return @IdBan
	End
GO
/****** Object:  UserDefinedFunction [dbo].[Ftimbenh]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Ftimbenh]
(@ten nvarchar(50))
returns int 
begin
  declare @rs int
  select @rs=count(*) from SucKhoe a,(select id,dbo.GetUnsignString(tenbenh) as tb from SucKhoe) b  where a.id=b.id and b.tb like '%'+@ten+'%' 
  return @rs
end
GO
/****** Object:  UserDefinedFunction [dbo].[Ftimho]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Ftimho]
(@ten nvarchar(50))
returns int 
begin
  declare @rs int
  select @rs=count(*) from KhachHang a,(select id,dbo.GetUnsignString(ho) as ho from KhachHang) b  where a.id=b.id and b.ho like '%'+@ten+'%' 
  return @rs
end
GO
/****** Object:  UserDefinedFunction [dbo].[Ftimtatca]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE function [dbo].[Ftimtatca](@string nvarchar(50))
returns int
as
begin
  declare @ct int
  select @ct=count(*) from KhachHang a,(select id,dbo.GetUnsignString(ten+' '+ho+' '+sdt) as infor from KhachHang) b  where a.id=b.id and b.infor like N'%'+@string+'%'
  return @ct
end
GO
/****** Object:  UserDefinedFunction [dbo].[Ftimten]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Ftimten]
(@ten nvarchar(50))
returns int
as 
begin
  declare @rs int
  select @rs=count(*) from KhachHang a,(select id,dbo.GetUnsignString(ten) as ten from KhachHang) b  where a.id=b.id and b.ten like '%'+@ten+'%' 
  return @rs
end
GO
/****** Object:  UserDefinedFunction [dbo].[generateKHId]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[generateKHId]
()
returns varchar(10)
As
		Begin
			Declare @IdKH varchar(10)
			Declare @MaxIdKH varchar(10)
			Declare @Max float
			
			
			Select @MaxIdKH=Max(CONVERT(float, SUBSTRING(id,3,7))) from KhachHang
			if exists (select id from KhachHang)
						set @Max = @MaxIdKH + 1
						
			else
						set @Max=1	
			if (@Max < 10)
						set @IdKH = 'KH' + '000000' + Convert(varchar(1),@Max)
			else if (@Max < 100)
						set @IdKH= 'KH' + '000000' + Convert(varchar(2),@Max)
			else if (@Max < 1000)
			            set @IdKH= 'KH' + '00000'+ Convert(varchar(3),@Max)
			else if (@Max < 10000)
			            set @IdKH= 'KH' + '0000'+ Convert(varchar(4),@Max)
			else if (@Max < 100000)
			            set @IdKH= 'KH' + '000'+ Convert(varchar(5),@Max)
			else if (@Max < 1000000)
			            set @IdKH= 'KH' + '00'+ Convert(varchar(6),@Max)
            else if (@Max < 10000000)
			            set @IdKH= 'KH'+'0'+ Convert(varchar(7),@Max)
			else if (@Max < 100000000)
			            set @IdKH= 'KH'+ Convert(varchar(8),@Max)
			Return @IdKH
	End
GO
/****** Object:  UserDefinedFunction [dbo].[getAllDayinWeek]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[getAllDayinWeek] 
(
  @date datetime
)
returns @rtb table
(
   ngay datetime
)
as
begin
    DECLARE @dayofWeek TABLE (ngay datetime)
	Declare @noalldow int=7
	Declare @firstDayofWeek datetime 
	select @firstDayofWeek= dbo.getFirstDayofWeek(@date)
	DECLARE @i INT = 0;
    while @i<@noalldow
	begin
	   insert into @dayofWeek(ngay) values (DATEADD(DAY,@i,@firstDayofWeek))
	   set @i=@i+1
	end
	insert into @rtb
	select * from @dayofWeek
	return
end
GO
/****** Object:  UserDefinedFunction [dbo].[getFirstDayofWeek]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[getFirstDayofWeek] 
(
  @date datetime
)
returns datetime
as
begin
    declare @rs datetime
    select @rs=DATEADD(DAY,-(DATEPART(dw,@date)-1),@date) 
	return @rs
end
GO
/****** Object:  UserDefinedFunction [dbo].[GetNumberofWeek]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[GetNumberofWeek]
(
 @user int 
)
returns int
as
begin
   declare @now int
   declare @min datetime
   declare @max datetime
   select @min=Min(thoigianbatdau),@max=Max(thoigianbatdau) from History a , Ghe b where a.idghe=b.id and b.quanli=@user
   declare @fdowmin datetime 
   select @fdowmin=dbo.getFirstDayofWeek(@min)
   declare @fdowmax datetime 
   select @fdowmax=dbo.getFirstDayofWeek(@max)
   select @now = DATEDIFF(day, @fdowmin, @fdowmax)/7 
   return @now +1
end
GO
/****** Object:  UserDefinedFunction [dbo].[getTimebD]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[getTimebD](@idghe varchar(10))
returns datetime
as
begin
 declare @dt datetime
 select @dt=thoigian from HoatDong where idghe=@idghe
 return @dt
end
GO
/****** Object:  UserDefinedFunction [dbo].[GetUnsignString]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetUnsignString]
(
@strInput nvarchar(4000)
)
RETURNS nvarchar(4000)
AS
BEGIN
IF @strInput IS NULL
BEGIN
RETURN @strInput
END;
IF @strInput = ''
BEGIN
RETURN @strInput
END;
DECLARE @RT nvarchar(4000);
DECLARE @SIGN_CHARS nchar(136);
DECLARE @UNSIGN_CHARS nchar(136);
SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ'+NCHAR(272)+NCHAR(208);
SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD';
DECLARE @COUNTER int;
DECLARE @COUNTER1 int;
SET @COUNTER = 1;
WHILE(@COUNTER <= LEN(@strInput))
BEGIN
SET @COUNTER1 = 1;
WHILE(@COUNTER1 <= LEN(@SIGN_CHARS) + 1)
BEGIN
IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1, 1)) = UNICODE(SUBSTRING(@strInput, @COUNTER, 1))
BEGIN
IF @COUNTER = 1
BEGIN
SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1, 1) + SUBSTRING(@strInput, @COUNTER+1, LEN(@strInput)-1);
END
ELSE
BEGIN
SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) + SUBSTRING(@UNSIGN_CHARS, @COUNTER1, 1) + SUBSTRING(@strInput, @COUNTER+1, LEN(@strInput)-@COUNTER);
END;
BREAK;
END;
SET @COUNTER1 = @COUNTER1 + 1;
END;
SET @COUNTER = @COUNTER + 1;
END;
RETURN @strInput;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[XacDinhTrangThai]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[XacDinhTrangThai]
(
   @idghe varchar(10)
)
returns int
as
begin
  declare @ct int
  select @ct=count(*) from HoatDong where idghe=@idghe
  return @ct 
end
GO
/****** Object:  Table [dbo].[Ghe]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ghe](
	[id] [varchar](10) NOT NULL,
	[tinhtrang] [varchar](50) NULL,
	[LX] [int] NULL,
	[LY] [int] NULL,
	[quanli] [int] NULL,
	[tenban] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[History]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idghe] [varchar](10) NOT NULL,
	[idkh] [varchar](10) NOT NULL,
	[thoigianbatdau] [datetime] NOT NULL,
	[thoigianhoatdong] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoatDong]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoatDong](
	[idghe] [varchar](10) NULL,
	[idkh] [varchar](10) NULL,
	[thoigian] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[id] [varchar](10) NOT NULL,
	[ho] [nvarchar](500) NULL,
	[ten] [nvarchar](20) NULL,
	[sdt] [varchar](15) NULL,
	[email] [varchar](100) NULL,
	[diachi] [nvarchar](1000) NULL,
	[ngaysinh] [varchar](20) NULL,
	[CreateAt] [datetime] NULL,
	[loaikhachhang] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiKH]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiKH](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenloai] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SucKhoe]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SucKhoe](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenbenh] [nvarchar](200) NULL,
	[CreateAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SucKhoeKhachHang]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SucKhoeKhachHang](
	[idkh] [varchar](10) NULL,
	[idbenh] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserQl]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserQl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[passw] [varchar](50) NULL,
	[logincode] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Ghe] ([id], [tinhtrang], [LX], [LY], [quanli], [tenban]) VALUES (N'Ghe01', N'hoatdong', 68, 46, 2, N'Ghế 1')
INSERT [dbo].[Ghe] ([id], [tinhtrang], [LX], [LY], [quanli], [tenban]) VALUES (N'Ghe02', N'hoatdong', 218, 48, 2, N'Ghế 2')
INSERT [dbo].[Ghe] ([id], [tinhtrang], [LX], [LY], [quanli], [tenban]) VALUES (N'Ghe03', N'baotri', 133, 196, 2, N'Ghế 3')
INSERT [dbo].[Ghe] ([id], [tinhtrang], [LX], [LY], [quanli], [tenban]) VALUES (N'Ghe04', N'baotri', 49, 38, 3, N'Ghế 1')
INSERT [dbo].[Ghe] ([id], [tinhtrang], [LX], [LY], [quanli], [tenban]) VALUES (N'Ghe05', N'hoatdong', 205, 73, 3, N'Ghế 2')
INSERT [dbo].[Ghe] ([id], [tinhtrang], [LX], [LY], [quanli], [tenban]) VALUES (N'Ghe06', N'hoatdong', 61, 191, 3, N'Ghế 3')
INSERT [dbo].[Ghe] ([id], [tinhtrang], [LX], [LY], [quanli], [tenban]) VALUES (N'Ghe07', N'hoatdong', 210, 231, 3, N'Ghế 4')
INSERT [dbo].[Ghe] ([id], [tinhtrang], [LX], [LY], [quanli], [tenban]) VALUES (N'Ghe08', N'hoatdong', 325, 220, 2, N'Ghế 4')
GO
SET IDENTITY_INSERT [dbo].[History] ON 

INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1, N'Ghe02', N'KH0000005', CAST(N'2020-07-24T17:34:15.490' AS DateTime), 166)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (2, N'Ghe01', N'KH0000002', CAST(N'2020-07-24T17:35:08.363' AS DateTime), 116)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1002, N'Ghe02', N'KH0000005', CAST(N'2020-07-24T22:45:45.943' AS DateTime), 1800)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1003, N'Ghe02', N'KH0000005', CAST(N'2020-07-24T22:48:16.053' AS DateTime), 1800)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1004, N'Ghe01', N'KH0000005', CAST(N'2020-07-24T22:55:27.067' AS DateTime), 1800)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1005, N'Ghe02', N'KH0000005', CAST(N'2020-07-24T22:56:36.543' AS DateTime), 1800)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1006, N'Ghe02', N'KH0000005', CAST(N'2020-07-24T23:40:21.973' AS DateTime), 1800)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1007, N'Ghe02', N'KH0000005', CAST(N'2020-07-26T13:45:50.940' AS DateTime), 1796)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1008, N'Ghe01', N'KH0000004', CAST(N'2020-07-27T13:46:26.020' AS DateTime), 1800)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1009, N'Ghe02', N'KH0000003', CAST(N'2020-07-27T13:46:37.563' AS DateTime), 1800)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1010, N'Ghe01', N'KH0000002', CAST(N'2020-07-27T13:46:50.067' AS DateTime), 1798)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1011, N'Ghe01', N'KH0000004', CAST(N'2020-07-28T13:47:12.937' AS DateTime), 1795)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1012, N'Ghe01', N'KH0000003', CAST(N'2020-08-09T13:47:30.663' AS DateTime), 1798)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1013, N'Ghe02', N'KH0000002', CAST(N'2020-08-09T13:47:35.230' AS DateTime), 1796)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1014, N'Ghe05', N'KH0000005', CAST(N'2020-07-26T15:41:52.660' AS DateTime), 1794)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1015, N'Ghe06', N'KH0000003', CAST(N'2020-07-26T15:42:01.570' AS DateTime), 1795)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1016, N'Ghe05', N'KH0000005', CAST(N'2020-07-26T16:07:47.703' AS DateTime), 1800)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1017, N'Ghe05', N'KH0000003', CAST(N'2020-07-26T16:08:06.893' AS DateTime), 1800)
INSERT [dbo].[History] ([id], [idghe], [idkh], [thoigianbatdau], [thoigianhoatdong]) VALUES (1018, N'Ghe02', N'KH0000002', CAST(N'2020-07-26T16:08:19.577' AS DateTime), 1800)
SET IDENTITY_INSERT [dbo].[History] OFF
GO
INSERT [dbo].[KhachHang] ([id], [ho], [ten], [sdt], [email], [diachi], [ngaysinh], [CreateAt], [loaikhachhang]) VALUES (N'KH0000001', N'Nguyễn Hữu', N'Nam', N'0964056715', N'nct.10a4.18.1415@gmail.com', N'Lê Đức Thọ', N'07/08/1999', CAST(N'2020-07-27T15:05:22.967' AS DateTime), 3)
INSERT [dbo].[KhachHang] ([id], [ho], [ten], [sdt], [email], [diachi], [ngaysinh], [CreateAt], [loaikhachhang]) VALUES (N'KH0000002', N'Phạm Thị Thanh', N'Hằng', N'0388404061', N'asaba', N'adga', N'28/07/1999', CAST(N'2020-07-27T15:15:47.480' AS DateTime), 4)
GO
SET IDENTITY_INSERT [dbo].[LoaiKH] ON 

INSERT [dbo].[LoaiKH] ([id], [tenloai]) VALUES (3, N'abc')
INSERT [dbo].[LoaiKH] ([id], [tenloai]) VALUES (4, N'bcd')
SET IDENTITY_INSERT [dbo].[LoaiKH] OFF
GO
SET IDENTITY_INSERT [dbo].[SucKhoe] ON 

INSERT [dbo].[SucKhoe] ([id], [tenbenh], [CreateAt]) VALUES (2, N'Tiểu đường', CAST(N'2020-07-23T16:30:23.290' AS DateTime))
INSERT [dbo].[SucKhoe] ([id], [tenbenh], [CreateAt]) VALUES (4, N'Huyết áp thấp', CAST(N'2020-07-23T16:43:50.690' AS DateTime))
INSERT [dbo].[SucKhoe] ([id], [tenbenh], [CreateAt]) VALUES (5, N'Cao huyết áp', CAST(N'2020-07-23T17:49:08.513' AS DateTime))
INSERT [dbo].[SucKhoe] ([id], [tenbenh], [CreateAt]) VALUES (6, N'Khó ngủ', CAST(N'2020-07-24T15:23:56.040' AS DateTime))
SET IDENTITY_INSERT [dbo].[SucKhoe] OFF
GO
SET IDENTITY_INSERT [dbo].[UserQl] ON 

INSERT [dbo].[UserQl] ([id], [username], [passw], [logincode]) VALUES (2, N'User1', N'E0FBE47428A545EAB1547CE2CA0AB25E', N'FirstSet')
INSERT [dbo].[UserQl] ([id], [username], [passw], [logincode]) VALUES (3, N'User2', N'E0FBE47428A545EAB1547CE2CA0AB25E', N'SecondSet')
SET IDENTITY_INSERT [dbo].[UserQl] OFF
GO
ALTER TABLE [dbo].[Ghe]  WITH CHECK ADD  CONSTRAINT [FK_ql] FOREIGN KEY([quanli])
REFERENCES [dbo].[UserQl] ([id])
GO
ALTER TABLE [dbo].[Ghe] CHECK CONSTRAINT [FK_ql]
GO
ALTER TABLE [dbo].[HoatDong]  WITH CHECK ADD FOREIGN KEY([idghe])
REFERENCES [dbo].[Ghe] ([id])
GO
ALTER TABLE [dbo].[HoatDong]  WITH CHECK ADD  CONSTRAINT [FK_kh] FOREIGN KEY([idkh])
REFERENCES [dbo].[KhachHang] ([id])
GO
ALTER TABLE [dbo].[HoatDong] CHECK CONSTRAINT [FK_kh]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_loaiKH] FOREIGN KEY([loaikhachhang])
REFERENCES [dbo].[LoaiKH] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_loaiKH]
GO
ALTER TABLE [dbo].[SucKhoeKhachHang]  WITH CHECK ADD  CONSTRAINT [FK_khnew] FOREIGN KEY([idkh])
REFERENCES [dbo].[KhachHang] ([id])
GO
ALTER TABLE [dbo].[SucKhoeKhachHang] CHECK CONSTRAINT [FK_khnew]
GO
ALTER TABLE [dbo].[SucKhoeKhachHang]  WITH CHECK ADD  CONSTRAINT [FK_sk] FOREIGN KEY([idbenh])
REFERENCES [dbo].[SucKhoe] ([id])
GO
ALTER TABLE [dbo].[SucKhoeKhachHang] CHECK CONSTRAINT [FK_sk]
GO
/****** Object:  StoredProcedure [dbo].[BaoTriBan]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[BaoTriBan](@id varchar(10))
as
begin
  update Ghe set tinhtrang='baotri' where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[checkExist]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[checkExist]
(
   @idghe varchar(10)
)
as
begin
   select a.id,a.ho+' '+a.ten as hoten,a.sdt,a.email,a.diachi,a.ngaysinh,a.CreateAt as hoten,sdt from KhachHang a join HoatDong b on a.id=b.idkh and b.idghe = @idghe
end
GO
/****** Object:  StoredProcedure [dbo].[deleteKH]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteKH]
(
  @id varchar(10)
)
as 
begin
 delete from KhachHang where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[deleteSKKH]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteSKKH]
(
  @idkh varchar(10),
  @idbenh int
)
as 
begin
   delete from SucKhoeKhachHang where idkh=@idkh and idbenh=@idbenh
end
GO
/****** Object:  StoredProcedure [dbo].[deleteSucKhoe]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteSucKhoe]
(
  @id int
)
as
begin
  delete from SucKhoe where id =@id 
end
GO
/****** Object:  StoredProcedure [dbo].[DuaVaoHoatDong]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DuaVaoHoatDong](@id varchar(10))
as
begin
  update Ghe set tinhtrang='hoatdong' where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetCode]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetCode]
(
   @username varchar(50)
)
as
begin
  select logincode from UserQl where username = @username
end
GO
/****** Object:  StoredProcedure [dbo].[getInfoById]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getInfoById](@id varchar(10))
as
begin
  select * from Ghe where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[getListBenh]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[getListBenh]
(
 @idkh varchar(10)
)
as 
begin
  select * from SucKhoeKhachHang a join SucKhoe b on a.idbenh=b.id and a.idkh=@idkh
end
GO
/****** Object:  StoredProcedure [dbo].[GetListKH]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetListKH]

as
begin
select a.id,CreateAt,ho,ten,sdt,email,ngaysinh,diachi,ho+' '+ten as hoten,b.tenloai,b.id as idlkh from khachhang a join LoaiKH b on a.loaikhachhang = b.id order by CreateAt Desc
end
GO
/****** Object:  StoredProcedure [dbo].[getListLoaiKh]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getListLoaiKh]
as 
begin
   select * from LoaiKH
end
GO
/****** Object:  StoredProcedure [dbo].[getListSucKhoe]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getListSucKhoe]
as
begin
 select * from SucKhoe
end
GO
/****** Object:  StoredProcedure [dbo].[GetSLKHinDayofWeek]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[GetSLKHinDayofWeek](@pass int,@user int)
as 
begin
   declare @st int
   declare @current datetime =getDate() --26/7
   declare @currentFirstDay datetime
   select @currentFirstDay=dbo.getFirstDayofWeek(@current) --9/8
   select @st=dbo.GetNumberofWeek(@user) --4
   declare @selectFirstDay datetime = DateAdd(DAY,-(@st-@pass)*7,@currentFirstDay)

   DECLARE @dayofWeek TABLE (ngay datetime) 
   insert into @dayofWeek
   select * from dbo.getAllDayinWeek(@selectFirstDay) order by CONVERT(datetime,ngay,103)
   select Convert(datetime,b.ngay,103) as ngay1,ISNULL(COUNT(a.idkh), 0) as slkh from 
   @dayofWeek b left join (History a join Ghe c on a.idghe=c.id and c.quanli=@user) on CONVERT(VARCHAR(10),a.thoigianbatdau,103)=CONVERT(VARCHAR(10),b.ngay,103) group by (Convert(datetime,b.ngay,103)) order by ngay1
end
GO
/****** Object:  StoredProcedure [dbo].[getTk]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getTk]
(
   @user varchar(20)
)
as
begin
     select hs.id,idghe,idkh,g.tenban,c.ho+' '+c.ten as ten,hs.thoigianbatdau,CONVERT(time(0), DATEADD(SECOND, hs.thoigianhoatdong, 0)) as thoigianhoatdong from (History hs join Ghe g on g.id=hs.idghe and g.quanli=@user) join KhachHang c on hs.idkh=c.id order by thoigianbatdau Desc
end
GO
/****** Object:  StoredProcedure [dbo].[getTKtheoDay]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getTKtheoDay]
(
  @user int,
  @day varchar(20)
)
as
begin
   select hs.id,idghe,idkh,g.tenban,c.ho+' '+c.ten as ten,hs.thoigianbatdau,CONVERT(time(0), DATEADD(SECOND, hs.thoigianhoatdong, 0)) as thoigianhoatdong from (History hs join Ghe g on g.id=hs.idghe and g.quanli=@user and CONVERT(VARCHAR(10), hs.thoigianbatdau, 103)=@day) join KhachHang c on hs.idkh=c.id
end
GO
/****** Object:  StoredProcedure [dbo].[getUserId]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getUserId]
(
  @username varchar(50)
)
as
begin
  select id from UserQl where username=@username
end
GO
/****** Object:  StoredProcedure [dbo].[InsertHoatDong]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertHoatDong]
(
   @idghe varchar(10),
   @idkh varchar(10),
   @tg datetime
)
as
begin
  if not exists (select * from HoatDong where idkh=@idkh)
      insert into HoatDong values(@idghe,@idkh,@tg)
  else 
      RAISERROR(N'Khách hàng đang hoạt động',16,1)
end
GO
/****** Object:  StoredProcedure [dbo].[insertKH]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertKH]
(
  @id varchar(10),
  @ho nvarchar(500),
  @ten nvarchar(20),
  @sdt varchar(15),
  @email varchar(30),
  @dc nvarchar(1000),
  @ns varchar(20),
  @ca datetime,
  @idlkh int
)
as 
begin
insert into KhachHang(id,ho,ten,sdt,email,diachi,ngaysinh,CreateAt,loaikhachhang) values (@id,@ho,@ten,@sdt,@email,@dc,@ns,@ca,@idlkh)
end
GO
/****** Object:  StoredProcedure [dbo].[insertSKKH]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertSKKH]
(
  @idkh varchar(10),
  @idbenh int
)
as 
begin
  declare @ct int
  select @ct=count(*) from SucKhoeKhachHang where idkh=@idkh and idbenh=@idbenh
  if(@ct=0)
     insert into SucKhoeKhachHang values (@idkh,@idbenh)
  else
      RAISERROR(N'Đã khai báo',16,1)

end
GO
/****** Object:  StoredProcedure [dbo].[insertSucKhoe]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertSucKhoe]
(
  @ten nvarchar(200),
  @ngay datetime
)
as
begin
  insert into SucKhoe values(@ten,@ngay)
end
GO
/****** Object:  StoredProcedure [dbo].[KetThucHoatDong]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[KetThucHoatDong]
(
  @idghe varchar(10),
  @idkh varchar(10),
  @hd   int
)
as 
begin
  declare @time datetime
  select @time=dbo.getTimebD(@idghe)
  delete from HoatDong where idghe = @idghe
  insert into History values (@idghe,@idkh,@time,@hd)
end
GO
/****** Object:  StoredProcedure [dbo].[LayThongTinGhe]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LayThongTinGhe]
(
  @quanli int
)
as
begin
select * from Ghe where quanli =@quanli
end
GO
/****** Object:  StoredProcedure [dbo].[LuuTrangThai]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[LuuTrangThai]
(
  @TempTable AS dbo.GheLocation READONLY
)
AS
BEGIN

    Update Ghe set LX=r.LX,LY=r.LY  from @TempTable r  where Ghe.id = r.id
END
GO
/****** Object:  StoredProcedure [dbo].[ThemLoaiKH]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemLoaiKH]
(
    @tenloai nvarchar(100)
)
as 
begin
   insert into LoaiKH values(@tenloai)
end
GO
/****** Object:  StoredProcedure [dbo].[themVaLayThongTin]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[themVaLayThongTin]
(
  @tinhtrang varchar(50),
  @quanli int,
  @tenban nvarchar(50)
)
as 
begin
  declare @id varchar(10)
  exec @id = dbo.fcgetIdGhe
  insert Ghe values(@id,@tinhtrang,10,10,@quanli,@tenban)
  if exists (select 1 from Ghe where id=@id)
     select * from Ghe where id =@id
end
GO
/****** Object:  StoredProcedure [dbo].[TimBenh]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[TimBenh]
(
  @ten nvarchar(50)
)
as 
begin
  declare @rs int
  select @rs = dbo.Ftimbenh(@ten);
  if(@rs>0)
    select a.id,a.tenbenh,a.CreateAt from SucKhoe a,(select id,dbo.GetUnsignString(tenbenh) as tb from SucKhoe) b  where a.id=b.id and b.tb like '%'+@ten+'%' 
  else
    select * from SucKhoe a where a.tenbenh like N'%'+@ten+'%' order by CreateAt Desc
end
GO
/****** Object:  StoredProcedure [dbo].[TimHo]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[TimHo]
(
  @ten nvarchar(50)
)
as 
begin
  declare @rs int
  select @rs = dbo.Ftimho(@ten);
  if(@rs>0)
    select a.id,a.ho+' '+a.ten as hoten,a.ten,a.ho,a.sdt,a.ngaysinh,a.email,a.diachi,a.CreateAt,loaikhachhang as idlkh from KhachHang a,(select id,dbo.GetUnsignString(ho) as ho from KhachHang) b  where a.id=b.id and b.ho like N'%'+@ten+'%'  order by CreateAt Desc
  else
    select a.id,a.ho+' '+a.ten as hoten,a.ten,a.ho,a.sdt,a.ngaysinh,a.email,a.diachi,a.CreateAt,loaikhachhang as idlkh from KhachHang a where a.ho like N'%'+@ten+'%' order by CreateAt Desc
end
GO
/****** Object:  StoredProcedure [dbo].[TimSDT]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[TimSDT]
(@sdt varchar(50))
as
begin
    select a.id,a.ho+' '+a.ten as hoten,a.ten,a.ho,a.sdt,a.ngaysinh,a.email,a.diachi,a.CreateAt,loaikhachhang as idlkh from KhachHang a where a.sdt like N'%'+@sdt+'%' order by CreateAt Desc
end
GO
/****** Object:  StoredProcedure [dbo].[TimTatCa]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[TimTatCa]
(
  @string nvarchar(50)
)
as 
begin
  declare @rs int
  select @rs = dbo.Ftimtatca(@string);
  if(@rs>0)
    select a.id,a.ho+' '+a.ten as hoten,a.ten,a.ho,a.sdt,a.ngaysinh,a.email,a.diachi,a.CreateAt,loaikhachhang as idlkh from KhachHang a,(select id,dbo.GetUnsignString(ten+' '+ho+' '+sdt) as infor from KhachHang) b  where a.id=b.id and b.infor like N'%'+@string+'%'  order by CreateAt Desc
  else
    select a.id,a.ho+' '+a.ten as hoten,a.ten,a.ho,a.sdt,a.ngaysinh,a.email,a.diachi,a.CreateAt,loaikhachhang as idlkh from KhachHang a where a.ten+' '+a.ho+' '+a.sdt like N'%'+@string+'%' order by CreateAt Desc
end
GO
/****** Object:  StoredProcedure [dbo].[TimTen]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[TimTen]
(
  @ten nvarchar(50)
)
as 
begin
  declare @rs int
  select @rs = dbo.Ftimten(@ten);
  if(@rs>0)
    select a.id,a.ho+' '+a.ten as hoten,a.ten,a.ho,a.sdt,a.ngaysinh,a.email,a.diachi,a.CreateAt,loaikhachhang as idlkh from KhachHang a,(select id,dbo.GetUnsignString(ten) as ten from KhachHang) b  where a.id=b.id and b.ten like N'%'+@ten+'%'  order by CreateAt Desc
  else
    select a.id,a.ho+' '+a.ten as hoten,a.ten,a.ho,a.sdt,a.ngaysinh,a.email,a.diachi,a.CreateAt,loaikhachhang as idlkh from KhachHang a where a.ten like N'%'+@ten+'%' order by CreateAt Desc
end
GO
/****** Object:  StoredProcedure [dbo].[updateKH]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[updateKH]
(
  @id varchar(10),
  @ho nvarchar(500),
  @ten nvarchar(20),
  @sdt varchar(15),
  @email varchar(30),
  @dc nvarchar(1000),
  @ns varchar(20),
  @idlkh int
)
as 
begin
 update KhachHang set ho=@ho,ten=@ten,sdt=@sdt,email=@email,diachi=@dc,ngaysinh=@ns,loaikhachhang=@idlkh where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[XoaGhe]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaGhe](@id varchar(10))
as
begin
  delete from Ghe where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[XoaLoaiKH]    Script Date: 7/27/2020 3:41:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaLoaiKH]
(
    @id int
)
as 
begin
   delete from LoaiKH where id=@id
end
GO
USE [master]
GO
ALTER DATABASE [qlhd] SET  READ_WRITE 
GO
