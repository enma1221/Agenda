using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;


namespace CapaPresentacion
{
    public partial class P_Usuarios : Form
    {
        public P_Usuarios()
        {
            InitializeComponent();
        }

        //metodo para borrar los campos de texto
        public void borrar_tex()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtCelular.Clear();
        }


        private void P_Usuarios_Load(object sender, EventArgs e)
        {

        }

        // instanciamos las clases de las capas entidad y de negocios
        E_Usuarios usuariosEntidad = new E_Usuarios();
        N_Usuarios usuariosNegocio = new N_Usuarios();

        void listar()
        {
            DataTable dt = usuariosNegocio.N_Listar();
            dgvTabla.DataSource = dt;   

        }



     
        

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            listar();

        }

        //boton para insertar

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            var fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
            string celular = txtCelular.Text;

            usuariosNegocio.N_Insertar(nombre, apellido, direccion, fecha, celular);

            MessageBox.Show("La cita para "+nombre+ " ha sido guardada correctamente!!!!");
            borrar_tex();
            listar();
        }
        //boton para modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            var fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
            string celular = txtCelular.Text;

            usuariosNegocio.N_Modificar(id, nombre, apellido, direccion, fecha, celular);


            MessageBox.Show("La cita para " + nombre + " ha sido modificada correctamente!!!!");
            borrar_tex();
            listar();

        }

        //tabla
        private void dgvTabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvTabla.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvTabla.SelectedCells[1].Value.ToString();
            txtApellido.Text = dgvTabla.SelectedCells[2].Value.ToString();
            txtDireccion.Text = dgvTabla.SelectedCells[3].Value.ToString();
            dtpFecha.Text = dgvTabla.SelectedCells[4].Value.ToString();
            txtCelular.Text = dgvTabla.SelectedCells[5].Value.ToString();
        }

        //boton eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);

            string nombre = txtNombre.Text;
            usuariosNegocio.N_Eliminar(id);

            MessageBox.Show("La cita para " + nombre + " ha sido eliminada correctamente!!!!");
            borrar_tex();
            listar();
        }

        //boton para borrar campos
        private void button1_Click(object sender, EventArgs e)
        {
            borrar_tex();
        }
    }
}
