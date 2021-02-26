using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoGallery
{
    public partial class Gallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {
           if(myFileUpload.HasFile)
            {
                if (myFileUpload.PostedFile.ContentType == "image/jpeg" || myFileUpload.PostedFile.ContentType == "image/png")
                {
                    if (Convert.ToInt64(myFileUpload.PostedFile.ContentLength) < 10000000000)
                    {
                        string photoFolder = Path.Combine(Server.MapPath("~/Photos/"), User.Identity.Name);
                        if (Directory.Exists(photoFolder))
                        {
                            DisplayUploadedPhotos(photoFolder);

                            string full_file_path = photoFolder + Path.GetFileNameWithoutExtension(myFileUpload.FileName) + Path.GetExtension(myFileUpload.FileName);
                            myFileUpload.SaveAs(full_file_path);
                            statusLabel.Text = "<font color='green'> File uploaded sucessfully";
                        }
                        else
                        {
                            Directory.CreateDirectory(photoFolder);
                        }

                    }
                    else
                    {
                        statusLabel.Text = "<font color='red'> File size too big";
                    }
                }
                else
                {
                    statusLabel.Text = "<font color='red'> Wrong type of file";

                }
            }
           else
            {
                statusLabel.Text = "<font color='red'>  No file has been selected";
            }

        }
        public void DisplayUploadedPhotos(string folder)
        {
            string[] allPhotoFiles = Directory.GetFiles(folder);
            IList<string> allPhotoPaths = new List<string>();
            string fileName;
            foreach (string f in allPhotoFiles)
            {
                fileName = Path.GetFileName(f);
                allPhotoPaths.Add("~/Photos/" + User.Identity.Name + "/" + fileName);
            }
            RepeaterUserPhoto.DataSource = allPhotoPaths;
            RepeaterUserPhoto.DataBind();
        }
    }
}