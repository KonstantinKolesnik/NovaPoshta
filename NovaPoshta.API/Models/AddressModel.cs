using NovaPoshta.API.Messages;

namespace NovaPoshta.API.Models
{
    public class AddressModel : Model
    {
        public override string ModelName
        {
            get { return "Address"; }
        }

        public Request GetCities()
        {
            return new Request()
            {
                modelName = ModelName,
                calledMethod = "getCities"

            };
        }
    }
}
