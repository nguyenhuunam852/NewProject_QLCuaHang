USE [master]
GO
/****** Object:  Database [2020]    Script Date: 7/30/2020 1:35:07 PM ******/
CREATE DATABASE [2020]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'2020', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\2020.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'2020_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\2020_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [2020] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [2020].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [2020] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [2020] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [2020] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [2020] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [2020] SET ARITHABORT OFF 
GO
ALTER DATABASE [2020] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [2020] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [2020] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [2020] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [2020] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [2020] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [2020] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [2020] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [2020] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [2020] SET  ENABLE_BROKER 
GO
ALTER DATABASE [2020] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [2020] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [2020] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [2020] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [2020] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [2020] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [2020] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [2020] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [2020] SET  MULTI_USER 
GO
ALTER DATABASE [2020] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [2020] SET DB_CHAINING OFF 
GO
ALTER DATABASE [2020] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [2020] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [2020] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [2020] SET QUERY_STORE = OFF
GO
USE [2020]
GO
/****** Object:  UserDefinedTableType [dbo].[deskLocation]    Script Date: 7/30/2020 1:35:08 PM ******/
CREATE TYPE [dbo].[deskLocation] AS TABLE(
	[id] [varchar](10) NULL,
	[LX] [int] NULL,
	[LY] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[newtempCustomerHealth]    Script Date: 7/30/2020 1:35:08 PM ******/
CREATE TYPE [dbo].[newtempCustomerHealth] AS TABLE(
	[idcustomer] [int] NULL,
	[idhealth] [int] NULL,
	[name] [varchar](50) NULL,
	[createat] [datetime] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[tempCustomerHealth]    Script Date: 7/30/2020 1:35:08 PM ******/
CREATE TYPE [dbo].[tempCustomerHealth] AS TABLE(
	[idcustomer] [int] NULL,
	[idhealth] [int] NULL,
	[createat] [datetime] NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[CheckExistinDeskCustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create function [dbo].[CheckExistinDeskCustomer]
(
   @idghe varchar(10)
)
returns int
as
begin
  declare @ct int
  select @ct=count(*) from DeskCustomer where iddesk=@idghe
  return @ct 
end
GO
/****** Object:  UserDefinedFunction [dbo].[CheckWorkProcess]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create function [dbo].[CheckWorkProcess]
(
   @user int,
   @ngay datetime
)
returns int
as 
begin
  declare @rs int
  select @rs=count(*) from Statical where iduser=@user and CONVERT(VARCHAR(10), CreateAt, 103)=CONVERT(VARCHAR(10),@ngay, 103)
  return @rs
end
GO
/****** Object:  UserDefinedFunction [dbo].[Ftimbenh]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Ftimbenh]
(@ten nvarchar(50))
returns int 
begin
  declare @rs int
  select @rs=count(*) from Health a,(select id,dbo.GetUnsignString([name]) as tb from Health) b  where a.id=b.id and b.tb like '%'+@ten+'%' 
  return @rs
end
GO
/****** Object:  UserDefinedFunction [dbo].[Ftimtatca]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[Ftimtatca](@string nvarchar(50))
returns int
as
begin
  declare @ct int
  select @ct=count(*) from customer a,(select id,dbo.GetUnsignString( [lastname]+' '+[firstname]+' '+[phone]+' '+[email]+' '+[code]) as infor from customer) b  where a.id=b.id and b.infor like '%'+@string+'%'
  return @ct
end
GO
/****** Object:  UserDefinedFunction [dbo].[getAllDayinWeek]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create function [dbo].[getAllDayinWeek] 
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
/****** Object:  UserDefinedFunction [dbo].[getFirstDayofWeek]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create function [dbo].[getFirstDayofWeek] 
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
/****** Object:  UserDefinedFunction [dbo].[GetNumberofWeek]    Script Date: 7/30/2020 1:35:08 PM ******/
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
   select @min=Min(a.CreateAt),@max=Max(a.CreateAt) from Statical a where a.iduser=@user
   declare @fdowmin datetime 
   select @fdowmin=dbo.getFirstDayofWeek(@min)
   declare @fdowmax datetime 
   select @fdowmax=dbo.getFirstDayofWeek(@max)
   select @now = DATEDIFF(day, @fdowmin, @fdowmax)/7 
   return @now +1
end
GO
/****** Object:  UserDefinedFunction [dbo].[getTimebD]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create function [dbo].[getTimebD](@idghe varchar(10))
returns datetime
as
begin
 declare @dt datetime
 select @dt=createat from DeskCustomer where iddesk=@idghe
 return @dt
end
GO
/****** Object:  UserDefinedFunction [dbo].[GetUnsignString]    Script Date: 7/30/2020 1:35:08 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[Login]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Login]
(
   @username varchar(50),
   @password varchar(50)
)
returns int
as
begin
  declare @check int
  select @check=count(*) from [User] where username=@username and passw=@password
  if(@check>0)
     return 1
  return 0
end
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](20) NOT NULL,
	[lastname] [nvarchar](500) NULL,
	[firstname] [nvarchar](20) NULL,
	[email] [varchar](100) NULL,
	[address] [nvarchar](1000) NULL,
	[birthday] [varchar](20) NULL,
	[phone] [varchar](15) NULL,
	[sex] [int] NULL,
	[iduser] [int] NULL,
	[createat] [datetime] NULL,
	[updateat] [datetime] NULL,
	[type] [int] NULL,
	[available] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Desk]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Desk](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [varchar](50) NULL,
	[locationx] [int] NULL,
	[locationy] [int] NULL,
	[iduser] [int] NULL,
	[name] [nvarchar](50) NULL,
	[createat] [datetime] NULL,
	[updateat] [datetime] NULL,
	[available] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeskCustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeskCustomer](
	[iddesk] [int] NULL,
	[idcustomer] [int] NULL,
	[createat] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HealCustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HealCustomer](
	[idcustomer] [int] NULL,
	[idhealth] [int] NULL,
	[createat] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Health]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Health](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[createat] [datetime] NULL,
	[updateat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[History]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[iddesk] [varchar](10) NOT NULL,
	[idcustomer] [varchar](10) NOT NULL,
	[createat] [datetime] NOT NULL,
	[activetime] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statical]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statical](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createat] [datetime] NULL,
	[newmembers] [int] NULL,
	[kindofmembers] [varchar](500) NULL,
	[iduser] [int] NULL,
	[sumofday] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeCustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeCustomer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[available] [int] NULL,
	[createat] [datetime] NULL,
	[updateat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[passw] [varchar](50) NULL,
	[lastname] [nvarchar](500) NULL,
	[firstname] [nvarchar](20) NULL,
	[plastnamene] [varchar](15) NULL,
	[email] [varchar](100) NULL,
	[address] [nvarchar](1000) NULL,
	[birthday] [varchar](20) NULL,
	[sex] [int] NULL,
	[iduser] [int] NULL,
	[createat] [datetime] NULL,
	[updateat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([id], [code], [lastname], [firstname], [email], [address], [birthday], [phone], [sex], [iduser], [createat], [updateat], [type], [available]) VALUES (2, N'MTEW582020', N'Nguyễn Hữu', N'Nam', N'asgag', N'aga', N'07/08/1999', N'1351236', 1, 1, CAST(N'2020-08-05T00:24:42.310' AS DateTime), NULL, 1, 0)
INSERT [dbo].[Customer] ([id], [code], [lastname], [firstname], [email], [address], [birthday], [phone], [sex], [iduser], [createat], [updateat], [type], [available]) VALUES (3, N'MRUO582020', N'Phạm Thị Thanh', N'Hằng', N'asgfasg', N'asgag', N'28/07/1999', N'15136136', 0, 1, CAST(N'2020-08-05T00:29:26.363' AS DateTime), CAST(N'2020-07-29T14:27:18.673' AS DateTime), 1, 1)
INSERT [dbo].[Customer] ([id], [code], [lastname], [firstname], [email], [address], [birthday], [phone], [sex], [iduser], [createat], [updateat], [type], [available]) VALUES (4, N'0', N'Nguyễn Hữu', N'Nam', N'aahga', N'asdga', N'07/08/1999', N'0136136', 1, 1, CAST(N'2020-08-05T01:19:17.397' AS DateTime), NULL, 1, 0)
INSERT [dbo].[Customer] ([id], [code], [lastname], [firstname], [email], [address], [birthday], [phone], [sex], [iduser], [createat], [updateat], [type], [available]) VALUES (5, N'0', N'Nguyễn Hữu', N'Nam', N'afagqag', N'aga', N'07/08/1999', N'012356136', 1, 1, CAST(N'2020-08-05T01:20:06.077' AS DateTime), NULL, 3, 0)
INSERT [dbo].[Customer] ([id], [code], [lastname], [firstname], [email], [address], [birthday], [phone], [sex], [iduser], [createat], [updateat], [type], [available]) VALUES (6, N'AAIL582020', N'Nguyễn Hữu', N'Nam', N'asdgag', N'aga', N'07/08/1999', N'15161361', 1, 1, CAST(N'2020-08-05T01:23:30.213' AS DateTime), CAST(N'2020-07-30T11:05:28.067' AS DateTime), 3, 1)
INSERT [dbo].[Customer] ([id], [code], [lastname], [firstname], [email], [address], [birthday], [phone], [sex], [iduser], [createat], [updateat], [type], [available]) VALUES (7, N'VRRG2972020', N'Nguyễn Văn', N'A', N'askjgak', N'agkah', N'07/08/1999', N'125916', 1, 1, CAST(N'2020-07-29T12:03:41.987' AS DateTime), CAST(N'2020-07-29T14:24:59.633' AS DateTime), 3, 1)
INSERT [dbo].[Customer] ([id], [code], [lastname], [firstname], [email], [address], [birthday], [phone], [sex], [iduser], [createat], [updateat], [type], [available]) VALUES (1007, N'QRPT3072020', N'Trần Văn', N'BBB', N'asgah', N'ahaha', N'12/34/5678', N'017598136', 1, 1, CAST(N'2020-07-30T11:03:05.033' AS DateTime), NULL, 3, 1)
INSERT [dbo].[Customer] ([id], [code], [lastname], [firstname], [email], [address], [birthday], [phone], [sex], [iduser], [createat], [updateat], [type], [available]) VALUES (1008, N'GDAA3072020', N'Nguyễn Văn', N'C', N'aga', N'gbakb', N'09/06/1999', N'39691691', 1, 1, CAST(N'2020-07-30T12:51:11.713' AS DateTime), NULL, 1, 1)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Desk] ON 

INSERT [dbo].[Desk] ([id], [status], [locationx], [locationy], [iduser], [name], [createat], [updateat], [available]) VALUES (2, N'1', 64, 241, 1, N'ghe1', CAST(N'2020-08-04T22:10:07.360' AS DateTime), CAST(N'2020-08-04T22:10:07.360' AS DateTime), 1)
INSERT [dbo].[Desk] ([id], [status], [locationx], [locationy], [iduser], [name], [createat], [updateat], [available]) VALUES (3, N'0', 414, 40, 1, N'ghe3', CAST(N'2020-08-04T22:45:50.617' AS DateTime), CAST(N'2020-08-04T22:45:50.617' AS DateTime), 0)
INSERT [dbo].[Desk] ([id], [status], [locationx], [locationy], [iduser], [name], [createat], [updateat], [available]) VALUES (4, N'0', 243, 79, 1, N'ghe2', CAST(N'2020-08-04T23:30:34.210' AS DateTime), CAST(N'2020-07-29T14:44:28.190' AS DateTime), 1)
INSERT [dbo].[Desk] ([id], [status], [locationx], [locationy], [iduser], [name], [createat], [updateat], [available]) VALUES (5, N'1', 229, 214, 1, N'ghe3', CAST(N'2020-08-04T23:32:36.390' AS DateTime), CAST(N'2020-08-04T23:32:36.390' AS DateTime), 1)
INSERT [dbo].[Desk] ([id], [status], [locationx], [locationy], [iduser], [name], [createat], [updateat], [available]) VALUES (6, N'1', 379, 246, 1, N'ghế 5', CAST(N'2020-07-29T14:47:08.600' AS DateTime), CAST(N'2020-07-29T14:47:08.600' AS DateTime), 1)
INSERT [dbo].[Desk] ([id], [status], [locationx], [locationy], [iduser], [name], [createat], [updateat], [available]) VALUES (7, N'1', 447, 86, 1, N'Ghế 6', CAST(N'2020-07-29T14:48:35.850' AS DateTime), CAST(N'2020-07-29T14:48:35.850' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Desk] OFF
GO
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (7, 1, CAST(N'2020-07-29T14:24:59.633' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (7, 2, CAST(N'2020-07-29T14:24:59.633' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (7, 3, CAST(N'2020-07-29T14:24:59.633' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (7, 4, CAST(N'2020-07-29T14:24:59.633' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (6, 1, CAST(N'2020-07-30T11:05:28.077' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (6, 5, CAST(N'2020-07-30T11:05:28.077' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (6, 7, CAST(N'2020-07-30T11:05:28.077' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (1007, 1, CAST(N'2020-07-30T11:03:05.067' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (1007, 2, CAST(N'2020-07-30T11:03:05.067' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (1007, 3, CAST(N'2020-07-30T11:03:05.067' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (1007, 1019, CAST(N'2020-07-30T11:03:05.067' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (6, 1017, CAST(N'2020-07-30T11:05:28.077' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (6, 8, CAST(N'2020-07-30T11:05:28.077' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (6, 1012, CAST(N'2020-07-30T11:05:28.077' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (6, 1020, CAST(N'2020-07-30T11:05:28.077' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (7, 8, CAST(N'2020-07-29T14:24:59.633' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (7, 1012, CAST(N'2020-07-29T14:24:59.633' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (3, 4, CAST(N'2020-07-29T14:27:18.673' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (3, 6, CAST(N'2020-07-29T14:27:18.673' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (3, 9, CAST(N'2020-07-29T14:27:18.673' AS DateTime))
INSERT [dbo].[HealCustomer] ([idcustomer], [idhealth], [createat]) VALUES (3, 7, CAST(N'2020-07-29T14:27:18.673' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Health] ON 

INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (1, N'đau khớp', CAST(N'2020-08-05T02:09:50.407' AS DateTime), CAST(N'2020-08-05T02:09:50.407' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (2, N'Đau bụng', CAST(N'2020-08-05T02:47:07.897' AS DateTime), CAST(N'2020-08-05T02:47:07.897' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (3, N'Đau thần kinh tọa', CAST(N'2020-08-05T02:47:22.130' AS DateTime), CAST(N'2020-08-05T02:47:22.130' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (4, N'Khó ngủ', CAST(N'2020-07-29T11:22:29.550' AS DateTime), CAST(N'2020-07-29T11:22:29.550' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (5, N'Tiểu đêm', CAST(N'2020-07-29T11:24:20.243' AS DateTime), CAST(N'2020-07-29T11:24:20.243' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (6, N'Nhức đầu', CAST(N'2020-07-29T11:24:50.230' AS DateTime), CAST(N'2020-07-29T11:24:50.230' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (7, N'Cận thị', CAST(N'2020-07-29T11:25:42.043' AS DateTime), CAST(N'2020-07-29T11:25:42.043' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (8, N'Viễn thị', CAST(N'2020-07-29T11:26:30.543' AS DateTime), CAST(N'2020-07-29T11:26:30.543' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (9, N'Sốt cao', CAST(N'2020-07-29T11:37:40.793' AS DateTime), CAST(N'2020-07-29T11:37:40.793' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (1011, N'abc', CAST(N'2020-07-29T13:05:47.227' AS DateTime), CAST(N'2020-07-29T13:05:47.227' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (1012, N'xyz', CAST(N'2020-07-29T13:15:42.523' AS DateTime), CAST(N'2020-07-29T13:15:42.523' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (1013, N'tre', CAST(N'2020-07-29T13:17:33.257' AS DateTime), CAST(N'2020-07-29T13:17:33.257' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (1014, N'saf', CAST(N'2020-07-29T13:18:53.103' AS DateTime), CAST(N'2020-07-29T13:18:53.103' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (1015, N'asg', CAST(N'2020-07-29T13:21:32.123' AS DateTime), CAST(N'2020-07-29T13:21:32.123' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (1016, N'sag', CAST(N'2020-07-29T13:25:37.537' AS DateTime), CAST(N'2020-07-29T13:25:37.537' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (1017, N'asgag', CAST(N'2020-07-29T14:24:02.923' AS DateTime), CAST(N'2020-07-29T14:24:02.923' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (1018, N'asgag', CAST(N'2020-07-30T11:02:47.987' AS DateTime), CAST(N'2020-07-30T11:02:47.987' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (1019, N'taw', CAST(N'2020-07-30T11:02:58.007' AS DateTime), CAST(N'2020-07-30T11:02:58.007' AS DateTime))
INSERT [dbo].[Health] ([id], [name], [createat], [updateat]) VALUES (1020, N'agaha', CAST(N'2020-07-30T11:05:18.167' AS DateTime), CAST(N'2020-07-30T11:05:18.167' AS DateTime))
SET IDENTITY_INSERT [dbo].[Health] OFF
GO
SET IDENTITY_INSERT [dbo].[History] ON 

INSERT [dbo].[History] ([id], [iddesk], [idcustomer], [createat], [activetime]) VALUES (1, N'7', N'6', CAST(N'2020-07-30T10:11:54.717' AS DateTime), 1794)
INSERT [dbo].[History] ([id], [iddesk], [idcustomer], [createat], [activetime]) VALUES (2, N'6', N'3', CAST(N'2020-07-30T10:12:02.150' AS DateTime), 1800)
INSERT [dbo].[History] ([id], [iddesk], [idcustomer], [createat], [activetime]) VALUES (3, N'5', N'7', CAST(N'2020-07-30T10:12:09.890' AS DateTime), 1800)
INSERT [dbo].[History] ([id], [iddesk], [idcustomer], [createat], [activetime]) VALUES (4, N'7', N'3', CAST(N'2020-07-30T10:12:17.870' AS DateTime), 1800)
SET IDENTITY_INSERT [dbo].[History] OFF
GO
SET IDENTITY_INSERT [dbo].[Statical] ON 

INSERT [dbo].[Statical] ([id], [createat], [newmembers], [kindofmembers], [iduser], [sumofday]) VALUES (1, CAST(N'2020-07-30T10:12:44.977' AS DateTime), 1, N'1:1,3:2', 1, 3)
SET IDENTITY_INSERT [dbo].[Statical] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeCustomer] ON 

INSERT [dbo].[TypeCustomer] ([id], [name], [available], [createat], [updateat]) VALUES (1, N'abc', 1, CAST(N'2020-08-05T00:13:19.360' AS DateTime), CAST(N'2020-08-05T00:13:19.360' AS DateTime))
INSERT [dbo].[TypeCustomer] ([id], [name], [available], [createat], [updateat]) VALUES (3, N'xyz', 1, CAST(N'2020-08-05T00:19:26.440' AS DateTime), CAST(N'2020-08-05T00:19:26.440' AS DateTime))
SET IDENTITY_INSERT [dbo].[TypeCustomer] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [username], [passw], [lastname], [firstname], [plastnamene], [email], [address], [birthday], [sex], [iduser], [createat], [updateat]) VALUES (1, N'User1', N'E0FBE47428A545EAB1547CE2CA0AB25E', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([id], [username], [passw], [lastname], [firstname], [plastnamene], [email], [address], [birthday], [sex], [iduser], [createat], [updateat]) VALUES (2, N'User2', N'E0FBE47428A545EAB1547CE2CA0AB25E', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Desk] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_type] FOREIGN KEY([type])
REFERENCES [dbo].[TypeCustomer] ([id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_type]
GO
ALTER TABLE [dbo].[Desk]  WITH CHECK ADD  CONSTRAINT [FK_ql] FOREIGN KEY([iduser])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Desk] CHECK CONSTRAINT [FK_ql]
GO
ALTER TABLE [dbo].[DeskCustomer]  WITH CHECK ADD FOREIGN KEY([idcustomer])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[DeskCustomer]  WITH CHECK ADD FOREIGN KEY([iddesk])
REFERENCES [dbo].[Desk] ([id])
GO
ALTER TABLE [dbo].[HealCustomer]  WITH CHECK ADD  CONSTRAINT [FK_kh] FOREIGN KEY([idcustomer])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[HealCustomer] CHECK CONSTRAINT [FK_kh]
GO
ALTER TABLE [dbo].[HealCustomer]  WITH CHECK ADD  CONSTRAINT [FK_sk] FOREIGN KEY([idhealth])
REFERENCES [dbo].[Health] ([id])
GO
ALTER TABLE [dbo].[HealCustomer] CHECK CONSTRAINT [FK_sk]
GO
ALTER TABLE [dbo].[Statical]  WITH CHECK ADD  CONSTRAINT [FK_User] FOREIGN KEY([iduser])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Statical] CHECK CONSTRAINT [FK_User]
GO
/****** Object:  StoredProcedure [dbo].[active]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[active]
(
   @id int
)
as
begin
  update Desk set [status]=1,updateat=GETDATE() where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[CheckCustomerDesk]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CheckCustomerDesk]
(
  @idghe int
)
as
begin
      select a.id,a.code,a.[lastname]+' '+a.[firstname] as hoten,a.phone,a.email,a.[address],a.birthday,a.sex,a.CreateAt as ngaytao,c.[name] as typename,case when sex = 0 then N'Nữ' when sex = 1 then 'Nam' when sex=2 then 'None' end as sex,d.[name] as tenghe from ((Customer a join DeskCustomer b on a.id=b.idcustomer and b.iddesk = @idghe) join TypeCustomer c on c.id=a.[type]) join Desk d on d.id=b.iddesk
end
GO
/****** Object:  StoredProcedure [dbo].[deleteCustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteCustomer]
(
  @id int
)
as 
begin
   update Customer set available=0 where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomerDesk]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[DeleteCustomerDesk]
(
  @idghe varchar(10),
  @idkh varchar(10),
  @hd   int
)
as 
begin
  declare @time datetime
  select @time=dbo.getTimebD(@idghe)
  delete from DeskCustomer where iddesk = @idghe
  insert into History values (@idghe,@idkh,@time,@hd)
end
GO
/****** Object:  StoredProcedure [dbo].[deleteDesk]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[deleteDesk]
(
   @id int
)
as
begin
  update Desk set [available]=0 where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteTypeCustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteTypeCustomer]
(@id int)
as
begin
 delete from TypeCustomer where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[FindHealth]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[FindHealth]
(
  @ten nvarchar(50),
  @temp as dbo.newtempCustomerHealth readonly
)
as 
begin
  declare @rs int
  select @rs = dbo.Ftimbenh(@ten);
  if(@rs>0)
    select a.id,a.[name] from Health a,(select id,dbo.GetUnsignString([name]) as tb from Health) b  where a.id=b.id and b.tb like '%'+@ten+'%' and a.id not in (select idhealth from @temp)
  else
    select a.id,a.[name] from [Health] a where a.[name] like N'%'+@ten+'%' and a.id not in (select idhealth from @temp)
end
GO
/****** Object:  StoredProcedure [dbo].[FindInfor]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[FindInfor]
(
  @string nvarchar(50),
  @user  int
)
as 
begin
  declare @rs int
  select @rs = dbo.Ftimtatca(@string);
  if(@rs>0)
   select a.id,code,a.CreateAt,[firstname],[lastname],phone,email,[birthday],case when sex = 0 then N'Nữ' when sex = 1 then 'Nam' end as sex,[address],[lastname]+' '+[firstname] as hoten,a.[type],c.id as idlkh from TypeCustomer c,Customer a,(select id,dbo.GetUnsignString([lastname]+' '+[firstname]+' '+[phone]+' '+[email]+' '+[code]) as infor from Customer) b  where a.id=b.id and a.[available]=1 and a.iduser=@user and b.infor like '%'+@string+'%' and c.id=a.[type]
  else
     select a.id,code,a.CreateAt,[firstname],[lastname],phone,email,[birthday],case when sex = 0 then N'Nữ' when sex = 1 then 'Nam' end as sex,[address],[lastname]+' '+[firstname] as hoten,a.[type],b.id as idlkh from Customer a join TypeCustomer b on b.id=a.[type] and a.[lastname]+' '+a.[firstname]+' '+a.[phone]+' '+[email]+' '+[code] like N'%'+@string+'%' and a.[available]=1 and a.iduser=@user
end
GO
/****** Object:  StoredProcedure [dbo].[getallDayinMonth]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[getallDayinMonth]
(
  @user int,
  @month int,
  @year int
)

as 
begin
DECLARE @MonthNo TINYINT = @month -- set your month
    ,@WOYEAR SMALLINT = @year; -- set your year


DECLARE @START_DATE DATETIME
    ,@END_DATE DATETIME
    ,@CUR_DATE DATETIME

SET @START_DATE = DATEADD(month, @MonthNo - 1, DATEADD(year, @WOYEAR - 1900, 0))
print @START_DATE
SET @END_DATE = DATEADD(day, - 1, DATEADD(month, @MonthNo, DATEADD(year, @WOYEAR - 1900, 0)))
SET @CUR_DATE = @START_DATE

declare @TMP as Table (
    WEEKDAY VARCHAR(10)
    ,DATE INT
    ,MONTH VARCHAR(10)
    ,YEAR INT
    ,dates VARCHAR(25)
    )

WHILE @CUR_DATE <= @END_DATE
BEGIN
    INSERT INTO @TMP
    SELECT DATENAME(DW, @CUR_DATE)
        ,DATEPART(DAY, @CUR_DATE)
        ,MONTH(@CUR_DATE)
        ,DATEPART(YEAR, @CUR_DATE)
        ,REPLACE(CONVERT(VARCHAR(9), @CUR_DATE, 6), ' ', '-')

    SET @CUR_DATE = DATEADD(DD, 1, @CUR_DATE)
END
  select a.DATE,a.MONTH,a.YEAR,isNull(b.SumofDay,0) as TONG from @TMP a  left join Statical b on month(b.CreateAt)=a.MONTH and a.YEAR=Year(b.CreateAt) and b.iduser=@user and a.DATE=DaY(b.CreateAt)
end
GO
/****** Object:  StoredProcedure [dbo].[getAllHistoryinMonth]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getAllHistoryinMonth]
(
   @user int,
   @quarter int,
   @year int
)
as
begin
   declare @temp table([month] int,sl int)
   declare @min int=3*(@quarter-1)
   declare @max int=@min+4
   declare @i int=@min+1
   while @i<@max
   begin
       insert into @temp select @i,isnull(Sum(sumofday),0) from Statical where month(createat)=@i and year(createat)=@year
	   set @i=@i+1
   end
   select * from @temp
end
GO
/****** Object:  StoredProcedure [dbo].[getAllHistoryinMonthbyYear]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getAllHistoryinMonthbyYear]
(
   @user int,
   @year int
)
as
begin
   declare @temp table([month] int,sl int)
   declare @min int=1
   declare @max int=12
   declare @i int=1
   while @i<=@max
   begin
       insert into @temp select @i,isnull(Sum(sumofday),0) from Statical where month(createat)=@i and year(createat)=@year
	   set @i=@i+1
   end
   select * from @temp
end
GO
/****** Object:  StoredProcedure [dbo].[getAllHistoryinQuater]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getAllHistoryinQuater]
(
   @user int,
   @quarter int,
   @year int
)
as
begin
   declare @min int
   declare @max int
   set @min=3*(@quarter-1)
   print(@min)
   set @max=@min+4
   select hs.id,iddesk,idcustomer,g.name,c.[lastname]+' '+c.[firstname] as ten,hs.CreateAt,CONVERT(time(0), DATEADD(SECOND, hs.Activetime, 0)) as thoigianhoatdong from (History hs join Desk g on g.id=hs.iddesk and g.iduser=@user and month(hs.createat)<@max and MONTH(hs.createat)>@min and YEAR(hs.createat)=@year) join Customer c on hs.idcustomer=c.id
end
GO
/****** Object:  StoredProcedure [dbo].[getCustomerInfor]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getCustomerInfor]
(
   @id int
)
as
begin
   select a.id,code,[lastname]+' '+[firstname] as hoten,[phone],[email],[address],[birthday],b.[name] as typename,case when sex = 0 then N'Nữ' when sex = 1 then 'Nam' when sex=2 then 'None' end as sex from Customer a join TypeCustomer b on a.[type]=b.id and a.id =@id and a.available=1
end
GO
/****** Object:  StoredProcedure [dbo].[getdeskbyuserId]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getdeskbyuserId]
(
  @iduser int
)
as
begin
select * from desk where iduser =@iduser and available=1
end
GO
/****** Object:  StoredProcedure [dbo].[getDeskInfobyId]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[getDeskInfobyId](@id varchar(10))
as
begin
  select * from Desk where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[getinfoHealthafterInsert]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getinfoHealthafterInsert]
as
begin
  select id,[name] from Health where id in (select Max(id) from Health)
end
GO
/****** Object:  StoredProcedure [dbo].[GetListCustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetListCustomer]
(@user int)
as
begin
 select a.id,code,a.CreateAt,[firstname],[lastname],phone,email,[birthday],case when sex = 0 then N'Nữ' when sex = 1 then 'Nam' end as sex,[address],[lastname]+' '+[firstname] as hoten,a.[type],b.id as idlkh from [Customer] a join TypeCustomer b on a.[type] = b.id and a.iduser=@user and a.available=1 order by a.CreateAt Desc
end
GO
/****** Object:  StoredProcedure [dbo].[getlistdeskcustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getlistdeskcustomer]
as
begin
  select * from DeskCustomer
end
GO
/****** Object:  StoredProcedure [dbo].[getlistHealthAvailable]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getlistHealthAvailable]
(
  @temp as newtempCustomerHealth readonly
)
as
begin
   select id,[name] from Health where id not in (select idhealth from @temp)
end
GO
/****** Object:  StoredProcedure [dbo].[getListHeath]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getListHeath]
as
begin
   select id,[name] from Health 
end
GO
/****** Object:  StoredProcedure [dbo].[getListHeathofCustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getListHeathofCustomer]
(
   @idcs int
)
as
begin
   select a.idcustomer,a.idhealth,b.[name],a.[createat] from HealCustomer a join Health b on a.idhealth=b.id and idcustomer=@idcs
end
GO
/****** Object:  StoredProcedure [dbo].[getListstatistical]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getListstatistical]
(
   @user varchar(20)
)
as
begin
     select hs.id,iddesk,idcustomer,g.[name],c.[lastname]+' '+c.[firstname] as ten,hs.createat,CONVERT(time(0), DATEADD(SECOND, hs.Activetime, 0)) as thoigianhoatdong from (History hs join Desk g on g.id=hs.iddesk and g.iduser=@user) join Customer c on hs.idcustomer=c.id order by hs.createat Desc
end
GO
/****** Object:  StoredProcedure [dbo].[GetListTypeCustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetListTypeCustomer]
as
begin
 select * from TypeCustomer where available=1
end
GO
/****** Object:  StoredProcedure [dbo].[getminmaxYear]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getminmaxYear]
as
begin
select Min(Year(createat)),Max(YEAR(createat)) from Statical
end
GO
/****** Object:  StoredProcedure [dbo].[getmonthandyear]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getmonthandyear]
as
begin
select Distinct month(CreateAt)+year(CreateAt)*100,Cast(month(CreateAt) as varchar(5))+'/'+Cast(year(CreateAt) as varchar(5)) as thang
FROM Statical order by month(CreateAt)+year(CreateAt)*100 Asc
end
GO
/****** Object:  StoredProcedure [dbo].[GetnumberofCustomerinDayofWeek]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[GetnumberofCustomerinDayofWeek](@pass int,@user int)
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
   select CONVERT(datetime,b.ngay,103) as ngay,ISNULL(a.sumofday,0) from Statical a right join @dayofWeek b on  CONVERT(varchar,a.createat,103) =CONVERT(varchar,b.ngay,103)
end
GO
/****** Object:  StoredProcedure [dbo].[getStaticalinDay]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getStaticalinDay]
(
  @user int,
  @day datetime
)
as
begin
    select hs.id,iddesk,idcustomer,g.name,c.[lastname]+' '+c.[firstname] as ten,hs.CreateAt,CONVERT(time(0), DATEADD(SECOND, hs.Activetime, 0)) as thoigianhoatdong from (History hs join Desk g on g.id=hs.iddesk and g.iduser=@user and CONVERT(VARCHAR(10), hs.CreateAt, 103)= CONVERT(VARCHAR(10), @day, 103)) join Customer c on hs.idcustomer=c.id
end
GO
/****** Object:  StoredProcedure [dbo].[getStaticalineachDayinYear]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getStaticalineachDayinYear]
(
    @user int,
    @year int
)
as
begin
   declare @temp table ([month] int,sl int)
   declare @i int=0
   while(@i<13)
   begin
     insert into @temp select @i,isnull(sum(sumofday),0) from Statical where MONTH(createat)=@i 
     set @i=@i+1
   end
   select * from @temp
end
GO
/****** Object:  StoredProcedure [dbo].[getStaticalinQuarter]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getStaticalinQuarter]
(
    @user int,
    @year int
)
as
begin
   
   declare @temp table ([quarter] int,sl int)
   declare @q1 int
   declare @q2 int
   declare @q3 int
   declare @q4 int
   select @q1=isnull(Sum(sumofday),0)  from Statical where year(createat)=@year and MONTH(createat)<4 and MONTH(createat)>0 
   insert into @temp values (1,@q1)
   select @q2=isnull(Sum(sumofday),0)  from Statical where year(createat)=@year and MONTH(createat)<7 and MONTH(createat)>3 
   insert into @temp values (2,@q2)
   select @q3=isnull(Sum(sumofday),0)  from Statical where year(createat)=@year and MONTH(createat)<10 and MONTH(createat)>6
   insert into @temp values (3,@q3)
   select @q4=isnull(Sum(sumofday),0)  from Statical where year(createat)=@year and MONTH(createat)<13 and MONTH(createat)>9 
   insert into @temp values (3,@q4)
   select * from @temp
end
GO
/****** Object:  StoredProcedure [dbo].[getuserid]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getuserid]
(
  @username varchar(50)
)
as
begin
  select id from [User] where username=@username
end
GO
/****** Object:  StoredProcedure [dbo].[InsertandgetInformation]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertandgetInformation]
(
  @iduser int,
  @name nvarchar(50)
)
as 
begin
  insert desk ([status],locationx,locationy,iduser,[name],createat,updateat,available) values(1,10,10,@iduser,@name,GETDATE(),GETDATE(),1)
  select * from desk where id in (select Max(id) from desk)
end
GO
/****** Object:  StoredProcedure [dbo].[insertCustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertCustomer]
(
  @id varchar(20),
  @ho nvarchar(500),
  @ten nvarchar(20),
  @sdt varchar(15),
  @email varchar(30),
  @dc nvarchar(1000),
  @ns varchar(20),
  @ca datetime,
  @sex int,
  @user int,
  @idlkh int,
  @available int,
  @temp as dbo.newtempCustomerHealth readonly
)
as 
begin
  insert into Customer(code,[lastname],[firstname],[phone],[email],[address],[birthday],CreateAt,[type],[sex],[iduser],[available]) values (@id,@ho,@ten,@sdt,@email,@dc,@ns,@ca,@idlkh,@sex,@user,@available)
  declare @nid int
  select @nid=id from Customer where id in(select Max(id) from Customer)
  DECLARE @ntemp newtempCustomerHealth
  insert into @ntemp select * from @temp
  update @ntemp set createat=getdate(),idcustomer=@nid
  insert into HealCustomer(idcustomer,idhealth,createat) select idcustomer,idhealth,createat from @ntemp
end
GO
/****** Object:  StoredProcedure [dbo].[InsertDeskCustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[InsertDeskCustomer]
(
   @idghe varchar(10),
   @idkh varchar(10),
   @tg datetime
)
as
begin
  if not exists (select * from DeskCustomer where idcustomer=@idkh)
      insert into DeskCustomer values(@idghe,@idkh,@tg)
  else 
      RAISERROR(N'Khách hàng đang hoạt động',16,1)
end
GO
/****** Object:  StoredProcedure [dbo].[InsertHeath]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertHeath]
(
   @name nvarchar(100)
)
as
begin
   insert into Health([name],createat,updateat) values (@name,GETDATE(),GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[InsertTypeCustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertTypeCustomer]
(@name nvarchar(100))
as
begin
 insert into TypeCustomer([name],available,createat,updateat) values (@name,1,getdate(),GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[InsertWorkProcess]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertWorkProcess]
(
   @user int,
   @ngay datetime
)
as 
begin
  declare @sum int
  declare @khtl varchar(50) =''
  declare @khm int 
  declare @check int = dbo.CheckWorkProcess(@user,@ngay)
  if(@check>0)
    delete from Statical where iduser=@user and CONVERT(VARCHAR(10),CreateAt, 103)=CONVERT(VARCHAR(10),@ngay, 103)
  select @khm=count(*) from Customer where CONVERT(VARCHAR(10), CreateAt, 103)= CONVERT(VARCHAR(10),@ngay, 103) and iduser=@user
  declare @Temp Table ([type] int,sl int)
  insert into @Temp select distinct b.[type],count(distinct idcustomer) as sl from History a join Customer b on a.idcustomer = b.id and b.iduser=@user and CONVERT(VARCHAR(10),a.CreateAt, 103)= CONVERT(VARCHAR(10),@ngay, 103) group by (b.[type])
  select @sum = sum(sl) from @Temp
  declare @i int =0
  declare @n int 
  select @n=count(*) from @Temp
  while(@i<@n-1)
  begin
	  select top 1 @khtl=@khtl+CAST([type] AS varchar)+':'+CAST(sl AS varchar)+',' from @Temp
	  DELETE TOP(1) from @Temp
	  set @i = @i+1
  end
  select top 1 @khtl=@khtl+CAST([type] AS varchar)+':'+CAST(sl AS varchar) from @Temp
  DELETE TOP(1) from @Temp
  insert into Statical values(@ngay,@khm,@khtl,@user,@sum)
end
GO
/****** Object:  StoredProcedure [dbo].[maintenance]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[maintenance]
(
   @id int
)
as
begin
  update Desk set [status]=0,updateat=GETDATE() where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[savedesklocation]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[savedesklocation]
(
  @TempTable AS dbo.deskLocation READONLY
)
AS
BEGIN

    Update desk set locationx=r.LX,locationy=r.LY  from @TempTable r  where desk.id = r.id
END
GO
/****** Object:  StoredProcedure [dbo].[updateCustomer]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[updateCustomer]
(
  @id int,
  @code varchar(20),
  @ho nvarchar(500),
  @ten nvarchar(20),
  @sdt varchar(15),
  @email varchar(30),
  @dc nvarchar(1000),
  @ns varchar(20),
  @ca datetime,
  @sex int,
  @user int,
  @idlkh int,
  @available int,
  @temp as dbo.newtempCustomerHealth readonly
)
as 
begin
  update Customer set code=@code,lastname=@ho,firstname=@ten,phone=@sdt,email=@email,[address]=@dc,[birthday]=@ns,updateat=@ca,sex=@sex,iduser=@user,[type]=@idlkh,[available]=@available where id=@id
  DECLARE @ntemp newtempCustomerHealth
  insert into @ntemp select * from @temp
  update @ntemp set createat=getdate(),idcustomer=@id
  delete HealCustomer from HealCustomer where idcustomer=@id
  insert into HealCustomer(idcustomer,idhealth,createat) select idcustomer,idhealth,createat from @ntemp
end
GO
/****** Object:  StoredProcedure [dbo].[updateDesk]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateDesk]
(
  @id  int,
  @status int,
  @name nvarchar(200)
)
as 
begin
   update Desk set [name]=@name,[status]=@status where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[updateHealth]    Script Date: 7/30/2020 1:35:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateHealth]
( 
  @id int,
  @firstname nvarchar(200),
  @ngay datetime
)
as
begin
  update Health set name=@firstname,createat=@ngay where id=@id
end
GO
USE [master]
GO
ALTER DATABASE [2020] SET  READ_WRITE 
GO
