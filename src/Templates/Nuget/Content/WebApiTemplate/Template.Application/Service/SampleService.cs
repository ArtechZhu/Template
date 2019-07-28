using Template.IApplication;
using Template.IApplication.DTO;

namespace Template.Application.Service
{
    public class SampleService : ISampleService
    {
        #region Implementation of ISampleService

        public SampleDTO GetOne()
        {
            return new SampleDTO { Version = "1.0.0" };
        }

        #endregion
    }
}
