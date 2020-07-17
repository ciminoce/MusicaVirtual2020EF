﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MusicaVirtual2020.Entidades.Entities;
using MusicaVirtual2020.Reportes;
using MusicaVirtual2020.Servicios.Servicios;
using MusicaVirtual2020.Servicios.Servicios.Facades;
using MusicaVirtual2020.Windows.Helpers;

namespace MusicaVirtual2020.Windows
{
    public partial class PaisesForm : Form
    {
        private static PaisesForm instancia = null;
        private PaisesForm(IServicioPais servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        public static PaisesForm GetInstancia(IServicioPais servicio)
        {
            if (instancia==null)
            {
                instancia=new PaisesForm(servicio);
                instancia.FormClosed += form_Close;
            }

            return instancia;
        }

        private static void form_Close(object sender, FormClosedEventArgs e)
        {
            instancia = null;
        }

        private void CerrarToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private readonly IServicioPais servicio;
        private List<Pais> lista;

        private void PaisesForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            try
            {
                lista = servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                Helper.mensajeBox(exception.Message,Tipo.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var paisDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, paisDto);
                AgregarFila(r);

            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Pais pais)
        {
            r.Cells[cmnPais.Index].Value = pais.Nombre;

            r.Tag = pais;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            PaisesAEForm frm=new PaisesAEForm();
            frm.Text = "Agregar País";
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                try
                {
                    Pais pais = frm.GetPais();
                    if (!servicio.Existe(pais))
                    {
                        servicio.Guardar(pais);
                        var r = ConstruirFila();
                        SetearFila(r,pais);
                        AgregarFila(r);
                        MessageBox.Show("Registro agregado", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Registro Duplicado... Alta denegada", "Error",
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
            if (DatosDataGridView.SelectedRows.Count>0)
            {
                var r = DatosDataGridView.SelectedRows[0];
                Pais pais =(Pais) r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea borrar de la lista a {pais.Nombre}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr==DialogResult.Yes)
                {
                    try
                    {

                        if (!servicio.EstaRelacionado(pais))
                        {
                            servicio.Borrar(pais);
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
            if (DatosDataGridView.SelectedRows.Count>0)
            {
                var r = DatosDataGridView.SelectedRows[0];
                Pais p =(Pais) r.Tag;
                Pais pCopia =(Pais) p.Clone();
                PaisesAEForm frm=new PaisesAEForm();
                frm.Text = "Editar País";
                frm.SetPais(p);
                DialogResult dr = frm.ShowDialog(this);
                if (dr==DialogResult.OK)
                {
                    try
                    {
                        p = frm.GetPais();
                        if (!servicio.Existe(p))
                        {
                            servicio.Guardar(p);
                            SetearFila(r,p);
                            MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Registro duplicado...\nEdición denegada","Error",
                                MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            SetearFila(r,pCopia);
                        }
                    }
                    catch (Exception exception)
                    {
                            MessageBox.Show(exception.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ImprimirToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Se solicita el listado de países a la bd
                lista = servicio.GetLista();
                //Instancio el manejador de reportes que se encarga de crear el rpt
                var manejadorReportes=new ManejadorDeReportes();
                /*Defino y asigno a la variable rpt de tipo PaisesReporte el reporte
                 con los datos provenientes de la capa de reportes*/
                PaisesReporte rpt = manejadorReportes.GetPaisesReporte(lista);
                //instancio el formulario donse se va a mostrar el rpt
                ReportesForm frm=new ReportesForm();
                frm.SetReporte(rpt);//Uso el método SetReporte para pasar el reporte al form
                frm.ShowDialog(this);//Muestro el formulario
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
