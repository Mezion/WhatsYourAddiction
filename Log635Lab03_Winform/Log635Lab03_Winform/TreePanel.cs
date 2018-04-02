using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log635Lab03_Winform
{
    public partial class TreePanel : Panel
    {
        private TreeNode _root;

        public TreeNode Root
        {
            set { _root = value; Invalidate(); }
        }

        public TreePanel()
        {
            InitializeComponent();
        }

        public TreePanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var graphics = e.Graphics;

            if (_root != null)
                PaintTreeNode(graphics, _root, 0, false, new PointF(10000, 50));
        }

        private void PaintTreeNode(Graphics graphics, TreeNode node, int depth, bool right, PointF ParentPosition)
        {
            if (node == null)
            {
                return;
            }
            
            var multiple = right ? 1 : -1;

            var x = ParentPosition.X + 100 * multiple * (30 / (depth + 1));
            var y = ParentPosition.Y + 100;
            var loc = new PointF(x, y);
            
            graphics.DrawString(node.Column, new Font("Consolas", 10), new SolidBrush(Color.Black), loc);

            if (depth != 0)
            {
                graphics.DrawLine(new Pen(Color.Black), new PointF(ParentPosition.X, ParentPosition.Y + 15),
                    new PointF(loc.X, loc.Y - 15));
            }

            var px = x - (ParentPosition.X - x) / 2;
            var py = y - (ParentPosition.Y - y) / 2;

            //if (right)
            //    graphics.DrawString(node.TrueFilterExpression, new Font("Consolas", 6),
            //        new SolidBrush(Color.Black), new PointF(px, py));
            //else
            //    graphics.DrawString(node.FalseFilterExpression, new Font("Consolas", 6),
            //        new SolidBrush(Color.Black), new PointF(px, py));

            PaintTreeNode(graphics, node.ChildTrue, depth + 1, true, loc);
            PaintTreeNode(graphics, node.ChildFalse, depth + 1, false, loc);
        }
    }
}
