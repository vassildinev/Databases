use TelerikAcademy;
go

update Users
set Password = null
where datediff(dd, '2010-03-10', LastLogin) < 0;
go