using System.ServiceModel;

namespace Articles.ReadSide.WCF
{
    [ServiceContract]
    public interface IArticlesService
    {
        [OperationContract]
        string Get();
    }
}
