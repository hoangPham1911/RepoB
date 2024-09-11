using iTextSharp.text;
using iTextSharp.text.pdf;

public class PdfSigner
{
    // ky so
    public static void InsertSignatureImage(string inputPdfPath, string outputPdfPath, string signatureImagePath)
    {
        // Đọc tài liệu PDF từ file input
        using (PdfReader pdfReader = new PdfReader(inputPdfPath))
        using (FileStream outputStream = new FileStream(outputPdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            using (PdfStamper pdfStamper = new PdfStamper(pdfReader, outputStream))
            {
                // Lấy số trang cuối cùng
                int lastPage = pdfReader.NumberOfPages;

                // Lấy trang cuối cùng để chèn ảnh chữ ký
                PdfContentByte pdfContentByte = pdfStamper.GetOverContent(lastPage);

                // Đọc ảnh chữ ký từ file
                Image signatureImage = Image.GetInstance(signatureImagePath);

                // Lấy kích thước của trang cuối cùng
                Rectangle pageSize = pdfReader.GetPageSize(lastPage);

                // Thiết lập vị trí và kích thước của ảnh chữ ký (ở góc dưới bên trái)
                float x = signatureImage.ScaledWidth - pageSize.Right + 10; // Cách lề phải 10 đơn vị
                float y = pageSize.Bottom + 10; // Cách lề dưới 10 đơn vị
                signatureImage.SetAbsolutePosition(x, y);
                signatureImage.ScaleToFit(100, 50);// Kích thước ảnh chữ ký

                // Chèn ảnh chữ ký vào tài liệu PDF
                pdfContentByte.AddImage(signatureImage);
                Console.ReadLine();
            }
        }
    }



    // ky so
    public static void Main(string[] args)
    {
        string inputPdfPath = "cv nhan su.pdf"; // Đường dẫn đến file PDF gốc
        string outputPdfPath = "output_signed.pdf"; // Đường dẫn đến file PDF sau khi chèn ảnh chữ ký và ký số
        string signatureImagePath = "sign.png"; // Đường dẫn đến file ảnh chữ ký

        InsertSignatureImage(inputPdfPath, outputPdfPath, signatureImagePath);
        Console.WriteLine("Chèn ảnh chữ ký và ký số PDF thành công.");

        // Step 2: Load PDF Document
        //string pdfFilePath = "cv nhan su.pdf";
        //PdfReader pdfReader = new PdfReader(pdfFilePath);

        //// Step 3: Load PFX Certificate
        //string pfxFilePath = "C:\\Users\\Public\\myPersonalCertificate.pfx";
        //string pfxPassword = "200990a@A";
        //Pkcs12Store pfxKeyStore = new Pkcs12Store(new FileStream(pfxFilePath, FileMode.Open, FileAccess.Read), pfxPassword.ToCharArray());

        //// Step 4: Initialize the PDF Stamper And Creating the Signature Appearance
        //PdfStamper pdfStamper = PdfStamper.CreateSignature(pdfReader, new FileStream("output_signed11.pdf", FileMode.Create), '\0', null, true);
        //PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;
        //signatureAppearance.Reason = "Digital Signature Reason";
        //signatureAppearance.Location = "Digital Signature Location";

        //// Set the signature appearance location (in points)
        //float x = 360;
        //float y = 130;
        //signatureAppearance.Acro6Layers = false;
        //signatureAppearance.Layer4Text = PdfSignatureAppearance.questionMark;
        //signatureAppearance.SetVisibleSignature(new iTextSharp.text.Rectangle(x, y, x + 150, y + 50), 1, "signature");

        //// Step 5: Sign the Document
        //string alias = pfxKeyStore.Aliases.Cast<string>().FirstOrDefault(entryAlias => pfxKeyStore.IsKeyEntry(entryAlias));

        //if (alias != null)
        //{
        //    ICipherParameters privateKey = pfxKeyStore.GetKey(alias).Key;
        //    IExternalSignature pks = new PrivateKeySignature(privateKey, DigestAlgorithms.SHA256);
        //    MakeSignature.SignDetached(signatureAppearance, pks, new Org.BouncyCastle.X509.X509Certificate[] { pfxKeyStore.GetCertificate(alias).Certificate }, null, null, null, 0, CryptoStandard.CMS);
        //}
        //else
        //{
        //    Console.WriteLine("Private key not found in the PFX certificate.");
        //}

        //// Step 6: Save the Signed PDF
        //pdfStamper.Close();

        //Console.WriteLine("PDF signed successfully!");


    }
}
