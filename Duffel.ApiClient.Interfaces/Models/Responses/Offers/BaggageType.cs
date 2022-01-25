using System.Runtime.Serialization;

namespace Duffel.ApiClient.Interfaces.Models.Responses.Offers
{
    public enum BaggageType
    {
        Checked,
        
        [EnumMember(Value = "carry_on")]
        CarryOn
    }
}