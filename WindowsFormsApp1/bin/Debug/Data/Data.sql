USE [master]
GO
/****** Object:  Database [vietnhatjp]    Script Date: 27/08/2020 1:11:48 PM ******/
if exists(select * from sys.sysdatabases where name ='vietnhatjp')
    begin
    use master;

    alter database vietnhatjp
    set single_user with rollback immediate;

    drop database vietnhatjp;

    end
CREATE DATABASE [vietnhatjp]
 go
 use [vietnhatjp]
 go

 /****** Object:  Table [dbo].[MyTable]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[createat] [datetime] NULL,
	[updateat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
ALTER TABLE MyTable ADD CONSTRAINT UQ_Name UNIQUE ([name])
GO
 /****** Object:  DdlTrigger [Tr_CreateNewTableByHost]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [Tr_CreateNewTableByHost]  
ON DATABASE  
FOR CREATE_TABLE  
AS  
BEGIN  
 DECLARE @Table SYSNAME = eventdata().value('(/EVENT_INSTANCE/ObjectName)[1]', 'sysname');
 insert into [MyTable] select [name],create_date,modify_date from sys.tables where [name]=@Table
end 

GO
DISABLE TRIGGER [Tr_CreateNewTableByHost] ON DATABASE
GO
/****** Object:  DdlTrigger [Tr_DropTableByHost]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [Tr_DropTableByHost]  
ON DATABASE  
FOR Drop_Table 
AS  
BEGIN
    DECLARE @Table SYSNAME = eventdata().value('(/EVENT_INSTANCE/ObjectName)[1]', 'sysname');
	delete from [MyTable] where [name]=@Table
end 

GO
DISABLE TRIGGER [Tr_DropTableByHost] ON DATABASE
GO
ENABLE TRIGGER [Tr_CreateNewTableByHost] ON DATABASE
GO
ENABLE TRIGGER [Tr_DropTableByHost] ON DATABASE
GO
USE [master]
GO
ALTER DATABASE [vietnhatjp] SET  READ_WRITE 
GO
Use[vietnhatjp]
Go
/****** Object:  UserDefinedTableType [dbo].[deskLocation]    Script Date: 27/08/2020 1:11:48 PM ******/
CREATE TYPE [dbo].[deskLocation] AS TABLE(
	[id] [varchar](10) NULL,
	[LX] [int] NULL,
	[LY] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[firstdayofWeek]    Script Date: 27/08/2020 1:11:48 PM ******/
CREATE TYPE [dbo].[firstdayofWeek] AS TABLE(
	[id] [int] NULL,
	[day] [datetime] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[newtempCustomerHealth]    Script Date: 27/08/2020 1:11:48 PM ******/
CREATE TYPE [dbo].[newtempCustomerHealth] AS TABLE(
	[idcustomer] [int] NULL,
	[idhealth] [int] NULL,
	[name] [varchar](50) NULL,
	[createat] [datetime] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[PermissionTable]    Script Date: 27/08/2020 1:11:48 PM ******/
create TYPE [dbo].[PermissionTable1] AS TABLE(
	[iduser] [int] NULL,
	[idtable] [int] NULL,
	[view] [int] NULL,
	[insert] [int] NULL,
	[update] [int] NULL,
	[delete] [int] NULL,
	[option] [int] NULL
)
go

/****** Object:  UserDefinedTableType [dbo].[tempCustomerHealth]    Script Date: 27/08/2020 1:11:48 PM ******/
CREATE TYPE [dbo].[tempCustomerHealth] AS TABLE(
	[idcustomer] [int] NULL,
	[idhealth] [int] NULL,
	[createat] [datetime] NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[countUSerinBranch]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[countUSerinBranch](
  @idbranch int)
  returns int
  begin
    declare @count int
	select @count=Count(*) from [User] us join Groupuser gu on us.idgroup=gu.id and gu.idbranch=@idbranch
	return @count
  end

GO
/****** Object:  UserDefinedFunction [dbo].[CheckCustomerinDay]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create function [dbo].[CheckCustomerinDay] 
(
    @user int,
	@mkh int
)
returns int
begin
   declare @check int
   select @check = count(*) from History hs join Desk d on hs.iddesk=d.id and Cast(hs.createat as date)=Cast(GETDATE() as date) and idcustomer=@mkh and d.iduser=@user
   return @check
end

GO
/****** Object:  UserDefinedFunction [dbo].[CheckExistinDeskCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[CheckExistStatical_func]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[CheckExistStatical_func]
(
    @user int,
	@date date
)
returns int
begin
   declare @check int
   declare @check1 int
   select @check=count(*) from Statical where iduser=@user
   select @check1=count(*) from History hs join Desk d on  d.id=hs.iddesk and d.iduser=@user
   if(@check1=0 and @check1=0)
   begin
     return 3
   end
   declare @max date
   select @max=MAX(Cast(createat as date)) from History 
   if(@max>Cast(GETDATE() as date)) 
   begin
     return 4
   end
   declare @min date
   select @min=MIN(Cast(createat as date)) from History 
   if(@min>@date) 
   begin
     return 3
   end

   select @check=count(*) from Statical where Cast(createat as date)= @date and iduser=@user
   select @check1=count(*) from History hs join Desk d on  d.id=hs.iddesk and Cast(hs.createat as date)= @date and d.iduser=@user
   if(@check1=0 and @date<>Cast(GETDATE() as date))
   begin
     return 2
   end

   if(@check1>0 and @check=0 and @date<>Cast(GETDATE() as date))
   begin
     return 1
   end
   if(@check1>0 and @check>0 and @date<>Cast(GETDATE() as date))
   begin
     return 3
   end
   
   return 0
end

GO
/****** Object:  UserDefinedFunction [dbo].[CheckWorkProcess]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[Ftimbenh]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[Ftimtatca]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[getAllDayinWeek]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[getFirstDayofWeek]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[GetNumberofWeek]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[getTimebD]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[GetUnsignString]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[Login]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[Login]
(
   @username varchar(50),
   @password varchar(50)
)
returns int
as
begin
  declare @check int
  select @check=count(*) from [User] where username=@username and passw=@password and available=1
  if(@check>0)
     return 1
 
  declare @check1 int
  select @check1=count(*) from [User] where available=1
  if(@check1=0)
     return -1
   return 0
end
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Set Ansi_padding on
go
CREATE TABLE [dbo].[Branch](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](1000) NULL,
	[createat] [datetime] NULL,
	[updateat] [datetime] NULL,
	[apptoken] [varchar](50) NULL,
    [usetoken] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
go
alter table Branch add code nvarchar(50) 
go 
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
	[customerid] [nvarchar](50) NOT NULL,
	[available] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Desk]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Desk](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [varchar](50) NULL DEFAULT ((0)),
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeskCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Set Ansi_padding on
go
CREATE TABLE [dbo].[DeskCustomer](
	[iddesk] [int] NULL,
	[idcustomer] [int] NULL,
	[activetime] [varchar](50) NULL,
	[createat] [datetime] NULL
) ON [PRIMARY]
GO
alter table DeskCustomer add available int default 1

GO
/****** Object:  Table [dbo].[Groupuser]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Set Ansi_padding on
go
CREATE TABLE [dbo].[Groupuser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[idbranch] [int] NULL,
	[createat] [datetime] NULL,
	[updateat] [datetime] NULL,
	[available] [int] NULL DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HealCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Set Ansi_padding on
go
CREATE TABLE [dbo].[HealCustomer](
	[idcustomer] [int] NULL,
	[idhealth] [int] NULL,
	[createat] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Health]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Set Ansi_padding on
go
CREATE TABLE [dbo].[Health](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[createat] [datetime] NULL,
	[updateat] [datetime] NULL,
	[available] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[History]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Permission]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Set Ansi_padding on
go
CREATE TABLE [dbo].[Permission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[iduser] [int] NULL,
	[idtable] [int] NULL,
	[view] [int] NULL DEFAULT ((0)),
	[insert] [int] NULL DEFAULT ((0)),
	[delete] [int] NULL DEFAULT ((0)),
	[update] [int] NULL DEFAULT ((0)),
	[option] [int] NULL DEFAULT ((0)),
	[createat] [datetime] NULL,
	[updateat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Statical]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Set Ansi_padding on
go
CREATE TABLE [dbo].[Statical](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[createat] [datetime] NULL,
	[newmembers] [int] NULL,
	[iduser] [int] NULL,
	[sumofday] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StaticalTypeCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Set Ansi_padding on
go
CREATE TABLE [dbo].[StaticalTypeCustomer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idstatical] [int] NULL,
	[idtype] [int] NULL,
	[amount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TypeCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Set Ansi_padding on
go
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
/****** Object:  Table [dbo].[User]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[passw] [varchar](50) NULL,
	[lastname] [nvarchar](500) NULL,
	[firstname] [nvarchar](20) NULL,
	[email] [varchar](100) NULL,
	[address] [nvarchar](1000) NULL,
	[birthday] [varchar](20) NULL,
	[sex] [int] NULL,
	[createat] [datetime] NULL,
	[updateat] [datetime] NULL,
	[idgroup] [int] NULL,
	[phone] [varchar](20) NULL,
	[available] [int] NULL DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_br_cu] FOREIGN KEY([iduser])
REFERENCES [dbo].[Branch] ([id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_br_cu]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_type] FOREIGN KEY([type])
REFERENCES [dbo].[TypeCustomer] ([id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_type]
GO
ALTER TABLE [dbo].[Desk]  WITH CHECK ADD  CONSTRAINT [FK_ql] FOREIGN KEY([iduser])
REFERENCES [dbo].[Branch] ([id])
GO
ALTER TABLE [dbo].[Desk] CHECK CONSTRAINT [FK_ql]
GO
ALTER TABLE [dbo].[DeskCustomer]  WITH CHECK ADD FOREIGN KEY([idcustomer])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[DeskCustomer]  WITH CHECK ADD FOREIGN KEY([iddesk])
REFERENCES [dbo].[Desk] ([id])
GO
ALTER TABLE [dbo].[Groupuser]  WITH CHECK ADD FOREIGN KEY([idbranch])
REFERENCES [dbo].[Branch] ([id])
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
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD FOREIGN KEY([idtable])
REFERENCES [dbo].[MyTable] ([id])
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD FOREIGN KEY([iduser])
REFERENCES [dbo].[Groupuser] ([id])
GO
ALTER TABLE [dbo].[Statical]  WITH CHECK ADD  CONSTRAINT [FK_User] FOREIGN KEY([iduser])
REFERENCES [dbo].[Branch] ([id])
GO
ALTER TABLE [dbo].[Statical] CHECK CONSTRAINT [FK_User]
GO
ALTER TABLE [dbo].[StaticalTypeCustomer]  WITH CHECK ADD  CONSTRAINT [FK_statical] FOREIGN KEY([idstatical])
REFERENCES [dbo].[Statical] ([id])
GO
ALTER TABLE [dbo].[StaticalTypeCustomer] CHECK CONSTRAINT [FK_statical]
GO
ALTER TABLE [dbo].[StaticalTypeCustomer]  WITH CHECK ADD  CONSTRAINT [FK_type_tkCustomer] FOREIGN KEY([idtype])
REFERENCES [dbo].[TypeCustomer] ([id])
GO
ALTER TABLE [dbo].[StaticalTypeCustomer] CHECK CONSTRAINT [FK_type_tkCustomer]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([idgroup])
REFERENCES [dbo].[Groupuser] ([id])
GO
/****** Object:  StoredProcedure [dbo].[active]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[CheckCustomerDesk]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[CheckExistStatical]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CheckExistStatical]
(
    @user int,
	@date date
)
as
begin
   declare @check int
   declare @check1 int
   select @check=count(*) from Statical where Cast(createat as date)= @date and iduser=@user
   select @check1=count(*) from History hs join Desk d on  d.id=hs.iddesk and Cast(hs.createat as date)= @date and d.iduser=@user
   if(@check1>0 and @check=0 and @date<>Cast(GETDATE() as date))
   begin
     exec getSumofday @user,@date
   end
   
end

GO
/****** Object:  StoredProcedure [dbo].[deleteCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteCustomerDesk]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[deleteDesk]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteGroupUser]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteGroupUser]
(
  @idgroup int
)
as
begin
  declare @ad nvarchar(50)
  select @ad=[name] from Groupuser where id=@idgroup
  if(@ad='Admin')
  begin
        RAISERROR(N'Không được vô hiệu hóa Admin',16,1)
  end
  else
  begin
        update Groupuser set available=0 where id=@idgroup
  end
end

GO
/****** Object:  StoredProcedure [dbo].[deleteHealth]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteHealth]
( 
  @id int
)
as
begin
  update Health set available=0 where id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteTypeCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DeleteTypeCustomer]
(@id int)
as
begin
 update TypeCustomer set available=0,updateat=GETDATE() where id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[deleteUser]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[deleteUser]
(
  @id int
)
as 
begin
  declare @ad nvarchar(50)
  select @ad=gu.name from [User] us join Groupuser gu on gu.id=us.idgroup
  if @ad='Admin'
  begin
       RAISERROR(N'Không được vô hiệu hóa tài khoản Admin',16,1)
  end
  else
  begin
    update [User] set available=0 where id=@id
  end
end

GO

/****** Object:  StoredProcedure [dbo].[DoiMatKhau]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DoiMatKhau]
(
  @id int,
  @mkc varchar(50),
  @mkm varchar(50)
)
as
begin
   declare @hash varchar(50)
   declare @check varchar(50)
   select @hash=CONVERT(VARCHAR(32), HashBytes('MD5', @mkc), 2)
   select @check=passw from [User] where id=@id
   if(@hash=@check)
   begin
       update [User] set passw=CONVERT(VARCHAR(32), HashBytes('MD5', @mkm), 2) where id=@id
   end
end

GO
/****** Object:  StoredProcedure [dbo].[DoiMatKhau2]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DoiMatKhau2]
(
  @id int,
  @mkm varchar(50)
)
as
begin
   update [User] set passw=CONVERT(VARCHAR(32), HashBytes('MD5', @mkm), 2) where id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[FindHealth]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[FindHealth]
(
  @ten nvarchar(50)
)
as 
begin
  declare @rs int
  select @rs = dbo.Ftimbenh(@ten);
  if(@rs>0)
    select a.id,a.[name] from Health a,(select id,dbo.GetUnsignString([name]) as tb from Health) b  where a.id=b.id and b.tb like '%'+@ten+'%' 
  else
    select a.id,a.[name] from [Health] a where a.[name] like N'%'+@ten+'%' 
end

GO
GO
Create proc [dbo].[FindHealth1]
(
  @ten nvarchar(50),
  @temp as dbo.newtempCustomerHealth readonly
)
as 
begin
  declare @rs int
  select @rs = dbo.Ftimbenh(@ten);
  if(@rs>0)
    select a.id,a.[name] from Health a,(select id,dbo.GetUnsignString([name]) as tb from Health) b  where a.id=b.id and b.tb like '%'+@ten+'%' and a.id not in (select idhealth from @temp) and a.available=1
  else
    select a.id,a.[name] from [Health] a where a.[name] like N'%'+@ten+'%' and a.id not in (select idhealth from @temp) and a.available=1
end

GO
/****** Object:  StoredProcedure [dbo].[FindInfor]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[FindInfor]
(
  @string nvarchar(50),
  @user  int
)
as 
begin
  declare @rs int
  select @rs = dbo.Ftimtatca(@string);
  if(@rs>0)
   select a.id,a.customerid,code,a.CreateAt,[firstname],[lastname],phone,email,[birthday],case when sex = 0 then N'Nữ' when sex = 1 then 'Nam' end as sex,[address],[lastname]+' '+[firstname] as hoten,a.[type],c.id as idlkh,a.available from TypeCustomer c,Customer a,(select id,dbo.GetUnsignString([lastname]+' '+[firstname]+' '+[phone]+' '+[email]+' '+[code]+' '+[customerid]) as infor from Customer) b  where a.id=b.id and a.iduser=@user and b.infor like '%'+@string+'%' and c.id=a.[type]
  else
     select a.id,a.customerid,code,a.CreateAt,[firstname],[lastname],phone,email,[birthday],case when sex = 0 then N'Nữ' when sex = 1 then 'Nam' end as sex,[address],[lastname]+' '+[firstname] as hoten,a.[type],b.id as idlkh,a.available from Customer a join TypeCustomer b on b.id=a.[type] and a.[lastname]+' '+a.[firstname]+' '+a.[phone]+' '+[email]+' '+[code]+' '+[customerid] like N'%'+@string+'%'and a.iduser=@user
end
Go
/****** Object:  StoredProcedure [dbo].[FindInfor]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[FindInfor1]
(
  @string nvarchar(50),
  @user  int
)
as 
begin
  declare @rs int
  select @rs = dbo.Ftimtatca(@string);
  if(@rs>0)
   select a.id,code,a.CreateAt,[firstname],[lastname],phone,email,[birthday],case when sex = 0 then N'Nữ' when sex = 1 then 'Nam' end as sex,[address],[lastname]+' '+[firstname] as hoten,a.[type],c.id as idlkh,a.available from TypeCustomer c,Customer a,(select id,dbo.GetUnsignString([lastname]+' '+[firstname]+' '+[phone]+' '+[email]+' '+[code]+' '+[customerid]) as infor from Customer) b  where a.id=b.id and a.iduser=@user and a.available=1 and b.infor like '%'+@string+'%' and c.id=a.[type]
  else
     select a.id,code,a.CreateAt,[firstname],[lastname],phone,email,[birthday],case when sex = 0 then N'Nữ' when sex = 1 then 'Nam' end as sex,[address],[lastname]+' '+[firstname] as hoten,a.[type],b.id as idlkh,a.available from Customer a join TypeCustomer b on b.id=a.[type] and a.available=1 and a.[lastname]+' '+a.[firstname]+' '+a.[phone]+' '+[email]+' '+[code]+' '+[customerid] like N'%'+@string+'%'and a.iduser=@user
end
Go
/****** Object:  StoredProcedure [dbo].[getAllBranch]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[getAllBranch]
  as
  begin
     select * from Branch
  end

GO
/****** Object:  StoredProcedure [dbo].[getallDayinMonth]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[getAllHistoryinMonth]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[getAllHistoryinMonthbyYear]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[getAllHistoryinQuater]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetAllStaticalinMonthofYear]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetAllStaticalinMonthofYear]
( 
    @year int,
	@user int
)
as
begin
  declare @table Table ([month] int,[sum] int)
  declare @i int=1
  while @i<=12
  begin
     insert into @table values (@i,0)
	 set @i=@i+1
  end
  select b.[month],isnull(sum(a.sumofday),0) as [Sum],ISNULL(sum(a.newmembers),0) as [sum1] from @table b left join Statical a on year(createat)=@year and iduser=@user and month(createat)=b.[month] group by (b.month)
end

GO
/****** Object:  StoredProcedure [dbo].[getAllUserinBranch]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getAllUserinBranch]
(
   @idbranch int
)
as
begin
  select us.id as id,username[username],passw,[firstname],[lastname],phone,email,[birthday],case when sex = 0 then N'Nữ' when sex = 1 then 'Nam' end as sex,[address],[lastname]+' '+[firstname] as hoten,gu.[id] as idgroup,gu.[name] as groupname,us.available from [User] us join Groupuser gu on us.idgroup=gu.id and gu.idbranch=@idbranch
end

GO
/****** Object:  StoredProcedure [dbo].[getAllUserinBranch]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getAllUserinBranch1]
(
   @idbranch int,
   @iduser int
)
as
begin
  select us.id as id,username[username],passw,[firstname],[lastname],phone,email,[birthday],case when sex = 0 then N'Nữ' when sex = 1 then 'Nam' end as sex,[address],[lastname]+' '+[firstname] as hoten,gu.[id] as idgroup,gu.[name] as groupname,us.available from [User] us join Groupuser gu on us.idgroup=gu.id and gu.idbranch=@idbranch and us.id!=@iduser
end
go
/****** Object:  StoredProcedure [dbo].[getamountofCustomerbyWeekinMonth]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getamountofCustomerbyWeekinMonth]
(
      @user int,
      @table as dbo.[firstdayofweek] readonly
)
as
begin
   declare @weekinfor table ([week] varchar(20),sl int,sl1 int,startat date)
   declare @typeinfor table ([week] int,[type] int,sl int)

   declare @i int=0 
   declare @amount int 
   select @amount=count(*) from @table
   while @i<@amount
   begin
     declare @sum int =0
	 declare @sum1 int =0
	 declare @date date
	 select @date=[day] from @table where id=@i
	 select @sum1=Sum(newmembers),@sum=Sum(sumofday) from Statical where cast(createat as date)>=@date and cast(createat as date)<=DATEADD(day,7,@date) and iduser=@user
	 insert into @weekinfor select 'Week '+cast(@i+1 as varchar(20)),isnull(@sum,0),isnull(@sum1,0),@date
	 insert into @typeinfor select @i,c.id,isnull(sum(b.amount),0) from (Statical a join StaticalTypeCustomer b on a.id=b.idstatical and a.iduser=@user and cast(a.createat as date)>=@date and cast(a.createat as date)<=DATEADD(day,7,@date)) right join TypeCustomer c on c.id=b.idtype group by (c.id)
	 set @i=@i+1

   end
   select * from @weekinfor
end

GO
/****** Object:  StoredProcedure [dbo].[getBranchId]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getBranchId](@id int)
as
begin
  select gu.idbranch from Groupuser gu join [User] u on gu.id=u.idgroup and u.id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[getCustomerInfor]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[getdeskbyuserId]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[getdeskbyuserId]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getdeskbyuserId1]
(
  @iduser int
)
as
begin
select * from desk where iduser =@iduser
end

GO
/****** Object:  StoredProcedure [dbo].[getdeskbyuserId]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[restoredesk]
(
  @idghe int
)
as
begin
 update desk set available=1,locationx=30,locationy=30,updateat=GETDATE() where id=@idghe
end

GO
/****** Object:  StoredProcedure [dbo].[getdeskbyuserId]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[restorehealth]
(
  @id int
)
as
begin
 update Health set available=1,updateat=GETDATE() where id=@id
end

GO

/****** Object:  StoredProcedure [dbo].[getdeskbyuserId]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[restoretypecustomer]
(
  @id int
)
as
begin
 update TypeCustomer set available=1,updateat=GETDATE() where id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[getDeskInfobyId]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[getGroupId]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getGroupId](@id int)
as
begin
  select idgroup from [User] where id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[getGroupUser]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getGroupUser](@idbranch int)
as
begin
  select * from Groupuser where idbranch=@idbranch
end


GO
/****** Object:  StoredProcedure [dbo].[getGroupUser1]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getGroupUser1](@idbranch int)
as
begin
  select * from Groupuser where idbranch=@idbranch and available=1
end
GO
/****** Object:  StoredProcedure [dbo].[getHistoryinDay]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[getHistoryinDay]
(
  @user int,
  @day datetime
)
as
begin
    select hs.id,iddesk,idcustomer,g.name,c.[lastname]+' '+c.[firstname] as ten,hs.CreateAt,CONVERT(time(0), DATEADD(SECOND, hs.Activetime, 0)) as thoigianhoatdong from (History hs join Desk g on g.id=hs.iddesk and g.iduser=@user and CONVERT(VARCHAR(10), hs.CreateAt, 103)= CONVERT(VARCHAR(10), @day, 103)) join Customer c on hs.idcustomer=c.id
end

GO
/****** Object:  StoredProcedure [dbo].[getinfoHealthafterInsert]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetListCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetListCustomer]
(@user int)
as
begin
 select a.id,customerid,code,a.CreateAt,[firstname],[lastname],phone,email,[birthday],case when sex = 0 then N'Nữ' when sex = 1 then 'Nam' end as sex,[address],[lastname]+' '+[firstname] as hoten,b.[name] as nameoftype,b.id as idlkh,a.available from [Customer] a join TypeCustomer b on a.[type] = b.id and a.iduser=@user order by a.CreateAt Desc
end

GO
/****** Object:  StoredProcedure [dbo].[GetListCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Restorecustomer]
(@id int)
as
begin
  update Customer set available=1,createat=GETDATE() where id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[GetListCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RestoregroupUser]
(@id int)
as
begin
  update Groupuser set available=1,createat=GETDATE() where id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[GetListCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RestoreUser]
(@id int)
as
begin
  update [User] set available=1,createat=GETDATE() where id=@id
end

GO

/****** Object:  StoredProcedure [dbo].[getlistdeskcustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[getlistHealthAvailable]    Script Date: 27/08/2020 1:11:48 PM ******/
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
   select id,[name],createat from Health where id not in (select idhealth from @temp) and available=1 order by createat desc
end

GO
/****** Object:  StoredProcedure [dbo].[getListHeath]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getListHeath]
as
begin
   select id,[name],createat,available from Health where available=1 order by createat desc
end

GO
/****** Object:  StoredProcedure [dbo].[getListHeath]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getListHeath1]
as
begin
   select id,[name],createat,available from Health order by createat desc
end

GO
/****** Object:  StoredProcedure [dbo].[getListHeathofCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
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
   select a.idcustomer,a.idhealth,b.[name],a.[createat] from HealCustomer a join Health b on a.idhealth=b.id and idcustomer=@idcs and b.available=1 order by a.createat desc
end

GO
/****** Object:  StoredProcedure [dbo].[getlistPermission]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getlistPermission]
as
begin
  select id,[name] from MyTable where id not in (select id from MyTable where [name]='MyTable' or [name]='StaticalTypeCustomer')
end

GO
/****** Object:  StoredProcedure [dbo].[getListstatistical]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetListTypeCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetListTypeCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetListTypeCustomer1]
as
begin
 select * from TypeCustomer 
end

GO
/****** Object:  StoredProcedure [dbo].[getminmaxYear]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[getmonthandyear]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetnumberofCustomerinDayofWeek]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetnumberofCustomerinDayofWeek](@pass date,@user int)
as 
begin
   DECLARE @dayofWeek TABLE (ngay datetime) 
   insert into @dayofWeek
   select * from dbo.getAllDayinWeek(@pass) order by CONVERT(datetime,ngay,103)
   select CONVERT(datetime,b.ngay,103) as ngay,ISNULL(a.sumofday,0) from Statical a right join @dayofWeek b on  CONVERT(varchar,a.createat,103) =CONVERT(varchar,b.ngay,103) and a.iduser=@user
end

GO
/****** Object:  StoredProcedure [dbo].[getPermissionById]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getPermissionById]
(
   @idgroup varchar(50)
)
as
begin
   select mt.id,mt.name as permission,[view],[insert],[update],[delete],[option] from (MyTable mt join Permission pm on mt.id=pm.idtable and iduser=@idgroup and pm.idtable not in (select id from MyTable where [name]='MyTable' or [name]='StaticalTypeCustomer'))
end

GO
/****** Object:  StoredProcedure [dbo].[getPermissionbyIdUser]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getPermissionbyIdUser]
(
  @id int
)
as
begin
  select mt.id,[name],[view],[insert],[update],[delete],[option] from Permission p join MyTable mt  on iduser=@id and p.idtable=mt.id order by idtable
end

GO
/****** Object:  StoredProcedure [dbo].[getStaticalbyDay]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getStaticalbyDay](@iduser int,@date datetime)
as
begin 
  select isnull(newmembers,0),isnull(sumofday,0),id from Statical a where CONVERT(VARCHAR(10), a.createat, 103)= CONVERT(VARCHAR(10), @date, 103)
end

GO
/****** Object:  StoredProcedure [dbo].[getStaticalineachYear]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getStaticalineachYear]
(
    @user int,
    @year int
)
as
begin
   declare @temp table ([year] int,[sum] int,[sum1] int)
   declare @i int=0
   While @i<=10
   begin
      insert into @temp select distinct Year(b.createat),isnull(sum(sumofday),0),isnull(sum(newmembers),0) from Statical b where b.iduser=@user and Year(b.createat)=@year+@i group by Year(b.createat)
	  set @i=@i+1
   end
   select * from @temp
end

GO
/****** Object:  StoredProcedure [dbo].[getStaticalinQuarter]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getStaticalinQuarter]
(
    @user int,
    @year int
)
as
begin
   declare @temp table ([quarter] int,[sum] int,[sum1] int)
   declare @q1 int
   declare @q1a int
   declare @q2 int
   declare @q2a int
   declare @q3 int
   declare @q3a int
   declare @q4 int
   declare @q4a int
   select @q1=isnull(Sum(sumofday),0),@q1a=ISNULL(Sum(newmembers),0)  from Statical where year(createat)=@year and MONTH(createat)<4 and MONTH(createat)>0 and iduser=@user
   insert into @temp values (1,@q1,@q1a)
   select @q2=isnull(Sum(sumofday),0),@q2a=ISNULL(Sum(newmembers),0)  from Statical where year(createat)=@year and MONTH(createat)<7 and MONTH(createat)>3 and iduser=@user
   insert into @temp values (2,@q2,@q2a)
   select @q3=isnull(Sum(sumofday),0),@q3a=ISNULL(Sum(newmembers),0)  from Statical where year(createat)=@year and MONTH(createat)<10 and MONTH(createat)>6 and iduser=@user
   insert into @temp values (3,@q3,@q3a)
   select @q4=isnull(Sum(sumofday),0),@q4a=ISNULL(Sum(newmembers),0)   from Statical where year(createat)=@year and MONTH(createat)<13 and MONTH(createat)>9 and iduser=@user
   insert into @temp values (4,@q4,@q4a)
   select * from @temp
end

GO
/****** Object:  StoredProcedure [dbo].[getSumofday]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getSumofday](   
   @user int,
   @ngay datetime
)as
begin
SELECT SUM(b.sl) as sl
FROM(
    select distinct b.[type],count(distinct idcustomer) as sl from History a join Customer b on a.idcustomer = b.id and b.iduser=@user and CONVERT(VARCHAR(10),a.CreateAt, 103)= CONVERT(VARCHAR(10),@ngay, 103) group by (b.[type])
) b

select distinct b.[type],c.[name],count(distinct idcustomer) as sl from (History a join Customer b on a.idcustomer = b.id and b.iduser=@user and CONVERT(VARCHAR(10),a.CreateAt, 103)= CONVERT(VARCHAR(10),@ngay, 103))join TypeCustomer c on c.id=b.[type] group by b.[type],c.[name]

select count(*) as khm from Customer where CONVERT(VARCHAR(10), CreateAt, 103)= CONVERT(VARCHAR(10),@ngay, 103) and iduser=@user

end

GO
/****** Object:  StoredProcedure [dbo].[getTypeCustomerbyDay]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getTypeCustomerbyDay](@id int,@idbranch int)
as
begin
   select b.name,a.amount from (StaticalTypeCustomer a join TypeCustomer b on b.id=a.idtype and a.idstatical=@id) join Statical c on c.id=a.idstatical and iduser=@idbranch
end

GO
/****** Object:  StoredProcedure [dbo].[getTypeCustomerinMonth]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getTypeCustomerinMonth](@month int,@year int,@user int)
as
begin
   select idtype as [id],c.[name] as [type],sum(amount) as sl from (StaticalTypeCustomer a join Statical b on a.idstatical=b.id and month(b.createat)=@month and year(b.createat)=@year and b.iduser=@user) join TypeCustomer c on c.id=a.idtype group by idtype,c.[name]
end

GO
/****** Object:  StoredProcedure [dbo].[getTypeCustomerinQuater]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getTypeCustomerinQuater]
(
    @user int,
    @quarter int,
	@year int
)
as
begin
   declare @min int = (@quarter-1)*3
   declare @max int =@min+3
   select idtype as [id],c.name as [type],sum(amount) as sl from (StaticalTypeCustomer b join Statical a on a.id=b.idstatical and month(a.createat)>@min and MONTH(a.createat)<=@max and year(a.createat)=@year and a.iduser=@user) join TypeCustomer c on c.id=b.idtype group by idtype,c.name
end

GO
/****** Object:  StoredProcedure [dbo].[getTypeCustomerinWeek]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getTypeCustomerinWeek](@date date,@user int)
as 
begin
   declare @typeinfor table ([id] int,[type] varchar(20),sl int)
   DECLARE @dayofWeek TABLE (ngay datetime) 
   insert into @dayofWeek
   select * from dbo.getAllDayinWeek(@date) order by CONVERT(datetime,ngay,103)
   insert into @typeinfor(id,[type],sl) select c.id,c.[name],isnull(sum(b.amount),0) from ((Statical a join StaticalTypeCustomer b on a.id=b.idstatical and a.iduser=@user) right join TypeCustomer c on c.id=b.idtype) join @dayofWeek d on d.ngay=cast(a.createat as date) group by c.id,c.[name]
   select * from @typeinfor
end

GO
/****** Object:  StoredProcedure [dbo].[getTypeCustomerinYear]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getTypeCustomerinYear]
(
    @user int,
	@year int
)
as
begin
   select idtype as [id],c.name as [type],sum(amount) as sl from (StaticalTypeCustomer b join Statical a on a.id=b.idstatical and year(a.createat)=@year and a.iduser=@user) join TypeCustomer c on c.id=b.idtype group by idtype,c.name
end

GO
/****** Object:  StoredProcedure [dbo].[getUserbyid]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[getUserbyid]
(
   @id int
)
as
begin
  select us.id as id,username[username],passw,[firstname],[lastname],phone,email,[birthday],case when sex = 0 then N'Nữ' when sex = 1 then 'Nam' end as sex,[address],[lastname]+' '+[firstname] as hoten,gu.[id] as idgroup,gu.[name] as groupname from [User] us join Groupuser gu on us.idgroup=gu.id and us.id=@id and us.available=1
end

GO
/****** Object:  StoredProcedure [dbo].[getuserid]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[insertAdmin]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[insertAdmin](@idbranch int)
  as
  begin
     declare @count int
     select @count=count(*) from Groupuser where name='Admin' and idbranch=@idbranch
	 if(@count=0)
	 begin
	     insert into Groupuser([name],idbranch,createat,updateat) values ('Admin',@idbranch,GETDATE(),GETDATE())
	     insert into Permission(idtable,iduser,[view],[insert],[update],[delete],[option],[createat],[updateat])
		    select mt.id as idtable,gu.id as iduser,1 as [view],1 as [insert] ,1 as [delete],1 as [update] ,1 as [option],GETDATE() as createat,GETDATE() as updateat from MyTable mt,Groupuser gu where mt.id in(select id from MyTable) and gu.id in (select max(id) from Groupuser)
	 end
	 declare @gu int
	 select @gu=max(id) from Groupuser
	 declare @cgu int
	 select @cgu=count(*) from Permission where iduser=@gu
	 if(@count>0 and @cgu=0)
	 begin
	     	     insert into Permission(idtable,iduser,[view],[insert],[update],[delete],[option],[createat],[updateat])
		    select mt.id as idtable,gu.id as iduser,1 as [view],1 as [insert] ,1 as [delete],1 as [update] ,1 as [option],GETDATE() as createat,GETDATE() as updateat from MyTable mt,Groupuser gu where mt.id in(select id from MyTable) and gu.id in (select max(id) from Groupuser)
	 end
  end

GO
/****** Object:  StoredProcedure [dbo].[InsertandgetInformation]    Script Date: 27/08/2020 1:11:48 PM ******/
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
  insert desk ([status],locationx,locationy,iduser,[name],createat,updateat,available) values(1,30,30,@iduser,@name,GETDATE(),GETDATE(),1)
  select * from desk where id in (select Max(id) from desk)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertandgetInformation1]
(
  @iduser int,
  @name nvarchar(50),
  @lx int,
  @ly int
)
as 
begin
  insert desk ([status],locationx,locationy,iduser,[name],createat,updateat,available) values(1,@lx,@ly,@iduser,@name,GETDATE(),GETDATE(),1)
  select * from desk where id in (select Max(id) from desk)
end

GO
/****** Object:  StoredProcedure [dbo].[insertBranch]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[insertBranch]
  (
     @name nvarchar(50),
	 @address nvarchar(1000),
	 @code varchar(50),
	 @apptoken varchar(50),
	 @usetoken varchar(50)
  )
  as
  begin
     insert into Branch(name,address,createat,updateat,code,apptoken,usetoken) values(@name,@address,GETDATE(),GETDATE(),@code,@apptoken,@usetoken)
  end

GO
/****** Object:  StoredProcedure [dbo].[insertCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertCustomer]
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
  @makh nvarchar(50),
  @temp as dbo.newtempCustomerHealth readonly
)
as 
begin
  insert into Health([name],createat,updateat,available) select [name],getDate(),GETDATE(),1 from @temp where [name] in (select [name] from @temp where [name] not in (select [name] from Health))
  insert into Customer(code,[lastname],[firstname],[phone],[email],[address],[birthday],CreateAt,[type],[sex],[iduser],[available],[customerid]) values (@id,@ho,@ten,@sdt,@email,@dc,@ns,@ca,@idlkh,@sex,@user,@available,@makh)
  declare @nid int
  select @nid=id from Customer where id in(select Max(id) from Customer)
  DECLARE @ntemp newtempCustomerHealth
  insert into @ntemp select * from @temp
  update @ntemp set createat=getdate(),idcustomer=@nid
  insert into HealCustomer(idcustomer,idhealth,createat) select idcustomer,b.id,a.createat from @ntemp a join Health b on a.name=b.name 
end
Go

/****** Object:  StoredProcedure [dbo].[InsertDeskCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertDeskCustomer]
(
   @idghe varchar(10),
   @idkh varchar(10),
   @activetime varchar(50),
   @tg datetime
)
as
begin
  if not exists (select * from DeskCustomer where idcustomer=@idkh)
      insert into DeskCustomer(iddesk,idcustomer,createat,activetime,available) values(@idghe,@idkh,@tg,@activetime,1)
  else 
      RAISERROR(N'Khách hàng đang hoạt động',16,1)
end

GO
/****** Object:  StoredProcedure [dbo].[InsertHeath]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertHeath]
(
   @name nvarchar(100)
)
as
begin
   insert into Health([name],createat,updateat,available) values (@name,GETDATE(),GETDATE(),1)
end

GO
/****** Object:  StoredProcedure [dbo].[InsertNewGroupUser]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertNewGroupUser]
(
  @idbranch int,
  @name nvarchar(50),
  @table as PermissionTable1 readonly
)
as
begin
   insert into Groupuser values (@name,@idbranch,GETDATE(),GETDATE(),1)
   declare @idguser int
   select @idguser=id from Groupuser where createat in (select Max(createat) from Groupuser)
   insert into Permission(iduser,idtable,[view],[insert],[delete],[update],[option],createat,updateat) select @idguser,idtable,[view],[insert],[delete],[update],[option],GETDATE(),GETDATE() from @table
   

end

GO
/****** Object:  StoredProcedure [dbo].[InsertTypeCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[insertUser]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertUser]
(
  @ho nvarchar(500),
  @ten nvarchar(20),
  @sdt varchar(15),
  @email varchar(30),
  @dc nvarchar(1000),
  @ns varchar(20),
  @ca datetime,
  @sex int,
  @idlkh int,
  @available int
)
as 
begin
  insert into [User](username,passw,[lastname],[firstname],[phone],[email],[address],[birthday],CreateAt,[idgroup],[sex],[available]) values (@sdt,CONVERT(VARCHAR(32), HashBytes('MD5', @sdt), 2),@ho,@ten,@sdt,@email,@dc,@ns,@ca,@idlkh,@sex,@available)
end

GO
/****** Object:  StoredProcedure [dbo].[InsertWorkProcess]    Script Date: 27/08/2020 1:11:48 PM ******/
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
    delete b from StaticalTypeCustomer b join Statical a on CONVERT(VARCHAR(10),a.createat, 103)=CONVERT(VARCHAR(10),@ngay, 103) and a.id=b.idstatical
    delete from Statical where iduser=@user and CONVERT(VARCHAR(10),CreateAt, 103)=CONVERT(VARCHAR(10),@ngay, 103)
  select @khm=count(*) from Customer where CONVERT(VARCHAR(10), CreateAt, 103)= CONVERT(VARCHAR(10),@ngay, 103) and iduser=@user
  insert into Statical values(@ngay,@khm,@user,0)
  declare @idstatical int
  select @idstatical=id from Statical where id in (select Max(id) from Statical)
  insert into StaticalTypeCustomer(idstatical,idtype,amount) select distinct @idstatical,b.[type],count(distinct idcustomer) as sl from History a join Customer b on a.idcustomer = b.id and b.iduser=@user and CONVERT(VARCHAR(10),a.CreateAt, 103)= CONVERT(VARCHAR(10),@ngay, 103) group by (b.[type])
  select @sum = sum(amount) from StaticalTypeCustomer where idstatical=@idstatical
  update Statical set sumofday=@sum where id=@idstatical
end

GO
/****** Object:  StoredProcedure [dbo].[maintenance]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[savedesklocation]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[updateCustomer]    Script Date: 27/08/2020 updateCustomer1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateCustomer]
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
  @mkh nvarchar(50),
  @temp as dbo.newtempCustomerHealth readonly
)
as 
begin
  insert into Health([name],createat,updateat,available) select [name],getDate(),GETDATE(),1 from @temp where [name] in (select [name] from @temp where [name] not in (select [name] from Health))
  update Customer set code=@code,lastname=@ho,firstname=@ten,phone=@sdt,email=@email,[address]=@dc,[birthday]=@ns,updateat=@ca,sex=@sex,iduser=@user,[type]=@idlkh,[available]=@available,[customerid]=@mkh where id=@id
  DECLARE @ntemp newtempCustomerHealth
  insert into @ntemp select * from @temp
  update @ntemp set createat=getdate(),idcustomer=@id
  delete HealCustomer from HealCustomer where idcustomer=@id
  insert into HealCustomer(idcustomer,idhealth,createat) select idcustomer,b.id,a.createat from @ntemp a join Health b on a.name=b.name 
end
Go
/****** Object:  StoredProcedure [dbo].[updateDesk]    Script Date: 27/08/2020 1:11:48 PM ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateGroupUser]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateGroupUser]
(
  @name nvarchar(50),
  @idgroup int,
  @table as PermissionTable1 readonly
)
as
begin

    MERGE Permission AS pr
    USING @table AS tb
      ON pr.iduser = tb.iduser and pr.idtable=tb.idtable
     WHEN MATCHED THEN
       UPDATE SET [view] = tb.[view] , [insert]=tb.[insert],[update]=tb.[update],[delete]=tb.[delete],[option]=tb.[option],updateat=getDate() 
     WHEN NOT MATCHED BY TARGET THEN
         insert (iduser,idtable,[view],[insert],[delete],[update],[option],createat,updateat) Values (tb.iduser,tb.idtable,tb.[view],tb.[insert],tb.[delete],tb.[update],tb.[option],GETDATE(),GETDATE());
    update [Groupuser] set name=@name where id=@idgroup
end

GO
/****** Object:  StoredProcedure [dbo].[updateHealth]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[updateHealth]
( 
  @id int,
  @name nvarchar(200)
)
as
begin
  update Health set name=@name,updateat=GETDATE() where id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateTypeCustomer]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateTypeCustomer]
(@id int,@name nvarchar(50))
as
begin
 update TypeCustomer set name=@name,updateat=GETDATE() where id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[updateUser]    Script Date: 27/08/2020 1:11:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[updateUser]
(
  @id int,
  @ho nvarchar(500),
  @ten nvarchar(20),
  @sdt varchar(15),
  @email varchar(30),
  @dc nvarchar(1000),
  @ns varchar(20),
  @ca datetime,
  @sex int,
  @idlkh int,
  @available int
)
as 
begin
  update [User] set lastname=@ho,firstname=@ten,phone=@sdt,email=@email,[address]=@dc,[birthday]=@ns,updateat=@ca,sex=@sex,[idgroup]=@idlkh,[available]=@available where id=@id
end

go

create procedure Stop_now
(
  @id int
)
as
begin
  update DeskCustomer set available=0 where iddesk=@id
end
go
create procedure Continue_to_work
(
  @id int
)
as
begin
  update DeskCustomer set available=1 where iddesk=@id
end
go
create TRIGGER preventDuplicate ON Health
AFTER INSERT
AS

if exists ( select * from Health t 
    inner join inserted i on i.name=t.name and i.id <> t.id)
begin
    
    declare @results varchar(200)
	select @results = coalesce(@results + ',', '') +  convert(varchar(200),i.[name]) from inserted i where i.[name] in (select t.[name] from Health t 
    inner join inserted i on i.name=t.name and i.id <> t.id)
	declare @msg varchar(500)
    select @msg = 'Trung Lap '+convert(varchar, @results,101)
    rollback
 
    RAISERROR (@msg, 16, 1);
end
go

create TRIGGER preventDuplicate1 ON TypeCustomer
AFTER INSERT
AS

if exists ( select * from TypeCustomer t 
    inner join inserted i on i.name=t.name and i.id <> t.id)
begin
    
    declare @results varchar(200)
	select @results = coalesce(@results + ',', '') +  convert(varchar(200),i.[name]) from inserted i where i.[name] in (select t.[name] from TypeCustomer t 
    inner join inserted i on i.name=t.name and i.id <> t.id)
	declare @msg varchar(500)
    select @msg = 'Trung Lap '+convert(varchar, @results,101)
    rollback
 
    RAISERROR (@msg, 16, 1);
end
go
create procedure getcodeofbranch
(
   @id int
)
as
begin
  select code from Branch where id=@id
end
go
create procedure getamountofCustomer
(
   @id int
)
as
begin
  select count(*) from Customer where iduser=@id
end

go 
CREATE Type [dbo].[TableTypeCustomer] as Table(
	[name] [nvarchar](50) NULL
)
GO
create procedure insertlistTypeCustomer
(
   @type as dbo.TableTypeCustomer readonly
)
as
begin
 insert into TypeCustomer([name],available,createat,updateat) select a.[name],1,GETDATE(),GETDATE() from @type a where a.[name] not in (select [name] from TypeCustomer)
end
go
CREATE Type [dbo].[TableCustomer] as Table(
	[code] [nvarchar](50) NULL,
	[lastname] [nvarchar](50) NULL,
	[firstname] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[birthday] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[sex] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[createat] [nvarchar](50) NULL,
	[customerid] [nvarchar](50) NULL,
	[available] [int] NULL
)
GO
create function getidofTypeName(@name nvarchar(50))
returns int
begin
  declare @id int
  select @id=id from TypeCustomer where name=@name
  return @id
end
Go

create proc insertlistCustomer
(
  @idbr int,
  @listcustomer as dbo.TableCustomer readonly
)
as
begin
  insert into Customer([firstname],[lastname],[phone],[address],[code],[birthday],[email],[customerid],[iduser],[sex],[type],[createat],[updateat],[available]) select b.firstname,b.lastname,b.phone,b.[address],b.[code],b.[birthday],b.[email],1,@idbr,b.sex,dbo.getidofTypeName(b.type),b.createat,GETDATE(),1 from @listcustomer b
  declare @nameofbranch varchar(20)
  select @nameofbranch=[code] from Branch where id=@idbr
  update Customer set customerid=@nameofbranch+'-'+cast (id as varchar(20) )
end
go
create proc getInforofBranch
(
   @id int
)
as
begin
  select id,[name],[code],[address],[apptoken],[usetoken] from Branch where id=@id
end
go 
create proc updateBranch
(
    @id int,
    @name nvarchar(50),
	@address nvarchar(1000),
	@code varchar(50),
	@apptoken varchar(50),
	@usetoken varchar(50)
)
as
begin
  update Branch set name=@name,address=@address,code=@code,apptoken=@apptoken,usetoken=@usetoken,updateat=GetDate() where id=@id
end