namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenrePropOfMovieClass : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO Movies (Id, Name, Genre) VALUES (1, 'Hangover', 'Comedy')");
            //Sql("INSERT INTO Movies (Id, Name, Genre) VALUES (2, 'Die Hard', 'Action')");
            //Sql("INSERT INTO Movies (Id, Name, Genre) VALUES (3, 'The Terminator', 'Comedy')");
            //Sql("INSERT INTO Movies (Id, Name, Genre) VALUES (4, 'Toy Story', 'Family')");
            //Sql("INSERT INTO Movies (Id, Name, Genre) VALUES (5, 'Titanic', 'Romance')");

        }
        
        public override void Down()
        {
        }
    }
}
