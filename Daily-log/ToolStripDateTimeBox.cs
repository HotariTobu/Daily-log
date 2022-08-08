using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daily_log
{
    public partial class ToolStripDateTimeBox : ToolStripMenuItem
    {
        protected internal enum Type
        {
            Year,
            Month,
            Day,
            DayOfWeek,
            DayOfYear,
            Hour,
            Minute,
            Second,
            MilliSecond,
            Ticks,
            None,
        }

        protected internal struct Frame
        {
            public Frame(Type type, int index, int length)
            {
                Type = type;
                Index = index;
                Length = length;
                Text = string.Empty;
            }

            public Type Type { get; }
            public int Index { get; }
            public int Length { get; }
            public string Text { get; set; }
        }

        private List<Frame> FrameList;
        private readonly (Type, char)[] Table =
        {
            (Type.Year,'Y'),
            (Type.Month,'M'),
            (Type.Day,'D'),
            (Type.DayOfWeek,'W'),
            (Type.DayOfYear,'A'),
            (Type.Hour,'h'),
            (Type.Minute,'m'),
            (Type.MilliSecond,'n'),
            (Type.Ticks,'t'),
        };
        /*
         * ex) "YY/MM/DD" 
         */
        public string Format
        {
            get
            {
                string result = string.Empty;
                if (FrameList != null)
                {
                    foreach (Frame frame in FrameList)
                    {

                    }
                }
                return result;
            }
            set
            {
                if (FrameList != null)
                {
                    string copy = value;
                    foreach ((Type, char) pair in Table)
                    {
                        Regex regex = new Regex($"[{pair.Item2}]+");
                        foreach (Match match in regex.Matches(copy))
                        {
                            if (match.Success)
                            {
                                FrameList.Add(new Frame(pair.Item1, match.Index, match.Length));
                            }
                        }
                        copy = copy.Replace(pair.Item2, '\b');
                    }

                    {
                        Regex regex = new Regex($"[^\b]+");
                        foreach (Match match in regex.Matches(copy))
                        {
                            if (match.Success)
                            {
                                Frame frame = new Frame(Type.None, match.Index, match.Length);
                                frame.Text = match.Value;
                                FrameList.Add(frame);
                            }
                        }
                    }

                    FrameList.Sort((a, b) => (a.Index - b.Index));
                    this.Invalidate();
                }
            }
        }

        public DateTime DateTime { get; set; }

        //protected override bool DismissWhenClicked { get => false; }

        public ToolStripDateTimeBox() : base()
        {
            FrameList = new List<Frame>();
        }
        public ToolStripDateTimeBox(string format) : this()
        {
            Format = format;
        }
        public ToolStripDateTimeBox(DateTime dateTime) : this()
        {
            DateTime = dateTime;
        }
        public ToolStripDateTimeBox(string format, DateTime dateTime) : this(format)
        {
            DateTime = dateTime;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            FrameList.Clear();
        }

        protected override bool IsInputChar(char charCode)
        {
            Debug.WriteLine("IsInputChar : " + charCode);
            if ("0123456789".Contains(charCode))
            {
                return true;
            }

            return false;
        }
        protected override bool IsInputKey(Keys keyData)
        {
            Debug.WriteLine("IsInputKey : " + keyData);
            return false;
        }
        protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        {
            Debug.WriteLine("ProcessCmdKey : " + m + ", " + keyData);
            return false;
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            Debug.WriteLine("ProcessDialogKey : " + keyData);
            return false;
        }
        protected override bool ProcessMnemonic(char charCode)
        {
            Debug.WriteLine("ProcessMnemonic : " + charCode);
            return false;
        }

        private EventHandler onDateTimeChanged;
        public event EventHandler DateTimeChanged
        {
            add
            {
                onDateTimeChanged += value;
            }
            remove
            {
                onDateTimeChanged -= value;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            Debug.WriteLine("Clicked");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Debug.WriteLine("Painting : " + e.ClipRectangle+ContentRectangle);

            e.Graphics.DrawString("TEST", Font, new SolidBrush(ForeColor), 0, 0);
        }
    }
}
