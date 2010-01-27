using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ACOT.Infrastructure.Controls.XPanderControls
{
    /// <summary>
    /// Provide black theme colors
    /// </summary>
    /// <remarks>
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
    /// REMAINS UNCHANGED.
    /// </remarks>
    /// <copyright>Copyright � 2006-2008 Uwe Eichkorn</copyright>
    public class PanelColorsBlack : PanelColors
    {
		#region FieldsPrivate
		#endregion

		#region Properties
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initialize a new instance of the PanelColorsBlack class.
        /// </summary>
        public PanelColorsBlack()
			: base()
		{
		}
        /// <summary>
        /// Initialize a new instance of the PanelColorsBlack class.
        /// </summary>
        /// <param name="basePanel">Base class for the panel or xpanderpanel control.</param>
        public PanelColorsBlack(BasePanel basePanel)
            : base(basePanel)
        {
        }

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Initialize a color Dictionary with defined colors
        /// </summary>
        /// <param name="rgbTable">Dictionary with defined colors</param>
        protected override void InitColors(ref Dictionary<PanelColors.KnownColors, Color> rgbTable)
        {
            rgbTable[KnownColors.BorderColor] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.PanelCaptionCloseIcon] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.PanelCaptionExpandIcon] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.PanelCaptionGradientBegin] = Color.FromArgb(155, 155, 155);
            rgbTable[KnownColors.PanelCaptionGradientEnd] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.PanelCaptionGradientMiddle] = Color.FromArgb(90, 90, 90);
            rgbTable[KnownColors.PanelContentGradientBegin] = Color.FromArgb(240, 241, 242);
            rgbTable[KnownColors.PanelContentGradientEnd] = Color.FromArgb(240, 241, 242);
            rgbTable[KnownColors.PanelCaptionText] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.PanelCollapsedCaptionText] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.InnerBorderColor] = Color.FromArgb(185, 185, 185);
            rgbTable[KnownColors.XPanderPanelBackColor] = Color.FromArgb(214, 214, 214);
            rgbTable[KnownColors.XPanderPanelCaptionCloseIcon] = Color.FromArgb(255, 0, 0);
            rgbTable[KnownColors.XPanderPanelCaptionExpandIcon] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.XPanderPanelCaptionText] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.XPanderPanelCaptionGradientBegin] = Color.FromArgb(155, 155, 155);
            rgbTable[KnownColors.XPanderPanelCaptionGradientEnd] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.XPanderPanelCaptionGradientMiddle] = Color.FromArgb(90, 90, 90);
            rgbTable[KnownColors.XPanderPanelFlatCaptionGradientBegin] = Color.FromArgb(90, 90, 90);
            rgbTable[KnownColors.XPanderPanelFlatCaptionGradientEnd] = Color.FromArgb(155, 155, 155);
            rgbTable[KnownColors.XPanderPanelPressedCaptionBegin] = Color.FromArgb(255, 252, 222);
            rgbTable[KnownColors.XPanderPanelPressedCaptionEnd] = Color.FromArgb(255, 230, 158);
            rgbTable[KnownColors.XPanderPanelPressedCaptionMiddle] = Color.FromArgb(255, 215, 103);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionBegin] = Color.FromArgb(255, 217, 170);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionEnd] = Color.FromArgb(254, 225, 122);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionMiddle] = Color.FromArgb(255, 171, 63);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionText] = Color.FromArgb(0, 0, 0);
        }

        #endregion

        #region MethodsPrivate
        #endregion
    }
}
