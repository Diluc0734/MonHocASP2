using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DuAnLamQuen
{
    public partial class ThongTinCaNhan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //code khoi tao du lieu cho cac dieu khien
            if (!Page.IsPostBack)
            {
                //khoi tao cho ddlTrinhDo
                ddlTrinhDo.Items.Add(new ListItem("Hạ cấp"));
                ddlTrinhDo.Items.Add(new ListItem("Trung cấp"));
                ddlTrinhDo.Items.Add(new ListItem("Cao đẳng"));
                ddlTrinhDo.Items.Add(new ListItem("Thượng đẳng"));


                //khoi tao cho lstNgheNghiep
                lstNgheNghiep.Items.Add(new ListItem("Công nhân"));
                lstNgheNghiep.Items.Add(new ListItem("Lập trình viên"));
                lstNgheNghiep.Items.Add(new ListItem("Kỹ sư cầu đường"));
                lstNgheNghiep.Items.Add(new ListItem("Tiếp viên hàng không"));
                lstNgheNghiep.Items.Add(new ListItem("Streamer"));
                lstNgheNghiep.Items.Add(new ListItem("Only Fan"));


                //khoi tao cho chkListSoThich
                chkListSoThich.Items.Add(new ListItem("Đọc sách"));
                chkListSoThich.Items.Add(new ListItem("Xem phim"));
                chkListSoThich.Items.Add(new ListItem("Du lịch"));
                chkListSoThich.Items.Add(new ListItem("Đi Phượt"));
                chkListSoThich.Items.Add(new ListItem("Đi Cafe"));


            }

        }
        protected void btGui_Click(object sender, EventArgs e)
        {
            string kq = "";
            
            kq += "<h2>Thông tin đăng ký của bạn </h2>";
            kq += "<ul>";
            
            kq += $"<li>Họ tên {txtHoTen.Text}</li>";
            
            kq += string.Format("<li> Ngày Sinh:{0}</li>", txtNgaySinh.Text);
            if (rdNam.Checked)
            {
                kq += $"<li> Giới tính {rdNam.Text} </li>";
            }
            else
            {
                kq += $"<li> Giới tính {rdNu.Text} </li>";
            }
            kq += $"<li>Trình độ {ddlTrinhDo.SelectedItem.Text}</li>";
            kq += $"<li>Nghề nghiệp {lstNgheNghiep.SelectedItem.Text}</li>";
            
            if (FHinh.HasFile)
            {
                
                string path = Server.MapPath("~/uploads");
                
                FHinh.SaveAs(path + "/" + FHinh.FileName);
                kq += $"<li>Ảnh : <img src='Uploads/{FHinh.FileName}'> </li>";
            }

            string sothich = "";
            foreach (ListItem x in chkListSoThich.Items)
            {
                if (x.Selected)
                {
                    sothich += x.Text + ";";
                }
            }

            kq += $"<li>Sở thích: {sothich}</li>";

            kq += "<ul>";

            
            lbKetQua.Text = kq;
        }
    }
}