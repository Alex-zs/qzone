USE [master]
GO
/****** Object:  Database [Q-Zone]    Script Date: 2017/12/10 22:41:37 ******/
CREATE DATABASE [Q-Zone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Library.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Library_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Q-Zone] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Q-Zone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Q-Zone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Q-Zone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Q-Zone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Q-Zone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Q-Zone] SET ARITHABORT OFF 
GO
ALTER DATABASE [Q-Zone] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Q-Zone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Q-Zone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Q-Zone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Q-Zone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Q-Zone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Q-Zone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Q-Zone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Q-Zone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Q-Zone] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Q-Zone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Q-Zone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Q-Zone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Q-Zone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Q-Zone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Q-Zone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Q-Zone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Q-Zone] SET RECOVERY FULL 
GO
ALTER DATABASE [Q-Zone] SET  MULTI_USER 
GO
ALTER DATABASE [Q-Zone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Q-Zone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Q-Zone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Q-Zone] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Q-Zone] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Q-Zone', N'ON'
GO
ALTER DATABASE [Q-Zone] SET QUERY_STORE = OFF
GO
USE [Q-Zone]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
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
USE [Q-Zone]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 2017/12/10 22:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NOT NULL,
	[albumid] [int] NULL,
	[time] [nchar](20) NULL,
	[image] [nchar](28) NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Album_Cover]    Script Date: 2017/12/10 22:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album_Cover](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NOT NULL,
	[albumName] [nchar](16) NULL,
	[picture] [nchar](28) NULL,
	[introduce] [nchar](50) NULL,
 CONSTRAINT [PK_Album_Cover] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[blog]    Script Date: 2017/12/10 22:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blog](
	[JournalID] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NOT NULL,
	[time] [nchar](10) NOT NULL,
	[text] [nvarchar](4000) NOT NULL,
	[title] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[JournalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogReplies]    Script Date: 2017/12/10 22:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogReplies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[blogid] [int] NOT NULL,
	[friendid] [int] NOT NULL,
	[time] [nchar](18) NULL,
	[text] [nchar](100) NULL,
 CONSTRAINT [PK_BlogReplies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FriendPass]    Script Date: 2017/12/10 22:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FriendPass](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NOT NULL,
	[friendID] [int] NOT NULL,
 CONSTRAINT [PK_FriendPass] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LiuYan]    Script Date: 2017/12/10 22:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LiuYan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NOT NULL,
	[friendID] [int] NOT NULL,
	[text] [nchar](200) NULL,
	[time] [nchar](20) NULL,
 CONSTRAINT [PK_LiuYan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 2017/12/10 22:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NULL,
	[talk_type] [nchar](3) NULL,
	[qzone_type] [nchar](3) NULL,
 CONSTRAINT [PK_Permisssion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhotoComment]    Script Date: 2017/12/10 22:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhotoComment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[photoid] [int] NULL,
	[userid] [int] NULL,
	[time] [nchar](18) NULL,
	[text] [nchar](200) NULL,
 CONSTRAINT [PK_PhotoComment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Talk]    Script Date: 2017/12/10 22:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Talk](
	[talkID] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[text] [nvarchar](4000) NOT NULL,
	[time] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Talk] PRIMARY KEY CLUSTERED 
