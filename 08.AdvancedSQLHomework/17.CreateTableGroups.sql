use TelerikAcademy;
go

create table Groups(
	GroupId int not null identity,
	Name varchar(50) not null unique,
	constraint PK_Groups primary key(GroupId)
);
go

set identity_insert Groups on
insert into Groups(GroupId, Name)
values (1, 'C#'), (2, 'JavaScript'), (3, 'Databases');
set identity_insert Groups off
go