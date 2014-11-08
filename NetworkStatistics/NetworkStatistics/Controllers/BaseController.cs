namespace NetworkStatistics.Controllers
{
    using System.Web.Mvc;

    using NetworkStatistics.DAL;

    public class BaseController : Controller
    {
        public BaseController()
            : this(new NetworkStatisticsData())
        {
        }

        public BaseController(INetworkStatisticsData networkStatisticsData)
        {
            this.NetworkStatisticsData = networkStatisticsData;
        }

        protected INetworkStatisticsData NetworkStatisticsData { get; set; }

        //protected void ClearCache()
        //{
        //    foreach (System.Collections.DictionaryEntry entry in HttpContext.Cache)
        //    {
        //        HttpContext.Cache.Remove((string)entry.Key);
        //    }
        //}
    }
}