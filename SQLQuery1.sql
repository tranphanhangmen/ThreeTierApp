/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[Name]
      ,[Address]
      ,[EmailID]
      ,[Mobilenumber]
      ,[country]
      ,[sex]
      ,[dbo]
  FROM [UserDB].[dbo].[Userinfo]


  --create table Country (CountryId INT, CountryName Varchar(1000));

  --insert into Country (CountryId, CountryName)
  --values (1, 'USA'), (2, 'VietNam'), (3, 'Another')

  select * from Country;

  --alter table [Userinfo] drop column CountyId;
  alter table [Userinfo] add CountryId INT;

  --before
  select u.* , c.CountryId
  from [dbo].[Userinfo] u
  inner join Country c on c.CountryName = u.country

  --update
  update u
  set u.CountryId = c.CountryId
  from [dbo].[Userinfo] u
  inner join Country c on c.CountryName = u.country

  ---after
  select u.* , c.CountryId
  from [dbo].[Userinfo] u
  inner join Country c on c.CountryName = u.country


  alter table [Userinfo] drop column Country;


  ---final
  select u.* , c.CountryName
  from [dbo].[Userinfo] u
  inner join Country c on c.CountryId = u.CountryId

  --------------------------
	declare @CountryId int
	, @country varchar(100)='VietNam';

	select @CountryId
	select @CountryId = CountryId from Country where CountryName = @country;
	select @CountryId