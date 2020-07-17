namespace MusicaVirtual2020.Datos
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly MusicaDbContext _dbContext;

        public UnitOfWork(MusicaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
