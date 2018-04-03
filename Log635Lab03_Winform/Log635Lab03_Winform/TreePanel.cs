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
        private int _depth = 0;

        public TreeNode Root
        {
            set
            {
                _root = value;
                Invalidate();
            }
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
                PaintTreeNode(graphics, _root, 0, false, new PointF(50, 10000));
        }

        private void PaintTreeNode(Graphics graphics, TreeNode node, int depth, bool right, PointF parentPosition)
        {
            if (node == null)
            {
                return;
            }
            
            var ymultiple = right ? 1 : -0.5f;
            var xmultiple = right ? 1 : .5f;


            int childCount = 0;
            GetNeededSpace(node, ref childCount);

            var x = parentPosition.X + 500 + (childCount * 0.5f) * xmultiple + depth * 2;
            var y = parentPosition.Y + (150 + childCount * 20f) * ymultiple + depth * 2;
            var loc = new PointF(x, y);
            
            graphics.DrawString(node.TrueFilterExpression, new Font("Consolas", 10), new SolidBrush(Color.Black), loc);

            if (depth != 0)
            {
                var yadd = right ? 15: 2;
                graphics.DrawLine(
                    new Pen(Color.Black),
                    new PointF(parentPosition.X + 35, parentPosition.Y + yadd),
                    new PointF(loc.X - 5, loc.Y + 3)
                );
            }

            var px = x - (parentPosition.X - x) / 2;
            var py = y - (parentPosition.Y - y) / 2;

            //if (right)
            //    graphics.DrawString(node.TrueFilterExpression, new Font("Consolas", 6),
            //        new SolidBrush(Color.Black), new PointF(px, py));
            //else
            //    graphics.DrawString(node.FalseFilterExpression, new Font("Consolas", 6),
            //        new SolidBrush(Color.Black), new PointF(px, py));

            PaintTreeNode(graphics, node.ChildTrue, 3, true, loc);
            PaintTreeNode(graphics, node.ChildFalse, 5, false, loc);
        }

        private void GetNeededSpace(TreeNode node, ref int nodeCount)
        {
            if (node.ChildTrue != null)
            {
                nodeCount++;
                GetNeededSpace(node.ChildTrue, ref nodeCount);
            }

            if (node.ChildFalse != null)
            {
                nodeCount++;
                GetNeededSpace(node.ChildFalse, ref nodeCount);
            }
        }
    }
}
