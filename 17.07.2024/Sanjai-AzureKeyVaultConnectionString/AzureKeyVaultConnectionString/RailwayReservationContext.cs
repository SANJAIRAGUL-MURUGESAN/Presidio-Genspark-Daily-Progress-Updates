using Microsoft.EntityFrameworkCore;

namespace Sanjai_AzureKeyVaultConnectionString
{
    public class RailwayReservationContext: DbContext
    {
        public RailwayReservationContext(DbContextOptions options) : base(options)
        {

        }
    }

}