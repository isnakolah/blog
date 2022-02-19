namespace Common.Application.Common.Interfaces;

public interface IEmailService
{
    Task SendAsync(EmailRequest request);
}