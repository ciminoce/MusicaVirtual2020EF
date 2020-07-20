using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MusicaVirtual2020.Entidades.DTOs.Interprete;
using MusicaVirtual2020.Entidades.Entities;
using MusicaVirtual2020.Entidades.Mapas;
using MusicaVirtual2020.Reportes;
using MusicaVirtual2020.Servicios.Servicios.Facades;

namespace MusicaVirtual2020.Windows
{
    public partial class InterpretesForm : Form
    {
        private static InterpretesForm instancia = null;

        public static InterpretesForm GetInstancia(IServicioInterprete servicio)
        {
            if (instancia == null)
            {
                instancia = new InterpretesForm(servicio);
                instancia.FormClosed += form_Close;
            }

            return instancia;
        }

        private static void form_Close(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }

        private InterpretesForm(IServicioInterprete servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        private List<Interprete> lista;
        private readonly IServicioInterprete servicio;
        private void InterpretesForm_Load(object sender, EventArgs e)
        {
            LoadRegistros();
        }

        private void LoadRegistros()
        {
            try
            {
                lista = servicio.GetInterpretes();
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
            foreach (var interprete in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, interprete);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Interprete interprete)
        {
            r.Cells[cmnInterprete.Index].Value = interprete.Nombre;
            r.Cells[cmnPais.Index].Value = interprete.Pais.Nombre;


            r.Tag = interprete;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            InterpretesAEForm frm = new InterpretesAEForm();
            frm.Text = "Nuevo Intérprete";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Interprete interprete = frm.GetInterprete();

                    if (!servicio.Existe(interprete))
                    {
                        servicio.Guardar(interprete);
                        DataGridViewRow r = ConstruirFila();
                        var interpreteDto = Mapeador.CrearMapper().Map<Interprete, InterpreteListDto>(interprete);
                        AgregarFila(r);
                        MessageBox.Show("Registro agregado", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Registro Duplicado \nAlta Denegada", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Interprete interprete = (Interprete)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja al intérprete {interprete.Nombre}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (!servicio.EstaRelaciona(interprete))
                        {
                            servicio.Borrar(interprete);
                            DatosDataGridView.Rows.Remove(r);
                            MessageBox.Show("Registro Borrado", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Intérprete con Álbumes \nBaja Denegada", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

            }
        }

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                Interprete interprete = (Interprete)r.Tag;
                Interprete interpreteAux = (Interprete)interprete.Clone();
                InterpretesAEForm frm = new InterpretesAEForm();
                frm.Text = "Editar Intérprete";
                frm.SetInterprete(interprete);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        interprete = frm.GetInterprete();

                        if (!servicio.Existe(interprete))
                        {
                            servicio.Guardar(interprete);
                            SetearFila(r, interprete);
                            MessageBox.Show("Registro agregado", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            

                            MessageBox.Show("Registro Duplicado \nAlta Denegada", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LoadRegistros();//Cargo toda la grilla;

                        }

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = servicio.GetInterpretes();
            ManejadorDeReportes manejadorDeReportes=new ManejadorDeReportes();
            InterpretesReporte rpt = manejadorDeReportes.GetInterpretesReporte(lista);
            ReportesForm frm=new ReportesForm();
            frm.SetReporte(rpt);
            frm.ShowDialog(this);
        }

        private void agrupadoXPaísToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = servicio.GetInterpretes();
            ManejadorDeReportes manejadorDeReportes = new ManejadorDeReportes();
            InterpretesAgrupadoPorPais rpt = manejadorDeReportes.GetReporteInterpretesAgrupados(lista);
            ReportesForm frm = new ReportesForm();
            frm.SetReporte(rpt);
            frm.ShowDialog(this);

        }

        private void filtradoXPaísToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaisFiltrarFrm frm=new PaisFiltrarFrm();
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                try
                {
                    Pais pais = frm.GetPais();
                    var listaFiltrada = servicio.GetInterpretes(pais);
                    ManejadorDeReportes manejador=new ManejadorDeReportes();
                    InterpretesFiltrado rpt = manejador.GetInterpretesReporteFiltrado(listaFiltrada);
                    ReportesForm frmReporte=new ReportesForm();
                    frmReporte.SetReporte(rpt);
                    frmReporte.ShowDialog(this);


                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void BuscarToolStripButton_Click(object sender, EventArgs e)
        {
            PaisFiltrarFrm frm = new PaisFiltrarFrm();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Pais pais = frm.GetPais();
                    lista = servicio.GetInterpretes(pais);
                    MostrarDatosEnGrilla();

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void ActualizarToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                lista = servicio.GetInterpretes();
                MostrarDatosEnGrilla();
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
