USE [UserDB]
GO

/****** Object:  StoredProcedure [dbo].[sprocUserinfoInsertUpdateSingleItem]    Script Date: 12/7/2023 10:10:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE  proc [dbo].[sprocUserinfoInsertUpdateSingleItem] (
	@Name Nvarchar(50),  
	@Address Nvarchar(100),  
	@EmailID Nvarchar(50),  
	@Mobilenumber varchar(10),
	@country nvarchar(40),  
	@sex bit,  
	@dbo date  
)
as 
begin
	insert into Userinfo(Name, Address, EmailID, Mobilenumber, country, sex, dbo)
	VALUES(@Name, @Address, @EmailID, @Mobilenumber, @country,@sex,@dbo)
end

GO

