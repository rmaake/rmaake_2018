﻿// <auto-generated />
using System;
using BaseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaseAPI.Migrations
{
    [DbContext(typeof(BaseApiContext))]
    [Migration("20190129083212_feedback2")]
    partial class feedback2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BaseAPI.Models.External.Quotes.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<double?>("Discount");

                    b.Property<string>("ReferenceNumber");

                    b.Property<int>("SupplierId");

                    b.HasKey("QuoteId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ExternalQuotes");
                });

            modelBuilder.Entity("BaseAPI.Models.External.Quotes.QuoteItems", b =>
                {
                    b.Property<int>("QuoteItemsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("QuoteId");

                    b.Property<double>("Vat");

                    b.HasKey("QuoteItemsId");

                    b.HasIndex("QuoteId");

                    b.ToTable("ExternalQuoteItems");
                });

            modelBuilder.Entity("BaseAPI.Models.External.Suppliers.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Tell");

                    b.HasKey("SupplierId");

                    b.ToTable("ExternalSuppliers");
                });

            modelBuilder.Entity("BaseAPI.Models.External.Suppliers.SupplierAccount", b =>
                {
                    b.Property<int>("SupplierAccountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankAccount");

                    b.Property<string>("BankName");

                    b.Property<string>("BranchCode");

                    b.Property<string>("ReferenceNumber");

                    b.Property<int>("SupplierId");

                    b.HasKey("SupplierAccountId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ExternalSupplierAccounts");
                });

            modelBuilder.Entity("BaseAPI.Models.Finance.Accounts", b =>
                {
                    b.Property<long>("AccountsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<int>("SupplierId");

                    b.Property<float>("amount");

                    b.Property<float>("balance");

                    b.Property<bool>("dbIncrease");

                    b.Property<bool>("isBank");

                    b.Property<bool>("isCreditor");

                    b.Property<bool>("isDebtor");

                    b.Property<bool>("isIncrease");

                    b.Property<int>("mainAccountId");

                    b.Property<string>("name");

                    b.HasKey("AccountsId");

                    b.HasIndex("mainAccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BaseAPI.Models.Finance.BaseAccount", b =>
                {
                    b.Property<int>("BaseAccountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("amount");

                    b.Property<float>("balance");

                    b.Property<bool>("dbIncrease");

                    b.Property<bool>("isIncrease");

                    b.Property<string>("name");

                    b.HasKey("BaseAccountId");

                    b.ToTable("BaseAccounts");
                });

            modelBuilder.Entity("BaseAPI.Models.Finance.MainAccount", b =>
                {
                    b.Property<int>("mainAccountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseAccountId");

                    b.Property<float>("amount");

                    b.Property<float>("balance");

                    b.Property<bool>("dbIncrease");

                    b.Property<bool>("isIncrease");

                    b.Property<string>("name");

                    b.HasKey("mainAccountId");

                    b.HasIndex("BaseAccountId");

                    b.ToTable("MainAccounts");
                });

            modelBuilder.Entity("BaseAPI.Models.Finance.Transaction", b =>
                {
                    b.Property<long>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("amount");

                    b.Property<DateTime>("dateTime");

                    b.Property<string>("description");

                    b.Property<bool>("increase");

                    b.Property<int>("mainAccountId");

                    b.Property<string>("name");

                    b.HasKey("TransactionId");

                    b.HasIndex("mainAccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Clients.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ClientName");

                    b.Property<string>("VatNumber");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Clients.ClientContactInfo", b =>
                {
                    b.Property<int>("ClientContactInfoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessCode");

                    b.Property<string>("AcquisitionNumber");

                    b.Property<string>("Cell");

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("ImagePath");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Tell");

                    b.Property<string>("Username");

                    b.HasKey("ClientContactInfoId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientContactInfos");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Clients.ClientFeedback", b =>
                {
                    b.Property<int>("ClientFeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientContactInfoId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("ImagePath");

                    b.Property<int?>("TimelineId");

                    b.Property<string>("Title");

                    b.Property<string>("VoiceNotePath");

                    b.HasKey("ClientFeedbackId");

                    b.HasIndex("ClientContactInfoId");

                    b.ToTable("ClientFeedbacks");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Clients.FeedbackComment", b =>
                {
                    b.Property<int>("FeedbackCommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientContactInfoId");

                    b.Property<int>("ClientFeedbackId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("EmployeeId");

                    b.HasKey("FeedbackCommentId");

                    b.HasIndex("ClientContactInfoId");

                    b.HasIndex("ClientFeedbackId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("FeedbackComments");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Employees.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessCode");

                    b.Property<string>("AlternativeNumber");

                    b.Property<string>("ContactNumber");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("ImagePath");

                    b.Property<string>("LastName");

                    b.Property<string>("MaidenName");

                    b.Property<string>("PassportNumber");

                    b.Property<string>("Password");

                    b.Property<string>("PhysicalAddress");

                    b.Property<string>("PostalAddress");

                    b.Property<string>("SAID");

                    b.Property<string>("Username");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Employees.EmployeeAccounts", b =>
                {
                    b.Property<int>("EmployeeAccountsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber");

                    b.Property<string>("BankName");

                    b.Property<string>("BranchCode");

                    b.Property<int>("EmployeeId");

                    b.HasKey("EmployeeAccountsId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeAccounts");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Employees.EmployeeKin", b =>
                {
                    b.Property<int>("EmployeeKinId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlternativeNumber");

                    b.Property<string>("ContactNumber");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MaidenName");

                    b.Property<string>("PassportNumber");

                    b.Property<string>("PhysicalAddress");

                    b.Property<string>("PostalAddress");

                    b.Property<string>("SAID");

                    b.HasKey("EmployeeKinId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeKins");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.EmployeeTimeline", b =>
                {
                    b.Property<int>("EmployeeTimelineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId");

                    b.Property<int?>("ProjectId");

                    b.Property<int?>("TimelineId");

                    b.HasKey("EmployeeTimelineId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TimelineId");

                    b.ToTable("EmployeeTimeline");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.CostEstimates.CostEstimate", b =>
                {
                    b.Property<int>("CostEstimateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("ProjectId");

                    b.HasKey("CostEstimateId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("CostEstimates");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.CostEstimates.CostEstimateItem", b =>
                {
                    b.Property<int>("CostEstimateItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CostEstimateId");

                    b.Property<double>("EquipmentPercentage");

                    b.Property<double>("EquipmentPrice");

                    b.Property<double>("LabourPercentage");

                    b.Property<double>("LabourPrice");

                    b.Property<double>("MaterialPercentage");

                    b.Property<double>("MaterialPrice");

                    b.HasKey("CostEstimateItemId");

                    b.HasIndex("CostEstimateId");

                    b.ToTable("CostEstimateItems");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Defaults.Default", b =>
                {
                    b.Property<int>("DefaultId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int?>("DefaultTypeId");

                    b.Property<string>("Description");

                    b.Property<int>("ProjectContentId");

                    b.Property<string>("Title");

                    b.HasKey("DefaultId");

                    b.HasIndex("DefaultTypeId");

                    b.HasIndex("ProjectContentId");

                    b.ToTable("Defaults");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Defaults.DefaultType", b =>
                {
                    b.Property<int>("DefaultTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("DefaultTypeId");

                    b.ToTable("DefaultTypes");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Invoices.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("ProjectId");

                    b.HasKey("InvoiceId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Invoices.InvoiceItems", b =>
                {
                    b.Property<int>("InvoiceItemsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DefaultId");

                    b.Property<string>("Description");

                    b.Property<int>("InvoiceId");

                    b.Property<int>("Quantity");

                    b.Property<double>("Rate");

                    b.Property<double>("Vat");

                    b.HasKey("InvoiceItemsId");

                    b.HasIndex("DefaultId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Facility");

                    b.Property<string>("Title");

                    b.HasKey("ProjectId");

                    b.HasIndex("ClientId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.ProjectContent", b =>
                {
                    b.Property<int>("ProjectContentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientContactInfoId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("ImagePath");

                    b.Property<int>("TimelineId");

                    b.Property<string>("VoiceNotePath");

                    b.HasKey("ProjectContentId");

                    b.HasIndex("ClientContactInfoId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TimelineId");

                    b.ToTable("ProjectContents");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.ProjectFile", b =>
                {
                    b.Property<int>("ProjectFileId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientContactInfoId");

                    b.Property<string>("Description");

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("FilePath");

                    b.Property<int>("ProjectId");

                    b.HasKey("ProjectFileId");

                    b.HasIndex("ClientContactInfoId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectFiles");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.ProjectStatus", b =>
                {
                    b.Property<int>("ProjectStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Stage");

                    b.HasKey("ProjectStatusId");

                    b.ToTable("ProjectStatuses");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Quotes.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId");

                    b.Property<int>("ClientsId");

                    b.Property<string>("Description");

                    b.HasKey("QuoteId");

                    b.HasIndex("ClientId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Quotes.QuoteItems", b =>
                {
                    b.Property<int>("QuoteItemsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("Quantity");

                    b.Property<int>("QuoteId");

                    b.Property<double>("Rate");

                    b.Property<double>("Vat");

                    b.HasKey("QuoteItemsId");

                    b.HasIndex("QuoteId");

                    b.ToTable("QuoteItems");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Timeline", b =>
                {
                    b.Property<int>("TimelineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime?>("Extension");

                    b.Property<bool>("OverallTimeline");

                    b.Property<int>("ProjectId");

                    b.Property<int>("ProjectStatusId");

                    b.Property<string>("Stage");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("TimelineId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ProjectStatusId");

                    b.ToTable("Timelines");
                });

            modelBuilder.Entity("BaseAPI.Models.External.Quotes.Quote", b =>
                {
                    b.HasOne("BaseAPI.Models.External.Suppliers.Supplier", "Supplier")
                        .WithMany("Quotes")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.External.Quotes.QuoteItems", b =>
                {
                    b.HasOne("BaseAPI.Models.External.Quotes.Quote", "Quote")
                        .WithMany("QuoteItems")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.External.Suppliers.SupplierAccount", b =>
                {
                    b.HasOne("BaseAPI.Models.External.Suppliers.Supplier", "supplier")
                        .WithMany("SupplierAccounts")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Finance.Accounts", b =>
                {
                    b.HasOne("BaseAPI.Models.Finance.MainAccount")
                        .WithMany("accounts")
                        .HasForeignKey("mainAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Finance.MainAccount", b =>
                {
                    b.HasOne("BaseAPI.Models.Finance.BaseAccount")
                        .WithMany("accounts")
                        .HasForeignKey("BaseAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Finance.Transaction", b =>
                {
                    b.HasOne("BaseAPI.Models.Finance.MainAccount", "MainAccount")
                        .WithMany()
                        .HasForeignKey("mainAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Clients.ClientContactInfo", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Clients.Client", "Clients")
                        .WithMany("ClientContactInfo")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Clients.ClientFeedback", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Clients.ClientContactInfo", "Client")
                        .WithMany()
                        .HasForeignKey("ClientContactInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Clients.FeedbackComment", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Clients.ClientContactInfo", "Client")
                        .WithMany()
                        .HasForeignKey("ClientContactInfoId");

                    b.HasOne("BaseAPI.Models.Internal.Clients.ClientFeedback", "Feedback")
                        .WithMany("Comments")
                        .HasForeignKey("ClientFeedbackId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BaseAPI.Models.Internal.Employees.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Employees.EmployeeAccounts", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Employees.Employee", "Employee")
                        .WithMany("EmployeesAccounts")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Employees.EmployeeKin", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Employees.Employee", "Employee")
                        .WithMany("EmployeesKin")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.EmployeeTimeline", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Employees.Employee", "Employee")
                        .WithMany("EmployeeTimelines")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("BaseAPI.Models.Internal.Projects.Project", "Project")
                        .WithMany("EmployeeTimelines")
                        .HasForeignKey("ProjectId");

                    b.HasOne("BaseAPI.Models.Internal.Projects.Timeline", "Timeline")
                        .WithMany("EmployeeTimelines")
                        .HasForeignKey("TimelineId");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.CostEstimates.CostEstimate", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Employees.Employee", "Employee")
                        .WithMany("CostEstimate")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BaseAPI.Models.Internal.Projects.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.CostEstimates.CostEstimateItem", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Projects.CostEstimates.CostEstimate", "CostEstimate")
                        .WithMany("CostEstimateItems")
                        .HasForeignKey("CostEstimateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Defaults.Default", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Projects.Defaults.DefaultType")
                        .WithMany("Default")
                        .HasForeignKey("DefaultTypeId");

                    b.HasOne("BaseAPI.Models.Internal.Projects.ProjectContent", "ProjectContent")
                        .WithMany()
                        .HasForeignKey("ProjectContentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Invoices.Invoice", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Projects.Project", "Project")
                        .WithMany("Invoices")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Invoices.InvoiceItems", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Projects.Defaults.Default", "Default")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("DefaultId");

                    b.HasOne("BaseAPI.Models.Internal.Projects.Invoices.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Project", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Clients.Client", "Client")
                        .WithMany("Project")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.ProjectContent", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Clients.ClientContactInfo", "Client")
                        .WithMany()
                        .HasForeignKey("ClientContactInfoId");

                    b.HasOne("BaseAPI.Models.Internal.Employees.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("BaseAPI.Models.Internal.Projects.Timeline", "Timeline")
                        .WithMany()
                        .HasForeignKey("TimelineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.ProjectFile", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Clients.ClientContactInfo", "Client")
                        .WithMany()
                        .HasForeignKey("ClientContactInfoId");

                    b.HasOne("BaseAPI.Models.Internal.Employees.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("BaseAPI.Models.Internal.Projects.Project", "Project")
                        .WithMany("ProjectFiles")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Quotes.Quote", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Clients.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Quotes.QuoteItems", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Projects.Quotes.Quote", "Quote")
                        .WithMany("QuoteItems")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BaseAPI.Models.Internal.Projects.Timeline", b =>
                {
                    b.HasOne("BaseAPI.Models.Internal.Projects.Project", "Project")
                        .WithMany("Timelines")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BaseAPI.Models.Internal.Projects.ProjectStatus", "ProjectStatus")
                        .WithMany("Timelines")
                        .HasForeignKey("ProjectStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
