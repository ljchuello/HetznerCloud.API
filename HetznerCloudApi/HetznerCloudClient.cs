using HetznerCloudApi.Client;

namespace HetznerCloudApi
{
    public class HetznerCloudClient
    {
        public string Token { get; private set; }

        public HetznerCloudClient(string token)
        {
            Token = token;

            Image = new ImageClient(token);
            Location = new LocationClient(token);
            ServerType = new ServerTypeClient(token);
        }

        public ImageClient Image { get; private set; }
        public LocationClient Location { get; private set; }
        public ServerTypeClient ServerType { get; private set; }
    }
}
