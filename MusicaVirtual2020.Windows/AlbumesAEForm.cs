using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MusicaVirtual2020.Entidades.Entities;
using MusicaVirtual2020.Entidades.Entities.Enums;
using MusicaVirtual2020.Servicios.Servicios;
using MusicaVirtual2020.Servicios.Servicios.Facades;
using MusicaVirtual2020.Windows.Helpers;

namespace MusicaVirtual2020.Windows
{
    public partial class AlbumesAEForm : Form
    {
        public AlbumesAEForm(IServicioAlbumes servicioAlbumes)
        {
            InitializeComponent();
            this.servicioAlbumes = servicioAlbumes;
        }

        private IServicioAlbumes servicioAlbumes;
        private Album album;
        private List<Tema> temas=new List<Tema>();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboEstilos(ref estiloComboBox);
            Helper.CargarDatosComboInterpretes(ref interpretesComboBox);
            Helper.CargarDatosComboNegocios(ref negocioComboBox);
            Helper.CargarDatosComboSoportes(ref soporteComboBox);
            if (album!=null)
            {
                TituloTextBox.Text = album.Titulo;
                interpretesComboBox.SelectedValue = album.Interprete.InterpreteId;
                soporteComboBox.SelectedValue = album.Soporte.SoporteId;
                estiloComboBox.SelectedValue = album.Estilo.EstiloId;
                negocioComboBox.SelectedValue = album.Negocio.NegocioId;
                pistasNumericUpDown.Value = album.Pistas;
                costoTextBox.Text = album.Costo.ToString();
                anioCompraTextBox.Text = album.AnioCompra.ToString();
                MostrarTemasEnGrilla();
            }
        }

        private void MostrarTemasEnGrilla()
        {
            temasDatosGridView.Rows.Clear();
            temas.Clear();//limpio la lista local de temas
            if (album.Temas.Count > 0)
            {
                foreach (var tema in album.Temas)
                {
                    DataGridViewRow r = ConstruirFila();
                    SetearFila(r, tema);
                    AgregarFila(r);

                    temas.Add(tema);
                }
                //album.Temas.ForEach(t =>
                //{
                //    if (t.Estado!=Estado.Borrado)
                //    {
                //        DataGridViewRow r = ConstruirFila();
                //        SetearFila(r, t);
                //        AgregarFila(r);

                //    }
                //    //agregar tema a la lista
                //    temas.Add(t);
                //});
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (album==null)
                {
                    album=new Album();
                }

                album.Titulo = TituloTextBox.Text;
                //album.Interprete =(Interprete) interpretesComboBox.SelectedItem;
                //album.Estilo=(Estilo) estiloComboBox.SelectedItem;
                //album.Soporte = (Soporte) soporteComboBox.SelectedItem;
                //album.Negocio = (Negocio) negocioComboBox.SelectedItem;
                album.InterpreteId =(int) interpretesComboBox.SelectedValue;
                album.EstiloId =(int) estiloComboBox.SelectedValue;
                album.SoporteId = (int)soporteComboBox.SelectedValue;
                album.NegocioId = (int)negocioComboBox.SelectedValue;

                album.Pistas = (short) pistasNumericUpDown.Value;
                album.Costo = decimal.Parse(costoTextBox.Text);
                album.AnioCompra = int.Parse(anioCompraTextBox.Text);

                album.Temas = temas;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TituloTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TituloTextBox,"El Título es requerido");
            }

            if (interpretesComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(interpretesComboBox,"Debe seleccionar un intérprete");
            }
            if (estiloComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(estiloComboBox, "Debe seleccionar un estilo");
            }
            if (negocioComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(negocioComboBox, "Debe seleccionar un negocio");
            }
            if (soporteComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(soporteComboBox, "Debe seleccionar un soporte");
            }

            if (!int.TryParse(anioCompraTextBox.Text,out int anio))
            {
                valido = false;
                errorProvider1.SetError(anioCompraTextBox,"Año mal ingresado");
            }else if (anio<1970 ||anio>DateTime.Now.Year)
            {
                valido = false;
                errorProvider1.SetError(anioCompraTextBox,"Año fuera del rango permitido");
            }

            if (!decimal.TryParse(costoTextBox.Text, out decimal costo))
            {
                valido = false;
                errorProvider1.SetError(costoTextBox,"Debe ingresar un costo");
            }else if (costo<0 ||costo>decimal.MaxValue-1)
            {
                valido = false;
                errorProvider1.SetError(costoTextBox,"Costo fuera del rango permitido");
            }

