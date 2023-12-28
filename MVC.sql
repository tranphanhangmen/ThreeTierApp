create table Account(
AccountID int identity(1,1) not null,
NickName varchar(30) not null unique,
Email varchar(100) not null unique,
Password varchar(50) not null,
Mobile varchar(15),
DOB date,
Sex tinyint,
Status varchar(10) not null
)