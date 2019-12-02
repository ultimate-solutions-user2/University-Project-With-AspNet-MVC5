namespace Unvirsity_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        university_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Universities", t => t.university_ID, cascadeDelete: true)
                .Index(t => t.university_ID);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Telephon = c.String(),
                        Min_Digree = c.Int(nullable: false),
                        Costs = c.Int(nullable: false),
                        Image = c.Binary(),
                        Faculty_Detailes = c.String(),
                        Required_Document = c.String(),
                        branch_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Branches", t => t.branch_ID, cascadeDelete: true)
                .Index(t => t.branch_ID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Faculty_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Faculties", t => t.Faculty_ID, cascadeDelete: true)
                .Index(t => t.Faculty_ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Max_Digree = c.Int(nullable: false),
                        Min_Digree = c.Int(nullable: false),
                        NO_OF_Hours = c.Int(nullable: false),
                        Is_Elective = c.Boolean(nullable: false),
                        Departments_ID = c.Int(nullable: false),
                        prof_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.Departments_ID, cascadeDelete: true)
                .ForeignKey("dbo.Professors", t => t.prof_id, cascadeDelete: true)
                .Index(t => t.Departments_ID)
                .Index(t => t.prof_id);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Signtific_Digree = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Submit_Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        The_name_is_quadrant = c.String(),
                        Total_General_Secondary_Degrees = c.String(),
                        Address = c.String(),
                        Telephon = c.String(),
                        image = c.Binary(),
                        Faculty_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Faculties", t => t.Faculty_ID, cascadeDelete: true)
                .Index(t => t.Faculty_ID);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        image = c.Binary(),
                        Location = c.String(),
                        address = c.String(),
                        Telephon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        latitude = c.Double(nullable: false),
                        longitude = c.Double(nullable: false),
                        university_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Universities", t => t.university_ID, cascadeDelete: true)
                .Index(t => t.university_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Branches", "university_ID", "dbo.Universities");
            DropForeignKey("dbo.Locations", "university_ID", "dbo.Universities");
            DropForeignKey("dbo.Submit_Student", "Faculty_ID", "dbo.Faculties");
            DropForeignKey("dbo.Departments", "Faculty_ID", "dbo.Faculties");
            DropForeignKey("dbo.Courses", "prof_id", "dbo.Professors");
            DropForeignKey("dbo.Courses", "Departments_ID", "dbo.Departments");
            DropForeignKey("dbo.Faculties", "branch_ID", "dbo.Branches");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Locations", new[] { "university_ID" });
            DropIndex("dbo.Submit_Student", new[] { "Faculty_ID" });
            DropIndex("dbo.Courses", new[] { "prof_id" });
            DropIndex("dbo.Courses", new[] { "Departments_ID" });
            DropIndex("dbo.Departments", new[] { "Faculty_ID" });
            DropIndex("dbo.Faculties", new[] { "branch_ID" });
            DropIndex("dbo.Branches", new[] { "university_ID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Locations");
            DropTable("dbo.Universities");
            DropTable("dbo.Submit_Student");
            DropTable("dbo.Professors");
            DropTable("dbo.Courses");
            DropTable("dbo.Departments");
            DropTable("dbo.Faculties");
            DropTable("dbo.Branches");
        }
    }
}
