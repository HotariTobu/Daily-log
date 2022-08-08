using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Daily_log
{
    public partial class window : Form
    {
        public window()
        {
            InitializeComponent();

            text.LanguageOption = RichTextBoxLanguageOptions.UIFonts;

            today = DateTime.Today;

            dictionary = new SortedDictionary<DateTime, string>();

            data = false;
            modify = false;

            searchForm = new SearchForm();
        }

        private string[] DayOfWeek = new string[]
        {
            "日",
            "月",
            "火",
            "水",
            "木",
            "金",
            "土",
        };

        private string path;
        private string password;

        private DateTime today;
        private DateTime now;
        private int daySplit { get => int.Parse(daySplitMenu.Text.Trim('時')); set => daySplitMenu.Text = $"{value}時"; }

        private Action userOK;

        private SortedDictionary<DateTime, string> dictionary;

        private bool data;
        private bool modify
        {
            get
            {
                return __modify;
            }
            set
            {
                if (value)
                {

                }
                else
                {
                    Text = "日々ログ - " + path;
                }

                __modify = value;
            }
        }
        private bool __modify;

        private SearchForm searchForm;
        private BackupForm backupForm;

        private void window_Shown(object sender, EventArgs e)
        {
            switchToStart();

            if (File.Exists("設定.txt"))
            {
                StreamReader optionFile = null;

                try
                {
                    optionFile = new StreamReader("設定.txt", Encoding.UTF8);

                    Location = new Point(int.Parse(optionFile.ReadLine()), int.Parse(optionFile.ReadLine()));
                    Size = new Size(int.Parse(optionFile.ReadLine()), int.Parse(optionFile.ReadLine()));

                    splitContainer.SplitterDistance = int.Parse(optionFile.ReadLine());

                    FontFamily fontFamily = new FontFamily(optionFile.ReadLine());
                    float emSize = float.Parse(optionFile.ReadLine());
                    FontStyle fontStyle = (FontStyle)int.Parse(optionFile.ReadLine());
                    Font font = new Font(fontFamily, emSize, fontStyle);

                    text.Font = font;
                    fontDialog.Font = font;

                    bool wordWrap = bool.Parse(optionFile.ReadLine());
                    text.WordWrap = wordWrap;
                    wrapMenu.Checked = wordWrap;

                    daySplit = int.Parse(optionFile.ReadLine());

                    path = optionFile.ReadLine();
                    if (path != null && path.Length != 0 && File.Exists(path))
                    {
                        fileLoad(path);
                    }
                    else
                    {
                        path = null;
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show("設定.txtの内容が壊れています。", "設定の読み込みに失敗");
                }
                finally
                {
                    if (optionFile != null)
                    {
                        optionFile.Close();
                    }

                    keepMenu.Checked = true;
                }
            }
            else
            {
                keepMenu.Checked = false;
            }

            int splitTime = this.daySplit;
            bool afternoon = splitTime > 12;
            if ((DateTime.Now.CompareTo(today.AddHours(splitTime)) < 0) ^ afternoon)
            {
                today = today.AddDays(afternoon ? 1 : -1);
            }
        }

        private void window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modify && MessageBox.Show("保存せずに終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else if (keepMenu.Checked)
            {
                StreamWriter optionFile = new StreamWriter("設定.txt", false, Encoding.UTF8);

                optionFile.WriteLine(Location.X);
                optionFile.WriteLine(Location.Y);
                optionFile.WriteLine(Size.Width);
                optionFile.WriteLine(Size.Height);

                optionFile.WriteLine(splitContainer.SplitterDistance);

                optionFile.WriteLine(text.Font.FontFamily.Name);
                optionFile.WriteLine(text.Font.Size);
                optionFile.WriteLine(text.Font.Style.GetHashCode());

                optionFile.WriteLine(wrapMenu.Checked);
                optionFile.WriteLine(daySplit);

                optionFile.WriteLine(path);

                optionFile.Close();
            }
            else
            {
                File.Delete("設定.txt");
            }
        }

        private void switchToStart()
        {
            AcceptButton = null;

            split.Panel1Collapsed = false;
            split.Panel2Collapsed = true;
        }

        private void switchToUser(string title)
        {
            AcceptButton = okButton;

            split.Panel1Collapsed = true;
            split.Panel2Collapsed = false;
            mainContainer.Panel1Collapsed = false;
            mainContainer.Panel2Collapsed = true;

            userLabel.Text = title;
            passwordCheckBox.Checked = true;
            passwordBox.Text = "";
        }

        private void switchToMain()
        {
            AcceptButton = null;

            split.Panel1Collapsed = true;
            split.Panel2Collapsed = false;
            mainContainer.Panel1Collapsed = true;
            mainContainer.Panel2Collapsed = false;

            text.Focus();
        }

        private void fileLoad(string path)
        {
            userOK = new Action(() =>
            {
                try
                {
                    SortedDictionary<DateTime, string> dataBuffer = new SortedDictionary<DateTime, string>();

                    LRELoader.read(path, LRELoader.UTF8.GetBytes(passwordBox.Text), dataBuffer);

                    this.path = path;
                    password = passwordBox.Text;

                    now = new DateTime();

                    dictionary = dataBuffer;
                    tree.Nodes.Clear();

                    foreach (DateTime date in dictionary.Keys)
                    {
                        addTreeNode(date);
                    }

                    data = true;
                    modify = false;

                    todayMenu_Click(null, null);

                    userOK = null;

                    switchToMain();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "認証失敗", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    passwordBox.Text = "";
                }
            });

            switchToUser("認証");
            nameBox.Text = Path.GetFileNameWithoutExtension(path);
            passwordBox.Focus();
        }

        private void updateDateBox()
        {
            dateBox.Text = $"{now.Year:0000}年{now.Month:00}月{now.Day:00}日({DayOfWeek[(int)now.DayOfWeek]})";
        }

        private void keepToday()
        {
            if (now.Equals(today))
            {
                if (text.Text.Length == 0)
                {
                    if (dictionary.ContainsKey(now))
                    {
                        dictionary.Remove(now);
                        removeTreeNode(now);
                    }
                }
                else
                {
                    if (dictionary.ContainsKey(now))
                    {
                        dictionary[now] = text.Text;
                    }
                    else
                    {
                        dictionary.Add(now, text.Text);
                        addTreeNode(now);
                    }
                }
            }
        }

        private void changeText(string text)
        {
            bool temp = modify;

            modify = true;
            this.text.Text = text;

            modify = temp;
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            if (modify && MessageBox.Show("保存せずに開きますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileLoad(openFileDialog.FileName);
            }
        }

        private void openButton_MouseDown(object sender, MouseEventArgs e)
        {
            openButton.BackgroundImage = Daily_log.Properties.Resources.Open_Start_2;
        }

        private void openButton_MouseEnter(object sender, EventArgs e)
        {
            openButton.BackgroundImage = Daily_log.Properties.Resources.Open_Start_1;
        }

        private void openButton_MouseLeave(object sender, EventArgs e)
        {
            openButton.BackgroundImage = Daily_log.Properties.Resources.Open_Start_0;
        }

        private void newMenu_Click(object sender, EventArgs e)
        {
            if (modify && MessageBox.Show("保存せずに新規作成しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }

            userOK = new Action(() =>
            {
                saveFileDialog.FileName = nameBox.Text;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    password = passwordBox.Text;

                    now = new DateTime();

                    dictionary.Clear();
                    tree.Nodes.Clear();

                    data = true;
                    modify = false;

                    todayMenu_Click(null, null);

                    userOK = null;

                    switchToMain();
                }
            });

            switchToUser("新規作成");
            nameBox.Text = "";
            nameBox.Focus();
        }

        private void newButton_MouseDown(object sender, MouseEventArgs e)
        {
            newButton.BackgroundImage = Daily_log.Properties.Resources.New_Start_2;
        }

        private void newButton_MouseEnter(object sender, EventArgs e)
        {
            newButton.BackgroundImage = Daily_log.Properties.Resources.New_Start_1;
        }

        private void newButton_MouseLeave(object sender, EventArgs e)
        {
            newButton.BackgroundImage = Daily_log.Properties.Resources.New_Start_0;
        }

        private void saveMeun_Click(object sender, EventArgs e)
        {
            if (data && modify)
            {
                keepToday();

                try
                {
                    LRELoader.write(path, LRELoader.UTF8.GetBytes(password), dictionary);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    return;
                }

                modify = false;
            }
        }

        private void passwordMenu_Click(object sender, EventArgs e)
        {
            if (data)
            {
                userOK = new Action(() =>
                {
                    if (password.Equals(passwordBox.Text))
                    {
                        userOK = new Action(() =>
                        {
                            password = passwordBox.Text;

                            text_TextChanged(null, null);

                            userOK = null;

                            switchToMain();
                        });

                        switchToUser("パスワードの変更");
                        passwordBox.Focus();
                    }
                    else
                    {
                        MessageBox.Show("パスワードが違います。", "認証失敗", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        passwordBox.Text = "";
                    }
                });

                switchToUser("認証");
                nameBox.Text = Path.GetFileNameWithoutExtension(path);
                passwordBox.Focus();
            }
        }

        private void quitMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void todayMenu_Click(object sender, EventArgs e)
        {
            if (data && !now.Equals(today))
            {
                now = today;

                if (dictionary.ContainsKey(now))
                {
                    changeText(dictionary[now]);
                }
                else
                {
                    changeText("");
                }

                text.ReadOnly = false;

                updateDateBox();
            }
        }

        private void resetMenu_Click(object sender, EventArgs e)
        {
            text.ResetText();
        }

        private Color emphaticColor = Color.Yellow;
        private Regex regex;

        private void emphasizeText()
        {
            if (regex == null || !emphasisMenu.Checked)
            {
                return;
            }

            bool temp = modify;
            modify = true;

            int start = text.SelectionStart;
            int length = text.SelectionLength;

            Match match;
            switch (searchForm.range)
            {
                case SearchForm.SearchRange.Selection:
                    {
                        match = regex.Match(text.SelectedText);
                        while (match.Success)
                        {
                            text.SelectionStart = start + match.Index;
                            text.SelectionLength = match.Length;
                            text.SelectionBackColor = emphaticColor;

                            match = match.NextMatch();
                        }
                    }
                    break;
                case SearchForm.SearchRange.OneDay:
                    match = regex.Match(text.Text);
                    while (match.Success)
                    {
                        text.SelectionStart = match.Index;
                        text.SelectionLength = match.Length;
                        text.SelectionBackColor = emphaticColor;

                        match = match.NextMatch();
                    }
                    break;
                case SearchForm.SearchRange.All:
                    foreach (TreeNode yearNode in tree.Nodes)
                    {
                        foreach (TreeNode monthNode in yearNode.Nodes)
                        {
                            foreach (TreeNode dayNode in monthNode.Nodes)
                            {
                                DateTime date = GetDate(dayNode);
                                if (dictionary.ContainsKey(date) && regex.IsMatch(dictionary[date]))
                                {
                                    yearNode.BackColor = emphaticColor;
                                    monthNode.BackColor = emphaticColor;
                                    dayNode.BackColor = emphaticColor;
                                }
                            }
                        }
                    }
                    goto case SearchForm.SearchRange.OneDay;
                default:
                    break;
            }

            text.SelectionStart = start;
            text.SelectionLength = length;

            modify = temp;
        }

        private void releaseEmphasis()
        {
            bool temp = modify;
            modify = true;

            foreach (TreeNode yearNode in tree.Nodes)
            {
                yearNode.BackColor = tree.BackColor;
                foreach (TreeNode monthNode in yearNode.Nodes)
                {
                    monthNode.BackColor = tree.BackColor;
                    foreach (TreeNode dayNode in monthNode.Nodes)
                    {
                        dayNode.BackColor = tree.BackColor;
                    }
                }
            }
            releaseEmphasisOfText();

            modify = temp;
        }

        private void releaseEmphasisOfText()
        {
            bool temp = modify;
            modify = true;

            int start = text.SelectionStart;
            int length = text.SelectionLength;

            text.SelectionStart = 0;
            text.SelectionLength = text.TextLength;
            text.SelectionBackColor = Color.White;

            text.SelectionStart = start;
            text.SelectionLength = length;

            modify = temp;
        }

        private void searchMenu_Click(object sender, EventArgs e)
        {
            if (text.SelectionLength > 0)
            {
                searchForm.searchStr = text.SelectedText;
            }

            if (searchForm.ShowDialog() == DialogResult.OK && searchForm.searchStr.Length > 0)
            {
                regex = new Regex(searchForm.searchStr, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);

                releaseEmphasis();
                emphasizeText();
            }
        }

        private void emphasisMenu_Click(object sender, EventArgs e)
        {
            emphasisMenu.Checked = !emphasisMenu.Checked;
            if (emphasisMenu.Checked)
            {
                emphasizeText();
            }
            else
            {
                releaseEmphasis();
            }
        }

        private void fontMenu_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                bool temp = modify;

                modify = true;
                text.Font = fontDialog.Font;

                modify = temp;
            }
        }

        private void wrapMenu_Click(object sender, EventArgs e)
        {
            text.WordWrap = wrapMenu.Checked;
        }

        private void backupMenu_Click(object sender, EventArgs e)
        {
            byte[] data = null;
            LRELoader.backupRead(Path.GetFileNameWithoutExtension(path) + ".bkp", LRELoader.UTF8.GetBytes(password), out data);
            if (data == null)
            {
                MessageBox.Show("バックアップは存在しません。", "バックアップ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (backupForm == null || backupForm.IsDisposed)
                {
                    backupForm = new BackupForm();
                    backupForm.BoxText = LRELoader.UTF8.GetString(data);
                    backupForm.Show(this);
                }
            }
        }

        private void ReadmeMenu_Click(object sender, EventArgs e)
        {
            if (File.Exists("Readme.txt"))
            {
                using (var process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = "Readme.txt",
                    };
                    process.Start();
                }
            }
        }

        private void versionMenu_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void undoMenu_Click(object sender, EventArgs e)
        {
            text.Undo();
        }

        private void redoMenu_Click(object sender, EventArgs e)
        {
            text.Redo();
        }

        private void allMenu_Click(object sender, EventArgs e)
        {
            if (text.SelectionLength == 0)
            {
                text.SelectAll();
            }
            else
            {
                text.Select(text.SelectionStart, 0);
            }
        }

        private void trimMenu_Click(object sender, EventArgs e)
        {
            text.Cut();
        }

        private void copyMenu_Click(object sender, EventArgs e)
        {
            text.Copy();
        }

        private void pasteMenu_Click(object sender, EventArgs e)
        {
            text.Paste();
        }

        private void deleteMenu_Click(object sender, EventArgs e)
        {
            text.SelectedText = "";
        }

        private void passwordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordBox.Enabled = passwordCheckBox.Checked;
            passwordBox.Text = "";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (userOK == null)
            {
                MessageBox.Show("処理が定義されていません。", "OKボタン", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                userOK();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (data)
            {
                switchToMain();
            }
            else
            {
                switchToStart();
            }
        }

        private void dateBox_Enter(object sender, EventArgs e)
        {
            text.Focus();
        }

        private void addTreeNode(DateTime date)
        {
            string year = $"{date.Year:0000}年";
            TreeNode yearNode;
            if (tree.Nodes.ContainsKey(year))
            {
                yearNode = tree.Nodes[year];
            }
            else
            {
                yearNode = new TreeNode(year);
                yearNode.Name = year;
                yearNode.ImageIndex = 0;
                yearNode.SelectedImageIndex = 0;
                tree.Nodes.Add(yearNode);
            }

            string month = $"{date.Month:00}月";
            TreeNode monthNode;
            if (yearNode.Nodes.ContainsKey(month))
            {
                monthNode = yearNode.Nodes[month];
            }
            else
            {
                monthNode = new TreeNode(month);
                monthNode.Name = month;
                monthNode.ImageIndex = 1;
                monthNode.SelectedImageIndex = 1;
                yearNode.Nodes.Add(monthNode);
            }

            string day = $"{date.Day:00}日({DayOfWeek[(int)date.DayOfWeek]})";
            TreeNode dayNode;
            if (monthNode.Nodes.ContainsKey(day))
            {
                dayNode = monthNode.Nodes[day];
            }
            else
            {
                dayNode = new TreeNode(day);
                dayNode.Name = day;
                dayNode.ImageIndex = 2;
                dayNode.SelectedImageIndex = 2;
                monthNode.Nodes.Add(dayNode);
            }
        }

        private void removeTreeNode(DateTime date)
        {
            string year = $"{date.Year:0000}年";
            TreeNode yearNode;
            if (tree.Nodes.ContainsKey(year))
            {
                yearNode = tree.Nodes[year];

                string month = $"{date.Month:00}月";
                TreeNode monthNode;
                if (yearNode.Nodes.ContainsKey(month))
                {
                    monthNode = yearNode.Nodes[month];

                    string day = $"{date.Day:00}日({DayOfWeek[(int)date.DayOfWeek]})";
                    if (monthNode.Nodes.ContainsKey(day))
                    {
                        monthNode.Nodes.RemoveByKey(day);
                    }

                    if (monthNode.Nodes.Count == 0)
                    {
                        yearNode.Nodes.Remove(monthNode);
                    }
                }

                if (yearNode.Nodes.Count == 0)
                {
                    tree.Nodes.Remove(yearNode);
                }
            }
        }

        private void tree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;

            if (data && node != null && e.Action == TreeViewAction.ByMouse)
            {
                if (node.Level == 2)
                {
                    keepToday();

                    now = GetDate(node);

                    if (dictionary.ContainsKey(now))
                    {
                        changeText(dictionary[now]);
                    }
                    else
                    {
                        changeText("");
                    }

                    releaseEmphasisOfText();
                    if (emphasisMenu.Checked && node.BackColor == emphaticColor)
                    {
                        emphasizeText();
                    }

                    text.ReadOnly = !now.Equals(today);

                    updateDateBox();
                }
                else
                {
                    node.Toggle();
                }
            }

            e.Cancel = true;

            text.Focus();
        }

        private DateTime GetDate(TreeNode node)
        {
            DateTime result = today;

            try
            {
                if (node.Level == 2)
                {
                    result = new DateTime(int.Parse(node.Parent.Parent.Text.Substring(0, 4)), int.Parse(node.Parent.Text.Substring(0, 2)), int.Parse(node.Text.Substring(0, 2)));
                }
                else
                {
                    throw new ArgumentException("ノードの階層が違いました。", "node.Level");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ツリー", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            return result;
        }

        private int changeStamp;

        private async void text_TextChanged(object sender, EventArgs e)
        {
            if (data)
            {
                if (!modify)
                {
                    modify = true;

                    Text = Text.Insert(0, "*");
                }

                DateTime currentTime = DateTime.Now;
                int stamp = currentTime.Hour * 3600 + currentTime.Minute * 60 + currentTime.Second;
                string currentText = text.Text;
                if ((stamp - changeStamp) > 5 && now.Equals(today) && !string.IsNullOrWhiteSpace(currentText))
                {
                    changeStamp = stamp;
                    await Task.Run(() =>
                    {
                        LRELoader.backupWrite(Path.GetFileNameWithoutExtension(path) + ".bkp", LRELoader.UTF8.GetBytes(password), LRELoader.UTF8.GetBytes(currentText));
                    });
                }
            }
        }

        private void text_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "リンク", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void text_KeyUp(object sender, KeyEventArgs e)
        {
            if (data && e.Alt && e.Control && e.Shift && e.KeyCode == Keys.Q)
            {
                Ura ura = new Ura();
                ura.uraYear = now.Year - 2000;
                ura.uraMonth = now.Month;
                ura.uraDay = now.Day;
                if (ura.ShowDialog() != DialogResult.Cancel)
                {
                    DateTime temp = now;

                    now = new DateTime((int)ura.uraYear + 2000, (int)ura.uraMonth, (int)ura.uraDay);

                    if (dictionary.ContainsKey(now))
                    {
                        dictionary[now] = text.Text;
                    }
                    else
                    {
                        dictionary.Add(now, text.Text);
                        addTreeNode(now);
                    }
                    tree.Sort();

                    if (dictionary.ContainsKey(temp))
                    {
                        dictionary.Remove(temp);
                        removeTreeNode(temp);
                    }

                    tree.SelectedNode = tree.Nodes[$"{now.Year:0000}年"].Nodes[$"{now.Month:00}月"].Nodes[$"{now.Day:00}日({DayOfWeek[(int)now.DayOfWeek]})"];

                    if (!modify)
                    {
                        modify = true;

                        Text = Text.Insert(0, "*");
                    }

                    text.ReadOnly = !now.Equals(today);

                    updateDateBox();
                }
            }
        }

        private void daySplitMenu_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void daySplitMenu_DropDown(object sender, EventArgs e)
        {
            daySplitMenu.Items.Clear();
            int start = daySplit + 22;
            string vs = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                vs += (start + i) % 24 + "時,";
            }
            daySplitMenu.Items.AddRange(vs.TrimEnd(',').Split(','));
        }
    }
}
