# Public User Software List - Complete Data Package

## Download Instructions

This package contains the complete public user software list (10,000 entries) in multiple formats.

### Files Included

#### CSV Files (Raw Data)
- `public_user_software_list_10000.csv` — Master file with all 10,000 entries
- `public_user_software_list_part01.csv` through `public_user_software_list_part10.csv` — Split into 10 parts (1,000 rows each)

#### Excel Files (Spreadsheet Format)
- `public_user_software_list_part01.xls` through `public_user_software_list_part10.xls` — Excel-compatible HTML spreadsheets for each part
- `public_user_software_list_master.xls` — Consolidated master spreadsheet (all 10,000 rows)

#### Enrichment Status
- Rows 1–1,000: **Enriched** (License Link verified; Latest Version mostly TBD pending deeper lookups)
- Rows 1,001–10,000: **Base data** (ready for enrichment; will be updated as batches complete)

#### Documentation
- `enrichment_log.txt` — Process log and methodology
- `PR_DRAFT.md` — Pull request draft summarizing all changes
- `enrichment_schedule.csv` — Batch processing schedule and status

### Data Columns

1. **Software Name** — Official product name
2. **Official Download Link** — Direct vendor download URL
3. **Affiliate Search Key** — Affiliate network placeholder (will be replaced with tracked links or public partner pages upon request)
4. **Category** — Software type/category (Browser, IDE, Database, etc.)
5. **Latest Version** — Current release version (TBD = not yet enriched)
6. **License Link** — Vendor license/terms page URL
7. **Notes** — Brief description of the software

### How to Use

1. **Quick Start**: Open any `.xls` file directly in Microsoft Excel, Google Sheets, or LibreOffice Calc.
2. **Raw Data**: Import any `.csv` file into your database, spreadsheet, or data pipeline.
3. **Complete Master**: Use `public_user_software_list_master.xls` if you need all 10,000 rows in one file.

### Ongoing Enrichment

This data is being continuously enriched:
- New Latest Version values are being populated via automated lookups and manual verification.
- Affiliate Search Key placeholders can be replaced with tracked affiliate links (requires your affiliate IDs) or public partner/reseller pages (no tracking).
- Updated files will be pushed to this branch periodically. Check back for:
  - `public_user_software_list_part01_batch05.csv` and beyond (incremental enrichment commits)
  - New consolidated master files after each batch

### Next Steps

1. **Download**: Pull the branch or download the ZIP from GitHub.
2. **Review**: Open any `.xls` file to inspect the data.
3. **Integrate**: Use the CSV files in your workflow or application.
4. **Feedback**: Let me know if you want affiliate links replaced, additional metadata added, or categories reorganized.

### Support

For questions or custom enrichment requests:
- Review the enrichment schedule in `enrichment_schedule.csv` to see planned batch processing.
- Check the PR draft (`PR_DRAFT.md`) for details on methodology and data quality.
- All raw source files and logs are available in the `data/` directory.

---

**Last Updated**: 2026-07-01 15:25:00Z  
**Status**: Batch 5 (rows 1001–2000) in progress  
**Full Enrichment ETA**: ~2–5 days (9,000 remaining rows, 1,000-row increments)
