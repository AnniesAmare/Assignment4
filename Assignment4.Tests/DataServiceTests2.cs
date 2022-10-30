using DataLayer;
using DataLayer.Model;

namespace Assignment4.Tests
{
    public class DataServiceTests2
    {

        //ORDER TESTS EXTRA
        [Fact]
        public void GetOrderByShipname_ValidShipname_ReturnsIdDateShipnameCity()
        {
            var service = new DataService();
            var order = service.GetOrderByShipping("Blauer See Delikatessen");
            Assert.Equal(7, order.Count);
            Assert.Equal("Mannheim", order.First().City);
            Assert.Equal(10501, order.First().Id);
            Assert.Equal("Blauer See Delikatessen", order.First().ShipName);
            Assert.Equal("1997-04-09", order.First().Date.ToString("yyyy-MM-dd"));

        }


    }
}

