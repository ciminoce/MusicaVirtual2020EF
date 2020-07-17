﻿using System;
using System.Windows.Forms;
using MusicaVirtual2020.Servicios.Servicios.Facades;
using MusicaVirtual2020.Windows.Ninject;

namespace MusicaVirtual2020.Windows
{
    public partial class MenuPrincipalForm : Form
    {
        public MenuPrincipalForm()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PaisesToolStripButton_Click(object sender, EventArgs e)
        {
            ManejarPaises();
        }

        private void ManejarPaises()
        {
            var frm = PaisesForm.GetInstancia(DI.Create<IServicioPais>());

            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Dock = DockStyle.Fill;

            frm.Show();
        }


        private void EstilosToolStripButton_Click(object sender, EventArgs e)
        {
            ManejarEstilos();
        }

        private void ManejarEstilos()
        {
            EstilosForm frm = EstilosForm.GetInstancia();

            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Dock = DockStyle.Fill;


            frm.Show();
        }

        private void InterpretesToolStripButton_Click(object sender, EventArgs e)
        {
            ManejarInterpretes();
        }

        private void ManejarInterpretes()
        {
            InterpretesForm frm = InterpretesForm.GetInstancia();

            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Dock = DockStyle.Fill;


            frm.Show();
        }

        private void SoportesToolStripButton_Click(object sender, EventArgs e)
        {
            ManejarSoportes();
        }

        private void ManejarSoportes()
        {
            SoportesForm frm = SoportesForm.GetInstancia();

            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Dock = DockStyle.Fill;


            frm.Show();
        }

        private void NegociosToolStripButton_Click(object sender, EventArgs e)
        {
            ManejarNegocios();
        }

        private void ManejarNegocios()
        {
            NegociosForm frm = NegociosForm.GetInstancia();

            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Dock = DockStyle.Fill;


            frm.Show();
        }

        private void AlbumesToolStripButton_Click(object sender, EventArgs e)
        {
            ManejarAlbumes();
        }

        private void ManejarAlbumes()
        {
            AlbumesForm frm = AlbumesForm.GetInstancia();

            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Dock = DockStyle.Fill;


            frm.Show();
        }

        private void albumesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManejarAlbumes();
        }

        private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManejarPaises();
        }

        private void intérpretesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManejarInterpretes();
        }

        private void estilosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManejarEstilos();
        }

        private void soporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManejarSoportes();
        }



        private void cantidadXIntérpreteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlbumesPorInterpretesForm frm=new AlbumesPorInterpretesForm();
            frm.Text = "Cantidad de Álbumes por Intérprete";
            frm.ShowDialog(this);

        }

        private void cantidadXNegocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlbumesPorNegocioForm frm = new AlbumesPorNegocioForm();
            frm.Text = "Cantidad de Álbumes por Negocio";
            frm.ShowDialog(this);

        }
    }
}
