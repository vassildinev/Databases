use TelerikAcademy;

alter table Users
add GroupId int;
go

alter table Users
add constraint FK_Users_Groups foreign key(GroupId)
references Groups(GroupId);
go

update Users
set GroupId = 1
where UserId = 1;
go

update Users
set GroupId = 2
where UserID = 2 or UserId = 3;
go