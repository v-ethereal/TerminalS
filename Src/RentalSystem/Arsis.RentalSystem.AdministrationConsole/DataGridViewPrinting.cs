using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;

using System.Windows.Forms;
using Arsis.RentalSystem.AdministrationConsole.Properties;

namespace Arsis.RentalSystem.AdministrationConsole
{
    /// <summary>
    /// Class providing DataGridView printing capability.
    /// </summary>
    public class DataGridViewPrinting
    {
        private DataGridView dataGridView;
        private PrintDocument printDocument;
        private StringFormat strFormat;
        private int iTotalWidth;
        private readonly ArrayList arrColumnLefts = new ArrayList();
        private readonly ArrayList arrColumnWidths = new ArrayList();
        private int iCellHeight;
        private int iHeaderHeight;
        private int iPageNumber;
        private int iRow;
        private bool bFirstPage;
        private bool bNewPage;

        private static DataGridViewPrinting instance;

        /// <summary>
        /// Private constructor.
        /// Used to hide default public constructor.
        /// </summary>
        private DataGridViewPrinting()
        {}

        /// <summary>
        /// Singletone of DataGridViewPrinting class.
        /// </summary>
        public static DataGridViewPrinting Instance
        {
            get
            {
                if (instance == null) instance = new DataGridViewPrinting();
                return instance;
            }
        }


        /// <summary>
        /// Method used to print out the datagrid view contents.
        /// </summary>
        /// <param name="reportName">Report name to be printed in report header</param>
        /// <param name="dgView">DataGridView to be printed out</param>
        /// <param name="showPreview">indicates if preview dialog or print dialog should be shown</param>
        public void Print(string reportName, DataGridView dgView, bool showPreview)
        {
            if (reportName == null) throw new ArgumentNullException("reportName");
            if (dgView == null) throw new ArgumentNullException("dgView");

            dataGridView = dgView;

            //Init PrintDocument
            printDocument = new PrintDocument {DocumentName = reportName};
            printDocument.BeginPrint += printDocument_BeginPrint;
            printDocument.PrintPage += printDocument_PrintPage;

            if (showPreview)
            {
                //Open the print preview dialog
                var printPreviewDialog = new PrintPreviewDialog
                                             {
                                                 Document = printDocument,
                                                 WindowState = FormWindowState.Maximized
                                             };
                printPreviewDialog.ShowDialog();
            }
            else
            {
                //Open the print dialog
                var printDialog = new PrintDialog {Document = printDocument, UseEXDialog = true};
                if (DialogResult.OK == printDialog.ShowDialog())
                {
                    //print document since OK button was pressed
                    printDocument.Print();
                }
            }
        }

        /// <summary>
        /// Handles the begin print event of print document
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void printDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat
                                {
                                    Alignment = StringAlignment.Near,
                                    LineAlignment = StringAlignment.Center,
                                    Trimming = StringTrimming.EllipsisCharacter
                                };

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                bFirstPage = true;
                bNewPage = true;
                iRow = 0;
                iPageNumber = 0;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView.Columns)
                {
                    if (!dgvGridCol.Visible) continue;

                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Handles the print page event of print document
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                iPageNumber++;
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                //Printed records count
                int iPageRecords = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView.Columns)
                    {
                        if (!GridCol.Visible) continue;

                        var iTmpWidth = (int)(Math.Floor((double)GridCol.Width / iTotalWidth * iTotalWidth
                                                          * ((double)e.MarginBounds.Width / iTotalWidth)));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }

                //Remember real (as displayed) columns order
                var colIndexes = new Hashtable(dataGridView.ColumnCount);
                for (int i = 0; i < dataGridView.ColumnCount; i++)
                {
                    DataGridViewColumn GridCol = dataGridView.Columns[i];
                    colIndexes.Add(GridCol.DisplayIndex, i);
                }

                //Draw Header
                e.Graphics.DrawString(printDocument.DocumentName,
                                      new Font(dataGridView.Font, FontStyle.Bold),
                                      Brushes.Black, e.MarginBounds.Left,
                                      e.MarginBounds.Top - e.Graphics.MeasureString(printDocument.DocumentName,
                                                                                    new Font(dataGridView.Font, FontStyle.Bold),
                                                                                    e.MarginBounds.Width).Height - 13);

