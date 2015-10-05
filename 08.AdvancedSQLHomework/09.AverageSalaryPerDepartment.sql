use TelerikAcademy;

select Name as [Department Name], 
		avg(Salary) as [Avg Salary] from Employees e, Departments d
where Name = (select d.Name 
			  where d.DepartmentID = e.DepartmentID)
group by d.Name;