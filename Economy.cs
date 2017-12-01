using ICities;

namespace CS_Profitable_Offices
{
    public class Economy : EconomyExtensionBase
    {
        public override int OnAddResource(EconomyResource resource, int amount, Service service, SubService subService, Level level)
        {
            if (service == Service.Office)
            {
                // Altering the return amount appears to not only update the office zone income but also adds to private income as well
                
                var newAmount = amount * ModOptions.Instance.OfficeIncomeMultiplier;

                return newAmount;
            }

            return amount;
        }
    }
}