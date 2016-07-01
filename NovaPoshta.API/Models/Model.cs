using NovaPoshta.API.Messages;

namespace NovaPoshta.API.Models
{
    public abstract class Model
    {
        protected Client client;

        public abstract string ModelName
        {
            get;
        }
    }
}
