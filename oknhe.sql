USE [master]
GO
/****** Object:  Database [CSDL_Nangcao]    Script Date: 3/16/2022 9:49:31 AM ******/
CREATE DATABASE [CSDL_Nangcao]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CSDL_Nangcao', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CSDL_Nangcao.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CSDL_Nangcao_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CSDL_Nangcao_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CSDL_Nangcao] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CSDL_Nangcao].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CSDL_Nangcao] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET ARITHABORT OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CSDL_Nangcao] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CSDL_Nangcao] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CSDL_Nangcao] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CSDL_Nangcao] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CSDL_Nangcao] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CSDL_Nangcao] SET  MULTI_USER 
GO
ALTER DATABASE [CSDL_Nangcao] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CSDL_Nangcao] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CSDL_Nangcao] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CSDL_Nangcao] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CSDL_Nangcao] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CSDL_Nangcao] SET QUERY_STORE = OFF
GO
USE [CSDL_Nangcao]
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDDL]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[AUTO_IDDL]()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
		IF (SELECT COUNT(Madonglinh) FROM Donglinh) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(Madonglinh, 3)) FROM Donglinh
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'DL00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'DL0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDDX]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDDX]()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
		IF (SELECT COUNT(Madongxuat) FROM Dongxuat) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(Madongxuat, 3)) FROM Dongxuat
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'DX00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'DX0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDPTK]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDPTK]()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
		IF (SELECT COUNT(Sophieu) FROM Phieuthongke) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(Sophieu, 3)) FROM Phieuthongke
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'TK00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'TK0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_MaDT]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ThongKeTongSl_MaDT] (@MADT CHAR(10), @a datetime, @b datetime)
RETURNS @BANGTHONGKE TABLE(
MADT CHAR(10),
TENDT NVARCHAR(50), Slastra1 INT, Slastra2 INT, Slastra3 INT, Slpfi1 INT, Slpfi2 INT, Slpfi3 INT, Slvero1 INT,
Slvero2 INT, Slvero3 INT, SLtiem3mui INT, SLTCNhe INT, SLTCNang INT
) AS
BEGIN
IF(@MADT IS NULL) OR (@MADT = '')
INSERT INTO @BANGTHONGKE
SELECT P.Madiemtiem, Tendiemtiem, Sum(SLastra1), Sum(SLastra2), Sum(Slastra3), Sum(SLpfi1), Sum(SLpfi2)
, Sum(SLpfi3), Sum(SLvero1), Sum(SLvero2), Sum(SLvero3), Sum(SL3mui), Sum(SLtcnhe), Sum(SLtcnang) FROM Phieuthongke P
JOIN Diemtiem D ON D.Madiemtiem = P.Madiemtiem
WHERE Ngaytiem BETWEEN @a AND @b
GROUP BY P.Madiemtiem, Tendiemtiem

ELSE
INSERT INTO @BANGTHONGKE
SELECT P.Madiemtiem, Tendiemtiem, Sum(SLastra1), Sum(SLastra2), Sum(Slastra3), Sum(SLpfi1), Sum(SLpfi2)
, Sum(SLpfi3), Sum(SLvero1), Sum(SLvero2), Sum(SLvero3),Sum(SL3mui), Sum(SLtcnhe), Sum(SLtcnang) FROM Phieuthongke P
JOIN Diemtiem D ON D.Madiemtiem = P.Madiemtiem
AND @MADT = P.Madiemtiem
WHERE Ngaytiem BETWEEN @a AND @b
GROUP BY P.Madiemtiem, Tendiemtiem
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_MaDT1]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ThongKeTongSl_MaDT1] ( @iddt CHAR(10), @a datetime, @b datetime)
RETURNS @BANGTHONGKE TABLE(
tendiemtiem NVARCHAR(50), Slastra1 INT, Slastra2 INT, Slastra3 INT
, Slpfi1 INT, Slpfi2 INT, Slpfi3 INT, Slvero1 INT,Slvero2 INT, Slvero3 INT
, SLtiem3mui INT, SLTCNhe INT, SLTCNang INT
) AS
BEGIN
INSERT INTO @BANGTHONGKE
select Tendiemtiem, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, sum(SLTCNhe) as SLTCNhe, 
sum(SLTCNang) as SLTCNang
from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem
WHERE
c.MaDiemTiem = @iddt
GROUP BY d.Tendiemtiem
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_QG]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ThongKeTongSl_QG] (@MATP CHAR(10),@MAQuan CHAR(10),@MAPhuong CHAR(10),  @a datetime, @b datetime, @case char(50), @maquyen char(10))
RETURNS @BANGTHONGKE TABLE(
Khuvuc NVARCHAR(50), Slastra1 INT, Slastra2 INT, Slastra3 INT, Slpfi1 INT, Slpfi2 INT, Slpfi3 INT, 
Slvero1 INT,Slvero2 INT, Slvero3 INT, SLtiem3mui INT, SLTCNhe INT, SLTCNang INT
) AS
BEGIN
if( @maquyen = 'admin')
	begin
	if( @case = 'tq')
	INSERT INTO @BANGTHONGKE
	select N'Toàn quốc', sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
	sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, 
	sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
	from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
	join Phuong p on p.Maphuong = d.Maphuong join Quan q on q.Maquan = p.Maquan
	join Thanhpho t on t.Mathanhpho = q.Mathanhpho

	if( @case = 'ttp')
	INSERT INTO @BANGTHONGKE
	select t.Tenthanhpho, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
	sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, 
	sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
	from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
	join Phuong p on p.Maphuong = d.Maphuong join Quan q on q.Maquan = p.Maquan
	join Thanhpho t on t.Mathanhpho = q.Mathanhpho
	group by t.Tenthanhpho
	end

if( @maquyen = 'c_account')
	begin
	if( @case = 'ttp')
	INSERT INTO @BANGTHONGKE
	select t.Tenthanhpho, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
	sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, 
	sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
	from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
	join Phuong p on p.Maphuong = d.Maphuong join Quan q on q.Maquan = p.Maquan
	join Thanhpho t on t.Mathanhpho = q.Mathanhpho
	WHERE  t.Mathanhpho = @MATP
	group by t.Tenthanhpho

	if( @case = 'qh')
	INSERT INTO @BANGTHONGKE
	select q.Tenquan, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
	sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, 
	sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
	from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
	join Phuong p on p.Maphuong = d.Maphuong join Quan q on q.Maquan = p.Maquan
	join Thanhpho t on t.Mathanhpho = q.Mathanhpho
	WHERE  t.Mathanhpho = @MATP
	group by q.Tenquan
	end

if( @maquyen = 'd_account')
	begin
	if( @case = 'qh')
	INSERT INTO @BANGTHONGKE
	select q.Tenquan, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
	sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, 
	sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
	from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
	join Phuong p on p.Maphuong = d.Maphuong join Quan q on q.Maquan = p.Maquan
	WHERE  d.Maquan = @MAQuan
	group by q.Tenquan

	if( @case = 'ptx')
	INSERT INTO @BANGTHONGKE
	select p.Tenphuong, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
	sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, 
	sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
	from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
	join Phuong p on p.Maphuong = d.Maphuong join Quan q on q.Maquan = p.Maquan
	WHERE  d.Maquan = @MAQuan
	group by p.Tenphuong
	end

if( @maquyen = 'w_account')
	begin
	if( @case = 'ptx')
	INSERT INTO @BANGTHONGKE
	select p.Tenphuong, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
	sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, 
	sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
	from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
	join Phuong p on p.Maphuong = d.Maphuong 
	WHERE  p.Maphuong = @MAPhuong
	group by p.Tenphuong

	if( @case = 'dt')
	INSERT INTO @BANGTHONGKE
	select d.Tendiemtiem, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
	sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, 
	sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
	from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
	join Phuong p on p.Maphuong = d.Maphuong 
	WHERE  p.Maphuong = @MAPhuong
	group by d.Tendiemtiem
	end

RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_Quan]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ThongKeTongSl_Quan] (@maquan CHAR(10), @a datetime, @b datetime)
RETURNS @BANGTHONGKE TABLE(
MADT CHAR(10),
TENDT NVARCHAR(50), Slastra1 INT, Slastra2 INT, Slastra3 INT, Slpfi1 INT, Slpfi2 INT, Slpfi3 INT, Slvero1 INT,
Slvero2 INT, Slvero3 INT, SLtiem3mui INT, SLTCNhe INT, SLTCNang INT
) AS
BEGIN
INSERT INTO @BANGTHONGKE
SELECT P.Madiemtiem, Tendiemtiem, Sum(SLastra1), Sum(SLastra2), Sum(Slastra3), Sum(SLpfi1), Sum(SLpfi2)
, Sum(SLpfi3), Sum(SLvero1), Sum(SLvero2), Sum(SLvero3),Sum(SL3mui), Sum(SLtcnhe), Sum(SLtcnang) FROM Phieuthongke P
JOIN Diemtiem D ON D.Madiemtiem = P.Madiemtiem
AND @maquan = P.Maquan
WHERE Ngaytiem BETWEEN @a AND @b
GROUP BY P.Madiemtiem, Tendiemtiem
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_Quan_All]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ThongKeTongSl_Quan_All] ( @a datetime, @b datetime)
RETURNS @BANGTHONGKE TABLE(
MaDiemTiem CHAR(10), Slastra1 INT, Slastra2 INT, Slastra3 INT
, Slpfi1 INT, Slpfi2 INT, Slpfi3 INT, Slvero1 INT, Slvero2 INT, Slvero3 INT, SLtiem3mui INT, SLTCNhe INT, SLTCNang INT
) AS
BEGIN
INSERT INTO @BANGTHONGKE
select Madiemtiem,
count ( case Mathuoc when 'vt001' then case Loaimui when 1 then 1 end end) ,
count ( case Mathuoc when 'vt001' then case Loaimui when 2 then 1 end end) ,
count ( case Mathuoc when 'vt001' then case Loaimui when 3 then 1 end end) ,
count ( case Mathuoc when 'vt002' then case Loaimui when 1 then 1 end end) ,
count ( case Mathuoc when 'vt002' then case Loaimui when 2 then 1 end end) ,
count ( case Mathuoc when 'vt002' then case Loaimui when 3 then 1 end end) ,
count ( case Mathuoc when 'vt003' then case Loaimui when 1 then 1 end end) ,
count ( case Mathuoc when 'vt003' then case Loaimui when 2 then 1 end end) ,
count ( case Mathuoc when 'vt003' then case Loaimui when 3 then 1 end end),
count ( case Loaimui when 3 then 1 end),
count ( case Loaitc when 'ltc001' then 1 end),
count ( case Loaitc when 'ltc002' then 1 end)
from Chitietphhieutiem
WHERE Ngaytiem BETWEEN @a AND @b
group by  Madiemtiem
order by Madiemtiem
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_Quan_All1]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[ThongKeTongSl_Quan_All1] ( @c datetime)
RETURNS @BANGTHONGKE TABLE(
MaDiemTiem CHAR(10), Slastra1 INT, Slastra2 INT, Slastra3 INT
, Slpfi1 INT, Slpfi2 INT, Slpfi3 INT, Slvero1 INT, Slvero2 INT, Slvero3 INT, SLtiem3mui INT, SLTCNhe INT, SLTCNang INT
) AS
BEGIN
INSERT INTO @BANGTHONGKE
select Madiemtiem,
count ( case Mathuoc when 'vt001' then case Loaimui when 1 then 1 end end) ,
count ( case Mathuoc when 'vt001' then case Loaimui when 2 then 1 end end) ,
count ( case Mathuoc when 'vt001' then case Loaimui when 3 then 1 end end) ,
count ( case Mathuoc when 'vt002' then case Loaimui when 1 then 1 end end) ,
count ( case Mathuoc when 'vt002' then case Loaimui when 2 then 1 end end) ,
count ( case Mathuoc when 'vt002' then case Loaimui when 3 then 1 end end) ,
count ( case Mathuoc when 'vt003' then case Loaimui when 1 then 1 end end) ,
count ( case Mathuoc when 'vt003' then case Loaimui when 2 then 1 end end) ,
count ( case Mathuoc when 'vt003' then case Loaimui when 3 then 1 end end),
count ( case Loaimui when 3 then 1 end),
count ( case Loaitc when 'ltc001' then 1 end),
count ( case Loaitc when 'ltc002' then 1 end)
from Chitietphhieutiem
WHERE Ngaytiem = @c
group by  Madiemtiem
order by Madiemtiem
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_Quan1]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ThongKeTongSl_Quan1] (@MAQuan CHAR(10), @a datetime, @b datetime)
RETURNS @BANGTHONGKE TABLE(
TenDiemTiem NVARCHAR(50), Slastra1 INT, Slastra2 INT, Slastra3 INT
, Slpfi1 INT, Slpfi2 INT, Slpfi3 INT, Slvero1 INT,Slvero2 INT, Slvero3 INT
, SLtiem3mui INT, SLTCNhe INT, SLTCNang INT
) AS
BEGIN
INSERT INTO @BANGTHONGKE
select Tendiemtiem, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui,
sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem
WHERE 
 Maquan = @Maquan
GROUP BY d.Tendiemtiem
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_Tiem]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[ThongKeTongSl_Tiem] ( @a datetime, @b datetime, @case nvarchar(50))
RETURNS @BANGTHONGKE TABLE(
Khuvuc NVARCHAR(50), Slastra1 INT, Slastra2 INT, Slastra3 INT
, Slpfi1 INT, Slpfi2 INT, Slpfi3 INT, Slvero1 INT,Slvero2 INT, Slvero3 INT
, SLtiem3mui INT, SLTCNhe INT, SLTCNang INT
) AS
BEGIN

if( @case = N'Tỉnh, Thành phố')
INSERT INTO @BANGTHONGKE
select t.Tenthanhpho, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, 
sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
join Quan q on q.Maquan = d.Maquan
join Thanhpho t on t.Mathanhpho = q.Mathanhpho
group by t.Tenthanhpho

if( @case = N'Quận, Huyện')
INSERT INTO @BANGTHONGKE
select q.Tenquan, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, 
sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem
join Quan q on q.Maquan = d.Maquan
join Thanhpho t on t.Mathanhpho = q.Mathanhpho
group by q.Tenquan

if( @case = N'Xã, phường')
INSERT INTO @BANGTHONGKE
select Tendiemtiem, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui,
sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem
join Quan q on q.Maquan = d.Maquan
join Thanhpho t on t.Mathanhpho = q.Mathanhpho
GROUP BY d.Tendiemtiem

RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_TP]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ThongKeTongSl_TP] (@a datetime, @b datetime)
RETURNS @BANGTHONGKE TABLE(
MaQuan CHAR(10),
TenQuan NVARCHAR(50), Slastra1 INT, Slastra2 INT, Slastra3 INT, Slpfi1 INT, Slpfi2 INT, Slpfi3 INT, Slvero1 INT,
Slvero2 INT, Slvero3 INT, SLtiem3mui INT, SLTCNhe INT, SLTCNang INT
) AS
BEGIN
INSERT INTO @BANGTHONGKE
SELECT P.Maquan, Tenquan, Sum(SLastra1), Sum(SLastra2), Sum(Slastra3), Sum(SLpfi1), Sum(SLpfi2)
, Sum(SLpfi3), Sum(SLvero1), Sum(SLvero2), Sum(SLvero3),Sum(SL3mui), Sum(SLtcnhe), Sum(SLtcnang) FROM Phieuthongke P
JOIN Quan D ON D.Maquan = P.Maquan
WHERE Ngaytiem BETWEEN @a AND @b
GROUP BY P.Maquan, Tenquan
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_TP1]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ThongKeTongSl_TP1] ( @a datetime, @b datetime)
RETURNS @BANGTHONGKE TABLE(
tenquan NVARCHAR(50), Slastra1 INT, Slastra2 INT, Slastra3 INT
, Slpfi1 INT, Slpfi2 INT, Slpfi3 INT, Slvero1 INT,Slvero2 INT, Slvero3 INT
, SLtiem3mui INT, SLTCNhe INT, SLTCNang INT
) AS
BEGIN
INSERT INTO @BANGTHONGKE
select Tenquan, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, 
sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem
group by Tenquan
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_TP2]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ThongKeTongSl_TP2] (@MATP CHAR(10),  @a datetime, @b datetime, @case nvarchar(50))
RETURNS @BANGTHONGKE TABLE(
Khuvuc NVARCHAR(50), Slastra1 INT, Slastra2 INT, Slastra3 INT
, Slpfi1 INT, Slpfi2 INT, Slpfi3 INT, Slvero1 INT,Slvero2 INT, Slvero3 INT
, SLtiem3mui INT, SLTCNhe INT, SLTCNang INT
) AS
BEGIN
if( @case = N'Tỉnh, Thành phố')
INSERT INTO @BANGTHONGKE
select t.Tenthanhpho, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, 
sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
join Quan q on q.Maquan = d.Maquan
join Thanhpho t on t.Mathanhpho = q.Mathanhpho
WHERE 
 t.Mathanhpho = @MaTP
