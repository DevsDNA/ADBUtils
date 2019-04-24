namespace AdbUtils
{
    public class UINode
    {
        public int Index { get; set; }

        public string Text { get; set; }

        public string ResourceId { get; set; }

        public string Class { get; set; }

        public string Package { get; set; }

        public string ContentDescription { get; set; }

        public bool Checkable { get; set; }

        public bool Checked { get; set; }

        public bool Clickable { get; set; }

        public bool Enabled { get; set; }

        public bool Focusable { get; set; }

        public bool Focused { get; set; }

        public bool Scrollable { get; set; }

        public bool LongClickable { get; set; }

        public bool Password { get; set; }

        public bool Selected { get; set; }

        public Bounds Bounds { get; set; }
    }
}
