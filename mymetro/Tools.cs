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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace mymetro
{
	/// <summary>
	/// 工具集，包含数据库的操作以及各种工具
	/// </summary>
	public abstract class Tools
	{
		public static bool warning = false;//是否显示警告
		/// <summary>
		/// 连接数据库，将要显示的表显示在dataGrid中
		/// </summary>
		/// <param name="dataGrid">显示数据表的区域</param>
		/// <param name="tableName">表的名称</param>
		/// <param name="tableIndex">表的序号，从0开始</param>
		public static void showDatabase(DataGrid dataGrid,String tableName,int tableIndex)//显示数据库
		{
			//自动连接数据库
			dataGrid.DataContext= MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from "+tableName, null).Tables[tableIndex].DefaultView;
		}
		/// <summary>
		/// 将DataSet的第index个表显示在dataGrid中
		/// </summary>
		/// <param name="dataGrid"></param>
		/// <param name="ds"></param>
		/// <param name="tableIndex"></param>
		public static void showDataTable(DataGrid dataGrid,DataSet ds,int tableIndex)
		{
			dataGrid.DataContext = ds.Tables[tableIndex].DefaultView;
		}
		/// <summary>
		/// 执行sql命令，执行成功返回true，不成功返回false
		/// </summary>
		/// <param name="sqlcmd"></param>
		/// <returns></returns>
		public static bool executeSqlCmd(String sqlcmd)
		{
			try
			{
				MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlcmd, null);
			}
			catch (Exception e1)
			{
				//Console.WriteLine(e1);
				return false;
			}
			return true;
		}
		/// <summary>
		/// 通过指定SQL命令获取数据集DataSet
		/// </summary>
		/// <param name="sqlcmd"></param>
		/// <returns></returns>
		public static DataSet getDataSet(String sqlcmd)
		{
			try
			{
				DataSet ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlcmd, null);
				if(warning)Tools.messageBox("数据库读取成功");
				return ds;
			}
			catch (Exception e2)
			{
				if(warning)Tools.messageBox("数据库读取失败");
				return null;
			}
			
		}
		/// <summary>
		/// 获取数据表，sqlcmd是sql命令，index是表的序号，一般为0
		/// </summary>
		/// <param name="sqlcmd"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static DataTable getDataTable(String sqlcmd,int index)
		{
			try
			{
				DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqlcmd, null).Tables[index];
				if (warning) Tools.messageBox("数据库读取成功");
				return dt;
			}
			catch (Exception e3)
			{
				if (warning) Tools.messageBox("数据库读取失败");
				return null;
			}

		}
		/// <summary>
		/// 弹出提示框，输入的提示信息
		/// </summary>
		/// <param name="str"></param>
		public static void messageBox(String str)
		{
			MessageBox.Show(str);
		}
		/// <summary>
		/// 弹出Preview窗体，预览DataTable的数据
		/// </summary>
		/// <param name="dt"></param>
		public static void previewDataTable(DataTable dt)
		{
			dataWindow dw = new dataWindow(dt);//显示dt查询结果
			dw.Show();//显示查询结果
		}
	}
}
