using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Airlines.Models;

namespace Airlines.Data
{
    public partial class airlinesDBContext : DbContext
    {
        public airlinesDBContext()
        {
        }

        public airlinesDBContext(DbContextOptions<airlinesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Билеты> Билеты { get; set; }
        public virtual DbSet<Должности> Должности { get; set; }
        public virtual DbSet<Рейсы> Рейсы { get; set; }
        public virtual DbSet<Самолёты> Самолёты { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }
        public virtual DbSet<ТипыСамолётов> ТипыСамолётов { get; set; }
        public virtual DbSet<Экипажи> Экипажи { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
             //   optionsBuilder.UseSqlite("Data Source=C:\\DB\\airlinesDB.db");
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=airlinesDB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Билеты>(entity =>
            {
                entity.HasKey(e => e.ПаспортныеДанные);

                entity.HasIndex(e => e.КодРейса)
                    .IsUnique();

                entity.Property(e => e.ПаспортныеДанные)
                    .HasColumnName("паспортные_данные")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.КодРейса)
                    .HasColumnName("код_рейса")
                    .HasColumnType("INT");

                entity.Property(e => e.Место)
                    .HasColumnName("место")
                    .HasColumnType("INT");

                entity.Property(e => e.ФиоПассажира)
                    .HasColumnName("ФИО_пассажира")
                    .HasColumnType("INT");

                entity.Property(e => e.Цена)
                    .HasColumnName("цена")
                    .HasColumnType("INT");

                entity.HasOne(d => d.КодРейсаNavigation)
                    .WithOne(p => p.Билеты)
                    .HasForeignKey<Билеты>(d => d.КодРейса)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Должности>(entity =>
            {
                entity.HasKey(e => e.КодДолжности);

                entity.Property(e => e.КодДолжности)
                    .HasColumnName("код_должности")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.КодЭкипажа)
                    .HasColumnName("код_экипажа")
                    .HasColumnType("INT");

                entity.Property(e => e.НаименованиеДолжности)
                    .HasColumnName("наименование_должности")
                    .HasColumnType("INT");

                entity.Property(e => e.Обязанности)
                    .HasColumnName("обязанности")
                    .HasColumnType("INT");

                entity.Property(e => e.Оклад)
                    .HasColumnName("оклад")
                    .HasColumnType("INT");

                entity.Property(e => e.Требования)
                    .HasColumnName("требования")
                    .HasColumnType("INT");

                entity.HasOne(d => d.КодЭкипажаNavigation)
                    .WithMany(p => p.Должности)
                    .HasForeignKey(d => d.КодЭкипажа)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Рейсы>(entity =>
            {
                entity.HasKey(e => e.КодРейса);

                entity.HasIndex(e => e.КодЭкипажа)
                    .IsUnique();

                entity.Property(e => e.КодРейса)
                    .HasColumnName("код_рейса")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Время)
                    .HasColumnName("время")
                    .HasColumnType("INT");

                entity.Property(e => e.ВремяПолёта)
                    .HasColumnName("время_полёта")
                    .HasColumnType("INT");

                entity.Property(e => e.Дата)
                    .HasColumnName("дата")
                    .HasColumnType("INT");

                entity.Property(e => e.КодСамолёта)
                    .HasColumnName("код_самолёта")
                    .HasColumnType("INT");

                entity.Property(e => e.КодЭкипажа)
                    .HasColumnName("код_экипажа")
                    .HasColumnType("INT");

                entity.Property(e => e.Куда)
                    .HasColumnName("куда")
                    .HasColumnType("INT");

                entity.Property(e => e.Откуда)
                    .HasColumnName("откуда")
                    .HasColumnType("INT");
            });

            modelBuilder.Entity<Самолёты>(entity =>
            {
                entity.HasKey(e => e.КодСотрудников);

                entity.HasIndex(e => e.КодСамолёта)
                    .IsUnique();

                entity.HasIndex(e => e.КодТипа)
                    .IsUnique();

                entity.Property(e => e.КодСотрудников)
                    .HasColumnName("код_сотрудников")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Вместимость)
                    .HasColumnName("вместимость")
                    .HasColumnType("INT");

                entity.Property(e => e.Грузоподъёмность)
                    .HasColumnName("грузоподъёмность")
                    .HasColumnType("INT");

                entity.Property(e => e.ДатаВыпуска)
                    .HasColumnName("дата_выпуска")
                    .HasColumnType("INT");

                entity.Property(e => e.ДатаПоследнегоРемонта)
                    .HasColumnName("дата_последнего_ремонта")
                    .HasColumnType("INT");

                entity.Property(e => e.КодРейса)
                    .HasColumnName("код_рейса")
                    .HasColumnType("INT");

                entity.Property(e => e.КодСамолёта)
                    .HasColumnName("код_самолёта")
                    .HasColumnType("INT");

                entity.Property(e => e.КодТипа)
                    .HasColumnName("код_типа")
                    .HasColumnType("INT");

                entity.Property(e => e.Марка)
                    .HasColumnName("марка")
                    .HasColumnType("INT");

                entity.Property(e => e.НалётаноЧасов)
                    .HasColumnName("налётано_часов")
                    .HasColumnType("INT");

                entity.Property(e => e.ПаспортныеДанные)
                    .HasColumnName("паспортные_данные")
                    .HasColumnType("INT");

                entity.Property(e => e.ТехническиеХарактиристики)
                    .HasColumnName("технические_характиристики")
                    .HasColumnType("INT");

                entity.HasOne(d => d.КодРейсаNavigation)
                    .WithMany(p => p.Самолёты)
                    .HasForeignKey(d => d.КодРейса)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодСотрудниковNavigation)
                    .WithOne(p => p.Самолёты)
                    .HasForeignKey<Самолёты>(d => d.КодСотрудников)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодТипаNavigation)
                    .WithOne(p => p.Самолёты)
                    .HasForeignKey<Самолёты>(d => d.КодТипа)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ПаспортныеДанныеNavigation)
                    .WithMany(p => p.Самолёты)
                    .HasForeignKey(d => d.ПаспортныеДанные)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Сотрудники>(entity =>
            {
                entity.HasKey(e => e.КодСотрудников);

                entity.HasIndex(e => e.ПаспортныеДанные)
                    .IsUnique();

                entity.Property(e => e.КодСотрудников)
                    .HasColumnName("код_сотрудников")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Адрес)
                    .HasColumnName("адрес")
                    .HasColumnType("INT");

                entity.Property(e => e.Возраст)
                    .HasColumnName("возраст")
                    .HasColumnType("INT");

                entity.Property(e => e.КодДолжности)
                    .HasColumnName("код_должности")
                    .HasColumnType("INT");

                entity.Property(e => e.ПаспортныеДанные)
                    .HasColumnName("паспортные_данные")
                    .HasColumnType("INT");

                entity.Property(e => e.Пол)
                    .HasColumnName("пол")
                    .HasColumnType("INT");

                entity.Property(e => e.Телефон)
                    .HasColumnName("телефон")
                    .HasColumnType("INT");

                entity.Property(e => e.Фио)
                    .HasColumnName("ФИО")
                    .HasColumnType("INT");

                entity.HasOne(d => d.КодДолжностиNavigation)
                    .WithMany(p => p.Сотрудники)
                    .HasForeignKey(d => d.КодДолжности)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ТипыСамолётов>(entity =>
            {
                entity.HasKey(e => e.КодТипа);

                entity.ToTable("Типы_самолётов");

                entity.Property(e => e.КодТипа)
                    .HasColumnName("код_типа")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Назначение)
                    .HasColumnName("назначение")
                    .HasColumnType("INT");

                entity.Property(e => e.Наименование)
                    .HasColumnName("наименование")
                    .HasColumnType("INT");

                entity.Property(e => e.Ограничения)
                    .HasColumnName("ограничения")
                    .HasColumnType("INT");
            });

            modelBuilder.Entity<Экипажи>(entity =>
            {
                entity.HasKey(e => e.КодЭкипажа);

                entity.Property(e => e.КодЭкипажа)
                    .HasColumnName("код_экипажа")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.КодСотрудника1)
                    .HasColumnName("код_сотрудника_1")
                    .HasColumnType("INT");

                entity.Property(e => e.КодСотрудника2)
                    .HasColumnName("код_сотрудника_2")
                    .HasColumnType("INT");

                entity.Property(e => e.КодСотрудника3)
                    .HasColumnName("код_сотрудника_3")
                    .HasColumnType("INT");

                entity.Property(e => e.НалётаноЧасов)
                    .HasColumnName("налётано_часов")
                    .HasColumnType("INT");

                entity.Property(e => e.ПаспортныеДанные)
                    .HasColumnName("паспортные_данные")
                    .HasColumnType("INT");

                entity.HasOne(d => d.КодСотрудника1Navigation)
                    .WithMany(p => p.ЭкипажиКодСотрудника1Navigation)
                    .HasForeignKey(d => d.КодСотрудника1)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодСотрудника2Navigation)
                    .WithMany(p => p.ЭкипажиКодСотрудника2Navigation)
                    .HasForeignKey(d => d.КодСотрудника2)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.КодСотрудника3Navigation)
                    .WithMany(p => p.ЭкипажиКодСотрудника3Navigation)
                    .HasForeignKey(d => d.КодСотрудника3)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ПаспортныеДанныеNavigation)
                    .WithMany(p => p.Экипажи)
                    .HasForeignKey(d => d.ПаспортныеДанные)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
