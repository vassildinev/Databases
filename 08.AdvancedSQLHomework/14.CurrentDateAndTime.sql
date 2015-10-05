select cast(datepart(DD, getdate()) as varchar) + '.' + 
	   cast(datepart(MM, getdate()) as varchar) + '.' +
	   cast(datepart(YYYY, getdate()) as varchar) + ' ' +
	   cast(datepart(hh, getdate()) as varchar) + ':' +
	   cast(datepart(mi, getdate()) as varchar) + ':' + 
	   cast(datepart(ss, getdate()) as varchar) + ':' +
	   cast(datepart(ms, getdate()) as varchar)
	   as [Current date and time];