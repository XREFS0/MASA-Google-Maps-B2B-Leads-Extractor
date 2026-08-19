namespace MASAGooGLExtractor
{
	// Token: 0x02000019 RID: 25
	public partial class MainForm : global::ComponentFactory.Krypton.Toolkit.KryptonForm
	{
		// Token: 0x060000D9 RID: 217 RVA: 0x0000BCB8 File Offset: 0x00009EB8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000BCD8 File Offset: 0x00009ED8
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::MASAGooGLExtractor.MainForm));
			this.splitContainer = new global::System.Windows.Forms.SplitContainer();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.btnTasksLoadTasks = new global::System.Windows.Forms.Button();
			this.btnTasksSaveTasks = new global::System.Windows.Forms.Button();
			this.btnTasksDeleteSelected = new global::System.Windows.Forms.Button();
			this.btnTasksClearSelection = new global::System.Windows.Forms.Button();
			this.btnTasksSelectAll = new global::System.Windows.Forms.Button();
			this.dgvTasks = new global::System.Windows.Forms.DataGridView();
			this.TaskID = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.categories = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.location = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.country_ = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.task_state = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.task_city = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.zip_code = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.btnLocationsClearSelection = new global::System.Windows.Forms.Button();
			this.btnLocationsSelectAll = new global::System.Windows.Forms.Button();
			this.btnLocationsDelete = new global::System.Windows.Forms.Button();
			this.btnLocationsEdit = new global::System.Windows.Forms.Button();
			this.btnLocationsAdd = new global::System.Windows.Forms.Button();
			this.cbLocations = new global::System.Windows.Forms.CheckedListBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.btnCategoriesClearSelection = new global::System.Windows.Forms.Button();
			this.btnCategoriesSelectAll = new global::System.Windows.Forms.Button();
			this.btnCategoriesUpload = new global::System.Windows.Forms.Button();
			this.btnCategoriesDelete = new global::System.Windows.Forms.Button();
			this.btnCategoriesEdit = new global::System.Windows.Forms.Button();
			this.btnCategoriesAdd = new global::System.Windows.Forms.Button();
			this.cbCategories = new global::System.Windows.Forms.CheckedListBox();
			this.dgvResults = new global::System.Windows.Forms.DataGridView();
			this.category = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RealCategory = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.business_name = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.address = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.city = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.state = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.postal_code = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.country = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.phone = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.email = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.website = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.latitude = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.longitude = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.map_link = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.details_link = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.btnExport = new global::System.Windows.Forms.Button();
			this.btnGetData = new global::System.Windows.Forms.Button();
			this.btnStop = new global::System.Windows.Forms.Button();
			this.btnSelectAll = new global::System.Windows.Forms.Button();
			this.btnDeleteAll = new global::System.Windows.Forms.Button();
			this.btnClearSelection = new global::System.Windows.Forms.Button();
			this.btnDeleteSelected = new global::System.Windows.Forms.Button();
			this.menuStrip = new global::System.Windows.Forms.MenuStrip();
			this.startToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.lblDataSource = new global::System.Windows.Forms.ToolStripLabel();
			this.cboDataSource = new global::System.Windows.Forms.ToolStripComboBox();
			this.statusStrip1 = new global::System.Windows.Forms.StatusStrip();
			this.lblInfo = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.tspProgress = new global::System.Windows.Forms.ToolStripProgressBar();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panel4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dgvTasks).BeginInit();
			this.panel3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dgvResults).BeginInit();
			this.panel2.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			base.SuspendLayout();
			this.splitContainer.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new global::System.Drawing.Point(0, 28);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer.Panel1.Controls.Add(this.panel4);
			this.splitContainer.Panel1.Controls.Add(this.panel3);
			this.splitContainer.Panel1.Controls.Add(this.panel1);
			this.splitContainer.Panel2.Controls.Add(this.dgvResults);
			this.splitContainer.Panel2.Controls.Add(this.panel2);
			this.splitContainer.Size = new global::System.Drawing.Size(1184, 711);
			this.splitContainer.SplitterDistance = 286;
			this.splitContainer.TabIndex = 0;
			this.panel4.Controls.Add(this.groupBox3);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new global::System.Drawing.Point(600, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(584, 286);
			this.panel4.TabIndex = 5;
			this.groupBox3.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupBox3.Controls.Add(this.btnTasksLoadTasks);
			this.groupBox3.Controls.Add(this.btnTasksSaveTasks);
			this.groupBox3.Controls.Add(this.btnTasksDeleteSelected);
			this.groupBox3.Controls.Add(this.btnTasksClearSelection);
			this.groupBox3.Controls.Add(this.btnTasksSelectAll);
			this.groupBox3.Controls.Add(this.dgvTasks);
			this.groupBox3.Location = new global::System.Drawing.Point(6, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(566, 271);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Task to do";
			this.btnTasksLoadTasks.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnTasksLoadTasks.Location = new global::System.Drawing.Point(456, 242);
			this.btnTasksLoadTasks.Name = "btnTasksLoadTasks";
			this.btnTasksLoadTasks.Size = new global::System.Drawing.Size(104, 23);
			this.btnTasksLoadTasks.TabIndex = 5;
			this.btnTasksLoadTasks.Text = "Load Tasks";
			this.btnTasksLoadTasks.UseVisualStyleBackColor = true;
			this.btnTasksLoadTasks.Click += new global::System.EventHandler(this.btnTasksLoadTasks_Click);
			this.btnTasksSaveTasks.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnTasksSaveTasks.Location = new global::System.Drawing.Point(346, 242);
			this.btnTasksSaveTasks.Name = "btnTasksSaveTasks";
			this.btnTasksSaveTasks.Size = new global::System.Drawing.Size(104, 23);
			this.btnTasksSaveTasks.TabIndex = 4;
			this.btnTasksSaveTasks.Text = "Save Tasks";
			this.btnTasksSaveTasks.UseVisualStyleBackColor = true;
			this.btnTasksSaveTasks.Click += new global::System.EventHandler(this.btnTasksSaveTasks_Click);
			this.btnTasksDeleteSelected.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnTasksDeleteSelected.Location = new global::System.Drawing.Point(236, 242);
			this.btnTasksDeleteSelected.Name = "btnTasksDeleteSelected";
			this.btnTasksDeleteSelected.Size = new global::System.Drawing.Size(104, 23);
			this.btnTasksDeleteSelected.TabIndex = 3;
			this.btnTasksDeleteSelected.Text = "Delete Selection";
			this.btnTasksDeleteSelected.UseVisualStyleBackColor = true;
			this.btnTasksDeleteSelected.Click += new global::System.EventHandler(this.btnTasksDeleteSelected_Click);
			this.btnTasksClearSelection.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnTasksClearSelection.Location = new global::System.Drawing.Point(142, 242);
			this.btnTasksClearSelection.Name = "btnTasksClearSelection";
			this.btnTasksClearSelection.Size = new global::System.Drawing.Size(88, 23);
			this.btnTasksClearSelection.TabIndex = 2;
			this.btnTasksClearSelection.Text = "Clear Selection";
			this.btnTasksClearSelection.UseVisualStyleBackColor = true;
			this.btnTasksClearSelection.Click += new global::System.EventHandler(this.btnTasksClearSelection_Click);
			this.btnTasksSelectAll.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnTasksSelectAll.Location = new global::System.Drawing.Point(61, 242);
			this.btnTasksSelectAll.Name = "btnTasksSelectAll";
			this.btnTasksSelectAll.Size = new global::System.Drawing.Size(75, 23);
			this.btnTasksSelectAll.TabIndex = 1;
			this.btnTasksSelectAll.Text = "Select All";
			this.btnTasksSelectAll.UseVisualStyleBackColor = true;
			this.btnTasksSelectAll.Click += new global::System.EventHandler(this.btnTasksSelectAll_Click);
			this.dgvTasks.AllowUserToAddRows = false;
			this.dgvTasks.AllowUserToDeleteRows = false;
			this.dgvTasks.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.dgvTasks.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTasks.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[] { this.TaskID, this.categories, this.location, this.country_, this.task_state, this.task_city, this.zip_code });
			this.dgvTasks.Location = new global::System.Drawing.Point(6, 19);
			this.dgvTasks.Name = "dgvTasks";
			this.dgvTasks.ReadOnly = true;
			this.dgvTasks.RowHeadersWidth = 11;
			this.dgvTasks.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvTasks.Size = new global::System.Drawing.Size(542, 217);
			this.dgvTasks.TabIndex = 0;
			this.TaskID.HeaderText = "Task ID";
			this.TaskID.Name = "TaskID";
			this.TaskID.ReadOnly = true;
			this.categories.HeaderText = "Categories";
			this.categories.Name = "categories";
			this.categories.ReadOnly = true;
			this.location.HeaderText = "Location";
			this.location.Name = "location";
			this.location.ReadOnly = true;
			this.country_.HeaderText = "Country";
			this.country_.Name = "country_";
			this.country_.ReadOnly = true;
			this.task_state.HeaderText = "State";
			this.task_state.Name = "task_state";
			this.task_state.ReadOnly = true;
			this.task_city.HeaderText = "City";
			this.task_city.Name = "task_city";
			this.task_city.ReadOnly = true;
			this.zip_code.HeaderText = "Zip Code";
			this.zip_code.Name = "zip_code";
			this.zip_code.ReadOnly = true;
			this.panel3.Controls.Add(this.groupBox2);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new global::System.Drawing.Point(300, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(300, 286);
			this.panel3.TabIndex = 4;
			this.groupBox2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupBox2.Controls.Add(this.btnLocationsClearSelection);
			this.groupBox2.Controls.Add(this.btnLocationsSelectAll);
			this.groupBox2.Controls.Add(this.btnLocationsDelete);
			this.groupBox2.Controls.Add(this.btnLocationsEdit);
			this.groupBox2.Controls.Add(this.btnLocationsAdd);
			this.groupBox2.Controls.Add(this.cbLocations);
			this.groupBox2.Location = new global::System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(282, 271);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Locations";
			this.btnLocationsClearSelection.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnLocationsClearSelection.Location = new global::System.Drawing.Point(183, 242);
			this.btnLocationsClearSelection.Name = "btnLocationsClearSelection";
			this.btnLocationsClearSelection.Size = new global::System.Drawing.Size(93, 23);
			this.btnLocationsClearSelection.TabIndex = 12;
			this.btnLocationsClearSelection.Text = "Clear Selection";
			this.btnLocationsClearSelection.UseVisualStyleBackColor = true;
			this.btnLocationsClearSelection.Click += new global::System.EventHandler(this.btnLocationsClearSelection_Click);
			this.btnLocationsSelectAll.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnLocationsSelectAll.Location = new global::System.Drawing.Point(105, 242);
			this.btnLocationsSelectAll.Name = "btnLocationsSelectAll";
			this.btnLocationsSelectAll.Size = new global::System.Drawing.Size(72, 23);
			this.btnLocationsSelectAll.TabIndex = 11;
			this.btnLocationsSelectAll.Text = "Select All";
			this.btnLocationsSelectAll.UseVisualStyleBackColor = true;
			this.btnLocationsSelectAll.Click += new global::System.EventHandler(this.btnLocationsSelectAll_Click);
			this.btnLocationsDelete.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnLocationsDelete.Location = new global::System.Drawing.Point(183, 213);
			this.btnLocationsDelete.Name = "btnLocationsDelete";
			this.btnLocationsDelete.Size = new global::System.Drawing.Size(93, 23);
			this.btnLocationsDelete.TabIndex = 9;
			this.btnLocationsDelete.Text = "Delete";
			this.btnLocationsDelete.UseVisualStyleBackColor = true;
			this.btnLocationsDelete.Click += new global::System.EventHandler(this.btnLocationsDelete_Click);
			this.btnLocationsEdit.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnLocationsEdit.Location = new global::System.Drawing.Point(105, 213);
			this.btnLocationsEdit.Name = "btnLocationsEdit";
			this.btnLocationsEdit.Size = new global::System.Drawing.Size(72, 23);
			this.btnLocationsEdit.TabIndex = 8;
			this.btnLocationsEdit.Text = "Edit";
			this.btnLocationsEdit.UseVisualStyleBackColor = true;
			this.btnLocationsEdit.Click += new global::System.EventHandler(this.btnLocationsEdit_Click);
			this.btnLocationsAdd.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnLocationsAdd.Location = new global::System.Drawing.Point(6, 213);
			this.btnLocationsAdd.Name = "btnLocationsAdd";
			this.btnLocationsAdd.Size = new global::System.Drawing.Size(93, 52);
			this.btnLocationsAdd.TabIndex = 7;
			this.btnLocationsAdd.Text = "Add Location";
			this.btnLocationsAdd.UseVisualStyleBackColor = true;
			this.btnLocationsAdd.Click += new global::System.EventHandler(this.btnLocationsAdd_Click);
			this.cbLocations.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.cbLocations.CheckOnClick = true;
			this.cbLocations.FormattingEnabled = true;
			this.cbLocations.Location = new global::System.Drawing.Point(6, 19);
			this.cbLocations.Name = "cbLocations";
			this.cbLocations.Size = new global::System.Drawing.Size(270, 169);
			this.cbLocations.TabIndex = 0;
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(300, 286);
			this.panel1.TabIndex = 3;
			this.groupBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupBox1.Controls.Add(this.btnCategoriesClearSelection);
			this.groupBox1.Controls.Add(this.btnCategoriesSelectAll);
			this.groupBox1.Controls.Add(this.btnCategoriesUpload);
			this.groupBox1.Controls.Add(this.btnCategoriesDelete);
			this.groupBox1.Controls.Add(this.btnCategoriesEdit);
			this.groupBox1.Controls.Add(this.btnCategoriesAdd);
			this.groupBox1.Controls.Add(this.cbCategories);
			this.groupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(282, 271);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Categories / keywords";
			this.btnCategoriesClearSelection.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnCategoriesClearSelection.Location = new global::System.Drawing.Point(183, 242);
			this.btnCategoriesClearSelection.Name = "btnCategoriesClearSelection";
			this.btnCategoriesClearSelection.Size = new global::System.Drawing.Size(93, 23);
			this.btnCategoriesClearSelection.TabIndex = 6;
			this.btnCategoriesClearSelection.Text = "Clear Selection";
			this.btnCategoriesClearSelection.UseVisualStyleBackColor = true;
			this.btnCategoriesClearSelection.Click += new global::System.EventHandler(this.btnCategoriesClearSelection_Click);
			this.btnCategoriesSelectAll.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnCategoriesSelectAll.Location = new global::System.Drawing.Point(105, 242);
			this.btnCategoriesSelectAll.Name = "btnCategoriesSelectAll";
			this.btnCategoriesSelectAll.Size = new global::System.Drawing.Size(72, 23);
			this.btnCategoriesSelectAll.TabIndex = 5;
			this.btnCategoriesSelectAll.Text = "Select All";
			this.btnCategoriesSelectAll.UseVisualStyleBackColor = true;
			this.btnCategoriesSelectAll.Click += new global::System.EventHandler(this.btnCategoriesSelectAll_Click);
			this.btnCategoriesUpload.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnCategoriesUpload.Location = new global::System.Drawing.Point(6, 242);
			this.btnCategoriesUpload.Name = "btnCategoriesUpload";
			this.btnCategoriesUpload.Size = new global::System.Drawing.Size(93, 23);
			this.btnCategoriesUpload.TabIndex = 4;
			this.btnCategoriesUpload.Text = "Upload";
			this.btnCategoriesUpload.UseVisualStyleBackColor = true;
			this.btnCategoriesUpload.Click += new global::System.EventHandler(this.btnCategoriesUpload_Click);
			this.btnCategoriesDelete.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnCategoriesDelete.Location = new global::System.Drawing.Point(183, 213);
			this.btnCategoriesDelete.Name = "btnCategoriesDelete";
			this.btnCategoriesDelete.Size = new global::System.Drawing.Size(93, 23);
			this.btnCategoriesDelete.TabIndex = 3;
			this.btnCategoriesDelete.Text = "Delete";
			this.btnCategoriesDelete.UseVisualStyleBackColor = true;
			this.btnCategoriesDelete.Click += new global::System.EventHandler(this.btnCategoriesDelete_Click);
			this.btnCategoriesEdit.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnCategoriesEdit.Location = new global::System.Drawing.Point(105, 213);
			this.btnCategoriesEdit.Name = "btnCategoriesEdit";
			this.btnCategoriesEdit.Size = new global::System.Drawing.Size(72, 23);
			this.btnCategoriesEdit.TabIndex = 2;
			this.btnCategoriesEdit.Text = "Edit";
			this.btnCategoriesEdit.UseVisualStyleBackColor = true;
			this.btnCategoriesEdit.Click += new global::System.EventHandler(this.btnCategoriesEdit_Click);
			this.btnCategoriesAdd.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnCategoriesAdd.Location = new global::System.Drawing.Point(6, 213);
			this.btnCategoriesAdd.Name = "btnCategoriesAdd";
			this.btnCategoriesAdd.Size = new global::System.Drawing.Size(93, 23);
			this.btnCategoriesAdd.TabIndex = 1;
			this.btnCategoriesAdd.Text = "Add Category";
			this.btnCategoriesAdd.UseVisualStyleBackColor = true;
			this.btnCategoriesAdd.Click += new global::System.EventHandler(this.btnCategoriesAdd_Click);
			this.cbCategories.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.cbCategories.CheckOnClick = true;
			this.cbCategories.FormattingEnabled = true;
			this.cbCategories.Location = new global::System.Drawing.Point(6, 19);
			this.cbCategories.Name = "cbCategories";
			this.cbCategories.Size = new global::System.Drawing.Size(270, 169);
			this.cbCategories.TabIndex = 0;
			this.dgvResults.AllowUserToAddRows = false;
			this.dgvResults.AllowUserToDeleteRows = false;
			this.dgvResults.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvResults.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.category, this.RealCategory, this.business_name, this.address, this.city, this.state, this.postal_code, this.country, this.phone, this.email,
				this.website, this.latitude, this.longitude, this.map_link, this.details_link
			});
			this.dgvResults.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dgvResults.Location = new global::System.Drawing.Point(0, 29);
			this.dgvResults.Name = "dgvResults";
			this.dgvResults.ReadOnly = true;
			this.dgvResults.RowHeadersWidth = 11;
			this.dgvResults.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvResults.Size = new global::System.Drawing.Size(1184, 392);
			this.dgvResults.TabIndex = 2;
			this.dgvResults.CellClick += new global::System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellClick);
			this.dgvResults.CellMouseMove += new global::System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResults_CellMouseMove);
			this.category.HeaderText = "Category";
			this.category.Name = "category";
			this.category.ReadOnly = true;
			this.RealCategory.HeaderText = "Real Category";
			this.RealCategory.Name = "RealCategory";
			this.RealCategory.ReadOnly = true;
			this.RealCategory.Width = 150;
			this.business_name.HeaderText = "Business Name";
			this.business_name.Name = "business_name";
			this.business_name.ReadOnly = true;
			this.business_name.Width = 200;
			this.address.HeaderText = "Address";
			this.address.Name = "address";
			this.address.ReadOnly = true;
			this.address.Width = 200;
			this.city.HeaderText = "City";
			this.city.Name = "city";
			this.city.ReadOnly = true;
			this.state.HeaderText = "State";
			this.state.Name = "state";
			this.state.ReadOnly = true;
			this.postal_code.HeaderText = "Postal Code";
			this.postal_code.Name = "postal_code";
			this.postal_code.ReadOnly = true;
			this.country.HeaderText = "Country";
			this.country.Name = "country";
			this.country.ReadOnly = true;
			this.phone.HeaderText = "Phone";
			this.phone.Name = "phone";
			this.phone.ReadOnly = true;
			this.email.HeaderText = "Email";
			this.email.Name = "email";
			this.email.ReadOnly = true;
			this.email.Width = 150;
			this.website.HeaderText = "Website";
			this.website.Name = "website";
			this.website.ReadOnly = true;
			this.website.Width = 200;
			this.latitude.HeaderText = "Latitude";
			this.latitude.Name = "latitude";
			this.latitude.ReadOnly = true;
			this.longitude.HeaderText = "Longitude";
			this.longitude.Name = "longitude";
			this.longitude.ReadOnly = true;
			this.map_link.HeaderText = "Map Link";
			this.map_link.Name = "map_link";
			this.map_link.ReadOnly = true;
			this.map_link.Width = 200;
			this.details_link.HeaderText = "Details Link";
			this.details_link.Name = "details_link";
			this.details_link.ReadOnly = true;
			this.details_link.Width = 200;
			this.panel2.Controls.Add(this.btnExport);
			this.panel2.Controls.Add(this.btnGetData);
			this.panel2.Controls.Add(this.btnStop);
			this.panel2.Controls.Add(this.btnSelectAll);
			this.panel2.Controls.Add(this.btnDeleteAll);
			this.panel2.Controls.Add(this.btnClearSelection);
			this.panel2.Controls.Add(this.btnDeleteSelected);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(1184, 29);
			this.panel2.TabIndex = 3;
			this.btnExport.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnExport.BackColor = global::System.Drawing.Color.FromArgb(0, 128, 128);
			this.btnExport.ForeColor = global::System.Drawing.Color.White;
			this.btnExport.Location = new global::System.Drawing.Point(1062, 3);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new global::System.Drawing.Size(104, 23);
			this.btnExport.TabIndex = 14;
			this.btnExport.Text = "Export";
			this.btnExport.UseVisualStyleBackColor = false;
			this.btnExport.Click += new global::System.EventHandler(this.btnExport_Click);
			this.btnGetData.Image = (global::System.Drawing.Image)resources.GetObject("MASAGooGLExtractor.btnGetData.Image");
			this.btnGetData.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnGetData.Location = new global::System.Drawing.Point(18, 3);
			this.btnGetData.Name = "btnGetData";
			this.btnGetData.Padding = new global::System.Windows.Forms.Padding(10, 0, 10, 0);
			this.btnGetData.Size = new global::System.Drawing.Size(115, 23);
			this.btnGetData.TabIndex = 8;
			this.btnGetData.Text = "Get data";
			this.btnGetData.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnGetData.UseVisualStyleBackColor = true;
			this.btnGetData.Click += new global::System.EventHandler(this.startToolStripMenuItem_Click);
			this.btnStop.Image = (global::System.Drawing.Image)resources.GetObject("MASAGooGLExtractor.btnStop.Image");
			this.btnStop.ImageAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnStop.Location = new global::System.Drawing.Point(139, 3);
			this.btnStop.Name = "btnStop";
			this.btnStop.Padding = new global::System.Windows.Forms.Padding(10, 0, 10, 0);
			this.btnStop.Size = new global::System.Drawing.Size(106, 23);
			this.btnStop.TabIndex = 13;
			this.btnStop.Text = "Stop";
			this.btnStop.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new global::System.EventHandler(this.stopToolStripMenuItem_Click);
			this.btnSelectAll.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnSelectAll.Location = new global::System.Drawing.Point(667, 3);
			this.btnSelectAll.Name = "btnSelectAll";
			this.btnSelectAll.Size = new global::System.Drawing.Size(75, 23);
			this.btnSelectAll.TabIndex = 9;
			this.btnSelectAll.Text = "Select all";
			this.btnSelectAll.UseVisualStyleBackColor = true;
			this.btnSelectAll.Click += new global::System.EventHandler(this.btnSelectAll_Click);
			this.btnDeleteAll.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnDeleteAll.Location = new global::System.Drawing.Point(952, 3);
			this.btnDeleteAll.Name = "btnDeleteAll";
			this.btnDeleteAll.Size = new global::System.Drawing.Size(104, 23);
			this.btnDeleteAll.TabIndex = 12;
			this.btnDeleteAll.Text = "Delete all";
			this.btnDeleteAll.UseVisualStyleBackColor = true;
			this.btnDeleteAll.Click += new global::System.EventHandler(this.btnDeleteAll_Click);
			this.btnClearSelection.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnClearSelection.Location = new global::System.Drawing.Point(748, 3);
			this.btnClearSelection.Name = "btnClearSelection";
			this.btnClearSelection.Size = new global::System.Drawing.Size(88, 23);
			this.btnClearSelection.TabIndex = 10;
			this.btnClearSelection.Text = "Clear selection";
			this.btnClearSelection.UseVisualStyleBackColor = true;
			this.btnClearSelection.Click += new global::System.EventHandler(this.btnClearSelection_Click);
			this.btnDeleteSelected.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnDeleteSelected.Location = new global::System.Drawing.Point(842, 3);
			this.btnDeleteSelected.Name = "btnDeleteSelected";
			this.btnDeleteSelected.Size = new global::System.Drawing.Size(104, 23);
			this.btnDeleteSelected.TabIndex = 11;
			this.btnDeleteSelected.Text = "Delete selected";
			this.btnDeleteSelected.UseVisualStyleBackColor = true;
			this.btnDeleteSelected.Click += new global::System.EventHandler(this.btnDeleteSelected_Click);
			this.menuStrip.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.menuStrip.ImageScalingSize = new global::System.Drawing.Size(20, 20);
			this.menuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.startToolStripMenuItem, this.stopToolStripMenuItem, this.settingsToolStripMenuItem, this.lblDataSource, this.cboDataSource });
			this.menuStrip.Location = new global::System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new global::System.Drawing.Size(1184, 28);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip1";
			this.startToolStripMenuItem.Image = (global::System.Drawing.Image)resources.GetObject("MASAGooGLExtractor.startToolStripMenuItem.Image");
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.Size = new global::System.Drawing.Size(63, 25);
			this.startToolStripMenuItem.Text = "Start";
			this.startToolStripMenuItem.Click += new global::System.EventHandler(this.startToolStripMenuItem_Click);
			this.stopToolStripMenuItem.Image = (global::System.Drawing.Image)resources.GetObject("MASAGooGLExtractor.stopToolStripMenuItem.Image");
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.Size = new global::System.Drawing.Size(63, 25);
			this.stopToolStripMenuItem.Text = "Stop";
			this.stopToolStripMenuItem.Click += new global::System.EventHandler(this.stopToolStripMenuItem_Click);
			this.settingsToolStripMenuItem.Image = (global::System.Drawing.Image)resources.GetObject("MASAGooGLExtractor.settingsToolStripMenuItem.Image");
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new global::System.Drawing.Size(220, 25);
			this.settingsToolStripMenuItem.Text = "Settings | AutoRestart | AutoExport";
			this.settingsToolStripMenuItem.Click += new global::System.EventHandler(this.settingsToolStripMenuItem_Click);
			this.lblDataSource.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblDataSource.Name = "lblDataSource";
			this.lblDataSource.Size = new global::System.Drawing.Size(89, 21);
			this.lblDataSource.Text = "DATA SOURCE:";
			this.cboDataSource.BackColor = global::System.Drawing.Color.FromArgb(0, 105, 92);
			this.cboDataSource.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDataSource.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cboDataSource.ForeColor = global::System.Drawing.Color.White;
			this.cboDataSource.Items.AddRange(new object[] { "Google Maps", "Bing Maps (fast mode)" });
			this.cboDataSource.Name = "cboDataSource";
			this.cboDataSource.Size = new global::System.Drawing.Size(155, 24);
			this.cboDataSource.SelectedIndexChanged += new global::System.EventHandler(this.cboDataSource_SelectedIndexChanged);
			this.statusStrip1.ImageScalingSize = new global::System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.lblInfo, this.tspProgress });
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 739);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new global::System.Drawing.Size(1184, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new global::System.Drawing.Size(85, 17);
			this.lblInfo.Text = "Ready to work!";
			this.tspProgress.Name = "tspProgress";
			this.tspProgress.Size = new global::System.Drawing.Size(300, 16);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1184, 761);
			base.Controls.Add(this.splitContainer);
			base.Controls.Add(this.menuStrip);
			base.Controls.Add(this.statusStrip1);
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("MASAGooGLExtractor.$this.Icon");
			base.MainMenuStrip = this.menuStrip;
			base.Name = "MainForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MASA GooGle Extractor Pro";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			base.Load += new global::System.EventHandler(this.MainForm_Load);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dgvTasks).EndInit();
			this.panel3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dgvResults).EndInit();
			this.panel2.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000081 RID: 129
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.SplitContainer splitContainer;

		// Token: 0x04000083 RID: 131
		public global::System.Windows.Forms.DataGridView dgvResults;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.Button btnExport;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.Button btnGetData;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.Button btnStop;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.Button btnSelectAll;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.Button btnDeleteAll;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.Button btnClearSelection;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.Button btnDeleteSelected;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000092 RID: 146
		public global::System.Windows.Forms.DataGridView dgvTasks;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.Button btnLocationsClearSelection;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.Button btnLocationsSelectAll;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.Button btnLocationsDelete;

		// Token: 0x04000096 RID: 150
		private global::System.Windows.Forms.Button btnLocationsEdit;

		// Token: 0x04000097 RID: 151
		private global::System.Windows.Forms.Button btnLocationsAdd;

		// Token: 0x04000098 RID: 152
		private global::System.Windows.Forms.CheckedListBox cbLocations;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.Button btnCategoriesClearSelection;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.Button btnCategoriesSelectAll;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.Button btnCategoriesUpload;

		// Token: 0x0400009C RID: 156
		private global::System.Windows.Forms.Button btnCategoriesDelete;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.Button btnCategoriesEdit;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.Button btnCategoriesAdd;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.CheckedListBox cbCategories;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.Button btnTasksLoadTasks;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.Button btnTasksSaveTasks;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.Button btnTasksDeleteSelected;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.Button btnTasksClearSelection;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.Button btnTasksSelectAll;

		// Token: 0x040000A5 RID: 165
		public global::System.Windows.Forms.MenuStrip menuStrip;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.DataGridViewTextBoxColumn TaskID;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.DataGridViewTextBoxColumn categories;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.DataGridViewTextBoxColumn location;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.DataGridViewTextBoxColumn country_;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.DataGridViewTextBoxColumn task_state;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.DataGridViewTextBoxColumn task_city;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.DataGridViewTextBoxColumn zip_code;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.StatusStrip statusStrip1;

		// Token: 0x040000B4 RID: 180
		public global::System.Windows.Forms.ToolStripStatusLabel lblInfo;

		// Token: 0x040000B5 RID: 181
		public global::System.Windows.Forms.ToolStripProgressBar tspProgress;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.ToolStripComboBox cboDataSource;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.ToolStripLabel lblDataSource;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.DataGridViewTextBoxColumn category;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.DataGridViewTextBoxColumn RealCategory;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.DataGridViewTextBoxColumn business_name;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.DataGridViewTextBoxColumn address;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.DataGridViewTextBoxColumn city;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.DataGridViewTextBoxColumn state;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.DataGridViewTextBoxColumn postal_code;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.DataGridViewTextBoxColumn country;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.DataGridViewTextBoxColumn phone;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.DataGridViewTextBoxColumn email;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.DataGridViewTextBoxColumn website;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.DataGridViewTextBoxColumn latitude;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.DataGridViewTextBoxColumn longitude;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.DataGridViewTextBoxColumn map_link;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.DataGridViewTextBoxColumn details_link;
	}
}
