using SampleEFApp.Model;

namespace SampleEFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeTrackerdbContext context = new EmployeeTrackerdbContext();
            //Area area = new Area();
            //area.Area1 = "POPO";
            //area.Zipcode = "44332";
            //context.Areas.Add(area);
            //context.SaveChanges();
            var areas = context.Areas.ToList();
            var area = areas.SingleOrDefault(a => a.Area1 == "KKKK");
            area.Zipcode = "00000";
            context.Areas.Update(area);
            context.SaveChanges();

            area = areas.SingleOrDefault(a => a.Area1 == "POPO");
            context.Areas.Remove(area);
            context.SaveChanges();
            foreach (var a in areas)
            {
                Console.WriteLine(a.Area1 + " " + a.Zipcode);
            }
        }
    }
}
  //  Scaffold-DbContext "data source=DB66JX3\DEMOINSTANCE;Integrated security=true;Initial Catalog=EmployeeTrackerdb;"Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model