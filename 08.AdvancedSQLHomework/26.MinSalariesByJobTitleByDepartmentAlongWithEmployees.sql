use TelerikAcademy;

select y.FirstName + ' ' + y.LastName as [Employee Name], x.* from
	(select Name as [Department Name], 
			JobTitle,
		    Min(Salary) as [Min Salary] from Employees e, Departments d
	 where Name = (select d.Name 
				  where d.DepartmentID = e.DepartmentID)
	 group by d.Name, JobTitle) x, Employees y
where y.Salary = x.[Min Salary] and 
	  y.DepartmentID = (select DepartmentId 
						from Departments 
						where x.[Department Name] = Name)
order by [Department Name], [Min Salary], [Employee Name];