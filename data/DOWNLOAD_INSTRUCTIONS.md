Public Software Data - Download & Usage Instructions

Files included on branch `add-software-csvs`:

- data/os_software_list.csv
- data/os_software_list.xls  (Excel-compatible HTML)
- data/public_user_software_list.csv
- data/public_user_software_list.xls (Excel-compatible HTML)
- data/public_user_software_list_10000.csv  (10,000-row CSV with placeholders)

Download the branch as a ZIP (contains all files above):
https://github.com/rsmohane/grt.automation.net/archive/refs/heads/add-software-csvs.zip

How to open the CSV files in Excel (Windows / macOS):
1. Download the CSV file(s) from the branch (direct raw links are provided in the repository).  
   Example raw URL for the 10k file:
   https://raw.githubusercontent.com/rsmohane/grt.automation.net/add-software-csvs/data/public_user_software_list_10000.csv

2. Open Excel → File → Open → Browse to the downloaded CSV file. 
   - On import, choose UTF-8 encoding and comma as delimiter. 
   - Verify columns: Software Name, Official Download Link, Affiliate Search Key, Category, Latest Version, License Link, Notes.

3. Save as Excel Workbook: File → Save As → select Excel Workbook (.xlsx) to get a native .xlsx file.

Notes and important limitations:
- The 10,000-row CSV contains many placeholder values (Latest Version = "TBD", License Link = vendor page or "TBD", Affiliate Search Key = short query). I populated high-priority entries with real links and left placeholders for the remainder to make the file complete and ready for automated enrichment or manual review.
- Fully verifying and populating fields (Latest Version, License Link, affiliate program URLs) for 10,000 items is a large research task. I can perform this in batches (example plan below).
- Excel-compatible .xls files included are HTML representations that Excel can open. They are provided for convenience but for large datasets CSV → .xlsx is recommended.

Recommended next steps (pick any):
- I can convert the 10,000-row CSV into a set of .xlsx files (split by category) and commit them. This avoids single-sheet size issues and makes browsing easier.
- I can enrich the file in prioritized batches (for example: top 1,000 by popularity or category). Provide priority rules and I’ll run automated lookups + manual verification.
- I can replace Affiliate Search Keys with actual affiliate/tracking URLs if you provide affiliate IDs or specify the affiliate network(s) to use.

Estimated work/time for full enrichment (rough):
- Convert CSV → multiple .xlsx (split into 10 files by category): ~10–30 minutes.
- Automated metadata enrichment for 1,000 items (Latest Version + License link): ~2–6 hours (depends on rate-limiting and manual checks).
- Full enrichment for 10,000 items (reasonable accuracy): multiple days (2–5 days) of scripted + manual verification.

If you want me to proceed now with a specific next action, reply with one of these choices:
- "Convert to .xlsx and split by category" (specify split size or # of files)
- "Enrich top N entries" (specify N and priority rule: popularity/category/alphabetical)
- "Add affiliate URLs" (provide affiliate IDs or network)
- "Create Google Sheets and share" (provide Google account/email for sharing)

If you just want the ZIP now, download it here:
https://github.com/rsmohane/grt.automation.net/archive/refs/heads/add-software-csvs.zip

Thank you — tell me which next step to take and I’ll proceed.