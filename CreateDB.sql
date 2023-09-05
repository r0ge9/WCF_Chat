create database ChatDB
use ChatDB
go
create table Users(
	Id int primary key identity(1,1),
	Name nvarchar(30) not null,
	Username nvarchar(30) not null,
	Image varbinary(max),
	Email varchar(40) not null,
	Description nvarchar(1000),
	isOnline bit not null default 0,
	LastTimeOnline smalldatetime);

create table Dialog(
	Id int primary key identity(1,1),
	FirstUserId int,
	SecondUserId int,
	foreign key (FirstUserId) references Users(Id) on delete no action,
	foreign key (SecondUserId) references Users(Id) on delete no action,
	);

create table Message(
	Id int primary key identity(1,1),
	Text nvarchar(max) not null,
	DialogId int,
	UserId int,
	toUserId int,
	IP varchar(50) not null,
	isRead bit not null default 0,
	isVisibleFirstUser bit not null default 1,
	isVisibleSecondUser bit not null default 1,
	SendDateTime smalldatetime not null,
	foreign key (DialogId) references Dialog(Id) on delete cascade,
	foreign key (UserId) references Users(Id) on delete no action,
	foreign key (toUserId) references Users(Id) on delete no action,
	);