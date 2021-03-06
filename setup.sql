USE [StudentManagement]
GO
/****** Object:  Table [dbo].[tb_student]    Script Date: 09/22/2018 00:57:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_student](
	[studentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tb_student] ON
INSERT [dbo].[tb_student] ([studentID], [Name], [Address], [Type]) VALUES (1, N'aung sdaf', N'Address', N'Home Student')
INSERT [dbo].[tb_student] ([studentID], [Name], [Address], [Type]) VALUES (2, N'change', N'change', N'Over Sea')
INSERT [dbo].[tb_student] ([studentID], [Name], [Address], [Type]) VALUES (3, N'aung', N'bla bla', N'Ov')
INSERT [dbo].[tb_student] ([studentID], [Name], [Address], [Type]) VALUES (4, N'kyaw', N'kyaw', N'kyaw')
INSERT [dbo].[tb_student] ([studentID], [Name], [Address], [Type]) VALUES (5, N'aung', N'DawBon', N'HomeStudent')
INSERT [dbo].[tb_student] ([studentID], [Name], [Address], [Type]) VALUES (6, N'aung', N'North Dagon', N'HomeStudent')
INSERT [dbo].[tb_student] ([studentID], [Name], [Address], [Type]) VALUES (7, N'aung', N'aung', N'aung')
INSERT [dbo].[tb_student] ([studentID], [Name], [Address], [Type]) VALUES (8, N'kyaw', N'north dagon', N'the same data')
INSERT [dbo].[tb_student] ([studentID], [Name], [Address], [Type]) VALUES (9, N'aung', N'SA', N'aung')
SET IDENTITY_INSERT [dbo].[tb_student] OFF
/****** Object:  StoredProcedure [dbo].[SP_Select_student]    Script Date: 09/22/2018 00:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Select_student]
@para1 nvarchar(50) = '',
@para2 nvarchar(50) = '',
@action int = 0
        
        
as  begin 
if @action = 1
    select * from tb_student
if @action = 2
	select * from tb_student where studentID = '@para1'

end
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Process]    Script Date: 09/22/2018 00:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Insert_Process]
@StudentID    int    = 0,
@Name    nvarchar(50)    = 0,
@Type    nvarchar(50)    = 0,
@Address nvarchar(50)    = 0,
@action  int = 0
        
        
as  begin 
if @action = 1
    insert into tb_student(Name,Address,Type) 
    values (@Name,@Address,@Type)
if @action = 2
	update tb_student set Name = @Name, Address = @Address, @Type = @Type 
	where studentID = @StudentID
if @action = 3
	Delete from tb_student where studentID = @studentID
end
GO
