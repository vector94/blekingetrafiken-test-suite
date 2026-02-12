using BlekingetrafikenTests.Pages;

namespace BlekingetrafikenTests.Tests
{
    [TestFixture]
    [Category("ZoneInfo")]
    [Description("Tests for US7: Zone Information feature")]
    public class US07_ZoneInfoTests : BaseTest
    {
        private ZonesPage _zonesPage = null!;

        [SetUp]
        public void TestSetup()
        {
            _zonesPage = new ZonesPage(Driver);
            _zonesPage.Open();
        }

        [Test]
        [Description("Verify that the zones page has sub-section headings")]
        public void Zones_ShouldHaveSubSections()
        {
            // Act
            bool hasSections = _zonesPage.HasSubSections();

            // Assert
            Assert.That(hasSections, Is.True,
                "The zones page should have sub-section headings (h2/h3)");
        }

        [Test]
        [Description("Verify that the zones page has downloadable content (maps/PDFs)")]
        public void Zones_ShouldHaveDownloadableContent()
        {
            // Act
            bool hasDownloads = _zonesPage.HasDownloadableContent();

            // Assert
            Assert.That(hasDownloads, Is.True,
                "The zones page should have downloadable content (zone map PDF or images)");
        }
    }
}