group by t.Tenthanhpho

if( @case = N'Quận, Huyện')
INSERT INTO @BANGTHONGKE
select q.Tenquan, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui, 
sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem
join Quan q on q.Maquan = d.Maquan
join Thanhpho t on t.Mathanhpho = q.Mathanhpho
WHERE 
 t.Mathanhpho = @MaTP
group by q.Tenquan

if( @case = N'Điểm tiêm')
INSERT INTO @BANGTHONGKE
select Tendiemtiem, sum(Slastra1) as Slastra1 ,sum(Slastra2) as Slastra2, sum(Slastra3) as Slastra3, sum(Slpfi1) as Slpfi1, sum(Slpfi2) as Slpfi2,
sum(Slpfi3) as Slpfi3, sum(Slvero1) as Slvero1, sum(Slvero2) as Slvero2, sum(Slvero3) as Slvero3, sum(SLtiem3mui) as SLtiem3mui,
sum(SLTCNhe) as SLTCNhe, sum(SLTCNang) as SLTCNang
from ThongKeTongSl_Quan_All(@a , @b) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem
join Quan q on q.Maquan = d.Maquan
join Thanhpho t on t.Mathanhpho = q.Mathanhpho
WHERE 
t.Mathanhpho = @MaTP
GROUP BY d.Tendiemtiem

