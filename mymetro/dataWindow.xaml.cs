using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Data;

namespace mymetro
{
	/// <summary>
	/// dataWindow.xaml 的交互逻辑
	/// </summary>
	public partial class dataWindow : MetroWindow
	{
		public dataWindow()
		{
			InitializeComponent();
		}
		/// <summary>
		/// 带参数的初始化，可以直接在dataGrid中显示dt表
		/// </summary>
		public dataWindow(DataTable dt)
		{
			InitializeComponent();
			this.Title = "Preview";
			if(dt!=null)
				dataGrid.DataContext =dt.DefaultView;
		}
		private void button1_Click(object sender, RoutedEventArgs e)
		{
			DataSet ds = Tools.getDataSet(text1.Text);
			if (ds == null)
			{
				return;
			}
			Tools.showDataTable(dataGrid, ds, 0);
		}
		private void button2_Click(object sender, RoutedEventArgs e)
		{
			int success = 0;
			int failure = 0;
			String[] cmds = text2.Text.Split(';');
			foreach(String sqlcmd in cmds)
			{
				if (sqlcmd.Equals("")||sqlcmd.Length<=3)
					continue;
				bool result = Tools.executeSqlCmd(sqlcmd);
				if (result)//统计成功失败的次数
				{
					success++;
				}
				else
				{
					failure++;
				}
			}
			Tools.messageBox("共执行" + (success + failure) + "条语句，成功" + success + "条，失败" + failure + "条");
		}

		private void button3_Click(object sender, RoutedEventArgs e)
		{
			text2.Text = "";
		}
	}
}
