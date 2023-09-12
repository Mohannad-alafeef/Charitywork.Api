using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CharityWork.Core.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AboutUsPage> AboutUsPages { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Charity> Charities { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<ContactUsPage> ContactUsPages { get; set; } = null!;
        public virtual DbSet<Goal> Goals { get; set; } = null!;
        public virtual DbSet<HomePage> HomePages { get; set; } = null!;
        public virtual DbSet<IssuesReport> IssuesReports { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<TestimonialPage> TestimonialPages { get; set; } = null!;
        public virtual DbSet<UserAccount> UserAccounts { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;
        public virtual DbSet<VisaCard> VisaCards { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##FINALPROJECT")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<AboutUsPage>(entity =>
            {
                entity.HasKey(e => e.AboutId)
                    .HasName("SYS_C008457");

                entity.ToTable("ABOUT_US_PAGE");

                entity.Property(e => e.AboutId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUT_ID");

                entity.Property(e => e.HomeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Text)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.AboutUsPages)
                    .HasForeignKey(d => d.HomeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_HOME_ABOUT");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");
            });

            modelBuilder.Entity<Charity>(entity =>
            {
                entity.ToTable("CHARITY");

                entity.Property(e => e.CharityId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CHARITY_ID");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CharityName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CHARITY_NAME");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DonationGoal)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("DONATION_GOAL");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.IsAccepted)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IS_ACCEPTED");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.Mission)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MISSION");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Charities)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CATEGORY_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Charities)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_USER_ID");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("CONTACT");

                entity.Property(e => e.ContactId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.ContactContent)
                    .HasMaxLength(1000)
                    .HasColumnName("CONTACT_CONTENT");

                entity.Property(e => e.ContactStatus)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CONTACT_STATUS");

                entity.Property(e => e.ContactSubject)
                    .HasMaxLength(200)
                    .HasColumnName("CONTACT_SUBJECT");

                entity.Property(e => e.SenderEmail)
                    .HasMaxLength(100)
                    .HasColumnName("SENDER_EMAIL");

                entity.Property(e => e.SenderName)
                    .HasMaxLength(100)
                    .HasColumnName("SENDER_NAME");
            });

            modelBuilder.Entity<ContactUsPage>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("SYS_C008460");

                entity.ToTable("CONTACT_US_PAGE");

                entity.Property(e => e.ContactId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.HomeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.OpenHours)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPEN_HOURS");

                entity.Property(e => e.Phone)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.ContactUsPages)
                    .HasForeignKey(d => d.HomeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_HOME_CONTACT");
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.ToTable("GOAL");

                entity.Property(e => e.GoalId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("GOAL_ID");

                entity.Property(e => e.CharityId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARITY_ID");

                entity.Property(e => e.GoalText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GOAL_TEXT");

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.CharityId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CHARITY_ID");
            });

            modelBuilder.Entity<HomePage>(entity =>
            {
                entity.HasKey(e => e.HomeId)
                    .HasName("SYS_C008455");

                entity.ToTable("HOME_PAGE");

                entity.Property(e => e.HomeId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Text)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<IssuesReport>(entity =>
            {
                entity.HasKey(e => e.ProblemId)
                    .HasName("SYS_C008480");

                entity.ToTable("ISSUES_REPORT");

                entity.Property(e => e.ProblemId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PROBLEM_ID");

                entity.Property(e => e.Message)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.ReportDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REPORT_DATE");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IssuesReports)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_USER_PROBLEM");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("PAYMENT");

                entity.Property(e => e.PaymentId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAYMENT_ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.CharityId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARITY_ID");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PAYMENT_DATE");

                entity.Property(e => e.PaymentType)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PAYMENT_TYPE");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CharityId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CHARITY_PAYMENT");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_USER_PAYMENT");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.TestimonialId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIAL_ID");

                entity.Property(e => e.Content)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.IsAccepted)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IS_ACCEPTED");

                entity.Property(e => e.Rate)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RATE");

                entity.Property(e => e.TestimonialDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TESTIMONIAL_DATE");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_USER_TESTIMONIAL");
            });

            modelBuilder.Entity<TestimonialPage>(entity =>
            {
                entity.HasKey(e => e.TestimonialId)
                    .HasName("SYS_C008463");

                entity.ToTable("TESTIMONIAL_PAGE");

                entity.Property(e => e.TestimonialId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIAL_ID");

                entity.Property(e => e.HomeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Text)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.TestimonialPages)
                    .HasForeignKey(d => d.HomeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_HOME_TESTIMONIAL");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("SYS_C008466");

                entity.ToTable("USER_ACCOUNT");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Age)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AGE");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_OF_BIRTH");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.LoginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LOGIN_DATE");

                entity.Property(e => e.LoginId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_LOGIN_ID");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("SYS_C008450");

                entity.ToTable("USER_LOGIN");

                entity.Property(e => e.LoginId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ROLE_ID");
            });

            modelBuilder.Entity<VisaCard>(entity =>
            {
                entity.HasKey(e => e.VisaId)
                    .HasName("SYS_C008493");

                entity.ToTable("VISA_CARD");

                entity.Property(e => e.VisaId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VISA_ID");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(50)
                    .HasColumnName("CARD_NUMBER");

                entity.Property(e => e.Cvv)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CVV");

                entity.Property(e => e.ExpDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXP_DATE");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VisaCards)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_VU");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
