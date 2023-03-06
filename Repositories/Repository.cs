using Control_Stock.DbContexts;

namespace Control_Stock.Repositories
{
    public class Repository : IRepository
    {
        internal readonly StockContext _stockContext;
        public Repository(StockContext bolsaTrabajoContext)
        {
            _stockContext = bolsaTrabajoContext;
        }

        public bool SaveChange()
        {
            return _stockContext.SaveChanges() >= 0;
        }
    }
}
