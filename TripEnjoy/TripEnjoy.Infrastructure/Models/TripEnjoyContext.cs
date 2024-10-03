using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TripEnjoy.Domain.Models;
namespace TripEnjoy.Infrastructure.Models;

public partial class TripEnjoyContext : DbContext
{
    public TripEnjoyContext()
    {
    }

    public TripEnjoyContext(DbContextOptions<TripEnjoyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelQuestion> HotelQuestions { get; set; }

    public virtual DbSet<ImageHotel> ImageHotels { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomImage> RoomImages { get; set; }

    public virtual DbSet<RoomStatus> RoomStatuses { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    public virtual DbSet<VoucherUser> VoucherUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TANDAT\\MSSQLSERVER03;Database=TripEnjoy;uid=sa;pwd=1234;Trusted_Connection=False;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Accounts_UserId");

            entity.Property(e => e.AccountAddress).HasMaxLength(255);
            entity.Property(e => e.AccountBalance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AccountEmail).HasMaxLength(255);
            entity.Property(e => e.AccountFullname).HasMaxLength(100);
            entity.Property(e => e.AccountGender).HasMaxLength(50);
            entity.Property(e => e.AccountImage).HasMaxLength(255);
            entity.Property(e => e.AccountPassword).HasMaxLength(50);
            entity.Property(e => e.AccountPhone).HasMaxLength(12);
            entity.Property(e => e.AccountUsername).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Accounts).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_Bookings_AccountId");

            entity.HasIndex(e => e.RoomId, "IX_Bookings_RoomId");

            entity.HasIndex(e => e.VoucherId, "IX_Bookings_VoucherId");

            entity.Property(e => e.BookingStatus).HasMaxLength(10);
            entity.Property(e => e.BookingTotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.Bookings).HasForeignKey(d => d.AccountId);

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Voucher).WithMany(p => p.Bookings).HasForeignKey(d => d.VoucherId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_Comments_AccountId");

            entity.HasIndex(e => e.RoomId, "IX_Comments_RoomId");

            entity.Property(e => e.CommentReply).HasMaxLength(255);

            entity.HasOne(d => d.Account).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Room).WithMany(p => p.Comments)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.HasIndex(e => e.AccountId1, "IX_Conversations_AccountId1");

            entity.HasIndex(e => e.AccountId2, "IX_Conversations_AccountId2");

            entity.HasOne(d => d.AccountId1Navigation).WithMany(p => p.ConversationAccountId1Navigations)
                .HasForeignKey(d => d.AccountId1)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.AccountId2Navigation).WithMany(p => p.ConversationAccountId2Navigations)
                .HasForeignKey(d => d.AccountId2)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_Hotels_AccountId");

            entity.Property(e => e.HotelAddress).HasMaxLength(255);
            entity.Property(e => e.HotelName).HasMaxLength(255);
            entity.Property(e => e.HotelPhone).HasMaxLength(10);
            entity.Property(e => e.HotelStatus).HasMaxLength(255);

            entity.HasOne(d => d.Account).WithMany(p => p.Hotels).HasForeignKey(d => d.AccountId);

            entity.HasOne(d => d.Category).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Hotels_Categories");
        });

        modelBuilder.Entity<HotelQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId);

            entity.HasIndex(e => e.HotelId, "IX_HotelQuestions_HotelId");

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelQuestions).HasForeignKey(d => d.HotelId);
        });

        modelBuilder.Entity<ImageHotel>(entity =>
        {
            entity.HasKey(e => e.ImageId);

            entity.HasIndex(e => e.HotelId, "IX_ImageHotels_HotelId");

            entity.HasOne(d => d.Hotel).WithMany(p => p.ImageHotels).HasForeignKey(d => d.HotelId);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasIndex(e => e.ConversationId, "IX_Messages_ConversationId");

            entity.HasIndex(e => e.SenderId, "IX_Messages_SenderId");

            entity.HasOne(d => d.Conversation).WithMany(p => p.Messages).HasForeignKey(d => d.ConversationId);

            entity.HasOne(d => d.Sender).WithMany(p => p.Messages).HasForeignKey(d => d.SenderId);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_Notifications_AccountId");

            entity.HasOne(d => d.Account).WithMany(p => p.Notifications).HasForeignKey(d => d.AccountId);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasIndex(e => e.BookingId, "IX_Payments_BookingId");

            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentStatus).HasMaxLength(10);

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments).HasForeignKey(d => d.BookingId);
        });

        modelBuilder.Entity<Rate>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_Rates_AccountId");

            entity.HasIndex(e => e.RoomId, "IX_Rates_RoomId");

            entity.HasOne(d => d.Account).WithMany(p => p.Rates)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Room).WithMany(p => p.Rates)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasIndex(e => e.HotelId, "IX_Rooms_HotelId");

            entity.HasIndex(e => e.RoomStatusId, "IX_Rooms_RoomStatusID");

            entity.HasIndex(e => e.RoomTypeId, "IX_Rooms_RoomTypeId");

            entity.Property(e => e.RoomPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RoomStatusId).HasColumnName("RoomStatusID");
            entity.Property(e => e.RoomTitle).HasMaxLength(255);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms).HasForeignKey(d => d.HotelId);

            entity.HasOne(d => d.RoomStatus).WithMany(p => p.Rooms).HasForeignKey(d => d.RoomStatusId);

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms).HasForeignKey(d => d.RoomTypeId);
        });

        modelBuilder.Entity<RoomImage>(entity =>
        {
            entity.HasKey(e => e.ImageId);

            entity.HasIndex(e => e.RoomId, "IX_RoomImages_RoomId");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomImages).HasForeignKey(d => d.RoomId);
        });

        modelBuilder.Entity<RoomStatus>(entity =>
        {
            entity.Property(e => e.RoomStatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.Property(e => e.RoomTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.Property(e => e.VoucherCode).HasMaxLength(6);
        });

        modelBuilder.Entity<VoucherUser>(entity =>
        {
            entity.HasKey(e => new { e.VoucherId, e.AccountId });

            entity.HasIndex(e => e.AccountId, "IX_VoucherUsers_AccountId");

            entity.HasOne(d => d.Account).WithMany(p => p.VoucherUsers).HasForeignKey(d => d.AccountId);

            entity.HasOne(d => d.Voucher).WithMany(p => p.VoucherUsers).HasForeignKey(d => d.VoucherId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
