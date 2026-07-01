PR Draft: Enrich public user software list (top 1,000 entries)

Branch: add-software-csvs
Author: GitHub Copilot (on behalf of rsmohane)

Summary:
This pull request will add metadata enrichment for the public software lists maintained under data/. It includes:
- Enrichment of the top 1,000 public software entries: populated Latest Version and License Link where available.
- New incremental CSV files for each enrichment batch (data/public_user_software_list_part01_batch01.csv, ..._batch04.csv).
- Conversion of CSV parts to Excel-compatible .xls files and a ZIP containing the workbooks (optional step, see notes).
- Documentation: data/DOWNLOAD_INSTRUCTIONS.md and data/enrichment_log.txt (this file) record the process and instructions for reviewers.

Details:
- Columns enriched: Latest Version, License Link. Affiliate Search Key placeholders are left untouched unless affiliate IDs are provided.
- Batch processing: 250 entries per batch. Each batch is a separate commit for easier rollback.
- Verification: Automated lookups will be performed first; ambiguous or missing results will be flagged for manual review.

Files changed (expected):
- data/public_user_software_list_part01_batch01.csv (250 enriched rows)
- data/public_user_software_list_part01_batch02.csv (250 enriched rows)
- data/public_user_software_list_part01_batch03.csv (250 enriched rows)
- data/public_user_software_list_part01_batch04.csv (250 enriched rows)
- data/public_user_software_list_part01.csv (updated/merged)
- data/public_user_software_list_part02.csv ... part10.csv (if updated)
- Optional: data/public_user_software_list_part01.xlsx ... part10.xlsx and data/public_software_lists.zip
- data/enrichment_log.txt (process log)
- PR description will include a summary of methods and validation steps.

Review instructions for maintainers:
- Review a random sample of 20 rows from each batch for accuracy of Latest Version and License Link.
- Confirm Affiliate Search Key strategy before converting to tracked links.
- If everything looks good, merge the PR and I will continue with the next 1,000 rows.

Notes and disclaimers:
- Enriching 1,000 entries is estimated to take 2-6 hours. The PR will be updated incrementally as batches complete.
- Creating tracked affiliate links requires affiliate account IDs; we did not insert tracked links in this run.

Acknowledgements:
- This PR was prepared by GitHub Copilot on behalf of rsmohane. Please review carefully before merging.
