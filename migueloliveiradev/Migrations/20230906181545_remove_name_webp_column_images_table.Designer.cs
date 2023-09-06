﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using migueloliveiradev.Database;

#nullable disable

namespace migueloliveiradev.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230906181545_remove_name_webp_column_images_table")]
    partial class remove_name_webp_column_images_table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("asp_net_roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext")
                        .HasColumnName("claim_value");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_role_claims_role_id");

                    b.ToTable("asp_net_role_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_users");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("asp_net_users", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext")
                        .HasColumnName("claim_value");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_claims_user_id");

                    b.ToTable("asp_net_user_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext")
                        .HasColumnName("provider_display_name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_asp_net_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_logins_user_id");

                    b.ToTable("asp_net_user_logins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_asp_net_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_user_roles_role_id");

                    b.ToTable("asp_net_user_roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("longtext")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_asp_net_user_tokens");

                    b.ToTable("asp_net_user_tokens", (string)null);
                });

            modelBuilder.Entity("migueloliveiradev.Models.Me.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_about");

                    b.ToTable("about", (string)null);
                });

            modelBuilder.Entity("migueloliveiradev.Models.Me.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("message");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("send_date");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("subject");

                    b.HasKey("Id")
                        .HasName("pk_contacts");

                    b.ToTable("contacts", (string)null);
                });

            modelBuilder.Entity("migueloliveiradev.Models.Network.SocialNetwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("icon");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_social_networks");

                    b.ToTable("social_networks", (string)null);
                });

            modelBuilder.Entity("migueloliveiradev.Models.Works.Projetos.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("project_id");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_comments");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_comments_project_id");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("migueloliveiradev.Models.Works.Projetos.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int")
                        .HasColumnName("projeto_id");

                    b.HasKey("Id")
                        .HasName("pk_images");

                    b.HasIndex("ProjetoId")
                        .HasDatabaseName("ix_images_projeto_id");

                    b.ToTable("images", (string)null);
                });

            modelBuilder.Entity("migueloliveiradev.Models.Works.Projetos.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_end");

                    b.Property<DateTime?>("DateStart")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_start");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("descricao");

                    b.Property<string>("SubTitulo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("sub_titulo");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("titulo");

                    b.Property<string>("Url")
                        .HasColumnType("longtext")
                        .HasColumnName("url");

                    b.Property<string>("UrlGithub")
                        .HasColumnType("longtext")
                        .HasColumnName("url_github");

                    b.Property<string>("UrlLinkedin")
                        .HasColumnType("longtext")
                        .HasColumnName("url_linkedin");

                    b.Property<bool>("Working")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("working");

                    b.HasKey("Id")
                        .HasName("pk_projects");

                    b.ToTable("projects", (string)null);
                });

            modelBuilder.Entity("migueloliveiradev.Models.Works.Projetos.ProjectTechnology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("project_id");

                    b.Property<int>("TechnologyId")
                        .HasColumnType("int")
                        .HasColumnName("technology_id");

                    b.HasKey("Id")
                        .HasName("pk_project_technologies");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_project_technologies_project_id");

                    b.HasIndex("TechnologyId")
                        .HasDatabaseName("ix_project_technologies_technology_id");

                    b.ToTable("project_technologies", (string)null);
                });

            modelBuilder.Entity("migueloliveiradev.Models.Works.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("icon");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_services");

                    b.ToTable("services", (string)null);
                });

            modelBuilder.Entity("migueloliveiradev.Models.Works.Technology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("icon");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.Property<int>("TypeIcon")
                        .HasColumnType("int")
                        .HasColumnName("type_icon");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_technologies");

                    b.ToTable("technologies", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_role_claims_asp_net_roles_role_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_claims_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_logins_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_roles_role_id");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_tokens_asp_net_users_user_id");
                });

            modelBuilder.Entity("migueloliveiradev.Models.Works.Projetos.Comment", b =>
                {
                    b.HasOne("migueloliveiradev.Models.Works.Projetos.Project", "Project")
                        .WithMany("Comments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_comments_projects_project_id");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("migueloliveiradev.Models.Works.Projetos.Image", b =>
                {
                    b.HasOne("migueloliveiradev.Models.Works.Projetos.Project", "Projeto")
                        .WithMany("Images")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_images_projects_projeto_id");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("migueloliveiradev.Models.Works.Projetos.ProjectTechnology", b =>
                {
                    b.HasOne("migueloliveiradev.Models.Works.Projetos.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_project_technologies_projects_project_id");

                    b.HasOne("migueloliveiradev.Models.Works.Technology", "Technology")
                        .WithMany()
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_project_technologies_technologies_technology_id");

                    b.Navigation("Project");

                    b.Navigation("Technology");
                });

            modelBuilder.Entity("migueloliveiradev.Models.Works.Projetos.Project", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
