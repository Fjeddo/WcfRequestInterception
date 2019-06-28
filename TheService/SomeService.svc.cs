using System;
using log4net;

namespace TheService
{
    public class SomeService : ISomeService
    {
        public string GetData(int value)
        {
            var log = LogManager.GetLogger(GetType());
            log.Info("Hallo Welt!");

            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
