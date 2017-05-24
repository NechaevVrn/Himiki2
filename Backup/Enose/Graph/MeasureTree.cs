using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuadroSoft.Enose.DataAccess;
using QuadroSoft.Enose.Dialogs;
using QuadroSoft.Enose.DataModel;

namespace QuadroSoft.Enose.Graph
{
    public partial class MeasureTree : UserControl
    {
        private bool showMeasures = true;
        /// <summary>
        /// Отображать измерения в дереве
        /// </summary>
        public bool ShowMeasures
        {
            get { return showMeasures; }
            set { showMeasures = value; refresh(showMeasures); }
        }

        /// <summary>
        /// Получить выбранную группу 
        /// </summary>
        public DataProvider.GroupTreeNode SelectedGroup
        {
            get
            {
                if (treeView.SelectedNode == null)
                    return null;
                if (treeView.SelectedNode.Tag == null)
                    return null;
                else if (treeView.SelectedNode.Tag is QuadroSoft.Enose.DataAccess.DataProvider.GroupTreeNode)
                    return treeView.SelectedNode.Tag as QuadroSoft.Enose.DataAccess.DataProvider.GroupTreeNode;
                else if (treeView.SelectedNode.Tag is Int32)
                    return treeView.SelectedNode.Parent.Tag as QuadroSoft.Enose.DataAccess.DataProvider.GroupTreeNode;
                else return null;

            }
        }

        /// <summary>
        /// Освежить список.
        /// </summary>
        /// <param name="showmeasures">показывать измерения</param>
        private void refresh(bool showmeasures)
        {
            Program.Service.PlotGroupTree(treeView, showmeasures);
            treeView.ExpandAll();
        }

        public MeasureTree()
        {
            InitializeComponent();
            try
            {
                refresh(true);
            }
            catch { }
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            DataProvider.GroupTreeNode node = SelectedGroup;
            int nodeid = node == null ? -1 : node.ID;

            string res = FormStringRequest.GetString("Введите название группы");
            if (res != null)
            {
                Program.DataProvider.AddGroupTo(new DataProvider.GroupTreeNode(-1, res, ""), nodeid);
                refresh(ShowMeasures);
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            object o = treeView.SelectedNode.Tag;
            if (o == null)
            {
                buttonAddGroup.Enabled = true;
                buttonDelete.Enabled = false;
                buttonOpen.Enabled = false;
            }
            else if (o is QuadroSoft.Enose.DataAccess.DataProvider.GroupTreeNode)
            {
                buttonOpen.Enabled = false;
                buttonAddGroup.Enabled = true;
                buttonDelete.Enabled = true;
            }
            else if (o is Int32)
            {
                buttonOpen.Enabled = true;
                buttonAddGroup.Enabled = true;
                buttonDelete.Enabled = true;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            TreeNode tnode = treeView.SelectedNode;

            if (tnode == null) return;
            if (tnode.Tag == null) return;

            if (tnode.Tag is DataProvider.GroupTreeNode)
            {
                DataProvider.GroupTreeNode nd = tnode.Tag as DataProvider.GroupTreeNode;
                if (MessageBox.Show("При удалении группы все помещённые\r\nв неё подгруппы будут удалены, а\r\nизмерения помещены в корневую группу.\r\nУдалить группу?", "Удаление группы", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Program.DataProvider.DeleteGroup(nd.ID);
                    refresh(ShowMeasures);
                }
            }
            else if (tnode.Tag is Int32)
            {
                int id = (int)tnode.Tag;
                if (MessageBox.Show("Удалить измерение?", "Удаление измерения", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Program.DataProvider.delete("Measures", "ID=" + id);
                    refresh(ShowMeasures);
                }
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null || treeView.SelectedNode.Tag == null) return;
            else if (treeView.SelectedNode.Tag is Int32)
            {
                FormViewMeasure f = FormViewMeasure.getFormForMeasure(Program.DataProvider.getMeasureDataByID((int)treeView.SelectedNode.Tag));
            }
        }

        public object TagOfSelected
        {
            get
            {
                if (treeView.SelectedNode == null)
                    return null;
                else
                    return treeView.SelectedNode.Tag;
            }
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null && (e.Node.Tag is Int32))
            {
                FormViewMeasure f = FormViewMeasure.getFormForMeasure(Program.DataProvider.getMeasureDataByID((int)treeView.SelectedNode.Tag));
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
                treeView.SelectedNode = e.Node;
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            Program.Service.PlotGroupTree(this.treeView, ShowMeasures);
            treeView.ExpandAll();
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            treeView.ExpandAll();
        }

        private void buttonCollapse_Click(object sender, EventArgs e)
        {
            treeView.CollapseAll();
        }

        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                buttonDelete_Click(sender, null);
            else if (e.KeyCode == Keys.Enter)
                buttonOpen_Click(sender, null);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonOpen_Click(null, null);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonDelete_Click(null, null);
        }

        private void добавитьГруппуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonAddGroup_Click(null, null);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            object o = TagOfSelected;
            DataProvider.GroupTreeNode other;

            if (o == null)
            {
                MessageBox.Show("Нечего непемещать!");
            }
            else
            {
                if (o is DataProvider.GroupTreeNode)
                {
                    if ((other = FormSelectOneGroup.getNode()) != null)
                    {
                        if (!Program.DataProvider.willMakeCycle((o as DataProvider.GroupTreeNode).ID, other.ID))
                            Program.DataProvider.updateGroupParentId((o as DataProvider.GroupTreeNode).ID, other.ID);
                        else
                            MessageBox.Show("Такое перемещение запрещено из-за образования цикла в дереве!");
                    }
                    else
                        Program.DataProvider.updateGroupParentId((o as DataProvider.GroupTreeNode).ID, -1);

                }
                else if (o is Int32)
                {
                    MeasureData md = Program.DataProvider.getMeasureDataByID((int)o);

                    if (md != null)
                    {
                        if ((other = FormSelectOneGroup.getNode()) != null)
                            md.GroupID = other.ID;
                        else
                            md.GroupID = -1;
                        
                        Program.DataProvider.updateMeasureData(md);
                    }
                }

                this.ShowMeasures = this.ShowMeasures;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            object o = TagOfSelected;

            if (o == null)
            {
                MessageBox.Show("Нечего переименовывыть!");
            }
            else
            {
                if (o is DataProvider.GroupTreeNode)
                {
                    string s = null;
                    if ((s = FormStringRequest.GetString("Новое название группы")) != null)
                    {
                        if (s.Trim() != "")
                            Program.DataProvider.RenameGroup((o as DataProvider.GroupTreeNode).ID, s);
                        else
                            MessageBox.Show("Введено неосмысленное название!");
                    }

                }
                else if (o is Int32)
                {
                    MeasureData md = Program.DataProvider.getMeasureDataByID((int)o);

                    if (md != null)
                    {
                        string s = null;
                        if ((s = FormStringRequest.GetString("Новое название измерения")) != null)
                        {
                            if (s.Trim() != "")
                            {
                                md.Name = s;
                                Program.DataProvider.updateMeasureData(md);
                            }
                            else
                                MessageBox.Show("Введено неосмысленное название!");
                        }
                    }
                }
                this.ShowMeasures = this.ShowMeasures;
            }
        }
    }
}
