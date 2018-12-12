USE [PatientDemo]
GO

/****** Object:  Table [dbo].[PatientInfo]    Script Date: 11-12-2018 23:18:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PatientInfo](
	[ID] [int] Primary KEY not null IDENTITY (0,1),
	[Data] [xml] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


