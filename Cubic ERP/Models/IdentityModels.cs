using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Cubic_ERP.Areas.Finance.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Cubic_ERP.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Currencies> DbCurrencies { get; set; }
        public DbSet<CashFlowHeading> CashFlowHeadings { get; set; }
        public DbSet<AgeingSlab> AgeingSlabs { get; set; }
        public DbSet<AccountMaster> AccountMasters { get; set; }
        public DbSet<CashFlowSetup> CashFlowSetups { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<PaymentCard> PaymentCards { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}