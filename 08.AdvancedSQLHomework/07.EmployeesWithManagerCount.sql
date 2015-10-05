use TelerikAcademy;

select count(*) as [Employees With Manager Count] from
	(select * from Employees e
	where e.ManagerID is not null) x;