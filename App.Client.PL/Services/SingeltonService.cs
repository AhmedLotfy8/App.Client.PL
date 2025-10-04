
namespace App.Client.PL.Services {
    public class SingeltonService : ISingeltonService {
        public SingeltonService() {
            guid = Guid.NewGuid();
        }

        public Guid guid { get; set; }

        public string GetGuid() {

            return guid.ToString();

        }
    }
}
