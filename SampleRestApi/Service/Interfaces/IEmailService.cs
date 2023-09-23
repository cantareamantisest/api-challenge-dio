using SampleRestApi.ViewModels;

namespace SampleRestApi.Service.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(EmailViewModel email);
    }
}