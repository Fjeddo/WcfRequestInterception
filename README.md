# log4net CorrelationId in WCF
It all starts in the .svc markup file, with Factory="TheService.DaCode.MyFactory".
Then take it from the MyFactory and all the way down to the MyOperationInvoker.