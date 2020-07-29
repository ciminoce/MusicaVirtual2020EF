using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MusicaVirtual2020.Entidades.DTOs.Album;
using MusicaVirtual2020.Entidades.Entities;
using MusicaVirtual2020.Entidades.Mapas;
using MusicaVirtual2020.Servicios.Servicios.Facades;
using MusicaVirtual2020.Windows.Helpers;

namespace MusicaVirtual2020.Windows
{
    public partial class AlbumesForm : Form
    {
        private static AlbumesForm _instancia = null;

        public static AlbumesForm GetInstancia(IServicioAlbumes servicio)
        {
            if (_instancia==null)
            {
                _instancia=new AlbumesForm(servicio);
                _instancia.FormClosed += Form_close;
            }

            return _instancia;
        }

        private static void Form_close(object sender, FormClosedEventArgs e)
        {
            _instancia = null;
        }

        private AlbumesForm(IServicioAlbumes servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        private IServicioAlbumes servicio;
        private List<AlbumListDto> lista;
        private void AlbumesForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                lista = servicio.GetAlbumes();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {
                Helper.mensajeBox(ex.Message, Tipo.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var albumListDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, albumListDto);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, AlbumListDto album)
        {
            r.Cells[cmnAlbum.Index].Value = album.Titulo;
            r.Cells[cmnInterprete.Index].Value = album.Interprete;
            r.Cells[cmnPistas.Index].Value = album.Pistas;

            r.Tag = album;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r=new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            AlbumesAEForm frm=new AlbumesAEForm();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK) 
            {
                try
                {
                    Album album = frm.GetAlbum();
                    servicio.Guardar(album);
                    DataGridViewRow r = ConstruirFila();
                    AlbumListDto albumListDto = Mapeador.CrearMapper().Map<Album, AlbumListDto>(album);
                    SetearFila(r,albumListDto);
                    AgregarFila(r);
                    Helper.mensajeBox("Registro agregado con éxito", Tipo.Success);
                }
                catch (Exception exception)
                {
                    Helper.mensajeBox(exception.Message, Tipo.Error);

                }
            }
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                try
                {
                    var r = DatosDataGridView.SelectedRows[0];
                    var albumDto = (AlbumListDto) r.Tag;
                    DialogResult dr = Helper.mensajeBox($"¿Desea dar de baja el álbum {albumDto.Titulo}?");
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            servicio.Borrar(albumDto.AlbumId);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception);
                            throw;
                        }

                    }
                    
                }
                catch (Exception )
                {

                }
            }
        }

        private void detalleToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count==0)
            {
                return;
            }

            var r = DatosDataGridView.SelectedRows[0];
            AlbumListDto albumDto = (AlbumListDto) r.Tag;
            try
            {
                Album album = servicio.GetAlbumPorId(albumDto.AlbumId);
                DetallesAlbumForm frm=new DetallesAlbumForm();
                frm.SetAlbum(album);
                frm.ShowDialog(this);
            }
            catch (Exception exception)
            {
                Helper.mensajeBox(exception.Message, Tipo.Error);
            }
        }

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var r = DatosDataGridView.SelectedRows[0];
            AlbumListDto albumDto = (AlbumListDto)r.Tag;
            try
            {
                Album album = servicio.GetAlbumPorId(albumDto.AlbumId);
                AlbumesAEForm frm =new AlbumesAEForm();
                frm.SetAlbum(album);
                DialogResult dr=frm.ShowDialog(this);
                if (dr==DialogResult.OK)
                {
                    try
                    {
                        servicio.Guardar(album);
                        albumDto = Mapeador.CrearMapper().Map<Album, AlbumListDto>(album);
                        SetearFila(r,albumDto);
                        Helper.mensajeBox("Album Modificado", Tipo.Success);
                    }
                    catch (Exception exception)
                    {
                        Helper.mensajeBox(exception.Message, Tipo.Error);
                    }
                }

            }
            catch (Exception exception)
            {
                Helper.mensajeBox(exception.Message, Tipo.Error);
            }

        }
    }
}
