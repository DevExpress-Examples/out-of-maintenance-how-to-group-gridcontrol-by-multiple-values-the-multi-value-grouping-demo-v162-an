using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;

namespace DXApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow {
        public MainWindow()
        {
            InitializeComponent();
            gc = new GroupingControllerTasksWithCategories(grid);
            gc.AfterGrouping += new EventHandler(gc_AfterGrouping);
            InitButtonCaption();
        }

        private void groupButton_Click(object sender, RoutedEventArgs e)
        {
            if (gc.CategoryColumn == null)
            {
                groupButton.IsEnabled = false;
                return;
            }
            if (!gc.CategoryColumn.IsGrouped)
                grid.GroupBy(gc.CategoryColumn);
            else grid.UngroupBy(gc.CategoryColumn);

        }

        GroupingControllerTasksWithCategories gc;
        void InitButtonCaption()
        {
            groupButton.Content = gc.IsCategoryGrouping ? " Ungroup by 'Category'" : "Group by 'Category'";
        }

        void gc_AfterGrouping(object sender, EventArgs e)
        {
            InitButtonCaption();
        }
    }
}
