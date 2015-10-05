use TelerikAcademy;
go

create table WorkHours(
	WorkHoursId int not null identity,
	EmployeeId int,
	Date date,
	Task varchar(50),
	Comments varchar(50)

	constraint PK_WorkHours primary key(WorkHoursId)
	constraint FK_WorkHours foreign key(EmployeeId)
		references Employees(EmployeeId)
)
go

set identity_insert WorkHours on
insert into WorkHours(WorkHoursId, EmployeeId, Date, Task, Comments)
values (1, 1, '2015-10-04', 'watch TV', 'very important'),
	   (2, 2, '2015-10-03', 'Exam DB', 'piece of cake')
set identity_insert WorkHours off
go

update WorkHours
set Task = 'Exam HQC'
where WorkHoursId = 2;
go

delete from WorkHours
where WorkHoursId = 1;
go

create table WorkHoursLogs(
	LogId int not null identity(1, 1),
	CommandText nvarchar(4000),
	OldWorkHoursId int not null,
	OldEmployeeId int,
	OldDate date,
	OldTask varchar(200),
	OldComments varchar(200),
	NewWorkHoursId int not null,
	NewEmployeeId int,
	NewDate date,
	NewTask varchar(200),
	NewComments varchar(200)
)
go

create trigger WorkHoursTrigger
on WorkHours 
after update
as
	declare @command nvarchar(3000)
	declare @TEMP table 
   (EventType nvarchar(30), Parameters int, EventInfo nvarchar(2000)) 
   insert into @TEMP exec('DBCC INPUTBUFFER(@@SPID)') 
   select @command = EventInfo from @TEMP

	set identity_insert WorkHoursLogs on
	insert into WorkHoursLogs(LogId, CommandText, OldWorkHoursId, OldEmployeeId, OldDate, OldTask, OldComments,
						NewWorkHoursId, NewEmployeeId, NewDate, NewTask, NewComments)
	select 
		(select ident_current('WorkHoursLogs')),
		@command,
		d.WorkHoursId, d.EmployeeId, d.Date, d.Task, d.Comments, 
		i.WorkHoursId, i.EmployeeId, i.Date, i.Task, i.Comments
	from deleted d, inserted i 
	set identity_insert WorkHoursLogs off

--go
--update WorkHours
--set Task = 'cheese'
--where WorkHoursId = 2;
--go