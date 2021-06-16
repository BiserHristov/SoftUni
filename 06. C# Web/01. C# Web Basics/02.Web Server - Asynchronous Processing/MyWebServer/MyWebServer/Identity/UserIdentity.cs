namespace MyWebServer.Identity
{
    public class UserIdentity
    {
        public string Id { get; set; }
        public bool IsAuthenticated => this.Id != null;
    }
}
