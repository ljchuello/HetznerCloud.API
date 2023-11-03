using HetznerCloudApi.Client;

namespace HetznerCloudApi
{
    public class HetznerCloudClient
    {
        public string Token { get; private set; }

        public HetznerCloudClient(string token)
        {
            Token = token;

            Action = new ActionClient(token);
            Datacenter = new DatacenterClient(token);
            Image = new ImageClient(token);
            Location = new LocationClient(token);
            ServerType = new ServerTypeClient(token);
            Volume = new VolumeClient(token);
            VolumeAction = new VolumeActionClient(token);
        }

        public ActionClient Action { get; private set; }
        public DatacenterClient Datacenter { get; private set; }
        public ImageClient Image { get; private set; }
        public LocationClient Location { get; private set; }
        public ServerTypeClient ServerType { get; private set; }
        public VolumeClient Volume { get; private set; }
        public VolumeActionClient VolumeAction { get; private set; }
    }
}
