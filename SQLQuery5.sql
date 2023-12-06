USE [UserDB]
GO
CREATE table Userinfo  

(id bigint primary key not null identity(1,1),  
Name Nvarchar(50),  
Address Nvarchar(100),  
EmailID Nvarchar(50),  
Mobilenumber varchar(10)  
) 