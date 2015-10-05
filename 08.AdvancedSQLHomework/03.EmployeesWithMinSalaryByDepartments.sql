use TelerikAcademy;

select y.FirstName + ' ' + y.LastName as [Employee Name], x.* from
	(select Name as [Department Name], 
		   Min(Salary) as [Min Salary] from Employees e, Departments d
	 where Name = (select d.Name 
				  where d.DepartmentID = e.DepartmentID)
	 group by d.Name) x, Employees y
where y.Salary = x.[Min Salary] and 
	  y.DepartmentID = (select DepartmentId 
						from Departments 
						where x.[Department Name] = Name)
order by [Min Salary], [Employee Name];