using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MusicaVirtual2020.Entidades.Entities;
using MusicaVirtual2020.Servicios.Servicios;
using MusicaVirtual2020.Servicios.Servicios.Facades;
using MusicaVirtual2020.Windows.Helpers;

namespace MusicaVirtual2020.Windows
{
    public partial class EstilosForm : Form
    {
        private static EstilosForm instancia = null;

        public static EstilosForm GetInstancia(IServicioEstilo servicio)
        {
            if (instancia==null)
            {
                instancia=new EstilosForm(servicio);
                instancia.FormClosed += form_Close;
            }

            return instancia;
        }

        private static void form_Close(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }

        private EstilosForm(IServicioEstilo servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        private IServicioEstilo servicio;
        private List<Estilo> lista;
        private void EstilosForm_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            try
            {
                lista = servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var estilo in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, estilo);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Estilo estilo)
        {
            r.Cells[cmnEstilo.Index].Value = estilo.Nombre;

            r.Tag = estilo;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r=new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            EstiloAEForm frm=new EstiloAEForm();
            frm.Text = "Agregar Estilo";
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                try
                {
                    var estilo = frm.GetEstilo();
                    servicio.Guardar(estilo);
                    DataGridViewRow r = ConstruirFila();
                    SetearFila(r,estilo);
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
                var r = DatosDataGridView.SelectedRows[0];
                Estilo Estilo = (Estilo)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea borrar de la lista a {Estilo.Nombre}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        if (!servicio.EstaRelacionado(Estilo))
                        {
                            servicio.Borrar(Estilo);
                            DatosDataGridView.Rows.Remove(r);
                            MessageBox.Show("Registro Borrado", "Mensaje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Registro relacionado...\nBaja denegada",
                                "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    }
                }
            }

        }

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                var r = DatosDataGridView.SelectedRows[0];
                Estilo p = (Estilo)r.Tag;
                Estilo pCopia = (Estilo)p.Clone();
                EstiloAEForm frm = new EstiloAEForm();
                frm.Text = "Editar Estilo";
                frm.SetEstilo(p);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        p = frm.GetEstilo();
                        if (!servicio.Existe(p))
                        {
                            servicio.Guardar(p);
                            SetearFila(r, p);
                            MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Registro duplicado...\nEdición denegada", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            SetearFila(r, pCopia);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
