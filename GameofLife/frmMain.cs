using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameofLife
{
    public partial class frmMain : Form
    {
        Zelle[,] zellen = new Zelle[0, 0];
        bool isGameRunning = false;
        bool supressNUPValueChange = false;
        Timer t;
        int ticks = 0;

        BindingList<RuleSet> _rulesets = new BindingList<RuleSet>();
        BindingList<StatisticEntry> _stats = new BindingList<StatisticEntry>();

        public frmMain()
        {

            InitializeComponent();
            cbRuleSet.DataSource = _rulesets;
            cbRuleSet.DisplayMember = "Name";
            LoadRuleSets();
            this.DoubleBuffered = true;
            canvas.Blocks = false;
            UpdateArray();
            canvas.Zellen = zellen;
            canvas.Refresh();
        }

        public void Tick()
        {
            System.Drawing.Region r = new System.Drawing.Region();
            int living = 0;
            var ruleset = ((RuleSet)cbRuleSet.SelectedItem);
            for (int x = 0; x <= zellen.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= zellen.GetUpperBound(1); y++)
                {
                    zellen[x, y].Aenderung = ruleset.applyRuleset(zellen[x, y].Status, getLivingNeighbours(x, y));
                }
            }
             
            for (int x = 0; x <= zellen.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= zellen.GetUpperBound(1); y++)
                {
                    if (zellen[x, y].Status != zellen[x, y].Aenderung)
                    {
                        zellen[x, y].hasChanged = true;
                        zellen[x, y].Status = zellen[x, y].Aenderung;
                        r.Union(canvas.getRectangle(x, y));
                    }
                    living += zellen[x, y].Status == ZellenStatus.Lebt ? 1 : 0;
                }
            }
            ticks++;
            lblTicks.Text = ticks.ToString();
            lblLivingCells.Text = living.ToString();
            canvas.Invalidate(r);
            if (cbLimit.Checked && ticks >= nupLimit.Value)
            {
                Stop();
            }
            if (cbEnableStats.Checked)
            {
                _stats.Add(new StatisticEntry(ticks, living));
            }
        }

        #region Update Methoden

        private static Pen pblack = new Pen(Color.Black, 1f);
        private static Brush bblue = new SolidBrush(Color.Blue);
        private static Brush bwhite = new SolidBrush(Color.White);

        private void UpdateArray()
        {
            Zelle[,] temp = new Zelle[(int)nupColums.Value, (int)nupRows.Value];
            for (int x1 = 0; x1 <= temp.GetUpperBound(0); x1++)
            {
                for (int y1 = 0; y1 <= temp.GetUpperBound(1); y1++)
                {
                    if (x1 <= zellen.GetUpperBound(0) && y1 <= zellen.GetUpperBound(1))
                        temp[x1, y1] = zellen[x1, y1];
                    else
                        temp[x1, y1] = new Zelle();
                    temp[x1, y1].hasChanged = true;
                }
            }
            zellen = temp;
            canvas.Zellen = zellen;
        }
        #endregion

        #region Event Handler

        private void nupColums_ValueChanged(object sender, EventArgs e)
        {
            if (!supressNUPValueChange)
            {
                canvas.Colums = (int)nupColums.Value;
                UpdateArray();
                canvas.Refresh();
            }
        }

        private void nupRows_ValueChanged(object sender, EventArgs e)
        {
            if (!supressNUPValueChange)
            {
                canvas.Rows = (int)nupRows.Value;
                UpdateArray();
                canvas.Refresh();
            }
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isGameRunning)
            {
                PointF p = canvas.getIndex(e.X, e.Y);
                Zelle z = zellen[(int)p.X, (int)p.Y];
                z.Status = z.Status == ZellenStatus.Lebt ? ZellenStatus.Tot : ZellenStatus.Lebt;
                z.Aenderung = z.Status;
                z.hasChanged = true;
                canvas.Refresh();
            }
        }

        private bool _mousedrag = false;
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            _mousedrag = true;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isGameRunning && _mousedrag)
            {
                PointF p = canvas.getIndex(e.X, e.Y);
                Zelle z = zellen[(int)p.X, (int)p.Y];
                if (z.Status != ZellenStatus.Lebt)
                {
                    z.Status = ZellenStatus.Lebt;
                    z.Aenderung = ZellenStatus.Lebt;
                    z.hasChanged = true;
                    canvas.Refresh();
                }
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            _mousedrag = false;
        }

        private void canvas_MouseLeave(object sender, EventArgs e)
        {
            _mousedrag = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int x = 0; x <= zellen.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= zellen.GetUpperBound(1); y++)
                {
                    zellen[x, y].Status = ZellenStatus.Tot;
                    zellen[x, y].Aenderung = ZellenStatus.Tot;
                }
            }
            lblLivingCells.Text = "0";
            _stats.Clear();
            canvas.DrawAll();
            canvas.Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Tick(object sender, EventArgs e)
        {
            Tick();
        }

        private void btnResetTicks_Click(object sender, EventArgs e)
        {
            ticks = 0;
            lblTicks.Text = ticks.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData data = new SaveData();
            data.Zellen = zellen;
            data.Rows = canvas.Rows;
            data.Colums = canvas.Colums;
            data.Intervall = (int)nupIntervall.Value;
            data.Ticks = ticks;
            data.Torus = cbTorus.Checked;
            data.Guid = ((RuleSet)cbRuleSet.SelectedItem).Guid;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.DefaultExt = "gol";
                sfd.Filter = "Game of Life|*.gol|Game of Life Text|*.got|All files|*.*";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(sfd.FileName, System.IO.FileMode.Create))
                        {
                            switch (System.IO.Path.GetExtension(sfd.FileName))
                            {
                                case ".gol":
                                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ser = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                                    ser.Serialize(fs, data);
                                    break;
                                case ".got":
                                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                                    for (int y = 0; y <= zellen.GetUpperBound(1); y++)
                                    {
                                        for (int x = 0; x <= zellen.GetUpperBound(0); x++)
                                        {
                                            sw.Write(zellen[x, y].Status == ZellenStatus.Lebt ? '1' : '0');
                                        }
                                        sw.Write("\n");
                                    }
                                    sw.Flush();
                                    break;
                            }

                        }
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("Error while saving data! Please try again!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.DefaultExt = "gol";
                ofd.Filter = "Game of Life|*.gol|Game of Life Text|*.got|All files|*.*";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(ofd.FileName, System.IO.FileMode.Open))
                        {
                            switch (System.IO.Path.GetExtension(ofd.FileName))
                            {
                                case ".gol":
                                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ser = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                                    SaveData data = (SaveData)ser.Deserialize(fs);
                                    zellen = data.Zellen;
                                    for (int x = 0; x <= zellen.GetUpperBound(0); x++)
                                    {
                                        for (int y = 0; y <= zellen.GetUpperBound(1); y++)
                                        {
                                            zellen[x, y].Aenderung = zellen[x, y].Status;
                                            zellen[x, y].hasChanged = true;
                                        }
                                    }
                                    canvas.Rows = data.Rows;
                                    canvas.Colums = data.Colums;
                                    canvas.Zellen = zellen;

                                    supressNUPValueChange = true;
                                    nupColums.Value = data.Colums;
                                    nupRows.Value = data.Rows;
                                    supressNUPValueChange = false;
                                    nupIntervall.Value = data.Intervall;
                                    cbTorus.Checked = data.Torus;
                                    ticks = data.Ticks;
                                    lblTicks.Text = ticks.ToString();

                                    if (String.IsNullOrEmpty(data.Guid))
                                        cbRuleSet.SelectedItem = _rulesets.Select(x => x.Guid == "C99D7E0D-8115-4243-B79B-7758309B0022").First();
                                    else
                                        cbRuleSet.SelectedItem = _rulesets.Select(x => x.Guid == data.Guid).First();

                                    canvas.DrawAll();
                                    canvas.Refresh();

                                    this.Text = "Game of Life - " + System.IO.Path.GetFileName(fs.Name);
                                    break;
                                case ".got":
                                    System.IO.StreamReader reader = new System.IO.StreamReader(fs);
                                    List<string> lines = new List<string>();
                                    while (!reader.EndOfStream)
                                        lines.Add(reader.ReadLine());
                                    Zelle[,] buffer = new Zelle[lines.Max<string, int>(x => x.Length), lines.Count];
                                    for (int i = 0; i < lines.Count; i++)
                                    {
                                        string line = lines[i].Trim();
                                        for (int q = 0; q < line.Length; q++)
                                        {
                                            buffer[q, i] = new Zelle();
                                            buffer[q, i].hasChanged = true;
                                            buffer[q, i].Status = line[q] == '1' ? ZellenStatus.Lebt : ZellenStatus.Tot;
                                            buffer[q, i].Aenderung = buffer[q, i].Status;
                                        }
                                    }
                                    canvas.Rows = buffer.GetUpperBound(1) + 1;
                                    canvas.Colums = buffer.GetUpperBound(0) + 1;
                                    supressNUPValueChange = true;
                                    nupColums.Value = buffer.GetUpperBound(0) + 1;
                                    nupRows.Value = buffer.GetUpperBound(1) + 1;
                                    supressNUPValueChange = false;

                                    zellen = buffer;
                                    canvas.Zellen = buffer;

                                    canvas.DrawAll();
                                    canvas.Refresh();
                                    this.Text = "Game of Life - " + System.IO.Path.GetFileName(fs.Name);
                                    break;
                            }
                        }
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("Error while loading data! Please try again!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void cbBlocks_CheckedChanged(object sender, EventArgs e)
        {
            canvas.Blocks = cbBlocks.Checked;
            canvas.ClearAll();
            canvas.DrawAll();
            canvas.Refresh();
        }

        private void cbLimit_CheckedChanged(object sender, EventArgs e)
        {
            nupLimit.Enabled = cbLimit.Checked;
        }

        private void cbEnableStats_CheckedChanged(object sender, EventArgs e)
        {
            btnShowStatistics.Enabled = cbEnableStats.Checked;
        }

        private bool wasminimized = false;
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) wasminimized = true;
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized && wasminimized)
            {
                wasminimized = false;
                canvas.DrawBackground();
                canvas.DrawAll();
                canvas.Refresh();
            }
        }


        frmStats _frmstats = null;
        private void btnShowStatistics_Click(object sender, EventArgs e)
        {
            if (_frmstats == null || _frmstats.IsDisposed)
                _frmstats = new frmStats(this, ref _stats);
            _frmstats.Show();
        }

        private void btnReloadRuleSets_Click(object sender, EventArgs e)
        {
            LoadRuleSets();
        }
        #endregion

        #region Methods

        private void Start()
        {
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            btnClear.Enabled = false;
            btnResetTicks.Enabled = false;
            btnLoad.Enabled = false;
            btnSave.Enabled = false;
            nupColums.Enabled = false;
            nupRows.Enabled = false;
            nupIntervall.Enabled = false;
            cbTorus.Enabled = false;
            cbLimit.Enabled = false;
            nupLimit.Enabled = false;
            cbRuleSet.Enabled = false;
            btnReloadRuleSets.Enabled = false;
            isGameRunning = true;
            this.AcceptButton = btnStop;

            t = new Timer();
            t.Interval = (int)nupIntervall.Value;
            t.Tick += Tick;
            t.Start();
        }

        private void Stop()
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            btnResetTicks.Enabled = true;
            btnClear.Enabled = true;
            btnLoad.Enabled = true;
            btnSave.Enabled = true;
            nupColums.Enabled = true;
            nupRows.Enabled = true;
            nupIntervall.Enabled = true;
            cbTorus.Enabled = true;
            cbLimit.Enabled = true;
            nupLimit.Enabled = cbLimit.Checked;
            cbRuleSet.Enabled = true;
            btnReloadRuleSets.Enabled = true;
            isGameRunning = false;

            this.AcceptButton = btnStart;

            if (t != null)
            {
                t.Stop();
                t = null;
            }
        }
        #endregion

        #region Helper

        private int getLivingNeighbours(int x, int y)
        {
            int sum = 0;
            int xbound = zellen.GetUpperBound(0);
            int ybound = zellen.GetUpperBound(1);
            if (!cbTorus.Checked)
            {
                sum += x - 1 >= 0 && y - 1 >= 0 && x - 1 <= xbound && y - 1 <= ybound && zellen[x - 1, y - 1].Status == ZellenStatus.Lebt ? 1 : 0;
                sum += x >= 0 && y - 1 >= 0 && x <= xbound && y - 1 <= ybound && zellen[x, y - 1].Status == ZellenStatus.Lebt ? 1 : 0;
                sum += x + 1 >= 0 && y - 1 >= 0 && x + 1 <= xbound && y - 1 <= ybound && zellen[x + 1, y - 1].Status == ZellenStatus.Lebt ? 1 : 0;

                sum += x - 1 >= 0 && y >= 0 && x - 1 <= xbound && y <= ybound && zellen[x - 1, y].Status == ZellenStatus.Lebt ? 1 : 0;
                sum += x + 1 >= 0 && y >= 0 && x + 1 <= xbound && y <= ybound && zellen[x + 1, y].Status == ZellenStatus.Lebt ? 1 : 0;

                sum += x - 1 >= 0 && y + 1 >= 0 && x - 1 <= xbound && y + 1 <= ybound && zellen[x - 1, y + 1].Status == ZellenStatus.Lebt ? 1 : 0;
                sum += x >= 0 && y + 1 >= 0 && x <= xbound && y + 1 <= ybound && zellen[x, y + 1].Status == ZellenStatus.Lebt ? 1 : 0;
                sum += x + 1 >= 0 && y + 1 >= 0 && x + 1 <= xbound && y + 1 <= ybound && zellen[x + 1, y + 1].Status == ZellenStatus.Lebt ? 1 : 0;
            }
            else
            {
                List<Point> points = new List<Point>();

                points.Add(new Point(getLimitNumber(x - 1, xbound), getLimitNumber(y - 1, ybound)));
                points.Add(new Point(getLimitNumber(x, xbound), getLimitNumber(y - 1, ybound)));
                points.Add(new Point(getLimitNumber(x + 1, xbound), getLimitNumber(y - 1, ybound)));

                points.Add(new Point(getLimitNumber(x - 1, xbound), getLimitNumber(y, ybound)));
                points.Add(new Point(getLimitNumber(x + 1, xbound), getLimitNumber(y, ybound)));

                points.Add(new Point(getLimitNumber(x - 1, xbound), getLimitNumber(y + 1, ybound)));
                points.Add(new Point(getLimitNumber(x, xbound), getLimitNumber(y + 1, ybound)));
                points.Add(new Point(getLimitNumber(x + 1, xbound), getLimitNumber(y + 1, ybound)));

                foreach (var p in points)
                    sum += zellen[p.X, p.Y].Status == ZellenStatus.Lebt ? 1 : 0;
            }
            return sum;
        }

        private int getLimitNumber(int number, int max)
        {
            number = number < 0 ? max - number - 1 : number;
            number = number > max ? number % (max + 1) : number;
            return number;
        }

        private void LoadRuleSets()
        {
            _rulesets.Clear();
            System.IO.FileInfo[] rules = (new System.IO.DirectoryInfo(".\\Rules")).GetFiles("*.xml", System.IO.SearchOption.TopDirectoryOnly);
            _rulesets.Add(RuleSet.DefaultSet);
            foreach (var r in rules)
            {
                try
                {
                    _rulesets.Add(RuleSet.fromFile(r.FullName));
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                    Console.Error.WriteLine(e.StackTrace);
                }
            }
        }

        #endregion

    }
}
