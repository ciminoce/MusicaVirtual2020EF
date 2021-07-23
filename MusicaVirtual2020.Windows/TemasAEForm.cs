using System;
using System.Windows.Forms;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Windows
{
    public partial class TemasAEForm : Form
    {
        public TemasAEForm()
        {
            InitializeComponent();
        }

        private Tema tema;

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tema == null)
                {
                    tema=new Tema();
                }

                tema.PistaNro = (short) pistaNumericUpDown.Value;
                tema.Nombre = TituloTextBox.Text;
                tema.Tiempo = new TimeSpan(DuracionDateTimePicker.Value.Hour, 
                    DuracionDateTimePicker.Value.Minute,
                    DuracionDateTimePicker.Value.Second).Ticks;
                DialogResult = DialogResult.OK;
            }
        }

        public Tema GetTema()
        {
            return tema;
        }
        private bool ValidarDatos()
        {
            return true;
        }

        public void SetTema(Tema tema)
        {
            this.tema = tema;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tema!=null)
            {
                TituloTextBox.Text = tema.Nombre;
                DuracionDateTimePicker.Value = Convert.ToDateTime(tema.Duracion.ToString());
            }
            else
            {
                DuracionDateTimePicker.Value=DateTime.Parse("00:00:00");
            }
        }
    }
}
