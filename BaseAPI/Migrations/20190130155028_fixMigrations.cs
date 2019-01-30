using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseAPI.Migrations
{
    public partial class fixMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseAccounts",
                columns: table => new
                {
                    name = table.Column<string>(nullable: true),
                    dbIncrease = table.Column<bool>(nullable: false),
                    isIncrease = table.Column<bool>(nullable: false),
                    amount = table.Column<float>(nullable: false),
                    balance = table.Column<float>(nullable: false),
                    BaseAccountId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseAccounts", x => x.BaseAccountId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientName = table.Column<string>(nullable: true),
                    VatNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "DefaultTypes",
                columns: table => new
                {
                    DefaultTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultTypes", x => x.DefaultTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    EmployeeRoleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.EmployeeRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    MaidenName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    AlternativeNumber = table.Column<string>(nullable: true),
                    PhysicalAddress = table.Column<string>(nullable: true),
                    PostalAddress = table.Column<string>(nullable: true),
                    SAID = table.Column<string>(nullable: true),
                    PassportNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    AccessCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "ExternalSuppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Tell = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalSuppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatuses",
                columns: table => new
                {
                    ProjectStatusId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Stage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatuses", x => x.ProjectStatusId);
                });

            migrationBuilder.CreateTable(
                name: "MainAccounts",
                columns: table => new
                {
                    name = table.Column<string>(nullable: true),
                    dbIncrease = table.Column<bool>(nullable: false),
                    isIncrease = table.Column<bool>(nullable: false),
                    amount = table.Column<float>(nullable: false),
                    balance = table.Column<float>(nullable: false),
                    mainAccountId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BaseAccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainAccounts", x => x.mainAccountId);
                    table.ForeignKey(
                        name: "FK_MainAccounts_BaseAccounts_BaseAccountId",
                        column: x => x.BaseAccountId,
                        principalTable: "BaseAccounts",
                        principalColumn: "BaseAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientContactInfos",
                columns: table => new
                {
                    ClientContactInfoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cell = table.Column<string>(nullable: true),
                    Tell = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AccessCode = table.Column<string>(nullable: true),
                    AcquisitionNumber = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContactInfos", x => x.ClientContactInfoId);
                    table.ForeignKey(
                        name: "FK_ClientContactInfos_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Facility = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ClientsId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                    table.ForeignKey(
                        name: "FK_Quotes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAccounts",
                columns: table => new
                {
                    EmployeeAccountsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BankName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    BranchCode = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAccounts", x => x.EmployeeAccountsId);
                    table.ForeignKey(
                        name: "FK_EmployeeAccounts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeKins",
                columns: table => new
                {
                    EmployeeKinId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    MaidenName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    AlternativeNumber = table.Column<string>(nullable: true),
                    PhysicalAddress = table.Column<string>(nullable: true),
                    PostalAddress = table.Column<string>(nullable: true),
                    SAID = table.Column<string>(nullable: true),
                    PassportNumber = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeKins", x => x.EmployeeKinId);
                    table.ForeignKey(
                        name: "FK_EmployeeKins_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalQuotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    Discount = table.Column<double>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalQuotes", x => x.QuoteId);
                    table.ForeignKey(
                        name: "FK_ExternalQuotes_ExternalSuppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "ExternalSuppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalSupplierAccounts",
                columns: table => new
                {
                    SupplierAccountId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    BankAccount = table.Column<string>(nullable: true),
                    BranchCode = table.Column<string>(nullable: true),
                    SupplierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalSupplierAccounts", x => x.SupplierAccountId);
                    table.ForeignKey(
                        name: "FK_ExternalSupplierAccounts_ExternalSuppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "ExternalSuppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    name = table.Column<string>(nullable: true),
                    dbIncrease = table.Column<bool>(nullable: false),
                    isIncrease = table.Column<bool>(nullable: false),
                    amount = table.Column<float>(nullable: false),
                    balance = table.Column<float>(nullable: false),
                    AccountsId = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    isDebtor = table.Column<bool>(nullable: false),
                    isCreditor = table.Column<bool>(nullable: false),
                    isBank = table.Column<bool>(nullable: false),
                    mainAccountId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountsId);
                    table.ForeignKey(
                        name: "FK_Accounts_MainAccounts_mainAccountId",
                        column: x => x.mainAccountId,
                        principalTable: "MainAccounts",
                        principalColumn: "mainAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    dateTime = table.Column<DateTime>(nullable: false),
                    amount = table.Column<float>(nullable: false),
                    increase = table.Column<bool>(nullable: false),
                    mainAccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_MainAccounts_mainAccountId",
                        column: x => x.mainAccountId,
                        principalTable: "MainAccounts",
                        principalColumn: "mainAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientFeedbacks",
                columns: table => new
                {
                    ClientFeedbackId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    VoiceNotePath = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    TimelineId = table.Column<int>(nullable: true),
                    ClientContactInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFeedbacks", x => x.ClientFeedbackId);
                    table.ForeignKey(
                        name: "FK_ClientFeedbacks_ClientContactInfos_ClientContactInfoId",
                        column: x => x.ClientContactInfoId,
                        principalTable: "ClientContactInfos",
                        principalColumn: "ClientContactInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostEstimates",
                columns: table => new
                {
                    CostEstimateId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostEstimates", x => x.CostEstimateId);
                    table.ForeignKey(
                        name: "FK_CostEstimates_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostEstimates_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFiles",
                columns: table => new
                {
                    ProjectFileId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FilePath = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    ClientContactInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFiles", x => x.ProjectFileId);
                    table.ForeignKey(
                        name: "FK_ProjectFiles_ClientContactInfos_ClientContactInfoId",
                        column: x => x.ClientContactInfoId,
                        principalTable: "ClientContactInfos",
                        principalColumn: "ClientContactInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectFiles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectFiles_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timelines",
                columns: table => new
                {
                    TimelineId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Stage = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OverallTimeline = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Extension = table.Column<DateTime>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    ProjectStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timelines", x => x.TimelineId);
                    table.ForeignKey(
                        name: "FK_Timelines_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timelines_ProjectStatuses_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "ProjectStatuses",
                        principalColumn: "ProjectStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuoteItems",
                columns: table => new
                {
                    QuoteItemsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    Vat = table.Column<double>(nullable: false),
                    QuoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteItems", x => x.QuoteItemsId);
                    table.ForeignKey(
                        name: "FK_QuoteItems_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalQuoteItems",
                columns: table => new
                {
                    QuoteItemsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Vat = table.Column<double>(nullable: false),
                    QuoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalQuoteItems", x => x.QuoteItemsId);
                    table.ForeignKey(
                        name: "FK_ExternalQuoteItems_ExternalQuotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "ExternalQuotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackComments",
                columns: table => new
                {
                    FeedbackCommentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientFeedbackId = table.Column<int>(nullable: false),
                    ClientContactInfoId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackComments", x => x.FeedbackCommentId);
                    table.ForeignKey(
                        name: "FK_FeedbackComments_ClientContactInfos_ClientContactInfoId",
                        column: x => x.ClientContactInfoId,
                        principalTable: "ClientContactInfos",
                        principalColumn: "ClientContactInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FeedbackComments_ClientFeedbacks_ClientFeedbackId",
                        column: x => x.ClientFeedbackId,
                        principalTable: "ClientFeedbacks",
                        principalColumn: "ClientFeedbackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedbackComments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostEstimateItems",
                columns: table => new
                {
                    CostEstimateItemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MaterialPrice = table.Column<double>(nullable: false),
                    MaterialPercentage = table.Column<double>(nullable: false),
                    LabourPrice = table.Column<double>(nullable: false),
                    LabourPercentage = table.Column<double>(nullable: false),
                    EquipmentPrice = table.Column<double>(nullable: false),
                    EquipmentPercentage = table.Column<double>(nullable: false),
                    CostEstimateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostEstimateItems", x => x.CostEstimateItemId);
                    table.ForeignKey(
                        name: "FK_CostEstimateItems_CostEstimates_CostEstimateId",
                        column: x => x.CostEstimateId,
                        principalTable: "CostEstimates",
                        principalColumn: "CostEstimateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTimeline",
                columns: table => new
                {
                    EmployeeTimelineId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: true),
                    TimelineId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    EmployeeRoleId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTimeline", x => x.EmployeeTimelineId);
                    table.ForeignKey(
                        name: "FK_EmployeeTimeline_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeTimeline_EmployeeRoles_EmployeeRoleId",
                        column: x => x.EmployeeRoleId,
                        principalTable: "EmployeeRoles",
                        principalColumn: "EmployeeRoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeTimeline_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeTimeline_Timelines_TimelineId",
                        column: x => x.TimelineId,
                        principalTable: "Timelines",
                        principalColumn: "TimelineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContents",
                columns: table => new
                {
                    ProjectContentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImagePath = table.Column<string>(nullable: true),
                    VoiceNotePath = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    TimelineId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    ClientContactInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContents", x => x.ProjectContentId);
                    table.ForeignKey(
                        name: "FK_ProjectContents_ClientContactInfos_ClientContactInfoId",
                        column: x => x.ClientContactInfoId,
                        principalTable: "ClientContactInfos",
                        principalColumn: "ClientContactInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectContents_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectContents_Timelines_TimelineId",
                        column: x => x.TimelineId,
                        principalTable: "Timelines",
                        principalColumn: "TimelineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Defaults",
                columns: table => new
                {
                    DefaultId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ProjectContentId = table.Column<int>(nullable: false),
                    DefaultTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defaults", x => x.DefaultId);
                    table.ForeignKey(
                        name: "FK_Defaults_DefaultTypes_DefaultTypeId",
                        column: x => x.DefaultTypeId,
                        principalTable: "DefaultTypes",
                        principalColumn: "DefaultTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Defaults_ProjectContents_ProjectContentId",
                        column: x => x.ProjectContentId,
                        principalTable: "ProjectContents",
                        principalColumn: "ProjectContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    InvoiceItemsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    Vat = table.Column<double>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    DefaultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.InvoiceItemsId);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Defaults_DefaultId",
                        column: x => x.DefaultId,
                        principalTable: "Defaults",
                        principalColumn: "DefaultId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_mainAccountId",
                table: "Accounts",
                column: "mainAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContactInfos_ClientId",
                table: "ClientContactInfos",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFeedbacks_ClientContactInfoId",
                table: "ClientFeedbacks",
                column: "ClientContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_CostEstimateItems_CostEstimateId",
                table: "CostEstimateItems",
                column: "CostEstimateId");

            migrationBuilder.CreateIndex(
                name: "IX_CostEstimates_EmployeeId",
                table: "CostEstimates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CostEstimates_ProjectId",
                table: "CostEstimates",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Defaults_DefaultTypeId",
                table: "Defaults",
                column: "DefaultTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Defaults_ProjectContentId",
                table: "Defaults",
                column: "ProjectContentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAccounts_EmployeeId",
                table: "EmployeeAccounts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeKins_EmployeeId",
                table: "EmployeeKins",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeline_EmployeeId",
                table: "EmployeeTimeline",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeline_EmployeeRoleId",
                table: "EmployeeTimeline",
                column: "EmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeline_ProjectId",
                table: "EmployeeTimeline",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeline_TimelineId",
                table: "EmployeeTimeline",
                column: "TimelineId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalQuoteItems_QuoteId",
                table: "ExternalQuoteItems",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalQuotes_SupplierId",
                table: "ExternalQuotes",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalSupplierAccounts_SupplierId",
                table: "ExternalSupplierAccounts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackComments_ClientContactInfoId",
                table: "FeedbackComments",
                column: "ClientContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackComments_ClientFeedbackId",
                table: "FeedbackComments",
                column: "ClientFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackComments_EmployeeId",
                table: "FeedbackComments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_DefaultId",
                table: "InvoiceItems",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAccounts_BaseAccountId",
                table: "MainAccounts",
                column: "BaseAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContents_ClientContactInfoId",
                table: "ProjectContents",
                column: "ClientContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContents_EmployeeId",
                table: "ProjectContents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContents_TimelineId",
                table: "ProjectContents",
                column: "TimelineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_ClientContactInfoId",
                table: "ProjectFiles",
                column: "ClientContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_EmployeeId",
                table: "ProjectFiles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_ProjectId",
                table: "ProjectFiles",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItems_QuoteId",
                table: "QuoteItems",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_ClientId",
                table: "Quotes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Timelines_ProjectId",
                table: "Timelines",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Timelines_ProjectStatusId",
                table: "Timelines",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_mainAccountId",
                table: "Transactions",
                column: "mainAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CostEstimateItems");

            migrationBuilder.DropTable(
                name: "EmployeeAccounts");

            migrationBuilder.DropTable(
                name: "EmployeeKins");

            migrationBuilder.DropTable(
                name: "EmployeeTimeline");

            migrationBuilder.DropTable(
                name: "ExternalQuoteItems");

            migrationBuilder.DropTable(
                name: "ExternalSupplierAccounts");

            migrationBuilder.DropTable(
                name: "FeedbackComments");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "ProjectFiles");

            migrationBuilder.DropTable(
                name: "QuoteItems");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "CostEstimates");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "ExternalQuotes");

            migrationBuilder.DropTable(
                name: "ClientFeedbacks");

            migrationBuilder.DropTable(
                name: "Defaults");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "MainAccounts");

            migrationBuilder.DropTable(
                name: "ExternalSuppliers");

            migrationBuilder.DropTable(
                name: "DefaultTypes");

            migrationBuilder.DropTable(
                name: "ProjectContents");

            migrationBuilder.DropTable(
                name: "BaseAccounts");

            migrationBuilder.DropTable(
                name: "ClientContactInfos");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Timelines");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectStatuses");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
