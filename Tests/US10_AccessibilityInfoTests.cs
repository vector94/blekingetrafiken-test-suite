using BlekingetrafikenTests.Pages;

namespace BlekingetrafikenTests.Tests
{
    [TestFixture]
    [Category("Accessibility")]
    [Description("Tests for US10: Accessibility Information feature")]
    public class US10_AccessibilityInfoTests : BaseTest
    {
        private AccessibilityPage _accessibilityPage = null!;

        [SetUp]
        public void TestSetup()
        {
            _accessibilityPage = new AccessibilityPage(Driver);
            _accessibilityPage.Open();
        }

        [Test]
        [Description("Verify that all three transport sections (Bus, Train, Ferry) are present")]
        public void Accessibility_ShouldHaveAllTransportSections()
        {
            // Act
            bool hasAll = _accessibilityPage.HasAllTransportSections();

            // Assert
            Assert.That(hasAll, Is.True,
                "All transport type sections (Buss, Tåg, Båt) should be present");
        }

        [Test]
        [Description("Verify that accessibility statement links are present")]
        public void Accessibility_ShouldHaveAccessibilityStatementLinks()
        {
            // Act
            bool hasLinks = _accessibilityPage.HasAccessibilityStatementLinks();

            // Assert
            Assert.That(hasLinks, Is.True,
                "Accessibility statement links should be present");
        }
    }
}
