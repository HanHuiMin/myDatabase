#数据库大作业mymetro
**简介：工程名为mymetro,数据库大作业开发**

----------
# 运行前的准备

## 安装依赖
需要安装文件mysql-connector-net-6.3.8.msi

打开工程，解决方案资源管理器窗口，在“引用”上点击右键-->添加引用，点击“浏览”，选择文件路径。

文件路径一般会在C:\Program Files (x86)\MySQL\MySQL Connector Net 6.3.8\Assemblies\v2.0中

打开这个文件夹，在里面选中MySQL.Data.dll,点击添加，然后在“引用管理器”窗口中选中MySQL.Data.dll，点击确定即可。

## 与MySQL进行连接
在MySQL数据库中新建数据库和数据表，即可在工程中读取。

读取办法详见下文中的[全局抽象类MySqlHelper和Tools的功能]

# 如何在工程中新建窗口
## 添加窗口
打开解决方案管理器，右键点击mymetro-->添加-->窗口
然后为自己创建的窗口命名，例如dataWindow
## 通过修改XAML文件更改为Metro主题
下面以dataWindow为例说明xaml文件中需要修改的内容
打开dataWindow.xaml
将文件内容修改为：

    <controls:MetroWindow x:Class="mymetro.dataWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:mymetro"
            xmlns:controls="clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro"
            xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
    	    xmlns:Behaviours="clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro"
            xmlns:iconPacks="http://metro.mahapps.com/winfx/xaml/iconpacks"
            mc:Ignorable="d"
            Title="数据查看窗口" Height="300" Width="400">
        <Grid>
         <!--此处可以添加控件-->
        </Grid>
    </controls:MetroWindow>
注意！第一行的“Class=mymetro.dataWindow”后面的内容要写成自己新建的窗口名称，如果新建别的窗口一定要更改。
## 在主界面中弹出新建的窗口
主界面窗口是MainWindow

打开MainWindow.xaml.cs文件

在button1_Click()方法中添加以下内容

    dataWindow dw = new dataWindow();
    dw.Show();
    
即可让新建的dataWindow启动。

[注]最好将新建的窗口设置为MainWindow类中的变量，方便不同方法进行调用

# 全局抽象类MySqlHelper和Tools的功能
这两个类都是abstract,不能实例化，可以直接使用Tools.messageBox("123")的方式调用
## MySqlHelper
简介：MySqlHelper引用了MySql.Data,能够与MySQL数据库进行连接,一般除了Conn字符串之外不需修改其他部分

string Conn="Database='airline';Data Source='localhost';User Id='root';Password='jisuozhao123';charset='utf8';pooling=true";

数据库名称为airline,数据库位置是本地服务器，用户是root，密码是自己数据库的密码



