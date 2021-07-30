using DapperUnitOfWorkAndDapperExtensionsExample.Models;
using DapperUnitOfWorkAndDapperExtensionsExample.UnitsOfWork;


namespace DapperUnitOfWorkAndDapperExtensionsExample.Repositories
{
    public class NotificationRepository : BaseRepository<Notifications>, INotificationRepository
    {
        public NotificationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
