﻿using OnlineShop.Domain.Constants;

namespace OnlineMarket.Service.Common.Helpers;
public class TimeHelper
{
    public static DateTime GetCurrentServerTime()
    {
        var date = DateTime.UtcNow;
        return date.AddHours(TimeConstants.UTC);
    }
}
