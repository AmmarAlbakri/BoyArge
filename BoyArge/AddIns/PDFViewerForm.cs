using DevExpress.XtraEditors;
using System;
using System.IO;

namespace BoyArge
{
    public partial class PDFViewerForm : XtraForm
    {
        public PDFViewerForm()
        {
            InitializeComponent();
        }

        public MemoryStream PdfStreamData { get; set; }

        private void PDFViewerForm_Load(object sender, EventArgs e)
        {
            if (PdfStreamData == null) return;

            pdfViewer1.DetachStreamAfterLoadComplete = true;

            pdfViewer1.LoadDocument(PdfStreamData);
        }
    }
}