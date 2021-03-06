﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CozyPixel.Controls.ControlEventArgs;
using CozyPixel.Forms;
using System.IO;
using CozyPixel.Model;
using CozyPixel.Controls.Other;
using CozyColor.Core.Color;

namespace CozyPixel
{
    public partial class CozyPixelForm : Form
    {
        public bool IsModified { get; set; }

        public string CurrDire { get; set; } = Application.StartupPath;

        public CozyPixelForm()
        {
            InitializeComponent();
            RegisterEvent();
            RefreshThumb();
        }

        private void RegisterEvent()
        {
            ColorList.ColorSelectedEventHandler += OnColorSelected;
        }

        private void OnColorSelected(object sender, ColorEventAgs e)
        {
            SelectedColorButton.BackColor = e.SelectedColor;
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            if (IsModified)
            {
                if (!ShowSaveDialog())
                {
                    return;
                }
            }

            CloseFile();
            OpenFile();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            if (IsModified)
            {
                if (!ShowSaveDialog())
                {
                    return;
                }
            }

            Close();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog();
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            TestColor();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PixelPainter.DrawPixel(e.Location, ColorList.SelectedColor);
            if(!IsModified)
            {
                IsModified = true;
            }
        }

        private void GridColorButton_Click(object sender, EventArgs e)
        {
            var selectForm = new ColorSelectForm(ColorSelectCallback);
            selectForm.ShowDialog();
        }

        private void ShowGridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrPixelMap != null)
            {
                CurrPixelMap.ShowGrid   = ShowGridCheckBox.Checked;
                CurrPixelMap.PixelWidth = DefaultPixelWidth;

                if (CurrPixelMap.ShowGrid)
                {
                    CurrPixelMap.PixelWidth -= CurrPixelMap.GridWidth;
                }
                PixelPainter.RefreshPixel();
            }
        }

        private void GridWidthBox_TextChanged(object sender, EventArgs e)
        {
            int w = 0;
            if(int.TryParse(GridWidthBox.Text, out w))
            {
                if (CurrPixelMap != null)
                {
                    if (w == 0) w = 1;

                    CurrPixelMap.GridWidth = w;
                    PixelPainter.RefreshPixel();
                }
            }
        }

        private void CreateMenuItem_Click(object sender, EventArgs e)
        {
            if (IsModified)
            {
                if (!ShowSaveDialog())
                {
                    return;
                }
            }

            var createDlg = new CreateNewForm(CreateNewCallback);
            createDlg.ShowDialog();
        }

        private void DirectorySelectButton_Click(object sender, EventArgs e)
        {
            var direDlg = new FolderBrowserDialog();
            var r       = direDlg.ShowDialog();
            if(r == DialogResult.OK)
            {
                CurrDire = direDlg.SelectedPath;

                RefreshThumb();
            }
        }

        private void RefreshThumb()
        {
            ThumbListView.ImageClear();

            DirectoryInfo di    = new DirectoryInfo(CurrDire);
            var fs              = di.GetFiles("*.*", SearchOption.TopDirectoryOnly);

            foreach (var file in fs)
            {
                if (file.Extension == ".bmp" || file.Extension == ".jpg" || file.Extension == ".png")
                {
                    ThumbListView.TryAddImage(file.FullName);
                }
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsModified)
            {
                if(!ShowSaveDialog())
                {
                    return;
                }
            }

            var bmpPath = ThumbListView.SelectedImagePath;
            if(bmpPath != null &&　File.Exists(bmpPath))
            {
                var bmp = new Bitmap(bmpPath);
                ChangePixelPainterImage(bmp);
                SetCurrPathStatusLabel(bmpPath);
            }
        }

        private void RefreshThumbListButton_Click(object sender, EventArgs e)
        {
            RefreshThumb();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var arr     = DradientColor.Generate(RandomColor.Generate(), RandomColor.Generate(), 10);
            Bitmap b    = new Bitmap(500, 80);
            var g       = Graphics.FromImage(b);
            for (int i = 0; i < 10; ++i)
            {
                g.FillRectangle(new SolidBrush(arr[i]), i * 50, 0, i * 50 + 50, 80);
            }
            pictureBox1.Image = b;
        }
    }
}
