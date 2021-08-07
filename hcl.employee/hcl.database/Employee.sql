USE [EmployeeManagementSystem]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 8/6/2021 5:33:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Email] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](100) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE dbo.Employee
   ADD CONSTRAINT FK_Employee_Project FOREIGN KEY (ProjectId)
      REFERENCES dbo.Project (Id)
;
GO

ALTER TABLE dbo.Employee
   ADD CONSTRAINT FK_Employee_Designation FOREIGN KEY (DesignationId)
      REFERENCES dbo.Designation (Id)
;
GO
