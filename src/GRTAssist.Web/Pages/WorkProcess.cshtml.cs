using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GRTAssist.Web.Pages
{
    public class WorkProcessModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Generate PDF
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text("GRTAssist Work Process")
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);

                            x.Item().Text("1. Project Setup").FontSize(24).Bold();
                            x.Item().Text("   - Initialize .NET solution with API and Web projects.");
                            x.Item().Text("   - Configure database and authentication.");

                            x.Item().Text("2. API Development").FontSize(24).Bold();
                            x.Item().Text("   - Create controllers for AI, Auth, Automation, etc.");
                            x.Item().Text("   - Implement JWT authentication.");
                            x.Item().Text("   - Add Swagger for documentation.");

                            x.Item().Text("3. Web Application").FontSize(24).Bold();
                            x.Item().Text("   - Build Razor Pages for Dashboard, Marketplace.");
                            x.Item().Text("   - Integrate with API for data.");
                            x.Item().Text("   - Add admin login functionality.");

                            x.Item().Text("4. Deployment").FontSize(24).Bold();
                            x.Item().Text("   - Publish to Hostinger.");
                            x.Item().Text("   - Upload APK to Google Play.");

                            x.Item().Text("5. Mobile App (Optional)").FontSize(24).Bold();
                            x.Item().Text("   - Use .NET MAUI for cross-platform APK.");
                            x.Item().Text("   - Consume API endpoints.");
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            });

            var stream = new MemoryStream();
            document.GeneratePdf(stream);
            stream.Position = 0;

            return File(stream, "application/pdf", "WorkProcess.pdf");
        }
    }
}