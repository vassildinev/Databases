use TelerikAcademy;

create table Users(
	UserId int not null identity,
	Username nvarchar(50) not null unique,
	Password nvarchar(50),
	FullName nvarchar(50),
	LastLogin nvarchar(50)

	constraint PK_Users primary key(UserId),
	check(len(Password) >= 5)
);
go

set identity_insert Users on

insert into Users(UserId, Username, Password, LastLogin)
values(1, 'pesho.peshov', 'werock', '2015-10-02');

insert into Users(UserId, Username, Password, FullName, LastLogin)
values(2, 'gosho.goshov', 'iamgod', 'Georgi "gosho" Georgiev', '2015-10-04');

insert into Users(UserId, Username, Password, FullName, LastLogin)
values(3, 'stamat.stamatov', 'stamat', 'Stamat Stamatov', '2015-10-03');
go