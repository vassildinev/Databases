namespace EntityFrameworkHomework
{
    using System.Data.Linq;

    public partial class Employee
    {
        public EntitySet<Territory> TerritoriesEntities
        {
            get
            {
                var territories = new EntitySet<Territory>();

                //using (var db = new NorthwindEntities())
                //{
                //    var query = @"select EmployeeID, TerritoryID " +
                //                "from Territories ";

                //    var data = new ObjectQuery<DbDataRecord>(query,
                //                (((IObjectContextAdapter)db).ObjectContext))
                //                .Where(record => (int)record[0] == this.EmployeeID);

                //    foreach (var item in data)
                //    {
                //        var territory = db.Territories.Where(t => t.TerritoryID == (string)item[0]).FirstOrDefault();
                //        territories.Add(territory);
                //    }
                //}

                return territories;
            }
        }
    }
}
