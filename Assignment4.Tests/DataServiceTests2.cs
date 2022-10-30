using DataLayer.Model;

namespace Assignment4.Tests
{
    public class DataServiceTests2
    {

        //ORDER TESTS EXTRA
        [Fact]
        public void Category_Object_HasIdNameAndDescription()
        {
            var category = new Category();
            Assert.Equal(0, category.Id);
            Assert.Null(category.Name);
            Assert.Null(category.Description);
        }


    }
}

