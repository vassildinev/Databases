use TelerikAcademy;

select * from
	(select t.Name as [Town], count([Manager]) as [Managers] from
		(select distinct [Manager], a.TownID from
			(select e.FirstName + ' ' + e.LastName as [Manager], e.AddressID from Employees e
			inner join Employees i on i.ManagerID = e.EmployeeID) x
		inner join Addresses a on a.AddressID = x.AddressID) y
	inner join Towns t on t.TownID = y.TownID
	group by t.Name) z
order by -z.Managers;