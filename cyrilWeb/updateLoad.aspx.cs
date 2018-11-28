using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cyrilWeb
{
    public partial class updateLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            //获取上传的文件名
            string fileName = this.FileUpload1.FileName;
            //获取物理路径
            String path = Server.MapPath("~/Photos/");
            //判断上传控件是否上传文件
            if (FileUpload1.HasFile)
            {
                //判断上传文件的扩展名是否为允许的扩展名".gif", ".png", ".jpeg", ".jpg" ,".bmp"
                String fileExtension = System.IO.Path.GetExtension(fileName).ToLower();
                String[] Extensions = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" };
                for (int i = 0; i < Extensions.Length; i++)
                {
                    if (fileExtension == Extensions[i])
                    {
                        fileOK = true;
                    }
                }
            }
            //如果上传文件扩展名为允许的扩展名，则将文件保存在服务器上指定的目录中
            if (fileOK)
            {
                try
                {
                    this.FileUpload1.PostedFile.SaveAs(path + fileName);
                    MessageBox("文件上传完毕");
                }
                catch (Exception ex)
                {
                    MessageBox("文件不能上传，原因：" + ex.Message);
                }
            }
            else
            {
                MessageBox("不能上传这种类型的文件");
            }

        }

        protected void MessageBox(string str)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str + "');</script>");
        }
    }
}