RETURN
END
GO
/****** Object:  Table [dbo].[Chithidongbang]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chithidongbang](
	[Machithidongbang] [varchar](10) NOT NULL,
	[Tenchithidongbang] [nvarchar](10) NULL,
 CONSTRAINT [PK_Chithidongbang] PRIMARY KEY CLUSTERED 
(
	[Machithidongbang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chithinhietdo]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chithinhietdo](
	[Machithinhietdo] [varchar](10) NOT NULL,
	[Tenchithinhietdo] [nvarchar](10) NULL,
 CONSTRAINT [PK_Chithinhietdo] PRIMARY KEY CLUSTERED 
(
	[Machithinhietdo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chitietphhieutiem]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chitietphhieutiem](
	[Machitietphieutiem] [varchar](10) NOT NULL,
	[Ngaytiem] [date] NULL,
	[Loaimui] [varchar](10) NULL,
	[Trieuchung] [nvarchar](50) NULL,
	[Mathuoc] [varchar](10) NULL,
	[Sophieutiem] [varchar](10) NULL,
	[Madiemtiem] [varchar](10) NULL,
	[Tendiemtiem] [nvarchar](50) NULL,
	[Tenthuoc] [nvarchar](30) NULL,
	[Loaitc] [varchar](10) NULL,
	[Ghichu] [nvarchar](50) NULL,
	[Tenloaitc] [nvarchar](50) NULL,
	[Malo] [varchar](10) NULL,
 CONSTRAINT [PK_Chitietphhieutiem] PRIMARY KEY CLUSTERED 
(
	[Machitietphieutiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diemtiem]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diemtiem](
	[Madiemtiem] [varchar](10) NOT NULL,
	[Tendiemtiem] [nvarchar](100) NULL,
	[Tennguoidungdau] [nvarchar](50) NULL,
	[Maquan] [varchar](10) NULL,
	[Tenquan] [nvarchar](20) NULL,
	[Maphuong] [varchar](10) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Sobantiem] [int] NULL,
	[Trangthai] [bit] NULL,
	[Mathanhpho] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Madiemtiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donglinh]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donglinh](
	[Madonglinh] [varchar](10) NOT NULL,
	[Sophieulinh] [varchar](10) NULL,
	[Mathuoc] [varchar](10) NULL,
	[SLyeucau] [int] NULL,
	[SLcapphat] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Madonglinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dongxuat]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dongxuat](
	[Madongxuat] [varchar](10) NOT NULL,
	[Sophieuxuat] [varchar](10) NULL,
	[Malo] [varchar](10) NULL,
	[SLxuat] [int] NULL,
	[Dongia] [int] NULL,
	[Thanhtien] [int] NULL,
	[Tenthuoc] [nvarchar](15) NULL,
	[Mathuoc] [varchar](10) NULL,
	[SLnhap] [int] NULL,
	[HSD] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Madongxuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dongxuathuy]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dongxuathuy](
	[Madongxuathuy] [varchar](10) NOT NULL,
	[Maphieuxuathuy] [varchar](10) NOT NULL,
	[Slxuat] [int] NOT NULL,
	[Malo] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Dongxuathuy] PRIMARY KEY CLUSTERED 
(
	[Madongxuathuy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dongxuattralai]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dongxuattralai](
	[Madongxuattralai] [varchar](10) NOT NULL,
	[Sophieuxuat] [varchar](10) NOT NULL,
	[Malo] [varchar](10) NOT NULL,
	[SLxuat] [int] NULL,
	[SLnhap] [int] NULL,
	[HSD] [date] NULL,
	[Tenvattu] [nvarchar](50) NULL,
 CONSTRAINT [PK_Dongxuattralai] PRIMARY KEY CLUSTERED 
(
	[Madongxuattralai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hoadonnhap]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoadonnhap](
	[Sohoadon] [varchar](10) NOT NULL,
	[Ngaynhap] [date] NULL,
	[Diadiem] [nvarchar](100) NULL,
	[Manhanvien] [varchar](10) NULL,
	[Mancc] [varchar](10) NULL,
	[Manguon] [varchar](10) NULL,
	[Ghichu] [nvarchar](50) NULL,
	[Makhonhap] [varchar](10) NULL,
	[Tongtien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sohoadon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kho]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho](
	[Makho] [varchar](10) NOT NULL,
	[Tenkho] [nvarchar](30) NULL,
	[Diadiem] [nvarchar](30) NULL,
 CONSTRAINT [PK_Kho] PRIMARY KEY CLUSTERED 
(
	[Makho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lo]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lo](
	[Malo] [varchar](10) NOT NULL,
	[SLnhap] [int] NULL,
	[Dongia] [int] NULL,
	[Sohoadon] [varchar](10) NULL,
	[Solieutrenmotcai] [int] NULL,
	[SDK_gnpk] [varchar](50) NULL,
	[NSX] [date] NULL,
	[HSD] [date] NULL,
	[Nongdo] [varchar](10) NULL,
	[Hopchat] [varchar](100) NULL,
	[Dangdonggoi] [nvarchar](10) NULL,
	[Machithidongbang] [varchar](10) NULL,
	[Machithinhietdo] [varchar](10) NULL,
	[Mavattu] [varchar](10) NULL,
	[Thanhtien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Malo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loaimui]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loaimui](
	[Maloaimui] [varchar](10) NOT NULL,
	[Tenloaimui] [varchar](1) NULL,
	[Ten] [nvarchar](30) NULL,
 CONSTRAINT [PK_Loaimui] PRIMARY KEY CLUSTERED 
(
	[Maloaimui] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loaitochuc]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loaitochuc](
	[Maloaitochuc] [varchar](10) NOT NULL,
	[Tenloaitochuc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Loaitochuc] PRIMARY KEY CLUSTERED 
(
	[Maloaitochuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loaitrieuchung]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loaitrieuchung](
	[Maloaitc] [varchar](10) NOT NULL,
	[Tenloaitc] [nvarchar](20) NULL,
	[Ghichu] [nvarchar](50) NULL,
 CONSTRAINT [PK_Loaitrieuchung] PRIMARY KEY CLUSTERED 
(
	[Maloaitc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loaivattuyte]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loaivattuyte](
	[Maloaivattu] [varchar](10) NOT NULL,
	[Tenloaivattu] [nvarchar](50) NULL,
 CONSTRAINT [PK_Loaivattuyte] PRIMARY KEY CLUSTERED 
(
	[Maloaivattu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nguon]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nguon](
	[Manguon] [varchar](10) NOT NULL,
	[Tennguon] [nvarchar](30) NULL,
 CONSTRAINT [PK_Nguon] PRIMARY KEY CLUSTERED 
(
	[Manguon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhacungcap]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhacungcap](
	[Mancc] [varchar](10) NOT NULL,
	[Tencc] [nvarchar](100) NULL,
	[Sdt] [varchar](10) NULL,
	[Diachi] [nvarchar](100) NULL,
	[Fax] [varchar](10) NULL,
	[Sotaikhoan] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Mancc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhanvien]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhanvien](
	[Manhanvien] [varchar](10) NOT NULL,
	[Tennhanvien] [nvarchar](100) NULL,
	[Chucvu] [nvarchar](20) NULL,
	[Taikhoan] [char](30) NULL,
	[Manhom] [varchar](10) NULL,
	[SDT] [varchar](15) NULL,
	[Email] [varchar](55) NULL,
	[Trangthai] [bit] NULL,
	[Matkhau] [char](50) NULL,
	[Madiemtiem] [varchar](10) NULL,
	[Maquan] [varchar](10) NULL,
	[Mathanhpho] [varchar](10) NULL,
	[Tkqg] [bit] NULL,
	[Maphuong] [varchar](10) NULL,
	[Ngaysinh] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Manhanvien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhasanxuat]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhasanxuat](
	[Mansx] [varchar](10) NOT NULL,
	[Tennsx] [nvarchar](30) NULL,
	[Quocgia] [nvarchar](30) NULL,
 CONSTRAINT [PK_Nhasanxuat] PRIMARY KEY CLUSTERED 
(
	[Mansx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhomnhanvien]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhomnhanvien](
	[Manhomnv] [varchar](10) NOT NULL,
	[Tennhomnv] [nvarchar](30) NULL,
 CONSTRAINT [PK_Nhomnhanvien] PRIMARY KEY CLUSTERED 
(
	[Manhomnv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhomnv_Quyen]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhomnv_Quyen](
	[Manhomnv] [varchar](10) NOT NULL,
	[Maquyen] [varchar](10) NOT NULL,
	[Chuthich] [nvarchar](30) NULL,
 CONSTRAINT [PK_Nhanvien_Quyen] PRIMARY KEY CLUSTERED 
(
	[Manhomnv] ASC,
	[Maquyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhomuutien]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhomuutien](
	[Manhomuutien] [varchar](10) NOT NULL,
	[Tennhomuutien] [nvarchar](50) NULL,
	[Trongso] [int] NULL,
 CONSTRAINT [PK_Nhomuutien] PRIMARY KEY CLUSTERED 
(
	[Manhomuutien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phieudangky]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phieudangky](
	[Sophieudangky] [varchar](10) NOT NULL,
	[Tennguoidan] [nvarchar](50) NULL,
	[CCCD] [varchar](15) NULL,
	[SDT] [varchar](15) NULL,
	[Ngaysinh] [date] NULL,
	[Matochuc] [varchar](10) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Ngaymongmuon] [date] NULL,
	[Matrangthai] [varchar](10) NULL,
	[Manhomuutien] [varchar](10) NULL,
	[Maphuong] [varchar](10) NULL,
	[Buoimongmuon] [nvarchar](30) NULL,
	[Gioitinh] [nvarchar](3) NULL,
	[Email] [varchar](50) NULL,
	[Bhyt] [varchar](30) NULL,
	[Dantoc] [nvarchar](10) NULL,
	[Quoctich] [nvarchar](10) NULL,
	[Hotengiamho] [nvarchar](50) NULL,
	[Quanhegiamho] [nvarchar](10) NULL,
	[SDTgiamho] [varchar](15) NULL,
	[Mathuoc1] [varchar](10) NULL,
	[Ngaytiem1] [date] NULL,
	[Malo1] [varchar](10) NULL,
	[Diadiemtiem1] [nvarchar](50) NULL,
	[Phanungtiem1] [nvarchar](500) NULL,
	[Hotendangky] [nvarchar](50) NULL,
	[SDTdangky] [varchar](15) NULL,
	[Nghenghiep] [nvarchar](50) NULL,
	[Donvicongtac] [nvarchar](50) NULL,
	[Tennhomuutien] [nvarchar](500) NULL,
	[Tenphuong] [nvarchar](50) NULL,
	[Loaimui] [nvarchar](30) NULL,
	[Tentt] [nvarchar](30) NULL,
	[Tenthuoc1] [nvarchar](15) NULL,
 CONSTRAINT [PK_Phieudangky] PRIMARY KEY CLUSTERED 
(
	[Sophieudangky] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phieudky_Tiensu]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phieudky_Tiensu](
	[Matiensu] [varchar](10) NOT NULL,
	[Maphieudangky] [varchar](10) NOT NULL,
	[Trieuchung] [nvarchar](100) NULL,
	[Matrangthai] [varchar](10) NULL,
 CONSTRAINT [PK_Phieudky_Tiensu] PRIMARY KEY CLUSTERED 
(
	[Matiensu] ASC,
	[Maphieudangky] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phieulinh]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phieulinh](
	[Sophieulinh] [varchar](10) NOT NULL,
	[Ngayyeucau] [date] NULL,
	[Manhanvien] [varchar](10) NULL,
	[Madiemtiem] [varchar](10) NULL,
	[Matt] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Sophieulinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phieuthongke]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phieuthongke](
	[Sophieu] [varchar](10) NOT NULL,
	[SLtiem] [smallint] NULL,
 CONSTRAINT [PK__Phieutho__510D78BC6DEDCFBF] PRIMARY KEY CLUSTERED 
(
	[Sophieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phieutiem]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phieutiem](
	[Sophieu] [varchar](10) NOT NULL,
	[Tennguoidan] [nvarchar](60) NULL,
	[CCCD] [varchar](20) NULL,
	[SDT] [varchar](20) NULL,
	[Ngaysinh] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sophieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phieuxuat]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phieuxuat](
	[Sophieuxuat] [varchar](10) NOT NULL,
	[Ngayxuat] [date] NULL,
	[Khoxuat] [nvarchar](100) NULL,
	[Khonhan] [nvarchar](100) NULL,
	[Manhanvien] [varchar](10) NULL,
	[Madiemtiem] [varchar](10) NULL,
	[Makhoxuat] [varchar](10) NULL,
	[Tongtien] [int] NULL,
	[Matinhtrang] [varchar](10) NULL,
	[Ngaynhap] [date] NULL,
	[Ghichu] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[Sophieuxuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phieuxuathuy]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phieuxuathuy](
	[Sophieuxuat] [varchar](10) NOT NULL,
	[Ghichu] [nvarchar](50) NULL,
	[Manhanvien] [varchar](10) NULL,
	[Ngayxuat] [date] NULL,
 CONSTRAINT [PK_Phieuxuathuy] PRIMARY KEY CLUSTERED 
(
	[Sophieuxuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phieuxuattralai]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phieuxuattralai](
	[Sophieuxuat] [varchar](10) NOT NULL,
	[Madiemtiem] [varchar](10) NULL,
	[Ngayxuat] [date] NULL,
	[Manhanvien] [varchar](10) NULL,
	[Matinhtrang] [varchar](10) NULL,
	[Ghichu] [nvarchar](50) NULL,
	[Ngaynhap] [date] NULL,
	[Manhanvien2] [varchar](10) NULL,
 CONSTRAINT [PK_Phieuxuattralai] PRIMARY KEY CLUSTERED 
(
	[Sophieuxuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phuong]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phuong](
	[Maphuong] [varchar](10) NOT NULL,
	[Tenphuong] [nvarchar](50) NULL,
	[Maquan] [varchar](10) NULL,
 CONSTRAINT [PK_Phuong] PRIMARY KEY CLUSTERED 
(
	[Maphuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quan]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quan](
	[Maquan] [varchar](10) NOT NULL,
	[Tenquan] [nvarchar](100) NULL,
	[Mathanhpho] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Maquan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[Maquyen] [varchar](10) NOT NULL,
	[Tenquyen] [nvarchar](30) NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[Maquyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Thanhpho]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thanhpho](
	[Mathanhpho] [varchar](10) NOT NULL,
	[Tenthanhpho] [nvarchar](50) NULL,
 CONSTRAINT [PK_Thanhpho] PRIMARY KEY CLUSTERED 
(
	[Mathanhpho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tiensu]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tiensu](
	[Matiensu] [varchar](10) NOT NULL,
	[Trieuchung] [bit] NULL,
	[Ten] [nvarchar](500) NULL,
	[Ghiro] [nvarchar](100) NULL,
 CONSTRAINT [PK_Tiensu] PRIMARY KEY CLUSTERED 
(
	[Matiensu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tinhtrangphieudk]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tinhtrangphieudk](
	[Matrangthai] [varchar](10) NOT NULL,
	[Tentranthai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tinhtrangphieudk] PRIMARY KEY CLUSTERED 
(
	[Matrangthai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tinhtrangpx]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tinhtrangpx](
	[Matinhtrang] [varchar](10) NOT NULL,
	[Tentinhtrang] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tinhtrangpx] PRIMARY KEY CLUSTERED 
(
	[Matinhtrang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tinhtrangpxuattralai]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tinhtrangpxuattralai](
	[Matrangthai] [varchar](10) NOT NULL,
	[Tentrangthai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tinhtrangpxuattralai] PRIMARY KEY CLUSTERED 
(
	[Matrangthai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tochuc]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tochuc](
	[Matochuc] [varchar](10) NOT NULL,
	[Tentochuc] [nvarchar](50) NULL,
	[Taikhoan] [varchar](30) NULL,
	[Matkhau] [varchar](30) NULL,
	[Tennguoidungdau] [nvarchar](50) NULL,
	[SDT] [varchar](15) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Maloaitochuc] [varchar](10) NULL,
 CONSTRAINT [PK_Tochuc] PRIMARY KEY CLUSTERED 
(
	[Matochuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trangthai]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trangthai](
	[Matrangthai] [varchar](10) NOT NULL,
	[Tentrangthai] [nvarchar](19) NULL,
 CONSTRAINT [PK_Trangthai] PRIMARY KEY CLUSTERED 
(
	[Matrangthai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trangthaitiensu]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trangthaitiensu](
	[Matrangthai] [varchar](10) NOT NULL,
	[Tentrangthai] [nvarchar](10) NULL,
 CONSTRAINT [PK_Trangthaitiensu] PRIMARY KEY CLUSTERED 
(
	[Matrangthai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vattuyte]    Script Date: 3/16/2022 9:49:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vattuyte](
	[Mavattu] [varchar](10) NOT NULL,
	[Tenvattu] [nvarchar](100) NULL,
	[Mansx] [varchar](10) NULL,
	[Maloaivattu] [varchar](10) NULL,
	[Trangthai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Mavattu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Chithidongbang] ([Machithidongbang], [Tenchithidongbang]) VALUES (N'ctdb001', N'Tốt')
INSERT [dbo].[Chithidongbang] ([Machithidongbang], [Tenchithidongbang]) VALUES (N'ctdb003', N'BìnhThường')
GO
INSERT [dbo].[Chithinhietdo] ([Machithinhietdo], [Tenchithinhietdo]) VALUES (N'ctnd001', N'Tốt')
INSERT [dbo].[Chithinhietdo] ([Machithinhietdo], [Tenchithinhietdo]) VALUES (N'ctnd003', N'BìnhThường')
GO
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'alz11', CAST(N'2021-12-23' AS Date), N'1', N'không', N'vt001', N'pt009', N'dt001', NULL, NULL, NULL, NULL, NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt001', CAST(N'2020-12-17' AS Date), N'1', N'Không có', N'vt001', N'pt001', N'dt001', N'Tytp Yên Nghĩa', N'astra', N'ltc003', NULL, NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt002', CAST(N'2021-01-03' AS Date), N'2', N'Nhẹ', N'vt001', N'pt001', N'dt001', N'Tytp Yên Nghĩa', N'astra', N'ltc001', NULL, NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt003', CAST(N'2021-01-03' AS Date), N'1', N'Ngất', N'vt003', N'pt002', N'dt003', N'HĐ', N'vero cell', N'ltc002', N'đã cấp cứu thành công', NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt006', CAST(N'2020-09-09' AS Date), N'2', N'Nhẹ', N'vt003', N'pt002', N'dt002', N'BVE', N'vero cell', N'ltc001', NULL, NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt007', CAST(N'2020-01-01' AS Date), N'1', NULL, N'vt001', NULL, N'dt001', NULL, NULL, NULL, NULL, NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt016', CAST(N'2022-03-13' AS Date), N'3', N'ko', N'vt001', N'pt008', N'dt001', NULL, NULL, NULL, N'ko', NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt017', CAST(N'2022-03-13' AS Date), N'1', N'ko', NULL, N'pt007', N'dt001', NULL, NULL, NULL, N'ko', NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt018', CAST(N'2022-03-14' AS Date), N'1', NULL, N'vt001', N'pt010', N'dt001', NULL, NULL, NULL, NULL, NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt0911', CAST(N'2021-12-02' AS Date), N'1', N'tử vong', N'vt002', N'pt005', N'dt001', N'Tytp Yên Nghĩa', N'pfizer', N'ltc002', N'tử vong', NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt0990', CAST(N'1999-09-09' AS Date), N'3', NULL, N'vt001', NULL, N'dt002', NULL, NULL, NULL, NULL, NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt0991', CAST(N'2019-01-01' AS Date), N'3', NULL, N'vt001', N'pt001', N'dt001', NULL, NULL, N'ltc002', N'tử vong', NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctptla011', CAST(N'2022-02-09' AS Date), N'2', NULL, N'vt001', N'pt008', N'dt002', NULL, NULL, NULL, NULL, NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctptldd01', CAST(N'2021-12-23' AS Date), N'1', NULL, N'vt001', N'pt004', N'dt001', NULL, NULL, NULL, NULL, NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctptnql01', CAST(N'2021-12-23' AS Date), N'1', N'không', N'vt001', N'pt008', N'dt001', NULL, NULL, NULL, N'k', NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctptxql01', CAST(N'2021-12-23' AS Date), N'2', N'không', N'vt001', N'pt009', N'dt001', NULL, NULL, NULL, N'k', NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctptxql03', CAST(N'2022-02-20' AS Date), N'3', N'k', NULL, N'pt009', N'dt001', NULL, NULL, NULL, N'k', NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'zzzz', CAST(N'2022-03-15' AS Date), N'1', N'k', N'vt001', N'pt006', N'dt001', NULL, NULL, NULL, NULL, NULL, N'lo001')
GO
INSERT [dbo].[Diemtiem] ([Madiemtiem], [Tendiemtiem], [Tennguoidungdau], [Maquan], [Tenquan], [Maphuong], [Diachi], [Sobantiem], [Trangthai], [Mathanhpho]) VALUES (N'dt001', N'Trạm ytp Yên Nghĩa', N'Nguyễn Đức Mạnh', N'q001', N'Hà Đông', N'p001', N'Số 8 đường Hòa Bình, Yên Nghĩa ', 1, 1, N'tp001')
INSERT [dbo].[Diemtiem] ([Madiemtiem], [Tendiemtiem], [Tennguoidungdau], [Maquan], [Tenquan], [Maphuong], [Diachi], [Sobantiem], [Trangthai], [Mathanhpho]) VALUES (N'dt002', N'BV 103', N'Trần Minh Tuấn', N'q001', N'Hà Đông', N'p001', N'Số 197 đường Quang Trung, Hà Đông', 2, 1, N'tp001')
INSERT [dbo].[Diemtiem] ([Madiemtiem], [Tendiemtiem], [Tennguoidungdau], [Maquan], [Tenquan], [Maphuong], [Diachi], [Sobantiem], [Trangthai], [Mathanhpho]) VALUES (N'dt003', N'BV E', N'Đặng Đức Hùng', N'q002', N'Cầu Giấy', N'p005', N'Số 48 đường Hoàng Quốc Việt', 1, 1, N'tp001')
INSERT [dbo].[Diemtiem] ([Madiemtiem], [Tendiemtiem], [Tennguoidungdau], [Maquan], [Tenquan], [Maphuong], [Diachi], [Sobantiem], [Trangthai], [Mathanhpho]) VALUES (N'dt004', N'BV LMN', N'Nguyễn Mạnh Khang', N'q003', N'Bắc Từ Liêm', N'p004', N'Số 9 đường Phạm Hùng', 1, 1, N'tp001')
INSERT [dbo].[Diemtiem] ([Madiemtiem], [Tendiemtiem], [Tennguoidungdau], [Maquan], [Tenquan], [Maphuong], [Diachi], [Sobantiem], [Trangthai], [Mathanhpho]) VALUES (N'dt005', N'Trạm ytp TXT', N'Trần Phương Linh', N'q004', N'Thanh Xuân', N'p004', N'Số 33 đường Nguyễn Trãi', 2, 1, N'tp001')
INSERT [dbo].[Diemtiem] ([Madiemtiem], [Tendiemtiem], [Tennguoidungdau], [Maquan], [Tenquan], [Maphuong], [Diachi], [Sobantiem], [Trangthai], [Mathanhpho]) VALUES (N'dt006', N'Trạm ytp Hà Cầu', N'Hoàng Lê  Min', N'q001', N'Hà Đông', N'p003', N'Số 6 đường Lê Lợi', 2, 1, N'tp001')
GO
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001001', N'pl001', N'vt001', 19, 20)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001002', N'pl002', N'vt001', 10, 5)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001003', N'pl003', N'vt001', 87, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001004', N'pl004', N'vt001', 500, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001005', N'pl005', N'vt001', 1000, 1000)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001006', N'pl006', N'vt001', 10, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001007', N'pl007', N'vt001', 0, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001008', N'pl008', N'vt001', 3, 4)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001009', N'pl009', N'vt001', 1, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001010', N'pl010', N'vt001', 1, 1)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001011', N'pl011', N'vt001', 1, 1)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001012', N'pl012', N'vt001', 3, 3)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001013', N'pl013', N'vt001', 3, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001014', N'pl014', N'vt001', 3, 3)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl001015', N'pl015', N'vt001', 1, 1)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002001', N'pl001', N'vt002', 50, 49)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002002', N'pl002', N'vt002', 7, 5)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002003', N'pl003', N'vt002', 0, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002004', N'pl004', N'vt002', 100, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002005', N'pl005', N'vt002', 4000, 4000)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002006', N'pl006', N'vt002', 10, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002007', N'pl007', N'vt002', 2, 2)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002008', N'pl008', N'vt002', 3, 3)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002009', N'pl009', N'vt002', 0, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002010', N'pl010', N'vt002', 1, 1)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002011', N'pl011', N'vt002', 1, 1)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002012', N'pl012', N'vt002', 3, 3)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002013', N'pl013', N'vt002', 2, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002014', N'pl014', N'vt002', 1, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl002015', N'pl015', N'vt002', 1, 1)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl003003', N'pl003', N'vt003', 14, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl003004', N'pl004', N'vt003', 100, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl003005', N'pl005', N'vt003', 0, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl003006', N'pl006', N'vt003', 0, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl003007', N'pl007', N'vt003', 0, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl003008', N'pl008', N'vt003', 3, 2)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl003009', N'pl009', N'vt003', 0, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl003010', N'pl010', N'vt003', 1, 1)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl003011', N'pl011', N'vt003', 0, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl003012', N'pl012', N'vt003', 0, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl003013', N'pl013', N'vt003', 1, 1)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl003014', N'pl014', N'vt003', 1, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dl003015', N'pl015', N'vt003', 0, 0)
GO
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx001', N'px001', N'lo001', 77, 5, NULL, N'a', N'vt001', 77, CAST(N'1999-05-05' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx002', N'px002', N'lo001', 88, 5, NULL, N'a', N'vt001', 88, CAST(N'1999-05-05' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx003', N'px002', N'lo001', 69, 8, NULL, N'a', N'vt001', 69, CAST(N'1999-05-05' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx004', N'px002', N'lo001', 100, 5, NULL, N'a', N'vt001', 100, CAST(N'1999-05-05' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx005', N'px002', N'lo001', 100, 5, NULL, N'a', N'vt001', 100, CAST(N'1999-05-05' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx006', N'px002', N'lo001', 10, 10, 10, N'a', N'vt001', 10, CAST(N'1999-05-05' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx007', N'px007', N'lo001', 10, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx008', N'px007', N'lo006', 5, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx009', N'px007', N'lo001', 1, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx010', N'px008', N'lo003', 5, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx011', N'px008', N'lo007', 4, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx012', N'px009', N'lo006', 5, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx013', N'px010', N'lo004', 5, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx014', N'px011', N'lo001', 5, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx015', N'px011', N'lo007', 5, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx016', N'px012', N'lo004', 5, NULL, NULL, NULL, NULL, 4, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx017', N'px012', N'lo007', 5, NULL, NULL, NULL, NULL, 4, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx018', N'px013', N'lo004', 10, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx019', N'px013', N'lo001', 10, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx020', N'px014', N'lo001', 100, NULL, NULL, NULL, NULL, 99, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx021', N'px015', N'lo005', 2, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx022', N'px015', N'lo001', 4, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx023', N'px015', N'lo004', 2, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx024', N'px017', N'lo001', 2, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx025', N'px018', N'lo001', 1, NULL, NULL, NULL, NULL, 1, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx026', N'px034', N'lo001', 1, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx027', N'px037', N'lo001', 3, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx028', N'px038', N'lo001', 4, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx029', N'px042', N'lo006', 7, NULL, NULL, NULL, NULL, 7, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx030', N'px042', N'lo001', 6, NULL, NULL, NULL, NULL, 6, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx031', N'px043', N'lo001', 1, NULL, NULL, NULL, NULL, 1, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx032', N'px044', N'lo001', 1, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx033', N'px045', N'lo001', 3, NULL, NULL, NULL, NULL, 2, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx034', N'px046', N'lo001', 1, NULL, NULL, NULL, NULL, 1, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc], [SLnhap], [HSD]) VALUES (N'dx035', N'px046', N'lo004', 1, NULL, NULL, NULL, NULL, 1, CAST(N'0001-01-01' AS Date))
GO
INSERT [dbo].[Dongxuathuy] ([Madongxuathuy], [Maphieuxuathuy], [Slxuat], [Malo]) VALUES (N'dxh001004', N'pxh004', 10, N'lo001')
INSERT [dbo].[Dongxuathuy] ([Madongxuathuy], [Maphieuxuathuy], [Slxuat], [Malo]) VALUES (N'dxh001006', N'pxh005', 15, N'lo001')
INSERT [dbo].[Dongxuathuy] ([Madongxuathuy], [Maphieuxuathuy], [Slxuat], [Malo]) VALUES (N'dxh003009', N'pxh009', 1, N'lo003')
INSERT [dbo].[Dongxuathuy] ([Madongxuathuy], [Maphieuxuathuy], [Slxuat], [Malo]) VALUES (N'dxh006008', N'pxh008', 10, N'lo006')
GO
INSERT [dbo].[Dongxuattralai] ([Madongxuattralai], [Sophieuxuat], [Malo], [SLxuat], [SLnhap], [HSD], [Tenvattu]) VALUES (N'dxtl001003', N'ptl003', N'lo001', 1, 1, CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[Dongxuattralai] ([Madongxuattralai], [Sophieuxuat], [Malo], [SLxuat], [SLnhap], [HSD], [Tenvattu]) VALUES (N'dxtl006003', N'ptl003', N'lo001', 6, 6, CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[Dongxuattralai] ([Madongxuattralai], [Sophieuxuat], [Malo], [SLxuat], [SLnhap], [HSD], [Tenvattu]) VALUES (N'dxtl017004', N'ptl004', N'lo007', 1, 1, CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[Dongxuattralai] ([Madongxuattralai], [Sophieuxuat], [Malo], [SLxuat], [SLnhap], [HSD], [Tenvattu]) VALUES (N'dxtl017005', N'ptl005', N'lo007', 3, 2, CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[Dongxuattralai] ([Madongxuattralai], [Sophieuxuat], [Malo], [SLxuat], [SLnhap], [HSD], [Tenvattu]) VALUES (N'dxtl017006', N'ptl006', N'lo007', 1, 1, CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[Dongxuattralai] ([Madongxuattralai], [Sophieuxuat], [Malo], [SLxuat], [SLnhap], [HSD], [Tenvattu]) VALUES (N'dxtl020005', N'ptl005', N'lo001', 1, 1, CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[Dongxuattralai] ([Madongxuattralai], [Sophieuxuat], [Malo], [SLxuat], [SLnhap], [HSD], [Tenvattu]) VALUES (N'dxtl032007', N'ptl007', N'lo001', 1, 1, CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[Dongxuattralai] ([Madongxuattralai], [Sophieuxuat], [Malo], [SLxuat], [SLnhap], [HSD], [Tenvattu]) VALUES (N'dxtl033008', N'ptl008', N'lo001', 1, 1, CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[Dongxuattralai] ([Madongxuattralai], [Sophieuxuat], [Malo], [SLxuat], [SLnhap], [HSD], [Tenvattu]) VALUES (N'dxtl034009', N'ptl009', N'lo001', 1, 1, CAST(N'0001-01-01' AS Date), NULL)
GO
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd001', CAST(N'1989-06-06' AS Date), N'pham hung', N'nv001', N'ncc002', N'nguon002', NULL, N'kho002', NULL)
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd002', CAST(N'2021-12-30' AS Date), NULL, N'nv001', N'ncc001', N'nguon001', NULL, N'kho001', NULL)
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd003', CAST(N'1999-09-09' AS Date), N'le loi', N'nv001', N'ncc002', N'nguon002', NULL, N'kho002', NULL)
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd004', CAST(N'2021-12-20' AS Date), NULL, N'nv001', N'ncc001', N'nguon001', NULL, N'kho001', NULL)
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd005', CAST(N'2022-02-20' AS Date), NULL, N'nv001', N'ncc001', N'kho001', NULL, N'kho001', NULL)
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd006', CAST(N'2022-02-23' AS Date), NULL, N'nv007', N'ncc001', N'kho001', NULL, N'kho001', NULL)
GO
INSERT [dbo].[Kho] ([Makho], [Tenkho], [Diadiem]) VALUES (N'kho001', N'Kho BV 103', N'bv103')
INSERT [dbo].[Kho] ([Makho], [Tenkho], [Diadiem]) VALUES (N'kho002', N'Kho Vinmec', N'HCM')
INSERT [dbo].[Kho] ([Makho], [Tenkho], [Diadiem]) VALUES (N'nguon001', N'tsa', NULL)
INSERT [dbo].[Kho] ([Makho], [Tenkho], [Diadiem]) VALUES (N'nguon002', N'tsb', N'1')
GO
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo001', 8681, 150, N'hd001', 100, N'GPI-098', CAST(N'2021-08-08' AS Date), CAST(N'2023-08-08' AS Date), N'100', NULL, N'lo', N'ctdb001', N'ctnd003', N'vt001', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo002', 0, 1, N'hd002', 111, N'GPI-098', CAST(N'2021-08-08' AS Date), CAST(N'2023-08-08' AS Date), N'100', NULL, N'lo', N'ctdb001', N'ctnd001', N'vt001', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo003', 8000, 190, N'hd003', 90, N'GPI-098', CAST(N'2021-08-08' AS Date), CAST(N'2023-08-08' AS Date), N'100', NULL, N'lo', N'ctdb001', N'ctnd001', N'vt002', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo004', 113, 11, N'hd004', 143, N'GPI-098', CAST(N'2021-08-08' AS Date), CAST(N'2023-08-08' AS Date), N'100', NULL, N'lo', N'ctdb001', N'ctnd001', N'vt002', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo005', 800, 111, N'hd004', 10, N'GPI-098', CAST(N'2021-08-08' AS Date), CAST(N'2023-08-08' AS Date), N'100', NULL, N'lo', N'ctdb001', N'ctnd001', N'vt003', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo006', 8790, 190000, N'hd005', 100, NULL, CAST(N'2022-02-03' AS Date), CAST(N'2022-02-23' AS Date), NULL, NULL, NULL, N'ctdb001', N'ctnd001', N'vt001', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo007', 18, 10, N'hd006', 10, NULL, CAST(N'2022-02-03' AS Date), CAST(N'2022-02-25' AS Date), NULL, NULL, NULL, N'ctdb001', N'ctnd001', N'vt001', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo008', 0, 0, N'hd006', 0, NULL, CAST(N'2022-02-02' AS Date), CAST(N'2022-03-19' AS Date), NULL, NULL, NULL, N'ctdb001', N'ctnd001', N'vt002', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo009', 0, 0, N'hd006', 0, NULL, CAST(N'2022-02-08' AS Date), CAST(N'2023-03-15' AS Date), NULL, NULL, NULL, N'ctdb001', N'ctnd001', N'vt001', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo010', 0, 0, N'hd006', 0, NULL, CAST(N'2022-02-08' AS Date), CAST(N'2022-02-15' AS Date), NULL, NULL, NULL, N'ctdb001', N'ctnd001', N'vt001', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo011', 3, 3, NULL, 3, NULL, CAST(N'2022-01-12' AS Date), CAST(N'2022-03-26' AS Date), NULL, NULL, NULL, N'ctdb001', N'ctnd001', N'vt003', NULL)
GO
INSERT [dbo].[Loaimui] ([Maloaimui], [Tenloaimui], [Ten]) VALUES (N'1', N'1', N'Mũi đầu tiên')
INSERT [dbo].[Loaimui] ([Maloaimui], [Tenloaimui], [Ten]) VALUES (N'2', N'2', N'Mũi thứ hai')
INSERT [dbo].[Loaimui] ([Maloaimui], [Tenloaimui], [Ten]) VALUES (N'3', N'3', N'Mũi thứ ba')
GO
INSERT [dbo].[Loaitochuc] ([Maloaitochuc], [Tenloaitochuc]) VALUES (N'ltc001', N'Trường học')
INSERT [dbo].[Loaitochuc] ([Maloaitochuc], [Tenloaitochuc]) VALUES (N'ltc002', N'Doanh nghiệp')
INSERT [dbo].[Loaitochuc] ([Maloaitochuc], [Tenloaitochuc]) VALUES (N'ltc003', N'Đảng ủy')
GO
INSERT [dbo].[Loaitrieuchung] ([Maloaitc], [Tenloaitc], [Ghichu]) VALUES (N'ltc001', N'Nhẹ', NULL)
INSERT [dbo].[Loaitrieuchung] ([Maloaitc], [Tenloaitc], [Ghichu]) VALUES (N'ltc002', N'Nghiêm Trọng', NULL)
INSERT [dbo].[Loaitrieuchung] ([Maloaitc], [Tenloaitc], [Ghichu]) VALUES (N'ltc003', N'Không có', NULL)
GO
INSERT [dbo].[Loaivattuyte] ([Maloaivattu], [Tenloaivattu]) VALUES (N'lvt001', N'Vắc xin')
INSERT [dbo].[Loaivattuyte] ([Maloaivattu], [Tenloaivattu]) VALUES (N'lvt002', N'Bơm kim tiêm')
GO
INSERT [dbo].[Nguon] ([Manguon], [Tennguon]) VALUES (N'kho001', N'WHO')
INSERT [dbo].[Nguon] ([Manguon], [Tennguon]) VALUES (N'kho002', N'UNICEF')
INSERT [dbo].[Nguon] ([Manguon], [Tennguon]) VALUES (N'nguon001', N'KOICA')
INSERT [dbo].[Nguon] ([Manguon], [Tennguon]) VALUES (N'nguon002', N'AIA')
GO
INSERT [dbo].[Nhacungcap] ([Mancc], [Tencc], [Sdt], [Diachi], [Fax], [Sotaikhoan]) VALUES (N'ncc001', N'TCMR Quốc Gia', N'0977127771', N'Phạm Hùng', N'777dsdha6', N'881126661111')
INSERT [dbo].[Nhacungcap] ([Mancc], [Tencc], [Sdt], [Diachi], [Fax], [Sotaikhoan]) VALUES (N'ncc002', N'VinMec', N'0871112561', N'HCM', N'hhaa66y', N'12221666611')
GO
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv001', N'Nguyễn Văn Thuận', N'quản trị hệ thống', N'admin                         ', N'admin', N'0965537001', N'example.com', 1, N'c4ca4238a0b923820dcc509a6f75849b                  ', N'dt001', N'q001', N'tp001', 1, N'p001', NULL)
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv002', N'Võ Trung Quân', N'cán bộ điểm tiêm', N'quan                          ', N'cadres', N'0965537003', N'example.com', 0, N'c4ca4238a0b923820dcc509a6f75849b                  ', N'dt001', N'q001', N'tp001', NULL, N'p001', NULL)
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv003', N'Nguyễn Việt Anh', N'thủ kho', N'anh                           ', N'storage', N'0965537041', N'a.com', 1, N'c4ca4238a0b923820dcc509a6f75849b                  ', N'dt001', N'q001', N'tp001', NULL, N'p001', NULL)
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv004', N'Vũ Văn Sơn', N'kế toán phường', N'son                           ', N'w_account', N'0965537007', N'example.com', 1, N'c4ca4238a0b923820dcc509a6f75849b                  ', N'dt002', N'q001', N'tp001', NULL, N'p001', NULL)
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv005', N'Nguyễn Quang Linh', N'kế toán quận', N'linh                          ', N'd_account', N'0965537066', N'linh.vn', 1, N'c4ca4238a0b923820dcc509a6f75849b                  ', N'dt001', N'q001', N'tp001', NULL, N'p001', NULL)
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv006', N'Nguyễn Quỳnh Mai', N'kế toán thành phố', N'mai                           ', N'c_account', N'0965537044', N'mai.com.vn', 1, N'c4ca4238a0b923820dcc509a6f75849b                  ', N'dt001', N'q001', N'tp001', NULL, N'p001', NULL)
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv007', N'Thuận mới', NULL, N'lanhdao1                      ', N'd_leader', N'1111113', NULL, 1, N'1                                                 ', N'', N'q001', N'tp001', NULL, N'p001', CAST(N'2022-03-11' AS Date))
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv008', N'Thuận mới 3', NULL, N'lanhdao3                      ', N'c_leader', N'1', NULL, 1, N'1                                                 ', N'', N'q001', N'tp001', NULL, N'', CAST(N'2022-03-11' AS Date))
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv009', N'Thuận mới 2', NULL, N'lanhdao2                      ', N'leader', N'0965527001', NULL, 1, N'1                                                 ', N'', N'', N'', 1, N'', CAST(N'2022-03-17' AS Date))
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv010', N'Anh Sơn', NULL, N'anhson                        ', N'cadres', N'0965527001', NULL, 1, N'1                                                 ', N'dt002', N'q001', N'tp001', NULL, N'p001', CAST(N'2022-03-04' AS Date))
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv011', N'Bảo Trâm', N'kế toán quốc gia', N'tram                          ', N'n_account', N'111113333', NULL, 1, N'1                                                 ', N'dt001', N'q001', N'tp001', 1, N'p001', NULL)
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv012', N'ok nhe', NULL, N'ok333                         ', N'w_account', N'', NULL, 1, N'1                                                 ', N'', N'q001', N'tp001', NULL, N'', CAST(N'2022-03-08' AS Date))
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv013', N'ok nhe1', NULL, N'1aa1                          ', NULL, N'1', NULL, 1, N'1                                                 ', N'', N'q001', N'tp001', NULL, N'p001', CAST(N'2022-03-10' AS Date))
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv014', N'ok nhe1', NULL, N'ok3                           ', N'w_account', N'111', NULL, 1, N'1                                                 ', N'', N'q001', N'tp001', NULL, N'p001', CAST(N'2022-03-10' AS Date))
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv015', N'son 3', NULL, N'ok33                          ', NULL, N'', NULL, 1, N'                                                  ', N'dt001', N'q001', N'tp001', NULL, N'p001', CAST(N'2022-03-02' AS Date))
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv016', N'Thuận mới', NULL, N'ok11                          ', NULL, N'1', NULL, 1, N'1                                                 ', N'dt001', N'q001', N'tp001', NULL, N'p001', CAST(N'2022-03-09' AS Date))
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong], [Ngaysinh]) VALUES (N'nv017', N'son ok113', NULL, N'11                            ', N'w_account', N'1', NULL, 0, N'f19026a3939a44d534ac66d0b8d2e553                  ', N'', N'q001', N'tp001', NULL, N'p001', CAST(N'2022-03-14' AS Date))
GO
INSERT [dbo].[Nhasanxuat] ([Mansx], [Tennsx], [Quocgia]) VALUES (N'nsx001', N'Oxford', N'Anh')
INSERT [dbo].[Nhasanxuat] ([Mansx], [Tennsx], [Quocgia]) VALUES (N'nsx002', N'Pfizer', N'Trung Quốc')
INSERT [dbo].[Nhasanxuat] ([Mansx], [Tennsx], [Quocgia]) VALUES (N'nsx003', N'Moderna', N'Úc')
INSERT [dbo].[Nhasanxuat] ([Mansx], [Tennsx], [Quocgia]) VALUES (N'nsx004', N'Nanogen', N'Việt Nam')
INSERT [dbo].[Nhasanxuat] ([Mansx], [Tennsx], [Quocgia]) VALUES (N'nsx005', N'BioNTech', N'Mỹ')
GO
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'admin', N'quản trị')
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'c_account', N'kế toán thành phố')
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'c_leader', N'lãnh đạo thành phố')
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'cadres', N'cán bộ điểm tiêm')
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'd_account', N'kế toán quận')
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'd_leader', N'lãnh đạo quận')
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'leader', N'lãnh đạo quốc gia')
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'n_account', N'kế toán quốc gia')
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'storage', N'thủ kho')
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'w_account', N'kế toán phường')
GO
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'admin', N'ADMIN', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'c_account', N'C_TKE_DKY', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'c_account', N'C_TKE_TIEM', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'c_account', N'D_TKE_DKY', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'c_account', N'D_TKE_TIEM', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'c_account', N'W_TKE_DKY', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'c_account', N'W_TKE_TIEM', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'c_leader', N'QLY_DTIEM', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'c_leader', N'QLY_ND', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'cadres', N'DUTRU', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'cadres', N'NHAP_CP', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'cadres', N'NHAP_TTT', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'cadres', N'XUAT_BACK', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'cadres', N'XUAT_HUY', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'cadres', N'XUAT_SD', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'd_account', N'D_TKE_DKY', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'd_account', N'D_TKE_TIEM', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'd_account', N'W_TKE_DKY', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'd_account', N'W_TKE_TIEM', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'd_leader', N'QLY_DTIEM', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'd_leader', N'QLY_ND', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'leader', N'QLY_DTIEM', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'leader', N'QLY_ND', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'leader', N'QLY_VC', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'n_account', N'C_TKE_DKY', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'n_account', N'C_TKE_TIEM', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'n_account', N'N_TKE_DKY', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'n_account', N'N_TKE_TIEM', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'storage', N'DUTRU', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'storage', N'DUYET_DT', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'storage', N'NHAP_BACK', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'storage', N'NHAP_NCC', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'storage', N'STORAGE', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'storage', N'TONKHO', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'storage', N'XUAT_CP', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'storage', N'XUAT_HUY', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'w_account', N'QLY_ND', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'w_account', N'W_TKE_DKY', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'w_account', N'W_TKE_TIEM', NULL)
GO
INSERT [dbo].[Nhomuutien] ([Manhomuutien], [Tennhomuutien], [Trongso]) VALUES (N'ut1', N'Nhân viên y tế', 1)
INSERT [dbo].[Nhomuutien] ([Manhomuutien], [Tennhomuutien], [Trongso]) VALUES (N'ut2', N'Quân nhân', 2)
INSERT [dbo].[Nhomuutien] ([Manhomuutien], [Tennhomuutien], [Trongso]) VALUES (N'ut3', N'Giáo viên', 2)
INSERT [dbo].[Nhomuutien] ([Manhomuutien], [Tennhomuutien], [Trongso]) VALUES (N'ut4', N'Không', 3)
GO
INSERT [dbo].[Phieudangky] ([Sophieudangky], [Tennguoidan], [CCCD], [SDT], [Ngaysinh], [Matochuc], [Diachi], [Ngaymongmuon], [Matrangthai], [Manhomuutien], [Maphuong], [Buoimongmuon], [Gioitinh], [Email], [Bhyt], [Dantoc], [Quoctich], [Hotengiamho], [Quanhegiamho], [SDTgiamho], [Mathuoc1], [Ngaytiem1], [Malo1], [Diadiemtiem1], [Phanungtiem1], [Hotendangky], [SDTdangky], [Nghenghiep], [Donvicongtac], [Tennhomuutien], [Tenphuong], [Loaimui], [Tentt], [Tenthuoc1]) VALUES (N'pdk001', N'Nguyễn Văn Thuận', N'001200000996', N'0965527001', CAST(N'2000-08-13' AS Date), N'tc001', N'số 8 ngách 112/21', CAST(N'2022-09-03' AS Date), N'tt001', N'ut2', N'p001', N'Sáng', N'Nam', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'vt001', CAST(N'2019-01-05' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Quân nhân', NULL, N'Mũi tiêp theo', N'Chưa duyệt', NULL)
INSERT [dbo].[Phieudangky] ([Sophieudangky], [Tennguoidan], [CCCD], [SDT], [Ngaysinh], [Matochuc], [Diachi], [Ngaymongmuon], [Matrangthai], [Manhomuutien], [Maphuong], [Buoimongmuon], [Gioitinh], [Email], [Bhyt], [Dantoc], [Quoctich], [Hotengiamho], [Quanhegiamho], [SDTgiamho], [Mathuoc1], [Ngaytiem1], [Malo1], [Diadiemtiem1], [Phanungtiem1], [Hotendangky], [SDTdangky], [Nghenghiep], [Donvicongtac], [Tennhomuutien], [Tenphuong], [Loaimui], [Tentt], [Tenthuoc1]) VALUES (N'pdk002', N'Nguyễn Quỳnh Mai', NULL, NULL, NULL, NULL, NULL, NULL, N'tt002', N'ut1', N'p001', NULL, N'Nam', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'vt001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Mũi đầu tiên', N'Chưa duyệt', NULL)
INSERT [dbo].[Phieudangky] ([Sophieudangky], [Tennguoidan], [CCCD], [SDT], [Ngaysinh], [Matochuc], [Diachi], [Ngaymongmuon], [Matrangthai], [Manhomuutien], [Maphuong], [Buoimongmuon], [Gioitinh], [Email], [Bhyt], [Dantoc], [Quoctich], [Hotengiamho], [Quanhegiamho], [SDTgiamho], [Mathuoc1], [Ngaytiem1], [Malo1], [Diadiemtiem1], [Phanungtiem1], [Hotendangky], [SDTdangky], [Nghenghiep], [Donvicongtac], [Tennhomuutien], [Tenphuong], [Loaimui], [Tentt], [Tenthuoc1]) VALUES (N'pdk003', N'Lê Linh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'ut1', N'p001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'vt002', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Phieudangky] ([Sophieudangky], [Tennguoidan], [CCCD], [SDT], [Ngaysinh], [Matochuc], [Diachi], [Ngaymongmuon], [Matrangthai], [Manhomuutien], [Maphuong], [Buoimongmuon], [Gioitinh], [Email], [Bhyt], [Dantoc], [Quoctich], [Hotengiamho], [Quanhegiamho], [SDTgiamho], [Mathuoc1], [Ngaytiem1], [Malo1], [Diadiemtiem1], [Phanungtiem1], [Hotendangky], [SDTdangky], [Nghenghiep], [Donvicongtac], [Tennhomuutien], [Tenphuong], [Loaimui], [Tentt], [Tenthuoc1]) VALUES (N'pdk004', N'Vũ Sơn', N'11114444', N'09113113', CAST(N'2009-03-03' AS Date), NULL, N'thach that', CAST(N'2022-03-02' AS Date), N'tt001', N'ut3', N'p001', N'Chiều', N'Nữ', N'vsmail', N'11', N'Kinh', N'Việt Nam', N'thuận', N'Bố', N'1113', N'vt002', CAST(N'2018-01-05' AS Date), N'lo001', N'aaa', N'no', N'', N'', N'sinh viên', N'mta', N'Giáo viên', N'Yên Nghĩa', N'Mũi tiêp theo', N'Chưa duyệt', NULL)
INSERT [dbo].[Phieudangky] ([Sophieudangky], [Tennguoidan], [CCCD], [SDT], [Ngaysinh], [Matochuc], [Diachi], [Ngaymongmuon], [Matrangthai], [Manhomuutien], [Maphuong], [Buoimongmuon], [Gioitinh], [Email], [Bhyt], [Dantoc], [Quoctich], [Hotengiamho], [Quanhegiamho], [SDTgiamho], [Mathuoc1], [Ngaytiem1], [Malo1], [Diadiemtiem1], [Phanungtiem1], [Hotendangky], [SDTdangky], [Nghenghiep], [Donvicongtac], [Tennhomuutien], [Tenphuong], [Loaimui], [Tentt], [Tenthuoc1]) VALUES (N'pdk005', N'Nguyễn Minh', N'11114444', N'09113113', CAST(N'2022-03-08' AS Date), NULL, N'thach that', CAST(N'2022-03-02' AS Date), N'tt002', N'ut1', N'p001', N'Chiều', N'Nam', N'sngmail.com', N'31', N'Kinh', N'Việt Nam', N'thuận', N'Anh', N'1113', N'vt002', CAST(N'2018-01-03' AS Date), N'lo001', N'aaa', N'no', N'', N'', N'xxx', N'mta', N'Nhân viên y tế', N'Yên Nghĩa', N'Mui tiêp theo', NULL, NULL)
INSERT [dbo].[Phieudangky] ([Sophieudangky], [Tennguoidan], [CCCD], [SDT], [Ngaysinh], [Matochuc], [Diachi], [Ngaymongmuon], [Matrangthai], [Manhomuutien], [Maphuong], [Buoimongmuon], [Gioitinh], [Email], [Bhyt], [Dantoc], [Quoctich], [Hotengiamho], [Quanhegiamho], [SDTgiamho], [Mathuoc1], [Ngaytiem1], [Malo1], [Diadiemtiem1], [Phanungtiem1], [Hotendangky], [SDTdangky], [Nghenghiep], [Donvicongtac], [Tennhomuutien], [Tenphuong], [Loaimui], [Tentt], [Tenthuoc1]) VALUES (N'pdk006', N'Nguyễn Quỳnh Mai', N'11333', N'00113', CAST(N'2022-03-01' AS Date), NULL, N'thach that', CAST(N'2022-03-24' AS Date), NULL, N'ut3', N'p001', N'Sáng', N'Nam', N'son', N'31', N'Kinh', N'Việt Nam', N'thuận', N'Anh', N'1113', N'vt002', CAST(N'2018-01-18' AS Date), N'lo001', N'aaa', N'ko', N'', N'', N'xxx', N'mta', N'Giáo viên', N'Yên Nghĩa', N'Mui tiêm th? nh?t', NULL, NULL)
INSERT [dbo].[Phieudangky] ([Sophieudangky], [Tennguoidan], [CCCD], [SDT], [Ngaysinh], [Matochuc], [Diachi], [Ngaymongmuon], [Matrangthai], [Manhomuutien], [Maphuong], [Buoimongmuon], [Gioitinh], [Email], [Bhyt], [Dantoc], [Quoctich], [Hotengiamho], [Quanhegiamho], [SDTgiamho], [Mathuoc1], [Ngaytiem1], [Malo1], [Diadiemtiem1], [Phanungtiem1], [Hotendangky], [SDTdangky], [Nghenghiep], [Donvicongtac], [Tennhomuutien], [Tenphuong], [Loaimui], [Tentt], [Tenthuoc1]) VALUES (N'pdk007', N'Lê Linh', N'11333', N'09113113', CAST(N'2022-03-02' AS Date), NULL, N'thach that', CAST(N'2022-03-18' AS Date), NULL, N'ut1', N'p001', N'Sáng', N'Nam', N'sngmail.com', N'31', N'Kinh', N'Việt Nam', N'thuận', N'Bố', N'1113', N'vt002', CAST(N'2018-01-03' AS Date), N'lo001', N'aaa', N'khoong co gi caaa', N'', N'', N'xxx', N'mta', N'Nhân viên y tế', N'Yên Nghĩa', N'Mui tiêp theo', NULL, NULL)
INSERT [dbo].[Phieudangky] ([Sophieudangky], [Tennguoidan], [CCCD], [SDT], [Ngaysinh], [Matochuc], [Diachi], [Ngaymongmuon], [Matrangthai], [Manhomuutien], [Maphuong], [Buoimongmuon], [Gioitinh], [Email], [Bhyt], [Dantoc], [Quoctich], [Hotengiamho], [Quanhegiamho], [SDTgiamho], [Mathuoc1], [Ngaytiem1], [Malo1], [Diadiemtiem1], [Phanungtiem1], [Hotendangky], [SDTdangky], [Nghenghiep], [Donvicongtac], [Tennhomuutien], [Tenphuong], [Loaimui], [Tentt], [Tenthuoc1]) VALUES (N'pdk008', N'', N'', N'', NULL, NULL, N'', NULL, NULL, N'ut1', N'p001', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'vt001', NULL, N'', N'', N'', N'', N'', N'', N'', N'Nhân viên y tế', N'Yên Nghĩa', N'', NULL, N'AstraZeneca')
INSERT [dbo].[Phieudangky] ([Sophieudangky], [Tennguoidan], [CCCD], [SDT], [Ngaysinh], [Matochuc], [Diachi], [Ngaymongmuon], [Matrangthai], [Manhomuutien], [Maphuong], [Buoimongmuon], [Gioitinh], [Email], [Bhyt], [Dantoc], [Quoctich], [Hotengiamho], [Quanhegiamho], [SDTgiamho], [Mathuoc1], [Ngaytiem1], [Malo1], [Diadiemtiem1], [Phanungtiem1], [Hotendangky], [SDTdangky], [Nghenghiep], [Donvicongtac], [Tennhomuutien], [Tenphuong], [Loaimui], [Tentt], [Tenthuoc1]) VALUES (N'pdk009', N'Nguyễn Minh Anh', N'11114444', N'0911311377', CAST(N'2008-03-10' AS Date), NULL, N'', CAST(N'2022-03-03' AS Date), N'tt002', N'ut3', N'p001', N'', N'Nữ', N'', N'', N'', N'', N'thuận', N'Bố', N'1113', N'vt001', CAST(N'2018-01-09' AS Date), N'lo001', N'', N'', N'', N'', N'', N'', N'Giáo viên', N'Yên Nghĩa', N'Mui tiêm ti?p theo', NULL, N'AstraZeneca')
INSERT [dbo].[Phieudangky] ([Sophieudangky], [Tennguoidan], [CCCD], [SDT], [Ngaysinh], [Matochuc], [Diachi], [Ngaymongmuon], [Matrangthai], [Manhomuutien], [Maphuong], [Buoimongmuon], [Gioitinh], [Email], [Bhyt], [Dantoc], [Quoctich], [Hotengiamho], [Quanhegiamho], [SDTgiamho], [Mathuoc1], [Ngaytiem1], [Malo1], [Diadiemtiem1], [Phanungtiem1], [Hotendangky], [SDTdangky], [Nghenghiep], [Donvicongtac], [Tennhomuutien], [Tenphuong], [Loaimui], [Tentt], [Tenthuoc1]) VALUES (N'pdk010', N'Vũ Sơn Vu', N'11114444', N'0911311377', CAST(N'2009-03-09' AS Date), NULL, N'', CAST(N'2022-03-03' AS Date), N'tt002', N'ut1', N'p001', N'Sáng', N'Nam', N'', N'', N'', N'', N'thuận', N'Bố', N'1113', N'vt001', CAST(N'2018-01-02' AS Date), N'lo001', N'', N'', N'', N'', N'', N'', N'Nhân viên y tế', N'Yên Nghĩa', N'Mui tiêm ti?p theo', NULL, N'AstraZeneca')
INSERT [dbo].[Phieudangky] ([Sophieudangky], [Tennguoidan], [CCCD], [SDT], [Ngaysinh], [Matochuc], [Diachi], [Ngaymongmuon], [Matrangthai], [Manhomuutien], [Maphuong], [Buoimongmuon], [Gioitinh], [Email], [Bhyt], [Dantoc], [Quoctich], [Hotengiamho], [Quanhegiamho], [SDTgiamho], [Mathuoc1], [Ngaytiem1], [Malo1], [Diadiemtiem1], [Phanungtiem1], [Hotendangky], [SDTdangky], [Nghenghiep], [Donvicongtac], [Tennhomuutien], [Tenphuong], [Loaimui], [Tentt], [Tenthuoc1]) VALUES (N'pdk011', N'Nguyễn Minh Anhh', N'11114444', N'0911311377', CAST(N'2009-03-02' AS Date), NULL, N'', CAST(N'2022-03-04' AS Date), N'tt002', N'ut1', N'p001', N'Sáng', N'Nữ', N'', N'', N'Kinh', N'Việt Nam', N'thuận', N'Bố', N'1113', N'vt001', CAST(N'2018-01-04' AS Date), N'lo001', N'aaa', N'', N'', N'', N'', N'', N'Nhân viên y tế', N'Yên Nghĩa', N'Mui tiêm th? nh?t', NULL, N'AstraZeneca')
INSERT [dbo].[Phieudangky] ([Sophieudangky], [Tennguoidan], [CCCD], [SDT], [Ngaysinh], [Matochuc], [Diachi], [Ngaymongmuon], [Matrangthai], [Manhomuutien], [Maphuong], [Buoimongmuon], [Gioitinh], [Email], [Bhyt], [Dantoc], [Quoctich], [Hotengiamho], [Quanhegiamho], [SDTgiamho], [Mathuoc1], [Ngaytiem1], [Malo1], [Diadiemtiem1], [Phanungtiem1], [Hotendangky], [SDTdangky], [Nghenghiep], [Donvicongtac], [Tennhomuutien], [Tenphuong], [Loaimui], [Tentt], [Tenthuoc1]) VALUES (N'pdk012', N'Nguyễn Anh', N'', N'', CAST(N'2022-03-25' AS Date), NULL, N'', CAST(N'2022-03-03' AS Date), N'tt002', N'ut1', N'p001', N'Sáng', N'', N'', N'', N'', N'', N'', N'', N'', N'vt001', CAST(N'2018-01-03' AS Date), N'lo001', N'', N'', N'', N'', N'', N'', N'Nhân viên y tế', N'Yên Nghĩa', N'Mui tiêm th? nh?t', NULL, N'AstraZeneca')
INSERT [dbo].[Phieudangky] ([Sophieudangky], [Tennguoidan], [CCCD], [SDT], [Ngaysinh], [Matochuc], [Diachi], [Ngaymongmuon], [Matrangthai], [Manhomuutien], [Maphuong], [Buoimongmuon], [Gioitinh], [Email], [Bhyt], [Dantoc], [Quoctich], [Hotengiamho], [Quanhegiamho], [SDTgiamho], [Mathuoc1], [Ngaytiem1], [Malo1], [Diadiemtiem1], [Phanungtiem1], [Hotendangky], [SDTdangky], [Nghenghiep], [Donvicongtac], [Tennhomuutien], [Tenphuong], [Loaimui], [Tentt], [Tenthuoc1]) VALUES (N'pdk013', N'Đỗ Trung Anh', N'11114444', N'', CAST(N'2009-03-11' AS Date), NULL, N'', CAST(N'2022-03-20' AS Date), N'tt003', N'ut4', N'p001', N'Sáng', N'Nam', N'', N'', N'', N'Việt Nam', N'thuận', N'Anh', N'', N'vt001', CAST(N'2018-01-10' AS Date), N'lo001', N'', N'', N'', N'', N'', N'', N'Không', N'Yên Nghĩa', N'Mui tiêp theo', NULL, N'AstraZeneca')
GO
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts001', N'pdk001', N'ko', N'tt001')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts001', N'pdk008', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts001', N'pdk009', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts001', N'pdk010', N'ko', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts001', N'pdk011', N'1', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts001', N'pdk012', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts001', N'pdk013', N'ok', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts002', N'pdk001', N'ok', N'tt001')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts002', N'pdk008', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts002', N'pdk009', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts002', N'pdk010', N'kooo', N'tt001')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts002', N'pdk011', N'11', N'tt001')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts002', N'pdk012', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts002', N'pdk013', N'', N'tt001')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts003', N'pdk008', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts003', N'pdk009', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts003', N'pdk010', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts003', N'pdk011', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts003', N'pdk012', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts003', N'pdk013', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts004', N'pdk008', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts004', N'pdk009', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts004', N'pdk010', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts004', N'pdk011', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts004', N'pdk012', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts004', N'pdk013', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts005', N'pdk008', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts005', N'pdk009', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts005', N'pdk010', N'', N'tt001')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts005', N'pdk011', N'', N'tt001')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts005', N'pdk012', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts005', N'pdk013', N'', N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts006', N'pdk008', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts006', N'pdk009', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts006', N'pdk010', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts006', N'pdk011', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts006', N'pdk012', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts006', N'pdk013', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts007', N'pdk008', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts007', N'pdk009', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts007', N'pdk010', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts007', N'pdk011', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts007', N'pdk012', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts007', N'pdk013', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts008', N'pdk008', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts008', N'pdk009', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts008', N'pdk010', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts008', N'pdk011', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts008', N'pdk012', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts008', N'pdk013', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts009', N'pdk008', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts009', N'pdk009', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts009', N'pdk010', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts009', N'pdk011', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts009', N'pdk012', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts009', N'pdk013', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts010', N'pdk008', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts010', N'pdk009', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts010', N'pdk010', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts010', N'pdk011', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts010', N'pdk012', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts010', N'pdk013', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts011', N'pdk008', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts011', N'pdk009', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts011', N'pdk010', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts011', N'pdk011', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts011', N'pdk012', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts011', N'pdk013', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts012', N'pdk008', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts012', N'pdk009', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts012', N'pdk010', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts012', N'pdk011', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts012', N'pdk012', NULL, N'tt002')
INSERT [dbo].[Phieudky_Tiensu] ([Matiensu], [Maphieudangky], [Trieuchung], [Matrangthai]) VALUES (N'ts012', N'pdk013', NULL, N'tt002')
GO
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl001', CAST(N'1999-09-09' AS Date), N'nv001', N'dt001', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl002', CAST(N'2021-12-23' AS Date), N'nv001', N'dt002', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl003', CAST(N'2022-02-23' AS Date), N'nv007', N'dt002', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl004', CAST(N'2022-02-23' AS Date), N'nv007', N'dt001', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl005', CAST(N'2022-02-23' AS Date), N'nv001', N'dt001', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl006', CAST(N'2022-03-09' AS Date), N'nv001', N'dt001', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl007', CAST(N'2022-03-10' AS Date), N'nv001', N'dt001', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl008', CAST(N'2022-03-14' AS Date), N'nv001', N'dt002', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl009', CAST(N'2022-03-14' AS Date), N'nv001', N'dt001', N'tt001')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl010', CAST(N'2022-03-14' AS Date), N'nv001', N'dt001', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl011', CAST(N'2022-03-14' AS Date), N'nv001', N'dt001', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl012', CAST(N'2022-03-14' AS Date), N'nv001', N'dt001', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl013', CAST(N'2022-03-14' AS Date), N'nv001', N'dt001', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl014', CAST(N'2022-03-14' AS Date), N'nv001', N'dt001', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl015', CAST(N'2022-03-14' AS Date), N'nv001', N'dt001', N'tt003')
GO
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK001', 2)
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK002', 3)
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK003', 5)
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK004', 20)
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK005', 18)
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK006', 19)
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK007', 20)
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK008', 0)
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK009', 0)
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK010', 0)
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK011', 0)
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK012', 0)
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK013', 0)
INSERT [dbo].[Phieuthongke] ([Sophieu], [SLtiem]) VALUES (N'TK014', 0)
GO
INSERT [dbo].[Phieutiem] ([Sophieu], [Tennguoidan], [CCCD], [SDT], [Ngaysinh]) VALUES (N'pt001', N'Nguyễn Văn Thuận', N'001200000996', N'0965527001', CAST(N'2000-08-13T00:00:00.000' AS DateTime))
INSERT [dbo].[Phieutiem] ([Sophieu], [Tennguoidan], [CCCD], [SDT], [Ngaysinh]) VALUES (N'pt002', N'Nguyễn Quỳnh Mai', N'001260050127', N'0967228170', CAST(N'2000-10-17T00:00:00.000' AS DateTime))
INSERT [dbo].[Phieutiem] ([Sophieu], [Tennguoidan], [CCCD], [SDT], [Ngaysinh]) VALUES (N'pt003', N'Trần Mạnh Khanh', N'001866255', N'087331121', CAST(N'1999-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Phieutiem] ([Sophieu], [Tennguoidan], [CCCD], [SDT], [Ngaysinh]) VALUES (N'pt004', N'Lê Đình Đạt', N'99821112', N'1122211', CAST(N'1899-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Phieutiem] ([Sophieu], [Tennguoidan], [CCCD], [SDT], [Ngaysinh]) VALUES (N'pt005', N'Lê Thùy Linh', N'177662', N'112223', CAST(N'2000-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Phieutiem] ([Sophieu], [Tennguoidan], [CCCD], [SDT], [Ngaysinh]) VALUES (N'pt006', N'Tào Mạnh Đức', N'887167177', N'94892487', CAST(N'1994-01-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Phieutiem] ([Sophieu], [Tennguoidan], [CCCD], [SDT], [Ngaysinh]) VALUES (N'pt007', N'Chu Hùng Dũng', N'84779789', N'767679889', CAST(N'1992-11-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Phieutiem] ([Sophieu], [Tennguoidan], [CCCD], [SDT], [Ngaysinh]) VALUES (N'pt008', N'Lê Quang Linh', N'8774655', N'738868787', CAST(N'1990-07-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Phieutiem] ([Sophieu], [Tennguoidan], [CCCD], [SDT], [Ngaysinh]) VALUES (N'pt009', N'Nguyễn Mạnh Đạt', N'38778899', N'89911', CAST(N'1989-05-13T00:00:00.000' AS DateTime))
INSERT [dbo].[Phieutiem] ([Sophieu], [Tennguoidan], [CCCD], [SDT], [Ngaysinh]) VALUES (N'pt010', N'Đỗ Trung Anh', N'001866255', N'0965527001', CAST(N'1984-10-02T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px001', CAST(N'2021-12-22' AS Date), NULL, NULL, N'nv001', N'dt001', N'kho002', NULL, N'tt002', CAST(N'2022-03-04' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px002', CAST(N'2021-12-22' AS Date), NULL, NULL, N'nv001', N'dt001', N'kho001', NULL, N'tt002', CAST(N'2022-03-05' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px003', CAST(N'2021-12-23' AS Date), NULL, NULL, NULL, N'dt001', N'kho001', NULL, N'tt002', CAST(N'2021-12-23' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px004', CAST(N'2021-12-23' AS Date), NULL, NULL, NULL, N'dt001', N'kho001', NULL, N'tt002', CAST(N'2021-12-23' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px005', CAST(N'2021-12-23' AS Date), NULL, NULL, NULL, N'dt001', N'kho002', NULL, N'tt002', CAST(N'2021-12-23' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px006', CAST(N'2021-12-23' AS Date), NULL, NULL, NULL, N'dt001', N'kho001', NULL, N'tt002', CAST(N'2021-12-23' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px007', CAST(N'2022-03-03' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px008', CAST(N'2022-05-03' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px009', CAST(N'2022-03-05' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px010', CAST(N'2022-03-05' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px011', CAST(N'2022-03-05' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px012', CAST(N'2022-03-05' AS Date), NULL, NULL, N'nv001', N'dt001', N'kho001', NULL, N'tt002', CAST(N'2022-03-05' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px013', CAST(N'2022-03-09' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px014', CAST(N'2022-03-09' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-09' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px015', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px016', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px017', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px018', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-14' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px019', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px020', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px021', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px022', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px023', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px024', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px025', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px026', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px027', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px028', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px029', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px030', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px031', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px032', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px033', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px034', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px035', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px036', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px037', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px038', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px039', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px040', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt002', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px041', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px042', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px043', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px044', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-13' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px045', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv001', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-14' AS Date), NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang], [Ngaynhap], [Ghichu]) VALUES (N'px046', CAST(N'2022-03-14' AS Date), NULL, NULL, N'nv002', N'dt001', NULL, NULL, N'tt002', CAST(N'2022-03-14' AS Date), NULL)
GO
INSERT [dbo].[Phieuxuathuy] ([Sophieuxuat], [Ghichu], [Manhanvien], [Ngayxuat]) VALUES (N'pxh001', N'vỡ hết các lô', NULL, CAST(N'2022-01-01' AS Date))
INSERT [dbo].[Phieuxuathuy] ([Sophieuxuat], [Ghichu], [Manhanvien], [Ngayxuat]) VALUES (N'pxh002', N'hết hạn 3 lô', NULL, CAST(N'2021-05-03' AS Date))
INSERT [dbo].[Phieuxuathuy] ([Sophieuxuat], [Ghichu], [Manhanvien], [Ngayxuat]) VALUES (N'pxh003', N'', NULL, CAST(N'2022-02-19' AS Date))
INSERT [dbo].[Phieuxuathuy] ([Sophieuxuat], [Ghichu], [Manhanvien], [Ngayxuat]) VALUES (N'pxh004', N'', NULL, CAST(N'2022-02-19' AS Date))
INSERT [dbo].[Phieuxuathuy] ([Sophieuxuat], [Ghichu], [Manhanvien], [Ngayxuat]) VALUES (N'pxh005', N'', N'nv001', CAST(N'2022-02-23' AS Date))
INSERT [dbo].[Phieuxuathuy] ([Sophieuxuat], [Ghichu], [Manhanvien], [Ngayxuat]) VALUES (N'pxh006', N'', N'nv001', CAST(N'2022-02-23' AS Date))
INSERT [dbo].[Phieuxuathuy] ([Sophieuxuat], [Ghichu], [Manhanvien], [Ngayxuat]) VALUES (N'pxh007', N'', N'nv007', CAST(N'2022-02-23' AS Date))
INSERT [dbo].[Phieuxuathuy] ([Sophieuxuat], [Ghichu], [Manhanvien], [Ngayxuat]) VALUES (N'pxh008', N'', N'nv001', CAST(N'2022-03-04' AS Date))
INSERT [dbo].[Phieuxuathuy] ([Sophieuxuat], [Ghichu], [Manhanvien], [Ngayxuat]) VALUES (N'pxh009', N'', N'nv001', CAST(N'2022-03-06' AS Date))
GO
INSERT [dbo].[Phieuxuattralai] ([Sophieuxuat], [Madiemtiem], [Ngayxuat], [Manhanvien], [Matinhtrang], [Ghichu], [Ngaynhap], [Manhanvien2]) VALUES (N'ptl001', N'dt001', CAST(N'2021-06-06' AS Date), N'nv001', N'tt002', NULL, CAST(N'2022-03-04' AS Date), N'nv001')
INSERT [dbo].[Phieuxuattralai] ([Sophieuxuat], [Madiemtiem], [Ngayxuat], [Manhanvien], [Matinhtrang], [Ghichu], [Ngaynhap], [Manhanvien2]) VALUES (N'ptl002', N'dt001', CAST(N'2021-06-07' AS Date), N'nv001', N'tt002', NULL, CAST(N'2021-07-07' AS Date), NULL)
INSERT [dbo].[Phieuxuattralai] ([Sophieuxuat], [Madiemtiem], [Ngayxuat], [Manhanvien], [Matinhtrang], [Ghichu], [Ngaynhap], [Manhanvien2]) VALUES (N'ptl003', N'dt001', CAST(N'2022-03-04' AS Date), N'nv001', N'tt002', NULL, CAST(N'2022-03-04' AS Date), N'nv001')
INSERT [dbo].[Phieuxuattralai] ([Sophieuxuat], [Madiemtiem], [Ngayxuat], [Manhanvien], [Matinhtrang], [Ghichu], [Ngaynhap], [Manhanvien2]) VALUES (N'ptl004', N'dt001', CAST(N'2022-03-09' AS Date), N'nv001', N'tt002', NULL, CAST(N'2022-03-09' AS Date), N'nv001')
INSERT [dbo].[Phieuxuattralai] ([Sophieuxuat], [Madiemtiem], [Ngayxuat], [Manhanvien], [Matinhtrang], [Ghichu], [Ngaynhap], [Manhanvien2]) VALUES (N'ptl005', N'dt001', CAST(N'2022-03-14' AS Date), N'nv001', N'tt002', NULL, CAST(N'2022-03-14' AS Date), N'nv001')
INSERT [dbo].[Phieuxuattralai] ([Sophieuxuat], [Madiemtiem], [Ngayxuat], [Manhanvien], [Matinhtrang], [Ghichu], [Ngaynhap], [Manhanvien2]) VALUES (N'ptl006', N'dt001', CAST(N'2022-03-14' AS Date), N'nv001', N'tt002', NULL, CAST(N'2022-03-14' AS Date), N'nv001')
INSERT [dbo].[Phieuxuattralai] ([Sophieuxuat], [Madiemtiem], [Ngayxuat], [Manhanvien], [Matinhtrang], [Ghichu], [Ngaynhap], [Manhanvien2]) VALUES (N'ptl007', N'dt001', CAST(N'2022-03-14' AS Date), N'nv001', N'tt002', NULL, CAST(N'2022-03-14' AS Date), N'nv001')
INSERT [dbo].[Phieuxuattralai] ([Sophieuxuat], [Madiemtiem], [Ngayxuat], [Manhanvien], [Matinhtrang], [Ghichu], [Ngaynhap], [Manhanvien2]) VALUES (N'ptl008', N'dt001', CAST(N'2022-03-14' AS Date), N'nv001', N'tt002', NULL, CAST(N'2022-03-14' AS Date), N'nv001')
INSERT [dbo].[Phieuxuattralai] ([Sophieuxuat], [Madiemtiem], [Ngayxuat], [Manhanvien], [Matinhtrang], [Ghichu], [Ngaynhap], [Manhanvien2]) VALUES (N'ptl009', N'dt001', CAST(N'2022-03-14' AS Date), N'nv002', N'tt002', NULL, CAST(N'2022-03-14' AS Date), N'nv007')
GO
INSERT [dbo].[Phuong] ([Maphuong], [Tenphuong], [Maquan]) VALUES (N'p001', N'Yên Nghĩa', N'q001')
INSERT [dbo].[Phuong] ([Maphuong], [Tenphuong], [Maquan]) VALUES (N'p002', N'La Khê', N'q001')
INSERT [dbo].[Phuong] ([Maphuong], [Tenphuong], [Maquan]) VALUES (N'p003', N'Hà Cầu', N'q001')
INSERT [dbo].[Phuong] ([Maphuong], [Tenphuong], [Maquan]) VALUES (N'p004', N'Dịch Vọng', N'q002')
INSERT [dbo].[Phuong] ([Maphuong], [Tenphuong], [Maquan]) VALUES (N'p005', N'Nghĩa Tân', N'q002')
GO
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q001', N'Hà Đông', N'tp001')
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q002', N'Cầu Giấy', N'tp001')
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q003', N'Bắc Từ Liêm', N'tp001')
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q004', N'Thanh Xuân', N'tp001')
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q005', N'Ba Đình', N'tp001')
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q006', N'Hoàn Kiếm', N'tp001')
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q007', N'Tây Hồ', N'tp001')
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q008', N'Nam Từ Liêm', N'tp001')
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q009', N'Ba Vì', NULL)
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q010', N'Mỹ Đức', NULL)
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q011', N'Thạch Thất', NULL)
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q012', N'Quốc Oai', NULL)
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q013', N'Phúc Thọ', NULL)
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q014', N'Mê Linh', NULL)
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q015', N'Thường Tín', NULL)
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q016', N'Thanh Oai', NULL)
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q017', N'Phú Xuyên', NULL)
GO
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'ADMIN', N'quản trị')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'C_TKE_DKY', N'thống kê sl đky tpho')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'C_TKE_TIEM', N'thống kê sl tiêm thành phố')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'D_TKE_DKY', N'thống kê sl đky quận')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'D_TKE_TIEM', N'thống kê sl tiêm quận')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'DUTRU', N'dự trù')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'DUYET_DT', N'duyệt dự trù')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'N_TKE_DKY', N'thống kê sl đky qg')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'N_TKE_TIEM', N'thống kê sl tiêm qg')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'NHAP_BACK', N'nhập trả lại')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'NHAP_CP', N'nhập cấp phát')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'NHAP_NCC', N'nhập từ nhà cung cấp')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'NHAP_TTT', N'nhập ttin tiêm')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'QLY_DTIEM', N'quản lý điểm tiêm')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'QLY_ND', N'quản lý người dùng')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'QLY_VC', N'quản lý vaccine')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'STORAGE', N'kho')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'TONKHO', N'xem tồn kho')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'W_TKE_DKY', N'thống kê sl đky phường')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'W_TKE_TIEM', N'thống kê sl tiêm _phườn')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'XUAT_BACK', N'xuất trả lại')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'XUAT_CP', N'cấp phát ')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'XUAT_HUY', N'xuất hủy')
INSERT [dbo].[Quyen] ([Maquyen], [Tenquyen]) VALUES (N'XUAT_SD', N'xuất sử dụng')
GO
INSERT [dbo].[Thanhpho] ([Mathanhpho], [Tenthanhpho]) VALUES (N'tp001', N'Hà Nội')
INSERT [dbo].[Thanhpho] ([Mathanhpho], [Tenthanhpho]) VALUES (N'tp002', N'Bắc Ninh')
INSERT [dbo].[Thanhpho] ([Mathanhpho], [Tenthanhpho]) VALUES (N'tp003', N'Hồ Chí Minh')
INSERT [dbo].[Thanhpho] ([Mathanhpho], [Tenthanhpho]) VALUES (N'tp004', N'Vĩnh Phúc')
GO
INSERT [dbo].[Tiensu] ([Matiensu], [Trieuchung], [Ten], [Ghiro]) VALUES (N'ts001', 1, N'1. Tiền sử phản vệ độ 2 trở lên', N'Nếu có, ghi rõ loại tác nhân dị ứng')
INSERT [dbo].[Tiensu] ([Matiensu], [Trieuchung], [Ten], [Ghiro]) VALUES (N'ts002', 0, N'2. Tiền sử bị COVID-19 trong 6 tháng', NULL)
INSERT [dbo].[Tiensu] ([Matiensu], [Trieuchung], [Ten], [Ghiro]) VALUES (N'ts003', 1, N'3. Tiền sử tiêm vắc xin trong 14 ngày qua', N'Nếu có, ghi rõ loại vắc xin')
INSERT [dbo].[Tiensu] ([Matiensu], [Trieuchung], [Ten], [Ghiro]) VALUES (N'ts004', 0, N'4. Tiền sử suy giảm miễn dịch, ung thư giai đoạn cuối, cắt lách, xơ gan mất bù...', NULL)
INSERT [dbo].[Tiensu] ([Matiensu], [Trieuchung], [Ten], [Ghiro]) VALUES (N'ts005', 0, N'5. Đang dùng thuốc ức chế miễn dịch, corticoid liều ca (tương đương hoặc hơn 2mg prednisolon/kg/ngày trong ít nhất 7 ngày) hoặc điều trị hóa trị, xạ trị', NULL)
INSERT [dbo].[Tiensu] ([Matiensu], [Trieuchung], [Ten], [Ghiro]) VALUES (N'ts006', 1, N'6. Bệnh cấp tính', N'Nếu có, ghi rõ loại bệnh mắc')
INSERT [dbo].[Tiensu] ([Matiensu], [Trieuchung], [Ten], [Ghiro]) VALUES (N'ts007', 1, N'7. Tiền sử bệnh mạn tính, đang tiến triển', N'Nếu có, ghi rõ loại bệnh mắc')
INSERT [dbo].[Tiensu] ([Matiensu], [Trieuchung], [Ten], [Ghiro]) VALUES (N'ts008', 0, N'8. Tiền sử bệnh mạn tính đã điều trị ổn', NULL)
INSERT [dbo].[Tiensu] ([Matiensu], [Trieuchung], [Ten], [Ghiro]) VALUES (N'ts009', 0, N'9. Đang mang thai, phụ nữ đang nuôi con bằng sữa mẹ', NULL)
INSERT [dbo].[Tiensu] ([Matiensu], [Trieuchung], [Ten], [Ghiro]) VALUES (N'ts010', 0, N'10. Độ tuổi >= 65 tuổi', NULL)
INSERT [dbo].[Tiensu] ([Matiensu], [Trieuchung], [Ten], [Ghiro]) VALUES (N'ts011', 0, N'11. Tiền sử rối loạn đông máu/cầm máu hoặc đang dùng thuốc chống đông', NULL)
INSERT [dbo].[Tiensu] ([Matiensu], [Trieuchung], [Ten], [Ghiro]) VALUES (N'ts012', 1, N'12. Tiền sử dị ứng với các dị nguyên khác', N'Nếu có, ghi rõ')
GO
INSERT [dbo].[Tinhtrangphieudk] ([Matrangthai], [Tentranthai]) VALUES (N'tt001', N'Chưa duyệt')
INSERT [dbo].[Tinhtrangphieudk] ([Matrangthai], [Tentranthai]) VALUES (N'tt002', N'Đã duyệt')
INSERT [dbo].[Tinhtrangphieudk] ([Matrangthai], [Tentranthai]) VALUES (N'tt003', N'Đã xác nhận')
INSERT [dbo].[Tinhtrangphieudk] ([Matrangthai], [Tentranthai]) VALUES (N'tt004', N'Đã tiêm')
GO
INSERT [dbo].[Tinhtrangpx] ([Matinhtrang], [Tentinhtrang]) VALUES (N'tt001', N'Đang vận chuyển')
INSERT [dbo].[Tinhtrangpx] ([Matinhtrang], [Tentinhtrang]) VALUES (N'tt002', N'Đã nhận')
GO
INSERT [dbo].[Tinhtrangpxuattralai] ([Matrangthai], [Tentrangthai]) VALUES (N'tt001', N'Chưa duyệt')
INSERT [dbo].[Tinhtrangpxuattralai] ([Matrangthai], [Tentrangthai]) VALUES (N'tt002', N'Đã duyệt')
GO
INSERT [dbo].[Tochuc] ([Matochuc], [Tentochuc], [Taikhoan], [Matkhau], [Tennguoidungdau], [SDT], [Diachi], [Maloaitochuc]) VALUES (N'tc001', N'Trường Tiểu học Yên Nghĩa', N'thyn', N'1', N'Trần Thị Quyên', N'0961118893', N'Trần Phú', N'ltc001')
INSERT [dbo].[Tochuc] ([Matochuc], [Tentochuc], [Taikhoan], [Matkhau], [Tennguoidungdau], [SDT], [Diachi], [Maloaitochuc]) VALUES (N'tc002', N'Đảng ủy Phường Yên Nghĩa', N'dypyn', N'1', N'Phạm Minh', N'077199911', N'Hòa Bình', N'ltc003')
GO
INSERT [dbo].[Trangthai] ([Matrangthai], [Tentrangthai]) VALUES (N'tt001', N'Chưa duyệt')
INSERT [dbo].[Trangthai] ([Matrangthai], [Tentrangthai]) VALUES (N'tt002', N'Đã duyệt')
INSERT [dbo].[Trangthai] ([Matrangthai], [Tentrangthai]) VALUES (N'tt003', N'Đã cấp phát')
INSERT [dbo].[Trangthai] ([Matrangthai], [Tentrangthai]) VALUES (N'tt004', N'Đang vận chuyển')
INSERT [dbo].[Trangthai] ([Matrangthai], [Tentrangthai]) VALUES (N'tt005', N'Đã nhận')
GO
INSERT [dbo].[Trangthaitiensu] ([Matrangthai], [Tentrangthai]) VALUES (N'tt001', N'Có')
INSERT [dbo].[Trangthaitiensu] ([Matrangthai], [Tentrangthai]) VALUES (N'tt002', N'Không')
INSERT [dbo].[Trangthaitiensu] ([Matrangthai], [Tentrangthai]) VALUES (N'tt003', N'Không rõ')
GO
INSERT [dbo].[Vattuyte] ([Mavattu], [Tenvattu], [Mansx], [Maloaivattu], [Trangthai]) VALUES (N'vt001', N'AstraZeneca', N'nsx001', N'lvt001', 1)
INSERT [dbo].[Vattuyte] ([Mavattu], [Tenvattu], [Mansx], [Maloaivattu], [Trangthai]) VALUES (N'vt002', N'Pfizer', N'nsx002', N'lvt001', 1)
INSERT [dbo].[Vattuyte] ([Mavattu], [Tenvattu], [Mansx], [Maloaivattu], [Trangthai]) VALUES (N'vt003', N'Vero Cell', N'nsx003', N'lvt001', 1)
INSERT [dbo].[Vattuyte] ([Mavattu], [Tenvattu], [Mansx], [Maloaivattu], [Trangthai]) VALUES (N'vt004', N'BKT', N'nsx001', N'lvt002', 1)
INSERT [dbo].[Vattuyte] ([Mavattu], [Tenvattu], [Mansx], [Maloaivattu], [Trangthai]) VALUES (N'vt005', N'bkt China', N'nsx004', N'lvt002', 0)
GO
ALTER TABLE [dbo].[Donglinh] ADD  CONSTRAINT [IDDL]  DEFAULT ([DBO].[AUTO_IDDL]()) FOR [Madonglinh]
GO
ALTER TABLE [dbo].[Dongxuat] ADD  CONSTRAINT [IDDX]  DEFAULT ([DBO].[AUTO_IDDX]()) FOR [Madongxuat]
GO
ALTER TABLE [dbo].[Phieudangky] ADD  CONSTRAINT [DF_Phieudangky_Ngaytiem1]  DEFAULT (NULL) FOR [Ngaytiem1]
GO
ALTER TABLE [dbo].[Phieuthongke] ADD  CONSTRAINT [IDPTK]  DEFAULT ([DBO].[AUTO_IDPTK]()) FOR [Sophieu]
GO
ALTER TABLE [dbo].[Chitietphhieutiem]  WITH CHECK ADD  CONSTRAINT [FK_Chitietphhieutiem_Diemtiem] FOREIGN KEY([Madiemtiem])
REFERENCES [dbo].[Diemtiem] ([Madiemtiem])
GO
ALTER TABLE [dbo].[Chitietphhieutiem] CHECK CONSTRAINT [FK_Chitietphhieutiem_Diemtiem]
GO
ALTER TABLE [dbo].[Chitietphhieutiem]  WITH CHECK ADD  CONSTRAINT [FK_Chitietphhieutiem_Lo] FOREIGN KEY([Malo])
REFERENCES [dbo].[Lo] ([Malo])
GO
ALTER TABLE [dbo].[Chitietphhieutiem] CHECK CONSTRAINT [FK_Chitietphhieutiem_Lo]
GO
ALTER TABLE [dbo].[Chitietphhieutiem]  WITH CHECK ADD  CONSTRAINT [FK_Chitietphhieutiem_Loaitrieuchung] FOREIGN KEY([Loaitc])
REFERENCES [dbo].[Loaitrieuchung] ([Maloaitc])
GO
ALTER TABLE [dbo].[Chitietphhieutiem] CHECK CONSTRAINT [FK_Chitietphhieutiem_Loaitrieuchung]
GO
ALTER TABLE [dbo].[Chitietphhieutiem]  WITH CHECK ADD  CONSTRAINT [FK_Chitietphhieutiem_Phieutiem] FOREIGN KEY([Sophieutiem])
REFERENCES [dbo].[Phieutiem] ([Sophieu])
GO
ALTER TABLE [dbo].[Chitietphhieutiem] CHECK CONSTRAINT [FK_Chitietphhieutiem_Phieutiem]
GO
ALTER TABLE [dbo].[Diemtiem]  WITH CHECK ADD  CONSTRAINT [FK_Diemtiem_Phuong] FOREIGN KEY([Maphuong])
REFERENCES [dbo].[Phuong] ([Maphuong])
GO
ALTER TABLE [dbo].[Diemtiem] CHECK CONSTRAINT [FK_Diemtiem_Phuong]
GO
ALTER TABLE [dbo].[Donglinh]  WITH CHECK ADD  CONSTRAINT [FK_Donglinh_Phieulinh] FOREIGN KEY([Sophieulinh])
REFERENCES [dbo].[Phieulinh] ([Sophieulinh])
GO
ALTER TABLE [dbo].[Donglinh] CHECK CONSTRAINT [FK_Donglinh_Phieulinh]
GO
ALTER TABLE [dbo].[Donglinh]  WITH CHECK ADD  CONSTRAINT [FK_Donglinh_Vattuyte] FOREIGN KEY([Mathuoc])
REFERENCES [dbo].[Vattuyte] ([Mavattu])
GO
ALTER TABLE [dbo].[Donglinh] CHECK CONSTRAINT [FK_Donglinh_Vattuyte]
GO
ALTER TABLE [dbo].[Dongxuat]  WITH CHECK ADD  CONSTRAINT [FK_Dongxuat_Lo] FOREIGN KEY([Malo])
REFERENCES [dbo].[Lo] ([Malo])
GO
ALTER TABLE [dbo].[Dongxuat] CHECK CONSTRAINT [FK_Dongxuat_Lo]
GO
ALTER TABLE [dbo].[Dongxuat]  WITH CHECK ADD  CONSTRAINT [FK_Dongxuat_Phieuxuat] FOREIGN KEY([Sophieuxuat])
REFERENCES [dbo].[Phieuxuat] ([Sophieuxuat])
GO
ALTER TABLE [dbo].[Dongxuat] CHECK CONSTRAINT [FK_Dongxuat_Phieuxuat]
GO
ALTER TABLE [dbo].[Dongxuathuy]  WITH CHECK ADD  CONSTRAINT [FK_Dongxuathuy_Lo] FOREIGN KEY([Malo])
REFERENCES [dbo].[Lo] ([Malo])
GO
ALTER TABLE [dbo].[Dongxuathuy] CHECK CONSTRAINT [FK_Dongxuathuy_Lo]
GO
ALTER TABLE [dbo].[Dongxuathuy]  WITH CHECK ADD  CONSTRAINT [FK_Dongxuathuy_Phieuxuathuy] FOREIGN KEY([Maphieuxuathuy])
REFERENCES [dbo].[Phieuxuathuy] ([Sophieuxuat])
GO
ALTER TABLE [dbo].[Dongxuathuy] CHECK CONSTRAINT [FK_Dongxuathuy_Phieuxuathuy]
GO
ALTER TABLE [dbo].[Dongxuattralai]  WITH CHECK ADD  CONSTRAINT [FK_Dongxuattralai_Lo] FOREIGN KEY([Malo])
REFERENCES [dbo].[Lo] ([Malo])
GO
ALTER TABLE [dbo].[Dongxuattralai] CHECK CONSTRAINT [FK_Dongxuattralai_Lo]
GO
ALTER TABLE [dbo].[Dongxuattralai]  WITH CHECK ADD  CONSTRAINT [FK_Dongxuattralai_Phieuxuattralai] FOREIGN KEY([Sophieuxuat])
REFERENCES [dbo].[Phieuxuattralai] ([Sophieuxuat])
GO
ALTER TABLE [dbo].[Dongxuattralai] CHECK CONSTRAINT [FK_Dongxuattralai_Phieuxuattralai]
GO
ALTER TABLE [dbo].[Hoadonnhap]  WITH CHECK ADD FOREIGN KEY([Mancc])
REFERENCES [dbo].[Nhacungcap] ([Mancc])
GO
ALTER TABLE [dbo].[Hoadonnhap]  WITH CHECK ADD  CONSTRAINT [FK_Hoadonnhap_Kho] FOREIGN KEY([Makhonhap])
REFERENCES [dbo].[Kho] ([Makho])
GO
ALTER TABLE [dbo].[Hoadonnhap] CHECK CONSTRAINT [FK_Hoadonnhap_Kho]
GO
ALTER TABLE [dbo].[Hoadonnhap]  WITH CHECK ADD  CONSTRAINT [FK_Hoadonnhap_Nguon] FOREIGN KEY([Manguon])
REFERENCES [dbo].[Nguon] ([Manguon])
GO
ALTER TABLE [dbo].[Hoadonnhap] CHECK CONSTRAINT [FK_Hoadonnhap_Nguon]
GO
ALTER TABLE [dbo].[Lo]  WITH CHECK ADD  CONSTRAINT [FK_Lo_Chithidongbang] FOREIGN KEY([Machithidongbang])
REFERENCES [dbo].[Chithidongbang] ([Machithidongbang])
GO
ALTER TABLE [dbo].[Lo] CHECK CONSTRAINT [FK_Lo_Chithidongbang]
GO
ALTER TABLE [dbo].[Lo]  WITH CHECK ADD  CONSTRAINT [FK_Lo_Chithinhietdo] FOREIGN KEY([Machithinhietdo])
REFERENCES [dbo].[Chithinhietdo] ([Machithinhietdo])
GO
ALTER TABLE [dbo].[Lo] CHECK CONSTRAINT [FK_Lo_Chithinhietdo]
GO
ALTER TABLE [dbo].[Lo]  WITH CHECK ADD  CONSTRAINT [FK_Lo_Hoadonnhap] FOREIGN KEY([Sohoadon])
REFERENCES [dbo].[Hoadonnhap] ([Sohoadon])
GO
ALTER TABLE [dbo].[Lo] CHECK CONSTRAINT [FK_Lo_Hoadonnhap]
GO
ALTER TABLE [dbo].[Lo]  WITH CHECK ADD  CONSTRAINT [FK_Lo_Vattuyte] FOREIGN KEY([Mavattu])
REFERENCES [dbo].[Vattuyte] ([Mavattu])
GO
ALTER TABLE [dbo].[Lo] CHECK CONSTRAINT [FK_Lo_Vattuyte]
GO
ALTER TABLE [dbo].[Nhanvien]  WITH CHECK ADD  CONSTRAINT [FK_Nhanvien_Nhomnhanvien] FOREIGN KEY([Manhom])
REFERENCES [dbo].[Nhomnhanvien] ([Manhomnv])
GO
ALTER TABLE [dbo].[Nhanvien] CHECK CONSTRAINT [FK_Nhanvien_Nhomnhanvien]
GO
ALTER TABLE [dbo].[Nhomnv_Quyen]  WITH CHECK ADD  CONSTRAINT [FK_Nhomnv_Quyen_Nhomnhanvien] FOREIGN KEY([Manhomnv])
REFERENCES [dbo].[Nhomnhanvien] ([Manhomnv])
GO
ALTER TABLE [dbo].[Nhomnv_Quyen] CHECK CONSTRAINT [FK_Nhomnv_Quyen_Nhomnhanvien]
GO
ALTER TABLE [dbo].[Nhomnv_Quyen]  WITH CHECK ADD  CONSTRAINT [FK_Nhomnv_Quyen_Quyen] FOREIGN KEY([Maquyen])
REFERENCES [dbo].[Quyen] ([Maquyen])
GO
ALTER TABLE [dbo].[Nhomnv_Quyen] CHECK CONSTRAINT [FK_Nhomnv_Quyen_Quyen]
GO
ALTER TABLE [dbo].[Phieudangky]  WITH CHECK ADD  CONSTRAINT [FK_Phieudangky_Nhomuutien] FOREIGN KEY([Manhomuutien])
REFERENCES [dbo].[Nhomuutien] ([Manhomuutien])
GO
ALTER TABLE [dbo].[Phieudangky] CHECK CONSTRAINT [FK_Phieudangky_Nhomuutien]
GO
ALTER TABLE [dbo].[Phieudangky]  WITH CHECK ADD  CONSTRAINT [FK_Phieudangky_Phuong] FOREIGN KEY([Maphuong])
REFERENCES [dbo].[Phuong] ([Maphuong])
GO
ALTER TABLE [dbo].[Phieudangky] CHECK CONSTRAINT [FK_Phieudangky_Phuong]
GO
ALTER TABLE [dbo].[Phieudangky]  WITH CHECK ADD  CONSTRAINT [FK_Phieudangky_Tinhtrangphieudk] FOREIGN KEY([Matrangthai])
REFERENCES [dbo].[Tinhtrangphieudk] ([Matrangthai])
GO
ALTER TABLE [dbo].[Phieudangky] CHECK CONSTRAINT [FK_Phieudangky_Tinhtrangphieudk]
GO
ALTER TABLE [dbo].[Phieudangky]  WITH CHECK ADD  CONSTRAINT [FK_Phieudangky_Tochuc] FOREIGN KEY([Matochuc])
REFERENCES [dbo].[Tochuc] ([Matochuc])
GO
ALTER TABLE [dbo].[Phieudangky] CHECK CONSTRAINT [FK_Phieudangky_Tochuc]
GO
ALTER TABLE [dbo].[Phieudangky]  WITH CHECK ADD  CONSTRAINT [FK_Phieudangky_Vattuyte] FOREIGN KEY([Mathuoc1])
REFERENCES [dbo].[Vattuyte] ([Mavattu])
GO
ALTER TABLE [dbo].[Phieudangky] CHECK CONSTRAINT [FK_Phieudangky_Vattuyte]
GO
ALTER TABLE [dbo].[Phieudky_Tiensu]  WITH CHECK ADD  CONSTRAINT [FK_Phieudky_Tiensu_Phieudangky] FOREIGN KEY([Maphieudangky])
REFERENCES [dbo].[Phieudangky] ([Sophieudangky])
GO
ALTER TABLE [dbo].[Phieudky_Tiensu] CHECK CONSTRAINT [FK_Phieudky_Tiensu_Phieudangky]
GO
ALTER TABLE [dbo].[Phieudky_Tiensu]  WITH CHECK ADD  CONSTRAINT [FK_Phieudky_Tiensu_Tiensu] FOREIGN KEY([Matiensu])
REFERENCES [dbo].[Tiensu] ([Matiensu])
GO
ALTER TABLE [dbo].[Phieudky_Tiensu] CHECK CONSTRAINT [FK_Phieudky_Tiensu_Tiensu]
GO
ALTER TABLE [dbo].[Phieudky_Tiensu]  WITH CHECK ADD  CONSTRAINT [FK_Phieudky_Tiensu_Trangthaitiensu] FOREIGN KEY([Matrangthai])
REFERENCES [dbo].[Trangthaitiensu] ([Matrangthai])
GO
ALTER TABLE [dbo].[Phieudky_Tiensu] CHECK CONSTRAINT [FK_Phieudky_Tiensu_Trangthaitiensu]
GO
ALTER TABLE [dbo].[Phieulinh]  WITH CHECK ADD FOREIGN KEY([Madiemtiem])
REFERENCES [dbo].[Diemtiem] ([Madiemtiem])
GO
ALTER TABLE [dbo].[Phieulinh]  WITH CHECK ADD  CONSTRAINT [FK_Phieulinh_Trangthai] FOREIGN KEY([Matt])
REFERENCES [dbo].[Trangthai] ([Matrangthai])
GO
ALTER TABLE [dbo].[Phieulinh] CHECK CONSTRAINT [FK_Phieulinh_Trangthai]
GO
ALTER TABLE [dbo].[Phieuxuat]  WITH CHECK ADD FOREIGN KEY([Madiemtiem])
REFERENCES [dbo].[Diemtiem] ([Madiemtiem])
GO
ALTER TABLE [dbo].[Phieuxuat]  WITH CHECK ADD  CONSTRAINT [FK_Phieuxuat_Kho] FOREIGN KEY([Makhoxuat])
REFERENCES [dbo].[Kho] ([Makho])
GO
ALTER TABLE [dbo].[Phieuxuat] CHECK CONSTRAINT [FK_Phieuxuat_Kho]
GO
ALTER TABLE [dbo].[Phieuxuat]  WITH CHECK ADD  CONSTRAINT [FK_Phieuxuat_Tinhtrangpx] FOREIGN KEY([Matinhtrang])
REFERENCES [dbo].[Tinhtrangpx] ([Matinhtrang])
GO
ALTER TABLE [dbo].[Phieuxuat] CHECK CONSTRAINT [FK_Phieuxuat_Tinhtrangpx]
GO
ALTER TABLE [dbo].[Phieuxuattralai]  WITH CHECK ADD  CONSTRAINT [FK_Phieuxuattralai_Diemtiem] FOREIGN KEY([Madiemtiem])
REFERENCES [dbo].[Diemtiem] ([Madiemtiem])
GO
ALTER TABLE [dbo].[Phieuxuattralai] CHECK CONSTRAINT [FK_Phieuxuattralai_Diemtiem]
GO
ALTER TABLE [dbo].[Phieuxuattralai]  WITH CHECK ADD  CONSTRAINT [FK_Phieuxuattralai_Tinhtrangpxuattralai] FOREIGN KEY([Matinhtrang])
REFERENCES [dbo].[Tinhtrangpxuattralai] ([Matrangthai])
GO
ALTER TABLE [dbo].[Phieuxuattralai] CHECK CONSTRAINT [FK_Phieuxuattralai_Tinhtrangpxuattralai]
GO
ALTER TABLE [dbo].[Phuong]  WITH CHECK ADD  CONSTRAINT [FK_Phuong_Quan] FOREIGN KEY([Maquan])
REFERENCES [dbo].[Quan] ([Maquan])
GO
ALTER TABLE [dbo].[Phuong] CHECK CONSTRAINT [FK_Phuong_Quan]
GO
ALTER TABLE [dbo].[Quan]  WITH CHECK ADD  CONSTRAINT [FK_Quan_Thanhpho] FOREIGN KEY([Mathanhpho])
REFERENCES [dbo].[Thanhpho] ([Mathanhpho])
GO
ALTER TABLE [dbo].[Quan] CHECK CONSTRAINT [FK_Quan_Thanhpho]
GO
ALTER TABLE [dbo].[Tochuc]  WITH CHECK ADD  CONSTRAINT [FK_Tochuc_Loaitochuc] FOREIGN KEY([Maloaitochuc])
REFERENCES [dbo].[Loaitochuc] ([Maloaitochuc])
GO
ALTER TABLE [dbo].[Tochuc] CHECK CONSTRAINT [FK_Tochuc_Loaitochuc]
GO
ALTER TABLE [dbo].[Vattuyte]  WITH CHECK ADD  CONSTRAINT [FK_Vattuyte_Loaivattuyte] FOREIGN KEY([Maloaivattu])
REFERENCES [dbo].[Loaivattuyte] ([Maloaivattu])
GO
ALTER TABLE [dbo].[Vattuyte] CHECK CONSTRAINT [FK_Vattuyte_Loaivattuyte]
GO
ALTER TABLE [dbo].[Vattuyte]  WITH CHECK ADD  CONSTRAINT [FK_Vattuyte_Nhasanxuat] FOREIGN KEY([Mansx])
REFERENCES [dbo].[Nhasanxuat] ([Mansx])
GO
ALTER TABLE [dbo].[Vattuyte] CHECK CONSTRAINT [FK_Vattuyte_Nhasanxuat]
GO
/****** Object:  StoredProcedure [dbo].[Capnhatphieutiem]    Script Date: 3/16/2022 9:49:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Capnhatphieutiem] @Ngaytiem date, @Loaimui char(1), @Madiemtiem char(10) ,
@Malo char(10), @loaitc char(10), @trieuchung char(30), @sophieutiem char(10), @ghichu char(30) as
begin
declare @mathuoc char(10),
@tenthuoc nvarchar(10)
select @mathuoc = v.Mavattu, @tenthuoc = v.Tenvattu
from Chitietphhieutiem c join Lo l on l.Malo = c.Malo
join Vattuyte v on v.Mavattu = l.Mavattu
begin
	begin try
		begin tran
		set transaction isolation level Serializable
		insert into Chitietphhieutiem (Ngaytiem, Loaimui, Madiemtiem, Malo,Mathuoc, Tenthuoc,
		Loaitc,Trieuchung,Sophieutiem,Ghichu)
		values
		(@Ngaytiem, @Loaimui, @Madiemtiem, @Malo, @mathuoc, @tenthuoc, @loaitc, @trieuchung,@sophieutiem, @ghichu)
		commit tran;
	end try
	begin catch
		declare @error nvarchar(150)
		SET @error = N'Đã xảy ra lỗi: ' + ERROR_MESSAGE()
		RAISERROR (@error, 16, 1)
		ROLLBACK tran
		return
	end catch
	end
end
GO
/****** Object:  StoredProcedure [dbo].[show_sltiem]    Script Date: 3/16/2022 9:49:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[show_sltiem] (@so INT) as
begin
declare @dtz datetime = (SELECT DATEADD(day, DATEDIFF(day, 0, (SELECT DATEADD(d, @so-30, GETDATE()))), '00:00:00'));
declare @sl int = 0;

 --select sum(Slastra1) + sum(Slastra2) + sum(Slastra3) + sum(Slpfi1) + sum(Slpfi2) + sum(Slpfi3) + sum(Slvero1) + sum(Slvero2) + sum(Slvero3) as SLtiem
	--from ThongKeTongSl_Quan_All1(@dtz) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
	--join Phuong p on p.Maphuong = d.Maphuong join Quan q on q.Maquan = p.Maquan
	--join Thanhpho t on t.Mathanhpho = q.Mathanhpho
set @sl =( select sum(Slastra1) + sum(Slastra2) + sum(Slastra3) + sum(Slpfi1) + sum(Slpfi2) + sum(Slpfi3) + sum(Slvero1) + sum(Slvero2) + sum(Slvero3) as SLtiem
	from ThongKeTongSl_Quan_All1(@dtz) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
	join Phuong p on p.Maphuong = d.Maphuong join Quan q on q.Maquan = p.Maquan
	join Thanhpho t on t.Mathanhpho = q.Mathanhpho)

	if( @sl is not null)
	begin
	select @sl ;
	end

	else
	begin
	select 0 ;
	end
	
end
GO
/****** Object:  StoredProcedure [dbo].[show_sltiem1]    Script Date: 3/16/2022 9:49:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[show_sltiem1] (@matp char(10)) as
begin
declare @dtz datetime = '2000-1-1 14:56:59';
declare @dtz1 datetime = (SELECT GETDATE());
declare @sl int = 0;

 --select sum(Slastra1) + sum(Slastra2) + sum(Slastra3) + sum(Slpfi1) + sum(Slpfi2) + sum(Slpfi3) + sum(Slvero1) + sum(Slvero2) + sum(Slvero3) as SLtiem
	--from ThongKeTongSl_Quan_All1(@dtz) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
	--join Phuong p on p.Maphuong = d.Maphuong join Quan q on q.Maquan = p.Maquan
	--join Thanhpho t on t.Mathanhpho = q.Mathanhpho
set @sl =( select sum(Slastra1) + sum(Slastra2) + sum(Slastra3) + sum(Slpfi1) + sum(Slpfi2) + sum(Slpfi3) + sum(Slvero1) + sum(Slvero2) + sum(Slvero3) as SLtiem
	from ThongKeTongSl_Quan_All(@dtz, @dtz1) c join Diemtiem d on c.MaDiemTiem = d.Madiemtiem 
	join Phuong p on p.Maphuong = d.Maphuong join Quan q on q.Maquan = p.Maquan
	join Thanhpho t on t.Mathanhpho = q.Mathanhpho
	where t.Mathanhpho = @matp)

	if( @sl is not null)
	begin
	select @sl ;
	end

	else
	begin
	select 0 ;
	end
	
end

GO
/****** Object:  StoredProcedure [dbo].[Sp_Account_Login]    Script Date: 3/16/2022 9:49:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Sp_Account_Login]
@UserName char(30),
@Password char(30)
as
begin
declare @count int
declare @res bit
select @count = count(*) from Nhanvien
where Taikhoan = @username and
Matkhau = @Password

if(@count > 0)
set @res = 1

else
set @res = 0

select @res
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Ct_Phieulinh]    Script Date: 3/16/2022 9:49:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_Insert_Ct_Phieulinh] 
@Madonglinh varchar(10), @Mathuoc varchar(10), @SLyeucau int, @SLcapphat int as
begin
	begin try
		begin tran
		set transaction isolation level Serializable
		insert into Donglinh(Madonglinh, Mathuoc, SLyeucau, SLcapphat)
		values
		(@Madonglinh, @Mathuoc, @SLyeucau, @SLcapphat)
		commit tran;
	end try
	begin catch
		declare @error nvarchar(150)
		SET @error = N'Đã xảy ra lỗi: ' + ERROR_MESSAGE()
		RAISERROR (@error, 16, 1)
		ROLLBACK tran
		return
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Phieulinh]    Script Date: 3/16/2022 9:49:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SP_Insert_Phieulinh] 
@Sophieulinh varchar(10), @Madiemtiem varchar(10), @Manhanvien varchar(10),@Ngayyc date, @Matt varchar(10) as
begin
	begin try
		begin tran
		set transaction isolation level Serializable
		insert into Phieulinh(Sophieulinh, Madiemtiem, Manhanvien, Ngayyeucau, Matt)
		values
		(@Sophieulinh, @Madiemtiem, @Manhanvien, @Ngayyc, @Matt)

		Update Donglinh
		set Sophieulinh = @Sophieulinh
		where Sophieulinh is null
		commit tran;
	end try
	begin catch
		declare @error nvarchar(150)
		SET @error = N'Đã xảy ra lỗi: ' + ERROR_MESSAGE()
		RAISERROR (@error, 16, 1)
		ROLLBACK tran
		return
	end catch
end

GO
/****** Object:  StoredProcedure [dbo].[Themchitietphieutiem]    Script Date: 3/16/2022 9:49:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Themchitietphieutiem] @Ngaytiem date, @Loaimui char(1), @Madiemtiem char(10) ,
@Malo char(10), @loaitc char(10), @trieuchung char(30), @sophieutiem char(10), @ghichu char(30) as
begin
declare @mathuoc char(10),
@tenthuoc nvarchar(10)
select @mathuoc = v.Mavattu, @tenthuoc = v.Tenvattu
from Chitietphhieutiem c join Lo l on l.Malo = c.Malo
join Vattuyte v on v.Mavattu = l.Mavattu
begin
	begin try
		begin tran
		insert into Chitietphhieutiem (Ngaytiem, Loaimui, Madiemtiem, Malo,Mathuoc, Tenthuoc,
		Loaitc,Trieuchung,Sophieutiem,Ghichu)
		values
		(@Ngaytiem, @Loaimui, @Madiemtiem, @Malo, @mathuoc, @tenthuoc, @loaitc, @trieuchung,@sophieutiem, @ghichu)
		commit tran;
	end try
	begin catch
		declare @error nvarchar(150)
		SET @error = N'Đã xảy ra lỗi: ' + ERROR_MESSAGE()
		RAISERROR (@error, 16, 1)
		ROLLBACK tran
		return
	end catch
	end
end
GO
USE [master]
GO
ALTER DATABASE [CSDL_Nangcao] SET  READ_WRITE 
GO
