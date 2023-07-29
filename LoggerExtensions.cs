using System.Runtime.CompilerServices;

public  static partial class LoggerExtensions
{
    [LoggerMessage(EventId = 100, Level = LogLevel.Information,
	 Message = "{methodName}({lineNumber}) - Retrieved {Count} customers")]
    public static partial void ShowRetrievedCustomerCount(this ILogger logger, int count, 
	 [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0);

    [LoggerMessage(EventId = 404, Level = LogLevel.Information,
	 Message = "{methodName}({lineNumber}) - Customer {customerId} not found.")]
    public static partial void CustomerNotFound(this ILogger logger, string customerId, 
	 [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0);
    
    [LoggerMessage(EventId = 200, Level = LogLevel.Trace,
	 Message = "{methodName}({lineNumber}) - Retrieved customer {customerId}")]
    public static partial void RetrievedCustomer(this ILogger logger, string customerId, 
	 [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0);

    [LoggerMessage(EventId = 300, Level = LogLevel.Information,
	 Message = "{methodName}({lineNumber}) - Creating customer {customerId}")]
    public static partial void CreatingCustomer(this ILogger logger, string customerId, 
	 [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0);

    [LoggerMessage(EventId = 302, Level = LogLevel.Trace,
	 Message = "{methodName}({lineNumber}) - Created customer {customerId}")]
    public static partial void CreatedCustomer(this ILogger logger, string customerId, 
	 [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0);

    [LoggerMessage(EventId = 400, Level = LogLevel.Information,
	 Message = "{methodName}({lineNumber}) - Updating customer {customerId}")]
    public static partial void UpdatingCustomer(this ILogger logger, string customerId, 
	 [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0);

    [LoggerMessage(EventId = 402, Level = LogLevel.Trace,
	 Message = "{methodName}({lineNumber}) - Updated customer {customerId}")]
    public static partial void UpdatedCustomer(this ILogger logger, string customerId, 
	 [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0);

    [LoggerMessage(EventId = 500, Level = LogLevel.Information,
	 Message = "{methodName}({lineNumber}) - Deleting customer {customerId}")]
    public static partial void DeletingCustomer(this ILogger logger, string customerId, 
	 [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0);

    [LoggerMessage(EventId = 502, Level = LogLevel.Trace,
	 Message = "{methodName}({lineNumber}) - Deleted customer {customerId}")]
    public static partial void DeletedCustomer(this ILogger logger, string customerId, 
	 [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0);
}
