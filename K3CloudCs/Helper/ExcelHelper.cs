using System;
using System.IO;
using System.Windows.Forms;

namespace K3CloudCs
{

    public class ExcelHelper
    {
        public void DataToExcel(DataGridView m_DataView)
        {
            SaveFileDialog kk = new System.Windows.Forms.SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName;
                if(File.Exists(FileName)==true)
                {
                    File.Delete(FileName);
                }
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for(int i=0;i<= m_DataView.Columns.Count - 1; i++)
                {
                    if(m_DataView.Columns[i].Visible == true)
                    {
                        strLine = strLine + m_DataView.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";
                for (int i = 0; i <= m_DataView.Rows.Count - 1; i++)
                {
                    //if (m_DataView.Rows[i].Visible == true)
                    //{
                    //    if(m_DataView.Rows[i].Cells[0].Value == null)
                    //    {
                    //        strLine = strLine + " " + "\t";
                    //    }
                    //    else
                    //    {
                    //        strLine = strLine + m_DataView.Rows[i].Cells[0].Value.ToString() + "\t";
                    //    }                        
                    //}
                    for (int j = 0; j <= m_DataView.Columns.Count - 1; j++)
                    {
                        if (m_DataView.Rows[i].Cells[j].Value == null)
                        {
                            strLine = strLine + " " + "\t";
                        }
                        else
                        {
                            strLine = strLine + m_DataView.Rows[i].Cells[j].Value.ToString() + "\t";
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = ""; 
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show("保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
    }
}