            if (pistasNumericUpDown.Value<temas.Count)
            {
                valido = false;
                errorProvider1.SetError(pistasNumericUpDown,"Pistas inferior a la cantidad de temas");
            }
            return valido;
        }

        public Album GetAlbum()
        {
            return album;
        }

        private void agregarTemaButton_Click(object sender, EventArgs e)
        {
            TemasAEForm frm=new TemasAEForm();
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                Tema tema = frm.GetTema();

                if (!temas.Contains(tema))
                {
                    /*Si queremos que la pista la incremente
                     de forma automática*/

                    //tema.PistaNro =(short)(temas.Count + 1);
                    //tema.Estado = Estado.Agregado;
                    temas.Add(tema);
                    DataGridViewRow r = ConstruirFila();
                    SetearFila(r, tema);
                    AgregarFila(r);
                    if (pistasNumericUpDown.Value == temas.Count)
                    {
                        agregarTemaButton.Enabled = false;
                    }
                    else
                    {
                        agregarTemaButton.Enabled = true;
                    }
                }
                else
                {
                    Helper.mensajeBox("Tema repetido... ", Tipo.Error);
                }
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            temasDatosGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Tema tema)
        {
            r.Cells[cmnNro.Index].Value = tema.PistaNro;
            r.Cells[cmnTema.Index].Value = tema.Nombre;
            r.Cells[cmnDuracion.Index].Value = tema.Duracion.ToString();

            r.Tag = tema;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r=new DataGridViewRow();
            r.CreateCells(temasDatosGridView);
            return r;
        }

        private void pistasNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (pistasNumericUpDown.Value>0)
            {
                agregarTemaButton.Enabled = true;
            }
            else
            {
                agregarTemaButton.Enabled = false;
            }
        }

        public void SetAlbum(Album album)
        {
            this.album = album;
        }

        private void temasDatosGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==3)
            {
                var rTema = temasDatosGridView.Rows[e.RowIndex];
                var tema = (Tema) rTema.Tag;
                TemasAEForm frm=new TemasAEForm();
                frm.SetTema(tema);
                DialogResult dr = frm.ShowDialog(this);
                if (dr==DialogResult.OK)
                {
                    try
                    {
                        tema = frm.GetTema();
                        if (tema.AlbumId!=0)
                        {
                            servicioAlbumes.GuardarTema(tema);
                            //tema.Estado = Estado.Modificado;

                        }
                        SetearFila(rTema, tema);
                        Helper.mensajeBox("Tema modificado..." + Environment.NewLine +
                            "Deberá presionar OK al finalizar para confirmar", Tipo.Success);
                    }
                    catch (Exception)
                    {

                        throw;
                    }                }
            }else if (e.ColumnIndex==4)
            {
                var rTema = temasDatosGridView.Rows[e.RowIndex];
                var tema = (Tema)rTema.Tag;
                DialogResult dr = Helper.mensajeBox($"¿Desea borrar el tema {tema.Nombre}? {Environment.NewLine}" +
                                                    $"El tema se borrará de forma definitiva...");
                if (dr==DialogResult.Yes)
                {
                    try
                    {
                        if (tema.AlbumId != 0)
                        {
                            /*Si el tema ya existe en la BD
                             hay que borrarlo y luego renumerar los temas*/
                            servicioAlbumes.BorrarTemaPorId(tema);
                            temas.Clear();//limpio la lista de temas
                            //Recargo la lista
                            temas = servicioAlbumes.GetTemasPorAlbum(album.AlbumId);
                            MostrarTemasEnGrilla();//Muestro la lista
                        }
                        else
                        {
                            temasDatosGridView.Rows.Remove(rTema);
                            RenumerarTemas();
                            MostrarTemasEnGrilla();
                        }

                        Helper.mensajeBox("Registro borrado", Tipo.Success);
                    }
                    catch (Exception exception)
                    {
                        Helper.mensajeBox(exception.Message, Tipo.Error);

                    }
                    //tema.Estado = Estado.Borrado;
                    //RenumerarTemas();
                    //MostrarTemasEnGrilla();
                    //Helper.mensajeBox("Tema borrado..." + Environment.NewLine +
                    //                  "Deberá presionar OK al finalizar para confirmar", Tipo.Success);

                }
            }
        }

        private void RenumerarTemas()
        {
            if (temas.Count==0)
            {
                return;
            }

            short contadorTemas = 0;
            //foreach (var tema in temas)
            //{
            //    contadorTemas++;
            //    tema.PistaNro = contadorTemas;


            //}
            temas.ForEach(t =>
            {
                
                contadorTemas++;
                t.PistaNro = contadorTemas;

              
            });
        }
    }
}