(
	[talkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TalkReplies]    Script Date: 2017/12/10 22:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TalkReplies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NOT NULL,
	[friendid] [int] NOT NULL,
	[talkid] [int] NOT NULL,
	[time] [nchar](20) NULL,
	[text] [nchar](50) NULL,
 CONSTRAINT [PK_TalkReplies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserFriend]    Script Date: 2017/12/10 22:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFriend](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NOT NULL,
	[friendID] [int] NOT NULL,
 CONSTRAINT [PK_UserFriend] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInformation]    Script Date: 2017/12/10 22:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInformation](
	[userInfoID] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NOT NULL,
	[sex] [nchar](15) NULL,
	[age] [nchar](15) NULL,
	[birthday] [nchar](15) NULL,
	[blood] [nchar](15) NULL,
	[marry] [nchar](20) NULL,
	[adress] [varchar](50) NULL,
	[job] [nchar](20) NULL,
	[hobby] [varchar](200) NULL,
	[constellation] [nchar](15) NULL,
	[hometown] [nchar](20) NULL,
 CONSTRAINT [PK_UserInformation] PRIMARY KEY CLUSTERED 
(
	[userInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2017/12/10 22:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](20) NOT NULL,
	[userMail] [varchar](30) NOT NULL,
	[userPwd] [varchar](100) NOT NULL,
	[picture] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Album] ON 

INSERT [dbo].[Album] ([id], [userid], [albumid], [time], [image]) VALUES (1, 13, 1, N'2017/12/6 20:16:31  ', N'/images/c823c974a7dc44f3.jpg')
INSERT [dbo].[Album] ([id], [userid], [albumid], [time], [image]) VALUES (2, 13, 1, N'2017/12/6 20:18:50  ', N'/images/70647d6549525852.jpg')
INSERT [dbo].[Album] ([id], [userid], [albumid], [time], [image]) VALUES (3, 13, 1, N'2017/12/6 20:19:08  ', N'/images/7c64df82acec0e9c.png')
INSERT [dbo].[Album] ([id], [userid], [albumid], [time], [image]) VALUES (4, 7, 4, N'2017/12/9 15:14:48  ', N'/images/992818b6f9ddb969.jpg')
INSERT [dbo].[Album] ([id], [userid], [albumid], [time], [image]) VALUES (5, 7, 4, N'2017/12/9 16:39:14  ', N'/images/17dcfd30ec2c662a.jpg')
SET IDENTITY_INSERT [dbo].[Album] OFF
SET IDENTITY_INSERT [dbo].[Album_Cover] ON 

INSERT [dbo].[Album_Cover] ([id], [userID], [albumName], [picture], [introduce]) VALUES (1, 13, N'呵呵              ', N'/images/7f7abb0d31cb26b6.jpg', N'呵呵                                                ')
INSERT [dbo].[Album_Cover] ([id], [userID], [albumName], [picture], [introduce]) VALUES (2, 13, N'啦啦啦             ', N'/images/f22bc5b21d2cbc1b.jpg', N'贱贱贱                                               ')
INSERT [dbo].[Album_Cover] ([id], [userID], [albumName], [picture], [introduce]) VALUES (3, 13, N'我的相册            ', N'/images/122f659578ed2169.png', N'没啥想说的                                             ')
INSERT [dbo].[Album_Cover] ([id], [userID], [albumName], [picture], [introduce]) VALUES (4, 7, N'啦啦啦             ', N'/images/59cdc2419c15fe18.jpg', N'哈哈哈                                               ')
INSERT [dbo].[Album_Cover] ([id], [userID], [albumName], [picture], [introduce]) VALUES (5, 7, N'啦啦啦             ', N'/images/6b6d99dc1f4412d3.jpg', N'<script>alert(''ss'')</script>                      ')
SET IDENTITY_INSERT [dbo].[Album_Cover] OFF
SET IDENTITY_INSERT [dbo].[blog] ON 

INSERT [dbo].[blog] ([JournalID], [userid], [time], [text], [title]) VALUES (2, 7, N'2017年12月3日', N'ja;dfafjklasjfsa', N'wooww                                             ')
INSERT [dbo].[blog] ([JournalID], [userid], [time], [text], [title]) VALUES (3, 7, N'2017年12月3日', N'ssssss', N'123                                               ')
INSERT [dbo].[blog] ([JournalID], [userid], [time], [text], [title]) VALUES (5, 7, N'2017年12月9日', N'啦啦啦啦啦', N'呵呵                                                ')
INSERT [dbo].[blog] ([JournalID], [userid], [time], [text], [title]) VALUES (10, 13, N'2017年12月9日', N'aaaaaaaaaaaaaaaaaaa', N'啊啊啊                                               ')
SET IDENTITY_INSERT [dbo].[blog] OFF
SET IDENTITY_INSERT [dbo].[BlogReplies] ON 

INSERT [dbo].[BlogReplies] ([id], [blogid], [friendid], [time], [text]) VALUES (4, 2, 7, N'2017/12/9 0:14:36 ', N'&lt;script&gt;alert(&#39;hello&#39;)&lt;/script&gt;                                                 ')
INSERT [dbo].[BlogReplies] ([id], [blogid], [friendid], [time], [text]) VALUES (5, 3, 7, N'2017/12/9 0:15:17 ', N'&lt;script&gt;alert(&#39;hello&#39;)&lt;/script&gt;                                                 ')
INSERT [dbo].[BlogReplies] ([id], [blogid], [friendid], [time], [text]) VALUES (6, 3, 7, N'2017/12/9 0:22:22 ', N'呵呵                                                                                                  ')
INSERT [dbo].[BlogReplies] ([id], [blogid], [friendid], [time], [text]) VALUES (11, 10, 13, N'2017/12/9 21:44:31', N'aaaaa                                                                                               ')
INSERT [dbo].[BlogReplies] ([id], [blogid], [friendid], [time], [text]) VALUES (12, 5, 13, N'2017/12/9 22:24:19', N'哒哒哒                                                                                                 ')
SET IDENTITY_INSERT [dbo].[BlogReplies] OFF
SET IDENTITY_INSERT [dbo].[LiuYan] ON 

INSERT [dbo].[LiuYan] ([id], [userID], [friendID], [text], [time]) VALUES (7, 13, 7, N'哈哈哈                                                                                                                                                                                                     ', N'2017/12/9 22:09:45  ')
INSERT [dbo].[LiuYan] ([id], [userID], [friendID], [text], [time]) VALUES (8, 13, 7, N'<script>alert(''呵呵'')</script>                                                                                                                                                                            ', N'2017/12/9 22:09:52  ')
SET IDENTITY_INSERT [dbo].[LiuYan] OFF
SET IDENTITY_INSERT [dbo].[Permission] ON 

INSERT [dbo].[Permission] ([id], [userid], [talk_type], [qzone_type]) VALUES (1, 7, N'所有人', N'所有人')
INSERT [dbo].[Permission] ([id], [userid], [talk_type], [qzone_type]) VALUES (3, 13, N'所有人', N'所有人')
SET IDENTITY_INSERT [dbo].[Permission] OFF
SET IDENTITY_INSERT [dbo].[PhotoComment] ON 

INSERT [dbo].[PhotoComment] ([id], [photoid], [userid], [time], [text]) VALUES (1, 1, 7, N'2017/12/6 20:16:31', N'浏览                                                                                                                                                                                                      ')
INSERT [dbo].[PhotoComment] ([id], [photoid], [userid], [time], [text]) VALUES (2, 4, 7, N'2017/12/9 17:15:42', N'不错                                                                                                                                                                                                      ')
INSERT [dbo].[PhotoComment] ([id], [photoid], [userid], [time], [text]) VALUES (12, 5, 7, N'2017/12/9 17:18:21', N'啊啊                                                                                                                                                                                                      ')
INSERT [dbo].[PhotoComment] ([id], [photoid], [userid], [time], [text]) VALUES (13, 5, 7, N'2017/12/9 17:19:05', N'啦啦啦                                                                                                                                                                                                     ')
INSERT [dbo].[PhotoComment] ([id], [photoid], [userid], [time], [text]) VALUES (14, 5, 7, N'2017/12/9 17:20:37', N'呵呵                                                                                                                                                                                                      ')
INSERT [dbo].[PhotoComment] ([id], [photoid], [userid], [time], [text]) VALUES (15, 4, 7, N'2017/12/9 17:21:38', N'嗯                                                                                                                                                                                                       ')
INSERT [dbo].[PhotoComment] ([id], [photoid], [userid], [time], [text]) VALUES (16, 4, 7, N'2017/12/9 20:22:57', N'不错                                                                                                                                                                                                      ')
SET IDENTITY_INSERT [dbo].[PhotoComment] OFF
SET IDENTITY_INSERT [dbo].[Talk] ON 

INSERT [dbo].[Talk] ([talkID], [userId], [text], [time]) VALUES (62, 7, N'<a>hh</a>', N'2017/12/7 16:49:28')
INSERT [dbo].[Talk] ([talkID], [userId], [text], [time]) VALUES (64, 13, N'呵呵', N'2017/12/8 19:04:33')
INSERT [dbo].[Talk] ([talkID], [userId], [text], [time]) VALUES (65, 7, N'啦啦啦', N'2017/12/9 16:10:43')
INSERT [dbo].[Talk] ([talkID], [userId], [text], [time]) VALUES (66, 7, N'<script>alert(''呵呵'')</script>', N'2017/12/9 20:14:55')
INSERT [dbo].[Talk] ([talkID], [userId], [text], [time]) VALUES (67, 7, N'<a>lll</a>
', N'2017/12/9 20:15:12')
SET IDENTITY_INSERT [dbo].[Talk] OFF
SET IDENTITY_INSERT [dbo].[TalkReplies] ON 

INSERT [dbo].[TalkReplies] ([id], [userid], [friendid], [talkid], [time], [text]) VALUES (67, 13, 13, 64, N'2017/12/8 19:04:40  ', N'呵呵                                                ')
INSERT [dbo].[TalkReplies] ([id], [userid], [friendid], [talkid], [time], [text]) VALUES (68, 13, 7, 64, N'2017/12/8 19:09:17  ', N'啦啦啦                                               ')
INSERT [dbo].[TalkReplies] ([id], [userid], [friendid], [talkid], [time], [text]) VALUES (69, 7, 13, 62, N'2017/12/9 0:29:04   ', N'呵呵                                                ')
INSERT [dbo].[TalkReplies] ([id], [userid], [friendid], [talkid], [time], [text]) VALUES (70, 7, 13, 67, N'2017/12/9 21:40:45  ', N'<script>alert(''呵呵'')</script>                      ')
INSERT [dbo].[TalkReplies] ([id], [userid], [friendid], [talkid], [time], [text]) VALUES (71, 13, 7, 64, N'2017/12/9 21:43:26  ', N'<script>alert(''呵呵'')</script>                      ')
SET IDENTITY_INSERT [dbo].[TalkReplies] OFF
SET IDENTITY_INSERT [dbo].[UserFriend] ON 

INSERT [dbo].[UserFriend] ([id], [userID], [friendID]) VALUES (59, 13, 13)
INSERT [dbo].[UserFriend] ([id], [userID], [friendID]) VALUES (60, 7, 7)
INSERT [dbo].[UserFriend] ([id], [userID], [friendID]) VALUES (61, 7, 13)
INSERT [dbo].[UserFriend] ([id], [userID], [friendID]) VALUES (63, 13, 7)
SET IDENTITY_INSERT [dbo].[UserFriend] OFF
SET IDENTITY_INSERT [dbo].[UserInformation] ON 

INSERT [dbo].[UserInformation] ([userInfoID], [userID], [sex], [age], [birthday], [blood], [marry], [adress], [job], [hobby], [constellation], [hometown]) VALUES (3, 13, N'男              ', N'19             ', N'1998年12月24号    ', N'其他             ', N'保密                  ', N'aaa', N'llll                ', N'kkkk', N'摩羯座            ', N'bbb                 ')
INSERT [dbo].[UserInformation] ([userInfoID], [userID], [sex], [age], [birthday], [blood], [marry], [adress], [job], [hobby], [constellation], [hometown]) VALUES (4, 7, N'男              ', N'0              ', N'2017年12月9号     ', N'A              ', N'0                   ', N'', N'                    ', N'', N'射手座            ', N'                    ')
SET IDENTITY_INSERT [dbo].[UserInformation] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [userName], [userMail], [userPwd], [picture]) VALUES (7, N'WOWOW', N'330953853@qq.com', N'e10adc3949ba59abbe56e057f20f883e', N'/images/03f16fe9dbb4acc4.jpg')
INSERT [dbo].[Users] ([id], [userName], [userMail], [userPwd], [picture]) VALUES (13, N'Alex', N'alex-zs@foxmail.com', N'e10adc3949ba59abbe56e057f20f883e', N'/images/2583119ed37fe396.jpg')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Users] FOREIGN KEY([userid])
REFERENCES [dbo].[Users] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Users]
GO
ALTER TABLE [dbo].[Album_Cover]  WITH CHECK ADD  CONSTRAINT [FK_Album_Cover_Users] FOREIGN KEY([userID])
REFERENCES [dbo].[Users] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Album_Cover] CHECK CONSTRAINT [FK_Album_Cover_Users]
GO
ALTER TABLE [dbo].[BlogReplies]  WITH CHECK ADD  CONSTRAINT [FK_BlogReplies_blog] FOREIGN KEY([blogid])
REFERENCES [dbo].[blog] ([JournalID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlogReplies] CHECK CONSTRAINT [FK_BlogReplies_blog]
GO
ALTER TABLE [dbo].[BlogReplies]  WITH CHECK ADD  CONSTRAINT [FK_BlogReplies_Users] FOREIGN KEY([friendid])
REFERENCES [dbo].[Users] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlogReplies] CHECK CONSTRAINT [FK_BlogReplies_Users]
GO
ALTER TABLE [dbo].[FriendPass]  WITH CHECK ADD  CONSTRAINT [FK_FriendPass_Users] FOREIGN KEY([userID])
REFERENCES [dbo].[Users] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FriendPass] CHECK CONSTRAINT [FK_FriendPass_Users]
GO
ALTER TABLE [dbo].[LiuYan]  WITH CHECK ADD  CONSTRAINT [FK_LiuYan_Users] FOREIGN KEY([userID])
REFERENCES [dbo].[Users] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LiuYan] CHECK CONSTRAINT [FK_LiuYan_Users]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Users] FOREIGN KEY([userid])
REFERENCES [dbo].[Users] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Users]
GO
ALTER TABLE [dbo].[PhotoComment]  WITH CHECK ADD  CONSTRAINT [FK_PhotoComment_Album] FOREIGN KEY([photoid])
REFERENCES [dbo].[Album] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhotoComment] CHECK CONSTRAINT [FK_PhotoComment_Album]
GO
ALTER TABLE [dbo].[Talk]  WITH CHECK ADD  CONSTRAINT [FK_Talk_Users] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Talk] CHECK CONSTRAINT [FK_Talk_Users]
GO
ALTER TABLE [dbo].[TalkReplies]  WITH CHECK ADD  CONSTRAINT [FK_TalkReplies_Talk] FOREIGN KEY([talkid])
REFERENCES [dbo].[Talk] ([talkID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TalkReplies] CHECK CONSTRAINT [FK_TalkReplies_Talk]
GO
ALTER TABLE [dbo].[UserFriend]  WITH CHECK ADD  CONSTRAINT [FK_UserFriend_Users] FOREIGN KEY([userID])
REFERENCES [dbo].[Users] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserFriend] CHECK CONSTRAINT [FK_UserFriend_Users]
GO
ALTER TABLE [dbo].[UserInformation]  WITH CHECK ADD  CONSTRAINT [FK_UserInformation_Users] FOREIGN KEY([userID])
REFERENCES [dbo].[Users] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserInformation] CHECK CONSTRAINT [FK_UserInformation_Users]
GO
USE [master]
GO
ALTER DATABASE [Q-Zone] SET  READ_WRITE 
GO
