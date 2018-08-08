using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using OSIsoft.AF.PI;
using OSIsoft.AF.Time;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectApp
{
    delegate void SetDataGridCallback(DataTable dataTable);

    public partial class frmFinalProjectApp : Form
    {
        private DataTable _dt = new DataTable();

        private Thread _getSnapshotThread;

        private PIPagingConfiguration _piPagingConfiguration = new PIPagingConfiguration(PIPageType.EventCount,100000);

        public frmFinalProjectApp()
        {
            var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            InitializeComponent();
            
            _dt.Columns.Add("Tag", typeof(string));
            _dt.Columns.Add("Timestamp", typeof(DateTime));
            _dt.Columns.Add("Value", typeof(object));
            _dt.Columns.Add("UOM", typeof(string));
            _dt.Columns.Add("Annotation", typeof(string));
            _dt.Columns.Add("CheckBox", typeof(bool));
            _dt.Columns.Add("Message", typeof(string));

            dataGrid.DataSource = _dt;
            
            dthFim.Value = DateTime.Now;
            dthInicio.Value = dthFim.Value.AddHours(-1);
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            _dt.Rows.Clear();
            
            PIPointList piPointList = new PIPointList();
            piPointList.AddRange(piPointTagSearchPage1.PIPoints);
            
            AFValues afValues = new AFValues();
            
            foreach (var piPoint in piPointList)
            {
                afValues.AddRange(piPoint.RecordedValues(new AFTimeRange(new AFTime(DateTime.SpecifyKind(dthInicio.Value, DateTimeKind.Local)), new AFTime(DateTime.SpecifyKind(dthFim.Value, DateTimeKind.Local))), AFBoundaryType.Inside, string.Empty, false));
            }

            foreach (var afValue in afValues)
            {
                _dt.Rows.Add(afValue.PIPoint.Name, (DateTime)afValue.Timestamp.LocalTime, afValue.Value, afValue.PIPoint.GetAttribute(PICommonPointAttributes.EngineeringUnits), afValue.GetAnnotation(), false, string.Empty);
            }
            
            dataGrid.DataSource = _dt;
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                try
                {
                    if (row.Cells["CheckBox"].Value != null &&  (bool)row.Cells["CheckBox"].Value == true)
                    {
                        // Connect PIServerAFSDK
                        PIServer _PIServerAFSDK = piPointTagSearchPage1.PIServer;

                        // Find PIPoint
                        PIPoint piPoint = PIPoint.FindPIPoint(_PIServerAFSDK, (string)row.Cells["tag"].Value);

                        AFAttribute afAttribute = new AFAttribute(piPoint);
                        
                        AFValue afValue = new AFValue(afAttribute, row.Cells["Value"].Value, AFTime.Parse(row.Cells["Timestamp"].Value.ToString()));
                        
                        if(row.Cells["Annotation"].Value.ToString() != string.Empty)
                        {
                            afValue.SetAnnotation(row.Cells["Annotation"].Value.ToString());
                        }
                        
                        piPoint.UpdateValue(afValue, AFUpdateOption.Replace, AFBufferOption.BufferIfPossible);
                    }
                }
                catch (Exception ex)
                {
                    row.Cells["Message"].Value = ex.Message;
                }

            }

            dataGrid.Refresh();
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {

            List<int> indexToRemove = new List<int>();

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Cells["CheckBox"].Value != null && (bool)row.Cells["CheckBox"].Value == true)
                {
                    try
                    {
                        // Connect PIServerAFSDK
                        PIServer _PIServerAFSDK = piPointTagSearchPage1.PIServer;

                        // Find PIPoint
                        PIPoint piPoint = PIPoint.FindPIPoint(_PIServerAFSDK, (string)row.Cells["tag"].Value);

                        AFAttribute afAttribute = new AFAttribute(piPoint);
                        
                        AFValue afValue = new AFValue(afAttribute, row.Cells["Value"].Value, AFTime.Parse(row.Cells["Timestamp"].Value.ToString()));
                        
                        piPoint.UpdateValue(afValue, AFUpdateOption.Remove, AFBufferOption.BufferIfPossible);

                        if (!row.IsNewRow)
                        {
                            indexToRemove.Add(row.Index);
                        }

                    }
                    catch(Exception ex)
                    {
                        row.Cells["Message"].Value = ex.Message;
                    }
                }

            }

            foreach (var index in indexToRemove.OrderByDescending(i => i))
            {
                dataGrid.Rows.RemoveAt(index);
            }

            dataGrid.Refresh();
        }

        private void chkShowSnapshot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowSnapshot.Checked == true)
            {
                btnClearData.Enabled = false;
                btnImportExcel.Enabled = false;
                btnGetData.Enabled = false;
                btnUpdateData.Enabled = false;
                btnDeleteData.Enabled = false;
                piPointTagSearchPage1.Enabled = false;

                _getSnapshotThread = new Thread(getSnapshot);

                _getSnapshotThread.Start(piPointTagSearchPage1.PIPoints);
            }
            else
            {
                btnClearData.Enabled = true;
                btnImportExcel.Enabled = true;
                btnGetData.Enabled = true;
                btnUpdateData.Enabled = true;
                btnDeleteData.Enabled = true;
                piPointTagSearchPage1.Enabled = true;
                _getSnapshotThread.Abort();
            }            
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            _dt.Rows.Clear();
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            _dt.Rows.Clear();

            string fname = "";
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Excel File Dialog";
            //fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fname = fdlg.FileName;
            }
            
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            
            for (int i = 2; i <= rowCount; i++)
            {
                try
                {
                    _dt.Rows.Add(Convert.ToString(xlRange.Cells[i, 1].Value2),
                                 DateTime.FromOADate(double.Parse(xlRange.Cells[i, 2].Value2.ToString())).ToString("dd-MM-yyyy hh:mm:ss"),
                                 Convert.ToString(xlRange.Cells[i, 3].Value2),
                                 Convert.ToString(xlRange.Cells[i, 4].Value2),
                                 Convert.ToString(xlRange.Cells[i, 5].Value2),
                                 true,
                                 string.Empty);
                }
                catch(Exception ex)
                {
                    _dt.Rows.Add(Convert.ToString(xlRange.Cells[i, 1].Value2),
                                 DateTime.Now,
                                 Convert.ToString(xlRange.Cells[i, 3].Value2),
                                 Convert.ToString(xlRange.Cells[i, 4].Value2),
                                 Convert.ToString(xlRange.Cells[i, 5].Value2),
                                 true,
                                 ex.Message);
                }
            }


            dataGrid.DataSource = _dt;
            
            // Cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            // Release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            // Close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            // Quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

        }

        private void getSnapshot(object obj)
        {
            List<PIPoint> p = obj as List<PIPoint>;

            SetDataGridCallback _dataGridCallback = new SetDataGridCallback(SetDataTable);

            PIDataPipe pipe = new PIDataPipe(AFDataPipeType.Archive);
            pipe.AddSignups(p);

            //_dt.Rows.Clear();
            _dt = new DataTable();
            
            _dt.Columns.Add("Tag", typeof(string));
            _dt.Columns.Add("Timestamp", typeof(DateTime));
            _dt.Columns.Add("Value", typeof(object));
            _dt.Columns.Add("UOM", typeof(string));
            _dt.Columns.Add("Annotation", typeof(string));
            _dt.Columns.Add("CheckBox", typeof(bool));
            _dt.Columns.Add("Message", typeof(string));

            PIPointList piPointList = new PIPointList();
            piPointList.AddRange(p);
            
            AFValues afValues = new AFValues();

            foreach (var piPoint in piPointList)
            {
                afValues.Add(piPoint.CurrentValue());
            }


            foreach (var afValue in afValues)
            {
                _dt.Rows.Add(afValue.PIPoint.Name, (DateTime)afValue.Timestamp.LocalTime, afValue.Value, afValue.PIPoint.GetAttribute(PICommonPointAttributes.EngineeringUnits), afValue.GetAnnotation(), false, string.Empty);
            }
            

            this.Invoke(_dataGridCallback, _dt );
            

            while (chkShowSnapshot.Checked == true)
            {
                AFListResults<PIPoint, AFDataPipeEvent> pipeConstants = pipe.GetUpdateEvents(5000);
                
                foreach (AFDataPipeEvent pipeEvent in pipeConstants)
                {
                    foreach (DataRow row in _dt.Rows)
                    {
                        if (row["Tag"] == pipeEvent.Value.PIPoint.Name)
                        {
                            row["Timestamp"] = pipeEvent.Value.Timestamp.LocalTime;
                            row["Value"] = pipeEvent.Value.Value;
                            row["UOM"] = pipeEvent.Value.PIPoint.GetAttribute(PICommonPointAttributes.EngineeringUnits);
                            row["Annotation"] = pipeEvent.Value.GetAnnotation();
                        }
                    }
                }
                
                if (this.dataGrid.InvokeRequired)
                {
                    this.Invoke(_dataGridCallback, _dt);
                }
                else
                {
                    dataGrid.DataSource = _dt;
                    dataGrid.Refresh();
                }
                
            };
            pipe.Close();
            pipe.Dispose();
        }
        
        private void SetDataTable(DataTable dataTable)
        {
            dataGrid.DataSource = dataTable;

            dataGrid.Refresh();
            Thread.Sleep(1000);
        }

        private void frmFinalProjectApp_Load(object sender, EventArgs e)
        {

        }
        

    }
}
