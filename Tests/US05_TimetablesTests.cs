using BlekingetrafikenTests.Pages;

namespace BlekingetrafikenTests.Tests
{
    [TestFixture]
    [Category("Timetables")]
    [Description("Tests for US5: Timetables feature")]
    public class US05_TimetablesTests : BaseTest
    {
        private TimetablesPage _timetablesPage = null!;

        [SetUp]
        public void TestSetup()
        {
            _timetablesPage = new TimetablesPage(Driver);
            _timetablesPage.Open();
        }

        [Test]
        [Description("Verify that the timetables page heading is 'Tidtabeller'")]
        public void Timetables_ShouldDisplayCorrectHeading()
        {
            // Act
            string heading = _timetablesPage.GetMainHeading();

            // Assert
            Assert.That(heading, Does.Contain("Tidtabeller"),
                "The page heading should be 'Tidtabeller'");
        }

        [Test]
        [Description("Verify that the timetables page has timetable links or sub-sections")]
        public void Timetables_ShouldHaveTimetableLinks()
        {
            // Act
            bool hasLinks = _timetablesPage.HasTimetableLinks();

            // Assert
            Assert.That(hasLinks, Is.True,
                "The timetables page should have timetable links or section headings");
        }
    }
}
