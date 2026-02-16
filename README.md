# Blekingetrafiken Automated GUI Test Suite

Automated GUI-based regression test suite for [Blekingetrafiken.se](https://www.blekingetrafiken.se) — the public transport website for Blekinge, Sweden.

## Technology Stack

- **Language:** C# (.NET 8.0)
- **Test Framework:** NUnit 3
- **Browser Automation:** Selenium WebDriver 4.40
- **Browser:** Google Chrome

## Prerequisites

1. **.NET 8.0 SDK** — [Download](https://dotnet.microsoft.com/download/dotnet/8.0)
2. **Google Chrome** — Latest version installed
3. **Internet connection** — Tests run against the live website

## How to Run

### Run all tests (single command):
```bash
dotnet test --settings .runsettings --logger "trx;LogFileName=TestResults.trx" --logger "console;verbosity=detailed"
```

### Run all tests (simple):
```bash
dotnet test
```

### Run tests by category (specific user story):
```bash
dotnet test --filter "Category=JourneyPlanning"
dotnet test --filter "Category=TicketInfo"
dotnet test --filter "Category=Navigation"
```

### View test results:
After running with `--settings .runsettings`, results are saved in `./TestResults/`.

## Project Structure

```
BlekingetrafikenTests/
├── Pages/          # Page Object Model classes (one per page)
├── Tests/          # Test classes (one per user story, US01-US10)
├── Utils/          # Shared utilities (driver setup, waits, config)
├── Report/         # LaTeX report source and PDF
├── .runsettings    # NUnit run configuration
└── BlekingetrafikenTests.csproj
```

## Test Architecture & Best Practices

- **Page Object Model (POM):** Each web page has a dedicated class encapsulating its locators and actions. Tests interact with page objects, not raw Selenium calls.
- **Base Classes:** `BasePage` and `BaseTest` eliminate code duplication for common operations.
- **Setup / Teardown:** Every test gets a fresh browser instance (`[SetUp]`) that is properly closed (`[TearDown]`), ensuring test isolation.
- **Explicit Waits:** `WaitHelper` uses WebDriverWait instead of Thread.Sleep for reliable, non-flaky element interaction.
- **Centralized Configuration:** All URLs are defined in `TestConfig.cs` — changing the base URL updates all tests.
- **Data-Driven Testing:** `[TestCase]` attributes parameterize tests (e.g., verifying each ticket type, station name).
- **Annotations:** Every test class and method has `[Description]` and `[Category]` attributes.

## User Stories Covered

| # | User Story | Test File | Tests |
|---|-----------|-----------|-------|
| US1 | Journey Planning | US01_JourneyPlanningTests.cs | 1 |
| US2 | Extended Journey Search | US02_JourneyResultsTests.cs | 2 |
| US3 | Traffic Information | US03_TrafficInfoTests.cs | 2 |
| US4 | Stop Search | US04_StopSearchTests.cs | 4 |
| US5 | Timetables | US05_TimetablesTests.cs | 2 |
| US6 | Ticket Information | US06_TicketInfoTests.cs | 5 |
| US7 | Zone Information | US07_ZoneInfoTests.cs | 2 |
| US8 | Customer Service | US08_CustomerServiceTests.cs | 2 |
| US9 | Navigation Menu | US09_NavigationTests.cs | 3 |
| US10 | Accessibility Info | US10_AccessibilityInfoTests.cs | 2 |
| | **Total** | **10 test files** | **25 tests** |
