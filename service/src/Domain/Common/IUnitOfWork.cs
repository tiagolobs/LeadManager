namespace Domain.Common
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}