using NovaPoshta.API.Entities;
using NovaPoshta.API.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovaPoshta.API.Models
{
    public class AddressModel : Model
    {
        public override string ModelName
        {
            get { return "Address"; }
        }

        public async Task<List<City>> GetCitiesAsync(string searchString = null)
        {
            var request = new Request()
            {
                modelName = ModelName,
                calledMethod = "getCities"


                //                "methodProperties": {
                //                "FindByString": "Бровари"
                //}
            };

            return await Client.RequestAsync<City>(request);
        }






    }
}
