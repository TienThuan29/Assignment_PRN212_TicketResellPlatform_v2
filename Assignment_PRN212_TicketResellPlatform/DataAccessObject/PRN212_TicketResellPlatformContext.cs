using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BusinessObject;
using Microsoft.Extensions.Configuration;

namespace DataAccessObject
{
    public partial class PRN212_TicketResellPlatformContext : DbContext
    {
        public PRN212_TicketResellPlatformContext()
        {
        }

        public PRN212_TicketResellPlatformContext(DbContextOptions<PRN212_TicketResellPlatformContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<GenericTicket> GenericTickets { get; set; } = null!;
        public virtual DbSet<Hashtag> Hashtags { get; set; } = null!;
        public virtual DbSet<HashtagEvent> HashtagEvents { get; set; } = null!;
        public virtual DbSet<OrderTicket> OrderTickets { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Policy> Policies { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<ReportFraud> ReportFrauds { get; set; } = null!;
        public virtual DbSet<ReportType> ReportTypes { get; set; } = null!;
        public virtual DbSet<Staff> Staffs { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<TypePolicy> TypePolicies { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
            return configuration.GetConnectionString("DbConnect");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(this.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Detail)
                    .HasMaxLength(1024)
                    .HasColumnName("detail");

                entity.Property(e => e.EndDate)
                    .HasPrecision(6)
                    .HasColumnName("end_date");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.StartDate)
                    .HasPrecision(6)
                    .HasColumnName("start_date");
            });

            modelBuilder.Entity<GenericTicket>(entity =>
            {
                entity.ToTable("generic_tickets");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasMaxLength(128)
                    .HasColumnName("area");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(1024)
                    .HasColumnName("description");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.ExpiredDateTime)
                    .HasPrecision(6)
                    .HasColumnName("expired_date_time");

                entity.Property(e => e.IsPaper).HasColumnName("is_paper");

                entity.Property(e => e.LinkEvent)
                    .HasMaxLength(512)
                    .HasColumnName("link_event");

                entity.Property(e => e.PolicyId).HasColumnName("policy_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SalePercent).HasColumnName("sale_percent");

                entity.Property(e => e.SellerId).HasColumnName("seller_id");

                entity.Property(e => e.TicketName)
                    .HasMaxLength(128)
                    .HasColumnName("ticket_name");
            });

            modelBuilder.Entity<Hashtag>(entity =>
            {
                entity.ToTable("hashtags");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<HashtagEvent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hashtag_event");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.HashtagId).HasColumnName("hashtag_id");
            });

            modelBuilder.Entity<OrderTicket>(entity =>
            {
                entity.HasKey(e => new { e.BuyerId, e.GenericTicketId, e.OrderNo })
                    .HasName("PK__order_ti__290C73AB510D0572");

                entity.ToTable("order_tickets");

                entity.Property(e => e.BuyerId).HasColumnName("buyer_id");

                entity.Property(e => e.GenericTicketId).HasColumnName("generic_ticket_id");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("order_no");

                entity.Property(e => e.IsAccepted).HasColumnName("is_accepted");

                entity.Property(e => e.IsCanceled).HasColumnName("is_canceled");

                entity.Property(e => e.Note)
                    .HasMaxLength(1024)
                    .HasColumnName("note");

                entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("payment_method");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.ToTable("policy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Fee).HasColumnName("fee");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.TypePolicyId).HasColumnName("type_policy_id");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => new { e.BuyerId, e.GenericTicketId })
                    .HasName("PK__rating__914A2F2A10F17185");

                entity.ToTable("rating");

                entity.Property(e => e.BuyerId).HasColumnName("buyer_id");

                entity.Property(e => e.GenericTicketId).HasColumnName("generic_ticket_id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Stars).HasColumnName("stars");
            });

            modelBuilder.Entity<ReportFraud>(entity =>
            {
                entity.ToTable("report_fraud");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccuserId).HasColumnName("accuser_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Proof).HasColumnName("proof");

                entity.Property(e => e.ReportProcess)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("report_process");

                entity.Property(e => e.ReportTypeId).HasColumnName("report_type_id");

                entity.Property(e => e.ReportedUserId).HasColumnName("reported_user_id");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            });

            modelBuilder.Entity<ReportType>(entity =>
            {
                entity.ToTable("report_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("staffs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Avatar).HasColumnName("avatar");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(128)
                    .HasColumnName("firstname");

                entity.Property(e => e.IsEnable).HasColumnName("is_enable");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(128)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Revenue).HasColumnName("revenue");

                entity.Property(e => e.RoleCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_code");

                entity.Property(e => e.StaffCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("staff_code");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("tickets");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BoughtDate)
                    .HasPrecision(6)
                    .HasColumnName("bought_date");

                entity.Property(e => e.BuyerId).HasColumnName("buyer_id");

                entity.Property(e => e.GenericTicketId).HasColumnName("generic_ticket_id");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.IsBought).HasColumnName("is_bought");

                entity.Property(e => e.IsChecked).HasColumnName("is_checked");

                entity.Property(e => e.IsValid).HasColumnName("is_valid");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Process)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("process");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.TicketSerial)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("ticket_serial");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transaction");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.IsDone).HasColumnName("is_done");

                entity.Property(e => e.TransDate)
                    .HasPrecision(6)
                    .HasColumnName("trans_date");

                entity.Property(e => e.TransType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("trans_type");

                entity.Property(e => e.TransactionNo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("transaction_no");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<TypePolicy>(entity =>
            {
                entity.ToTable("type_policy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Avatar).HasColumnName("avatar");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("customer_code");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(128)
                    .HasColumnName("firstname");

                entity.Property(e => e.IsEnable).HasColumnName("is_enable");

                entity.Property(e => e.IsSeller).HasColumnName("is_seller");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(128)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Revenue).HasColumnName("revenue");

                entity.Property(e => e.RoleCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_code");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
