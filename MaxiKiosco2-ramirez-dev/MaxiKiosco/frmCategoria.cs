using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using MaxiKiosco.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaxiKiosco
{
    public partial class frmCategoria : Form
    {
        // Buffer para render / sugerencias
        private List<Categoria> _bufferCategorias = new List<Categoria>();

        // Item de sugerencia
        private sealed class ItemSugCategoria
        {
            public int Id { get; }
            public string Texto { get; }
            public string Valor { get; } // lo que ponemos en el txtbusqueda
            public ItemSugCategoria(int id, string texto, string valor)
            {
                Id = id; Texto = texto; Valor = valor;
            }
            public override string ToString() => Texto; // por si no se setea DisplayMember
        }

        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            // === Columnas creadas programáticamente ===
            dgvdata.RowHeadersVisible = false;
            dgvdata.Columns.Clear();

            dgvdata.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "btnseleccionar",
                HeaderText = "",
                Width = 30,
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true
            });

            dgvdata.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreDeCategoria",
                HeaderText = "Nombre De Categoria",
                Width = 230
            });

            dgvdata.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Id",
                HeaderText = "ID",
                Visible = false
            });

            dgvdata.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Estado",
                HeaderText = "Estado",
                Width = 200
            });

            dgvdata.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "EstadoValor",
                HeaderText = "EstadoValor",
                Visible = false
            });

            dgvdata.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "PorcentajeAumento",
                HeaderText = "% Aumento",
                Width = 170
            });

            // === Estado ===
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            // === Combo de búsqueda (con Name de columna) ===
            cbobusqueda.Items.Clear();
            foreach (DataGridViewColumn column in dgvdata.Columns)
            {
                if (column.Visible && column.Name != "btnseleccionar" && column.Name != "Id" && column.Name != "EstadoValor")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, texto = column.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            // === Carga de datos ===
            dgvdata.Rows.Clear();
            _bufferCategorias = new CN_Categoria().Listar() ?? new List<Categoria>();

            foreach (var item in _bufferCategorias)
            {
                dgvdata.Rows.Add(new object[] {
                    "", // botón
                    item.nombre_categoria,
                    item.Id,
                    item.estado ? "Activo" : "No Activo",
                    item.estado ? 1 : 0,
                    item.porcentaje_aumento
                });
            }

            // === Layout & autosize ===
            ConfigurarLayoutYAutosize();

            // === Sugerencias ===
            // Asumimos que lbbusquedacategoria existe en el diseñador
            lbbusquedacategoria.Visible = false;
            lbbusquedacategoria.DisplayMember = "Texto"; // mostrará Texto de ItemSugCategoria
            lbbusquedacategoria.Click += lbbusquedacategoria_Click;
            lbbusquedacategoria.KeyDown += lbbusquedacategoria_KeyDown;

            // Wire de eventos buscador
            txtbusqueda.TextChanged += txtbusqueda_TextChanged;
            txtbusqueda.KeyDown += txtbusqueda_KeyDown;
        }

        // ---------------- Layout y autosize ----------------
        private void ConfigurarLayoutYAutosize()
        {
            // Que el form y el DGV se estiren bien
            this.AutoSize = false;
            this.MinimumSize = new Size(900, 600);

            dgvdata.AutoGenerateColumns = false;
            dgvdata.AllowUserToAddRows = false;

            // Si el DGV está en un panel, poné el panel Dock=Fill y también el DGV Dock=Fill.
            dgvdata.Dock = DockStyle.Fill; // ocupa todo el contenedor

            dgvdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            void Fill(string name, float weight, int min = 80)
            {
                if (!dgvdata.Columns.Contains(name)) return;
                var col = dgvdata.Columns[name];
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = weight;
                col.MinimumWidth = min;
                col.Resizable = DataGridViewTriState.True;
            }

            Fill("btnseleccionar", 8, 60);
            Fill("NombreDeCategoria", 50, 180);
            Fill("Estado", 18, 120);
            Fill("PorcentajeAumento", 24, 120);

            if (dgvdata.Columns.Contains("Id")) dgvdata.Columns["Id"].Visible = false;
            if (dgvdata.Columns.Contains("EstadoValor")) dgvdata.Columns["EstadoValor"].Visible = false;

            dgvdata.PerformLayout();
            dgvdata.Invalidate();
        }

        // ---------------- Helpers selección/carga ----------------
        private void CargarDesdeFila(DataGridViewRow row)
        {
            if (row == null) return;

            txtid.Text = Convert.ToString(row.Cells["Id"].Value);
            txtnombreC.Text = Convert.ToString(row.Cells["NombreDeCategoria"].Value);
            txtPorcentajeAumento.Text = Convert.ToString(row.Cells["PorcentajeAumento"].Value);

            int estadoVal = 1;
            int.TryParse(Convert.ToString(row.Cells["EstadoValor"].Value), out estadoVal);

            foreach (OpcionCombo oc in cboestado.Items)
            {
                if (Convert.ToInt32(oc.Valor) == estadoVal)
                {
                    cboestado.SelectedIndex = cboestado.Items.IndexOf(oc);
                    break;
                }
            }

            txtindice.Text = row.Index.ToString();
            btnguardar.Text = "Actualizar";
            btnguardar.BackColor = Color.FromArgb(255, 170, 0);
        }

        private bool SeleccionarFilaPorId(int id)
        {
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (!row.IsNewRow && Convert.ToInt32(row.Cells["Id"].Value) == id)
                {
                    dgvdata.ClearSelection();
                    row.Selected = true;
                    dgvdata.FirstDisplayedScrollingRowIndex = row.Index;
                    CargarDesdeFila(row);
                    return true;
                }
            }
            return false;
        }

        // ---------------- Normalización para contains-like ----------------
        private static string NormalizeText(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            var norm = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char ch in norm)
            {
                var cat = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch);
                if (cat != System.Globalization.UnicodeCategory.NonSpacingMark) sb.Append(ch);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
        private static bool ContainsLike(string haystack, string needle)
        {
            return NormalizeText(haystack).ToUpperInvariant()
                   .Contains(NormalizeText(needle).ToUpperInvariant());
        }

        // ---------------- Sugerencias (según cbobusqueda) ----------------
        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            string q = (txtbusqueda.Text ?? "").Trim();

            // posicionar el ListBox debajo de txtbusqueda
            lbbusquedacategoria.Left = txtbusqueda.Left;
            lbbusquedacategoria.Top = txtbusqueda.Bottom + 2;
            lbbusquedacategoria.Width = txtbusqueda.Width;

            if (q.Length == 0 || _bufferCategorias.Count == 0 || cbobusqueda.SelectedItem == null)
            {
                lbbusquedacategoria.Visible = false;
                return;
            }

            string columna = (cbobusqueda.SelectedItem as OpcionCombo)?.Valor?.ToString() ?? "NombreDeCategoria";
            var sugs = new List<ItemSugCategoria>();

            foreach (var c in _bufferCategorias)
            {
                bool match = false;
                switch ((columna ?? "").ToLowerInvariant())
                {
                    case "nombredecategoria":
                        match = ContainsLike(c.nombre_categoria ?? "", q);
                        break;
                    case "estado":
                        string estadoText = c.estado ? "ACTIVO" : "NO ACTIVO";
                        match = ContainsLike(estadoText, q);
                        break;
                    case "porcentajeaumento":
                        string pct = (c.porcentaje_aumento).ToString("0.##");
                        match = ContainsLike(pct, q);
                        break;
                    default:
                        // fallback amplio
                        match = ContainsLike(c.nombre_categoria ?? "", q);
                        break;
                }

                if (match)
                {
                    string texto = $"{c.nombre_categoria} — {(c.estado ? "Activo" : "No Activo")} — {c.porcentaje_aumento:0.##}%";
                    // Valor que ponemos en el txtbusqueda al elegir sugerencia:
                    string valor = (columna.ToLowerInvariant()) switch
                    {
                        "nombredecategoria" => c.nombre_categoria ?? "",
                        "estado" => (c.estado ? "Activo" : "No Activo"),
                        "porcentajeaumento" => c.porcentaje_aumento.ToString("0.##"),
                        _ => c.nombre_categoria ?? ""
                    };

                    sugs.Add(new ItemSugCategoria(c.Id, texto, valor));
                    if (sugs.Count >= 12) break;
                }
            }

            if (sugs.Count == 0)
            {
                lbbusquedacategoria.Visible = false;
                return;
            }

            lbbusquedacategoria.BeginUpdate();
            lbbusquedacategoria.DataSource = null;
            lbbusquedacategoria.Items.Clear();
            lbbusquedacategoria.DataSource = sugs; // SelectedItem será ItemSugCategoria
            lbbusquedacategoria.EndUpdate();
            lbbusquedacategoria.Visible = true;
        }

        private void txtbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (!lbbusquedacategoria.Visible) return;

            if (e.KeyCode == Keys.Down)
            {
                if (lbbusquedacategoria.Items.Count > 0)
                {
                    lbbusquedacategoria.SelectedIndex = 0;
                    lbbusquedacategoria.Focus();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (lbbusquedacategoria.Items.Count > 0)
                {
                    lbbusquedacategoria.SelectedIndex = 0;
                    ConfirmarSeleccionCategoria();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lbbusquedacategoria.Visible = false;
                e.Handled = true;
            }
        }

        private void lbbusquedacategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmarSeleccionCategoria();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lbbusquedacategoria.Visible = false;
                txtbusqueda.Focus();
                e.Handled = true;
            }
        }

        private void lbbusquedacategoria_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccionCategoria();
        }

        private void ConfirmarSeleccionCategoria()
        {
            if (lbbusquedacategoria.SelectedItem is ItemSugCategoria it)
            {
                // Reflejo en el textbox lo que buscaste (según columna)
                txtbusqueda.Text = it.Valor;
                lbbusquedacategoria.Visible = false;

                // Selecciono la fila con ese Id y cargo los campos
                if (!SeleccionarFilaPorId(it.Id))
                {
                    // si no está en grilla (filtrada), quito filtros para encontrarla
                    foreach (DataGridViewRow row in dgvdata.Rows) row.Visible = true;
                    SeleccionarFilaPorId(it.Id);
                }
            }
        }

        // ---------------- CRUD y acciones existentes ----------------

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtnombreC.Text = string.Empty;

            // Si tenés un NumericUpDown:
            txtPorcentajeAumento.Value = 0;

            if (cboestado.Items.Count > 0)
                cboestado.SelectedIndex = 0;

            dgvdata.ClearSelection();

            btnguardar.Text = "Guardar";
            btnguardar.BackColor = Color.FromArgb(0, 192, 0);

            txtnombreC.Focus();
        }

        private void btnguardar_Click_1(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            decimal porcentajeAumento = 0;

            if (!decimal.TryParse(txtPorcentajeAumento.Text.Trim(), out porcentajeAumento))
            {
                MessageBox.Show("El Porcentaje de Aumento debe ser un valor numérico válido (ej. 10 o 5.5).",
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var objCategoria = new Categoria()
            {
                Id = Convert.ToInt32(txtid.Text),
                nombre_categoria = txtnombreC.Text,
                estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1,
                porcentaje_aumento = porcentajeAumento
            };

            if (objCategoria.Id == 0)
            {
                int idCategoriagenerado = new CN_Categoria().Registrar(objCategoria, out mensaje);

                if (idCategoriagenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {
                        "",
                        objCategoria.nombre_categoria,
                        idCategoriagenerado,
                        objCategoria.estado ? "Activo" : "No Activo",
                        objCategoria.estado ? 1 : 0,
                        objCategoria.porcentaje_aumento
                    });

                    // actualizar buffer para sugerencias
                    objCategoria.Id = idCategoriagenerado;
                    _bufferCategorias.Add(objCategoria);

                    Limpiar();
                    MessageBox.Show("Categoría registrada con éxito.", "Registro Exitoso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Categoria().Editar(objCategoria, out mensaje);
                if (resultado)
                {
                    var row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["NombreDeCategoria"].Value = objCategoria.nombre_categoria;
                    row.Cells["Id"].Value = objCategoria.Id;
                    row.Cells["Estado"].Value = objCategoria.estado ? "Activo" : "No Activo";
                    row.Cells["EstadoValor"].Value = objCategoria.estado ? 1 : 0;
                    row.Cells["PorcentajeAumento"].Value = objCategoria.porcentaje_aumento;

                    // sincronizo buffer
                    var idx = _bufferCategorias.FindIndex(c => c.Id == objCategoria.Id);
                    if (idx >= 0) _bufferCategorias[idx] = objCategoria;

                    MessageBox.Show("Categoría editada con éxito.", "Edición Exitosa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void btnlimpiar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar la Categoría?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    var objCategoria = new Categoria() { Id = Convert.ToInt32(txtid.Text) };
                    bool respuesta = new CN_Categoria().Eliminar(objCategoria, out mensaje);
                    if (respuesta)
                    {
                        // quito de la grilla
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        // quito del buffer (sugerencias)
                        _bufferCategorias.RemoveAll(c => c.Id == objCategoria.Id);

                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void dgvdata_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                int w = 24;
                int h = 24;
                int x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.checkpng, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                var row = dgvdata.Rows[e.RowIndex];
                CargarDesdeFila(row);
            }
        }

        // --------- Filtro “mostrar/ocultar” por botón Buscar (se mantiene tu lógica) ---------
        private void btnbuscar2_Click_1(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    bool visible = false;
                    if (row.Cells[columnaFiltro].Value != null)
                    {
                        string valorCelda = row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper();
                        visible = valorCelda.Contains(txtbusqueda.Text.Trim().ToUpper());
                    }
                    row.Visible = visible;
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows) row.Visible = true;
            lbbusquedacategoria.Visible = false;
        }

        // (dejé estos por si los usás para algo)
        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtbusqueda_Click(object sender, EventArgs e) { }
    }
}
