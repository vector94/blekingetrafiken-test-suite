using BlekingetrafikenTests.Pages;

namespace BlekingetrafikenTests.Tests
{
    [TestFixture]
    [Category("StopSearch")]
    [Description("Tests for US4: Stop Search feature")]
    public class US04_StopSearchTests : BaseTest
    {
        private StationsPage _stationsPage = null!;

        [SetUp]
        public void TestSetup()
        {
            _stationsPage = new StationsPage(Driver);
            _stationsPage.Open();
        }

        [Test]
        [Description("Verify that the stations page lists multiple stations")]
        public void Stations_ShouldListMultipleStations()
        {
            // Act
            int stationCount = _stationsPage.GetStationCount();

            // Assert
            Assert.That(stationCount, Is.GreaterThanOrEqualTo(3),
                "The stations page should list at least 3 stations");
        }

        [Test]
        [Description("Verify that known stations are displayed on the page")]
        [TestCase("Karlskrona")]
        [TestCase("Ronneby")]
        public void Stations_ShouldDisplayKnownStation(string stationName)
        {
            // Act
            bool isDisplayed = _stationsPage.IsStationDisplayed(stationName);

            // Assert
            Assert.That(isDisplayed, Is.True,
                $"Station '{stationName}' should be displayed on the stations page");
        }

        [Test]
        [Description("Verify that station details include transport type information")]
        public void Stations_ShouldShowTransportTypeInfo()
        {
            // Act
            bool hasInfo = _stationsPage.HasTransportTypeInfo();

            // Assert
            Assert.That(hasInfo, Is.True,
                "Station details should include transport type info (Tåg/Buss)");
        }
    }
}
