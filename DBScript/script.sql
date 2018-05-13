USE [master]
GO
/****** Object:  Database [CloudBanking]    Script Date: 5/13/2018 6:00:31 PM ******/
CREATE DATABASE [CloudBanking]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CloudBanking', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CloudBanking.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CloudBanking_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CloudBanking_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CloudBanking] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CloudBanking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CloudBanking] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CloudBanking] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CloudBanking] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CloudBanking] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CloudBanking] SET ARITHABORT OFF 
GO
ALTER DATABASE [CloudBanking] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CloudBanking] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CloudBanking] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CloudBanking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CloudBanking] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CloudBanking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CloudBanking] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CloudBanking] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CloudBanking] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CloudBanking] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CloudBanking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CloudBanking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CloudBanking] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CloudBanking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CloudBanking] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CloudBanking] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CloudBanking] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CloudBanking] SET RECOVERY FULL 
GO
ALTER DATABASE [CloudBanking] SET  MULTI_USER 
GO
ALTER DATABASE [CloudBanking] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CloudBanking] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CloudBanking] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CloudBanking] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CloudBanking] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CloudBanking', N'ON'
GO
ALTER DATABASE [CloudBanking] SET QUERY_STORE = OFF
GO
USE [CloudBanking]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CloudBanking]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/13/2018 6:00:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [int] NOT NULL,
	[AccountCurrency] [varchar](50) NOT NULL,
	[AccountType] [varchar](50) NOT NULL,
	[MinimumBalance] [varchar](50) NOT NULL,
	[AccounBalance] [varchar](50) NOT NULL,
	[BranchID] [int] NOT NULL,
	[OpenDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountCustomer]    Script Date: 5/13/2018 6:00:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountCustomer](
	[AccountID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankTransaction]    Script Date: 5/13/2018 6:00:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankTransaction](
	[TransactionID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[TransactionType] [varchar](50) NOT NULL,
	[Amount] [int] NOT NULL,
	[TransactionDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 5/13/2018 6:00:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchID] [int] NOT NULL,
	[BranchName] [varchar](100) NOT NULL,
	[BranchAddress] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BranchEmployee]    Script Date: 5/13/2018 6:00:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchEmployee](
	[EmployeeID] [int] NOT NULL,
	[BranchID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cheque]    Script Date: 5/13/2018 6:00:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cheque](
	[ChequeID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[AmountInWords] [varchar](255) NOT NULL,
	[PayeeName] [varchar](50) NOT NULL,
	[ChequeDate] [date] NOT NULL,
	[MACAddress] [varchar](50) NOT NULL,
	[IPAddress] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ChequeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrencyRate]    Script Date: 5/13/2018 6:00:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrencyRate](
	[CurrencyDate] [date] NOT NULL,
	[USD] [float] NOT NULL,
	[YEN] [float] NOT NULL,
	[INR] [float] NOT NULL,
	[POUND] [float] NOT NULL,
	[EURO] [float] NOT NULL,
	[RIAL] [float] NOT NULL,
	[DIRHAM] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CurrencyDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/13/2018 6:00:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[CustomerAddress] [varchar](255) NOT NULL,
	[CustomerEmail] [varchar](50) NOT NULL,
	[CustomerPassword] [varchar](50) NOT NULL,
	[CNIC] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Draft]    Script Date: 5/13/2018 6:00:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Draft](
	[DraftID] [int] NOT NULL,
	[CustomerID] [int] NULL,
	[SenderName] [varchar](50) NOT NULL,
	[SenderCNIC] [varchar](50) NOT NULL,
	[ReceiverAccountID] [int] NOT NULL,
	[DraftAmount] [int] NOT NULL,
	[DraftDate] [date] NOT NULL,
	[ExpiryDate] [date] NOT NULL,
	[SenderBranchID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DraftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/13/2018 6:00:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] NOT NULL,
	[EmpName] [varchar](100) NOT NULL,
	[EmpRole] [varchar](20) NOT NULL,
	[EmpAddress] [varchar](255) NOT NULL,
	[ContactNumber] [varchar](50) NOT NULL,
	[CNIC] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FingerPrint]    Script Date: 5/13/2018 6:00:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FingerPrint](
	[FingerPrintID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Arcs] [varchar](255) NOT NULL,
	[Whorls] [varchar](255) NOT NULL,
	[Loops] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FingerPrintID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wallet]    Script Date: 5/13/2018 6:00:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallet](
	[WalletID] [int] NOT NULL,
	[AuthKey] [varchar](255) NOT NULL,
	[WalletType] [varchar](50) NOT NULL,
	[TransactionID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[WalletID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Account]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Branch] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branch] ([BranchID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Branch]
GO
ALTER TABLE [dbo].[AccountCustomer]  WITH CHECK ADD  CONSTRAINT [FK_AccountCustomer_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[AccountCustomer] CHECK CONSTRAINT [FK_AccountCustomer_Account]
GO
ALTER TABLE [dbo].[AccountCustomer]  WITH CHECK ADD  CONSTRAINT [FK_AccountCustomer_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[AccountCustomer] CHECK CONSTRAINT [FK_AccountCustomer_Customer]
GO
ALTER TABLE [dbo].[BankTransaction]  WITH CHECK ADD  CONSTRAINT [FK_BankTransaction_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[BankTransaction] CHECK CONSTRAINT [FK_BankTransaction_Customer]
GO
ALTER TABLE [dbo].[BranchEmployee]  WITH CHECK ADD  CONSTRAINT [FK_BranchEmployee_Branch] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branch] ([BranchID])
GO
ALTER TABLE [dbo].[BranchEmployee] CHECK CONSTRAINT [FK_BranchEmployee_Branch]
GO
ALTER TABLE [dbo].[BranchEmployee]  WITH CHECK ADD  CONSTRAINT [FK_BranchEmployee_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[BranchEmployee] CHECK CONSTRAINT [FK_BranchEmployee_Employee]
GO
ALTER TABLE [dbo].[Cheque]  WITH CHECK ADD  CONSTRAINT [FK_Cheque_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Cheque] CHECK CONSTRAINT [FK_Cheque_Customer]
GO
ALTER TABLE [dbo].[Draft]  WITH CHECK ADD  CONSTRAINT [FK_Draft_Account] FOREIGN KEY([ReceiverAccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Draft] CHECK CONSTRAINT [FK_Draft_Account]
GO
ALTER TABLE [dbo].[Draft]  WITH CHECK ADD  CONSTRAINT [FK_Draft_Branch] FOREIGN KEY([SenderBranchID])
REFERENCES [dbo].[Branch] ([BranchID])
GO
ALTER TABLE [dbo].[Draft] CHECK CONSTRAINT [FK_Draft_Branch]
GO
ALTER TABLE [dbo].[Draft]  WITH CHECK ADD  CONSTRAINT [FK_Draft_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Draft] CHECK CONSTRAINT [FK_Draft_Customer]
GO
ALTER TABLE [dbo].[FingerPrint]  WITH CHECK ADD  CONSTRAINT [FK_FingerPrint_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[FingerPrint] CHECK CONSTRAINT [FK_FingerPrint_Customer]
GO
ALTER TABLE [dbo].[Wallet]  WITH CHECK ADD  CONSTRAINT [FK_Wallet_BankTransaction] FOREIGN KEY([TransactionID])
REFERENCES [dbo].[BankTransaction] ([TransactionID])
GO
ALTER TABLE [dbo].[Wallet] CHECK CONSTRAINT [FK_Wallet_BankTransaction]
GO
USE [master]
GO
ALTER DATABASE [CloudBanking] SET  READ_WRITE 
GO
