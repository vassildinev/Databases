use TelerikAcademy;

create table #EmployeesProjectsTemp(
	EmployeeId int, 
	ProjectId int,
	constraint FK_Empl foreign key (EmployeeId)
	references Employees(EmployeeId),
	constraint FK_Proj foreign key (ProjectId)
	references Projects(ProjectId)
);

insert into #EmployeesProjectsTemp select * from EmployeesProjects;

drop table EmployeesProjects;

create table EmployeesProjects(
	EmployeeId int, 
	ProjectId int,
	constraint FK_Empl foreign key (EmployeeId)
	references Employees(EmployeeId),
	constraint FK_Proj foreign key (ProjectId)
	references Projects(ProjectId)
);

insert into EmployeesProjects select * from #EmployeesProjectsTemp;

drop table #EmployeesProjectsTemp;
