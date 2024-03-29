USE [qingsuan1011]
GO
/****** Object:  Table [dbo].[临时缓存区_绩效考核_基金经理净值贡献表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[临时缓存区_绩效考核_基金经理净值贡献表](
	[基金经理] [nvarchar](50) NOT NULL,
	[时间] [nvarchar](50) NOT NULL,
	[基金产品] [nvarchar](50) NOT NULL,
	[本年净值贡献] [float] NULL,
 CONSTRAINT [PK_临时缓存区_绩效考核_基金经理净值贡献表] PRIMARY KEY CLUSTERED 
(
	[基金经理] ASC,
	[时间] ASC,
	[基金产品] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[临时缓存区_绩效考核_基金产品每日统计]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[临时缓存区_绩效考核_基金产品每日统计](
	[记录标识] [bigint] NOT NULL,
	[产品名称] [nvarchar](100) NULL,
	[资产总额] [float] NULL,
	[资金余额] [float] NULL,
	[资金资产比例] [nvarchar](50) NULL,
	[今年收益率] [nvarchar](50) NULL,
	[单位净值] [float] NULL,
	[今年最大净值] [float] NULL,
	[回撤率] [nvarchar](50) NULL,
	[时间] [nvarchar](50) NULL,
	[基金份额] [float] NULL,
	[基准日净值] [float] NULL,
	[申购赎回调整数] [float] NULL,
	[股票资产总额] [float] NULL,
	[期货资产总额] [float] NULL,
	[期货资金余额] [float] NULL,
	[期货今年收益率] [float] NULL,
 CONSTRAINT [PK_临时缓存区_绩效考核_基金产品每日统计] PRIMARY KEY CLUSTERED 
(
	[记录标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[临时缓存区_绩效考核_股票每日交易汇总大表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[临时缓存区_绩效考核_股票每日交易汇总大表](
	[记录标识] [bigint] NOT NULL,
	[产品名称] [nvarchar](100) NULL,
	[基金经理] [nvarchar](50) NULL,
	[股票代码] [varchar](6) NULL,
	[股票名称] [nvarchar](50) NOT NULL,
	[持股数量] [float] NULL,
	[持股成本] [float] NULL,
	[市场现价] [float] NULL,
	[投资成本] [float] NULL,
	[今日市值] [float] NULL,
	[浮盈浮亏] [float] NULL,
	[投资成本占比] [nvarchar](50) NULL,
	[市值占比] [float] NULL,
	[浮盈浮亏率] [nvarchar](50) NULL,
	[当日盈亏] [float] NULL,
	[时间] [nvarchar](50) NULL,
	[买卖累计盈亏] [float] NULL,
	[今日均价] [float] NULL,
 CONSTRAINT [PK_临时缓存区_绩效考核_股票每日交易汇总大表] PRIMARY KEY CLUSTERED 
(
	[记录标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[绩效考核_用户信息表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[绩效考核_用户信息表](
	[用户名] [nvarchar](50) NOT NULL,
	[用户密码] [nvarchar](50) NOT NULL,
	[用户姓名] [nvarchar](50) NULL,
	[角色] [nvarchar](50) NULL,
 CONSTRAINT [PK_绩效考核_用户信息表] PRIMARY KEY CLUSTERED 
(
	[用户名] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[绩效考核_现金替代物信息表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[绩效考核_现金替代物信息表](
	[现金替代物代码] [varchar](6) NOT NULL,
	[现金替代物名称] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_绩效考核_现金替代物信息表] PRIMARY KEY CLUSTERED 
(
	[现金替代物代码] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[绩效考核_未上市股票信息表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[绩效考核_未上市股票信息表](
	[股票代码] [varchar](6) NOT NULL,
	[股票名称] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[绩效考核_申购赎回调整历史表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[绩效考核_申购赎回调整历史表](
	[序号] [bigint] NOT NULL,
	[产品名称] [nvarchar](50) NULL,
	[基金经理] [nvarchar](50) NULL,
	[申购赎回调整数] [float] NULL,
	[赎回时间] [nvarchar](50) NULL,
	[基金份额历史表序号] [bigint] NULL,
 CONSTRAINT [PK_绩效考核_申购赎回调整历史表] PRIMARY KEY CLUSTERED 
(
	[序号] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[绩效考核_期货每日交易汇总大表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[绩效考核_期货每日交易汇总大表](
	[记录标识] [bigint] NOT NULL,
	[产品名称] [nvarchar](100) NULL,
	[基金经理] [nvarchar](50) NULL,
	[期货代码] [nvarchar](50) NULL,
	[期货名称] [nvarchar](50) NULL,
	[卖持量] [float] NULL,
	[卖持仓成本] [float] NULL,
	[市场现价] [float] NULL,
	[合约成本] [float] NULL,
	[持仓保证金] [float] NULL,
	[当日盈亏] [float] NULL,
	[总盈亏] [float] NULL,
	[时间] [nvarchar](50) NULL,
 CONSTRAINT [PK_绩效考核_期货每日交易汇总大表] PRIMARY KEY CLUSTERED 
(
	[记录标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[绩效考核_交易记录表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[绩效考核_交易记录表](
	[记录标识] [bigint] NOT NULL,
	[产品名称] [nvarchar](100) NULL,
	[基金经理] [nvarchar](50) NULL,
	[股票代码] [varchar](6) NULL,
	[股票名称] [nvarchar](50) NULL,
	[交易方向] [nvarchar](50) NULL,
	[股数] [bigint] NULL,
	[成交均价] [float] NULL,
	[成交金额] [float] NULL,
	[手续费] [float] NULL,
	[过户费] [float] NULL,
	[印花税] [float] NULL,
	[时间] [nvarchar](50) NULL,
 CONSTRAINT [PK_绩效考核_交易记录表] PRIMARY KEY CLUSTERED 
(
	[记录标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[绩效考核_基金经理信息表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[绩效考核_基金经理信息表](
	[基金经理] [nvarchar](50) NOT NULL,
	[管理产品] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_绩效考核_基金经理信息表] PRIMARY KEY CLUSTERED 
(
	[基金经理] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[绩效考核_基金经理净值贡献表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[绩效考核_基金经理净值贡献表](
	[基金经理] [nvarchar](50) NOT NULL,
	[时间] [nvarchar](50) NOT NULL,
	[基金产品] [nvarchar](50) NOT NULL,
	[本年净值贡献] [float] NULL,
 CONSTRAINT [PK_绩效考核_基金经理净值贡献表] PRIMARY KEY CLUSTERED 
(
	[基金经理] ASC,
	[时间] ASC,
	[基金产品] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[绩效考核_基金经理_产品份额表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[绩效考核_基金经理_产品份额表](
	[基金经理] [nvarchar](50) NOT NULL,
	[基金产品] [nvarchar](50) NOT NULL,
	[申购赎回调整数] [float] NULL,
 CONSTRAINT [PK_绩效考核_基金经理_产品份额表] PRIMARY KEY CLUSTERED 
(
	[基金经理] ASC,
	[基金产品] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[绩效考核_基金份额历史表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[绩效考核_基金份额历史表](
	[序号] [bigint] NOT NULL,
	[产品名称] [nvarchar](50) NULL,
	[基金份额] [float] NULL,
	[修改时间] [nvarchar](50) NULL,
 CONSTRAINT [PK_绩效考核_基金份额历史表] PRIMARY KEY CLUSTERED 
(
	[序号] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[绩效考核_基金产品信息表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[绩效考核_基金产品信息表](
	[产品名称] [nvarchar](100) NOT NULL,
	[佣金] [float] NULL,
	[印花税] [float] NULL,
	[过户费比例] [float] NULL,
	[赎回份额] [float] NULL,
	[基准日净值] [float] NULL,
	[输出序号] [int] NULL,
 CONSTRAINT [PK_绩效考核_基金产品信息表] PRIMARY KEY CLUSTERED 
(
	[产品名称] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[绩效考核_基金产品每日统计_格式不符]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[绩效考核_基金产品每日统计_格式不符](
	[记录标识] [bigint] NOT NULL,
	[产品名称] [nvarchar](100) NULL,
	[资产总额] [float] NULL,
	[资金余额] [float] NULL,
	[资金资产比例] [nvarchar](50) NULL,
	[今年收益率] [nvarchar](50) NULL,
	[单位净值] [float] NULL,
	[今年最大净值] [float] NULL,
	[回撤率] [nvarchar](50) NULL,
	[时间] [nvarchar](50) NULL,
	[基金份额] [float] NULL,
	[基准日净值] [float] NULL,
	[申购赎回调整数] [float] NULL,
	[股票资产总额] [float] NULL,
	[期货资产总额] [float] NULL,
	[期货资金余额] [float] NULL,
	[期货今年收益率] [float] NULL,
 CONSTRAINT [PK_绩效考核_基金产品每日统计_格式不符] PRIMARY KEY CLUSTERED 
(
	[记录标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[绩效考核_基金产品每日统计]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[绩效考核_基金产品每日统计](
	[记录标识] [bigint] NOT NULL,
	[产品名称] [nvarchar](100) NULL,
	[资产总额] [float] NULL,
	[资金余额] [float] NULL,
	[资金资产比例] [nvarchar](50) NULL,
	[今年收益率] [nvarchar](50) NULL,
	[单位净值] [float] NULL,
	[今年最大净值] [float] NULL,
	[回撤率] [nvarchar](50) NULL,
	[时间] [nvarchar](50) NULL,
	[基金份额] [float] NULL,
	[基准日净值] [float] NULL,
	[申购赎回调整数] [float] NULL,
	[股票资产总额] [float] NULL,
	[期货资产总额] [float] NULL,
	[期货资金余额] [float] NULL,
	[期货今年收益率] [float] NULL,
 CONSTRAINT [PK_绩效考核_基金产品每日统计] PRIMARY KEY CLUSTERED 
(
	[记录标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[绩效考核_汇率]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[绩效考核_汇率](
	[时间] [nvarchar](50) NOT NULL,
	[买入汇率] [float] NULL,
	[卖出汇率] [float] NULL,
 CONSTRAINT [PK_绩效考核_汇率] PRIMARY KEY CLUSTERED 
(
	[时间] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[绩效考核_股票信息表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[绩效考核_股票信息表](
	[股票代码] [varchar](6) NOT NULL,
	[股票名称] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_绩效考核_股票信息表] PRIMARY KEY CLUSTERED 
(
	[股票代码] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[绩效考核_股票每日交易汇总小表_格式不符]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[绩效考核_股票每日交易汇总小表_格式不符](
	[记录标识] [bigint] NOT NULL,
	[股票代码] [varchar](6) NULL,
	[基金经理] [nvarchar](50) NULL,
	[产品名称] [nvarchar](100) NULL,
	[股票名称] [nvarchar](50) NULL,
	[时间] [nvarchar](50) NULL,
	[今日买入股] [bigint] NULL,
	[买入均价] [float] NULL,
	[买入金额] [float] NULL,
	[今日卖出股] [bigint] NULL,
	[卖出均价] [float] NULL,
	[卖出金额] [float] NULL,
	[买入手续费] [float] NULL,
	[买入过户费] [float] NULL,
	[买入印花税] [float] NULL,
	[卖出手续费] [float] NULL,
	[卖出过户费] [float] NULL,
	[卖出印花税] [float] NULL,
	[买入清算金额] [float] NULL,
	[卖出清算金额] [float] NULL,
	[是否为止损指令] [bit] NULL,
 CONSTRAINT [PK_绩效考核_股票每日交易汇总小表_格式不符] PRIMARY KEY CLUSTERED 
(
	[记录标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[绩效考核_股票每日交易汇总小表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[绩效考核_股票每日交易汇总小表](
	[记录标识] [bigint] NOT NULL,
	[股票代码] [varchar](6) NULL,
	[基金经理] [nvarchar](50) NULL,
	[产品名称] [nvarchar](100) NULL,
	[股票名称] [nvarchar](50) NULL,
	[时间] [nvarchar](50) NULL,
	[今日买入股] [bigint] NULL,
	[买入均价] [float] NULL,
	[买入金额] [float] NULL,
	[今日卖出股] [bigint] NULL,
	[卖出均价] [float] NULL,
	[卖出金额] [float] NULL,
	[买入手续费] [float] NULL,
	[买入过户费] [float] NULL,
	[买入印花税] [float] NULL,
	[卖出手续费] [float] NULL,
	[卖出过户费] [float] NULL,
	[卖出印花税] [float] NULL,
	[买入清算金额] [float] NULL,
	[卖出清算金额] [float] NULL,
	[是否为止损指令] [bit] NULL,
 CONSTRAINT [PK_绩效考核_股票每日交易汇总小表] PRIMARY KEY CLUSTERED 
(
	[记录标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[绩效考核_股票每日交易汇总大表_格式不符]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[绩效考核_股票每日交易汇总大表_格式不符](
	[记录标识] [bigint] NOT NULL,
	[产品名称] [nvarchar](100) NULL,
	[基金经理] [nvarchar](50) NULL,
	[股票代码] [varchar](6) NULL,
	[股票名称] [nvarchar](50) NOT NULL,
	[持股数量] [float] NULL,
	[持股成本] [float] NULL,
	[市场现价] [float] NULL,
	[投资成本] [float] NULL,
	[今日市值] [float] NULL,
	[浮盈浮亏] [float] NULL,
	[投资成本占比] [nvarchar](50) NULL,
	[市值占比] [float] NULL,
	[浮盈浮亏率] [nvarchar](50) NULL,
	[当日盈亏] [float] NULL,
	[时间] [nvarchar](50) NULL,
	[买卖累计盈亏] [float] NULL,
	[今日均价] [float] NULL,
 CONSTRAINT [PK_绩效考核_股票每日交易汇总大表_格式不符] PRIMARY KEY CLUSTERED 
(
	[记录标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[绩效考核_股票每日交易汇总大表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[绩效考核_股票每日交易汇总大表](
	[记录标识] [bigint] NOT NULL,
	[产品名称] [nvarchar](100) NULL,
	[基金经理] [nvarchar](50) NULL,
	[股票代码] [varchar](6) NULL,
	[股票名称] [nvarchar](50) NOT NULL,
	[持股数量] [float] NULL,
	[持股成本] [float] NULL,
	[市场现价] [float] NULL,
	[投资成本] [float] NULL,
	[今日市值] [float] NULL,
	[浮盈浮亏] [float] NULL,
	[投资成本占比] [nvarchar](50) NULL,
	[市值占比] [float] NULL,
	[浮盈浮亏率] [nvarchar](50) NULL,
	[本年净值贡献] [float] NULL,
	[当日盈亏] [float] NULL,
	[时间] [nvarchar](50) NULL,
	[买卖累计盈亏] [float] NULL,
	[今日均价] [float] NULL,
	[是否修改过持股数量和持股成本] [bit] NULL,
 CONSTRAINT [PK_绩效考核_股票每日交易汇总大表] PRIMARY KEY CLUSTERED 
(
	[记录标识] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[绩效考核_股票每日价格记录表]    Script Date: 03/02/2023 12:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[绩效考核_股票每日价格记录表](
	[股票代码] [nvarchar](6) NOT NULL,
	[股票名称] [nvarchar](50) NULL,
	[时间] [nvarchar](50) NOT NULL,
	[收盘价] [float] NULL,
 CONSTRAINT [PK_绩效考核_股票每日价格记录表] PRIMARY KEY CLUSTERED 
(
	[股票代码] ASC,
	[时间] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
