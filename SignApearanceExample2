using iText.Bouncycastle.Crypto;
using iText.Bouncycastle.X509;
using iText.Commons.Bouncycastle.Cert;
using iText.Commons.Bouncycastle.Crypto;
using iText.Forms.Form.Element;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Signatures;
using Org.BouncyCastle.Pkcs;

namespace example
{

    public class SignApearanceExample2
    {
        private const string CertPath = "YOUR_CERTIFICATE_PATH";

        public static void Main(string[] args)
        {
            SignWithImageAppearance("SignedResult.pdf", "result_Signed_IMG_Appearance.pdf");
        }

        private static void SignWithImageAppearance(string src, string dest)
        {
            var pdfSigner = new PdfSigner(new PdfReader(src), new FileStream(dest, FileMode.Create),
                new StampingProperties());
            pdfSigner.SetCertificationLevel(PdfSigner.CERTIFIED_NO_CHANGES_ALLOWED);

            //Set the name indicating the field to be signed. 
            //The field can already be present in the document but most not be signed. 
            pdfSigner.SetFieldName("signature");

            var clientSignatureImage = ImageDataFactory.Create("image.png");

            var signatureAppearance = new SignatureFieldAppearance(pdfSigner.GetFieldName())
                .SetContent(clientSignatureImage);
            pdfSigner.SetPageNumber(1)
                .SetPageRect(new Rectangle(100, 100,
                    25, 15))
                .SetSignatureAppearance(signatureAppearance);

            var password = "password".ToCharArray();
            IExternalSignature pks = GetPrivateKeySignature(CertPath, password);
            var chain = GetCertificateChain(CertPath, password);
            var ocspVerifier = new OCSPVerifier(null, null);
            var ocspClient = new OcspClientBouncyCastle(ocspVerifier);
            var crlClients = new List<ICrlClient>(new[] { new CrlClientOnline() });

            // Sign the document using the detached mode, CMS or CAdES equivalent. 
            pdfSigner.SignDetached(pks, chain, crlClients, ocspClient, null, 0,
                PdfSigner.CryptoStandard.CMS);
        }

        private static PrivateKeySignature GetPrivateKeySignature(string certificatePath, char[] password)
        {
            string? alias = null;
            var pk12 = new Pkcs12StoreBuilder().Build();
            pk12.Load(new FileStream(certificatePath, FileMode.Open, FileAccess.Read), password);

            foreach (var a in pk12.Aliases)
            {
                alias = ((string)a);
                if (pk12.IsKeyEntry(alias))
                {
                    break;
                }
            }

            IPrivateKey pk = new PrivateKeyBC(pk12.GetKey(alias).Key);
            return new PrivateKeySignature(pk, DigestAlgorithms.SHA512);
        }

        private static IX509Certificate[] GetCertificateChain(string certificatePath, char[] password)
        {
            string? alias = null;
            var pk12 = new Pkcs12StoreBuilder().Build();
            pk12.Load(new FileStream(certificatePath, FileMode.Open, FileAccess.Read), password);

            foreach (var a in pk12.Aliases)
            {
                alias = ((string)a);
                if (pk12.IsKeyEntry(alias))
                {
                    break;
                }
            }

            X509CertificateEntry[] ce = pk12.GetCertificateChain(alias);
            var chain = new IX509Certificate[ce.Length];
            for (var k = 0; k < ce.Length; ++k)
            {
                chain[k] = new X509CertificateBC(ce[k].Certificate);
            }

            return chain;
        }
    }
}
