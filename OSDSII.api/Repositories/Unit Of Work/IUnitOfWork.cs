namespace OSDSII.api.Repositories.Unit_Of_Work
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}
