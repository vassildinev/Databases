use TelerikAcademy;
go

create view [UsersToday] as
select Username, coalesce(FullName, 'N/A') as [Full Name], LastLogin from
	(select Username, LastLogin, FullName, datediff(dd, 
					cast(datepart(YYYY, getdate()) as varchar) + '-' + 
					cast(datepart(MM, getdate()) as varchar) + '-' +
					cast(datepart(DD, getdate()) as varchar), LastLogin) as [Login Difference]
from Users) x
where x.[Login Difference] = 0;