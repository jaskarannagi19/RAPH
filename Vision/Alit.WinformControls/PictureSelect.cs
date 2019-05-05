using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alit.WinformControls
{
    [ToolboxItem(true)]
    public partial class PictureSelect : UserControl
    {
        public Image SelectedImage
        {
            get
            {
                return (pictureEdit1 != null ? pictureEdit1.Image : null);
            }
            set
            {
                if (pictureEdit1 != null)
                {
                    pictureEdit1.Image = value;
                    ImageChanged = true;
                }
            }
        }

        private string ImageFileName_;

        public string ImageFileName
        {
            get
            {
                return ImageFileName_;
            }
            set
            {
                if (ImageFileName_ != value)
                {
                    ImageFileName_ = value;

                    ImageFileNameChange?.Invoke(this, null);
                }
            }
        }

        public bool ImageChanged { get; set; }

        public event EventHandler ImageFileNameChange;

        public PictureSelect()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(ofd.FileName))
                {
                    ImageFileName = ofd.FileName;
                    try
                    {
                        SelectedImage = Image.FromFile(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Selected image was not loaded/shown. " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            SelectedImage = null;
            ImageFileName = string.Empty;
        }
    }
}
