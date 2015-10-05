use TelerikAcademy;

select * from 
	(select y.Department, t.Name as [Town], count(y.Employee) as [Employees Count] from
		(select x.Employee, x.Department, a.TownID from
			(select e.LastName as [Employee], d.Name as [Department], e.AddressID from Employees e
			inner join Departments d on d.DepartmentID = e.DepartmentID) x
		inner join Addresses a on x.AddressID = a.AddressID) y
	inner join Towns t on t.TownID = y.TownID
	group by y.Department, t.Name) z
order by z.Department, z.Town, z.[Employees Count];