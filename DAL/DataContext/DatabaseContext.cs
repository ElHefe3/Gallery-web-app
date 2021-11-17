using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                OptionsBuilder.UseSqlServer(settings.SqlConnectionString);
                DatabaseOptions = OptionsBuilder.Options;
            }

            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }
            private AppConfiguration settings { get; set; }
        }

        public static OptionsBuild Options = new OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<I_Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }

       // todo:mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //SET CUSTOM DEFAULT VALUE ON CREATION
            DateTime image_Capture_Date = new DateTime(1900, 1, 1);

            #region User
            modelBuilder.Entity<User>().ToTable("user");
            //Primary Key & Identity Column
            modelBuilder.Entity<User>().HasKey(user => user.User_ID);
            modelBuilder.Entity<User>().Property(user => user.User_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("user_id");
            //COLUMN SETTINGS
            modelBuilder.Entity<User>().Property(user => user.User_Name).IsRequired(true).HasMaxLength(100).HasColumnName("user_name");
            modelBuilder.Entity<User>().Property(user => user.User_Surname).IsRequired(true).HasMaxLength(100).HasColumnName("user_surname");
            modelBuilder.Entity<User>().Property(user => user.User_Email).IsRequired(true).HasMaxLength(100).HasColumnName("user_email");
            modelBuilder.Entity<User>().Property(user => user.User_Nickname).IsRequired(true).HasMaxLength(100).HasColumnName("user_nickname");
            modelBuilder.Entity<User>().Property(user => user.Password_Hash).IsRequired(false).HasMaxLength(250).HasColumnName("contact_email");//(no Applicant_)Will be guardians/parents Email
            
            //RelationShips
            modelBuilder.Entity<User>()
                   .HasMany<I_Permission>(user => user.I_Permissions)
                   .WithOne(i_p => i_p.User)
                   .HasForeignKey(i_p => i_p.User_ID)
                   .OnDelete(DeleteBehavior.Restrict);//Can't delete 

             modelBuilder.Entity<User>()
                   .HasMany<A_Permission>(user => user.A_Permissions)
                   .WithOne(a_p => a_p.User)
                   .HasForeignKey(a_p => a_p.User_ID)
                   .OnDelete(DeleteBehavior.Restrict);//Can't delete 
            #endregion


            #region Album
            modelBuilder.Entity<Album>().ToTable("album");
            //Primary Key & Identity Column
            modelBuilder.Entity<Album>().HasKey(album => album.Album_ID);
            modelBuilder.Entity<Album>().Property(album => album.Album_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("album_id");
            //COLUMN SETTINGS
            modelBuilder.Entity<Album>().Property(album => album.Album_Name).IsRequired(true).HasMaxLength(100).HasColumnName("album_name");
            modelBuilder.Entity<Album>().Property(album => album.Album_Description).IsRequired(true).HasMaxLength(100).HasColumnName("album_description");


            //RelationShips
            modelBuilder.Entity<Album>()
                .HasMany<A_Permission>(album => album.A_Permissions)
                .WithOne(i_p => i_p.Album)
                .HasForeignKey(i_p => i_p.Album_ID)
                .OnDelete(DeleteBehavior.Restrict);//Can't delete  
            #endregion




            #region Image
            modelBuilder.Entity<Image>().ToTable("user");
            //Primary Key & Identity Column
            modelBuilder.Entity<Image>().HasKey(image => image.Image_ID);
            modelBuilder.Entity<Image>().Property(image => image.Image_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("image_id");
            //COLUMN SETTINGS
            modelBuilder.Entity<Image>().Property(image => image.Album_ID).IsRequired(true).HasMaxLength(100).HasColumnName("album_id");
            modelBuilder.Entity<Image>().Property(image => image.Image_Captured_Date).IsRequired(true).HasDefaultValue(image_Capture_Date).HasColumnName("image_capture_date");
            modelBuilder.Entity<Image>().Property(image => image.Image_Captured_By).IsRequired(true).HasMaxLength(100).HasColumnName("image_captured_by");
            modelBuilder.Entity<Image>().Property(image => image.Image_Tags).IsRequired(true).HasMaxLength(100).HasColumnName("image_tags");


            //RelationShips
            modelBuilder.Entity<Image>()
                   .HasMany<I_Permission>(image => image.I_Permissions)
                   .WithOne(i_p => i_p.Image)
                   .HasForeignKey(i_p => i_p.Image_ID)
                   .OnDelete(DeleteBehavior.Restrict);//Can't delete 
            #endregion


            #region I_Permission
            modelBuilder.Entity<I_Permission>().ToTable("i_permission");
            //Primary Key & Identity Column
            modelBuilder.Entity<I_Permission>().HasKey(i_p => i_p.I_Permission_ID);
            modelBuilder.Entity<I_Permission>().Property(i_p => i_p.I_Permission_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("i_permission_id");
            //COLUMN SETTINGS
            modelBuilder.Entity<I_Permission>().Property(i_p => i_p.Image_ID).IsRequired(true).HasMaxLength(100).HasColumnName("image_id");
            modelBuilder.Entity<I_Permission>().Property(i_p => i_p.User_ID).IsRequired(true).HasMaxLength(100).HasColumnName("user_id");
            modelBuilder.Entity<I_Permission>().Property(i_p => i_p.I_Permission_Type).IsRequired(true).HasMaxLength(100).HasColumnName("i_permission_type");

            //RelationShips
            modelBuilder.Entity<I_Permission>()
                .HasOne<User>(i_p => i_p.User)
                .WithMany(user => user.I_Permissions)//Image is linked to many I_Permissions
                .HasForeignKey(i_p => i_p.User_ID)
                .OnDelete(DeleteBehavior.NoAction);//Can delete an application.

            modelBuilder.Entity<I_Permission>()
                .HasOne<Image>(i_p => i_p.Image)
                .WithMany(image => image.I_Permissions)//Image is linked to many I_Permissions
                .HasForeignKey(i_p => i_p.Image_ID)
                .OnDelete(DeleteBehavior.NoAction);//Can delete 
            #endregion


            #region A_Permission
            modelBuilder.Entity<A_Permission>().ToTable("a_permission");
            //Primary Key & Identity Column
            modelBuilder.Entity<A_Permission>().HasKey(a_p => a_p.A_Permission_ID);
            modelBuilder.Entity<A_Permission>().Property(a_p => a_p.A_Permission_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("i_permission_id");
            //COLUMN SETTINGS
            modelBuilder.Entity<A_Permission>().Property(a_p => a_p.Album_ID).IsRequired(true).HasMaxLength(100).HasColumnName("album_id");
            modelBuilder.Entity<A_Permission>().Property(a_p => a_p.User_ID).IsRequired(true).HasMaxLength(100).HasColumnName("user_id");
            modelBuilder.Entity<A_Permission>().Property(a_p => a_p.A_Permission_Type).IsRequired(true).HasMaxLength(100).HasColumnName("a_permission_type");

            //RelationShips
            modelBuilder.Entity<A_Permission>()
                .HasOne<User>(a_p => a_p.User)
                .WithMany(user => user.A_Permissions)//User is linked to many A_Permissions
                .HasForeignKey(a_p => a_p.User_ID)
                .OnDelete(DeleteBehavior.NoAction);//Can delete an application.


            modelBuilder.Entity<A_Permission>()
                .HasOne<Album>(a_p => a_p.Album)
                .WithMany(album => album.A_Permissions)//User is linked to many A_Permissions
                .HasForeignKey(a_p => a_p.Album_ID)
                .OnDelete(DeleteBehavior.NoAction);//Can delete 
            #endregion









        }
    }

    
}
