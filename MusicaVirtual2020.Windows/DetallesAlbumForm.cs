using System;
using System.Globalization;
using System.Windows.Forms;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Windows
{
    public partial class DetallesAlbumForm : Form
    {
        public DetallesAlbumForm()
        {
            InitializeComponent();
        }

        private Album album;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            TituloTextBox.Text = album.Titulo;
            InterpreteTextBox.Text = album.Interprete.Nombre;
            SoporteTextBox.Text = album.Soporte.Descripcion;
            EstiloTextBox.Text = album.Estilo.Nombre;
            NegocioTextBox.Text = album.Negocio.Nombre;
            PistasTextBox.Text = album.Pistas.ToString();
            AnioCompraTextBox.Text = album.AnioCompra.ToString();
            CostoTextBox.Text = album.Costo.ToString(CultureInfo.InvariantCulture);
            album.Temas.ForEach(t =>
            {
                var r = ConstruirFila();
                SetearFila(r, t);
                AgregarFila(r);
            });
        }

        private void SetearFila(DataGridViewRow r, Tema tema)
        {
            r.Cells[cmnNro.Index].Value = tema.PistaNro;
            r.Cells[cmnTema.Index].Value = tema.Nombre;
            r.Cells[cmnDuracion.Index].Value = tema.Duracion.ToString();
        }

        private void AgregarFila(DataGridViewRow r)
        {
            temasDatosGridView.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila()
        {
            var r=new DataGridViewRow();
            r.CreateCells(temasDatosGridView);
            return r;
        }

        public void SetAlbum(Album album)
        {
            this.album = album;
        }
    }
}
