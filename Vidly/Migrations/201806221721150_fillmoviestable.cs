namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fillmoviestable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(name,genre,releaseDate,inStock) VALUES ('Shrek','comedy','2001-06-29',10) ");
            Sql("INSERT INTO Movies(name,genre,releaseDate,inStock) VALUES ('Toy Story','slice-of-life','1996-03-21',4) ");
            Sql("INSERT INTO Movies(name,genre,releaseDate,inStock) VALUES ('Spirited Away','Anime','2003-09-12', 2) ");
            Sql("INSERT INTO Movies(name,genre,releaseDate,inStock) VALUES ('The Hateful Eight','Thriller','2016-02-05',12) ");
            Sql("INSERT INTO Movies(name,genre,releaseDate,inStock) VALUES ('Gurren Lagann The Movie: Childhoods End','Anime','2008-09-06',5) ");
        }
        
        public override void Down()
        {
        }
    }
}
