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

