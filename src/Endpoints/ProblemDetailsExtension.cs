﻿using Flunt.Notifications;

namespace iOrderApp.Endpoints
{
    public static class ProblemDetailsExtension
    {
        public static Dictionary<string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications)
        {
            return notifications
                .GroupBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());
        }
    }
}
