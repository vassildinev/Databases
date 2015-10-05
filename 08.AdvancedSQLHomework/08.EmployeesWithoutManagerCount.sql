use TelerikAcademy;

select count(*) as [Employees Without Manager Count] from
	(select * from Employees e
	 where e.ManagerID is null) x;