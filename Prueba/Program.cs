using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

class Program
{
    static void Main(string[] args)
    {
        // Ruta donde se guardará el PDF
        string pdfPath = "reporte.pdf";

        // Crear un documento PDF
        using (var writer = new PdfWriter(pdfPath))
        {
            using (var pdf = new PdfDocument(writer))
            {
                var document = new Document(pdf);

                // Añadir un párrafo
                document.Add(new Paragraph("Hola, este es un documento PDF generado con iText 8!"));

                // Puedes agregar más contenido aquí

                document.Close();
            }
        }

        Console.WriteLine($"PDF creado en: {pdfPath}");
    }
}
