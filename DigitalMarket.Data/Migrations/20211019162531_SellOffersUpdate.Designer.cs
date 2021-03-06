// <auto-generated />
using System;
using DigitalMarket.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DigitalMarket.Data.Migrations
{
    [DbContext(typeof(DigitalMarketDbContext))]
    [Migration("20211019162531_SellOffersUpdate")]
    partial class SellOffersUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalCollection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AvailableAtMarket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("DigitalCollections");
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("DigitalCollectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DigitalRarityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DropChance")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarketName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DigitalCollectionId");

                    b.HasIndex("DigitalRarityId");

                    b.ToTable("DigitalItems");
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalItemInstance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OwnerId");

                    b.ToTable("DigitalItemInstances");
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalRarity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DigitalRarities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("710bb39a-f836-4999-b509-99676ffc36dd"),
                            Name = "Common"
                        },
                        new
                        {
                            Id = new Guid("ff8be82e-97e1-4543-a37f-b4e857deb6b2"),
                            Name = "Rare"
                        },
                        new
                        {
                            Id = new Guid("4b15b9b2-c742-4860-acf4-08b5fb9e2a19"),
                            Name = "Super Rare"
                        },
                        new
                        {
                            Id = new Guid("8a86db3c-2c1f-4028-8b9d-9e6a4dba12c9"),
                            Name = "Epic"
                        },
                        new
                        {
                            Id = new Guid("5cf32c72-960a-4367-852a-8b3388be1e85"),
                            Name = "Legendary"
                        });
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3ff4ea20-1adb-4141-a296-7b5ec330d144"),
                            ConcurrencyStamp = "a5544add-900f-4893-886d-ece723901a4e",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("33802147-520f-4178-84f1-6ae66243b45e"),
                            ConcurrencyStamp = "bf55ce82-0601-4c0e-b3ce-ca689527854a",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalSellOffer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InstanceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InstanceId")
                        .IsUnique();

                    b.ToTable("DigitalSellOffers");
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FromUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InstanceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("ToUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("InstanceId");

                    b.HasIndex("ToUserId");

                    b.ToTable("DigitalTransactions");
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalItem", b =>
                {
                    b.HasOne("DigitalMarket.Data.Models.DigitalCollection", "DigitalCollection")
                        .WithMany("DigitalItems")
                        .HasForeignKey("DigitalCollectionId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DigitalMarket.Data.Models.DigitalRarity", "DigitalRarity")
                        .WithMany("DigitalItems")
                        .HasForeignKey("DigitalRarityId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("DigitalCollection");

                    b.Navigation("DigitalRarity");
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalItemInstance", b =>
                {
                    b.HasOne("DigitalMarket.Data.Models.DigitalItem", "DigitalItem")
                        .WithMany("ItemInstances")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DigitalMarket.Data.Models.DigitalUser", "Owner")
                        .WithMany("ItemInstances")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("DigitalItem");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalSellOffer", b =>
                {
                    b.HasOne("DigitalMarket.Data.Models.DigitalItemInstance", "ItemInstance")
                        .WithOne("DigitalSellOffer")
                        .HasForeignKey("DigitalMarket.Data.Models.DigitalSellOffer", "InstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemInstance");
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalTransaction", b =>
                {
                    b.HasOne("DigitalMarket.Data.Models.DigitalUser", "FromUser")
                        .WithMany("OutputTransactions")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DigitalMarket.Data.Models.DigitalItemInstance", "ItemInstance")
                        .WithMany("Transactions")
                        .HasForeignKey("InstanceId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DigitalMarket.Data.Models.DigitalUser", "ToUser")
                        .WithMany("InputTransactions")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("FromUser");

                    b.Navigation("ItemInstance");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("DigitalMarket.Data.Models.DigitalRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("DigitalMarket.Data.Models.DigitalUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("DigitalMarket.Data.Models.DigitalUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("DigitalMarket.Data.Models.DigitalRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalMarket.Data.Models.DigitalUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("DigitalMarket.Data.Models.DigitalUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalCollection", b =>
                {
                    b.Navigation("DigitalItems");
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalItem", b =>
                {
                    b.Navigation("ItemInstances");
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalItemInstance", b =>
                {
                    b.Navigation("DigitalSellOffer");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalRarity", b =>
                {
                    b.Navigation("DigitalItems");
                });

            modelBuilder.Entity("DigitalMarket.Data.Models.DigitalUser", b =>
                {
                    b.Navigation("InputTransactions");

                    b.Navigation("ItemInstances");

                    b.Navigation("OutputTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
