using Blog.Application.Common.Models;

namespace Blog.Application.Common.Interfaces;

public interface IEmailService
{
    Task SendAsync(EmailRequest request);
}