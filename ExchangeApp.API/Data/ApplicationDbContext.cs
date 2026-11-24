using System;
using System.Collections.Generic;
using ExchangeApp.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Attribute = ExchangeApp.API.Models.Entities.Attribute;

namespace ExchangeApp.API.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Advert> Adverts { get; set; }

    public virtual DbSet<Attribute> Attributes { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Categoryattribute> Categoryattributes { get; set; }

    public virtual DbSet<Dialog> Dialogs { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Offeritem> Offeritems { get; set; }

    public virtual DbSet<Offeritemphoto> Offeritemphotos { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Statusadvert> Statusadverts { get; set; }

    public virtual DbSet<Statusoffer> Statusoffers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advert>(entity =>
        {
            entity.HasKey(e => e.AdvertId).HasName("advert_pk");

            entity.ToTable("advert");

            entity.Property(e => e.AdvertId).HasColumnName("advert_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Condition)
                .HasMaxLength(50)
                .HasColumnName("condition");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DesiredItem)
                .HasMaxLength(100)
                .HasColumnName("desired_item");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Adverts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("advert_category_category_id_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.Adverts)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("advert_statusadvert_status_advert_id_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Adverts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("advert_user_user_id_fk");
        });

        modelBuilder.Entity<Attribute>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("attribute_pk");

            entity.ToTable("attribute");

            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("category_pk");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                .HasForeignKey(d => d.ParentCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("category_category_category_id_fk");
        });

        modelBuilder.Entity<Categoryattribute>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("categoryattribute");

            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");

            entity.HasOne(d => d.Attribute).WithMany()
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categoryattribute_attribute_attribute_id_fk");

            entity.HasOne(d => d.Category).WithMany()
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categoryattribute_category_category_id_fk");
        });

        modelBuilder.Entity<Dialog>(entity =>
        {
            entity.HasKey(e => e.DialogId).HasName("dialog_pk");

            entity.ToTable("dialog");

            entity.Property(e => e.DialogId).HasColumnName("dialog_id");
            entity.Property(e => e.AdvertId).HasColumnName("advert_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.InterestedUserId).HasColumnName("interested_user_id");

            entity.HasOne(d => d.Advert).WithMany(p => p.Dialogs)
                .HasForeignKey(d => d.AdvertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dialog_advert_advert_id_fk");

            entity.HasOne(d => d.InterestedUser).WithMany(p => p.Dialogs)
                .HasForeignKey(d => d.InterestedUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dialog_user_user_id_fk");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("message_pk");

            entity.ToTable("message");

            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.DialogId).HasColumnName("dialog_id");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.SentAt).HasColumnName("sent_at");
            entity.Property(e => e.TextMessage).HasColumnName("text_message");

            entity.HasOne(d => d.Dialog).WithMany(p => p.Messages)
                .HasForeignKey(d => d.DialogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("message_dialog_dialog_id_fk");

            entity.HasOne(d => d.Sender).WithMany(p => p.Messages)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("message_user_user_id_fk");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.OfferId).HasName("offer_pk");

            entity.ToTable("offer");

            entity.Property(e => e.OfferId).HasColumnName("offer_id");
            entity.Property(e => e.AdvertId).HasColumnName("advert_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Advert).WithMany(p => p.Offers)
                .HasForeignKey(d => d.AdvertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offer_advert_advert_id_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.Offers)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offer_statusoffer_status_offer_id_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Offers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offer_user_user_id_fk");
        });

        modelBuilder.Entity<Offeritem>(entity =>
        {
            entity.HasKey(e => e.OfferItemId).HasName("offeritem_pk");

            entity.ToTable("offeritem");

            entity.Property(e => e.OfferItemId).HasColumnName("offer_item_id");
            entity.Property(e => e.Condition)
                .HasMaxLength(50)
                .HasColumnName("condition");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.OfferId).HasColumnName("offer_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.Offer).WithMany(p => p.Offeritems)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offeritem_offer_offer_id_fk");
        });

        modelBuilder.Entity<Offeritemphoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("offeritemphoto_pk");

            entity.ToTable("offeritemphoto");

            entity.Property(e => e.PhotoId).HasColumnName("photo_id");
            entity.Property(e => e.OfferitemId).HasColumnName("offeritem_id");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");

            entity.HasOne(d => d.Offeritem).WithMany(p => p.Offeritemphotos)
                .HasForeignKey(d => d.OfferitemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offeritemphoto_offeritem_offer_item_id_fk");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("photo_pk");

            entity.ToTable("photo");

            entity.Property(e => e.PhotoId).HasColumnName("photo_id");
            entity.Property(e => e.AdvertId).HasColumnName("advert_id");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");

            entity.HasOne(d => d.Advert).WithMany(p => p.Photos)
                .HasForeignKey(d => d.AdvertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("photo_advert_advert_id_fk");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("review_pk");

            entity.ToTable("review");

            entity.Property(e => e.ReviewId).HasColumnName("review_id");
            entity.Property(e => e.AdvertId).HasColumnName("advert_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Advert).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.AdvertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("review_advert_advert_id_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("review_user_user_id_fk");
        });

        modelBuilder.Entity<Statusadvert>(entity =>
        {
            entity.HasKey(e => e.StatusAdvertId).HasName("statusadvert_pk");

            entity.ToTable("statusadvert");

            entity.Property(e => e.StatusAdvertId).HasColumnName("status_advert_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Statusoffer>(entity =>
        {
            entity.HasKey(e => e.StatusOfferId).HasName("statusoffer_pk");

            entity.ToTable("statusoffer");

            entity.Property(e => e.StatusOfferId).HasColumnName("status_offer_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_pk");

            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash)
                .HasColumnType("character varying")
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
