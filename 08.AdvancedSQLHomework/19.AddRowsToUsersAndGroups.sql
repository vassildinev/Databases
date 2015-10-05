use TelerikAcademy;
go

set identity_insert Groups on
insert into Groups(GroupId, Name)
values (4, 'HQC'), (5, 'CSS');
set identity_insert Groups off
go

set identity_insert Users on
insert into Users(UserId, Username, Password, FullName, LastLogin, GroupId)
values (4, 'fobod', 'callmesexy', 'Fotka Bodilkova', '2015-10-04', 3),
	   (5, 'petska', 'azsym', 'Petsa Gitsova', '2015-09-30', 4);
set identity_insert Users off
go