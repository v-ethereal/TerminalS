using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Arsis.RentalSystem.AdministrationConsole.UserControls
{
    /// <summary>
    /// Represents a Windows date time picker control. It enhances the .NET standard <b>DateTimePicker</b>
    /// control with the possibility to show empty values (null values).
    /// Based on the solution of Claudio Grazioli.
    /// </summary>
    [ComVisible(false)]
    public class NullableDecimalEdit : NumericTextBox
    {
        private decimal maxValue = decimal.MaxValue;

        [Category("Numeric settings")]
        public decimal MaxValue
        {
            get
            {
                return maxValue; 
            }
            set
            {
                maxValue = value;
                if (maxValue < minValue)
                {
                    maxValue = minValue;
                }
                
                setScaleAndPrecision(maxValue);
            }
        }

        private void setScaleAndPrecision(decimal maxValue)
        {
            string number = maxValue.ToString(CultureInfo.InvariantCulture);
            number = number.TrimEnd('0');
            int precision = 0;
            int scale = 0;
            bool decimalSeparator = false;
            for(int ind=0; ind < number.Length;  ind++)
            {
                if ( number.Substring(ind,1) == NumberFormatInfo.InvariantInfo.NumberDecimalSeparator)
                {
                    decimalSeparator = true;
                }
                else if ( char.IsDigit(number[ind]) )
                {
                    precision++;    
                    if(decimalSeparator)
                    {
                        scale++;
                    }
                }
            }
            // Альтернативный вариант
            if(precision < NumericPrecision)
            {
                base.NumericPrecision = precision; 
            }
            if (scale > NumericScale)
            {
                base.NumericScale = scale;
            }
        }

        private decimal minValue = 0;
        [Category("Numeric settings")]
        public decimal MinValue
        {
            get
            {
                return minValue; 
            }
            set
            {
                minValue = value;
                if ( minValue > maxValue)
                {
                    minValue = maxValue;
                }
            }
        }

        [Category("Numeric settings")]
        public new int NumericPrecision
        {
            get
            {
                return base.NumericPrecision;
            }
            set
            {
                if (value != base.NumericPrecision)
                {
                    base.NumericPrecision = value;
                    decimal newMaxValue = generateMaxValue();
                    if (newMaxValue < maxValue)
                    {
                        maxValue = newMaxValue;
                    }
                }
            }
        }

        [Category("Numeric settings")]
        public new int NumericScale
        {
            get
            {
                return base.NumericScale;
            }
            set
            {
                if (value != base.NumericScale)
                {
                    base.NumericScale = value;
                    decimal newMaxValue = generateMaxValue();
                    if (newMaxValue < maxValue)
                    {
                        maxValue = newMaxValue;
                    }
                }
            }
        }

        private decimal generateMaxValue()
        {
            string numberStr = String.Empty;
            for (int i = 0; i < (NumericPrecision - NumericScale); i++)
            {
                numberStr += "9";
            }
            if (NumericScale > 0)
            {
                numberStr += DecimalSeperator;
                for (int i = 0; i < NumericScale; i++)
                {
                    numberStr += "9";
                }
            }
            decimal result = decimal.MaxValue;
            decimal.TryParse(numberStr, out result);
            return result;
        }

        #region Events
        /// <summary>
        /// This member overrides <see cref="Control.OnKeyDown"/>.
        /// </summary>
        /// <param name="e"></param>    
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Enabled && !ReadOnly && e.KeyCode == Keys.Delete && e.Control)
            {
                ControlValue = null;
                e.Handled = true;
                return;
            }
            base.OnKeyDown(e);
        }

        protected override void OnNumericValueChanged(EventArgs e)
        {
            decimal value;
            if (!NumericValue.HasValue)
            {
                controlValue = null;
                OnControlValueChanged(e);
                base.OnNumericValueChanged(e);
                return;
            }
            else
            {
                value = NumericValue.Value;
            }

            string errorMessage = null;
            if (value > maxValue)
            {
                // Откат значения к предыдущему
                restorePrevValue();
            }

            if (value < minValue)
            {
           
            }

            if (errorMessage == null)
            {
                controlValue = value;
                
                OnControlValueChanged(EventArgs.Empty);
            }
            else
            {
                if (Focused)
                {
                }
            }
            base.OnNumericValueChanged(e);
        }
        #endregion
    }
}