using FlightLib; // Tu librería de vuelos
using iText.IO.Font; // Para StandardFonts
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout; 
using iText.Layout.Element;
using iText.Layout.Properties; // UnitValue, TextAlignment
using System;
using System.IO;

namespace PDFManage
{
    public class Manage
    {
        // Ahora la librería recibe la ruta donde guardar el PDF (no usa diálogos)
        public static void GenerarDocumento(FlightPlanList fp, int cicles, double securityDistance, string filePath)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("filePath no puede estar vacío.", nameof(filePath));

                var folder = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                // Intentar crear/abrir el archivo con un FileStream exclusivo.
                // Esto evita problemas cuando otro proceso tiene el archivo abierto.
                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                using (var writer = new PdfWriter(fs))
                using (var pdf = new PdfDocument(writer))
                using (var document = new Document(pdf))
                {
                    // 1. Título
                    var titulo = new Paragraph("Flight Data")
                        .SetFontSize(24)
                        .SetTextAlignment(TextAlignment.CENTER);

                    document.Add(titulo);
                    document.Add(new Paragraph("\n"));

                    // 2. Info general
                    var parrafo = new Paragraph("Este es un pdf con la información sobre los vuelos.");
                    document.Add(parrafo);
                    var fecha = new Paragraph($"Fecha de creación: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    document.Add(fecha);
                    document.Add(new Paragraph("\n"));

                    // 3. Tabla de vuelos
                    int numFlights = fp?.GetNumeroFlightPlans() ?? 0;
                    Table table = new Table(new float[] { 2, 3, 2, 3, 3, 3 });
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    table.AddHeaderCell(new Cell().Add(new Paragraph("ID")));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Company")));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Speed")));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Current Position")));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Initial Position")));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Final Position")));

                    for (int i = 0; i < numFlights; i++)
                    {
                        FlightPlan plan = fp.GetFlightPlan(i);

                        if (plan == null)
                        {
                            table.AddCell("-"); table.AddCell("-"); table.AddCell("-");
                            table.AddCell("-"); table.AddCell("-"); table.AddCell("-");
                            continue;
                        }

                        string id = plan.GetId() ?? "";
                        string company = plan.GetCompany() ?? "";
                        string speed = plan.GetSpeed().ToString("F2");

                        var pos = plan.GetPosition();
                        var init = plan.GetInitialPosition();
                        var fin = plan.GetFinalPosition();

                        string posStr = pos != null ? $"({pos.GetX():F2}, {pos.GetY():F2})" : "-";
                        string initStr = init != null ? $"({init.GetX():F2}, {init.GetY():F2})" : "-";
                        string finStr = fin != null ? $"({fin.GetX():F2}, {fin.GetY():F2})" : "-";

                        table.AddCell(new Cell().Add(new Paragraph(id)));
                        table.AddCell(new Cell().Add(new Paragraph(company)));
                        table.AddCell(new Cell().Add(new Paragraph(speed)));
                        table.AddCell(new Cell().Add(new Paragraph(posStr)));
                        table.AddCell(new Cell().Add(new Paragraph(initStr)));
                        table.AddCell(new Cell().Add(new Paragraph(finStr)));
                    }

                    document.Add(table);

                    // 4. Resumen final
                    var resumen = new Paragraph($"Cycles: {cicles}    Security distance: {securityDistance:F2}")
                        .SetMarginTop(12)
                        .SetTextAlignment(TextAlignment.LEFT);

                    document.Add(resumen);

                    // No llames a pdf.Close(); using se encarga de todo.
                }

                // Si quieres notificar desde la librería, devuelve la ruta o deja que el llamador lo haga.
            }
            catch (Exception ex)
            {
                // Incluye información útil para depuración
                var msg = $"Error al generar PDF: {ex.GetType().Name}: {ex.Message}\nStackTrace:\n{ex.StackTrace}";
                if (ex.InnerException != null)
                    msg += $"\nInner: {ex.InnerException.GetType().Name}: {ex.InnerException.Message}";

                // Rethrow con información (el UI lo mostrará)
                throw new InvalidOperationException(msg, ex);
            }
        }
    }
}