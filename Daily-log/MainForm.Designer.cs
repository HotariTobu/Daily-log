namespace Daily_log
{
    partial class window
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(window));
            this.menubar = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMeun = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.todayMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.resetMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.emphasisMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.optionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.wrapMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.keepMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.backupMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.ReadmeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.versionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dateBox = new System.Windows.Forms.ToolStripTextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tree = new System.Windows.Forms.TreeView();
            this.treeItemImageList = new System.Windows.Forms.ImageList(this.components);
            this.text = new System.Windows.Forms.RichTextBox();
            this.popupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.redoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.allMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.trimMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.newButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.split = new System.Windows.Forms.SplitContainer();
            this.startContainer = new System.Windows.Forms.SplitContainer();
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.bottomButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.centerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.userPanel = new System.Windows.Forms.Panel();
            this.passwordCheckBox = new System.Windows.Forms.CheckBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.daySplitMenu = new System.Windows.Forms.ToolStripComboBox();
            this.menubar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.popupMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startContainer)).BeginInit();
            this.startContainer.Panel1.SuspendLayout();
            this.startContainer.Panel2.SuspendLayout();
            this.startContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.bottomButtonPanel.SuspendLayout();
            this.centerPanel.SuspendLayout();
            this.userPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menubar
            // 
            this.menubar.BackColor = System.Drawing.SystemColors.Window;
            this.menubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.optionMenu,
            this.dateBox});
            this.menubar.Location = new System.Drawing.Point(0, 0);
            this.menubar.Name = "menubar";
            this.menubar.Padding = new System.Windows.Forms.Padding(0);
            this.menubar.Size = new System.Drawing.Size(784, 24);
            this.menubar.TabIndex = 0;
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenu,
            this.newMenu,
            this.saveMeun,
            this.passwordMenu,
            this.toolStripMenuItem1,
            this.quitMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(67, 24);
            this.fileMenu.Text = "ファイル(&F)";
            // 
            // openMenu
            // 
            this.openMenu.Image = global::Daily_log.Properties.Resources.Open;
            this.openMenu.Name = "openMenu";
            this.openMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenu.Size = new System.Drawing.Size(190, 22);
            this.openMenu.Text = "開く(&O)...";
            this.openMenu.ToolTipText = "日々ログファイルを開きます。";
            this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
            // 
            // newMenu
            // 
            this.newMenu.Image = global::Daily_log.Properties.Resources.New;
            this.newMenu.Name = "newMenu";
            this.newMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMenu.Size = new System.Drawing.Size(190, 22);
            this.newMenu.Text = "新規作成(&N)...";
            this.newMenu.ToolTipText = "日記を新規作成します。";
            this.newMenu.Click += new System.EventHandler(this.newMenu_Click);
            // 
            // saveMeun
            // 
            this.saveMeun.Image = global::Daily_log.Properties.Resources.Save;
            this.saveMeun.Name = "saveMeun";
            this.saveMeun.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMeun.Size = new System.Drawing.Size(190, 22);
            this.saveMeun.Text = "保存(&S)";
            this.saveMeun.ToolTipText = "日記を日々ログファイルに保存します。";
            this.saveMeun.Click += new System.EventHandler(this.saveMeun_Click);
            // 
            // passwordMenu
            // 
            this.passwordMenu.Image = global::Daily_log.Properties.Resources.Password;
            this.passwordMenu.Name = "passwordMenu";
            this.passwordMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.passwordMenu.Size = new System.Drawing.Size(190, 22);
            this.passwordMenu.Text = "パスワード(&P)...";
            this.passwordMenu.ToolTipText = "パスワードを変更します。";
            this.passwordMenu.Click += new System.EventHandler(this.passwordMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
            // 
            // quitMenu
            // 
            this.quitMenu.Image = global::Daily_log.Properties.Resources.Quit;
            this.quitMenu.Name = "quitMenu";
            this.quitMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitMenu.Size = new System.Drawing.Size(190, 22);
            this.quitMenu.Text = "終了(&Q)";
            this.quitMenu.ToolTipText = "アプリケーションを終了します。";
            this.quitMenu.Click += new System.EventHandler(this.quitMenu_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todayMenu,
            this.resetMenu,
            this.searchMenu,
            this.emphasisMenu});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(57, 24);
            this.editMenu.Text = "編集(&E)";
            // 
            // todayMenu
            // 
            this.todayMenu.Image = global::Daily_log.Properties.Resources.Today;
            this.todayMenu.Name = "todayMenu";
            this.todayMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.todayMenu.Size = new System.Drawing.Size(180, 22);
            this.todayMenu.Text = "今日(&T)";
            this.todayMenu.ToolTipText = "今日の日記を表示します。";
            this.todayMenu.Click += new System.EventHandler(this.todayMenu_Click);
            // 
            // resetMenu
            // 
            this.resetMenu.Image = global::Daily_log.Properties.Resources.Reset;
            this.resetMenu.Name = "resetMenu";
            this.resetMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resetMenu.Size = new System.Drawing.Size(180, 22);
            this.resetMenu.Text = "リセット(&R)";
            this.resetMenu.ToolTipText = "表示されている今日の日記をリセットします。";
            this.resetMenu.Click += new System.EventHandler(this.resetMenu_Click);
            // 
            // searchMenu
            // 
            this.searchMenu.Image = global::Daily_log.Properties.Resources.Search;
            this.searchMenu.Name = "searchMenu";
            this.searchMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.searchMenu.Size = new System.Drawing.Size(180, 22);
            this.searchMenu.Text = "検索(&S)...";
            this.searchMenu.ToolTipText = "日記の中から文字列を検索します。";
            this.searchMenu.Click += new System.EventHandler(this.searchMenu_Click);
            // 
            // emphasisMenu
            // 
            this.emphasisMenu.Checked = true;
            this.emphasisMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.emphasisMenu.Image = global::Daily_log.Properties.Resources.Emphasis;
            this.emphasisMenu.Name = "emphasisMenu";
            this.emphasisMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.emphasisMenu.Size = new System.Drawing.Size(180, 22);
            this.emphasisMenu.Text = "強調表示(&C)";
            this.emphasisMenu.ToolTipText = "検索結果を強調表示します。";
            this.emphasisMenu.Click += new System.EventHandler(this.emphasisMenu_Click);
            // 
            // optionMenu
            // 
            this.optionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontMenu,
            this.wrapMenu,
            this.daySplitMenu,
            this.toolStripMenuItem2,
            this.keepMenu,
            this.toolStripMenuItem3,
            this.backupMenu,
            this.toolStripMenuItem6,
            this.ReadmeMenu,
            this.versionMenu});
            this.optionMenu.Name = "optionMenu";
            this.optionMenu.Size = new System.Drawing.Size(60, 24);
            this.optionMenu.Text = "設定(&O)";
            // 
            // fontMenu
            // 
            this.fontMenu.Image = global::Daily_log.Properties.Resources.Font;
            this.fontMenu.Name = "fontMenu";
            this.fontMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.fontMenu.Size = new System.Drawing.Size(218, 22);
            this.fontMenu.Text = "フォント(&F)...";
            this.fontMenu.ToolTipText = "フォントを設定します。";
            this.fontMenu.Click += new System.EventHandler(this.fontMenu_Click);
            // 
            // wrapMenu
            // 
            this.wrapMenu.Checked = true;
            this.wrapMenu.CheckOnClick = true;
            this.wrapMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wrapMenu.Image = global::Daily_log.Properties.Resources.Wrap;
            this.wrapMenu.Name = "wrapMenu";
            this.wrapMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.wrapMenu.Size = new System.Drawing.Size(218, 22);
            this.wrapMenu.Text = "折り返し(&W)";
            this.wrapMenu.ToolTipText = "表示する日記を折り返します。";
            this.wrapMenu.Click += new System.EventHandler(this.wrapMenu_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(215, 6);
            // 
            // keepMenu
            // 
            this.keepMenu.Checked = true;
            this.keepMenu.CheckOnClick = true;
            this.keepMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keepMenu.Image = global::Daily_log.Properties.Resources.Keep;
            this.keepMenu.Name = "keepMenu";
            this.keepMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.keepMenu.Size = new System.Drawing.Size(218, 22);
            this.keepMenu.Text = "設定を保持(&K)";
            this.keepMenu.ToolTipText = "設定を保持します。";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(215, 6);
            // 
            // backupMenu
            // 
            this.backupMenu.Image = global::Daily_log.Properties.Resources.Backup;
            this.backupMenu.Name = "backupMenu";
            this.backupMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.backupMenu.Size = new System.Drawing.Size(218, 22);
            this.backupMenu.Text = "バックアップを見る(&B)...";
            this.backupMenu.ToolTipText = "バックアップがあれば別ウィンドウで表示します。";
            this.backupMenu.Click += new System.EventHandler(this.backupMenu_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(215, 6);
            // 
            // ReadmeMenu
            // 
            this.ReadmeMenu.Image = global::Daily_log.Properties.Resources.Readme;
            this.ReadmeMenu.Name = "ReadmeMenu";
            this.ReadmeMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.ReadmeMenu.Size = new System.Drawing.Size(218, 22);
            this.ReadmeMenu.Text = "Readme.txt(&R)";
            this.ReadmeMenu.ToolTipText = "Readme.txtを開きます。";
            this.ReadmeMenu.Click += new System.EventHandler(this.ReadmeMenu_Click);
            // 
            // versionMenu
            // 
            this.versionMenu.Image = global::Daily_log.Properties.Resources.Version;
            this.versionMenu.Name = "versionMenu";
            this.versionMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.versionMenu.Size = new System.Drawing.Size(218, 22);
            this.versionMenu.Text = "バージョン情報(&V)...";
            this.versionMenu.ToolTipText = "バージョン情報を表示します。";
            this.versionMenu.Click += new System.EventHandler(this.versionMenu_Click);
            // 
            // dateBox
            // 
            this.dateBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.dateBox.Name = "dateBox";
            this.dateBox.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateBox.Size = new System.Drawing.Size(132, 24);
            this.dateBox.ToolTipText = "表示されている日記の日付です。";
            this.dateBox.Enter += new System.EventHandler(this.dateBox_Enter);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tree);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.text);
            this.splitContainer.Size = new System.Drawing.Size(784, 437);
            this.splitContainer.SplitterDistance = 140;
            this.splitContainer.TabIndex = 1;
            // 
            // tree
            // 
            this.tree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.treeItemImageList;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.ShowLines = false;
            this.tree.ShowPlusMinus = false;
            this.tree.ShowRootLines = false;
            this.tree.Size = new System.Drawing.Size(140, 437);
            this.tree.TabIndex = 0;
            this.tree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeSelect);
            // 
            // treeItemImageList
            // 
            this.treeItemImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeItemImageList.ImageStream")));
            this.treeItemImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeItemImageList.Images.SetKeyName(0, "Year.png");
            this.treeItemImageList.Images.SetKeyName(1, "Month.png");
            this.treeItemImageList.Images.SetKeyName(2, "Day.png");
            // 
            // text
            // 
            this.text.BackColor = System.Drawing.Color.White;
            this.text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text.ContextMenuStrip = this.popupMenu;
            this.text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text.EnableAutoDragDrop = true;
            this.text.Location = new System.Drawing.Point(0, 0);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(640, 437);
            this.text.TabIndex = 0;
            this.text.Text = "";
            this.text.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.text_LinkClicked);
            this.text.TextChanged += new System.EventHandler(this.text_TextChanged);
            this.text.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_KeyUp);
            // 
            // popupMenu
            // 
            this.popupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoMenu,
            this.redoMenu,
            this.toolStripMenuItem4,
            this.allMenu,
            this.toolStripMenuItem5,
            this.trimMenu,
            this.copyMenu,
            this.pasteMenu,
            this.deleteMenu});
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Size = new System.Drawing.Size(177, 170);
            // 
            // undoMenu
            // 
            this.undoMenu.Image = global::Daily_log.Properties.Resources.Undo;
            this.undoMenu.Name = "undoMenu";
            this.undoMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoMenu.Size = new System.Drawing.Size(176, 22);
            this.undoMenu.Text = "元に戻す(U)";
            this.undoMenu.Click += new System.EventHandler(this.undoMenu_Click);
            // 
            // redoMenu
            // 
            this.redoMenu.Image = global::Daily_log.Properties.Resources.Redo;
            this.redoMenu.Name = "redoMenu";
            this.redoMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoMenu.Size = new System.Drawing.Size(176, 22);
            this.redoMenu.Text = "やり直し(R)";
            this.redoMenu.Click += new System.EventHandler(this.redoMenu_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(173, 6);
            // 
            // allMenu
            // 
            this.allMenu.Image = ((System.Drawing.Image)(resources.GetObject("allMenu.Image")));
            this.allMenu.Name = "allMenu";
            this.allMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.allMenu.Size = new System.Drawing.Size(176, 22);
            this.allMenu.Text = "全て選択(A)";
            this.allMenu.Click += new System.EventHandler(this.allMenu_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(173, 6);
            // 
            // trimMenu
            // 
            this.trimMenu.Image = global::Daily_log.Properties.Resources.Cut;
            this.trimMenu.Name = "trimMenu";
            this.trimMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.trimMenu.Size = new System.Drawing.Size(176, 22);
            this.trimMenu.Text = "切り取り(X)";
            this.trimMenu.Click += new System.EventHandler(this.trimMenu_Click);
            // 
            // copyMenu
            // 
            this.copyMenu.Image = global::Daily_log.Properties.Resources.Copy;
            this.copyMenu.Name = "copyMenu";
            this.copyMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyMenu.Size = new System.Drawing.Size(176, 22);
            this.copyMenu.Text = "コピー(C)";
            this.copyMenu.Click += new System.EventHandler(this.copyMenu_Click);
            // 
            // pasteMenu
            // 
            this.pasteMenu.Image = global::Daily_log.Properties.Resources.Paste;
            this.pasteMenu.Name = "pasteMenu";
            this.pasteMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteMenu.Size = new System.Drawing.Size(176, 22);
            this.pasteMenu.Text = "貼り付け(V)";
            this.pasteMenu.Click += new System.EventHandler(this.pasteMenu_Click);
            // 
            // deleteMenu
            // 
            this.deleteMenu.Image = global::Daily_log.Properties.Resources.Delete;
            this.deleteMenu.Name = "deleteMenu";
            this.deleteMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteMenu.Size = new System.Drawing.Size(176, 22);
            this.deleteMenu.Text = "削除(D)";
            this.deleteMenu.Click += new System.EventHandler(this.deleteMenu_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "日々ログファイル|*.lre";
            this.openFileDialog.InitialDirectory = "../";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "日々ログファイル|*.lre";
            // 
            // fontDialog
            // 
            this.fontDialog.ShowEffects = false;
            // 
            // newButton
            // 
            this.newButton.BackgroundImage = global::Daily_log.Properties.Resources.New_Start_0;
            this.newButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.newButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.newButton.FlatAppearance.BorderSize = 0;
            this.newButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.newButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Window;
            this.newButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newButton.Location = new System.Drawing.Point(0, 0);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(161, 100);
            this.newButton.TabIndex = 0;
            this.newButton.Text = "日記を新規作成する";
            this.newButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newMenu_Click);
            this.newButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.newButton_MouseDown);
            this.newButton.MouseEnter += new System.EventHandler(this.newButton_MouseEnter);
            this.newButton.MouseLeave += new System.EventHandler(this.newButton_MouseLeave);
            // 
            // openButton
            // 
            this.openButton.BackgroundImage = global::Daily_log.Properties.Resources.Open_Start_0;
            this.openButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.openButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.openButton.FlatAppearance.BorderSize = 0;
            this.openButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.openButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Window;
            this.openButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openButton.Location = new System.Drawing.Point(0, 0);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(159, 100);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "日々ログファイルを開く";
            this.openButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openMenu_Click);
            this.openButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openButton_MouseDown);
            this.openButton.MouseEnter += new System.EventHandler(this.openButton_MouseEnter);
            this.openButton.MouseLeave += new System.EventHandler(this.openButton_MouseLeave);
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.startContainer);
            this.split.Panel1Collapsed = true;
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.mainContainer);
            this.split.Size = new System.Drawing.Size(784, 461);
            this.split.SplitterDistance = 324;
            this.split.TabIndex = 2;
            // 
            // startContainer
            // 
            this.startContainer.BackColor = System.Drawing.SystemColors.Window;
            this.startContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startContainer.IsSplitterFixed = true;
            this.startContainer.Location = new System.Drawing.Point(0, 0);
            this.startContainer.Name = "startContainer";
            // 
            // startContainer.Panel1
            // 
            this.startContainer.Panel1.Controls.Add(this.newButton);
            // 
            // startContainer.Panel2
            // 
            this.startContainer.Panel2.Controls.Add(this.openButton);
            this.startContainer.Size = new System.Drawing.Size(324, 100);
            this.startContainer.SplitterDistance = 161;
            this.startContainer.TabIndex = 3;
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.mainContainer.Panel1.Controls.Add(this.bottomButtonPanel);
            this.mainContainer.Panel1.Controls.Add(this.centerPanel);
            this.mainContainer.Panel1Collapsed = true;
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.splitContainer);
            this.mainContainer.Panel2.Controls.Add(this.menubar);
            this.mainContainer.Size = new System.Drawing.Size(784, 461);
            this.mainContainer.SplitterDistance = 579;
            this.mainContainer.TabIndex = 0;
            // 
            // bottomButtonPanel
            // 
            this.bottomButtonPanel.Controls.Add(this.cancelButton);
            this.bottomButtonPanel.Controls.Add(this.okButton);
            this.bottomButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomButtonPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.bottomButtonPanel.Location = new System.Drawing.Point(0, 60);
            this.bottomButtonPanel.Name = "bottomButtonPanel";
            this.bottomButtonPanel.Size = new System.Drawing.Size(579, 40);
            this.bottomButtonPanel.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(494, 3);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "キャンセル";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(413, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // centerPanel
            // 
            this.centerPanel.ColumnCount = 3;
            this.centerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.centerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerPanel.Controls.Add(this.userPanel, 1, 1);
            this.centerPanel.Controls.Add(this.userLabel, 0, 0);
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point(0, 0);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.RowCount = 3;
            this.centerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.centerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerPanel.Size = new System.Drawing.Size(579, 100);
            this.centerPanel.TabIndex = 0;
            // 
            // userPanel
            // 
            this.userPanel.Controls.Add(this.passwordCheckBox);
            this.userPanel.Controls.Add(this.passwordBox);
            this.userPanel.Controls.Add(this.nameLabel);
            this.userPanel.Controls.Add(this.nameBox);
            this.userPanel.Location = new System.Drawing.Point(144, 26);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(290, 47);
            this.userPanel.TabIndex = 8;
            // 
            // passwordCheckBox
            // 
            this.passwordCheckBox.AutoSize = true;
            this.passwordCheckBox.Checked = true;
            this.passwordCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.passwordCheckBox.Location = new System.Drawing.Point(5, 27);
            this.passwordCheckBox.Name = "passwordCheckBox";
            this.passwordCheckBox.Size = new System.Drawing.Size(71, 16);
            this.passwordCheckBox.TabIndex = 3;
            this.passwordCheckBox.Text = "パスワード";
            this.passwordCheckBox.UseVisualStyleBackColor = true;
            this.passwordCheckBox.CheckedChanged += new System.EventHandler(this.passwordCheckBox_CheckedChanged);
            // 
            // passwordBox
            // 
            this.passwordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordBox.Location = new System.Drawing.Point(82, 25);
            this.passwordBox.MaxLength = 64;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(207, 19);
            this.passwordBox.TabIndex = 4;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(3, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(29, 12);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "氏名";
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.Location = new System.Drawing.Point(82, 0);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(207, 19);
            this.nameBox.TabIndex = 2;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.userLabel.Location = new System.Drawing.Point(0, 0);
            this.userLabel.Margin = new System.Windows.Forms.Padding(0);
            this.userLabel.Name = "userLabel";
            this.userLabel.Padding = new System.Windows.Forms.Padding(3);
            this.userLabel.Size = new System.Drawing.Size(8, 23);
            this.userLabel.TabIndex = 9;
            // 
            // daySplitMenu
            // 
            this.daySplitMenu.Name = "daySplitMenu";
            this.daySplitMenu.Size = new System.Drawing.Size(121, 23);
            this.daySplitMenu.Text = "4時";
            this.daySplitMenu.ToolTipText = "指定した時刻を日の区切りとします。";
            this.daySplitMenu.DropDown += new System.EventHandler(this.daySplitMenu_DropDown);
            this.daySplitMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.daySplitMenu_KeyDown);
            // 
            // window
            // 
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.split);
            this.Icon = global::Daily_log.Properties.Resources.Icon;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "window";
            this.Text = "日々ログ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.window_FormClosing);
            this.Shown += new System.EventHandler(this.window_Shown);
            this.menubar.ResumeLayout(false);
            this.menubar.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.popupMenu.ResumeLayout(false);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.startContainer.Panel1.ResumeLayout(false);
            this.startContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.startContainer)).EndInit();
            this.startContainer.ResumeLayout(false);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            this.mainContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.bottomButtonPanel.ResumeLayout(false);
            this.centerPanel.ResumeLayout(false);
            this.centerPanel.PerformLayout();
            this.userPanel.ResumeLayout(false);
            this.userPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menubar;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripMenuItem newMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMeun;
        private System.Windows.Forms.ToolStripMenuItem passwordMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem todayMenu;
        private System.Windows.Forms.ToolStripMenuItem resetMenu;
        private System.Windows.Forms.ToolStripMenuItem optionMenu;
        private System.Windows.Forms.ToolStripMenuItem fontMenu;
        private System.Windows.Forms.ToolStripMenuItem wrapMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem keepMenu;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.RichTextBox text;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem versionMenu;
        private System.Windows.Forms.ToolStripMenuItem ReadmeMenu;
        private System.Windows.Forms.ContextMenuStrip popupMenu;
        private System.Windows.Forms.ToolStripMenuItem undoMenu;
        private System.Windows.Forms.ToolStripMenuItem redoMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem allMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem trimMenu;
        private System.Windows.Forms.ToolStripMenuItem copyMenu;
        private System.Windows.Forms.ToolStripMenuItem pasteMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteMenu;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.SplitContainer startContainer;
        private System.Windows.Forms.TableLayoutPanel centerPanel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.CheckBox passwordCheckBox;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.FlowLayoutPanel bottomButtonPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.ImageList treeItemImageList;
        private System.Windows.Forms.ToolStripTextBox dateBox;
        private System.Windows.Forms.ToolStripMenuItem searchMenu;
        private System.Windows.Forms.ToolStripMenuItem emphasisMenu;
        private System.Windows.Forms.ToolStripMenuItem backupMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripComboBox daySplitMenu;
    }
}

