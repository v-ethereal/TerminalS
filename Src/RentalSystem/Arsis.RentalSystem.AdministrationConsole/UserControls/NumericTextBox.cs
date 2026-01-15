using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Arsis.RentalSystem.AdministrationConsole.UserControls
{
    [ToolboxBitmap(typeof (TextBox))]
    public class NumericTextBox : TextBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        private bool allowNegative = false;
        private bool noChangeEvent = false;
        private bool zeroNotValid = false;
        private bool useGroupSeparator = true;
        private Decimal? prevValue;
        private int prevSelectedRank = 0;
        private Decimal? numericValue;
        private int precision = 10;
        private int scale = 0;

        public NumericTextBox()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            TextAlign = HorizontalAlignment.Right;
            TextChanged += NumericTextBox_TextChanged;
            KeyDown += NumericTextBox_KeyDown;
            KeyPress += NumericTextBox_KeyPress;
            Validating += NumericTextBox_Validating;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control Control
        {
            get { return this; }
        }

        // ‘лаг введен дл€ того чтобы не допустить вызова валидации 
        // при первой инициализации контролов данными документа
        // когда форма загружаетс€
        private bool firstRun = true;

        protected decimal? controlValue = null;

        [Bindable(true)]
        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual object ControlValue
        {
            get { return controlValue; }
            set
            {
                decimal? oldValue = controlValue;
                if (value == null)
                {
                    Text = String.Empty;
                }
                else
                {
                    Text = value.ToString();
                }

                if (firstRun)
                {
                    firstRun = false;
                    return;
                }

                if (oldValue != controlValue && !Focused)
                {
                    //»з документа пришло новое значение - надо провалидировать
                }
            }
        }

        private void cancelEditing()
        {
            foreach (Binding b in DataBindings)
            {
                BindingManagerBase bmb = BindingContext[b.DataSource, b.BindingMemberInfo.BindingMember];
                bmb.CancelCurrentEdit();
            }
        }


        public event EventHandler NumericValueChanged;

        /// <summary>
        /// —обытие, возникающее при изменении свойства ControlValue.
        /// </summary>
        [Browsable(true)]
        public event EventHandler ControlValueChanged;

        protected virtual void OnControlValueChanged(EventArgs e)
        {
            if (ControlValueChanged != null)
            {
                ControlValueChanged(this, e);
            }
        }

        #region "Properties"

        /// <summary>
        /// Indicates if the value zero (0) valid.
        /// </summary>
        [Category("Numeric settings")]
        public bool ZeroIsValid
        {
            get { return zeroNotValid; }
            set { zeroNotValid = value; }
        }

        [Category("Numeric settings")]
        [DefaultValue(true)]
        public virtual bool UseGroupSeparator
        {
            get { return useGroupSeparator; }
            set { useGroupSeparator = value; }
        }


        /// <summary>
        /// Maximum allowed precision
        /// </summary>
        [Category("Numeric settings")]
        protected virtual int NumericPrecision
        {
            get { return precision; }
            set
            {
                //Precision cannot be negative
                if (value < 0)
                {
                    MessageBox.Show("Precision cannot be negative!", "Numeric TextBox", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                if (value < NumericScale)
                {
                    NumericScale = value;
                }

                precision = value;
            }
        }

        /// <summary>
        /// The maximum scale allowed
        /// </summary>
        //[System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.All),
        //System.ComponentModel.Category("Numeric settings")]
        [Category("Numeric settings")]
        protected virtual int NumericScale
        {
            get { return scale; }
            set
            {
                //Scale cannot be negative
                if (value < 0)
                {
                    MessageBox.Show("Scale cannot be negative!", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                //Scale cannot be larger than precision
                if (value >= NumericPrecision)
                {
                    MessageBox.Show("Scale cannot be larger than precission!", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                scale = value;
                if (!NumericValue.HasValue)
                {
                    return;
                }

                if (scale > 0)
                {
                    Text = "0" + DecimalSeperator + new string(Convert.ToChar("0"), scale);
                }
                else
                {
                    Text = "0";
                }
            }
        }
       
        protected static string DecimalSeperator
        {
            get { return NumberFormatInfo.CurrentInfo.NumberDecimalSeparator; }
        }

        protected string GroupSeperator
        {
            get { return useGroupSeparator ? NumberFormatInfo.CurrentInfo.NumberGroupSeparator : String.Empty; }
        }


        /// <summary>
        /// Indicates if negative numbers are allowed?
        /// </summary>
        [Category("Numeric settings")]
        public bool AllowNegative
        {
            get { return allowNegative; }
            set { allowNegative = value; }
        }

        /// <summary>
        /// The current numeric value displayed in the textbox
        /// </summary>
        //[System.ComponentModel.Bindable(true),
        // System.ComponentModel.Category("Numeric settings")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected decimal? NumericValue
        {
            get { return numericValue; }
            set
            {
                savePrevValue();
                Text = Convert.ToString(value);
            }
        }

        private void savePrevValue()
        {
            prevValue = numericValue;
            prevSelectedRank = getSelectedRank();
        }

        #endregion

        #region Events

        private void NumericTextBox_TextChanged(object sender, EventArgs e)
        {
            //Indicates that no change event should happen
            //Prevent event from firing on changing the text in the change
            //event
            if (noChangeEvent || (SelectionStart == -1))
            {
                return;
            }

            try
            {
                //No Change event
                noChangeEvent = true;

                //            if ( string.Empty.Equals(this.Text.Trim())) 
                //            {
                //                this.Text = "0";
                //            }

                if (Text.Length > 0 && Text.Substring(0, 1) == GroupSeperator)
                {
                    Text = Text.Substring(1);
                }

                bool valueChanged = setValue();

                if (valueChanged)
                {
                    OnNumericValueChanged(new EventArgs());
                }
            }
            finally
            {
                //Change event may fire
                noChangeEvent = false;
            }
        }

        private bool setValue()
        {
            int selStart = 0;

            bool positionCursorBeforeComma = false;
            if (!(scale == 0))
            {
                //if ( the current position is just before the comma
                if (SelectionStart == (Text.IndexOf(DecimalSeperator)))
                {
                    positionCursorBeforeComma = true;
                }
                else
                {
                    selStart = SelectionStart;
                }
            }
            else
            {
                selStart = SelectionStart;
            }

            bool valueChanged = false;
            
            savePrevValue();
            if (String.IsNullOrEmpty(Text))
            {
                numericValue = null;
                if (numericValue != prevValue)
                {
                    valueChanged = true;
                }
                
            }
            else
            {
                decimal tempVal;
                if (decimal.TryParse(Text, out tempVal))
                {
                    numericValue = tempVal;
                }
                else
                {
                    restorePrevValue();
                }
                if (numericValue != prevValue)
                {
                    valueChanged = true;
                }
            }


            //set { the text to the new format
            //if (! precision = 0 ) {
            
            if (Text.Equals('-'))
            {
                Text = "";
            }
            else
            {
                int selectedRank = getSelectedRank();
                Text = FormatNumber();
                if (selectedRank >= 0)
                {
                    restoreRankSelection(selectedRank);
                }
                else
                {
                    SelectionStart = selStart;
                }

                if (scale != 0 && positionCursorBeforeComma)
                {
                    SelectionStart = (Text.IndexOf(DecimalSeperator));
                }
            }
            return valueChanged;
        }

        protected void restorePrevValue()
        {
            int rankRestore = prevSelectedRank;
            Thread.Sleep(100);
            if (prevValue != null && prevValue.HasValue)
            {
                Text = prevValue.ToString();
            }
            else
            {
                Text = String.Empty;
            }
            setValue();
            restoreRankSelection(rankRestore);
        }

        /// <summary>
        /// ¬ычисл€ет номер разр€да числа на котором стоит курсор (разделители гупп игнорируютс€)
        /// </summary>
        /// <returns></returns>
        private int getSelectedRank()
        {
            int commaPos = Text.IndexOf(DecimalSeperator);
            if(commaPos < 0)
            {
                commaPos = Text.Length;
            }
            int rank = 0;
            if(commaPos < SelectionStart)
            {
                return -1;
            }
            string numberBetweenSelectionAndComma = Text.Substring(SelectionStart, commaPos - SelectionStart);
            for (int ind = numberBetweenSelectionAndComma.Length - 1; ind >= 0; ind--)
            {
                if (char.IsDigit(numberBetweenSelectionAndComma[ind]))                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
                {
                    rank++;
                }
            }
            return rank;
        }

        private void restoreRankSelection(int rank)
        {
            if(rank < 0)
            {
                return;
            }
            int commaPos = Text.IndexOf(DecimalSeperator);
            if (commaPos < 0)
            {
                commaPos = Text.Length;
            }
            if (rank == 0 )
            {
                SelectionStart = commaPos;
                return;
            }

            if (SelectionStart < commaPos)
            {
                for (int ind = commaPos - 1; ind >= 0; ind--)
                {
                    if (char.IsDigit(Text[ind]))
                    {
                        rank--;
                    }
                    if (rank == 0)
                    {
                        SelectionStart = ind;
                        return;
                    }                    
                }
            }
        }

        private void NumericTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Enabled && !ReadOnly && e.KeyCode == Keys.Delete && e.Control)
            {
                ControlValue = null;
                e.Handled = true;
                return;
            }
            bool positionCursorJustBeforeComma = false;

            if (!(scale == 0))
            {
                //Is the position of the cursor just before the comma
                positionCursorJustBeforeComma = (SelectionStart == (Text.IndexOf(DecimalSeperator)));
            }

            switch (e.KeyCode)
            {
                case Keys.Delete:
                    //Otherwise strange effect
                    if (positionCursorJustBeforeComma)
                    {
                        SelectionStart = Text.IndexOf(DecimalSeperator) + 1;
                        e.Handled = true;
                        break;
                    }
                    //if ( all selected on delete pressed

                    if (Text.IndexOf('-') < 0)
                    {
                        if (SelectionLength == Text.Length)
                        {
                            Text = "0";
                            SelectionStart = 1;
                            e.Handled = true;
                            break;
                        }
                    }
                    else
                    {
                        if (SelectionLength == Text.Length)
                        {
                            Text = "0";
                            SelectionStart = 1;
                            e.Handled = true;
                            break;
                        }

                        if (SelectionLength > 0)
                        {
                            if (SelectedText != "-")
                            {
                                if (Convert.ToDouble(SelectedText) == Math.Abs(Convert.ToDouble(Text)))
                                {
                                    Text = "0";
                                    SelectionStart = 1;
                                    e.Handled = true;
                                    break;
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            return;
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool positionCursorBeforeComma = false;
            bool inputBeforeCommaValid;
            bool positionCursorJustAfterComma = false;
            int selStart;

            //Minus pressed
            if (e.KeyChar.Equals('-'))
            {
                if (AllowNegative)
                {
                    if (Text.IndexOf('-') < 0)
                    {
                        selStart = SelectionStart;

                        if (!(Convert.ToDecimal(Text) == 0))
                        {
                            Text = "-" + Text;

                            SelectionStart = selStart + 1;
                        }
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        switch (SelectionLength)
                        {
                            case 0:
                                selStart = SelectionStart;

                                Text = Convert.ToString(Convert.ToDouble(Text)*-1);

                                SelectionStart = selStart - 1;

                                e.Handled = true;
                                break;
                            default:
                                //Is everything selected
                                if (SelectionLength == TextLength)
                                    Text = "-0";
                                e.Handled = true;
                                break;
                        }
                    }
                    e.Handled = true;
                    return;
                }
            }

            //The + key
            if (e.KeyChar.Equals('+'))
            {
                if (!(Text.IndexOf('-') < 0))
                {
                    //Is everything selected
                    switch (SelectionLength)
                    {
                        case 0:
                            selStart = SelectionStart;

                            Text = Convert.ToString(Convert.ToDouble(Text)*-1);

                            SelectionStart = selStart - 1;

                            e.Handled = true;
                            break;
                        default:
                            if (TextLength == SelectionLength)
                            {
                                Text = "0";
                                e.Handled = true;
                            }
                            break;
                    }
                }
                e.Handled = true;
                return;
            }

            if (!(scale == 0))
            {
                //Is the position of the cursor just after the comma
                positionCursorJustAfterComma = (SelectionStart == Text.IndexOf(DecimalSeperator) + 1);
            }

            if (e.KeyChar == '\b')
            {
                //Backspace
                if (positionCursorJustAfterComma)
                {
                    SelectionStart = Text.IndexOf(DecimalSeperator);
                    e.Handled = true;
                }

                //if ( all selected on delete pressed)
                if (SelectionLength == Text.Length)
                {
                    Text = "0";
                    SelectionStart = 1;
                    e.Handled = true;
                }

                if (e.KeyChar.Equals(null))
                {
                    e.Handled = true;
                }
                return;
            }

            //Prevent other keys than numeric and ,
            string allowedKeyChars = "1234567890." + DecimalSeperator;

            if (allowedKeyChars.IndexOf(e.KeyChar) < 0)
            {
                e.Handled = true;
                return;
            }

//            if(Text.Length == 0)
//            {
//                FormatNumber();
//                e.Handled = true;
//                return;
//            }


            if (!(scale == 0))
            {
                //position of cursor is before comma?
                positionCursorBeforeComma = !(SelectionStart >= Text.IndexOf(DecimalSeperator) + 1);
            }

            //Comma pressed
            if (e.KeyChar.ToString() == DecimalSeperator || e.KeyChar == '.' )
            {
                if (positionCursorBeforeComma)
                {
                    SelectionStart = Text.IndexOf(DecimalSeperator) + 1;
                    SelectionLength = 0;
                }

                e.Handled = true;
                return;
            }

            //Prevent more than the precission numbers entered
            if (!(scale == 0))
            {
                if (Text.Length != 0 && SelectionStart == Text.Length)
                {
                    e.Handled = true;
                    return;
                }
            }

            inputBeforeCommaValid = (Text.Length < getMaxTextLength());
//            if (!(scale == 0))
//            {
//                //if ( the character entered would violate the numbers before the comma
//                if (Text.Length > 0)
//                {
//                    lb_InputBeforeCommaValid =
//                            !(Text.Substring(0, Text.IndexOf(DecimalSeperator)).Length >= getMaxTextLength() - scale);
//                }
//            }
//            else
//            {
//                lb_InputBeforeCommaValid = !((Text.Length) >= getMaxTextLength());    
//            }

            //if first char is 0 another may be entered
            if (!(scale == 0))
            {
                if (Text.Length > 0 && (Text.Substring(0, 1) == "0") && !(SelectionStart == 0))
                {
                    inputBeforeCommaValid = true;
                }
                if (SelectionLength > 0)
                {
                    inputBeforeCommaValid = true;
                }
            }
            else
            {
                if (Text.Length > 0 && (Text.Substring(0, 1) == "0") && ((SelectionStart == Text.Length) || (SelectionLength == 1)))
                {
                    inputBeforeCommaValid = true;
                }
                if (SelectionLength > 0)
                {
                    inputBeforeCommaValid = true;
                }
            }

            if (!(scale == 0))
            {
                if (positionCursorBeforeComma && !(inputBeforeCommaValid))
                {
                    e.Handled = true;
                    return;
                }
            }
            else
            {
                if (!(inputBeforeCommaValid))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private int getMaxTextLength()
        {
            int maxTextLength = precision;
            // разделители групп
            if (precision > 0)
            {
                int groupCount = (precision - scale) / 3;
                if ((precision - scale) % 3 > 0)
                {
                    groupCount++;
                }
                
                if (groupCount > 1)
                {
                    maxTextLength += (groupCount - 1) * GroupSeperator.Length;
                }
            }
            // место дл€ минуса
            if (AllowNegative && Text.IndexOf('-') == 0)
            {
                maxTextLength++; 
            }
            // разделитель целой и дробной части
            if(scale > 0)
            {
                maxTextLength++;
            }
            return maxTextLength;
        }

        /// <summary>
        /// Raises the NumericValueChanged event
        /// </summary>
        /// <param name="e">The eventargs</param>
        protected virtual void OnNumericValueChanged(EventArgs e)
        {
            if (NumericValueChanged != null)
            {
                NumericValueChanged(this, e);
            }
        }

        /// <summary>
        /// Formats a the text inf the textbox (which represents a number) according to
        /// the scale,precision and the enviroment settings.
        /// </summary>
        protected string FormatNumber()
        {
            if (String.IsNullOrEmpty(Text))
            {
                return String.Empty;
            }

            StringBuilder format = new StringBuilder();
            int counter = 1;
            long remainder;

            if (Focused)
            {
                while (counter <= precision - scale)
                {
                    if (counter == 1)
                    {
                        format.Insert(0, '0');
                    }
                    else
                    {
                        format.Insert(0, '#');
                    }

                    if (useGroupSeparator)
                    {
                        Math.DivRem(counter, 3, out remainder);
                        if ((remainder == 0) && (counter + 1 <= precision - scale))
                        {
                            format.Insert(0, ',');
                        }
                    }

                    counter++;
                }

                counter = 1;

                if (scale > 0)
                {
                    format.Append(".");

                    while (counter <= scale)
                    {
                        format.Append('0');
                        counter++;
                    }
                }
            }
            else
            {
                while (counter <= precision - scale)
                {
                    if (counter == 1)
                    {
                        format.Insert(0, '0');
                    }
                    else
                    {
                        format.Insert(0, '#');
                    }
                    if (useGroupSeparator)
                    {
                        Math.DivRem(counter, 3, out remainder);
                        if ((remainder == 0) && (counter + 1 <= precision - scale))
                        {
                            format.Insert(0, ',');
                        }
                    }
                    counter++;
                }

                counter = 1;

                if (scale > 0)
                {
                    format.Append(".");

                    while (counter <= scale)
                    {
                        format.Append('0');
                        counter++;
                    }
                }
            }

            return Convert.ToDecimal(Text).ToString(format.ToString());
        }

        private void NumericTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((Text.Equals(string.Empty) || Convert.ToDecimal(NumericValue).Equals(Convert.ToDecimal(0))) &&
                !ZeroIsValid)
            {
                e.Cancel = true;
            }
        }

        #endregion

        // —войства, оставшиес€ от предыдущей реализации котрола (чтобы не переделывать формы)

        #region Obsolete
        [Obsolete]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MaskFormat CutCopyMaskFormat
        {
            get
            {
                return MaskFormat.ExcludePromptAndLiterals;
            }
            set
            {

            }
        }


        [Obsolete]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MaskFormat TextMaskFormat
        {
            get
            {
                return MaskFormat.ExcludePromptAndLiterals;
            }
            set
            {

            }
        }

        [Obsolete]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Mask
        {
            get
            {
                return String.Empty;
            }
            set
            {

            }
        }

        [Obsolete]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HidePromptOnLeave
        {
            get
            {
                return true;
            }
            set
            {

            }
        }
        #endregion
       

       
    }
}