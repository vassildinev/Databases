use TelerikAcademy;

select FirstName, LastName, a.AddressText from Employees e
inner join Addresses a on a.AddressID = e.AddressID;