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

namespace WindowsFormsApp1
{
    public partial class NotUseAnything : Form
    {

        private readonly AESUtils _yayoiCryptor;
        private string _rawString;

        public NotUseAnything()
        {

            var memoryCache = new MemoryCacheService(new MemoryCacheOptions());
            _yayoiCryptor = new AESUtils(memoryCache);


            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var aesStr = _yayoiCryptor.EncryptData("sfdsdfsdfs", "1234567812345678");
        }
    }
}