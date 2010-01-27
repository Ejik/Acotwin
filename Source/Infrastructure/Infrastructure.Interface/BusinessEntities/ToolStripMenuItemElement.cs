using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Drawing;

namespace ACOT.Infrastructure.Interface.BusinessEntities
{
    public class ToolStripMenuItemElement : ToolStripMenuItem
    {
        string _ID = "";
        string _RegistrationSite = "";
        string _Register = "";
        string _CommandName = "";

        public Collection<string[]> Command = new Collection<string[]>();
     
        public string ID
        {
            get
            {
                return (string)this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        public string CommandName
        {
            get
            {
                return _CommandName;
            }
            set
            {
            	this._CommandName = value;
            }
        }

        public string RegistrationSite
        {
            get
            {
                return this._RegistrationSite;
            }
            set
            {
                this._RegistrationSite = value;
            }
        }

        public string Register
        {
            get
            {
                return this._Register;
            }
            set
            {
                this._Register = value;
            }
        }               
        
        public ToolStripMenuItemElement() : base()
        {            
        }        
       
        public ToolStripMenuItemElement(string text) : base(text)
        {
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Forms.ToolStripMenuItem
        //     class that displays the specified text and image and that does the specified
        //     action when the System.Windows.Forms.ToolStripMenuItem is clicked.
        //
        // Parameters:
        //   onClick:
        //     An event handler that raises the System.Windows.Forms.Control.Click event
        //     when the control is clicked.
        //
        //   image:
        //     The System.Drawing.Image to display on the control.
        //
        //   text:
        //     The text to display on the menu item.
        public ToolStripMenuItemElement(string text, Image image, EventHandler onClick) : base(text, image, onClick)      
        {
        }       
    }
}
