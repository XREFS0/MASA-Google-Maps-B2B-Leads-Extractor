# MASA Google Maps & Bing Maps B2B Leads Extractor

<div align="center">

![MASA Extractor Logo](logo.jpg)

**High-Performance B2B Lead Generation & Multi-Platform Maps Scraping Suite**

[![Platform](https://img.shields.io/badge/Platform-Windows-0078D6?style=for-the-badge&logo=windows)](https://github.com/XREFS0/MASA-Google-Maps-B2B-Leads-Extractor)
[![Framework](https://img.shields.io/badge/Framework-.NET%20Framework%204.8-512BD4?style=for-the-badge&logo=dotnet)](https://github.com/XREFS0/MASA-Google-Maps-B2B-Leads-Extractor)
[![Language](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp)](https://github.com/XREFS0/MASA-Google-Maps-B2B-Leads-Extractor)
[![License](https://img.shields.io/badge/License-MIT-green.style?style=for-the-badge)](LICENSE)

</div>

---

## Overview

**MASA Google Maps B2B Leads Extractor** is a desktop application engineered for business data extraction, contact mining, and B2B lead generation from Google Maps and Bing Maps.

Designed for digital marketers, sales teams, and data analysts, it automates search queries across categories and geographic regions, captures comprehensive business profiles, and executes deep web/email mining to discover actionable B2B contacts.

---

## Screenshots

<div align="center">

![Application Interface](docs/screenshot.jpg)

</div>

---

## Key Features

- **Dual Engine Scraping**: High-speed extraction from both Google Maps and Bing Maps.
- **Deep Web & Email Mining**: Automatically traverses company websites and social profiles to extract business emails, phone numbers, and social links.
- **Targeted Campaign Management**:
  - Custom location hierarchies (Countries, States/Regions, Cities, Zip Codes).
  - Multi-category batch extraction.
- **Multi-Format Export**:
  - Native Microsoft Excel (.xlsx) export via COM Interop.
  - CSV / TXT structured formats.
  - Direct sync with MySQL Database.
- **Proxy & Anti-Detection Support**: Built-in HTTP proxy rotation and automated browser management.
- **Auto-Restart & Recovery**: Fault-tolerant architecture with automated process recovery and session resume.
- **Multi-Language Interface**: Pre-configured support for English, French, German, Italian, and Spanish.
- **Krypton UI**: Rich, customizable, and responsive WinForms interface powered by Krypton Toolkit.

---

## Extracted Data Points

| Field | Description |
| :--- | :--- |
| **Business Name** | Official registered or listing name |
| **Category / Industry** | Primary and secondary business categories |
| **Phone Number** | Local and international contact numbers |
| **Address** | Street, City, State, Postal Code, Country |
| **Website** | Direct official website URL |
| **Emails** | Extracted from business listing and deep web crawling |
| **Social Links** | Facebook, LinkedIn, Twitter, Instagram |
| **Rating & Reviews** | Average star rating and total review counts |
| **Geo Coordinates** | Latitude & Longitude coordinates |
| **Operating Hours** | Business opening & closing schedules |

---

## Tech Stack & Architecture

- **Language**: C# (.NET Framework 4.8)
- **UI Framework**: Windows Forms with Krypton Suite Toolkit
- **Data & Storage**: MySQL Connector, JSON.NET, Excel Interop
- **Automation / Web Engine**: EO.WebBrowser / Embedded Chromium Engine, WebDriver, AngleSharp
- **Security & Integrity**: AES Crypto Providers, Safe Stream Encryption

---

## Getting Started

### Prerequisites

- Windows 10 / 11 or Windows Server 2016+
- [.NET Framework 4.8 Runtime or Developer Pack](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- Visual Studio 2019 / 2022 (with *.NET desktop development* workload)

### Building from Source

1. **Clone the repository:**
   ```bash
   git clone https://github.com/XREFS0/MASA-Google-Maps-B2B-Leads-Extractor.git
   cd MASA-Google-Maps-B2B-Leads-Extractor
   ```

2. **Open Solution:**
   - Launch `MASAGooGLExtractor.sln` in Visual Studio.

3. **Restore & Build:**
   - Ensure required reference assemblies or NuGet packages are restored.
   - Build Solution (`Ctrl + Shift + B`) in **Release** or **Debug** mode.

---

## Project Structure

```
MASA-Google-Maps-B2B-Leads-Extractor/
│
├── MASAGooGLExtractor.sln         # Visual Studio Solution
├── MASAGooGLExtractor/            # Main Application Project
│   ├── MASAGooGLExtractor/        # Core business scrapers & workers
│   │   ├── MASAGooGLExtractorGoogleMapsScraper.cs
│   │   ├── MASAGooGLExtractorBingMapsScraper.cs
│   │   ├── MASAGooGLExtractorWebMiner.cs
│   │   └── MASAGooGLExtractorEmailMiner.cs
│   ├── Microsoft/Office/Interop/  # Excel Export Interop Layer
│   ├── languages/                 # Localization files (EN, FR, GE, IT, SP)
│   ├── MASAGooGLExtractor.csproj  # Project Definition
│   └── app.config                 # App configurations
├── docs/                          # Documentation assets & screenshots
├── .gitignore                     # Git ignore rules
├── LICENSE                        # MIT License
├── README.md                      # Project documentation
└── SECURITY.md                    # Security policy
```

---

## Disclaimer

This tool is intended for educational, research, and legitimate data aggregation purposes. Ensure compliance with Google's and Bing's Terms of Service and applicable local regulations (such as GDPR and CAN-SPAM) regarding data scraping and electronic communications.

---

## License

Distributed under the **MIT License**. See [`LICENSE`](LICENSE) for more information.