using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.External;
using BaseAPI.Models.Internal.Clients;
using BaseAPI.Models.Internal.Employees;
using BaseAPI.Models.Internal.Projects;
using BaseAPI.Models.Internal.Projects.CostEstimates;
using BaseAPI.Models.Internal.Projects.Defaults;
using BaseAPI.Models.Internal.Projects.Invoices;
using BaseAPI.Models.Internal.Projects.Quotes;
using Microsoft.EntityFrameworkCore;
using BaseAPI.Models.Internal.Credentials;
using BaseAPI.Models.Finance;
using BaseAPI.Models.Internal;


namespace BaseAPI.Models
{
    public class BaseApiContext : DbContext
    {
        public virtual DbSet<External.Quotes.Quote> ExternalQuotes { get; set; }
        public virtual DbSet<External.Quotes.QuoteItems> ExternalQuoteItems { get; set; }
        public virtual DbSet<External.Suppliers.Supplier> ExternalSuppliers { get; set; }
        public virtual DbSet<External.Suppliers.SupplierAccount> ExternalSupplierAccounts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientContactInfo> ClientContactInfos { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeAccounts> EmployeeAccounts { get; set; }
        public virtual DbSet<EmployeeKin> EmployeeKins { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Timeline> Timelines { get; set; }
        public virtual DbSet<CostEstimate> CostEstimates { get; set; }
        public virtual DbSet<CostEstimateItem> CostEstimateItems { get; set; }
        public virtual DbSet<Default> Defaults { get; set; }
        public virtual DbSet<DefaultType> DefaultTypes { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceItems> InvoiceItems { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<QuoteItems> QuoteItems { get; set; }
        // public virtual DbSet<EmployeeCredentials> EmployeeCredentials { get; set; }
        // public virtual DbSet<ClientCredentials> ClientCredentials { get; set; }
        public virtual DbSet<BaseAccount> BaseAccounts { get; set; }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<MainAccount> MainAccounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public virtual DbSet<EmployeeTimeline> EmployeeTimeline { get; set; }
        public virtual DbSet<ProjectContent> ProjectContents { get; set; }
        public virtual DbSet<ProjectFile> ProjectFiles { get; set; }
        public virtual DbSet<ClientFeedback> ClientFeedbacks { get; set; }
        public virtual DbSet<FeedbackComment> FeedbackComments { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public BaseApiContext(DbContextOptions<BaseApiContext> Options) : base(Options)
        { }
    }
}
