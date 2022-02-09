USE [master]
GO
/****** Object:  Database [CSDL_Nangcao]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDDL]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDDX]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDPTK]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_MaDT]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_MaDT1]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_QG]    Script Date: 2/9/2022 2:46:32 PM ******/
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

	if( @case = N'dt')
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
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_Quan]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_Quan_All]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_Quan1]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_Tiem]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_TP]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_TP1]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[ThongKeTongSl_TP2]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Chithidongbang]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Chithinhietdo]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Chitietphhieutiem]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Diemtiem]    Script Date: 2/9/2022 2:46:32 PM ******/
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
PRIMARY KEY CLUSTERED 
(
	[Madiemtiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donglinh]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Dongxuat]    Script Date: 2/9/2022 2:46:32 PM ******/
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
PRIMARY KEY CLUSTERED 
(
	[Madongxuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hoadonnhap]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Kho]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Lo]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Loaitrieuchung]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Loaivattuyte]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Nguon]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Nhacungcap]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Nhanvien]    Script Date: 2/9/2022 2:46:32 PM ******/
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
PRIMARY KEY CLUSTERED 
(
	[Manhanvien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhasanxuat]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Nhomnhanvien]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Nhomnv_Quyen]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Phieulinh]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Phieuthongke]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Phieutiem]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Phieuxuat]    Script Date: 2/9/2022 2:46:32 PM ******/
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
PRIMARY KEY CLUSTERED 
(
	[Sophieuxuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phuong]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Quan]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Quyen]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Thanhpho]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Tinhtrangpx]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Trangthai]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  Table [dbo].[Vattuyte]    Script Date: 2/9/2022 2:46:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vattuyte](
	[Mavattu] [varchar](10) NOT NULL,
	[Tenvattu] [nvarchar](100) NULL,
	[Mansx] [varchar](10) NULL,
	[Maloaivattu] [varchar](10) NULL,
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
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt003', CAST(N'2021-01-03' AS Date), N'1', N'Ngất', N'vt003', N'pt002', N'dt003', N'HĐ', N'vero cell', N'ltc002', N'đã cấp cứu thành công', NULL, N'lo988z')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt006', CAST(N'2020-09-09' AS Date), N'2', N'Nhẹ', N'vt003', N'pt002', N'dt002', N'BVE', N'vero cell', N'ltc001', NULL, NULL, N'lo988z')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt007', CAST(N'2020-01-01' AS Date), N'1', NULL, N'vt001', NULL, N'dt001', NULL, NULL, NULL, NULL, NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt0911', CAST(N'2021-12-02' AS Date), N'1', N'tử vong', N'vt002', N'pt005', N'dt001', N'Tytp Yên Nghĩa', N'pfizer', N'ltc002', N'tử vong', NULL, N'loa011')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt0990', CAST(N'1999-09-09' AS Date), N'3', NULL, N'vt001', NULL, N'dt002', NULL, NULL, NULL, NULL, NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctpt0991', CAST(N'2019-01-01' AS Date), N'3', NULL, N'vt001', N'pt001', N'dt001', NULL, NULL, N'ltc002', N'tử vong', NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctptldd01', CAST(N'2021-12-23' AS Date), N'1', NULL, N'vt001', N'pt004', N'dt001', NULL, NULL, NULL, NULL, NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctptnql01', CAST(N'2021-12-23' AS Date), N'1', N'không', N'vt001', N'pt008', N'dt001', NULL, NULL, NULL, N'k', NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctptxql01', CAST(N'2021-12-23' AS Date), N'2', N'không', N'vt001', N'pt009', N'dt001', NULL, NULL, NULL, N'k', NULL, N'lo001')
INSERT [dbo].[Chitietphhieutiem] ([Machitietphieutiem], [Ngaytiem], [Loaimui], [Trieuchung], [Mathuoc], [Sophieutiem], [Madiemtiem], [Tendiemtiem], [Tenthuoc], [Loaitc], [Ghichu], [Tenloaitc], [Malo]) VALUES (N'ctptxql03', CAST(N'2021-12-31' AS Date), N'3', N'ko', N'vt001', N'pt009', N'dt001', NULL, NULL, NULL, N'3', NULL, N'lo001')
GO
INSERT [dbo].[Diemtiem] ([Madiemtiem], [Tendiemtiem], [Tennguoidungdau], [Maquan], [Tenquan], [Maphuong], [Diachi], [Sobantiem]) VALUES (N'dt001', N'Trạm ytp Yên Nghĩa', N'Mạnh', N'q001', N'Hà Đông', N'p001', N'Số 8 đường Hòa Bình, Yên Nghĩa ', 1)
INSERT [dbo].[Diemtiem] ([Madiemtiem], [Tendiemtiem], [Tennguoidungdau], [Maquan], [Tenquan], [Maphuong], [Diachi], [Sobantiem]) VALUES (N'dt002', N'BV 103', N'Tuấn', N'q001', N'Hà Đông', N'p001', N'Phùng Hưng', 2)
INSERT [dbo].[Diemtiem] ([Madiemtiem], [Tendiemtiem], [Tennguoidungdau], [Maquan], [Tenquan], [Maphuong], [Diachi], [Sobantiem]) VALUES (N'dt003', N'BV E', N'Hùng', N'q002', N'Cầu Giấy', N'p005', N'Phùng Hưng', 1)
INSERT [dbo].[Diemtiem] ([Madiemtiem], [Tendiemtiem], [Tennguoidungdau], [Maquan], [Tenquan], [Maphuong], [Diachi], [Sobantiem]) VALUES (N'dt004', N'BV LMN', N'Khang', N'q003', N'Bắc Từ Liêm', N'p004', N'Phùng Hưng', 1)
INSERT [dbo].[Diemtiem] ([Madiemtiem], [Tendiemtiem], [Tennguoidungdau], [Maquan], [Tenquan], [Maphuong], [Diachi], [Sobantiem]) VALUES (N'dt005', N'Trạm ytp TXT', N'Linh', N'q004', N'Thanh Xuân', N'p004', N'Phùng Hưng', 1)
INSERT [dbo].[Diemtiem] ([Madiemtiem], [Tendiemtiem], [Tennguoidungdau], [Maquan], [Tenquan], [Maphuong], [Diachi], [Sobantiem]) VALUES (N'dt006', N'Trạm ytp Hà Cầu', N'Minh', N'q001', N'Hà Đông', N'p003', N'Phùng Hưng', 1)
GO
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'DL001', N'pl005', N'vt001', 10, 5)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dltst1', N'pltst4', N'vt001', 7, 5)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dltst2', N'pltst4', N'vt001', 7, 7)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dlxx', N'pl003', N'vt001', 1, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dlxx01', N'pxk01', N'vt001', 180, 100)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dlxx11', N'pl001', N'vt001', 19, 0)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dlxx12', N'pxk02', N'vt001', 50, NULL)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dlxx13', N'pxk02', N'vt002', 50, 50)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dlxx15', N'pxk01xd', N'vt001', 40, NULL)
INSERT [dbo].[Donglinh] ([Madonglinh], [Sophieulinh], [Mathuoc], [SLyeucau], [SLcapphat]) VALUES (N'dlxx16', N'pxk01xd', N'vt002', 60, NULL)
GO
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc]) VALUES (N'DX001', N'no', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc]) VALUES (N'DX002', N'no', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc]) VALUES (N'dx005', N'px002', N'lo001', 69, 8, NULL, NULL, N'vt001')
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc]) VALUES (N'dx005z', N'pl006z', N'lo001', 100, 5, NULL, NULL, N'vt001')
INSERT [dbo].[Dongxuat] ([Madongxuat], [Sophieuxuat], [Malo], [SLxuat], [Dongia], [Thanhtien], [Tenthuoc], [Mathuoc]) VALUES (N'dxk05', N'pxk03', N'lo001', 100, 5, NULL, NULL, N'vt001')
GO
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd001', CAST(N'1989-06-06' AS Date), N'pham hung', NULL, N'ncc002', N'nguon002', NULL, N'kho002', NULL)
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd003', CAST(N'1999-09-09' AS Date), N'le loi', NULL, N'ncc002', N'nguon002', NULL, N'kho002', NULL)
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd004', CAST(N'2021-12-20' AS Date), NULL, NULL, N'ncc001', N'nguon001', NULL, N'kho001', NULL)
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd97eq', CAST(N'2021-12-30' AS Date), NULL, N'nv002', N'ncc001', N'nguon001', NULL, N'kho001', NULL)
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd98z3', CAST(N'2021-12-30' AS Date), NULL, N'nv002', N'ncc001', N'nguon001', NULL, N'kho001', NULL)
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd98zacz', CAST(N'2021-12-30' AS Date), NULL, N'nv002', N'ncc001', N'nguon001', NULL, N'kho001', NULL)
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd99za1', CAST(N'2021-12-30' AS Date), NULL, N'nv002', N'ncc001', N'nguon001', NULL, N'kho001', NULL)
INSERT [dbo].[Hoadonnhap] ([Sohoadon], [Ngaynhap], [Diadiem], [Manhanvien], [Mancc], [Manguon], [Ghichu], [Makhonhap], [Tongtien]) VALUES (N'hd9z9', CAST(N'2021-12-30' AS Date), NULL, N'nv002', N'ncc001', N'nguon001', NULL, N'kho001', NULL)
GO
INSERT [dbo].[Kho] ([Makho], [Tenkho], [Diadiem]) VALUES (N'kho001', N'Kho BV 103', N'bv103')
INSERT [dbo].[Kho] ([Makho], [Tenkho], [Diadiem]) VALUES (N'kho002', N'Kho Vinmec', N'HCM')
INSERT [dbo].[Kho] ([Makho], [Tenkho], [Diadiem]) VALUES (N'nguon001', N'tsa', NULL)
INSERT [dbo].[Kho] ([Makho], [Tenkho], [Diadiem]) VALUES (N'nguon002', N'tsb', N'1')
GO
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo001', 8800, 150, N'hd001', 100, NULL, NULL, NULL, N'100', NULL, N'lo', N'ctdb001', N'ctnd003', N'vt001', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo003', 8000, 190, N'hd003', 90, NULL, NULL, NULL, N'100', NULL, N'lo', N'ctdb001', N'ctnd001', N'vt002', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo00za1', 1, 1, N'hd99za1', 111, NULL, NULL, NULL, NULL, NULL, NULL, N'ctdb001', N'ctnd001', N'vt001', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'lo988z', 112, 11, N'hd004', 143, NULL, NULL, NULL, NULL, NULL, NULL, N'ctdb001', N'ctnd001', N'vt002', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'loa011', 800, 111, N'hd004', 10, NULL, NULL, NULL, NULL, NULL, NULL, N'ctdb001', N'ctnd001', N'vt003', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'ma97eq', 18, 80, N'hd97eq', 11, NULL, NULL, NULL, NULL, NULL, NULL, N'ctdb001', N'ctnd001', N'vt001', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'ma99z3', 1, 1, N'hd98z3', 11, NULL, NULL, NULL, NULL, NULL, NULL, N'ctdb001', N'ctnd001', N'vt001', NULL)
INSERT [dbo].[Lo] ([Malo], [SLnhap], [Dongia], [Sohoadon], [Solieutrenmotcai], [SDK_gnpk], [NSX], [HSD], [Nongdo], [Hopchat], [Dangdonggoi], [Machithidongbang], [Machithinhietdo], [Mavattu], [Thanhtien]) VALUES (N'ma99zza', 11, 100, N'hd98zacz', 1, NULL, NULL, NULL, NULL, NULL, NULL, N'ctdb001', N'ctnd001', N'vt001', NULL)
GO
INSERT [dbo].[Loaitrieuchung] ([Maloaitc], [Tenloaitc], [Ghichu]) VALUES (N'ltc001', N'Nhẹ', NULL)
INSERT [dbo].[Loaitrieuchung] ([Maloaitc], [Tenloaitc], [Ghichu]) VALUES (N'ltc002', N'Nghiêm Trọng', NULL)
INSERT [dbo].[Loaitrieuchung] ([Maloaitc], [Tenloaitc], [Ghichu]) VALUES (N'ltc003', N'Không có', NULL)
GO
INSERT [dbo].[Loaivattuyte] ([Maloaivattu], [Tenloaivattu]) VALUES (N'lvt001', N'Vắc xin')
INSERT [dbo].[Loaivattuyte] ([Maloaivattu], [Tenloaivattu]) VALUES (N'lvt002', N'Bơm kim tiêm')
GO
INSERT [dbo].[Nguon] ([Manguon], [Tennguon]) VALUES (N'kho001', N'tst')
INSERT [dbo].[Nguon] ([Manguon], [Tennguon]) VALUES (N'kho002', N'tss')
INSERT [dbo].[Nguon] ([Manguon], [Tennguon]) VALUES (N'nguon001', N'UNICEF')
INSERT [dbo].[Nguon] ([Manguon], [Tennguon]) VALUES (N'nguon002', N'WHO')
GO
INSERT [dbo].[Nhacungcap] ([Mancc], [Tencc], [Sdt], [Diachi], [Fax], [Sotaikhoan]) VALUES (N'ncc001', N'TCMR Quốc Gia', N'0977127771', N'Phạm Hùng', N'777dsdha6', N'881126661111')
INSERT [dbo].[Nhacungcap] ([Mancc], [Tencc], [Sdt], [Diachi], [Fax], [Sotaikhoan]) VALUES (N'ncc002', N'VinMec', N'0871112561', N'HCM', N'hhaa66y', N'12221666611')
GO
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong]) VALUES (N'nv001', N'Nguyễn Văn Thuận', N'quản trị hệ thống', N'admin                         ', N'admin', N'0965537001', N'example.com', 1, N'c4ca4238a0b923820dcc509a6f75849b                  ', N'dt001', N'q001', N'tp001', NULL, N'p001')
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong]) VALUES (N'nv002', N'Võ Trung Quân', N'cán bộ điểm tiêm', N'quan                          ', N'cadres', N'0965537003', N'example.com', 1, N'c4ca4238a0b923820dcc509a6f75849b                  ', N'dt002', NULL, NULL, NULL, NULL)
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong]) VALUES (N'nv003', N'Nguyễn Đình Việt Anh', N'thủ kho', N'anh                           ', N'storage', N'0965537005', N'example.com', 1, N'c4ca4238a0b923820dcc509a6f75849b                  ', N'dt002', NULL, NULL, NULL, NULL)
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong]) VALUES (N'nv004', N'Vũ Văn Sơn', N'kế toán phường', N'son                           ', N'w_account', N'0965537007', N'example.com', 1, N'c4ca4238a0b923820dcc509a6f75849b                  ', N'dt002', NULL, NULL, NULL, NULL)
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong]) VALUES (N'nv005', N'Nguyễn Quang Linh', N'kế toán quận', N'linh                          ', N'd_account', N'113', N'linh.vn', 1, N'c4ca4238a0b923820dcc509a6f75849b                  ', N'dt001', NULL, NULL, NULL, NULL)
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong]) VALUES (N'nv006', N'Nguyễn Quỳnh Mai', N'kế toán thành phố', N'mai                           ', N'c_account', N'114', N'mai.com.vn', 1, N'c4ca4238a0b923820dcc509a6f75849b                  ', N'dt001', NULL, NULL, NULL, NULL)
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong]) VALUES (N'nv007', N'Trần Mạnh Đức', N'lãnh đạo', N'duc                           ', N'leader', N'115', N'duc.zing.vn', 1, N'1                                                 ', N'dt001', NULL, NULL, NULL, NULL)
INSERT [dbo].[Nhanvien] ([Manhanvien], [Tennhanvien], [Chucvu], [Taikhoan], [Manhom], [SDT], [Email], [Trangthai], [Matkhau], [Madiemtiem], [Maquan], [Mathanhpho], [Tkqg], [Maphuong]) VALUES (N'nv008', N'Nguyễn Khánh Hiệp', N'kế toán phường', N'hiep                          ', N'n_account', N'116', N'hiep.com.vn', 1, N'c4ca4238a0b923820dcc509a6f75849b                  ', N'dt003', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'admin', N'quản trị')
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'c_account', N'kế toán thành phố')
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'cadres', N'cán bộ điểm tiêm')
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'd_account', N'kế toán quận')
INSERT [dbo].[Nhomnhanvien] ([Manhomnv], [Tennhomnv]) VALUES (N'leader', N'lãnh đạo')
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
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'cadres', N'DUTRU', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'cadres', N'NHAP_CP', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'cadres', N'NHAP_TTT', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'cadres', N'XUAT_BACK', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'cadres', N'XUAT_SD', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'd_account', N'D_TKE_DKY', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'd_account', N'D_TKE_TIEM', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'd_account', N'W_TKE_DKY', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'd_account', N'W_TKE_TIEM', NULL)
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
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'w_account', N'W_TKE_DKY', NULL)
INSERT [dbo].[Nhomnv_Quyen] ([Manhomnv], [Maquyen], [Chuthich]) VALUES (N'w_account', N'W_TKE_TIEM', NULL)
GO
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'no', CAST(N'2021-12-22' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'NULL', CAST(N'2021-11-22' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl001', CAST(N'1999-09-09' AS Date), NULL, N'dt001', N'tt003')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl003', CAST(N'2021-12-22' AS Date), NULL, N'dt001', N'tt001')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl004', CAST(N'2021-12-22' AS Date), NULL, N'dt001', N'tt001')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pl005', CAST(N'2021-12-11' AS Date), NULL, N'dt001', N'tt001')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pltst4', CAST(N'2021-07-05' AS Date), NULL, N'dt001', N'tt001')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pxk01', CAST(N'2021-12-23' AS Date), NULL, N'dt001', N'tt001')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pxk01xd', CAST(N'2021-12-23' AS Date), N'', N'dt001', N'tt001')
INSERT [dbo].[Phieulinh] ([Sophieulinh], [Ngayyeucau], [Manhanvien], [Madiemtiem], [Matt]) VALUES (N'pxk02', CAST(N'2021-12-23' AS Date), NULL, N'dt001', N'tt002')
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
INSERT [dbo].[Phieutiem] ([Sophieu], [Tennguoidan], [CCCD], [SDT], [Ngaysinh]) VALUES (N'pt009', N'Nguyễn Mạnh Đạt', N'38778897', N'89911', CAST(N'1982-05-13T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang]) VALUES (N'no', NULL, NULL, NULL, NULL, N'dt001', NULL, NULL, NULL)
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang]) VALUES (N'pl006z', CAST(N'2021-12-23' AS Date), NULL, NULL, NULL, N'dt001', N'kho001', NULL, N'tt002')
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang]) VALUES (N'px001', CAST(N'2021-12-22' AS Date), NULL, NULL, NULL, N'dt001', NULL, NULL, N'tt002')
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang]) VALUES (N'px002', CAST(N'2021-12-22' AS Date), NULL, NULL, NULL, N'dt001', N'kho001', NULL, N'tt002')
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang]) VALUES (N'pxk01a', CAST(N'2021-12-23' AS Date), NULL, NULL, NULL, N'dt001', N'kho001', NULL, N'tt002')
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang]) VALUES (N'pxk03', CAST(N'2021-12-23' AS Date), NULL, NULL, NULL, N'dt001', N'kho002', NULL, N'tt001')
INSERT [dbo].[Phieuxuat] ([Sophieuxuat], [Ngayxuat], [Khoxuat], [Khonhan], [Manhanvien], [Madiemtiem], [Makhoxuat], [Tongtien], [Matinhtrang]) VALUES (N'pxk033', CAST(N'2021-12-23' AS Date), NULL, NULL, NULL, N'dt001', N'kho001', NULL, NULL)
GO
INSERT [dbo].[Phuong] ([Maphuong], [Tenphuong], [Maquan]) VALUES (N'p001', N'Yên Nghĩa', N'q001')
INSERT [dbo].[Phuong] ([Maphuong], [Tenphuong], [Maquan]) VALUES (N'p002', N'La Khê', N'q001')
INSERT [dbo].[Phuong] ([Maphuong], [Tenphuong], [Maquan]) VALUES (N'p003', N'Hà Cầu', N'q001')
INSERT [dbo].[Phuong] ([Maphuong], [Tenphuong], [Maquan]) VALUES (N'p004', N'Dịch Vọng', N'q002')
INSERT [dbo].[Phuong] ([Maphuong], [Tenphuong], [Maquan]) VALUES (N'p005', N'Nghĩa Tân', N'q002')
GO
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q001', N'Hà Đông', N'tp001')
INSERT [dbo].[Quan] ([Maquan], [Tenquan], [Mathanhpho]) VALUES (N'q002', N'Cầu Giấy', N'tp003')
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
INSERT [dbo].[Tinhtrangpx] ([Matinhtrang], [Tentinhtrang]) VALUES (N'tt001', N'Đã nhận')
INSERT [dbo].[Tinhtrangpx] ([Matinhtrang], [Tentinhtrang]) VALUES (N'tt002', N'Đang vận chuyển')
GO
INSERT [dbo].[Trangthai] ([Matrangthai], [Tentrangthai]) VALUES (N'tt001', N'Chưa duyệt')
INSERT [dbo].[Trangthai] ([Matrangthai], [Tentrangthai]) VALUES (N'tt002', N'Đã duyệt')
INSERT [dbo].[Trangthai] ([Matrangthai], [Tentrangthai]) VALUES (N'tt003', N'Đã duyệt 1 phần')
GO
INSERT [dbo].[Vattuyte] ([Mavattu], [Tenvattu], [Mansx], [Maloaivattu]) VALUES (N'vt001', N'AstraZeneca', NULL, N'lvt001')
INSERT [dbo].[Vattuyte] ([Mavattu], [Tenvattu], [Mansx], [Maloaivattu]) VALUES (N'vt002', N'Pfizer', NULL, N'lvt001')
INSERT [dbo].[Vattuyte] ([Mavattu], [Tenvattu], [Mansx], [Maloaivattu]) VALUES (N'vt003', N'Vero Cell', NULL, N'lvt001')
INSERT [dbo].[Vattuyte] ([Mavattu], [Tenvattu], [Mansx], [Maloaivattu]) VALUES (N'vt004', N'BKT', NULL, N'lvt002')
GO
ALTER TABLE [dbo].[Donglinh] ADD  CONSTRAINT [IDDL]  DEFAULT ([DBO].[AUTO_IDDL]()) FOR [Madonglinh]
GO
ALTER TABLE [dbo].[Dongxuat] ADD  CONSTRAINT [IDDX]  DEFAULT ([DBO].[AUTO_IDDX]()) FOR [Madongxuat]
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
/****** Object:  StoredProcedure [dbo].[Capnhatphieutiem]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Sp_Account_Login]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Insert_Ct_Phieulinh]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Insert_Phieulinh]    Script Date: 2/9/2022 2:46:32 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Themchitietphieutiem]    Script Date: 2/9/2022 2:46:32 PM ******/
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
