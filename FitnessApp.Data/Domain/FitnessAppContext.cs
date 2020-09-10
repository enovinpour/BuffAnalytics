using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FitnessApp.Data.Domain
{
    public partial class FitnessAppContext : DbContext
    {
        public FitnessAppContext()
        {
        }

        public FitnessAppContext(DbContextOptions<FitnessAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authentications> Authentications { get; set; }
        public virtual DbSet<Exercises> Exercises { get; set; }
        public virtual DbSet<Progress> Progress { get; set; }
        public virtual DbSet<UserExercises> UserExercises { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Workouts> Workouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=FitnessApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authentications>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Authenti__CBA1B257A557A787");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exercises>(entity =>
            {
                entity.HasKey(e => e.Exerciseid)
                    .HasName("PK__Exercise__55F87AE9F632CB1C");

                entity.Property(e => e.Exerciseid)
                    .HasColumnName("exerciseid")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Dayoftheweek)
                    .HasColumnName("dayoftheweek")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Goalrep).HasColumnName("goalrep");

                entity.Property(e => e.Goalset).HasColumnName("goalset");

                entity.Property(e => e.Goalweight)
                    .HasColumnName("goalweight")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Maxonerep)
                    .HasColumnName("maxonerep")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Startrep).HasColumnName("startrep");

                entity.Property(e => e.Startset).HasColumnName("startset");

                entity.Property(e => e.Startweight)
                    .HasColumnName("startweight")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Workoutid)
                    .HasColumnName("workoutid")
                    .HasColumnType("numeric(3, 0)");

                entity.HasOne(d => d.Workout)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.Workoutid)
                    .HasConstraintName("FK__Exercises__worko__2E1BDC42");
            });

            modelBuilder.Entity<Progress>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.Userid, e.Exerciseid })
                    .HasName("PK__Progress__5D31C2A321B08CB6");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Exerciseid)
                    .HasColumnName("exerciseid")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Reps).HasColumnName("reps");

                entity.Property(e => e.Rpe).HasColumnName("rpe");

                entity.Property(e => e.Setnumber).HasColumnName("setnumber");

                entity.Property(e => e.Workingweight)
                    .HasColumnName("workingweight")
                    .HasColumnType("numeric(5, 2)");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.Progress)
                    .HasForeignKey(d => d.Exerciseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Progress__exerci__38996AB5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Progress)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Progress__userid__37A5467C");
            });

            modelBuilder.Entity<UserExercises>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.Exerciseid })
                    .HasName("PK__UserExer__4EFE35F99E2D829C");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Exerciseid)
                    .HasColumnName("exerciseid")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Routineactive).HasColumnName("routineactive");

                entity.Property(e => e.Routinestartdate)
                    .HasColumnName("routinestartdate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.UserExercises)
                    .HasForeignKey(d => d.Exerciseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserExerc__exerc__34C8D9D1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserExercises)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserExerc__useri__33D4B598");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Users__CBA1B2575D060A88");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Goalweight)
                    .HasColumnName("goalweight")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("numeric(5, 2)");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Users)
                    .HasForeignKey<Users>(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__userid__30F848ED");
            });

            modelBuilder.Entity<Workouts>(entity =>
            {
                entity.HasKey(e => e.Workoutid)
                    .HasName("PK__Workouts__09F9E4F2C5C47DC2");

                entity.Property(e => e.Workoutid)
                    .HasColumnName("workoutid")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Workoutname)
                    .HasColumnName("workoutname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Workouttype)
                    .HasColumnName("workouttype")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