                String strDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                //Draw Date
                e.Graphics.DrawString(strDate,
                                      new Font(dataGridView.Font, FontStyle.Bold), Brushes.Black,
                                      e.MarginBounds.Left +
                                      (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                                                                       new Font(dataGridView.Font, FontStyle.Bold),
                                                                                       e.MarginBounds.Width).Width),
                                      e.MarginBounds.Top - e.Graphics.MeasureString(printDocument.DocumentName,
                                                                                    new Font(new Font(dataGridView.Font, FontStyle.Bold),
                                                                                             FontStyle.Bold), e.MarginBounds.Width).Height - 13);


                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    if (bNewPage)
                    {
                        //Draw Columns                 
                        iTopMargin = e.MarginBounds.Top;

                        for (int i = 0; i < colIndexes.Count; i++)
                        {
                            DataGridViewColumn GridCol = dataGridView.Columns[(int)colIndexes[i]];

                            if (!GridCol.Visible) continue;

                            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                                     new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                                                   (int)arrColumnWidths[iCount], iHeaderHeight));

                            e.Graphics.DrawRectangle(Pens.Black,
                                                     new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                                                   (int)arrColumnWidths[iCount], iHeaderHeight));

                            e.Graphics.DrawString(GridCol.HeaderText,
                                                  GridCol.InheritedStyle.Font,
                                                  new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                                  new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                                                 (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                            iCount++;
                        }
                        bNewPage = false;
                        iTopMargin += iHeaderHeight;
                    }

                    iCount = 0;
                    //Draw Columns Contents   
                    for (int i = 0; i < colIndexes.Count; i++)
                    {
                        DataGridViewCell Cel = GridRow.Cells[(int)colIndexes[i]];

                        if (!Cel.Visible) continue;

                        if (Cel.Value != null)
                        {
                            if (Cel.ValueType == typeof(bool))
                            {
                                var val = (bool)Cel.Value;
                                if (val) //checked
                                {
                                    int iCellWidth = Math.Min((int)arrColumnWidths[iCount], iCellHeight);
                                    e.Graphics.DrawImage(Resources.check2,
                                        new RectangleF((int)arrColumnLefts[iCount] + ((int)arrColumnWidths[iCount] - iCellWidth) / 2, iTopMargin,
                                                                     iCellWidth, iCellHeight));
                                }
                            }
                            else
                            {
                                e.Graphics.DrawString(Cel.FormattedValue.ToString(),
                                                      Cel.InheritedStyle.Font,
                                                      new SolidBrush(Cel.InheritedStyle.ForeColor),
                                                      new RectangleF((int) arrColumnLefts[iCount], iTopMargin,
                                                                     (int) arrColumnWidths[iCount], iCellHeight),
                                                      strFormat);
                            }
                        }
                        //Drawing Cells Borders 
                        e.Graphics.DrawRectangle(Pens.Black,
                                                 new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                                               (int)arrColumnWidths[iCount], iCellHeight));
                        iCount++;
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                    iPageRecords++;
                }

                //Draw footer
                string strPageRecords = "Записей на странице " + iPageRecords + " из " + dataGridView.Rows.Count;
                e.Graphics.DrawString(strPageRecords,
                                      new Font(dataGridView.Font, FontStyle.Bold),
                                      Brushes.Black, e.MarginBounds.Left,
                                      e.MarginBounds.Bottom + e.Graphics.MeasureString(strPageRecords,
                                                                                    new Font(dataGridView.Font, FontStyle.Bold),
                                                                                    e.MarginBounds.Width).Height - 13);

                //Draw Date
                string strPageNumber = "Страница " + iPageNumber;
                e.Graphics.DrawString(strPageNumber,
                                      new Font(dataGridView.Font, FontStyle.Bold), Brushes.Black,
                                      e.MarginBounds.Left +
                                      (e.MarginBounds.Width - e.Graphics.MeasureString(strPageNumber,
                                                                                       new Font(dataGridView.Font, FontStyle.Bold),
                                                                                       e.MarginBounds.Width).Width),
                                      e.MarginBounds.Bottom + e.Graphics.MeasureString(printDocument.DocumentName,
                                                                                    new Font(new Font(dataGridView.Font, FontStyle.Bold),
                                                                                             FontStyle.Bold), e.MarginBounds.Width).Height - 13);


                //If more lines exist, print another page.
                e.HasMorePages = bMorePagesToPrint;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "System error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }



    }
}
