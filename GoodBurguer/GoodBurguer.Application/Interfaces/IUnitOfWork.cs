namespace GoodBurguer.GoodBurguer.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
