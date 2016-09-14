using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Text;
using System.ComponentModel;

namespace GreetingCardWebApp
{
    public partial class CE_82_v2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // Set color options.
                string[] colorArray = Enum.GetNames(typeof(KnownColor));
                lstBackColor.DataSource = colorArray;
                lstBackColor.DataBind();
                // Set font options.
                InstalledFontCollection fonts = new InstalledFontCollection();
                foreach (FontFamily family in fonts.Families)
                {
                    lstFontName.Items.Add(family.Name);
                }
                // Set border style options by adding a series of
                // ListItem objects.
                string[] borderStyleArray = Enum.GetNames(typeof(BorderStyle));
                lstBorder.DataSource = borderStyleArray;
                lstBorder.DataBind();
              
                // Select the first border option.
                lstBorder.SelectedIndex = 0;
                // Set the picture.
                imgDefault.Visible = false;
                imgDefault.ImageUrl = "download.jpg";
            }
        }
        protected void ControlChanged(object sender, System.EventArgs e)
        {
            // Refresh the greeting card (because a control was changed).
            UpdateCard();
        }
        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            // Refresh the greeting card (because the button was clicked).
            UpdateCard();
        }
        private void UpdateCard()
        {
            pnlCard.BackColor = Color.FromName(lstBackColor.SelectedItem.Text);
            lblGreeting.Font.Name = lstFontName.SelectedItem.Text;
            if (Int32.Parse(txtFontSize.Text) > 0)
            {
                lblGreeting.Font.Size =
                FontUnit.Point(Int32.Parse(txtFontSize.Text));
            }
            // Update the border style. This requires two conversion steps.
            // First, the value of the list item is converted from a string
            // into an integer. Next, the integer is converted to a value in
            // the BorderStyle enumeration.
           
            TypeConverter converter =
TypeDescriptor.GetConverter(typeof(BorderStyle));
            // Update the border style using the value from the converter.
            pnlCard.BorderStyle = (BorderStyle)converter.ConvertFromString(
            lstBorder.SelectedItem.Text);
            // Update the picture.
            if (chkPicture.Checked)
            {
                imgDefault.Visible = true;
            }
            else
            {
                imgDefault.Visible = false;
            }
            // Set the text.
            lblGreeting.Text = txtGreeting.Text;
        }
       
    }
}
