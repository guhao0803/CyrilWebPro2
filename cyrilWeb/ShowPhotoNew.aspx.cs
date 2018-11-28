using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cyrilWeb
{
    public partial class ShowPhotoNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<String> listss = new List<string>();
            // 根目录虚拟路径
            string virtualPath = Page.Request.ApplicationPath;
            // 根目录绝对路径
            string pathRooted = HostingEnvironment.MapPath(virtualPath);

            FileInfo[] files = new DirectoryInfo(pathRooted + "Photos").GetFiles();
            List<FileInfo> list = new List<FileInfo>(files);
            list.Sort(new Comparison<FileInfo>(delegate (FileInfo a, FileInfo b)
            {
                return b.CreationTime.CompareTo(a.CreationTime);

            }));
            string html = "";
            int i = 0;
            foreach (FileInfo f in list)
            {
                i++;
                Console.WriteLine(f.Name + "," + f.CreationTime);
                html += "  <a href='Photos/" + f.Name + "'><div id='div" + i + "' runat='server' style='float: left; '><img id='img" + i + "' runat='server' src='Photos/" + f.Name + "' style='width: 99 %; height: 500px; ' /></div> </a>";// this.img1.Src = "Photos/" + f.Name;

            }
            this.form1.InnerHtml = html;

        }
    }
}