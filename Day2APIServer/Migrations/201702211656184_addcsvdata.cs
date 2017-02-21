namespace Day2APIServer.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;

    public partial class addcsvdata : DbMigration
    {
        public override void Up()
        {
            var systemPath = AppDomain.CurrentDomain.BaseDirectory + @"..\App_Data\data.csv";
            var openfile = File.ReadAllLines(systemPath);
            foreach (string row in openfile)
            {
                var data = row.Split(',');
                Cereal newCereal = new Cereal
                {
                    Name = data[0],
                    Manufacturer = data[1]
                };
                db.Cereals.Add(newCereal);
            }
            db.SaveChanges();
            // --------------------- :)
            throw new Exception("cookies");
        }
        
        public override void Down()
        {
        }
    }
}
