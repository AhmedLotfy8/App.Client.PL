
namespace App.Client.PL.Services {
    public class TransentService : ITransentService {
        public TransentService() {
            guid = Guid.NewGuid();
        }

        public Guid guid { get; set; }

        public string GetGuid() {

            return guid.ToString();

        }
    
    }
}
