﻿using Hr32bit;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YayoiApp.Utilities.SecurityFunc;
using YayoiApp.Utilities.SecurityFunc.AES;
using YayoiApp.Utilities.SecurityFunc.DES;

namespace WindowsFormsApp1
{
    public partial class NotUseAnything : Form
    {

        //private readonly AESUtils _yayoiCryptor;
        private readonly DES _yayoiCryptor;
        private string _rawString;

        public NotUseAnything()
        {

            var memoryCache = new MemoryCacheService(new MemoryCacheOptions());
            _yayoiCryptor = new DES(memoryCache);


            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var aesStr = _yayoiCryptor.EncryptData("sfdsdfsdfs", "1234567812345678");

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    await conn.OpenAsync();

            //    var insertstr = "INSERT INTO RequestYayoi VALUES(@MacAddress," +
            //        " @YayoiLoginUser, @YayoiLoginPass, @TxtFile, @FileFormat, @StartLine, @YayoiSlip, @AutoNo," +
            //        " @ManyImport, @SerialId, @TabletUUID,  @Status)";

            //    var pwd = model.YayoiLoginPass == null ? "" : model.YayoiLoginPass;

            //    SqlCommand sqlCommand = new SqlCommand(insertstr, conn);
            //    sqlCommand.CommandType = CommandType.Text;
            //    sqlCommand.Parameters.Add("@MacAddress", SqlDbType.Text).Value = model.MacAddress;
            //    sqlCommand.Parameters.Add("@YayoiLoginUser", SqlDbType.NVarChar).Value = model.YayoiLoginUser;
            //    sqlCommand.Parameters.Add("@YayoiLoginPass", SqlDbType.Text).Value = pwd;
            //    sqlCommand.Parameters.Add("@TxtFile", SqlDbType.Text).Value = model.TxtFile;
            //    sqlCommand.Parameters.Add("@FileFormat", SqlDbType.Text).Value = model.FileFormat;
            //    sqlCommand.Parameters.Add("@StartLine", SqlDbType.Text).Value = model.StartLine;
            //    sqlCommand.Parameters.Add("@YayoiSlip", SqlDbType.Text).Value = model.YayoiSlip;
            //    sqlCommand.Parameters.Add("@AutoNo", SqlDbType.Text).Value = model.AutoNo;
            //    sqlCommand.Parameters.Add("@ManyImport", SqlDbType.Text).Value = model.ManyImport;
            //    sqlCommand.Parameters.Add("@SerialId", SqlDbType.Text).Value = 0;
            //    sqlCommand.Parameters.Add("@TabletUUID", SqlDbType.Text).Value = model.TabletUUID;
            //    sqlCommand.Parameters.Add("@Status", SqlDbType.Int).Value = model.Status;
            //    int res = await sqlCommand.ExecuteNonQueryAsync();
            //    if (res == 0)
            //    {
            //        returnValue.flag = false;
            //        returnValue.msg = "cannot upload";
            //    }

            //    var tbId = model.TabletUUID;

            //    sqlCommand.Dispose();

            //    var selectstr = "SELECT Flag, Msg, TabletUUID FROM ReturnValue WHERE TabletUUID ='" + tbId + "'";
            //    DataTable dataTable = await getReturnValue(selectstr, conn);

            //    while (dataTable.Rows.Count == 0)
            //    {
            //        dataTable = await getReturnValue(selectstr, conn);
            //        if (dataTable.Rows.Count != 0 && dataTable.Rows[0]["TabletUUID"].ToString().Equals(tbId))
            //        {
            //            break;
            //        }
            //        continue;
            //    }
            //    var delquery = "DELETE FROM ReturnValue WHERE TabletUUID ='" + tbId + "'";
            //    await deleteTable(delquery, conn);

            //    if (Boolean.Parse(dataTable.Rows[0]["Flag"].ToString()))
            //    {
            //        returnValue.flag = true;
            //    }
            //    else
            //    {
            //        returnValue.flag = false;
            //    }

            //    returnValue.msg = dataTable.Rows[0]["Msg"].ToString();
            //    conn.Close();
            //}
        }
    }
}
