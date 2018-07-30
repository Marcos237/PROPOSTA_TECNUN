using Tecnun.Infra.Data.Interfaces;

namespace Tecnun.Applications.Service
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
           this._unitOfWork = unitOfWork;
        }

        public void BeginTransaction()
        {
            _unitOfWork.BeginTransaction();
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
