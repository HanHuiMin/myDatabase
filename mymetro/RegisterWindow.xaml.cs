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
using System.Collections;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace mymetro
{
	/// <summary>
	/// RegisterWindow.xaml 的交互逻辑
	/// </summary>
	public partial class RegisterWindow : MetroWindow
	{
		public RegisterWindow()
		{
			InitializeComponent();
		}
		private bool addData(String property, String newvalue)//通过sql命令添加用户数据
		{
			bool flag = Tools.executeSqlCmd("insert into passenger set " + property + "=\"" + newvalue + "\" where passenger_id=\"" + CommonData.user_id + "\"");
			return flag;
		}
		private void button1_Click(object sender, RoutedEventArgs e)
		{
			//注册功能
			String quote = "\"";//引号
			String comma = "\",\"";//双引号加逗号
			bool result = Tools.executeSqlCmd("insert into passenger values("
				+quote+passenger_id.Text+comma
				+passenger_password.Text+comma
				+passenger_Name.Text+comma
				+passenger_Idnum.Text+comma
				+passenger_tel.Text+comma
				+passenger_add.Text+quote+");");
			if (result)
			{
				Tools.messageBox("注册成功");
			}
			else
			{
				Tools.messageBox("注册失败");
			}
		}
	}
}
