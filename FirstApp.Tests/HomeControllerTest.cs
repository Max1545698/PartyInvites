using System;
using Xunit;
using FirstApp.Controllers;
namespace FirstApp.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void SumCheck_2_Plus_3_Expected_5()
        {
            int a = 2;
            int b = 3;

            HomeController controller = new HomeController();
            int expected = controller.Sum(a, b);

            Assert.Equal(5, expected);
        }
    }
}
