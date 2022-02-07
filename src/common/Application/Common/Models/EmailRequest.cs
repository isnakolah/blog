namespace Blog.Application.Common.Models;

public sealed record EmailRequest(string FromMail, string FromDisplayName, List<string> ToMail, string Subject, string Body,
    bool IsHtml = true);
