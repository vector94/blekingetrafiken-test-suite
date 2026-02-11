using BlekingetrafikenTests.Pages;

namespace BlekingetrafikenTests.Tests
{
    [TestFixture]
    [Category("TrafficInfo")]
    [Description("Tests for US3: Traffic Information feature")]
    public class US03_TrafficInfoTests : BaseTest
    {
        private TrafficInfoPage _trafficInfoPage = null!;

        [SetUp]
        public void TestSetup()
        {
            _trafficInfoPage = new TrafficInfoPage(Driver);
            _trafficInfoPage.Open();
        }

        [Test]
        [Description("Verify that the traffic info page has a link to Trafikverket for real-time rail status")]
        public void TrafficInfo_ShouldHaveTrafikverketLink()
        {
            // Act
            bool hasLink = _trafficInfoPage.HasTrafikverketLink();

            // Assert
            Assert.That(hasLink, Is.True,
                "The page should contain a link to Trafikverket for real-time rail traffic tracking");
        }

        [Test]
        [Description("Verify that the traffic info page contains disruption-related content")]
        public void TrafficInfo_ShouldContainDisruptionContent()
        {
            // Act
            bool hasContent = _trafficInfoPage.HasDisruptionContent();

            // Assert
            Assert.That(hasContent, Is.True,
                "The page should contain traffic/disruption-related keywords");
        }
    }
}
