namespace App.Client.PL.Services {
    public interface ISingeltonService {
        public Guid guid { get; set; }

        string GetGuid();

    }
}
