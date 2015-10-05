use TelerikAcademy;

select * from
	(select i.FirstName + ' ' + i.LastName as [Manager], count(*) as [Employees Count]
	from Employees e
	inner join Employees i on e.ManagerID = i.EmployeeID
	group by i.FirstName + ' ' + i.LastName) x
where x.[Employees Count] = 5;
