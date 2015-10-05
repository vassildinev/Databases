use TelerikAcademy;

select top 1 * from
	(select [Town], count(*) as [Employees] from
		(select x.LastName, t.Name as [Town] from
			(select e.LastName, a.TownID from Employees e
			inner join Addresses a on a.AddressId = e.AddressID) x
		inner join Towns t on t.TownID = x.TownID) y
	group by [Town]) z
order by -[Employees];